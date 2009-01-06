// -----------------------------------------------------------------------------
// Copyright (c) 2008
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
//
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
    AssertEqual( i.DividedBy( i ).ToDecimal(), (d / d) );
}



[Test( "Interval" )]
public static void
Test_Interval()
{
    int smaller = 0;
    int from = 5;
    int between = 7;
    int to = 10;
    int bigger = 20;

    IInterval< int > inc = new Interval< int >( 5, 10 );
    IInterval< int > exc = new Interval< int >( 5, false, 10, false );
    IInterval< int > frominc = new Interval< int >( 5, true, 10, false );
    IInterval< int > toinc = new Interval< int >( 5, false, 10, true );

    Print( "Both Inclusive" );
    AssertEqual( inc.Contains( smaller ), false );
    AssertEqual( inc.Contains( from ), true );
    AssertEqual( inc.Contains( between ), true );
    AssertEqual( inc.Contains( to ), true );
    AssertEqual( inc.Contains( bigger ), false );

    Print( "Both Exclusive" );
    AssertEqual( exc.Contains( smaller ), false );
    AssertEqual( exc.Contains( from ), false );
    AssertEqual( exc.Contains( between ), true );
    AssertEqual( exc.Contains( to ), false );
    AssertEqual( exc.Contains( bigger ), false );

    Print( "From Inclusive" );
    AssertEqual( frominc.Contains( smaller ), false );
    AssertEqual( frominc.Contains( from ), true );
    AssertEqual( frominc.Contains( between ), true );
    AssertEqual( frominc.Contains( to ), false );
    AssertEqual( frominc.Contains( bigger ), false );

    Print( "To Inclusive" );
    AssertEqual( toinc.Contains( smaller ), false );
    AssertEqual( toinc.Contains( from ), false );
    AssertEqual( toinc.Contains( between ), true );
    AssertEqual( toinc.Contains( to ), true );
    AssertEqual( toinc.Contains( bigger ), false );

    Print( "ToString()" );
    Print( inc.ToString() );
    Print( exc.ToString() );
    Print( frominc.ToString() );
    Print( toinc.ToString() );
}



[Test( "Comparison RTypes" )]
public static void
Test_ComparisonRTypes()
{
    int val = 5;
    int ltval = 0;
    int gtval = 10;
    IRType< int > gt        = new GT < int, int >( val );
    IRType< int > gte       = new GTE< int, int >( val );
    IRType< int > lt        = new LT < int, int >( val );
    IRType< int > lte       = new LTE< int, int >( val );
    IRType< int > equals    = new EQ < int, int >( val );

    Print( "GT: Less than fails" );
    Expect< RTypeException >( delegate() {
        gt.Check( ltval, new Local( "ltval" ) );
    } );
    Print( "GT: Equal fails" );
    Expect< RTypeException >( delegate() {
        gt.Check( val, new Local( "val" ) );
    } );
    Print( "GT: Greater than passes" );
    gt.Check( gtval, new Local( "gtval" ) );

    Print( "GTE: Less than fails" );
    Expect< RTypeException >( delegate() {
        gte.Check( ltval, new Local( "ltval" ) );
    } );
    Print( "GTE: Equal passes" );
    gte.Check( val, new Local( "val" ) );
    Print( "GTE: Greater than passes" );
    gte.Check( gtval, new Local( "gtval" ) );

    Print( "LT: Less than passes" );
    lt.Check( ltval, new Local( "ltval" ) );
    Print( "LT: Equal fails" );
    Expect< RTypeException >( delegate() {
        lt.Check( val, new Local( "val" ) );
    } );
    Print( "LT: Greater than fails" );
    Expect< RTypeException >( delegate() {
        lt.Check( gtval, new Local( "gtval" ) );
    } );

    Print( "LTE: Less than passes" );
    lte.Check( ltval, new Local( "ltval" ) );
    Print( "LTE: Equal passes" );
    lte.Check( val, new Local( "val" ) );
    Print( "LTE: Greater than fails" );
    Expect< RTypeException >( delegate() {
        lte.Check( gtval, new Local( "gtval" ) );
    } );

    Print( "EQ: Less than fails" );
    Expect< RTypeException >( delegate() {
        equals.Check( ltval, new Local( "ltval" ) );
    } );
    Print( "EQ: Equal passes" );
    equals.Check( val, new Local( "val" ) );
    Print( "EQ: Greater than fails" );
    Expect< RTypeException >( delegate() {
        equals.Check( gtval, new Local( "gtval" ) );
    } );
}



