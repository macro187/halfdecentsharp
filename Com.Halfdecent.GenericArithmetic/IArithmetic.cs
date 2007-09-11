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



/// %Arithmetic operations for a particular type
public interface
IArithmetic<T>
{



/// Convert from <tt>Int32/int</tt> to <tt>T</tt>
T From( int from );

/// Convert from <tt>UInt32/uint</tt> to <tt>T</tt>
T From( uint from );

/// Convert from <tt>Int64/long</tt> to <tt>T</tt>
T From( long from );

/// Convert from <tt>UInt64/ulong</tt> to <tt>T</tt>
T From( ulong from );

/// Convert from <tt>Single/float</tt> to <tt>T</tt>
T From( float from );

/// Convert from <tt>Double/double</tt> to <tt>T</tt>
T From( double from );

/// Convert from <tt>Decimal/decimal</tt> to <tt>T</tt>
T From( decimal from );



/// Addition
T
Add(
    T addend1,
    T addend2
);



/// Subtraction
T
Subtract(
    T minuend,
    T subtrahend
);



/// Multiplication
T
Multiply(
    T factor1,
    T factor2
);


/// Division
T
Divide(
    T dividend,
    T divisor
);




} // type
} // namespace

