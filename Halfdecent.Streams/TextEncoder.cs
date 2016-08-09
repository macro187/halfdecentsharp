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
/// A filter that encodes characters into bytes according to a specified
/// text encoding
// =============================================================================

public class
TextEncoder
    : Filter< char, byte >
{



public
TextEncoder(
    Encoding encoding
)
    : base(
        (getState,get,put) => StepIterator( encoding, getState, get, put ),
        null,
        () => {;} )
{
    NonNull.CheckParameter( encoding, "encoding" );
}



// -----------------------------------------------------------------------------
// private
// -----------------------------------------------------------------------------

private static
    IEnumerator< FilterState >
StepIterator(
    Encoding            encoding,
    Func< FilterState > getState,
    Func< char >        get,
    Action< byte >      put
)
{
    Encoder e = encoding.GetEncoder();
    char[] c = new char[ 1 ];
    int bsize = 1;
    byte[] b = new byte[ bsize ];
    for( ;; ) {

        // Get the next character
        yield return FilterState.Want;
        if( getState() == FilterState.Closed ) break;
        c[0] = get();

        // See how many bytes we'll get and grow the output array if necessary
        int newsize = e.GetByteCount( c, 0, 1, false );
        if( newsize > bsize ) {
            bsize = newsize;
            b = new byte[ bsize ];
        }

        // Feed the new char to the encoder
        int bcount = e.GetBytes( c, 0, 1, b, 0, false );

        // Yield any encoded byte(s)
        for( int i = 0; i < bcount; i++ ) {
            put( b[i] );
            yield return FilterState.Have;
        }
    }
}




} // type
} // namespace

