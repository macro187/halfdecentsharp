// -----------------------------------------------------------------------------
// Copyright (c) 2010
// Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
//
// Permission to use, copy, modify, and distribute this software for any
// purpose with or without fee is hereby granted, provided that the above
// copyright notice and this permission notice appear in all copies.
//
// THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
// WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
// MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
// ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
// WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
// ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
// OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
// -----------------------------------------------------------------------------


using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace
Com.Halfdecent.Traitor
{


public class
Traitor
{


/// The <tt>traitor</tt> program
///
/// Usage:
/// <tt>traitor <inputdir> [<inputfiles>] <outputdir></tt>
///
public static
    int
Main(
    string[] args
)
{
    // Debug/trace to stderr
    Debug.Listeners.Add( new ConsoleTraceListener( true ) );

    // Grab dirs and file list from cmdline
    ReadArgs( args );
    if( infiles.Count == 0 ) {
        Trace.WriteLine( "Warning: No input file(s) specified" );
        return 0;
    }

    // Scan input files for traits
    ScanTraits();

    // Output files, injecting traits
    WriteFiles();

    return 0;
}


private struct
Trait
{
    public string           Name;
    public string           File;
    public int              Line;
    public string           Text;
    public int              TextLines;
    public IList< string >  Usings;
}


private static
    string
indir = "";

private static
    string
outdir = "";

private static
    IList< string >
infiles = new List< string >();

private static
    IDictionary< string, Trait >
traits = new Dictionary< string, Trait >();


private static
    void
Info(
    string  file,
    int     line,
    string  messageformat,
    params object[] formatargs
)
{
    Info( file, line, string.Format( messageformat, formatargs ) );
}


private static
    void
Info(
    string  file,
    int     line,
    string  message
)
{
    Debug.Print( "{0}({1},1): Info: {2}", file, line, message );
}


private static
    void
Error(
    string  file,
    int     line,
    string  messageformat,
    params object[] formatargs
)
{
    Error( file, line, string.Format( messageformat, formatargs ) );
}


private static
    void
Error(
    string  file,
    int     line,
    string  message
)
{
    Trace.TraceError( "{0}({1},1): Error: {2}", file, line, message );
    throw new Exception( message );
}


private static
    void
ReadArgs(
    string[] args
)
{
    if( args.Length >= 1 )
        indir = args[ 0 ];
    if( args.Length >= 2 )
        outdir = args[ args.Length-1 ];
    for( int i=1; i<=args.Length-2; i++ )
        infiles.Add( args[ i ] );

    if( indir == "" )
        throw new Exception( "No input directory specified" );
    if( outdir == "" )
        throw new Exception( "No output directory specified" );
}


private static
    void
ScanTraits()
{
    foreach( string infile in infiles ) {
        string path = Path.Combine( indir, infile );
        ScanTrait( path );
    }
}


private static
    void
ScanTrait(
    string path
)
{
    using( TextReader reader = File.OpenText( path ) ) {

    int             linenum = 0;
    bool            inblock = false;
    int             blocklinenum = -1;
    int             ifdepth = 0;
    IList< string > usings = new List< string >();
    string          name = "";
    StringBuilder   text = new StringBuilder();
    int             textlines = 0;

    for( ;; ) {
        string line = reader.ReadLine();
        if( line == null ) break;
        linenum++;

        if( !inblock ) {

            // Entering the "#if TRAITOR" block
            if( line.Trim() == "#if TRAITOR" ) {
                inblock = true;
                blocklinenum = linenum+1;
                continue;
            }

            // using directive
            if( line.Trim().StartsWith( "using " ) ) {
                usings.Add( line.Trim() );
            }

            continue;
        }

        // Exiting trait block #if
        if( ifdepth == 0 && line.Trim().StartsWith( "#endif" ) ) {
            if( text.Length == 0 )
                continue;
            if( name == "" )
                Error( path, blocklinenum,
                    "No '// Trait <name>' line in '#if TRAITOR' block" );
            if( traits.ContainsKey( name ) )
                Error( path, blocklinenum,
                    "Found duplicate trait '{0}'", name );
            traits.Add(
                name,
                new Trait() {
                    Name = name,
                    File = path,
                    Line = blocklinenum,
                    Text = text.ToString(),
                    TextLines = textlines,
                    Usings = usings } );
            inblock = false;
            blocklinenum = -1;
            text.Length = 0;
            textlines = 0;
            continue;
        }

        // Add the line to the trait text
        text.AppendLine( line );
        textlines++;

        // Entering a nested #if
        if( line.Trim().StartsWith( "#if" ) ) {
            ifdepth++;
            continue;
        }

        // Exiting a nested #if
        if( line.Trim().StartsWith( "#endif" ) ) {
            ifdepth--;
            continue;
        }

        // "// Trait <traitname>"
        if( line.StartsWith( "// Trait " ) ) {
            name = line.Substring( 9 ).Trim();
            if( name == "" )
                Error( path, linenum,
                    "No trait name specified on '// Trait <name>' line" );
            continue;
        }

    }

    } // using(s)
}


private static
    void
WriteFiles()
{
    foreach( string infile in infiles ) {
        string inpath = Path.Combine( indir, infile );
        string outpath = Path.Combine( outdir, infile );
        WriteFile( inpath, outpath );
    }
}


private static
    string
LineRef(
    int     linenumber,
    string  filename
)
{
    filename = filename ?? "";
    return string.Format(
        "#line {0}{1}{2}",
        linenumber,
        filename != "" ? " " : "",
        filename );
}


private static
    void
WriteFile(
    string inpath,
    string outpath
)
{
    //
    // Pass 1
    // - Learn which traits will be referenced
    //
    // Pass 2
    // - Copy source file contents
    // - Insert 'using' directives from traits
    // - Insert trait contents
    // - TODO Insert source #file directives
    //

    TextReader reader = null;
    TextWriter writer = null;

    try {

    IList< string >         traitsused = new List< string >();
    ICollection< string >   traitswritten = new HashSet< string >();
    ICollection< string >   usingswritten = new HashSet< string >();

    string  line;
    int     linenum = 0;
    bool    inblock = false;
    bool    inusingblock = false;
    bool    pass2 = false;

    reader = File.OpenText( inpath );
    writer = File.CreateText( outpath );

    for( ;; ) {
        line = reader.ReadLine();
        if( line == null ) {

            // End of first pass, restart
            if( !pass2 ) {
                reader.Dispose();
                reader = File.OpenText( inpath );
                linenum = 0;
                pass2 = true;
                continue;

            // End of second pass, done
            } else {
                break;

            }
        }
        linenum++;

        if( pass2 && linenum == 1 )
            writer.WriteLine( LineRef( 1, inpath ) );

        // Usings
        if( pass2 ) {

            // Entering/in using block
            if( line.Trim().StartsWith( "using " ) ) {
                inusingblock = true;
                usingswritten.Add( line.Trim() );

            // End of using block, append usings from traits
            } else if( inusingblock ) {
                inusingblock = false;
                foreach( string usedname in traitsused )
                    foreach( string usedusing in traits[ usedname ].Usings )
                        if( !usingswritten.Contains( usedusing ) ) {
                            writer.WriteLine(
                                // TODO Track using line #'s
                                LineRef( 1, traits[ usedname ].File ) );
                            writer.WriteLine( usedusing );
                            writer.WriteLine( LineRef( linenum, inpath ) );
                            usingswritten.Add( usedusing );
                        }
            }

        }

        // Entering the block "#region TRAITOR"
        if( !inblock && line.Trim() == "#region TRAITOR" )
            inblock = true;

        // "// <traitname>" reference
        if( inblock && line.Trim().StartsWith( "// " ) ) {
            string name = line.Substring( 3 ).Trim();
            if( !traits.ContainsKey( name ) )
                Error( inpath, linenum,
                    "Reference to non-existent trait '{0}'", name );
            if( !pass2 ) {
                traitsused.Add( name );
            } else {
                if( traitswritten.Count > 0 ) writer.WriteLine();
                writer.WriteLine(
                    LineRef( traits[ name ].Line, traits[ name ].File ) );
                writer.Write(
                    traits[ name ].Text );
                writer.WriteLine(
                    LineRef( linenum+1, inpath ) ); // +1 because we're
                                                    // replacing the reference
                                                    // line
                traitswritten.Add( name );
            }
            continue;
        }

        // Exiting the block "#endregion"
        if( inblock && line.Trim() == "#endregion" ) {
            inblock = false;
        }

        // Write the line to the output file
        if( pass2 )
            writer.WriteLine( line );
    }

    } finally {
        if( reader != null ) reader.Dispose();
        if( writer != null ) writer.Dispose();
    }
}




} // class
} // namespace

