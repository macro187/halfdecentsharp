// -----------------------------------------------------------------------------
// Copyright (c) 2009
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


using SCG = System.Collections.Generic;
using System;
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
/// <tt>IKeyedCollection< T ></tt> library
// =============================================================================

public static class
KeyedCollection
{



// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// <tt>IKeyedCollection< TKey, T >.GetAll()</tt>
/// via
/// <tt>IUniqueKeyedCollection< TKey, T ></tt>
///
public static
    IStream< T >
GetAllViaUniqueKeyedCollection<
    TCollection,
    TKey,
    T
>(
    TCollection col,
    TKey        key
)
    where TCollection : IUniqueKeyedCollection< TKey, T >
{
    new NonNull().Require( col, new Parameter( "col" ) );
    return
        GetAllViaUniqueKeyedCollectionIterator<
            TCollection,
            TKey,
            T
        >( col, key )
        .AsStream();
}

private static
    SCG.IEnumerator< T >
GetAllViaUniqueKeyedCollectionIterator<
    TCollection,
    TKey,
    T
>(
    TCollection col,
    TKey        key
)
    where TCollection : IUniqueKeyedCollection< TKey, T >
{
    if( col.Contains( key ) ) yield return col.Get( key );
}


/// <tt>IKeyedCollectionC< TKey, T >.GetAndReplaceAll()</tt>
/// via
/// <tt>IUniqueKeyedCollectionC< TKey, T ></tt>
///
public static
    IFilter< T, T >
GetAndReplaceAllViaUniqueKeyedCollection<
    TCollection,
    TKey,
    T
>(
    TCollection col,
    TKey        key
)
    where TCollection : IUniqueKeyedCollectionC< TKey, T >
{
    new NonNull().Require( col, new Parameter( "col" ) );
    return new Filter< T, T >(
        ( get, put, drop ) =>
            GetAndReplaceAllViaUniqueKeyedCollectionFilter<
                TCollection,
                TKey,
                T
            >(
                col, key, get, put, drop ) );
}

private static
    SCG.IEnumerator< bool >
GetAndReplaceAllViaUniqueKeyedCollectionFilter<
    TCollection,
    TKey,
    T
>(
    TCollection     col,
    TKey            key,
    Func< T >       get,
    Func< T, Void > put,
    Func< T, Void > drop
)
    where TCollection : IUniqueKeyedCollectionC< TKey, T >
{
    if( !col.Contains( key ) ) yield break;
    T item = col.Get( key );
    yield return false;
    col.Replace( key, get() );
    put( item );
    yield return true;
}


/// <tt>IKeyedCollectionS< TKey, T >.GetAndRemoveAll()</tt>
/// via
/// <tt>IUniqueKeyedCollectionS< TKey, T ></tt>
///
public static
    IStream< T >
GetAndRemoveAllViaUniqueKeyedCollection<
    TCollection,
    TKey,
    T
>(
    TCollection col,
    TKey        key
)
    where TCollection : IUniqueKeyedCollectionS< TKey, T >
{
    new NonNull().Require( col, new Parameter( "col" ) );
    return
        GetAndRemoveAllViaUniqueKeyedCollectionIterator<
            TCollection,
            TKey,
            T
        >( col, key )
        .AsStream();
}

private static
    SCG.IEnumerator< T >
GetAndRemoveAllViaUniqueKeyedCollectionIterator<
    TCollection,
    TKey,
    T
>(
    TCollection col,
    TKey        key
)
    where TCollection : IUniqueKeyedCollectionS< TKey, T >
{
    if( col.Contains( key ) ) {
        T item = col.Get( key );
        col.Remove( key );
        yield return item;
    }
}




} // type
} // namespace

