// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010
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


[Test( "NonZero" )]
public static void
Test_NonZero()
{
    RType t = new NonZero();
    RType u = new NonZero();

    Print( ".Equals() and GetHashCode()" );
    Assert( t.Equals( t ) );
    Assert( t.Equals( u ) );
    Assert( t.GetHashCode() == u.GetHashCode() );

    Print( "Null passes" );
    NonZero.Check( null );

    Print( "Negative passes" );
    NonZero.Check( Real.From( -5m ) );

    Print( "Positive passes" );
    NonZero.Check( Real.From( 5m ) );

    Print( "Zero fails" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.Equals( new NonZero() ) ),
        () => NonZero.Check( Real.From( 0m ) ) );

    Print( "CheckParameter()" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Parameter( "param" ) ),
            rt => rt.Equals( new NonZero() ) ),
        () => NonZero.CheckParameter( Real.From( 0m ), "param" ) );
}


[Test( "NonNegative" )]
public static void
Test_NonNegative()
{
    RType t = new NonNegative();
    RType u = new NonNegative();

    Print( ".Equals() and GetHashCode()" );
    Assert( t.Equals( t ) );
    Assert( t.Equals( u ) );
    Assert( t.GetHashCode() == u.GetHashCode() );

    Print( "Null passes" );
    NonNegative.Check( null );

    Print( "Negative fails" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.Equals( new NonNegative() ) ),
        () => NonNegative.Check( Real.From( -5m ) ) );

    Print( "Zero passes" );
    NonNegative.Check( Real.From( 0m ) );

    Print( "Positive passes" );
    NonNegative.Check( Real.From( 5m ) );
}


[Test( "NonFractional" )]
public static void
Test_NonFractional()
{
    RType t = new NonFractional();
    RType u = new NonFractional();

    Print( ".Equals() and GetHashCode()" );
    Assert( t.Equals( t ) );
    Assert( t.Equals( u ) );
    Assert( t.GetHashCode() == u.GetHashCode() );

    Print( "Null passes" );
    NonFractional.Check( null );

    Print( "Not fractional passes" );
    NonFractional.Check( Real.From( 5m ) );

    Print( "Fractional fails" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.Equals( new NonFractional() ) ),
        () => NonFractional.Check( Real.From( 5.5m ) ) );

    Print( "Negative not fractional passes" );
    NonFractional.Check( Real.From( -5m ) );

    Print( "Negative fractional fails" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.Equals( new NonFractional() ) ),
        () => NonFractional.Check( Real.From( -5.5m ) ) );

    Print( ".CheckParameter()" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Parameter( "param" ) ),
            rt => rt.Equals( new NonFractional() ) ),
        () => NonFractional.CheckParameter( Real.From( -5.5m ), "param" ) );
}


[Test( "InByteRange" )]
public static void
Test_InByteRange()
{
    Test_InRange(
        new InByteRange(),
        Real.From( System.Byte.MinValue ),
        Real.From( System.Byte.MaxValue ),
        false );
}
[Test( "InSByteRange" )]
public static void
Test_InSByteRange()
{
    Test_InRange(
        new InSByteRange(),
        Real.From( System.SByte.MinValue ),
        Real.From( System.SByte.MaxValue ),
        false );
}
[Test( "InInt16Range" )]
public static void
Test_InInt16Range()
{
    Test_InRange(
        new InInt16Range(),
        Real.From( System.Int16.MinValue ),
        Real.From( System.Int16.MaxValue ),
        false );
}
[Test( "InUInt16Range" )]
public static void
Test_InUInt16Range()
{
    Test_InRange(
        new InUInt16Range(),
        Real.From( System.UInt16.MinValue ),
        Real.From( System.UInt16.MaxValue ),
        false );
}
[Test( "InInt32Range" )]
public static void
Test_InInt32Range()
{
    Test_InRange(
        new InInt32Range(),
        Real.From( System.Int32.MinValue ),
        Real.From( System.Int32.MaxValue ),
        false );
}
[Test( "InUInt32Range" )]
public static void
Test_InUInt32Range()
{
    Test_InRange(
        new InUInt32Range(),
        Real.From( System.UInt32.MinValue ),
        Real.From( System.UInt32.MaxValue ),
        false );
}
[Test( "InInt64Range" )]
public static void
Test_InInt64Range()
{
    Test_InRange(
        new InInt64Range(),
        Real.From( System.Int64.MinValue ),
        Real.From( System.Int64.MaxValue ),
        false );
}
[Test( "InUInt64Range" )]
public static void
Test_InUInt64Range()
{
    Test_InRange(
        new InUInt64Range(),
        Real.From( System.UInt64.MinValue ),
        Real.From( System.UInt64.MaxValue ),
        false );
}
[Test( "InDecimalRange" )]
public static void
Test_InDecimalRange()
{
    Test_InRange(
        new InDecimalRange(),
        Real.From( System.Decimal.MinValue ),
        Real.From( System.Decimal.MaxValue ),
        true );
}

