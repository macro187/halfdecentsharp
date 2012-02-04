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
using System.Collections.Generic;


namespace
Com.Halfdecent
{


// =============================================================================
/// <tt>EqualityComparerHD<T></tt> Library
// =============================================================================

public static class
EqualityComparerHD
{


// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// Make an equality comparer for a type that is <tt>System.IEquatable<T></tt>
///
/// The resultant comparer performs bidirectional comparisons using
/// <tt>SystemEquatable.EqualsBidirectional()</tt>.
///
/// If <tt>T</tt> is also <tt>IEquatableHD<T></tt>, then
/// <tt>IEquatableHD<T>.GetHashCode()</tt> is used.
///
/// IMPORTANT: If <tt>T</tt> is <strong>not</strong> <tt>IEquatableHD<T></tt>,
/// then <tt>System.Object.GetHashCode()</tt> is used, which must work according
/// to the same definition of equality as
/// <tt>System.IComparable<T>.Equals()</tt>.
///
public static
    IEqualityComparerHD< T >
Create<
    T
>()
    where T : IEquatable< T >
{
    return Create< T >(
        // XXX must be a better way to do this
        obj =>
            obj is IEquatableHD< T >
                ? ((IEquatableHD< T >)obj).GetHashCode()
                : obj.GetHashCode() );
}


/// Make an equality comparer for a type that is <tt>System.IEquatable<T></tt>
/// using a specified hash code function
///
/// The resultant comparer performs bidirectional comparisons using
/// <tt>SystemEquatable.EqualsBidirectional()</tt>.
///
/// IMPORTANT: <tt>getHashCodeFunc</tt> must work according to the same
/// definition of equality as <tt>System.IEquatable<T>.Equals()</tt>.
///
public static
    IEqualityComparerHD< T >
Create<
    T
>(
    GetHashCodeFunc< T > getHashCodeFunc
)
    where T : IEquatable< T >
{
    return Create< T >(
        (x,y) => x.EqualsBidirectional( y ),
        getHashCodeFunc );
}


/// Make an equality comparer out of an equality function and a hash code
/// function
///
/// IMPORTANT: <tt>equalsFunc</tt> and <tt>getHashCodeFunc</t> must work
/// according to the same definition of equality.
///
public static
    IEqualityComparerHD< T >
Create<
    T
>(
    EqualsFunc< T >         equalsFunc,
    GetHashCodeFunc< T >    getHashCodeFunc
)
{
    return new EqualityComparerHD< T >(
        equalsFunc,
        getHashCodeFunc );
}




} // type
} // namespace

