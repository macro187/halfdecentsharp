// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009
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


using Com.Halfdecent;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Numerics;
using Com.Halfdecent.Testing;


namespace
Com.Halfdecent.Numerics.Test
{


// =============================================================================
/// Test program for <tt>Com.Halfdecent.Numerics</tt>
// =============================================================================

public class
Tests
    : TestBase
{



public static
int
Main()
{
    return TestProgram.RunTests();
}


[Test( "DecimalReal" )]
public static void
Test_DecimalReal()
{
    decimal d = 3.14159m;
    IReal r = Real.From( d );
    IReal l = Real.From( (d - 2m) );
    IReal g = Real.From( (d + 2m) );

    Print( "ToDecimal()" );
    Assert( r.GetValue() == 3.14159m );

    Print( "GT()" );
    Assert( r.GT( l ) );
    Assert( !r.GT( r ) );
    Assert( !r.GT( g ) );

    Print( "GTE()" );
    Assert( r.GTE( l ) );
    Assert( r.GTE( r ) );
    Assert( !r.GTE( g ) );

    Print( "LT()" );
    Assert( !r.LT( l ) );
    Assert( !r.LT( r ) );
    Assert( r.LT( g ) );

    Print( "LTE()" );
    Assert( !r.LTE( l ) );
    Assert( r.LTE( r ) );
    Assert( r.LTE( g ) );

    Print( "Plus()" );
    Assert( r.Plus( Real.From( 2m ) ).GetValue() == d + 2m );
    Assert( r.Plus( Real.From( -2m ) ).GetValue() == d - 2m );

    Print( "Minus()" );
    Assert( r.Minus( Real.From( 2m ) ).GetValue() == d - 2m );
    Assert( r.Minus( Real.From( -2m ) ).GetValue() == d - -2m );

    Print( "Times()" );
    Assert( r.Times( Real.From( 2m ) ).GetValue() == d * 2m );
    Assert( r.Times( Real.From( -2m ) ).GetValue() == d * -2m );

    Print( "DividedBy()" );
    Assert( r.DividedBy( Real.From( 2m ) ).GetValue() == d / 2m );
    Assert( r.DividedBy( Real.From( -2m ) ).GetValue() == d / -2m );

    Print( "Truncate()" );
    Assert( r.Truncate().GetValue() == decimal.Truncate( d ) );
}


[Test( "DecimalInteger" )]
public static void
Test_DecimalInteger()
{
    decimal d = 5;
    IInteger i = Real.From( d ).Truncate();
    IInteger l = Real.From( d - 2m ).Truncate();
    IInteger g = Real.From( d + 2m ).Truncate();

    IInteger result;

    Print( "GetValue()" );
    Assert( i.GetValue() == 5m );

    Print( "GT()" );
    Assert( i.GT( l ) );
    Assert( !i.GT( i ) );
    Assert( !i.GT( g ) );

    Print( "GTE()" );
    Assert( i.GTE( l ) );
    Assert( i.GTE( i ) );
    Assert( !i.GTE( g ) );

    Print( "LT()" );
    Assert( !i.LT( l ) );
    Assert( !i.LT( i ) );
    Assert( i.LT( g ) );

    Print( "LTE()" );
    Assert( !i.LTE( l ) );
    Assert( i.LTE( i ) );
    Assert( i.LTE( g ) );

    Print( "Plus()" );
    result = i.Plus( i );
    Assert( result.GetValue() == d + d );

    Print( "Minus()" );
    result = i.Minus( i );
    Assert( result.GetValue() == d - d );

    Print( "Times()" );
    result = i.Times( i );
    Assert( result.GetValue() == d * d );

    // TODO
    //Print( "RemainderWhenDividedBy()" );
}


[Test( "InUInt64Range" )]
public static void
Test_InUInt64Range()
{
    IRType< IReal > t = new InUInt64Range();
    IReal smaller = Real.From( System.UInt64.MinValue - 1m );
    IReal min = Real.From( System.UInt64.MinValue );
    IReal inrange = Real.From( 10 );
    IReal max = Real.From( System.UInt64.MaxValue );
    IReal bigger = Real.From( System.UInt64.MaxValue + 1m );
    Value _smaller = new Local( "smaller" );
    Value _min = new Local( "min" );
    Value _inrange = new Local( "inrange" );
    Value _max = new Local( "max" );
    Value _bigger = new Local( "bigger" );
    Print( "null passes" );
    t.Require< IReal, IReal >( null, new Literal() );
    Print( "Smaller fails" );
    Expect< RTypeException >( () =>
        t.Require( smaller, _smaller ) );
    Print( "Min passes" );
    t.Require( min, _min );
    Print( "In range passes" );
    t.Require( inrange, _inrange );
    Print( "Max passes" );
    t.Require( max, _max );
    Print( "Bigger fails" );
    Expect< RTypeException >( () =>
        t.Require( bigger, _bigger ) );
}


[Test( "InInt64Range" )]
public static void
Test_InInt64Range()
{
    IRType< IReal > t = new InInt64Range();
    IReal smaller = Real.From( System.Int64.MinValue - 1m );
    IReal min = Real.From( System.Int64.MinValue );
    IReal inrange = Real.From( 10 );
    IReal max = Real.From( System.Int64.MaxValue );
    IReal bigger = Real.From( System.Int64.MaxValue + 1m );
    Value _smaller = new Local( "smaller" );
    Value _min = new Local( "min" );
    Value _inrange = new Local( "inrange" );
    Value _max = new Local( "max" );
    Value _bigger = new Local( "bigger" );
    Print( "null passes" );
    t.Require< IReal, IReal >( null, new Literal() );
    Print( "Smaller fails" );
    Expect< RTypeException >( () =>
        t.Require( smaller, _smaller ) );
    Print( "Min passes" );
    t.Require( min, _min );
    Print( "In range passes" );
    t.Require( inrange, _inrange );
    Print( "Max passes" );
    t.Require( max, _max );
    Print( "Bigger fails" );
    Expect< RTypeException >( () =>
        t.Require( bigger, _bigger ) );
}


[Test( "InUInt32Range" )]
public static void
Test_InUInt32Range()
{
    IRType< IReal > t = new InUInt32Range();
    IReal smaller = Real.From( System.UInt32.MinValue - 1m );
    IReal min = Real.From( System.UInt32.MinValue );
    IReal inrange = Real.From( 10 );
    IReal max = Real.From( System.UInt32.MaxValue );
    IReal bigger = Real.From( System.UInt32.MaxValue + 1m );
    Value _smaller = new Local( "smaller" );
    Value _min = new Local( "min" );
    Value _inrange = new Local( "inrange" );
    Value _max = new Local( "max" );
    Value _bigger = new Local( "bigger" );
    Print( "null passes" );
    t.Require< IReal, IReal >( null, new Literal() );
    Print( "Smaller fails" );
    Expect< RTypeException >( () =>
        t.Require( smaller, _smaller ) );
    Print( "Min passes" );
    t.Require( min, _min );
    Print( "In range passes" );
    t.Require( inrange, _inrange );
    Print( "Max passes" );
    t.Require( max, _max );
    Print( "Bigger fails" );
    Expect< RTypeException >( () =>
        t.Require( bigger, _bigger ) );
}


[Test( "InInt32Range" )]
public static void
Test_InInt32Range()
{
    IRType< IReal > t = new InInt32Range();
    IReal smaller = Real.From( System.Int32.MinValue - 1m );
    IReal min = Real.From( System.Int32.MinValue );
    IReal inrange = Real.From( 10 );
    IReal max = Real.From( System.Int32.MaxValue );
    IReal bigger = Real.From( System.Int32.MaxValue + 1m );
    Value _smaller = new Local( "smaller" );
    Value _min = new Local( "min" );
    Value _inrange = new Local( "inrange" );
    Value _max = new Local( "max" );
    Value _bigger = new Local( "bigger" );
    Print( "null passes" );
    t.Require< IReal, IReal >( null, new Literal() );
    Print( "Smaller fails" );
    Expect< RTypeException >( () =>
        t.Require( smaller, _smaller ) );
    Print( "Min passes" );
    t.Require( min, _min );
    Print( "In range passes" );
    t.Require( inrange, _inrange );
    Print( "Max passes" );
    t.Require( max, _max );
    Print( "Bigger fails" );
    Expect< RTypeException >( () =>
        t.Require( bigger, _bigger ) );
}


[Test( "InUInt16Range" )]
public static void
Test_InUInt16Range()
{
    IRType< IReal > t = new InUInt16Range();
    IReal smaller = Real.From( System.UInt16.MinValue - 1m );
    IReal min = Real.From( System.UInt16.MinValue );
    IReal inrange = Real.From( 10 );
    IReal max = Real.From( System.UInt16.MaxValue );
    IReal bigger = Real.From( System.UInt16.MaxValue + 1m );
    Value _smaller = new Local( "smaller" );
    Value _min = new Local( "min" );
    Value _inrange = new Local( "inrange" );
    Value _max = new Local( "max" );
    Value _bigger = new Local( "bigger" );
    Print( "null passes" );
    t.Require< IReal, IReal >( null, new Literal() );
    Print( "Smaller fails" );
    Expect< RTypeException >( () =>
        t.Require( smaller, _smaller ) );
    Print( "Min passes" );
    t.Require( min, _min );
    Print( "In range passes" );
    t.Require( inrange, _inrange );
    Print( "Max passes" );
    t.Require( max, _max );
    Print( "Bigger fails" );
    Expect< RTypeException >( () =>
        t.Require( bigger, _bigger ) );
}


[Test( "InInt16Range" )]
public static void
Test_InInt16Range()
{
    IRType< IReal > t = new InInt16Range();
    IReal smaller = Real.From( System.Int16.MinValue - 1m );
    IReal min = Real.From( System.Int16.MinValue );
    IReal inrange = Real.From( 10 );
    IReal max = Real.From( System.Int16.MaxValue );
    IReal bigger = Real.From( System.Int16.MaxValue + 1m );
    Value _smaller = new Local( "smaller" );
    Value _min = new Local( "min" );
    Value _inrange = new Local( "inrange" );
    Value _max = new Local( "max" );
    Value _bigger = new Local( "bigger" );
    Print( "null passes" );
    t.Require< IReal, IReal >( null, new Literal() );
    Print( "Smaller fails" );
    Expect< RTypeException >( () =>
        t.Require( smaller, _smaller ) );
    Print( "Min passes" );
    t.Require( min, _min );
    Print( "In range passes" );
    t.Require( inrange, _inrange );
    Print( "Max passes" );
    t.Require( max, _max );
    Print( "Bigger fails" );
    Expect< RTypeException >( () =>
        t.Require( bigger, _bigger ) );
}


[Test( "InByteRange" )]
public static void
Test_InByteRange()
{
    IRType< IReal > t = new InByteRange();
    IReal smaller = Real.From( System.Byte.MinValue - 1m );
    IReal min = Real.From( System.Byte.MinValue );
    IReal inrange = Real.From( 10 );
    IReal max = Real.From( System.Byte.MaxValue );
    IReal bigger = Real.From( System.Byte.MaxValue + 1m );
    Value _smaller = new Local( "smaller" );
    Value _min = new Local( "min" );
    Value _inrange = new Local( "inrange" );
    Value _max = new Local( "max" );
    Value _bigger = new Local( "bigger" );
    Print( "null passes" );
    t.Require< IReal, IReal >( null, new Literal() );
    Print( "Smaller fails" );
    Expect< RTypeException >( () =>
        t.Require( smaller, _smaller ) );
    Print( "Min passes" );
    t.Require( min, _min );
    Print( "In range passes" );
    t.Require( inrange, _inrange );
    Print( "Max passes" );
    t.Require( max, _max );
    Print( "Bigger fails" );
    Expect< RTypeException >( () =>
        t.Require( bigger, _bigger ) );
}


[Test( "InSByteRange" )]
public static void
Test_InSByteRange()
{
    IRType< IReal > t = new InSByteRange();
    IReal smaller = Real.From( System.SByte.MinValue - 1m );
    IReal min = Real.From( System.SByte.MinValue );
    IReal inrange = Real.From( 10 );
    IReal max = Real.From( System.SByte.MaxValue );
    IReal bigger = Real.From( System.SByte.MaxValue + 1m );
    Value _smaller = new Local( "smaller" );
    Value _min = new Local( "min" );
    Value _inrange = new Local( "inrange" );
    Value _max = new Local( "max" );
    Value _bigger = new Local( "bigger" );
    Print( "null passes" );
    t.Require< IReal, IReal >( null, new Literal() );
    Print( "Smaller fails" );
    Expect< RTypeException >( () =>
        t.Require( smaller, _smaller ) );
    Print( "Min passes" );
    t.Require( min, _min );
    Print( "In range passes" );
    t.Require( inrange, _inrange );
    Print( "Max passes" );
    t.Require( max, _max );
    Print( "Bigger fails" );
    Expect< RTypeException >( () =>
        t.Require( bigger, _bigger ) );
}


[Test( "InDecimalRange" )]
public static void
Test_InDecimalRange()
{
    IRType< IReal > t = new InDecimalRange();
    IReal min = Real.From( System.Decimal.MinValue );
    IReal inrange = Real.From( 10 );
    IReal max = Real.From( System.Decimal.MaxValue );
    Value _min = new Local( "min" );
    Value _inrange = new Local( "inrange" );
    Value _max = new Local( "max" );
    Print( "null passes" );
    t.Require< IReal, IReal >( null, new Literal() );
    Print( "Min passes" );
    t.Require( min, _min );
    Print( "In range passes" );
    t.Require( inrange, _inrange );
    Print( "Max passes" );
    t.Require( max, _max );
}


[Test( "NonFractional" )]
public static void
Test_NonFractional()
{
    NonFractional t = new NonFractional();
    NonFractional u = new NonFractional();

    Print( ".Equals() and GetHashCode()" );
    AssertEqual( t, t );
    AssertEqual( t, u );
    AssertEqual( t.GetHashCode(), u.GetHashCode() );

    Print( "Null passes" );
    t.Require< IReal, IReal >( null, new Literal() );

    Print( "Not fractional passes" );
    t.Require( Real.From( 5m ), new Literal() );

    Print( "Fractional fails" );
    Expect< RTypeException >( delegate() {
        t.Require( Real.From( 5.5m ), new Literal() );
    } );

    Print( "Negative not fractional passes" );
    t.Require( Real.From( -5m ), new Literal() );

    Print( "Negative fractional fails" );
    Expect< RTypeException >( delegate() {
        t.Require( Real.From( -5.5m ), new Literal() );
    } );
}


[Test( "NonZero" )]
public static void
Test_NonZero()
{
    NonZero t = new NonZero();
    NonZero u = new NonZero();

    Print( ".Equals() and GetHashCode()" );
    AssertEqual( t, t );
    AssertEqual( t, u );
    AssertEqual( t.GetHashCode(), u.GetHashCode() );

    Print( "Null passes" );
    t.Require< IReal, IReal >( null, new Literal() );

    Print( "Negative passes" );
    t.Require( Real.From( -5m ), new Literal() );

    Print( "Positive passes" );
    t.Require( Real.From( 5m ), new Literal() );

    Print( "Zero fails" );
    Expect< RTypeException >( delegate() {
        t.Require( Real.From( 0m ), new Literal() );
    } );
}


[Test( "NonNegative" )]
public static void
Test_NonNegative()
{
    NonNegative t = new NonNegative();
    NonNegative u = new NonNegative();

    Print( ".Equals() and GetHashCode()" );
    AssertEqual( t, t );
    AssertEqual( t, u );
    AssertEqual( t.GetHashCode(), u.GetHashCode() );

    Print( "Null passes" );
    t.Require< IReal, IReal >( null, new Literal() );

    Print( "Negative fails" );
    Expect< RTypeException >( delegate() {
        t.Require( Real.From( -5m ), new Literal() );
    } );

    Print( "Zero passes" );
    t.Require( Real.From( 0m ), new Literal() );

    Print( "Positive passes" );
    t.Require( Real.From( 5m ), new Literal() );
}




} // type
} // namespace

