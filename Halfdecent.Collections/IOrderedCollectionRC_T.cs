// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2012
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


using System;
using Halfdecent.Streams;


namespace
Halfdecent.Collections
{


// =============================================================================
/// TODO
// =============================================================================

public partial interface
IOrderedCollectionRC<
    T
>
    : IOrderedCollectionR< T >
    , IOrderedCollectionC< T >
    , IUniqueKeyedCollectionRC< long, T >
{



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionRC.Statics
// -----------------------------------------------------------------------------
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionRC.Proxy
// -----------------------------------------------------------------------------

public IFilter< T, T > GetAndReplaceAll( long key ) {
    return this.From.GetAndReplaceAll( key ); }
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionRC< T >.IndexSlice
// -----------------------------------------------------------------------------

public IFilter< T, T > GetAndReplaceAll( long key ) {
    return KeyedCollection
        .GetAndReplaceAllViaUniqueKeyedCollection( this, key ); }


public IFilter< T, T > GetAndReplaceWhere( Predicate< T > where ) {
    return Collection
        .GetAndReplaceWhereViaUniqueKeyedCollection( this, where ); }
#endif




} // type
} // namespace

