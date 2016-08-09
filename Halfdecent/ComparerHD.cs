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
Halfdecent
{


// =============================================================================
/// `ComparerHD<T>` Library
// =============================================================================

public static class
ComparerHD
{


// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// Make a comparer for a comparable type
///
/// [TODO]
///
public static
    IComparerHD< T >
Create<
    T
>()
    where T : IComparable< T >
{
    return new DefaultComparerHD< T >();
}


/// Make a comparer out of a comparison function and a hash code function
///
/// The comparison function is used to derive an equality function.
///
/// IMPORTANT: `compareFunc` and `getHashCodeFunc` must work
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
    return new ComparerHD< T >(
        compareFunc,
        getHashCodeFunc );
}



// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

public static
    IComparerHD< TTo >
Contravary<
    T,
    TTo
>(
    this IComparerHD< T > dis
)
    where TTo : T
{
    if( dis == null ) throw new ArgumentNullException( "dis" );
    return Create< TTo >(
        (x,y) => dis.Compare( x, y ),
        obj => dis.GetHashCode( obj ) );
}




} // type
} // namespace

