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


namespace
Com.Halfdecent
{


// =============================================================================
/// `IEquatableHD<T>` Library
// =============================================================================

public static class
EquatableHD
{


// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

public static
    bool
EqualsBidirectional<
    T
>(
    this T  dis,
    T       that
)
    where T : IEquatableHD< T >
{
    return EqualsBidirectional< T >(
        dis,
        that,
        (x,y) => x.Equals( y ),
        (x,y) => y.Equals( x ) );
}



// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

public static
    bool
EqualsBidirectional<
    T
>(
    T               x,
    T               y,
    EqualsFunc< T > equalsFunc1,
    EqualsFunc< T > equalsFunc2
)
{
    if( equalsFunc1 == null )
        throw new ArgumentNullException( "equalsFunc1" );
    if( equalsFunc2 == null )
        throw new ArgumentNullException( "equalsFunc2" );
    if( x == null && y == null ) return true;
    if( x == null || y == null ) return false;
    return equalsFunc1( x, y ) && equalsFunc2( x, y );
}




} // type
} // namespace

