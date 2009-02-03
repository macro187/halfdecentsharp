// -----------------------------------------------------------------------------
// Copyright (c) 2009
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


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// Presents an <tt>IStream< T ></tt> as an <tt>IEnumerator< T ></tt> via
/// <tt>Stream.Expect()</tt>
///
/// This adapter is useful when a finite number of items will be pulled from
/// the enumerator, all of which are expected to exist.  An
/// <tt>EndOfStreamException</tt> will result (via <tt>Stream.Expect()</tt>) if
/// the end of the stream is reached.
// =============================================================================
//
public class
StreamToExpectantEnumeratorAdapter<
    T
>
    : StreamToEnumeratorAdapter< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
StreamToExpectantEnumeratorAdapter(
    IStream< T > stream
)
    :base( stream )
{
}



// -----------------------------------------------------------------------------
// EnumeratorBase< T >
// -----------------------------------------------------------------------------

protected override
bool
MoveNext(
    out T nextItem
)
{
    nextItem = this.Stream.Expect();
    return true;
}




//private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

