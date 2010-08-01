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


using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// A filter that encodes characters into bytes according to a specified
/// text encoding
// =============================================================================

public class
TextEncoder
    : FilterBase< char, byte >
{



public
TextEncoder(
    System.Text.Encoding encoding
)
{
    new NonNull().Check( encoding, new Parameter( "encoding" ) );
    this.Encoding = encoding;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

protected
    System.Text.Encoding
Encoding
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// FilterBase
// -----------------------------------------------------------------------------

protected override
    System.Collections.Generic.IEnumerator< bool >
Process()
{
    System.Text.Encoder e = this.Encoding.GetEncoder();
    char[] c = new char[ 1 ];
    int bsize = 1;
    byte[] b = new byte[ bsize ];
    for( ;; ) {

        // Get the next character
        yield return false;
        c[0] = this.GetItem();

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
            this.PutItem( b[i] );
            yield return true;
        }

    }
}




//private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

