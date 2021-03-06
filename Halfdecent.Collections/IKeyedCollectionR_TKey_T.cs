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


using System.Linq;
using Halfdecent;
using Halfdecent.RTypes;
using Halfdecent.Streams;


namespace
Halfdecent.Collections
{


// =============================================================================
/// TODO
// =============================================================================

public interface
IKeyedCollectionR<
#if DOTNET40
    TKey,
    out T
#else
    TKey,
    T
#endif
>
    : IKeyedCollection
    , ICollectionR< T >
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Stream all key-value pairs
///
    IStream< ITupleHD< TKey, T > >
StreamPairs();


/// Determine whether the collection contains any items with the specified key
///
    bool
Contains(
    TKey key
);


/// Stream all items with the specified key
///
    IStream< T >
    /// @returns
    /// A stream of all items with the specified <tt>key</tt>
Stream(
    TKey key
    ///< - <tt>NonNull</tt>
);



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IKeyedCollectionR.Statics
// -----------------------------------------------------------------------------

public static
    IStream< TKey >
StreamKeys<
    TKey,
    T
>(
    this IKeyedCollectionR< TKey, T > col
)
{
    NonNull.CheckParameter( col, "col" );
    return
        col.StreamPairs()
        .AsEnumerable()
        .Select( pair => pair.A )
        .AsStream();
}


public static
    IKeyedCollectionR< TKey, T >
Covary<
    TFrom,
    TKey,
    T
>(
    this IKeyedCollectionR< TKey, TFrom > from
)
    where TFrom : T
{
    return new KeyedCollectionRProxy< TFrom, TKey, T >( from );
}
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IKeyedCollectionR.Proxy
// -----------------------------------------------------------------------------

public
    IStream< ITupleHD< TKey, T > >
StreamPairs()
{
    return
        this.From.StreamPairs()
        .AsEnumerable()
        .Select( t => t.Covary< TKey, TFrom, TKey, T >() )
        .AsStream();
}

public bool Contains( TKey key ) { return this.From.Contains( key ); }

public
    IStream< T >
Stream(
    TKey key
)
{
    return this.From.Stream( key ).Covary< TFrom, T >();
}
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IKeyedCollectionR.Proxy.Invariant
// -----------------------------------------------------------------------------

public
    IStream< ITupleHD< TKey, T > >
StreamPairs()
{
    return this.From.StreamPairs();
}

public bool Contains( TKey key ) { return this.From.Contains( key ); }

public
    IStream< T >
Stream(
    TKey key
)
{
    return this.From.Stream( key );
}
#endif




} // type
} // namespace

