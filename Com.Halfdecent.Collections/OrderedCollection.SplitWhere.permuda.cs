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

/// Split the collection into slices at single elements matching the specified
/// criteria
///
/// The slices are produced using <tt>.Slice()</tt>.
///
/// The elements at the split points are not included in the slices.
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
    return SplitWhereIterator< T >( dis, where ).AsStream();
}

private static
    SCG.IEnumerable< IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ >
SplitWhereIterator<
    T
>(
    IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ dis,
    System.Predicate< T > where
)
{
    IInteger from = Integer.From( 0 );
    IInteger count = Integer.From( 0 );
    for(
        IInteger i = Integer.From( 0 );
        i.LT( dis.Count );
        i = i.Plus( Integer.From( 1 ) )
    ){
        // This item is a separator
        if( where( dis.Get( i ) ) ) {

            // Yield the slice leading up to this separator
            yield return dis.Slice( from, count );

            // Next slice starts at the next item
            from = i.Plus( Integer.From( 1 ) );
            count = Integer.From( 0 );

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

