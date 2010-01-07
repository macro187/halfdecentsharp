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


using System;
using Com.Halfdecent.Testing;
using Com.Halfdecent.Numerics;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Meta;


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
    AssertEqual( r.ToDecimal(), 3.14159m );

    Print( "GT()" );
    AssertEqual( r.GT( l ), true );
    AssertEqual( r.GT( r ), false );
    AssertEqual( r.GT( g ), false );

    Print( "GTE()" );
    AssertEqual( r.GTE( l ), true );
    AssertEqual( r.GTE( r ), true );
    AssertEqual( r.GTE( g ), false );

    Print( "LT()" );
    AssertEqual( r.LT( l ), false );
    AssertEqual( r.LT( r ), false );
    AssertEqual( r.LT( g ), true );

    Print( "LTE()" );
    AssertEqual( r.LTE( l ), false );
    AssertEqual( r.LTE( r ), true );
    AssertEqual( r.LTE( g ), true );

    Print( "Plus()" );
    AssertEqual( r.Plus( Real.From( 2m ) ).ToDecimal(), (d + 2m) );
    AssertEqual( r.Plus( Real.From( -2m ) ).ToDecimal(), (d - 2m) );

    Print( "Minus()" );
    AssertEqual( r.Minus( Real.From( 2m ) ).ToDecimal(), (d - 2m) );
    AssertEqual( r.Minus( Real.From( -2m ) ).ToDecimal(), (d - -2m) );

    Print( "Times()" );
    AssertEqual( r.Times( Real.From( 2m ) ).ToDecimal(), (d * 2m) );
    AssertEqual( r.Times( Real.From( -2m ) ).ToDecimal(), (d * -2m) );

    Print( "DividedBy()" );
    AssertEqual( r.DividedBy( Real.From( 2m ) ).ToDecimal(), (d / 2m) );
    AssertEqual( r.DividedBy( Real.From( -2m ) ).ToDecimal(), (d / -2m) );

    Print( "Truncate()" );
    AssertEqual( r.Truncate().ToDecimal(), decimal.Truncate( d ) );
}


[Test( "DecimalInteger" )]
public static void
Test_DecimalInteger()
{
    decimal d = 5;
    IInteger i = Integer.From( d );
    IInteger l = Integer.From( (d - 2m) );
    IInteger g = Integer.From( (d + 2m) );

    Print( "ToDecimal()" );
    AssertEqual( i.ToDecimal(), 5m );

    Print( "GT()" );
    AssertEqual( i.GT( l ), true );
    AssertEqual( i.GT( i ), false );
    AssertEqual( i.GT( g ), false );

    Print( "GTE()" );
    AssertEqual( i.GTE( l ), true );
    AssertEqual( i.GTE( i ), true );
    AssertEqual( i.GTE( g ), false );

    Print( "LT()" );
    AssertEqual( i.LT( l ), false );
    AssertEqual( i.LT( i ), false );
    AssertEqual( i.LT( g ), true );

    Print( "LTE()" );
    AssertEqual( i.LTE( l ), false );
    AssertEqual( i.LTE( i ), true );
    AssertEqual( i.LTE( g ), true );

    Print( "Plus()" );
    AssertEqual( i.Plus( i ).ToDecimal(), (d + d) );

    Print( "Minus()" );
    AssertEqual( i.Minus( i ).ToDecimal(), (d - d) );

    Print( "Times()" );
    AssertEqual( i.Times( i ).ToDecimal(), (d * d) );

    Print( "DividedBy()" );
    Assert( i.DividedBy( i ).GetValue() == d / d );

    // TODO
    //Print( "RemainderWhenDividedBy()" );
}


[Test( "InInt64Range" )]
public static void
Test_InInt64Range()
{
    IRType< IReal > rt = new InInt64Range();

    Print( "null passes" );
    rt.Check< IReal, IReal >( null, new Literal() );

    Print( "Less than min fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( Integer.From( Int64.MinValue - 1m ), new Literal() );
    } );

    Print( "Min passes" );
    rt.Check( Integer.From( Int64.MinValue ), new Literal() );

    Print( "In range passes" );
    rt.Check( Integer.From( 5m ), new Literal() );

    Print( "Max passes" );
    rt.Check( Integer.From( Int64.MaxValue ), new Literal() );

    Print( "Greater than max fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( Integer.From( Int64.MaxValue + 1m ), new Literal() );
    } );
}


[Test( "InUInt64Range" )]
public static void
Test_InUInt64Range()
{
    IRType< IReal > rt = new InUInt64Range();

    Print( "null passes" );
    rt.Check< IReal, IReal >( null, new Literal() );

    Print( "Less than min fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( Integer.From( UInt64.MinValue - 1m ), new Literal() );
    } );

    Print( "Min passes" );
    rt.Check( Integer.From( UInt64.MinValue ), new Literal() );

    Print( "In range passes" );
    rt.Check( Integer.From( 5m ), new Literal() );

    Print( "Max passes" );
    rt.Check( Integer.From( UInt64.MaxValue ), new Literal() );

    Print( "Greater than max fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( Integer.From( UInt64.MaxValue + 1m ), new Literal() );
    } );
}


