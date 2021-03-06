// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2011, 2012
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
using System.Collections.Generic;
using System.Text;
using Halfdecent.Meta;
using Halfdecent.RTypes;


namespace
Halfdecent.Streams
{


// =============================================================================
/// A filter that splits a stream of characters into lines
///
/// Splits at <tt>LF</tt>, <tt>CR+LF</tt>, or <tt>CR</tt>.
// =============================================================================

public class
TextLineSplitter
    : Filter< char, string >
{



// -----------------------------------------------------------------------------
// Constructor
// -----------------------------------------------------------------------------

public
TextLineSplitter()
    : base( StepIterator, null, () => {;} )
{
}



// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private static
    IEnumerator< FilterState >
StepIterator(
    Func< FilterState > getState,
    Func< char >        get,
    Action< string >    put
)
{
    StringBuilder sb = new StringBuilder();
    bool r = false;
    for( ;; ) {

        // Get the next character
        yield return FilterState.Want;
        if( getState() == FilterState.Closed ) break;
        char c = get();

        // If it's an \n right after an \r, ignore it completely
        if( r && c == '\n' ) { r = false; continue; }

        // Remember whether it's an \r in case the next character is an \n
        r = ( c == '\r' );

        // If it's an \r or \n the line's done, so yield it
        if( c == '\r' || c == '\n' ) {
            put( sb.ToString() );
            yield return FilterState.Have;
            // XXX Does this shrink .Capacity?  If so, it guarantees new
            // allocation(s) each line, killing the advantage of using a
            // StringBuilder in the first place, so find another way to
            // do things.  (eg. List< char >)
            sb.Length = 0;
            continue;
        }

        // Otherwise append the character to the current line
        sb.Append( c );
    }

    // Closing, yield any remaining characters as the last line
    if( sb.Length > 0 ) {
        put( sb.ToString() );
        yield return FilterState.Have;
    }
}




} // type
} // namespace

