// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010, 2012
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


using Halfdecent;
using Halfdecent.Meta;
using Halfdecent.RTypes;
using Halfdecent.Numerics;
using Halfdecent.Testing;


namespace
Halfdecent.Numerics.Test
{


// =============================================================================
/// Test program for <tt>Halfdecent.Numerics</tt>
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
    IReal r = Real.Create( d );
    IReal l = Real.Create( (d - 2m) );
    IReal g = Real.Create( (d + 2m) );

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
    Assert( r.Plus( Real.Create( 2m ) ).GetValue() == d + 2m );
    Assert( r.Plus( Real.Create( -2m ) ).GetValue() == d - 2m );

    Print( "Minus()" );
    Assert( r.Minus( Real.Create( 2m ) ).GetValue() == d - 2m );
    Assert( r.Minus( Real.Create( -2m ) ).GetValue() == d - -2m );

    Print( "Times()" );
    Assert( r.Times( Real.Create( 2m ) ).GetValue() == d * 2m );
    Assert( r.Times( Real.Create( -2m ) ).GetValue() == d * -2m );

    Print( "DividedBy()" );
    Assert( r.DividedBy( Real.Create( 2m ) ).GetValue() == d / 2m );
    Assert( r.DividedBy( Real.Create( -2m ) ).GetValue() == d / -2m );

    Print( "Truncate()" );
    Assert( r.Truncate().GetValue() == decimal.Truncate( d ) );
}


[Test( "DecimalInteger" )]
public static void
Test_DecimalInteger()
{
    decimal d = 5;
    IInteger i = Real.Create( d ).Truncate();
    IInteger l = Real.Create( d - 2m ).Truncate();
    IInteger g = Real.Create( d + 2m ).Truncate();

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
    NonZero.Check( Real.Create( -5m ) );

    Print( "Positive passes" );
    NonZero.Check( Real.Create( 5m ) );

    Print( "Zero fails" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.Equals( new NonZero() ) ),
        () => NonZero.Check( Real.Create( 0m ) ) );

    Print( "CheckParameter()" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Parameter( "param" ) ),
            rt => rt.Equals( new NonZero() ) ),
        () => NonZero.CheckParameter( Real.Create( 0m ), "param" ) );
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
        () => NonNegative.Check( Real.Create( -5m ) ) );

    Print( "Zero passes" );
    NonNegative.Check( Real.Create( 0m ) );

    Print( "Positive passes" );
    NonNegative.Check( Real.Create( 5m ) );
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
    NonFractional.Check( Real.Create( 5m ) );

    Print( "Fractional fails" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.Equals( new NonFractional() ) ),
        () => NonFractional.Check( Real.Create( 5.5m ) ) );

    Print( "Negative not fractional passes" );
    NonFractional.Check( Real.Create( -5m ) );

    Print( "Negative fractional fails" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.Equals( new NonFractional() ) ),
        () => NonFractional.Check( Real.Create( -5.5m ) ) );

    Print( ".CheckParameter()" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Parameter( "param" ) ),
            rt => rt.Equals( new NonFractional() ) ),
        () => NonFractional.CheckParameter( Real.Create( -5.5m ), "param" ) );
}


[Test( "InByteRange" )]
public static void
Test_InByteRange()
{
    Test_InRange(
        new InByteRange(),
        Real.Create( System.Byte.MinValue ),
        Real.Create( System.Byte.MaxValue ),
        false );
}


[Test( "InSByteRange" )]
public static void
Test_InSByteRange()
{
    Test_InRange(
        new InSByteRange(),
        Real.Create( System.SByte.MinValue ),
        Real.Create( System.SByte.MaxValue ),
        false );
}


[Test( "InInt16Range" )]
public static void
Test_InInt16Range()
{
    Test_InRange(
        new InInt16Range(),
        Real.Create( System.Int16.MinValue ),
        Real.Create( System.Int16.MaxValue ),
        false );
}


[Test( "InUInt16Range" )]
public static void
Test_InUInt16Range()
{
    Test_InRange(
        new InUInt16Range(),
        Real.Create( System.UInt16.MinValue ),
        Real.Create( System.UInt16.MaxValue ),
        false );
}


[Test( "InInt32Range" )]
public static void
Test_InInt32Range()
{
    Test_InRange(
        new InInt32Range(),
        Real.Create( System.Int32.MinValue ),
        Real.Create( System.Int32.MaxValue ),
        false );
}


[Test( "InUInt32Range" )]
public static void
Test_InUInt32Range()
{
    Test_InRange(
        new InUInt32Range(),
        Real.Create( System.UInt32.MinValue ),
        Real.Create( System.UInt32.MaxValue ),
        false );
}


[Test( "InInt64Range" )]
public static void
Test_InInt64Range()
{
    Test_InRange(
        new InInt64Range(),
        Real.Create( System.Int64.MinValue ),
        Real.Create( System.Int64.MaxValue ),
        false );
}


[Test( "InUInt64Range" )]
public static void
Test_InUInt64Range()
{
    Test_InRange(
        new InUInt64Range(),
        Real.Create( System.UInt64.MinValue ),
        Real.Create( System.UInt64.MaxValue ),
        false );
}


[Test( "InDecimalRange" )]
public static void
Test_InDecimalRange()
{
    Test_InRange(
        new InDecimalRange(),
        Real.Create( System.Decimal.MinValue ),
        Real.Create( System.Decimal.MaxValue ),
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
            () => t.Check( min.Minus( Real.Create( 1m ) ) ) );
    Print( "Min passes" );
    t.Check( min );
    Print( "In range passes" );
    t.Check( Real.Create( 10 ) );
    Print( "Max passes" );
    t.Check( max );
    Print( "Bigger fails" );
    if( !skipout )
        Expect(
            e => RTypeException.Match( e,
                (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
                rt => rt.Equals( t ) ),
            () => t.Check( max.Plus( Real.Create( 1m ) ) ) );
}




} // type
} // namespace

