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
CheckParameter<
    TKey,
    T
>(
    IKeyedCollectionR< TKey, T >    collection,
    TKey                            item,
    string                          paramName
)
{
    ValueReferenceException.Map(
        f => f.Up().Parameter( paramName ),
        f => f.Down().Parameter( "item" ),
        () => Check( collection, item ) );
}


public static
    void
Check<
    TKey,
    T
>(
    IKeyedCollectionR< TKey, T >    collection,
    TKey                            item
)
{
    ValueReferenceException.Map(
        f => f.Parameter( "item" ),
        f => f.Down().Parameter( "item" ),
        () => Create( collection ).Check( item ) );
}


public static
    RType< TKey >
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
    : RType< TKey >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
ExistingKeyIn(
    IKeyedCollectionR< TKey, T > collection
)
    : base(
        item => collection.Contains( item ),
        r => _S( "{0} is the key of an item in the collection", r ),
        r => _S( "{0} is not the key of an item in the collection", r ),
        r => _S( "{0} must be the key of an item in the collection", r ) )
{
    NonNull.CheckParameter( collection, "collection" );
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
// IEquatable< RType >
// -----------------------------------------------------------------------------

public override
    bool
DirectionalEquals(
    RType that
)
{
    return
        base.DirectionalEquals( that )
        && that.Is<
            // XXX Won't work if 'that' has been varied through an adapter
            ExistingKeyIn< TKey, T > >(
            rt => ((object)(rt.Collection)) == this.Collection );
}


public override
    int
GetHashCode()
{
    return
        base.GetHashCode() ^
        this.Collection.GetHashCode();
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

