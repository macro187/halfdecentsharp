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


using SCG = System.Collections.Generic;
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
/// specified criteria, with those elements excluded
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
    System.Predicate< T > where
)
{
    new NonNull().Require( dis, new Parameter( "dis" ) );
    new NonNull().Require( where, new Parameter( "where" ) );
    return
        SplitWhereIterator< T >( dis, where, false, Integer.From( -1 ) )
        .AsStream();
}


/// Split the collection into (a maximum of) two by-reference slices at the
/// first element matching specified criteria, with that element excluded
///
/// If no separator element is found, a slice consisting of the entire
/// collection is returned.
///
/// The slices are produced using <tt>.Slice()</tt>.
///
public static
    IStream< IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ >
SplitAtFirstWhere<
    T
>(
    this IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ dis,
    System.Predicate< T > where
)
{
    new NonNull().Require( dis, new Parameter( "dis" ) );
    new NonNull().Require( where, new Parameter( "where" ) );
    return
        SplitWhereIterator< T >( dis, where, false, Integer.From( 2 ) )
        .AsStream();
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
    System.Predicate< T > where
)
{
    new NonNull().Require( dis, new Parameter( "dis" ) );
    new NonNull().Require( where, new Parameter( "where" ) );
    return
        SplitWhereIterator< T >( dis, where, true, Integer.From( -1 ) )
        .AsStream();
}


/// Split the collection into (a maximum of) two by-reference slices at the
/// first element matching specified criteria, with that element included
///
/// If no separator element is found, a slice consisting of the entire
/// collection is returned.
///
/// The slices are produced using <tt>.Slice()</tt>.
///
public static
    IStream< IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ >
SplitBeforeFirstWhere<
    T
>(
    this IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ dis,
    System.Predicate< T > where
)
{
    new NonNull().Require( dis, new Parameter( "dis" ) );
    new NonNull().Require( where, new Parameter( "where" ) );
    return
        SplitWhereIterator< T >( dis, where, true, Integer.From( 2 ) )
        .AsStream();
}


private static
    SCG.IEnumerable< IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ >
SplitWhereIterator<
    T
>(
    IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ dis,
    System.Predicate< T >   where,
    bool                    includeSeparator,
    IInteger                maxSlices
)
{
    if( maxSlices.Equals( Integer.From( 1 ) ) ) {
        yield return dis.Slice( Integer.From( 0 ), dis.Count );
        yield break;
    }

    IInteger from = Integer.From( 0 );
    IInteger count = Integer.From( 0 );
    IInteger slices = Integer.From( 0 );
    for(
        IInteger i = Integer.From( 0 );
        i.LT( dis.Count );
        i = i.Plus( Integer.From( 1 ) )
    ){
        // This item is a separator
        if( where( dis.Get( i ) ) ) {

            // Yield the slice leading up to this separator
            yield return dis.Slice( from, count );
            slices = slices.Plus( Integer.From( 1 ) );

            // Start the next slice
            if( includeSeparator ) {
                from = i;
                count = Integer.From( 1 );
            } else {
                from = i.Plus( Integer.From( 1 ) );
                count = Integer.From( 0 );
            }

            // If we're one away from the desired number of slices, bail out
            // and use the rest as the last slice
            if( maxSlices.GT( Integer.From( 0 ) ) ) {
                if( slices.GTE( maxSlices.Minus( Integer.From( 1 ) ) ) ) {
                    count = dis.Count.Minus( from );
                    break;
                }
            }

        // This item is not a separator
        } else {
            count = count.Plus( Integer.From( 1 ) );
            continue;
        }
    }

    // Yield the final (and possibly only) slice
    yield return dis.Slice( from, count );
}



#region PERMUDA
// combos R RC RS RG RCS RCG RSG RCSG
// filename OrderedCollection/*PERMUDA*/.SplitWhere.cs
#endregion
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

