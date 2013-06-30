// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2011, 2012
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
using System.Linq;
using SCG = System.Collections.Generic;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Streams;


namespace
Com.Halfdecent.Collections
{


// =============================================================================
/// TODO
// =============================================================================

public partial interface
IOrderedCollectionR<
#if DOTNET40
    out T
#else
    T
#endif
>
    : IOrderedCollection
    , IUniqueKeyedCollectionR< long, T >
{



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionR.Statics
// -----------------------------------------------------------------------------

/// Determine the index of the first item in the collection that matches
/// specified criteria
///
public static
    long
    /// @returns Index of the matching item
    /// - OR -
    /// -1 if no matching item
IndexWhere<
    T
>(
    this IOrderedCollectionR< T >   dis,
    Predicate< T >                  where
)
{
    NonNull.CheckParameter( where, "where" );
    foreach( ITupleHD< long, T > t in dis.StreamPairs().AsEnumerable() ) {
        if( where( t.B ) ) return t.A;
    }
    return -1;
}


public static
    IOrderedCollectionR< T >
Covary<
    TFrom,
    T
>(
    this IOrderedCollectionR< TFrom > from
)
    where TFrom : T
{
    return new OrderedCollectionRProxy< TFrom, T >( from );
}
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionR.Proxy
// -----------------------------------------------------------------------------

public
    IStream< ITupleHD< long, T > >
StreamPairs()
{
    return
        this.From.StreamPairs()
        .AsEnumerable()
        .Select( t => t.Covary< long, TFrom, long, T >() )
        .AsStream();
}

public bool Contains( long key ) { return this.From.Contains( key ); }

public
    IStream< T >
Stream(
    long key
)
{
    return this.From.Stream().Covary< TFrom, T >();
}

public T Get( long key ) { return this.From.Get( key ); }
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionR.Proxy.Invariant
// -----------------------------------------------------------------------------

public
    IStream< ITupleHD< long, T > >
StreamPairs()
{
    return this.From.StreamPairs();
}

public bool Contains( long key ) { return this.From.Contains( key ); }

public
    IStream< T >
Stream(
    long key
)
{
    return this.From.Stream( key );
}

public T Get( long key ) { return this.From.Get( key ); }
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionR< T >.IndexSlice
// -----------------------------------------------------------------------------

public
    T
Get(
    long key
)
{
    NonNull.CheckParameter( key, "key" );
    ExistingKeyIn.CheckParameter( this, key, "key" );
    return this.From.Get( this.Trans( key ) );
}


public
    IStream< ITupleHD< long, T > >
StreamPairs()
{
    return this.StreamPairsIterator().AsStream();
}

private
    SCG.IEnumerable< ITupleHD< long, T > >
StreamPairsIterator()
{
    long to = this.SliceIndex + this.SliceCount;
    for(
        long i = this.SliceIndex;
        i < to;
        i = i + 1
    ) {
        yield return TupleHD.Create( i, this.From.Get( i ) );
    }
}


public
    bool
Contains(
    long key
)
{
    NonNull.CheckParameter( key, "key" );
    return key.GTE( 0 ) && key < this.SliceCount;
}


public IStream< T > Stream( long key ) {
    return KeyedCollection.StreamViaUniqueKeyedCollection( this, key ); }


public IStream< T > Stream() {
    return Collection.StreamViaKeyedCollection( this ); }
#endif




} // type
} // namespace

