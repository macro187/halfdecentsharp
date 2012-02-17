// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010, 2012
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
/// TODO
// =============================================================================

public partial interface
IOrderedCollectionG<
#if DOTNET40
    in T
#else
    T
#endif
>
    : IOrderedCollection
    , IUniqueKeyedCollectionG< IInteger, T >
    , IImplicitUniqueKeyedCollectionG< T >
{



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionG.Statics
// -----------------------------------------------------------------------------

public static
    IOrderedCollectionG< T >
Contravary<
    TFrom,
    T
>(
    this IOrderedCollectionG< TFrom > from
)
    where T : TFrom
{
    return new OrderedCollectionGProxy< TFrom, T >( from );
}
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionG.Proxy
// -----------------------------------------------------------------------------

public void Add( IInteger key, T item ) { this.From.Add( key, item ); }
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionG< T >.IndexSlice
// -----------------------------------------------------------------------------

public
    void
Add(
    IInteger    key,
    T           item
)
{
    NonNull.CheckParameter( key, "key" );
    ExistingOrNextPositionIn.CheckParameter( this, key, "key" );
    this.From.Add( this.Trans( key ), item );
    this.SliceCount = this.SliceCount.Plus( Integer.Create( 1 ) );
}


public void Add( T item ) {
    Collection.AddViaOrderedCollection( this, item ); }
#endif




} // type
} // namespace

