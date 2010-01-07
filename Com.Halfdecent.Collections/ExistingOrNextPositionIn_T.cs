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
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Numerics;


namespace
Com.Halfdecent.Collections
{


// =============================================================================
/// TODO
// =============================================================================

public class
ExistingOrNextPositionIn<
    T
>
    : SimpleTextRTypeBase< IInteger >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
ExistingOrNextPositionIn(
    ICollection< T > collection
)
    : base(
        _S( "{0} is an existing or the next position in the collection" ),
        _S( "{0} is not an existing or the next position in the collection" ),
        _S( "{0} must be an existing or the next position in the collection" ) )
{
    new NonNull().Require( collection, new Parameter( "collection" ) );
    this.Collection = collection;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
ICollection< T >
Collection
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// RTypeBase< T >
// -----------------------------------------------------------------------------

public override
    SCG.IEnumerable< IRType< IInteger > >
GetComponents()
{
    return
        base.GetComponents()
        .Append( new GTE< IInteger >(
            Integer.From( 0 ),
            new ComparableComparer< IReal >()
                .Contravary< IReal, IInteger >() ) )
        .Append( new LTE< IInteger >(
            this.Collection.Count,
            new ComparableComparer< IReal >()
                .Contravary< IReal, IInteger >() ) );
}



// -----------------------------------------------------------------------------
// IEquatable< IRType >
// -----------------------------------------------------------------------------

public override
    bool
DirectionalEquals(
    IRType that
)
{
    // XXX
    return false;
}


public override
    int
GetHashCode()
{
    // XXX
    return
        base.GetHashCode() ^
        this.Collection.GetHashCode();
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

