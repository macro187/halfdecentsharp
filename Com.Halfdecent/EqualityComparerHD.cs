// -----------------------------------------------------------------------------
// Copyright (c) 2011, 2012
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
/// `EqualityComparerHD<T>` Library
// =============================================================================

public static class
EqualityComparerHD
{


// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// Create a default equality comparer for a specified type
///
/// Comparisons are bidirectional.
///
/// [TODO Discuss IEquatableHD<T>, IEquatable<T>, object]
///
public static
    IEqualityComparerHD< T >
Create<
    T
>()
{
    return new DefaultEqualityComparerHD< T >();
}


/// Make an equality comparer out of an equality function and a hash code
/// function
///
/// IMPORTANT: `equalsFunc` and `getHashCodeFunc` must work according to the
/// same definition of equality.
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



// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

public static
    IEqualityComparerHD< TTo >
Contravary<
    T,
    TTo
>(
    this IEqualityComparerHD< T > dis
)
    where TTo : T
{
    if( dis == null ) throw new ArgumentNullException( "dis" );
    return Create< TTo >(
        (x,y) => dis.Equals( x, y ),
        obj => dis.GetHashCode( obj ) );
}




} // type
} // namespace

