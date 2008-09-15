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
    IRType1 gt = new GT< int >( val );
    IRType1 gte = new GTE< int >( val );
    IRType1 lt = new LT< int >( val );
    IRType1 lte = new LTE< int >( val );
    IRType1 equals = new Equals< int >( val );

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

    Print( "Equals: Less than fails" );
    Expect< RTypeException >( delegate() {
        equals.Check( ltval, new Local( "ltval" ) );
    } );
    Print( "Equals: Equal passes" );
    equals.Check( val, new Local( "val" ) );
    Print( "Equals: Greater than fails" );
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

    IRType1 rtinc = new InInterval< int >(
        new Interval< int >( from, true, to, true ) );
    IRType1 rtexc = new InInterval< int >(
        new Interval< int >( from, false, to, false ) );
    IRType1 rtfrominc = new InInterval< int >(
        new Interval< int >( from, true, to, false ) );
    IRType1 rttoinc = new InInterval< int >(
        new Interval< int >( from, false, to, true ) );

    IRType1 rt;
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



[Test( "InInt32Range" )]
public static void
Test_InInt32Range()
{
    IInteger lt         = Integer.From( Int32.MinValue - 1m );
    IInteger min        = Integer.From( Int32.MinValue );
    IInteger between    = Integer.From( 5m );
    IInteger max        = Integer.From( Int32.MaxValue );
    IInteger gt         = Integer.From( Int32.MaxValue + 1m );
    IValue _lt          = new Local( "lt" );
    IValue _min         = new Local( "min" );
    IValue _between     = new Local( "between" );
    IValue _max         = new Local( "max" );
    IValue _gt          = new Local( "gt" );

    IRType1 rt = new InInt32Range();

    Print( "null passes" );
    rt.Check( null, new Literal() );

    Print( "Less than min fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( lt, _lt );
    } );
    Print( "Min passes" );
    rt.Check( min, _min );
    Print( "In range passes" );
    rt.Check( between, _between );
    Print( "Max passes" );
    rt.Check( max, _max );
    Print( "Greater than max fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( gt, _gt );
    } );
}



[Test( "NotFractional" )]
public static void
Test_NotFractional()
{
    IRType1 rt = new NotFractional();

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




} // type
} // namespace

