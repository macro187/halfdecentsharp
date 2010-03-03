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
/// <tt>ICollection< ITuple< TKey, T > ></tt> library
// =============================================================================

public static class
TupleCollection
{



public static
    IStream< ITuple< TKey, T > >
StreamViaKeyedCollection<
    TKey,
    T
>(
    IKeyedCollection< TKey, T > col
)
{
    new NonNull().Require( col, new Parameter( "col" ) );
    return
        col.StreamKeys()
        .AsEnumerable()
        .Aggregate(
            new Stream< ITuple< TKey, T > >().AsEnumerable(),
            ( s, key ) =>
                s.Concat(
                    col.GetAll( key )
                    .AsEnumerable()
                    .Select(
                        item => ((ITuple< TKey, T >)
                            new Tuple< TKey, T >( key, item ) ) ) ) )
        .AsStream();
}


public static
    void
AddViaKeyedCollection<
    TKey,
    T
>(
    IKeyedCollectionG< TKey, T >    col,
    ITuple< TKey, T >               item
)
{
    new NonNull().Require( col, new Parameter( "col" ) );
    new NonNull().Require( item, new Parameter( "item" ) );
    col.Add( item.A, item.B );
}


public static
    IStream< ITuple< TKey, T > >
GetAndRemoveAllViaUniqueKeyedCollection<
    TKey,
    T
>(
    IUniqueKeyedCollectionS< TKey, T >  col,
    Predicate< ITuple< TKey, T > >      where
)
{
    new NonNull().Require( col, new Parameter( "col" ) );
    new NonNull().Require( where, new Parameter( "where" ) );
    return
        GetAndRemoveAllViaUniqueKeyedCollectionIterator( col, where )
        .AsStream();
}

private static
    SCG.IEnumerator< ITuple< TKey, T > >
GetAndRemoveAllViaUniqueKeyedCollectionIterator<
    TKey,
    T
>(
    IUniqueKeyedCollectionS< TKey, T >  col,
    Predicate< ITuple< TKey, T > >      where
)
{
    startover:
    foreach( TKey key in col.StreamKeys().AsEnumerable() ) {
        ITuple< TKey, T > old = new Tuple< TKey, T >( key, col.Get( key ) );
        if( !where( old ) ) continue;
        // TODO Use .Remove() when it appears
        col.GetAndRemove( key );
        yield return old;
        goto startover;
    }
}




} // type
} // namespace

