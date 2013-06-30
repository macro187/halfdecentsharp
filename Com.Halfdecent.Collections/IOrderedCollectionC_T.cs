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


namespace
Com.Halfdecent.Collections
{


// =============================================================================
/// TODO
// =============================================================================

public partial interface
IOrderedCollectionC<
#if DOTNET40
    in T
#else
    T
#endif
>
    : IOrderedCollection
    , IUniqueKeyedCollectionC< long, T >
{



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionC.Statics
// -----------------------------------------------------------------------------

public static
    IOrderedCollectionC< T >
Contravary<
    TFrom,
    T
>(
    this IOrderedCollectionC< TFrom > from
)
    where T : TFrom
{
    return new OrderedCollectionCProxy< TFrom, T >( from );
}
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionC.Proxy
// -----------------------------------------------------------------------------

public void Replace( long key, T replacement ) {
    this.From.Replace( key, replacement ); }
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionC< T >.IndexSlice
// -----------------------------------------------------------------------------

public
    void
Replace(
    long    key,
    T       replacement
)
{
    NonNull.CheckParameter( key, "key" );
    GTE.CheckParameter( 0, key, "key" );
    LTE.CheckParameter( this.Count, key, "key" );
    this.From.Replace( this.Trans( key ), replacement );
}
#endif




} // type
} // namespace

