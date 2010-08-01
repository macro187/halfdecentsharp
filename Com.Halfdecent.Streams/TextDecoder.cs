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
/// A filter that decodes bytes into characters according to a specified
/// text encoding
// =============================================================================

public class
TextDecoder
    : FilterBase< byte, char >
{



public
TextDecoder(
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
    System.Text.Decoder d = this.Encoding.GetDecoder();
    byte[] b = new byte[ 1 ];
    int csize = 1;
    char[] c = new char[ csize ];
    for( ;; ) {

        // Get the next byte
        yield return false;
        b[0] = this.GetItem();

        // See how many chars we'll get and grow the output array if necessary
        int newsize = d.GetCharCount( b, 0, 1, false );
        if( newsize > csize ) {
            csize = newsize;
            c = new char[ csize ];
        }

        // Feed the new byte to the decoder
        int ccount = d.GetChars( b, 0, 1, c, 0, false );

        // Yield any decoded character(s)
        for( int i = 0; i < ccount; i++ ) {
            this.PutItem( c[i] );
            yield return true;
        }

    }
}




//private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

