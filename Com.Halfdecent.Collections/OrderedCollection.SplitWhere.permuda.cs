#region PERMUDA
// combos R RC RS RG RCS RCG RSG RCSG
// filename OrderedCollection/*PERMUDA*/.SplitWhere.cs
#endregion
// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2012
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
using Com.Halfdecent;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Numerics;


namespace
Com.Halfdecent.Collections
{


public static partial class
OrderedCollection/*PERMUDA*/
{



// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

/// Split the collection into by-reference slices at elements matching
/// specified criteria, with those elements omitted
///
/// If no separator elements are found, a slice consisting of the entire
/// collection is returned.
///
/// The slices are produced using <tt>.Slice()</tt>.
///
public static
    IStream< IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ >
SplitWhere<
    T
>(
    this IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ dis,
    Predicate< T > where
)
{
    NonNull.CheckParameter( dis, "dis" );
    NonNull.CheckParameter( where, "where" );
    return
        SplitWhereIterator< T >( dis, where, false, Integer.Create( -1 ) )
        .AsStream();
}


/// Split the collection into two by-reference slices at the first element
/// matching specified criteria, with that element omitted
///
/// If a separator element was not found or was the last item in the
/// collection, the second slice will be a zero-length slice at the end of the
/// collection.
///
/// The slices are produced using <tt>.Slice()</tt>.
///
public static
    ITupleHD<
        IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/,
        IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ >
SplitAtFirstWhere<
    T
>(
    this IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ dis,
    Predicate< T > where
)
{
    NonNull.CheckParameter( dis, "dis" );
    NonNull.CheckParameter( where, "where" );

    IStream< IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ > slices =
        SplitWhereIterator< T >( dis, where, false, Integer.Create( 2 ) )
        .AsStream();

    IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ s1;
    IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ s2;
    s1 = slices.Pull();
    if( !slices.TryPull( out s2 ) )
        s2 = dis.Slice( dis.Count, Integer.Create( 0 ) );

    return TupleHD.Create( s1, s2 );
}


/// Split the collection into by-reference slices at elements matching
/// specified criteria, with those elements included
///
/// If no separator elements are found, a slice consisting of the entire
/// collection is returned.
///
/// The slices are produced using <tt>.Slice()</tt>.
///
public static
    IStream< IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ >
SplitBeforeWhere<
    T
>(
    this IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ dis,
    Predicate< T > where
)
{
    NonNull.CheckParameter( dis, "dis" );
    NonNull.CheckParameter( where, "where" );
    return
        SplitWhereIterator< T >( dis, where, true, Integer.Create( -1 ) )
        .AsStream();
}


/// Split the collection into two by-reference slices before the first element
/// matching specified criteria, with that element included in the second slice
///
/// If a separator element was not found, the second slice will be a
/// zero-length slice at the end of the collection.
///
/// The slices are produced using <tt>.Slice()</tt>.
///
public static
    ITupleHD<
        IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/,
        IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ >
SplitBeforeFirstWhere<
    T
>(
    this IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ dis,
    Predicate< T > where
)
{
    NonNull.CheckParameter( dis, "dis" );
    NonNull.CheckParameter( where, "where" );

    IStream< IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ > slices =
        SplitWhereIterator< T >( dis, where, true, Integer.Create( 2 ) )
        .AsStream();

    IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ s1;
    IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ s2;
    s1 = slices.Pull();
    if( !slices.TryPull( out s2 ) )
        s2 = dis.Slice( dis.Count, Integer.Create( 0 ) );

    return TupleHD.Create( s1, s2 );
}


private static
    SCG.IEnumerable< IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ >
SplitWhereIterator<
    T
>(
    IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ dis,
    Predicate< T >          where,
    bool                    includeSeparator,
    IInteger                maxSlices
)
{
    if( maxSlices.Equals( Integer.Create( 1 ) ) ) {
        yield return dis.Slice( Integer.Create( 0 ), dis.Count );
        yield break;
    }

    IInteger from = Integer.Create( 0 );
    IInteger count = Integer.Create( 0 );
    IInteger slices = Integer.Create( 0 );
    for(
        IInteger i = Integer.Create( 0 );
        i.LT( dis.Count );
        i = i.Plus( Integer.Create( 1 ) )
    ){
        // This item is a separator
        if( where( dis.Get( i ) ) ) {

            // Yield the slice leading up to this separator
            yield return dis.Slice( from, count );
            slices = slices.Plus( Integer.Create( 1 ) );

            // Start the next slice
            if( includeSeparator ) {
                from = i;
                count = Integer.Create( 1 );
            } else {
                from = i.Plus( Integer.Create( 1 ) );
                count = Integer.Create( 0 );
            }

            // If we're one away from the desired number of slices, bail out
            // and use the rest as the last slice
            if( maxSlices.GT( Integer.Create( 0 ) ) ) {
                if( slices.GTE( maxSlices.Minus( Integer.Create( 1 ) ) ) ) {
                    count = dis.Count.Minus( from );
                    break;
                }
            }

        // This item is not a separator
        } else {
            count = count.Plus( Integer.Create( 1 ) );
            continue;
        }
    }

    // Yield the final (and possibly only) slice
    yield return dis.Slice( from, count );
}



#region PERMUDA TYPESUFFIX
// R:       < T >
// RC:      < T >
// RS:      < T >
// RG:      < T >
// RCS:     < T >
// RCG:     < T >
// RSG:     < T >
// RCSG:    < T >
#endregion




} // type
} // namespace

