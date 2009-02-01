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


using System.Collections;
using System.Collections.Generic;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// An <tt>IEnumerable< T ></tt> that always returns a given
/// <tt>IEnumerator< T ></tt>
// =============================================================================
//
public class
EnumeratorToEnumerableAdapter<
    T
>
    : IEnumerable< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
EnumeratorToEnumerableAdapter(
    IEnumerator< T > enumerator
)
{
    NonNull.Check( enumerator, new Parameter( "enumerator" ) );
    this.enumerator = enumerator;
}



// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private
IEnumerator< T >
enumerator;



// -----------------------------------------------------------------------------
// IEnumerable< T >
// -----------------------------------------------------------------------------

public
IEnumerator< T >
GetEnumerator()
{
    return this.enumerator;
}



// -----------------------------------------------------------------------------
// IEnumerable
// -----------------------------------------------------------------------------

IEnumerator
IEnumerable.GetEnumerator()
{
    return this.enumerator;
}




//private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace
