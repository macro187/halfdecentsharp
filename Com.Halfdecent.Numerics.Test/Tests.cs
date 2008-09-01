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

using Com.Halfdecent.Testing;
using Com.Halfdecent.Numerics;

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



/*
[Test( "IsNotZero" )]
public static void
Test_IsNotZero()
{
    IsNotZero< Real > p = new IsNotZero< Real >();

    Print( ".5 passes" );
    AssertEqual( p.Evaluate( Real.From( 0.5m ) ), true );

    Print( "0 fails" );
    AssertEqual( p.Evaluate( Real.From( 0 ) ), false );

    Print( "-.5 passes" );
    AssertEqual( p.Evaluate( Real.From( -0.5m ) ), true );
}



[Test( "IsNotFractional" )]
public static void
Test_IsNotFractional()
{
    IsNotFractional< Real > p = new IsNotFractional< Real >();

    Print( "0 passes" );
    AssertEqual( p.Evaluate( Real.From( 0 ) ), true );

    Print( "1 passes" );
    AssertEqual( p.Evaluate( Real.From( 1 ) ), true );

    Print( "-1 passes" );
    AssertEqual( p.Evaluate( Real.From( -1 ) ), true );

    Print( ".5 fails" );
    AssertEqual( p.Evaluate( Real.From( 0.5m ) ), false );

    Print( "-.5 fails" );
    AssertEqual( p.Evaluate( Real.From( -0.5m ) ), false );
}



[Test( "IsNotNegative" )]
public static void
Test_IsNotNegative()
{
    IsNotNegative< Real > p = new IsNotNegative< Real >();

    Print( "Positive passes" );
    AssertEqual( p.Evaluate( Real.From( 1 ) ), true );

    Print( "Zero passes" );
    AssertEqual( p.Evaluate( Real.From( 0 ) ), true );

    Print( "Negative fails" );
    AssertEqual( p.Evaluate( Real.From( -1 ) ), false );
}



[Test( "IsLT" )]
public static void
Test_IsLT()
{
    IsLT< Real > p = new IsLT< Real >( Real.From( 10 ) );

    // TODO "Evaluate( null ) throws BugException

    Print( "Less than passes" );
    AssertEqual( p.Evaluate( Real.From( 9 ) ), true );

    Print( "Equal fails" );
    AssertEqual( p.Evaluate( Real.From( 10 ) ), false );

    Print( "Greater than fails" );
    AssertEqual( p.Evaluate( Real.From( 11 ) ), false );
}



[Test( "IsLTE" )]
public static void
Test_IsLTE()
{
    IsLTE< Real > p = new IsLTE< Real >( Real.From( 10 ) );

    // TODO "Evaluate( null ) throws BugException

    Print( "Less than passes" );
    AssertEqual( p.Evaluate( Real.From( 9 ) ), true );

    Print( "Equal passes" );
    AssertEqual( p.Evaluate( Real.From( 10 ) ), true );

    Print( "Greater than fails" );
    AssertEqual( p.Evaluate( Real.From( 11 ) ), false );
}



[Test( "IsGT" )]
public static void
Test_IsGT()
{
    IsGT< Real > p = new IsGT< Real >( Real.From( 10 ) );

    // TODO "Evaluate( null ) throws BugException

    Print( "Less than fails" );
    AssertEqual( p.Evaluate( Real.From( 9 ) ), false );

    Print( "Equal fails" );
    AssertEqual( p.Evaluate( Real.From( 10 ) ), false );

    Print( "Greater than passes" );
    AssertEqual( p.Evaluate( Real.From( 11 ) ), true );
}



[Test( "IsGTE" )]
public static void
Test_IsGTE()
{
    IsGTE< Real > p = new IsGTE< Real >( Real.From( 10 ) );

    // TODO "Evaluate( null ) throws BugException

    Print( "Less than fails" );
    AssertEqual( p.Evaluate( Real.From( 9 ) ), false );

    Print( "Equal passes" );
    AssertEqual( p.Evaluate( Real.From( 10 ) ), true );

    Print( "Greater than passes" );
    AssertEqual( p.Evaluate( Real.From( 11 ) ), true );
}
*/



} // type
} // namespace

