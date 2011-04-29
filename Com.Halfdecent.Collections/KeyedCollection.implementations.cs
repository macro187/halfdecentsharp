// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2011
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
using System.Linq;
using Com.Halfdecent;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Numerics;
using Com.Halfdecent.Streams;


namespace
Com.Halfdecent.Collections
{


// =============================================================================
/// <tt>IKeyedCollection</tt> Implementations
// =============================================================================

public static partial class
KeyedCollection
{



// -----------------------------------------------------------------------------
// Implementations
// -----------------------------------------------------------------------------

/// <tt>IKeyedCollectionRC< TKey, T >.GetAndReplaceAll()</tt>
/// in terms of
/// <tt>IUniqueKeyedCollectionRC< TKey, T ></tt>
///
public static
    IFilter< T, T >
GetAndReplaceAllViaUniqueKeyedCollection<
    TKey,
    T
>(
    IUniqueKeyedCollectionRC< TKey, T > col,
    TKey                                key
)
{
    NonNull.CheckParameter( col, "col" );
    return Filter.Create< T, T >(
        ( getState, get, put ) =>
            GetAndReplaceAllViaUniqueKeyedCollectionFilter(
                col, key, getState, get, put ) );
}

private static
    SCG.IEnumerator< bool >
GetAndReplaceAllViaUniqueKeyedCollectionFilter<
    TKey,
    T
>(
    IUniqueKeyedCollectionRC< TKey, T > col,
    TKey                                key,
    System.Func< FilterState >          getState,
    System.Func< T >                    get,
    System.Action< T >                  put
)
{
    if( !col.Contains( key ) ) yield break;
    yield return false;
    put( col.Get( key ) );
    col.Replace( key, get() );
    yield return true;
}


/// <tt>IKeyedCollectionRS< TKey, T >.GetAndRemoveAll()</tt>
/// in terms of
/// <tt>IUniqueKeyedCollectionRS< TKey, T ></tt>
///
public static
    IStream< T >
GetAndRemoveAllViaUniqueKeyedCollection<
    TKey,
    T
>(
    IUniqueKeyedCollectionRS< TKey, T > col,
    TKey                                key
)
{
    NonNull.CheckParameter( col, "col" );
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
    IUniqueKeyedCollectionRS< TKey, T > col,
    TKey                                key
)
{
    if( !col.Contains( key ) ) yield break;
    T item = col.Get( key );
    col.Remove( key );
    yield return item;
}


/// <tt>IKeyedCollectionR< TKey, T >.Stream()</tt>
/// in terms of
/// <tt>IUniqueKeyedCollectionR< TKey, T ></tt>
///
public static
    IStream< T >
StreamViaUniqueKeyedCollection<
    TKey,
    T
>(
    IUniqueKeyedCollectionR< TKey, T >  col,
    TKey                                key
)
{
    NonNull.CheckParameter( col, "col" );
    return
        StreamViaUniqueKeyedCollectionIterator( col, key )
        .AsStream();
}

private static
    SCG.IEnumerator< T >
StreamViaUniqueKeyedCollectionIterator<
    TKey,
    T
>(
    IUniqueKeyedCollectionR< TKey, T >  col,
    TKey                                key
)
{
    if( !col.Contains( key ) ) yield break;
    yield return col.Get( key );
}




} // type
} // namespace

