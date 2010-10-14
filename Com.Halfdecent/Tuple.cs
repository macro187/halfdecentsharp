// -----------------------------------------------------------------------------
// Copyright (c) 2010
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
/// <tt>ITuple< T1, T2 ></tt> Library
// =============================================================================

public static class
Tuple
{



/// Create a tuple
///
public static
    ITuple< T1, T2 >
Create<
    T1,
    T2
>(
    T1 a,
    T2 b
)
{
    return new Tuple< T1, T2 >( a, b );
}


/// Assign the tuple values to the specifed variables
///
public static
    void
AssignTo<
    T1,
    T2
>(
    this ITuple< T1, T2 >   dis,
    out T1                  a,
    out T2                  b
)
{
    if( object.ReferenceEquals( dis, null ) )
        throw new System.ArgumentNullException( "dis" );
    a = dis.A;
    b = dis.B;
}


public static
    ITuple< TTo1, TTo2 >
Covary<
    TFrom1,
    TFrom2,
    TTo1,
    TTo2
>(
    this ITuple< TFrom1, TFrom2 > dis
)
    where TFrom1 : TTo1
    where TFrom2 : TTo2
{
    if( object.ReferenceEquals( dis, null ) )
        throw new System.ArgumentNullException( "dis" );
    return new TupleProxy< TFrom1, TFrom2, TTo1, TTo2 >( dis );
}


#if DOTNET40
public static
    System.Tuple< T1, T2 >
AsSystemTuple<
    T1,
    T2
>(
    this ITuple< T1, T2 > dis
)
{
    if( object.ReferenceEquals( dis, null ) )
        throw new System.ArgumentNullException( "dis" );
    return new System.Tuple< T1, T2 >( dis.A, dis.B );
}
#endif




} // type
} // namespace

