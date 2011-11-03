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
    IMaybe< U >
If<
    T,
    U
>(
    this IMaybe< T >    dis,
    Func< T, U >        hasValueFunc
)
{
    if( dis == null )
        throw new ArgumentNullException( "dis" );
    if( hasValueFunc == null )
        throw new ArgumentNullException( "hasValueFunc" );
    if( dis.HasValue )
        return Maybe.Create( hasValueFunc( dis.Value ) );
    else
        return Maybe.Create< U >();
}


public static
    void
If<
    T
>(
    this IMaybe< T >    dis,
    Action< T >         hasValueAction,
    Action              hasNoValueAction
)
{
    if( dis == null )
        throw new ArgumentNullException( "dis" );
    if( hasValueAction == null )
        throw new ArgumentNullException( "hasValueAction" );
    if( hasNoValueAction == null )
        hasNoValueAction = () => {};
    if( dis.HasValue )
        hasValueAction( dis.Value );
    else
        hasNoValueAction();
}


public static
    T
Else<
    T
>(
    this IMaybe< T >    dis,
    Func< T >           hasNoValueFunc
)
{
    if( dis == null )
        throw new ArgumentNullException( "dis" );
    if( hasNoValueFunc == null )
        throw new ArgumentNullException( "hadNoValueFunc" );
    return
        dis.HasValue
        ? dis.Value
        : hasNoValueFunc();
}



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
        throw new ArgumentNullException( "dis" );
    return new Maybe< TTo >(
        dis.HasValue,
        dis.HasValue ? dis.Value : default( TTo ) );
}




} // type
} // namespace

