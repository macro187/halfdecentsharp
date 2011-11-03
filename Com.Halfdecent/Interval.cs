// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010, 2011
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
using System.Collections.Generic;


namespace
Com.Halfdecent
{


// =============================================================================
/// <tt>IInterval< T ></tt> Library
// =============================================================================

public static class
Interval
{



// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// Create an interval between comparable values including both endpoints
///
public static
    IInterval< T >
Create<
    T
>(
    T from,
    T to
)
    where T : IComparable< T >
{
    return Create< T >(
        from,
        true,
        to,
        true );
}


/// Create an interval between comparable values with specified endpoint
/// inclusion
///
public static
    IInterval< T >
Create<
    T
>(
    T    from,
    bool fromInclusive,
    T    to,
    bool toInclusive
)
    where T : IComparable< T >
{
    //
    // XXX
    // Hack around the fact that overloading doesn't consider generic
    // constraints, i.e. we can't have a Create() for IComparable<T>'s and
    // another for IComparableHD<T>'s
    //
    if( from is IComparableHD< T > ) {
        return Create< T >(
            from,
            fromInclusive,
            to,
            toInclusive,
            (x,y) => x.CompareToBidirectional( y ),
            (IComparableHD< T > cmp) => cmp.GetHashCode() );
    } else {
        return Create< T >(
            from,
            fromInclusive,
            to,
            toInclusive,
            (x,y) => x.CompareToBidirectional( y ),
            obj => obj.GetHashCode() );
    }

}


/// Create an interval between values with specified endpoint inclusion,
/// comparison, and hash code implementation
///
public static
    IInterval< T >
Create<
    T
>(
    T                       from,
    bool                    fromInclusive,
    T                       to,
    bool                    toInclusive,
    CompareFunc< T >        compareFunc,
    GetHashCodeFunc< T >    getHashCodeFunc
)
{
    return new Interval< T >(
        from,
        fromInclusive,
        to,
        toInclusive,
        compareFunc,
        getHashCodeFunc );
}


public static
    bool
Equals<
    T
>(
    IInterval< T > x,
    IInterval< T > y
)
{
    if( x == null && y == null ) return true;
    if( x == null || y == null ) return false;

    return
        x.CompareFunc == y.CompareFunc
        && x.GetHashCodeFunc == y.GetHashCodeFunc
        && x.CompareFunc( x.From, y.From ) == 0
        && x.FromInclusive == y.FromInclusive
        && x.CompareFunc( x.To, y.To ) == 0
        && x.ToInclusive == y.ToInclusive;
}


public static
    int
GetHashCode<
    T
>(
    IInterval< T > i
)
{
    if( i == null )
        throw new ArgumentNullException( "i" );
    return
        typeof( IInterval< T > ).GetHashCode()
        ^ i.CompareFunc.GetHashCode()
        ^ i.GetHashCodeFunc.GetHashCode()
        ^ i.GetHashCodeFunc( i.From )
        ^ i.FromInclusive.GetHashCode()
        ^ i.GetHashCodeFunc( i.To )
        ^ i.ToInclusive.GetHashCode();
}


public static
    string
ToString<
    T
>(
    IInterval< T > dis
)
{
    if( dis == null )
        throw new ArgumentNullException( "dis" );
    return string.Format(
        "{0} {1} x {2} {3}",
        dis.From,
        dis.FromInclusive ? "<=" : "<",
        dis.ToInclusive ? "<=" : "<",
        dis.To );
}



// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

/// Determine if a value is within the interval
///
public static
    bool
Contains<
    T
>(
    this IInterval< T > dis,
    T                   value
)
{
    if( dis == null )
        throw new ArgumentNullException( "dis" );
    if( value == null )
        throw new ArgumentNullException( "value" );
    return
        ( dis.FromInclusive
            ? dis.CompareFunc( value, dis.From ) >= 0
            : dis.CompareFunc( value, dis.From ) > 0 )
        && ( dis.ToInclusive
            ? dis.CompareFunc( value, dis.To ) <= 0
            : dis.CompareFunc( value, dis.To ) < 0 );
}




} // type
} // namespace

