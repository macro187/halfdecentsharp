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



/// %Arithmetic operations for <tt>Int32/int</tt>
public struct
Int32Arithmetic
    : IArithmetic<int>
{


/// (see IArithmetic< T >)
public int MaxValue() { return int.MaxValue; }

/// (see IArithmetic< T >)
public int MinValue() { return int.MinValue; }

/// (see IArithmetic< T >)
public int From( int from ) { return from; }

/// (see IArithmetic< T >)
public int From( uint from ) { return (int)from; }

/// (see IArithmetic< T >)
public int From( long from ) { return (int)from; }

/// (see IArithmetic< T >)
public int From( ulong from ) { return (int)from; }

/// (see IArithmetic< T >)
public int From( float from ) { return (int)from; }

/// (see IArithmetic< T >)
public int From( double from ) { return (int)from; }

/// (see IArithmetic< T >)
public int From( decimal from ) { return (int)from; }

/// (see IArithmetic< T >)
public int Add( int x, int y) { return x + y; }

/// (see IArithmetic< T >)
public int Subtract( int x, int y) { return x - y; }

/// (see IArithmetic< T >)
public int Multiply( int x, int y) { return x * y; }

/// (see IArithmetic< T >)
public int Divide( int x, int y) { return x / y; }




} // type
} // namespace

