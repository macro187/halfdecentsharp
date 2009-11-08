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


using System;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Numerics
{


// =============================================================================
/// <tt>IInterval< T ></tt> Library
// =============================================================================

public static class
Interval
{



// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

/// Determine whether a value is within the interval
///
// XXX This logic is duplicated in InInterval< T >, not sure if there's any
//     way around that
public static
bool
Contains<
    T
>(
    this IInterval< T > i,
    T                   value
)
    where T : IComparable
{
    new NonNull().Check( value, new Parameter( "value" ) );
    return
        ( i.FromInclusive
            ? value.CompareTo( i.From ) >= 0
            : value.CompareTo( i.From ) > 0
        )
        && ( i.ToInclusive
            ? value.CompareTo( i.To ) <= 0
            : value.CompareTo( i.To ) < 0
        );
}


/// Covary the interval into one of a less-specific type
///
public static
IInterval< TTo >
Covary<
    TFrom,
    TTo
>(
    this IInterval< TFrom > from
)
    where TFrom : TTo, IComparable
    where TTo : IComparable
{
    new NonNull().Check( from, new Parameter( "from" ) );
    return new Interval< TTo >(
        from.From, from.FromInclusive, from.To, from.ToInclusive );
}



// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// Generate a human-readable string representation of an interval
///
/// Useful for implementing <tt>.ToString()</tt>
///
public static
string
ToString(
    IInterval i
)
{
    new NonNull().Check( i, new Parameter( "i" ) );
    return string.Format(
        "{0} {1} x {2} {3}",
        i.From,
        i.FromInclusive ? "<=" : "<",
        i.ToInclusive ? "<=" : "<",
        i.To );
}


/// Determine whether two intervals are equal
///
/// Useful for implementing <tt>.Equals()</tt>
///
public static
bool
Equals
(
    IInterval i1,
    IInterval i2
)
{
    if( i1 == null && i2 == null ) return true;
    if( i1 == null || i2 == null ) return false;
    return
        i1.From.Equals( i2.From ) &&
        i1.FromInclusive == i2.FromInclusive &&
        i1.To.Equals( i2.To ) &&
        i2.ToInclusive == i2.ToInclusive;
}


/// Generate a hash code for an interval
///
/// Useful for implementing <tt>.GetHashCode()</tt>
///
public static
int
GetHashCode
(
    IInterval i
)
{
    return
        i.From.GetHashCode() ^
        i.FromInclusive.GetHashCode() ^
        i.To.GetHashCode() ^
        i.ToInclusive.GetHashCode();
}




} // type
} // namespace