[Test( "InInterval" )]
public static void
Test_InInterval()
{
    int lt          = 3;
    int from        = 5;
    int between     = 7;
    int to          = 10;
    int gt          = 12;

    IValue _lt      = new Local( "lt" );
    IValue _from    = new Local( "from" );
    IValue _between = new Local( "between" );
    IValue _to      = new Local( "to" );
    IValue _gt      = new Local( "gt" );

    IRType< int > rtinc =
        new InInterval< int, int >(
            new Interval< int >( from, true, to, true ) );
    IRType< int > rtexc =
        new InInterval< int, int >(
            new Interval< int >( from, false, to, false ) );
    IRType< int > rtfrominc =
        new InInterval< int, int >(
            new Interval< int >( from, true, to, false ) );
    IRType< int > rttoinc =
        new InInterval< int, int >(
            new Interval< int >( from, false, to, true ) );

    IRType< int > rt;
    string id = "...";

    Print( "Inclusive" );
    rt = rtinc;
    Print( "is     : \"" + rt.SayIs( id ) + "\"" );
    Print( "is not : \"" + rt.SayIsNot( id ) + "\"" );
    Print( "must be: \"" + rt.SayMustBe( id ) + "\"" );
    Expect< RTypeException >( delegate() {
        rt.Check( lt, _lt );
    } );
    rt.Check( from, _from );
    rt.Check( between, _between );
    rt.Check( to, _to );
    Expect< RTypeException >( delegate() {
        rt.Check( gt, _gt );
    } );

    Print( "Exclusive" );
    rt = rtexc;
    Print( "is     : \"" + rt.SayIs( id ) + "\"" );
    Print( "is not : \"" + rt.SayIsNot( id ) + "\"" );
    Print( "must be: \"" + rt.SayMustBe( id ) + "\"" );
    Expect< RTypeException >( delegate() {
        rt.Check( lt, _lt );
    } );
    Expect< RTypeException >( delegate() {
        rt.Check( from, _from );
    } );
    rt.Check( between, _between );
    Expect< RTypeException >( delegate() {
        rt.Check( to, _to );
    } );
    Expect< RTypeException >( delegate() {
        rt.Check( gt, _gt );
    } );

    Print( "From Inclusive" );
    rt = rtfrominc;
    Print( "is     : \"" + rt.SayIs( id ) + "\"" );
    Print( "is not : \"" + rt.SayIsNot( id ) + "\"" );
    Print( "must be: \"" + rt.SayMustBe( id ) + "\"" );
    Expect< RTypeException >( delegate() {
        rt.Check( lt, _lt );
    } );
    rt.Check( from, _from );
    rt.Check( between, _between );
    Expect< RTypeException >( delegate() {
        rt.Check( to, _to );
    } );
    Expect< RTypeException >( delegate() {
        rt.Check( gt, _gt );
    } );

    Print( "To Inclusive" );
    rt = rttoinc;
    Print( "is     : \"" + rt.SayIs( id ) + "\"" );
    Print( "is not : \"" + rt.SayIsNot( id ) + "\"" );
    Print( "must be: \"" + rt.SayMustBe( id ) + "\"" );
    Expect< RTypeException >( delegate() {
        rt.Check( lt, _lt );
    } );
    Expect< RTypeException >( delegate() {
        rt.Check( from, _from );
    } );
    rt.Check( between, _between );
    rt.Check( to, _to );
    Expect< RTypeException >( delegate() {
        rt.Check( gt, _gt );
    } );
}



[Test( "InInt64Range" )]
public static void
Test_InInt64Range()
{
    IRType< IReal > rt = new InInt64Range< IReal >();

    Print( "null passes" );
    rt.Check( null, new Literal() );

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
    IRType< IReal > rt = new InUInt64Range< IReal >();

    Print( "null passes" );
    rt.Check( null, new Literal() );

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
    IRType< IReal > rt = new InInt32Range< IReal >();

    Print( "null passes" );
    rt.Check( null, new Literal() );

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
    IRType< IReal > rt = new InUInt32Range< IReal >();

    Print( "null passes" );
    rt.Check( null, new Literal() );

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
    IRType< IReal > rt = new InInt16Range< IReal >();

    Print( "null passes" );
    rt.Check( null, new Literal() );

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
    IRType< IReal > rt = new InUInt16Range< IReal >();

    Print( "null passes" );
    rt.Check( null, new Literal() );

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
    IRType< IReal > rt = new InByteRange< IReal >();

    Print( "null passes" );
    rt.Check( null, new Literal() );

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
    IRType< IReal > rt = new NonFractional< IReal >();

    Print( "Null passes" );
    rt.Check( null, new Literal() );

    Print( "Not fractional passes" );
    rt.Check( Real.From( 5m ), new Literal() );

    Print( "Fractional fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( Real.From( 5.5m ), new Literal() );
    } );

    Print( "Negative not fractional passes" );
    rt.Check( Real.From( -5m ), new Literal() );

    Print( "Negative fractional fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( Real.From( -5.5m ), new Literal() );
    } );
}



[Test( "NonZero" )]
public static void
Test_NonZero()
{
    IRType< IReal > rt = new NonZero< IReal >();

    Print( "Null passes" );
    rt.Check( null, new Literal() );

    Print( "Negative passes" );
    rt.Check( Real.From( -5m ), new Literal() );

    Print( "Positive passes" );
    rt.Check( Real.From( 5m ), new Literal() );

    Print( "Zero fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( Real.From( 0m ), new Literal() );
    } );
}




} // type
} // namespace

