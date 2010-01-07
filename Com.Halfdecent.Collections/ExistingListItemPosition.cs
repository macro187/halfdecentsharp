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
using Com.Halfdecent;
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Numerics;


namespace
Com.Halfdecent.Collections
{


public class
ExistingListItemPosition<
    T
    ///< Type of items in the list
>
    : SimpleTextRTypeBase< IInteger >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
ExistingListItemPosition(
    IList< T > list
)
    : base(
        _S("{0} is the position of an existing item"),
        _S("{0} is not the position of an existing item"),
        _S("{0} must be the position of an existing item")
    )
{
    new NonNull().Check( list, new Parameter( "list" ) );
    this.List = list;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
IList< T >
List
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// RTypeBase< Integer >
// -----------------------------------------------------------------------------

protected override
bool
Equals(
    IRType t
)
{
    return ((ExistingListItemPosition< T >)t).List.Equals( this.List );
}



// -----------------------------------------------------------------------------
// IRType< IInteger >
// -----------------------------------------------------------------------------

public override
SCG.IEnumerable< IRType< IInteger > >
Components
{
    get
    {
        return
            base.Components
            .Append( new NonNegative()
                .Contravary< IReal, IInteger >() )
            .Append( new LT( this.List.Count )
                .Contravary< object, IInteger >() );
    }
}



// -----------------------------------------------------------------------------
// System.Object
// -----------------------------------------------------------------------------

public override
int
GetHashCode()
{
    return base.GetHashCode() ^ this.List.GetHashCode();
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

