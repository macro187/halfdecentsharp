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
    IDictionary< string, string >
traits = new Dictionary< string, string >();


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

    int linenum = 0;
    bool inblock = false;
    int blocklinenum = -1;
    int ifdepth = 0;
    string name = "";
    StringBuilder text = new StringBuilder();

    for( ;; ) {
        string line = reader.ReadLine();
        if( line == null ) break;
        linenum++;

        // Entering the "#if TRAITOR" block
        if( !inblock ) {
            if( line.Trim() == "#if TRAITOR" ) {
                inblock = true;
                blocklinenum = linenum;
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
//            Info( path, blocklinenum, "Found trait '{0}'", name );
            traits.Add( name, text.ToString() );
            inblock = false;
            blocklinenum = -1;
            text.Length = 0;
            continue;
        }

        // Add the line to the trait text
        text.AppendLine( line );

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
    void
WriteFile(
    string inpath,
    string outpath
)
{
    using( TextReader reader = File.OpenText( inpath ) ) {
    using( TextWriter writer = File.CreateText( outpath ) ) {

    int linenum = 0;
    bool inblock = false;
    bool firsttrait = true;

    for( ;; ) {
        string line = reader.ReadLine();
        if( line == null ) break;
        linenum++;

        // Entering the block "#region TRAITOR"
        if( !inblock && line.Trim() == "#region TRAITOR" )
            inblock = true;

        // "// <traitname>" reference
        if( inblock && line.Trim().StartsWith( "// " ) ) {
            string name = line.Substring( 3 ).Trim();
            if( !traits.ContainsKey( name ) )
                Error( inpath, linenum,
                    "Reference to non-existent trait '{0}'", name );
//            Info( inpath, linenum, "Inserting trait '{0}'", name );
            if( !firsttrait ) writer.WriteLine();
            writer.Write( traits[ name ] );
            firsttrait = false;
            continue;
        }

        // Exiting the block "#endregion"
        if( inblock && line.Trim() == "#endregion" ) {
            inblock = false;
            firsttrait = true;
        }

        // Write the line to the output file
        writer.WriteLine( line );
    }

    }} // using(s)
}




} // class
} // namespace

