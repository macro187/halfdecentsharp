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
/// <tt>ICollection< ITuple< TKey, T > ></tt> library
// =============================================================================

public static class
TupleCollection
{



// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// <tt>ICollectionC< ITuple< TKey, T > >.GetAndReplaceAll()</tt>
/// via
/// <tt>IUniqueKeyedCollectionC< TKey, T ></tt>
///
/// Keys of replacement items are ignored.
///
/// Avoids replacing any given key more than once.
///
/// Semantically correct, but not very efficient.  Restarts item iteration when
/// an item is replaced, re-considering unreplaced items each time.
///
public static
    IFilter< ITuple< TKey, T >, ITuple< TKey, T > >
GetAndReplaceAllViaUniqueKeyedCollection<
    TCollection,
    TKey,
    T
>(
    TCollection                     col,
    Func< ITuple< TKey, T >, bool > where
)
    where TCollection : IUniqueKeyedCollectionC< TKey, T >
{
    new NonNull().Require( col, new Parameter( "col" ) );
    new NonNull().Require( where, new Parameter( "where" ) );
    return
        new Filter< ITuple< TKey, T >, ITuple< TKey, T > >(
            ( get, put, drop ) =>
                GetAndReplaceAllViaUniqueKeyedCollectionFilter<
                    TCollection,
                    TKey,
                    T
                >( col, where, get, put, drop ) );
}

private static
    SCG.IEnumerator< bool >
GetAndReplaceAllViaUniqueKeyedCollectionFilter<
    TCollection,
    TKey,
    T
>(
    TCollection                     col,
    Func< ITuple< TKey, T >, bool > where,
    Func< ITuple< TKey, T > >       get,
    Action< ITuple< TKey, T > >     put,
    Action< ITuple< TKey, T > >     drop
)
    where TCollection : IUniqueKeyedCollectionC< TKey, T >
{
    SCG.ICollection< TKey > replacedkeys = new SCG.HashSet< TKey >();
    while( true ) {
        IStream< ITuple< TKey, T > > pairs =
            ((ICollection< ITuple< TKey, T > >)( col )).Stream();
        while( true ) {
            ITuple< TKey, T > t;
            if( !pairs.TryPull( out t ) ) yield break;
            if( replacedkeys.Contains( t.A ) ) continue;
            if( where( t ) ) {
                yield return false;
                ITuple< TKey, T > t2 = get();
                col.Replace( t.A, t2.B );
                replacedkeys.Add( t.A );
                put( t );
                yield return true;
                break;
            }
        }
    }
}


/// <tt>ICollectionC< ITuple< TKey, T > >.GetAndRemoveAll()</tt>
/// via
/// <tt>IUniqueKeyedCollectionS< TKey, T ></tt>
///
/// Semantically correct, but not very efficient.  Restarts item iteration when
/// an item is removed, re-considering unremoved items each time.
///
public static
    IStream< ITuple< TKey, T > >
GetAndRemoveAllViaUniqueKeyedCollection<
    TCollection,
    TKey,
    T
>(
    TCollection                     col,
    Func< ITuple< TKey, T >, bool > where
)
    where TCollection : IUniqueKeyedCollectionS< TKey, T >
{
    new NonNull().Require( col, new Parameter( "col" ) );
    new NonNull().Require( where, new Parameter( "where" ) );
    return
        GetAndRemoveAllViaUniqueKeyedCollectionIterator<
            TCollection,
            TKey,
            T
        >( col, where )
        .AsStream();
}

private static
    SCG.IEnumerator< ITuple< TKey, T > >
GetAndRemoveAllViaUniqueKeyedCollectionIterator<
    TCollection,
    TKey,
    T
>(
    TCollection                     col,
    Func< ITuple< TKey, T >, bool > where
)
    where TCollection : IUniqueKeyedCollectionS< TKey, T >
{
    while( true ) {
        IStream< ITuple< TKey, T > > pairs =
            ((ICollection< ITuple< TKey, T > >)( col )).Stream();
        while( true ) {
            ITuple< TKey, T > t;
            if( !pairs.TryPull( out t ) ) yield break;
            if( where( t ) ) {
                col.Remove( t.A );
                yield return t;
                break;
            }
        }
    }
}




} // type
} // namespace

