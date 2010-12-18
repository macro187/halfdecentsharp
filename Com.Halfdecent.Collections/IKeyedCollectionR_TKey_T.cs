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
using Com.Halfdecent;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Streams;


namespace
Com.Halfdecent.Collections
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
    IStream< ITuple< TKey, T > >
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
    IStream< ITuple< TKey, T > >
StreamPairs()
{
//
// NET 4.0 covariance (apparently) isn't smart enough to do this
// - Mono dmcs v2.6.7.0
// - TODO Try MS or a newer Mono
//
//#if DOTNET40
//    return this.From.StreamPairs();
//#else
    return
        this.From.StreamPairs()
        .AsEnumerable()
        .Select( t => t.Covary< TKey, TFrom, TKey, T >() )
        .AsStream();
//#endif
}

public bool Contains( TKey key ) { return this.From.Contains( key ); }

public
    IStream< T >
Stream(
    TKey key
)
{
#if DOTNET40
    return this.From.Stream( key );
#else
    return this.From.Stream( key ).Covary< TFrom, T >();
#endif
}
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IKeyedCollectionR.Proxy.Invariant
// -----------------------------------------------------------------------------

public
    IStream< ITuple< TKey, T > >
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

