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
/// <tt>IKeyedCollection< TKey, T ></tt> library
// =============================================================================

public static class
KeyedCollection
{



public static
    IStream< T >
GetAllViaUniqueKeyedCollection<
    TKey,
    T
>(
    IUniqueKeyedCollection< TKey, T >   col,
    TKey                                key
)
{
    new NonNull().Require( col, new Parameter( "col" ) );
    return
        col.Contains( key )
            ? new Stream< T >( col.Get( key ) )
            : new Stream< T >();
}


public static
    IFilter< T, T >
GetAndReplaceAllViaUniqueKeyedCollection<
    TKey,
    T
>(
    IUniqueKeyedCollectionC< TKey, T >  col,
    TKey                                key
)
{
    new NonNull().Require( col, new Parameter( "col" ) );
    return new Filter< T, T >(
        ( get, put, drop ) =>
            GetAndReplaceAllViaUniqueKeyedCollectionFilter(
                col, key, get, put, drop ) );
}

private static
    SCG.IEnumerator< bool >
GetAndReplaceAllViaUniqueKeyedCollectionFilter<
    TKey,
    T
>(
    IUniqueKeyedCollectionC< TKey, T >  col,
    TKey                                key,
    Func< T >                           get,
    Action< T >                         put,
    Action< T >                         drop
)
{
    if( !col.Contains( key ) ) yield break;
    yield return false;
    put( col.GetAndReplace( key, get() ) );
    yield return true;
}


public static
    IStream< T >
GetAndRemoveAllViaUniqueKeyedCollection<
    TKey,
    T
>(
    IUniqueKeyedCollectionS< TKey, T >  col,
    TKey                                key
)
{
    new NonNull().Require( col, new Parameter( "col" ) );
    return
        GetAndRemoveAllViaUniqueKeyedCollectionIterator( col, key )
        .AsStream();
}

private static
    SCG.IEnumerator< T >
GetAndRemoveAllViaUniqueKeyedCollectionIterator<
    TKey,
    T
>(
    IUniqueKeyedCollectionS< TKey, T >  col,
    TKey                                key
)
{
    if( !col.Contains( key ) ) yield break;
    yield return col.GetAndRemove( key );
}


// XXX This algorithm assumes that .GetAndReplace() does not interfere with
//     .StreamKeys()
//
public static
    IFilter< ITuple< TKey, T >, ITuple< TKey, T > >
GetAndReplaceAllViaUniqueKeyedCollection<
    TKey,
    T
>(
    IUniqueKeyedCollectionC< TKey, T >  col,
    Func< ITuple< TKey, T >, bool >     where
)
{
    new NonNull().Require( col, new Parameter( "col" ) );
    new NonNull().Require( where, new Parameter( "where" ) );
    return
        new Filter< ITuple< TKey, T >, ITuple< TKey, T > >(
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
    Func< ITuple< TKey, T >, bool >     where,
    Func< ITuple< TKey, T > >           get,
    Action< ITuple< TKey, T > >         put,
    Action< ITuple< TKey, T > >         drop
)
{
    foreach( TKey key in col.StreamKeys().AsEnumerable() ) {
        ITuple< TKey, T > old = new Tuple< TKey, T >( key, col.Get( key ) );
        if( !where( old ) ) continue;
        yield return false;
        // TODO Change to .Replace() when it appears
        col.GetAndReplace( key, get().B );
        put( old );
        yield return true;
    }
}




} // type
} // namespace

