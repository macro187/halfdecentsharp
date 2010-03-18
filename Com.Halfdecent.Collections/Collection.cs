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


using System;
using SCG = System.Collections.Generic;
using System.Linq;
using Com.Halfdecent;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Numerics;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Filters;


namespace
Com.Halfdecent.Collections
{


// =============================================================================
/// <tt>ICollection</tt> library
// =============================================================================

public static class
Collection
{



// -----------------------------------------------------------------------------
// Implementations
// -----------------------------------------------------------------------------

/// <tt>ICollectionRC< T >.GetAndReplaceWhere()</tt>
/// in terms of
/// <tt>IUniqueKeyedCollection</tt>
///
public static
    IFilter< T, T >
GetAndReplaceWhereViaUniqueKeyedCollection<
    TKey,
    T
>(
    IUniqueKeyedCollectionRC< TKey, T > col,
    Predicate< T >                      where
)
{
    new NonNull().Require( col, new Parameter( "col" ) );
    new NonNull().Require( where, new Parameter( "where" ) );
    return
        new Filter< T, T >(
            ( get, put, drop ) =>
                GetAndReplaceWhereViaUniqueKeyedCollectionFilter(
                    col, where, get, put, drop ) );
}

private static
    SCG.IEnumerator< bool >
GetAndReplaceWhereViaUniqueKeyedCollectionFilter<
    TKey,
    T
>(
    IUniqueKeyedCollectionRC< TKey, T > col,
    Predicate< T >                      where,
    Func< T >                           get,
    Action< T >                         put,
    Action< T >                         drop
)
{
    // XXX
    // This algorithm assumes that .Replace() doesn't interfere with
    // .StreamKeys().  If this becomes an issue, just retrieve all keys at once
    // first.
    //
    foreach( TKey key in col.StreamKeys().AsEnumerable() ) {
        T old = col.Get( key );
        if( !where( old ) ) continue;
        yield return false;
        col.Replace( key, get() );
        put( old );
        yield return true;
    }
}


/// <tt>ICollectionRS< T >.GetAndRemoveWhere()</tt>
/// in terms of
/// <tt>IUniqueKeyedCollection</tt>
///
public static
    IStream< T >
GetAndRemoveWhereViaUniqueKeyedCollection<
    TKey,
    T
>(
    IUniqueKeyedCollectionRS< TKey, T > col,
    Predicate< T >                      where
)
{
    new NonNull().Require( col, new Parameter( "col" ) );
    new NonNull().Require( where, new Parameter( "where" ) );
    return
        GetAndRemoveWhereViaUniqueKeyedCollectionIterator( col, where )
        .AsStream();
}

private static
    SCG.IEnumerator< T >
GetAndRemoveWhereViaUniqueKeyedCollectionIterator<
    TKey,
    T
>(
    IUniqueKeyedCollectionRS< TKey, T > col,
    Predicate< T >                      where
)
{
    restart:
    while( true ) {
        foreach( TKey key in col.StreamKeys().AsEnumerable() ) {
            T item = col.Get( key );
            if( !where( item ) ) continue;
            col.Remove( key );
            yield return item;
            // Restart because keys may have changed
            goto restart;
        }
        yield break;
    }
}


/// <tt>ICollectionR< T >.Stream()</tt>
/// in terms of
/// <tt>IKeyedCollection</tt>
///
public static
    IStream< T >
StreamViaKeyedCollection<
    TKey,
    T
>(
    IKeyedCollectionR< TKey, T > col
)
{
    new NonNull().Require( col, new Parameter( "col" ) );
    return
        col.StreamPairs()
        .AsEnumerable()
        .Select( pair => pair.B )
        .AsStream();
}




} // type
} // namespace

