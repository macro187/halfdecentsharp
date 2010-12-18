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


using System.Linq;
using SCG = System.Collections.Generic;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Numerics;
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
    , IUniqueKeyedCollectionR< IInteger, T >
{



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionR.Statics
// -----------------------------------------------------------------------------

/// Determine the index of the first item in the collection that matches
/// specified criteria
///
public static
    IInteger
    /// @returns Index of the matching item
    /// - OR -
    /// -1 if no matching item
IndexWhere<
    T
>(
    this IOrderedCollectionR< T >   dis,
    System.Predicate< T >           where
)
{
    NonNull.CheckParameter( where, "where" );
    foreach( ITuple< IInteger, T > t in dis.StreamPairs().AsEnumerable() ) {
        if( where( t.B ) ) return t.A;
    }
    return Integer.From( -1 );
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
    IStream< ITuple< IInteger, T > >
StreamPairs()
{
#if DOTNET40
    return this.From.StreamPairs();
#else
    return
        this.From.StreamPairs()
        .AsEnumerable()
        .Select( t => t.Covary< IInteger, TFrom, IInteger, T >() )
        .AsStream();
#endif
}

public bool Contains( IInteger key ) { return this.From.Contains( key ); }

public
    IStream< T >
Stream(
    IInteger key
)
{
#if DOTNET40
    return this.From.Stream( key );
#else
    return this.From.Stream().Covary< TFrom, T >();
#endif
}

public T Get( IInteger key ) { return this.From.Get( key ); }
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionR.Proxy.Invariant
// -----------------------------------------------------------------------------

public
    IStream< ITuple< IInteger, T > >
StreamPairs()
{
    return this.From.StreamPairs();
}

public bool Contains( IInteger key ) { return this.From.Contains( key ); }

public
    IStream< T >
Stream(
    IInteger key
)
{
    return this.From.Stream( key );
}

public T Get( IInteger key ) { return this.From.Get( key ); }
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionR< T >.IndexSlice
// -----------------------------------------------------------------------------

public
    T
Get(
    IInteger key
)
{
    NonNull.CheckParameter( key, "key" );
    ExistingKeyIn.CheckParameter( this, key, "key" );
    return this.From.Get( this.Trans( key ) );
}


public
    IStream< ITuple< IInteger, T > >
StreamPairs()
{
    return this.StreamPairsIterator().AsStream();
}

private
    SCG.IEnumerable< ITuple< IInteger, T > >
StreamPairsIterator()
{
    IInteger to = this.SliceIndex.Plus( this.SliceCount );
    IInteger one = Integer.From( 1 );
    for(
        IInteger i = this.SliceIndex;
        i.LT( to );
        i = i.Plus( one )
    ) {
        yield return new Tuple< IInteger, T >(
            i,
            this.From.Get( i ) );
    }
}


public
    bool
Contains(
    IInteger key
)
{
    NonNull.CheckParameter( key, "key" );
    return key.GTE< IReal >( Integer.From( 0 ) ) && key.LT( this.SliceCount );
}


public IStream< T > Stream( IInteger key ) {
    return KeyedCollection.StreamViaUniqueKeyedCollection( this, key ); }


public IStream< T > Stream() {
    return Collection.StreamViaKeyedCollection( this ); }
#endif




} // type
} // namespace

