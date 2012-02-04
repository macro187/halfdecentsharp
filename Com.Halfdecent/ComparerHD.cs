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
/// <tt>ComparerHD<T></tt> Library
// =============================================================================

public static class
ComparerHD
{


// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// Make a comparer for a type that is <tt>System.IComparable<T></tt>
///
/// The resultant comparer performs bidirectional comparisons using
/// <tt>SystemComparable.CompareToBidirectional()</tt>.
///
/// If <tt>T</tt> is also <tt>IEquatableHD<T></tt>, then
/// <tt>IEquatableHD<T>.GetHashCode()</tt> is used.
///
/// IMPORTANT: If <tt>T</tt> is <strong>not</strong> <tt>IEquatableHD<T></tt>,
/// then <tt>System.Object.GetHashCode()</tt> is used. Callers are responsible
/// for ensuring it matches <tt>System.IComparable<T>.Equals()</tt>.
///
public static
    IComparerHD< T >
Create<
    T
>()
    where T : IComparable< T >
{
    return Create< T >(
        // XXX must be a better way to do this
        obj =>
            obj is IEquatableHD< T >
                ? ((IEquatableHD< T >)obj).GetHashCode()
                : obj.GetHashCode() );
}


/// Make a comparer for a type that is <tt>System.IComparable<T></tt> using a
/// specified hash code function
///
/// The resultant comparer performs bidirectional comparisons using
/// <tt>SystemComparable.CompareToBidirectional()</tt>.
///
/// IMPORTANT: <tt>getHashCodeFunc</tt> must work according to the same
/// definition of equality as <tt>System.IComparable<T>.CompareTo()</tt>.
///
public static
    IComparerHD< T >
Create<
    T
>(
    GetHashCodeFunc< T > getHashCodeFunc
)
    where T : IComparable< T >
{
    return Create< T >(
        (x,y) => x.CompareToBidirectional( y ),
        getHashCodeFunc );
}


/// Make a comparer out of a comparison function and a hash code function
///
/// The comparison function is used to derive an equality function.
///
/// IMPORTANT: <tt>compareFunc</tt> and <tt>getHashCodeFunc</t> must work
/// according to the same definition of equality.
///
public static
    IComparerHD< T >
Create<
    T
>(
    CompareFunc< T >        compareFunc,
    GetHashCodeFunc< T >    getHashCodeFunc
)
{
    return Create< T >(
        compareFunc,
        (x,y) => compareFunc( x, y ) == 0,
        getHashCodeFunc );
}


/// Make a comparer out of a comparison function, an equality function, and a
/// hash code function
///
/// IMPORTANT: <tt>compareFunc</tt>, <tt>equalsFunc</tt>, and
/// <tt>getHashCodeFunc</t> must all work according to the same definition of
/// equality.
///
public static
    IComparerHD< T >
Create<
    T
>(
    CompareFunc< T >        compareFunc,
    EqualsFunc< T >         equalsFunc,
    GetHashCodeFunc< T >    getHashCodeFunc
)
{
    return new ComparerHD< T >(
        compareFunc,
        equalsFunc,
        getHashCodeFunc );
}




} // type
} // namespace

