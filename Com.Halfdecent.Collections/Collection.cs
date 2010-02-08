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
/// <tt>ICollection< T ></tt> library
// =============================================================================

public static class
Collection
{



public static
    IStream< T >
StreamViaTupleCollection<
    TKey,
    T
>(
    ICollection< ITuple< TKey, T > > col
)
{
    new NonNull().Require( col, new Parameter( "col" ) );
    return
        col.Stream()
        .AsEnumerable()
        .Select( t => t.B )
        .AsStream();
}


public static
    IStream< T >
GetAndRemoveAllViaTupleCollection<
    TKey,
    T
>(
    ICollectionS< ITuple< TKey, T > >    col,
    Func< T, bool >                     where
)
{
    new NonNull().Require( col, new Parameter( "col" ) );
    new NonNull().Require( where, new Parameter( "where" ) );
    return
        col.GetAndRemoveAll( t => where( t.B ) )
        .AsEnumerable()
        .Select( t => t.B )
        .AsStream();
}


public static
    IFilter< T, T >
GetAndReplaceAllViaUniqueKeyedCollection<
    TKey,
    T
>(
    IUniqueKeyedCollectionC< TKey, T >  col,
    Func< T, bool >                     where
)
{
    new NonNull().Require( col, new Parameter( "col" ) );
    new NonNull().Require( where, new Parameter( "where" ) );
    return
        new Filter< T, T >(
            ( get, put, drop ) =>
                GetAndReplaceAllViaUniqueKeyedCollectionFilter(
                    col, where, get, put, drop ) );
}

private static
    SCG.IEnumerator< bool >
GetAndReplaceAllViaUniqueKeyedCollectionFilter<
    TKey,
    T
>(
    IUniqueKeyedCollectionC< TKey, T >  col,
    Func< T, bool >                     where,
    Func< T >                           get,
    Action< T >                         put,
    Action< T >                         drop
)
{
    // XXX
    // This algorithm assumes that .GetAndReplace() does not interfere with
    // .StreamKeys().  If this becomes an issue, just retrieve all keys at once
    // first.
    //
    foreach( TKey key in col.StreamKeys().AsEnumerable() ) {
        T old = col.Get( key );
        if( !where( old ) ) continue;
        yield return false;
        // TODO Change to .Replace() when it appears
        col.GetAndReplace( key, get() );
        put( old );
        yield return true;
    }
}


public static
    IFilter< T, T >
GetAndReplaceAllViaUniqueKeyedCollection<
    TCollection,
    TKey,
    T
>(
    TCollection     col,
    Func< T, bool > where
)
    where TCollection
        : IUniqueKeyedCollectionS< TKey, T >
        , ICollectionG< T >
{
    new NonNull().Require( col, new Parameter( "col" ) );
    new NonNull().Require( where, new Parameter( "where" ) );
    return
        new Filter< T, T >(
            ( get, put, drop ) =>
                GetAndReplaceAllViaUniqueKeyedCollectionFilter<
                    TCollection, TKey, T >(
                    col, where, get, put, drop ) );
}

private static
    SCG.IEnumerator< bool >
GetAndReplaceAllViaUniqueKeyedCollectionFilter<
    TCollection,
    TKey,
    T
>(
    TCollection     col,
    Func< T, bool > where,
    Func< T >       get,
    Action< T >     put,
    Action< T >     drop
)
    where TCollection
        : IUniqueKeyedCollectionS< TKey, T >
        , ICollectionG< T >
{
    // XXX
    // This algorithm assumes that .GetAndReplace() does not interfere with
    // .StreamKeys().  If this becomes an issue, just retrieve all keys at once
    // first.
    //
    foreach( TKey key in col.StreamKeys().AsEnumerable() ) {
        T old = col.Get( key );
        if( !where( old ) ) continue;
        yield return false;
        // TODO change to .Remove() when it appears
        col.GetAndRemove( key );
        col.Add( get() );
        put( old );
        yield return true;
    }
}




} // type
} // namespace

