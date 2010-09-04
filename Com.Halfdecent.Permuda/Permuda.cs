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
Com.Halfdecent.Permuda
{


public class
Permuda
{


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
    Trace.WriteLine(
        string.Format( "{0}({1},1): Error: {2}", file, line, message ) );
    throw new Exception( message );
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


/// The <tt>permuda</tt> program
///
/// Usage:
/// <tt>permuda <inputdir> [<inputfiles>] <outputdir></tt>
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

    // Process each file
    foreach( string infile in infiles ) {
        string path = Path.Combine( indir, infile );

        usepermuda = false;
        permutechars = "";
        combos = new string[]{};
        permuteblank = false;
        filenamepattern = "";
        vars = new Dictionary< string, IDictionary< string, string > >();

        // Scan input file for Permuda info
        Scan( path );

        // If this file doesn't use Permuda, pass it along unchanged and
        // proceed to the next one
        if( !usepermuda ) {
            File.Copy( path, Path.Combine( outdir, infile ) );
            continue;
        }

        // Write out versions of the file as per Permuda directives
        WritePermutations( path, outdir );
    }

    return 0;
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


// Assumes var+combo doesn't already exist
//
private static
    void
AddVar(
    IDictionary< string, IDictionary< string, string > > vars,
    string varname,
    string combo,
    string val
)
{
    if( !vars.ContainsKey( varname ) )
        vars.Add( varname, new Dictionary< string, string >() );
    vars[ varname ].Add( combo, val );
}


private static bool     usepermuda = false;
private static string   permutechars = "";
private static string[] combos;
private static bool     permuteblank = false;
private static string   filenamepattern = "";
private static IDictionary< string, IDictionary< string, string > > vars;
private static ICollection< string > fileswritten = new HashSet< string >();


private static
    void
Scan(
    string path
)
{
    int             linenum = 0;
    bool            inblock = false;
    int             blockline = 0;
    string          blockvar = "";
    string          blockcombo = "";
    StringBuilder   blocktext = new StringBuilder();
    string[]        a;
    string          combo = "";
    string          val = "";

    using( TextReader reader = File.OpenText( path ) ) {

    for( ;; ) {
        string line = reader.ReadLine();
        if( line == null ) break;
        linenum++;

        // "#region PERMUDA[ <varname>[ <combo>]]"
        if( !inblock && line.StartsWith( "#region PERMUDA" ) ) {
            inblock = true;
            blockline = linenum;
            a = line.Substring( 15 ).Trim().Split( ' ' );
            blockvar = a.Length >= 1 ? a[0].Trim() : "";
            blockcombo = a.Length >= 2 ? a[1].Trim() : "";
            // XXX Check for too many words
            blocktext.Length = 0;
            if( blockvar != "" && blockcombo != "" )
                if( vars.ContainsKey( blockvar ) )
                    if( vars[ blockvar ].ContainsKey( blockcombo ) )
                        Error( path, linenum,
                            "Duplicate variable+combo block" );
            // If it's a "#region PERMUDA", enable permuda for this file
            if( blockvar == "" && blockcombo == "" ) usepermuda = true;
            continue;
        }

        // "#endregion"
        if( inblock && line.StartsWith( "#endregion" ) ) {

            // ...of a "#region PERMUDA <varname> <combo>" block
            if( blockvar != "" && blockcombo != "" ) {
                AddVar( vars, blockvar, blockcombo, blocktext.ToString() );
                //Info( path, blockline,
                //    "{0}: {1}:\n{2}",
                //    blockvar, blockcombo, blocktext.ToString() );

            // ...of a "#region PERMUDA" block
            } else if( blockvar == "" && blockcombo == "" ) {
                if( permutechars == "" && combos.Length == 0 )
                    Error( path, blockline,
                        "No permutechars or combos specified" );
                if( filenamepattern == "" )
                    Error( path, blockline, "No filenamechars specified" );
            }

            inblock = false;
            blockline = 0;
            blockvar = "";
            blockcombo = "";
            blocktext.Length = 0;
            continue;
        }

        // Line in a "#region PERMUDA" block
        if( inblock && blockvar == "" && blockcombo == "" ) {

            // "// permute <characters>"
            if( line.StartsWith( "// permute " ) ) {
                if( combos.Length > 0 )
                    Error( path, linenum, "Combos already specified" );
                permutechars = line.Substring( 11 ).Trim();
                if( permutechars.StartsWith( "_" ) ) {
                    permuteblank = true;
                    permutechars = permutechars.Substring( 1 );
                } else {
                    permuteblank = false;
                }
                if( permutechars == "" )
                    Error( path, linenum,
                        "No permutation character(s) specified" );
                //Info( path, linenum, "Permutation chars: '{0}'", permutechars );
                //Info( path, linenum, "Blank permutation: {0}", permuteblank );
                continue;
            }

            // "// combos <combo>[ <combo2>[ ...]]"
            if( line.StartsWith( "// combos " ) ) {
                if( permutechars != "" )
                    Error( path, linenum, "Permutechars already specified" );
                // TODO handle '_' permutation
                combos = line.Substring( 10 ).Trim().Split( ' ' );
                if( combos.Length == 0 )
                    Error( path, linenum, "No combo(s) specified" );
            }

            // "// filename <filenamepattern>"
            if( line.StartsWith( "// filename " ) ) {
                filenamepattern = line.Substring( 12 ).Trim();
                if( filenamepattern == "" )
                    Error( path, linenum,
                        "No filename pattern specified" );
                //Info( path, linenum,
                //    "Filename pattern: '{0}'", filenamepattern );
            }
            continue;
        }

        // Line in a "#region PERMUDA <varname>" block
        if( inblock && blockvar != "" && blockcombo == "" ) {
            if( !line.StartsWith( "// " ) )
                Error( path, linenum,
                    "Unrecognised line, expected '// <combo>: <value>'" );
            a = line.Substring( 3 ).Split( new char[]{':'}, 2 );
            combo = a.Length >= 1 ? a[0].Trim() : "";
            val = a.Length >= 2 ? a[1].Trim() : "";
            if( combo == "" )
                Error( path, linenum,
                    "Unrecognised line, expected '// <combo>: <value>'" );
            if( vars.ContainsKey( blockvar ) )
                if( vars[ blockvar ].ContainsKey( combo ) )
                    Error( path, linenum, "Duplicate variable+combo" );
            AddVar( vars, blockvar, combo, val );
            //Info( path, linenum, "{0}: {1}: '{2}'", blockvar, combo, val );
            combo = "";
            val = "";
            continue;
        }

        // Line in a "#region PERMUDA <varname> <combo>" block
        if( inblock && blockvar != "" && blockcombo != "" ) {
            blocktext.AppendLine( line );
            continue;
        }

    }

    CheckForAllVariableCombos( path );

    } // using(s)
}


private static
    void
CheckForAllVariableCombos(
    string path
)
{
    // Check for all combos for all vars
    IEnumerable< string > combosinuse =
        permutechars != ""
            ? AllCharCombinations( permutechars )
            : combos;
    foreach( string varname in vars.Keys )
        foreach( string combo in combosinuse )
            if( !vars[ varname ].ContainsKey( combo ) )
                Error( path, 1,
                    "No definition for Permuda variable '{0}' combo '{1}'",
                    varname,
                    combo );
}


private static
    void
WritePermutations(
    string inpath,
    string outdir
)
{
    if( permuteblank )
        WritePermutation( inpath, outdir, "" );

    IEnumerable< string > combosinuse =
        permutechars != ""
            ? AllCharCombinations( permutechars )
            : combos;
    foreach( string combo in combosinuse )
        WritePermutation( inpath, outdir, combo );
}


private static
    void
WritePermutation(
    string inpath,
    string outdir,
    string combo
)
{
    //Info( inpath, 1, "Combo '{0}'", combo );

    // Compute output filename
    // TODO track 'filenamepattern' source line
    string outfile = SubVars( inpath, 1, filenamepattern, combo );
    string outpath = Path.Combine( outdir, outfile );

    // Check for duplicate output files
    if( fileswritten.Contains( outpath ) )
        Error( inpath, 1,
            "Duplicate output file for combo '{0}' '{1}'", combo, outpath );
    fileswritten.Add( outpath );

    using( TextReader reader = File.OpenText( inpath ) ) {
    using( TextWriter writer = File.CreateText( outpath ) ) {

    int linenum = 0;
    bool inblock = false;

    for( ;; ) {
        string line = reader.ReadLine();
        if( line == null ) break;
        linenum++;

        // "#region PERMUDA"
        if( !inblock && line.StartsWith( "#region PERMUDA" ) ) {
            inblock = true;
            continue;
        }

        // "#endregion"
        if( inblock && line.StartsWith( "#endregion" ) ) {
            inblock = false;
            continue;
        }

        // Ignore anything inside a "#region PERMUDA"
        if( inblock ) continue;

        // Substitute variable references and write to output file
        writer.WriteLine( SubVars( inpath, linenum, line, combo ) );
    }

    }} // usings
}


private static
    string
SubVars(
    string path,
    int linenum,
    string s,
    string combo
)
{
    for( ;; ) {

        // Find "/*PERMUDA[ <varname>]*/" comment
        int start = s.IndexOf( "/*PERMUDA" );
        int end = s.IndexOf( "*/" );
        if( start < 0 ) break;
        if( end < 0 ) break;

        // Find <varname> within comment
        int varstart = start+9;
        int varlen = end - 9 - start;
        string varname = s.Substring( varstart, varlen ).Trim();
        //Info( path, linenum, "Varname '{0}'", varname );

        string varval;

        // No varname => combo
        if( varname == "" ) {
            varval = combo;

        // Blank combo => blank
        } else if( combo == "" ) {
            varval = "";

        // Otherwise, look up
        } else {
            if( !vars.ContainsKey( varname ) )
                Error( path, linenum,
                    "Undefined Permuda variable '{0}'", varname );
            varval = vars[ varname ][ combo ];
        }
        //Info( path, linenum, "Varval '{0}'", varval );

        // Substitute
        s =
            s.Substring( 0, start ) +
            varval +
            s.Substring( end+2 );
        //Info( path, linenum, "New string '{0}'", s );
    }
    return s;
}


private static
    IEnumerable< string >
AllCharCombinations(
    string chars
)
{
    foreach( int[] numcombo in AllCombinations( chars.Length ) ) {
        string combo = "";
        for( int i=0; i<numcombo.Length; i++ )
            combo += chars[ numcombo[i] ].ToString();
        yield return combo;
    }
}



private static
    IEnumerable< int[] >
AllCombinations(
    int kn
)
{
    for( int i=1; i<=kn; i++ )
        foreach( int[] a in Combinations( kn, i ) )
            yield return a;
}


private static
    IEnumerable< int[] >
Combinations(
    int n,
    int k
)
{
    if( n <= 0 ) throw new ArgumentOutOfRangeException( "n" );
    if( k <= 0 ) throw new ArgumentOutOfRangeException( "k" );
    if( n < k ) throw new ArgumentOutOfRangeException( "n or k" );

    int i;

    // Initial values
    int[] a = new int[k];
    for( i=0; i<k; i++ )
        a[ i ] = i;

    for( ;; ) {

        // Yield the combo
        int[] r = new int[k];
        Array.Copy( a, r, k );
        yield return r;

        // Search right-to-left
        for( i=k-1; i>=0; i-- ) {

            // ...for the the next position that can be incremented
            if( a[i] < (n - 1 - (k-i-1)) ) {

                // Increment it and reset the subsequent positions
                for( int j=a[i]+1; i<k; i++, j++ )
                    a[i] = j;

                // Yield and proceed to the next combo
                break;

            // ...and if we're out of positions to increment, we're done
            } else if( i == 0 ) {
                yield break;
            }

        }
    }
}


/*
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
*/




} // class
} // namespace