public static void
Test_InRange(
    RType< IReal >  t,
    IReal           min,
    IReal           max,
    bool            skipout
)
{
    Print( "null passes" );
    t.Check( null );
    Print( "Smaller fails" );
    if( !skipout )
        Expect(
            e => RTypeException.Match( e,
                (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
                rt => rt.Equals( t ) ),
            () => t.Check( min.Minus( Real.From( 1m ) ) ) );
    Print( "Min passes" );
    t.Check( min );
    Print( "In range passes" );
    t.Check( Real.From( 10 ) );
    Print( "Max passes" );
    t.Check( max );
    Print( "Bigger fails" );
    if( !skipout )
        Expect(
            e => RTypeException.Match( e,
                (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
                rt => rt.Equals( t ) ),
            () => t.Check( max.Plus( Real.From( 1m ) ) ) );
}


/*
[Test( "InUInt64Range" )]
public static void
Test_InUInt64Range()
{
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
    InUInt64Range.Require( null, new Literal() );
    Print( "Smaller fails" );
    Expect< RTypeException >( () =>
        InUInt64Range.Require( smaller, _smaller ) );
    Print( "Min passes" );
    InUInt64Range.Require( min, _min );
    Print( "In range passes" );
    InUInt64Range.Require( inrange, _inrange );
    Print( "Max passes" );
    InUInt64Range.Require( max, _max );
    Print( "Bigger fails" );
    Expect< RTypeException >( () =>
        InUInt64Range.Require( bigger, _bigger ) );
}


[Test( "InInt64Range" )]
public static void
Test_InInt64Range()
{
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
    InInt64Range.Require( null, new Literal() );
    Print( "Smaller fails" );
    Expect< RTypeException >( () =>
        InInt64Range.Require( smaller, _smaller ) );
    Print( "Min passes" );
    InInt64Range.Require( min, _min );
    Print( "In range passes" );
    InInt64Range.Require( inrange, _inrange );
    Print( "Max passes" );
    InInt64Range.Require( max, _max );
    Print( "Bigger fails" );
    Expect< RTypeException >( () =>
        InInt64Range.Require( bigger, _bigger ) );
}


[Test( "InUInt32Range" )]
public static void
Test_InUInt32Range()
{
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
    InUInt32Range.Require( null, new Literal() );
    Print( "Smaller fails" );
    Expect< RTypeException >( () =>
        InUInt32Range.Require( smaller, _smaller ) );
    Print( "Min passes" );
    InUInt32Range.Require( min, _min );
    Print( "In range passes" );
    InUInt32Range.Require( inrange, _inrange );
    Print( "Max passes" );
    InUInt32Range.Require( max, _max );
    Print( "Bigger fails" );
    Expect< RTypeException >( () =>
        InUInt32Range.Require( bigger, _bigger ) );
}


[Test( "InInt32Range" )]
public static void
Test_InInt32Range()
{
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
    InInt32Range.Require( null, new Literal() );
    Print( "Smaller fails" );
    Expect< RTypeException >( () =>
        InInt32Range.Require( smaller, _smaller ) );
    Print( "Min passes" );
    InInt32Range.Require( min, _min );
    Print( "In range passes" );
    InInt32Range.Require( inrange, _inrange );
    Print( "Max passes" );
    InInt32Range.Require( max, _max );
    Print( "Bigger fails" );
    Expect< RTypeException >( () =>
        InInt32Range.Require( bigger, _bigger ) );
}


[Test( "InUInt16Range" )]
public static void
Test_InUInt16Range()
{
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
    InUInt16Range.Require( null, new Literal() );
    Print( "Smaller fails" );
    Expect< RTypeException >( () =>
        InUInt16Range.Require( smaller, _smaller ) );
    Print( "Min passes" );
    InUInt16Range.Require( min, _min );
    Print( "In range passes" );
    InUInt16Range.Require( inrange, _inrange );
    Print( "Max passes" );
    InUInt16Range.Require( max, _max );
    Print( "Bigger fails" );
    Expect< RTypeException >( () =>
        InUInt16Range.Require( bigger, _bigger ) );
}


[Test( "InInt16Range" )]
public static void
Test_InInt16Range()
{
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
    InInt16Range.Require( null, new Literal() );
    Print( "Smaller fails" );
    Expect< RTypeException >( () =>
        InInt16Range.Require( smaller, _smaller ) );
    Print( "Min passes" );
    InInt16Range.Require( min, _min );
    Print( "In range passes" );
    InInt16Range.Require( inrange, _inrange );
    Print( "Max passes" );
    InInt16Range.Require( max, _max );
    Print( "Bigger fails" );
    Expect< RTypeException >( () =>
        InInt16Range.Require( bigger, _bigger ) );
}


[Test( "InSByteRange" )]
public static void
Test_InSByteRange()
{
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
    InSByteRange.Require( null, new Literal() );
    Print( "Smaller fails" );
    Expect< RTypeException >( () =>
        InSByteRange.Require( smaller, _smaller ) );
    Print( "Min passes" );
    InSByteRange.Require( min, _min );
    Print( "In range passes" );
    InSByteRange.Require( inrange, _inrange );
    Print( "Max passes" );
    InSByteRange.Require( max, _max );
    Print( "Bigger fails" );
    Expect< RTypeException >( () =>
        InSByteRange.Require( bigger, _bigger ) );
}


[Test( "InDecimalRange" )]
public static void
Test_InDecimalRange()
{
    IReal min = Real.From( System.Decimal.MinValue );
    IReal inrange = Real.From( 10 );
    IReal max = Real.From( System.Decimal.MaxValue );
    Value _min = new Local( "min" );
    Value _inrange = new Local( "inrange" );
    Value _max = new Local( "max" );
    Print( "null passes" );
    InDecimalRange.Require( null, new Literal() );
    Print( "Min passes" );
    InDecimalRange.Require( min, _min );
    Print( "In range passes" );
    InDecimalRange.Require( inrange, _inrange );
    Print( "Max passes" );
    InDecimalRange.Require( max, _max );
}




*/




} // type
} // namespace

