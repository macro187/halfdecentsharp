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
using Com.Halfdecent.Testing;
using Com.Halfdecent.GenericArithmetic;



namespace
Com.Halfdecent.GenericArithmetic.Test
{



/// Tests for Com.Halfdecent.Arithmetic
public class
Tests
    : TestBase
{



/// Test program entry point
public static int Main() { return TestProgram.RunTests(); }



[Test( "Arithmetic.Get()" )]
public static void
TestArithmeticGet()
{
    Print( "Get<int>() returns an Int32Arithmetic" );
    IArithmetic<int> aint = Arithmetic.Get<int>();
    AssertEqual( aint.GetType(), typeof( Int32Arithmetic ) );

    Print( "Get<long>() returns an Int64Arithmetic" );
    IArithmetic<long> along = Arithmetic.Get<long>();
    AssertEqual( along.GetType(), typeof( Int64Arithmetic ) );

    Print( "ArgumentException for unsupported type" );
    bool thrown = false;
    try {
        IArithmetic<string> astring = Arithmetic.Get<string>();
        if( astring == null ) {}
    } catch( ArgumentException ae ) {
        thrown = true;
        if( ae == null ) {}
    }
    Assert( thrown );
}



[Test( "Generic Arithmetic (Int32)" )]
public static void
TestArithmeticInt32()
{
    Print( "MinValue() and MaxValue()" );
    AssertEqual( Arithmetic.MinValue<int>(), int.MinValue );
    AssertEqual( Arithmetic.MaxValue<int>(), int.MaxValue );

    Print( "From()" );
    AssertEqual( Arithmetic.From<int>( (int)10 ), 10 );
    AssertEqual( Arithmetic.From<int>( (uint)10 ), 10 );
    AssertEqual( Arithmetic.From<int>( (long)10 ), 10 );
    AssertEqual( Arithmetic.From<int>( (ulong)10 ), 10 );
    AssertEqual( Arithmetic.From<int>( (float)10 ), 10 );
    AssertEqual( Arithmetic.From<int>( (double)10 ), 10 );
    AssertEqual( Arithmetic.From<int>( (decimal)10 ), 10 );

    TestArithmeticOps<int>();
}



/*
[Test( "Generic Arithmetic Ops (UInt32)" )]
public static void
TestArithmeticUInt32()
{
    TestArithmeticOps<uint>();
}
*/



[Test( "Generic Arithmetic (Int64)" )]
public static void
TestArithmeticInt64()
{
    Print( "MinValue() and MaxValue()" );
    AssertEqual( Arithmetic.MinValue<long>(), long.MinValue );
    AssertEqual( Arithmetic.MaxValue<long>(), long.MaxValue );

    Print( "From()" );
    AssertEqual( Arithmetic.From<long>( (int)10 ), 10L );
    AssertEqual( Arithmetic.From<long>( (uint)10 ), 10L );
    AssertEqual( Arithmetic.From<long>( (long)10 ), 10L );
    AssertEqual( Arithmetic.From<long>( (ulong)10 ), 10L );
    AssertEqual( Arithmetic.From<long>( (float)10 ), 10L );
    AssertEqual( Arithmetic.From<long>( (double)10 ), 10L );
    AssertEqual( Arithmetic.From<long>( (decimal)10 ), 10L );

    TestArithmeticOps<long>();
}



public static void
TestArithmeticOps<T>()
{
    T a, b, c;

    Print( "Add()" );
    a = Arithmetic.From<T>( 10 );
    b = Arithmetic.From<T>( 5 );
    c = Arithmetic.From<T>( 15 );
    AssertEqual( Arithmetic.Add( a, b ), c );

    Print( "Subtract()" );
    a = Arithmetic.From<T>( 10 );
    b = Arithmetic.From<T>( 5 );
    c = Arithmetic.From<T>( 5 );
    AssertEqual( Arithmetic.Subtract( a, b ), c );

    Print( "Multiply()" );
    a = Arithmetic.From<T>( 5 );
    b = Arithmetic.From<T>( 5 );
    c = Arithmetic.From<T>( 25 );
    AssertEqual( Arithmetic.Multiply( a, b ), c );

    Print( "Divide()" );
    a = Arithmetic.From<T>( 25 );
    b = Arithmetic.From<T>( 5 );
    c = Arithmetic.From<T>( 5 );
    AssertEqual( Arithmetic.Divide( a, b ), c );
}




} // type
} // namespace

