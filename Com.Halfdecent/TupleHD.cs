// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2011
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
/// <tt>ITupleHD< T1, T2 ></tt> Library
// =============================================================================

public static class
TupleHD
{



/// Create a tuple
///
public static
    ITupleHD< T1, T2 >
Create<
    T1,
    T2
>(
    T1 a,
    T2 b
)
{
    return new TupleHD< T1, T2 >( a, b );
}


/// Determine whether both tuple values are equal to the specified values
///
/// @exception NotSupportedException
/// <tt>T1</tt> is not <tt>System.IEquatable<T1></tt> or
/// <tt>IEquatableHD<T1></tt>
/// - OR -
/// <tt>T2</tt> is not <tt>System.IEquatable<T2></tt> or
/// <tt>IEquatableHD<T2></tt>
///
public static
    bool
BothEqual<
    T1,
    T2
>(
    this ITupleHD< T1, T2 > dis,
    T1                      a,
    T2                      b
)
{
    return
        EqualityComparerHD.Create< T1 >().Equals( a, dis.A )
        && EqualityComparerHD.Create< T2 >().Equals( b, dis.B );
}


/// Assign the tuple values to the specifed variables
///
public static
    void
AssignTo<
    T1,
    T2
>(
    this ITupleHD< T1, T2 > dis,
    out T1                  a,
    out T2                  b
)
{
    if( dis == null )
        throw new ArgumentNullException( "dis" );
    a = dis.A;
    b = dis.B;
}


public static
    ITupleHD< TTo1, TTo2 >
Covary<
    TFrom1,
    TFrom2,
    TTo1,
    TTo2
>(
    this ITupleHD< TFrom1, TFrom2 > dis
)
    where TFrom1 : TTo1
    where TFrom2 : TTo2
{
    if( dis == null )
        throw new ArgumentNullException( "dis" );
    return Create< TTo1, TTo2 >( dis.A, dis.B );
}


#if DOTNET40
public static
    Tuple< T1, T2 >
AsTuple<
    T1,
    T2
>(
    this ITupleHD< T1, T2 > dis
)
{
    if( dis == null )
        throw new ArgumentNullException( "dis" );
    return new Tuple< T1, T2 >( dis.A, dis.B );
}
#endif


public static
    IMaybe< T >
AsMaybe<
    T
>(
    this ITupleHD< bool, T > dis
)
{
    if( dis == null )
        throw new System.ArgumentNullException( "dis" );
    if( dis.A )
        return Maybe.Create< T >( dis.B );
    else
        return Maybe.Create< T >();
}




} // type
} // namespace

