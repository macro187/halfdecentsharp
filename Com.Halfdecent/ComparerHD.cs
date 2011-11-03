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

/// TODO
//
public static
    IComparer< T >
Create<
    T
>()
    where T : IComparable< T >
{
    return Create< T >(
        obj => obj.GetHashCode() );
}


/// TODO
//
public static
    IComparer< T >
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


public static
    IComparer< T >
Create<
    T
>(
    CompareFunc< T > compareFunc
)
{
    return Create< T >(
        compareFunc,
        obj => obj.GetHashCode() );
}


public static
    IComparer< T >
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




} // type
} // namespace

