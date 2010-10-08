// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010
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

/// Create an interval of comparable items that includes both endpoints
///
/// Using the default implementation (<tt>Interval<T></tt>)
///
public static
    IInterval< T >
Create<
    T
>(
    T from,
    T to
)
    where T : System.IComparable< T >
{
    return Create( from, true, to, true );
}


/// Create an interval of comparable items with specified inclusion/exclusion
/// of endpoints
///
/// Using the default implementation (<tt>Interval<T></tt>)
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
    where T : System.IComparable< T >
{
    return Create(
        from, fromInclusive, to, toInclusive,
        new SystemComparableComparer< T >() );
}


/// Create an interval with specified inclusion/exclusion of endpoints, ordered
/// by a specified comparer
///
/// Using the default implementation (<tt>Interval<T></tt>)
///
public static
    IInterval< T >
Create<
    T
>(
    T               from,
    bool            fromInclusive,
    T               to,
    bool            toInclusive,
    IComparer< T >  comparer
)
{
    return new Interval< T >( from, fromInclusive, to, toInclusive, comparer );
}


/// <tt>IInterval<T>.DirectionalEquals()</tt> implementation
///
public static
    bool
DirectionalEquals<
    T
>(
    IInterval< T > dis,
    IInterval< T > that
)
{
    if( object.ReferenceEquals( dis, null ) )
        throw new System.ArgumentNullException( "dis" );
    return
        that != null &&
        that.Comparer.Equals( dis.Comparer ) &&
        that.From.Equals( dis.From ) &&
        that.FromInclusive == dis.FromInclusive &&
        that.To.Equals( dis.To ) &&
        that.ToInclusive == dis.ToInclusive;
}


/// <tt>IInterval<T>.GetHashCode()</tt> implementation
///
public static
    int
GetHashCode<
    T
>(
    IInterval< T > dis
)
{
    if( object.ReferenceEquals( dis, null ) )
        throw new System.ArgumentNullException( "dis" );
    return
        typeof( IInterval< T > ).GetHashCode() ^
        dis.Comparer.GetHashCode() ^
        dis.From.GetHashCode() ^
        dis.FromInclusive.GetHashCode() ^
        dis.To.GetHashCode() ^
        dis.ToInclusive.GetHashCode();
}


/// <tt>IInterval<T>.ToString()</tt> implementation
///
public static
    string
ToString<
    T
>(
    IInterval< T > dis
)
{
    if( object.ReferenceEquals( dis, null ) )
        throw new System.ArgumentNullException( "dis" );
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

/// Determine whether a value is within the interval
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
    if( object.ReferenceEquals( dis, null ) )
        throw new System.ArgumentNullException( "dis" );
    if( object.ReferenceEquals( value, null ) )
        throw new System.ArgumentNullException( "value" );
    return
        ( dis.FromInclusive ?
            dis.Comparer.Compare( value, dis.From ) >= 0 :
            dis.Comparer.Compare( value, dis.From ) > 0 ) &&
        ( dis.ToInclusive ?
            dis.Comparer.Compare( value, dis.To ) <= 0 :
            dis.Comparer.Compare( value, dis.To ) < 0 );
}


/// Covary the interval into one of a less-specific type
///
public static
    IInterval< T >
Covary<
    TFrom,
    T
>(
    this IInterval< TFrom > dis,
    IComparer< T >          comparer
)
    where TFrom : T
{
    if( object.ReferenceEquals( dis, null ) )
        throw new System.ArgumentNullException( "dis" );
    if( object.ReferenceEquals( comparer, null ) )
        throw new System.ArgumentNullException( "comparer" );
    return new Interval< T >(
        dis.From,
        dis.FromInclusive,
        dis.To,
        dis.ToInclusive,
        comparer );
}




} // type
} // namespace

