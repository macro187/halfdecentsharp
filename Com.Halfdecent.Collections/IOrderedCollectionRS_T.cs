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


using Com.Halfdecent.Numerics;
using Com.Halfdecent.Streams;


namespace
Com.Halfdecent.Collections
{


// =============================================================================
/// TODO
// =============================================================================

public partial interface
IOrderedCollectionRS<
    T
>
    : IOrderedCollectionR< T >
    , IOrderedCollectionS
    , IUniqueKeyedCollectionRS< IInteger, T >
{



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionRS.Statics
// -----------------------------------------------------------------------------
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionRS.Proxy
// -----------------------------------------------------------------------------

public IStream< T > GetAndRemoveAll( IInteger key ) {
    return this.From.GetAndRemoveAll( key ); }
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionRS< T >.IndexSlice
// -----------------------------------------------------------------------------

public IStream< T > GetAndRemoveAll( IInteger key ) {
    return KeyedCollection
        .GetAndRemoveAllViaUniqueKeyedCollection( this, key ); }


public IStream< T > GetAndRemoveWhere( System.Predicate< T > where ) {
    return Collection
        .GetAndRemoveWhereViaUniqueKeyedCollection( this, where ); }
#endif




} // type
} // namespace

