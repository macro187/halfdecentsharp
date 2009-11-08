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
using System.Collections.Generic;
using System.Linq;


namespace
Com.Halfdecent.SystemUtils
{


// =============================================================================
/// <tt>System.Collections.Generic.IEnumerable</tt> Library
// =============================================================================

public static class
EnumerableUtils
{



// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

/// Generate an enumerable that yields a single instance of this item
///
public static
IEnumerable< T >
AsSingleItemEnumerable<
    T
>(
    this T item
)
{
    yield return item;
}


/// Generate an enumerable yielding all items in this one plus the specified
/// item
///
public static
IEnumerable< T >
Append<
    T
>(
    this IEnumerable< T >   enumerable,
    T                       newItem
)
{
    if( enumerable == null ) throw new ArgumentNullException( "enumerable" );
    foreach( T item in enumerable ) yield return item;
    yield return newItem;
}


/// Covary the enumerable to one of items of a less-specific type
///
public static
IEnumerable< TTo >
Covary<
    TFrom,
    TTo
>(
    this IEnumerable< TFrom > e
)
    where TFrom : TTo
{
    return e.Select< TFrom, TTo >( i => i );
}




} // type
} // namespace

