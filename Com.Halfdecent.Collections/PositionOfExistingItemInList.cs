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


using SCG = System.Collections.Generic;
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Numerics;


namespace
Com.Halfdecent.Collections
{


public class
PositionOfExistingItemInList<
    T
    ///< Type of items in the list
>
    : SimpleRTypeBase< IInteger >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
PositionOfExistingItemInList(
    IList< T > list
)
    : base(
        _S("{0} is the position of an existing item"),
        _S("{0} is not the position of an existing item"),
        _S("{0} must be the position of an existing item")
    )
{
    NonNull.Check( list, new Parameter( "list" ) );
    this.components = new IRType< IInteger >[] {
        new NonNegative().Contravary< IReal, IInteger >(),
        new LT< IInteger >( list.Count )
    };
}



// -----------------------------------------------------------------------------
// RTypeBase< T >
// -----------------------------------------------------------------------------

public override
SCG.IEnumerable< IRType< IInteger > >
Components
{
    get { return this.components; }
}

private
SCG.IEnumerable< IRType< IInteger > >
components;




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // PositionOfExistingItemInList< T >



public static class
PositionOfExistingItemInList
{

public static
void
Check<
    T
>(
    IList< T >  list,
    IInteger    item,
    IValue      itemReference
)
{
    new PositionOfExistingItemInList< T >( list ).Check( item, itemReference );
}

} // PositionOfExistingItemInList




} // namespace

