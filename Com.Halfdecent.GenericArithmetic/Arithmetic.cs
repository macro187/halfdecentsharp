// -----------------------------------------------------------------------------
// Copyright (c) 2007 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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
Com.Halfdecent.GenericArithmetic
{



/// Generic arithmetic operations
public class
Arithmetic
{



// (not createable)
private Arithmetic() {}



/// Gets an IArithmetic< T > implementation for a given numeric
/// type
///
/// @exception ArgumentException
/// If arithmetic support is not available for <tt>T</tt>
public static IArithmetic<T>
Get<
    T
>()
{
    IArithmetic<T> result;
    Type t = typeof( T );

    // Int32
    if( t == typeof( int ) ) {
        result = new Int32Arithmetic() as IArithmetic<T>;

    // Int64
    } else if( t == typeof( long ) ) {
        result = new Int64Arithmetic() as IArithmetic<T>;

    // Unsupported
    } else {
        throw new ArgumentException( String.Format(
            "No Com.Halfdecent.GenericArithmetic support for '{0}'",
            t.FullName ));
    }

    if( result == null ) throw new Exception( "BUG in Arithmetic.Get()" );
    return result;
}



/// Convert from <tt>Int32/int</tt> to <tt>T</tt>
public static T
From<T>( int from) { return Get< T >().From( from ); }

/// Convert from <tt>UInt32/uint</tt> to <tt>T</tt>
public static T
From<T>( uint from) { return Get< T >().From( from ); }

/// Convert from <tt>Int64/long</tt> to <tt>T</tt>
public static T
From<T>( long from) { return Get< T >().From( from ); }

/// Convert from <tt>UInt64/ulong</tt> to <tt>T</tt>
public static T
From<T>( ulong from) { return Get< T >().From( from ); }

/// Convert from <tt>Single/float</tt> to <tt>T</tt>
public static T
From<T>( float from) { return Get< T >().From( from ); }

/// Convert from <tt>Double/double</tt> to <tt>T</tt>
public static T
From<T>( double from) { return Get< T >().From( from ); }

/// Convert from <tt>Decimal/decimal</tt> to <tt>T</tt>
public static T
From<T>( decimal from) { return Get< T >().From( from ); }



/// Addition
public static T
Add<T>(
    T addend1,
    T addend2
)
{
    return Get< T >().Add( addend1, addend2 );
}



/// Subtraction
public static T
Subtract<T>(
    T minuend,
    T subtrahend
)
{
    return Get< T >().Subtract( minuend, subtrahend );
}



/// Multiplication
public static T
Multiply<T>(
    T factor1,
    T factor2
)
{
    return Get< T >().Multiply( factor1, factor2 );
}



/// Division
public static T
Divide<T>(
    T dividend,
    T divisor
)
{
    return Get< T >().Divide( dividend, divisor );
}




} // type
} // namespace

