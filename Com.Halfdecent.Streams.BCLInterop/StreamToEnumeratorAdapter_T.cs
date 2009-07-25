// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009
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


using Com.Halfdecent.Exceptions;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Streams;


namespace
Com.Halfdecent.Streams.BCLInterop
{


// =============================================================================
/// Presents an <tt>IStream< T ></tt> as an <tt>IEnumerator< T ></tt>
// =============================================================================
//
public class
StreamToEnumeratorAdapter<
    T
>
    : EnumeratorBase< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
StreamToEnumeratorAdapter(
    IStream< T > stream
)
{
    NonNull.Check( stream, new Parameter( "stream" ) );
    this.stream = stream;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
IStream< T >
Stream
{
    get { return this.stream; }
}

private
IStream< T >
stream;



// -----------------------------------------------------------------------------
// EnumeratorBase< T >
// -----------------------------------------------------------------------------

protected override
bool
MoveNext(
    out T nextItem
)
{
    return this.stream.TryPull( out nextItem );
}




//private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

