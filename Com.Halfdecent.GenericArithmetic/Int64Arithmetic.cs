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



/// %Arithmetic operations for <tt>Int64/long</tt>
public struct
Int64Arithmetic
    : IArithmetic<long>
{


/// (see IArithmetic< T >)
public long MaxValue() { return long.MaxValue; }

/// (see IArithmetic< T >)
public long MinValue() { return long.MinValue; }

/// (see IArithmetic< T >)
public long From( int from ) { return from; }

/// (see IArithmetic< T >)
public long From( uint from ) { return from; }

/// (see IArithmetic< T >)
public long From( long from ) { return from; }

/// (see IArithmetic< T >)
public long From( ulong from ) { return (long)from; }

/// (see IArithmetic< T >)
public long From( float from ) { return (long)from; }

/// (see IArithmetic< T >)
public long From( double from ) { return (long)from; }

/// (see IArithmetic< T >)
public long From( decimal from ) { return (long)from; }

/// (see IArithmetic< T >)
public long Add( long x, long y) { return x + y; }

/// (see IArithmetic< T >)
public long Subtract( long x, long y) { return x - y; }

/// (see IArithmetic< T >)
public long Multiply( long x, long y) { return x * y; }

/// (see IArithmetic< T >)
public long Divide( long x, long y) { return x / y; }




} // type
} // namespace

