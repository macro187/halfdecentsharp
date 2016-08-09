// -----------------------------------------------------------------------------
// Copyright (c) 2007, 2008, 2009, 2010
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
using System.Resources;
using System.IO;



namespace
Halfdecent.Resbian
{



/// <summary>
/// Resource file type plugin base class
/// </summary>
public abstract class
FilePlugin
{



/// <summary>
/// Examine a given filename and, if recognized, add its contents to a
/// given <c>ResourceWriter</c> as an object of an appropriate type
/// </summary>
/// <remarks>
/// Plugins can assume that the given file exists
/// </remarks>
/// <returns>
/// <c>true</c> if the file was recognized and processed, <c>false</c> if not
/// </returns>
public abstract bool
Process(
    string filename,
    ResourceWriter writer
);



/// <summary>
/// Write a message related to processing
/// </summary>
protected void
WriteLine(
    string message
)
{
    WriteLine( message, 0 );
}

protected void
WriteLine(
    string message,
    int indent
)
{
    if( message == null ) message = "";
    Resbian.WriteLine( message, indent+1 );
}



/// <summary>
/// Extract the local part of a resource file name
/// </summary>
/// <remarks>
/// The "local" part is everything after "&lt;type&gt;__", which is usually
/// the part that a <c>FilePlugin</c> is concerned with.
/// </remarks>
/// <returns>
/// The "local" part of the filename or, if there is no type prefix, the
/// whole filename.  Neither case includes leading directory paths.
/// </returns>
protected string
GetLocalFilename(
    string filename
)
{
    string result;
    string filenameonly = Path.GetFileName( filename );
    int pos = filenameonly.IndexOf( "__" );
    if( pos >= 0 ) {
        result = filenameonly.Substring( pos + 2 );
    } else {
        result = filenameonly;
    }
    return result;
}


/// <summary>
/// <c>System.IO.File.ReadAllBytes()</c> for .NET &lt; 2.0
/// </summary>
protected static
    byte[]
ReadAllBytes(
    string path
)
{
    byte[] r;
    using( FileStream s = File.OpenRead( path ) ) {
        long len = s.Length;
        r = new byte[ len ];
        for( long i = 0; i < len; i++ )
            r[ i ] = ((byte)s.ReadByte());
    }
    return r;
}


/// <summary>
/// <c>System.IO.File.ReadAllLines()</c> for .NET &lt; 2.0
/// </summary>
protected static
    string[]
ReadAllLines(
    string path
)
{
    string[] r = new string[ 0 ];
    using( StreamReader rdr = File.OpenText( path ) ) {
        for( ;; ) {
            string s = rdr.ReadLine();
            if( s == null ) break;
            string[] old = r;
            r = new string[ old.Length + 1 ];
            Array.Copy( old, r, old.Length );
            r[ r.Length - 1 ] = s;
        }
    }
    return r;
}


/// <summary>
/// <c>System.IO.File.ReadAllText()</c> for .NET &lt; 2.0
/// </summary>
protected static
    string
ReadAllText(
    string path
)
{
    string r = "";
    using( StreamReader rdr = File.OpenText( path ) ) {
        for( ;; ) {
            string s = rdr.ReadLine();
            if( s == null ) break;
            if( r != "" ) r += Environment.NewLine;
            r += s;
        }
    }
    return r;
}




} // class
} // namespace

