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
using Com.Halfdecent.Numerics;


namespace
Com.Halfdecent.Collections
{


// =============================================================================
/// Static methods for <tt>ExistingKeyIn<TKey,T></tt>
// =============================================================================

public static class
ExistingKeyIn
{


public static
    void
Require<
    TKey,
    T
>(
    IKeyedCollectionR< TKey, T >    collection,
    TKey                            item,
    Value                           itemReference
)
{
    Create( collection ).Require( item, itemReference );
}


public static
    IRType< TKey >
Create<
    TKey,
    T
>(
    IKeyedCollectionR< TKey, T > collection
)
{
    return new ExistingKeyIn< TKey, T >( collection );
}



} // type



// =============================================================================
/// TODO
// =============================================================================

public sealed class
ExistingKeyIn<
    TKey,
    T
>
    : SimpleTextRTypeBase< TKey >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
ExistingKeyIn(
    IKeyedCollectionR< TKey, T > collection
)
    : base(
        _S( "{0} is the key of an item in the collection" ),
        _S( "{0} is not the key of an item in the collection" ),
        _S( "{0} must be the key of an item in the collection" ) )
{
    NonNull.Require( collection, new Parameter( "collection" ) );
    this.Collection = collection;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
IKeyedCollectionR< TKey, T >
Collection
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// RTypeBase< T >
// -----------------------------------------------------------------------------

public override
    bool
Predicate(
    TKey item
)
{
    return this.Collection.Contains( item );
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
    return
        that.GetType() == this.GetType() &&
        object.ReferenceEquals(
            ((ExistingKeyIn< TKey, T >)that).Collection,
            this.Collection );
}


public override
    int
GetHashCode()
{
    return
        base.GetHashCode() ^
        this.Collection.GetHashCode();
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType ), s, args ); }

} // type
} // namespace

