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


namespace
Com.Halfdecent
{


// =============================================================================
/// <tt>IMaybe< T ></tt> Library
// =============================================================================

public static class
Maybe
{



// -----------------------------------------------------------------------------
// Static
// -----------------------------------------------------------------------------

/// Create a maybe with no value
///
public static
    IMaybe< T >
Create<
    T
>()
{
    return new Maybe< T >( false, default( T ) );
}


/// Create a maybe with a specified value
///
public static
    IMaybe< T >
Create<
    T
>(
    T value
)
{
    return new Maybe< T >( true, value );
}



// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

public static
    IMaybe< TTo >
Covary<
    TFrom,
    TTo
>(
    this IMaybe< TFrom > dis
)
    where TFrom : TTo
{
    if( object.ReferenceEquals( dis, null ) )
        throw new System.ArgumentNullException( "dis" );
    return new Maybe< TTo >(
        dis.HasValue,
        dis.HasValue ? dis.Value : default( TTo ) );
}




} // type
} // namespace
