// -----------------------------------------------------------------------------
// Copyright (c) 2011
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


namespace
Com.Halfdecent
{


// =============================================================================
/// <tt>System.IComparable<T></tt> library
// =============================================================================

public static class
SystemComparable
{


// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

public static
    int
CompareToBidirectional<
    T
>(
    this T  dis,
    T       that
)
    where T : IComparable< T >
{
    return CompareBidirectional< T >(
        dis,
        that,
        (x,y) => x.CompareTo( y ),
        (x,y) => y.CompareTo( x ) );
}


public static
    bool
GT<
    T
>(
    this T  dis,
    T       that
)
    where T : IComparable< T >
{
    return dis.CompareToBidirectional( that ) > 0;
}


public static
    bool
GTE<
    T
>(
    this T  dis,
    T       that
)
    where T : IComparable< T >
{
    return dis.CompareToBidirectional( that ) >= 0;
}


public static
    bool
LT<
    T
>(
    this T  dis,
    T       that
)
    where T : IComparable< T >
{
    return dis.CompareToBidirectional( that ) < 0;
}


public static
    bool
LTE<
    T
>(
    this T  dis,
    T       that
)
    where T : IComparable< T >
{
    return dis.CompareToBidirectional( that ) <= 0;
}



// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

public static
    int
CompareBidirectional<
    T
>(
    T                   x,
    T                   y,
    CompareFunc< T >    compareFunc1,
    CompareFunc< T >    compareFunc2
)
{
    if( compareFunc1 == null )
        throw new ArgumentNullException( "compareFunc1" );
    if( compareFunc2 == null )
        throw new ArgumentNullException( "compareFunc2" );

    // Handle nulls according to System.IComparable.CompareTo() rules
    if( x == null && y == null ) return 0;
    if( x == null ) return -1;
    if( y == null ) return 1;

    // Get both opinions
    int r1 = compareFunc1( x, y );
    int r2 = compareFunc2( x, y );

    // If both items agree, use the agreed result
    if( r1 == 0 && r2 == 0 ) return 0;
    if( r1 > 0 && r2 < 0 ) return 1;
    if( r1 < 0 && r2 > 0 ) return -1;

    // If one says equal and the other says greater or less than, assume the
    // latter is more specific and go with that
    if( r1 == 0 && r2 < 0 ) return 1;
    if( r1 == 0 && r2 > 0 ) return -1;
    if( r1 > 0 && r2 == 0 ) return 1;
    if( r1 < 0 && r2 == 0 ) return -1;

    // If neither of the above is the case, then the items completely disagree
    // which means something's wrong with one or both of their CompareTo()
    // implementations
    throw new ComparisonDisagreementException(
        typeof( T ),
        x.GetType(),
        x,
        r1,
        y.GetType(),
        y,
        r2 );
}




} // type
} // namespace