[Test( "InInt32Range" )]
public static void
Test_InInt32Range()
{
    IRType< IReal > rt = new InInt32Range();

    Print( "null passes" );
    rt.Check< IReal, IReal >( null, new Literal() );

    Print( "Less than min fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( Integer.From( Int32.MinValue - 1m ), new Literal() );
    } );

    Print( "Min passes" );
    rt.Check( Integer.From( Int32.MinValue ), new Literal() );

    Print( "In range passes" );
    rt.Check( Integer.From( 5m ), new Literal() );

    Print( "Max passes" );
    rt.Check( Integer.From( Int32.MaxValue ), new Literal() );

    Print( "Greater than max fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( Integer.From( Int32.MaxValue + 1m ), new Literal() );
    } );
}


[Test( "InUInt32Range" )]
public static void
Test_InUInt32Range()
{
    IRType< IReal > rt = new InUInt32Range();

    Print( "null passes" );
    rt.Check< IReal, IReal >( null, new Literal() );

    Print( "Less than min fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( Integer.From( UInt32.MinValue - 1m ), new Literal() );
    } );

    Print( "Min passes" );
    rt.Check( Integer.From( UInt32.MinValue ), new Literal() );

    Print( "In range passes" );
    rt.Check( Integer.From( 5m ), new Literal() );

    Print( "Max passes" );
    rt.Check( Integer.From( UInt32.MaxValue ), new Literal() );

    Print( "Greater than max fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( Integer.From( UInt32.MaxValue + 1m ), new Literal() );
    } );
}


[Test( "InInt16Range" )]
public static void
Test_InInt16Range()
{
    IRType< IReal > rt = new InInt16Range();

    Print( "null passes" );
    rt.Check< IReal, IReal >( null, new Literal() );

    Print( "Less than min fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( Integer.From( Int16.MinValue - 1m ), new Literal() );
    } );

    Print( "Min passes" );
    rt.Check( Integer.From( Int16.MinValue ), new Literal() );

    Print( "In range passes" );
    rt.Check( Integer.From( 5m ), new Literal() );

    Print( "Max passes" );
    rt.Check( Integer.From( Int16.MaxValue ), new Literal() );

    Print( "Greater than max fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( Integer.From( Int16.MaxValue + 1m ), new Literal() );
    } );
}


[Test( "InUInt16Range" )]
public static void
Test_InUInt16Range()
{
    IRType< IReal > rt = new InUInt16Range();

    Print( "null passes" );
    rt.Check< IReal, IReal >( null, new Literal() );

    Print( "Less than min fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( Integer.From( UInt16.MinValue - 1m ), new Literal() );
    } );

    Print( "Min passes" );
    rt.Check( Integer.From( UInt16.MinValue ), new Literal() );

    Print( "In range passes" );
    rt.Check( Integer.From( 5m ), new Literal() );

    Print( "Max passes" );
    rt.Check( Integer.From( UInt16.MaxValue ), new Literal() );

    Print( "Greater than max fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( Integer.From( UInt16.MaxValue + 1m ), new Literal() );
    } );
}


[Test( "InByteRange" )]
public static void
Test_InByteRange()
{
    IRType< IReal > rt = new InByteRange();

    Print( "null passes" );
    rt.Check< IReal, IReal >( null, new Literal() );

    Print( "Less than min fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( Integer.From( Byte.MinValue - 1m ), new Literal() );
    } );

    Print( "Min passes" );
    rt.Check( Integer.From( Byte.MinValue ), new Literal() );

    Print( "In range passes" );
    rt.Check( Integer.From( 5m ), new Literal() );

    Print( "Max passes" );
    rt.Check( Integer.From( Byte.MaxValue ), new Literal() );

    Print( "Greater than max fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( Integer.From( Byte.MaxValue + 1m ), new Literal() );
    } );
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
    t.Check< IReal, IReal >( null, new Literal() );

    Print( "Not fractional passes" );
    t.Check( Real.From( 5m ), new Literal() );

    Print( "Fractional fails" );
    Expect< RTypeException >( delegate() {
        t.Check( Real.From( 5.5m ), new Literal() );
    } );

    Print( "Negative not fractional passes" );
    t.Check( Real.From( -5m ), new Literal() );

    Print( "Negative fractional fails" );
    Expect< RTypeException >( delegate() {
        t.Check( Real.From( -5.5m ), new Literal() );
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
    t.Check< IReal, IReal >( null, new Literal() );

    Print( "Negative passes" );
    t.Check( Real.From( -5m ), new Literal() );

    Print( "Positive passes" );
    t.Check( Real.From( 5m ), new Literal() );

    Print( "Zero fails" );
    Expect< RTypeException >( delegate() {
        t.Check( Real.From( 0m ), new Literal() );
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
    t.Check< IReal, IReal>( null, new Literal() );

    Print( "Negative fails" );
    Expect< RTypeException >( delegate() {
        t.Check( Real.From( -5m ), new Literal() );
    } );

    Print( "Zero passes" );
    t.Check( Real.From( 0m ), new Literal() );

    Print( "Positive passes" );
    t.Check( Real.From( 5m ), new Literal() );
}




} // type
} // namespace

