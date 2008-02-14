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
using Com.Halfdecent.Numerics;

/*
using System.Globalization;
using System.Threading;
using Com.Halfdecent.System;
using Com.Halfdecent.Predicates;
using Com.Halfdecent.Globalization;
*/


namespace
Com.Halfdecent.System.Test
{




/// Tests for <tt>Com.Halfdecent.Numerics</tt>
public class
NumericsTests
    : TestBase
{



[Test( "Real" )]
public static void
Test_Real()
{
    Real r;
    Real r1;
    Real r2;
    Real r3;
    Real r4;

    Print( "From( System.Decimal ) and ToDecimal()" );
    r = Real.From( 10 );
    AssertEqual< decimal >(
        r.ToDecimal(),
        10 );
    Print( "From( System.Decimal ) and ToDecimal()" );
    r = Real.From( 1.14m );
    AssertEqual< decimal >(
        r.ToDecimal(),
        1.14m );

    Print( "Equals( System.Object )" );
    r = Real.From( 10 );
    r1 = Real.From( 10 );
    r2 = Real.From( 20 );
    AssertEqual(
        r.Equals( (object)r1 ),
        true );
    AssertEqual(
        r.Equals( (object)r2 ),
        false );
    AssertEqual(
        r.Equals( new object() ),
        false );

    Print( "ToString() (doesn't actually assert anything)" );
    r1 = Real.From( 10 );
    r2 = Real.From( 1.141m );
    Print( r1.ToString() );
    Print( r2.ToString() );

    Print( "Equals( Real )" );
    r = Real.From( 10 );
    r1 = Real.From( 10 );
    r2 = Real.From( 20 );
    AssertEqual(
        r.Equals( r1 ),
        true );
    AssertEqual(
        r.Equals( r2 ),
        false );

    Print( "CompareTo()" );
    r = Real.From( 10 );
    r1 = Real.From( 5 );
    r2 = Real.From( 10 );
    r3 = Real.From( 20 );
    Assert( r.CompareTo( r1 ) > 0 );
    Assert( r.CompareTo( r2 ) == 0 );
    Assert( r.CompareTo( r3 ) < 0 );

    r1 = Real.From( 10 );
    r2 = Real.From( 5 );
    r3 = Real.From( 10 );
    r4 = Real.From( 20 );

    Print( "GT()" );
    AssertEqual( r1.GT( r2 ), true );
    AssertEqual( r1.GT( r3 ), false );
    AssertEqual( r1.GT( r4 ), false );
    Print( "GTE()" );
    AssertEqual( r1.GTE( r2 ), true );
    AssertEqual( r1.GTE( r3 ), true );
    AssertEqual( r1.GTE( r4 ), false );
    Print( "LT()" );
    AssertEqual( r1.LT( r2 ), false );
    AssertEqual( r1.LT( r3 ), false );
    AssertEqual( r1.LT( r4 ), true );
    Print( "LTE()" );
    AssertEqual( r1.LTE( r2 ), false );
    AssertEqual( r1.LTE( r3 ), true );
    AssertEqual( r1.LTE( r4 ), true );
    Print( "Plus()" );
    r = r1.Plus( r2 );
    Assert( r.Equals( Real.From( 15 ) ) );
    Print( "Minus()" );
    r = r1.Minus( r2 );
    Assert( r.Equals( Real.From( 5 ) ) );
    Print( "Times()" );
    r = r1.Times( r2 );
    Assert( r.Equals( Real.From( 50 ) ) );
    Print( "DividedBy()" );
    r = r1.DividedBy( r2 );
    Assert( r.Equals( Real.From( 2 ) ) );
    Print( "RemainderWhenDividedBy()" );
    r = Real.From( 11 ).RemainderWhenDividedBy( Real.From( 5 ) );
    Assert( r.Equals( Real.From( 1 ) ) );
    Print( "Truncate()" );
    r = Real.From( 1.141m );
    Assert( r.Truncate().Equals( Real.From( 1 ) ) );
    r = Real.From( -1.141m );
    Assert( r.Truncate().Equals( Real.From( -1 ) ) );
    Print( "Real > Real" );
    AssertEqual( r1 > r2, true );
    AssertEqual( r1 > r3, false );
    AssertEqual( r1 > r4, false );
    Print( "Real >= Real" );
    AssertEqual( r1 >= r2, true );
    AssertEqual( r1 >= r3, true );
    AssertEqual( r1 >= r4, false );
    Print( "Real < Real" );
    AssertEqual( r1 < r2, false );
    AssertEqual( r1 < r3, false );
    AssertEqual( r1 < r4, true );
    Print( "Real <= Real" );
    AssertEqual( r1 <= r2, false );
    AssertEqual( r1 <= r3, true );
    AssertEqual( r1 <= r4, true );
    Print( "Real + Real" );
    r = r1 + r2;
    Assert( r.Equals( Real.From( 15 ) ) );
    Print( "Real - Real" );
    r = r1 - r2;
    Assert( r.Equals( Real.From( 5 ) ) );
    Print( "Real * Real" );
    r = r1 * r2;
    Assert( r.Equals( Real.From( 50 ) ) );
    Print( "Real / Real" );
    r = r1 / r2;
    Assert( r.Equals( Real.From( 2 ) ) );
    Print( "Real++" );
    r = r1;
    r++;
    Assert( r.Equals( Real.From( 11 ) ) );
    Print( "Real--" );
    r = r1;
    r--;
    Assert( r.Equals( Real.From( 9 ) ) );
    Print( "+Real" );
    r = +r1;
    Assert( r.Equals( Real.From( 10 ) ) );
    Print( "-Real" );
    r = -r1;
    Assert( r.Equals( Real.From( -10 ) ) );
}



[Test( "Integer" )]
public static void
Test_Integer()
{
    Integer i;
    bool threw;

    Print( "From( Real ) and ToReal()" );
    i = Integer.From( Real.From( 10 ) );
    AssertEqual(
        i.ToReal().Equals( Real.From( 10 ) ),
        true );

    Print( "From( fractional Real ) throws ValueException" );
    threw = false;
    try {
        i = Integer.From( Real.From( 1.14m ) );
    } catch( ValueException ) {
        threw = true;
    }
    AssertEqual( threw, true );

    Print( "From( System.Decimal ) and ToDecimal()" );
    i = Integer.From( 10m );
    AssertEqual< decimal >(
        i.ToDecimal(),
        10m );

    Print( "From( fractional Decimal ) throws ValueException" );
    threw = false;
    try {
        i = Integer.From( 1.14m );
    } catch( ValueException ) {
        threw = true;
    }
    AssertEqual( threw, true );

    Print( "Equals( System.Object )" );
    i = Integer.From( 10 );
    AssertEqual(
        i.Equals( Integer.From( 10 ) ),
        true );
    AssertEqual(
        i.Equals( Integer.From( 20 ) ),
        false );
    AssertEqual(
        i.Equals( new object() ),
        false );

    Print( "ToString() (doesn't actually assert anything)" );
    Print( Integer.From( 10 ).ToString() );
    Print( Integer.From( -100 ).ToString() );

    Print( "Equals( Integer )" );
    AssertEqual(
        Integer.From( 10 ).Equals( Integer.From( 10 ) ),
        true );
    AssertEqual(
        Integer.From( 10 ).Equals( Integer.From( -100 ) ),
        false );

    Print( "CompareTo()" );
    Assert( Integer.From( 10 ).CompareTo( Integer.From( 5 ) ) > 0 );
    Assert( Integer.From( 10 ).CompareTo( Integer.From( 10 ) ) == 0 );
    Assert( Integer.From( 10 ).CompareTo( Integer.From( 20 ) ) < 0 );


    Print( "GT()" );
    AssertEqual( Integer.From( 10 ).GT( Integer.From( 5 ) ), true );
    AssertEqual( Integer.From( 10 ).GT( Integer.From( 10 ) ), false );
    AssertEqual( Integer.From( 10 ).GT( Integer.From( 20 ) ), false );

    Print( "GTE()" );
    AssertEqual( Integer.From( 10 ).GTE( Integer.From( 5 ) ), true );
    AssertEqual( Integer.From( 10 ).GTE( Integer.From( 10 ) ), true );
    AssertEqual( Integer.From( 10 ).GTE( Integer.From( 20 ) ), false );

    Print( "LT()" );
    AssertEqual( Integer.From( 10 ).LT( Integer.From( 5 ) ), false );
    AssertEqual( Integer.From( 10 ).LT( Integer.From( 10 ) ), false );
    AssertEqual( Integer.From( 10 ).LT( Integer.From( 20 ) ), true );

    Print( "LTE()" );
    AssertEqual( Integer.From( 10 ).LTE( Integer.From( 5 ) ), false );
    AssertEqual( Integer.From( 10 ).LTE( Integer.From( 10 ) ), true );
    AssertEqual( Integer.From( 10 ).LTE( Integer.From( 20 ) ), true );

    Print( "Plus()" );
    Assert( Integer.From( 10 ).Plus(
        Integer.From( 5 ) ).Equals(
        Integer.From( 15 ) ) );

    Print( "Minus()" );
    Assert( Integer.From( 10 ).Minus(
        Integer.From( 5 ) ).Equals(
        Integer.From( 5 ) ) );

    Print( "Times()" );
    Assert( Integer.From( 10 ).Times(
        Integer.From( 5 ) ).Equals(
        Integer.From( 50 ) ) );

    Print( "DividedBy()" );
    Assert( Integer.From( 25 ).DividedBy(
        Integer.From( 10 ) ).Equals(
        Real.From( 2.5m ) ) );

    Print( "RemainderWhenDividedBy()" );
    Assert( Integer.From( 25 ).RemainderWhenDividedBy(
        Integer.From( 10 ) ).Equals(
        Integer.From( 5 ) ) );

    Print( "Truncate()" );
    Assert( Integer.From( 5 ).Truncate().Equals( Integer.From( 5 ) ) );

    Print( "Integer == Integer" );
    AssertEqual(
        Integer.From( 5 ) == Integer.From( 5 ),
        true );
    AssertEqual(
        Integer.From( 5 ) == Integer.From( 10 ),
        false );

    Print( "Integer != Integer" );
    AssertEqual(
        Integer.From( 5 ) != Integer.From( 5 ),
        false );
    AssertEqual(
        Integer.From( 5 ) != Integer.From( 10 ),
        true );

    Print( "Integer > Integer" );
    AssertEqual(
        Integer.From( 10 ) > Integer.From( 5 ),
        true );
    AssertEqual(
        Integer.From( 10 ) > Integer.From( 10 ),
        false );
    AssertEqual(
        Integer.From( 10 ) > Integer.From( 20 ),
        false );

    Print( "Integer >= Integer" );
    AssertEqual(
        Integer.From( 10 ) >= Integer.From( 5 ),
        true );
    AssertEqual(
        Integer.From( 10 ) >= Integer.From( 10 ),
        true );
    AssertEqual(
        Integer.From( 10 ) >= Integer.From( 20 ),
        false );

    Print( "Integer < Integer" );
    AssertEqual(
        Integer.From( 10 ) < Integer.From( 5 ),
        false );
    AssertEqual(
        Integer.From( 10 ) < Integer.From( 10 ),
        false );
    AssertEqual(
        Integer.From( 10 ) < Integer.From( 20 ),
        true );

    Print( "Integer <= Integer" );
    AssertEqual(
        Integer.From( 10 ) <= Integer.From( 5 ),
        false );
    AssertEqual(
        Integer.From( 10 ) <= Integer.From( 10 ),
        true );
    AssertEqual(
        Integer.From( 10 ) <= Integer.From( 20 ),
        true );

    Print( "Integer + Integer" );
    Assert(
        ( Integer.From( 10 ) + Integer.From( 5 ) ).Equals(
        Integer.From( 15 ) ) );

    Print( "Integer - Integer" );
    Assert(
        ( Integer.From( 10 ) - Integer.From( 5 ) ).Equals(
        Integer.From( 5 ) ) );

    Print( "Integer * Integer" );
    Assert(
        ( Integer.From( 10 ) * Integer.From( 5 ) ).Equals(
        Integer.From( 50 ) ) );

    Print( "Integer / Integer" );
    Assert(
        ( Integer.From( 25 ) / Integer.From( 10 ) ).Equals(
        Real.From( 2.5m ) ) );

    Print( "Integer % Integer" );
    Assert(
        ( Integer.From( 25 ) % Integer.From( 10 ) ).Equals(
        Integer.From( 5 ) ) );

    Print( "Integer++" );
    i = Integer.From( 5 );
    i++;
    Assert( i.Equals( Integer.From( 6 ) ) );

    Print( "Integer--" );
    i = Integer.From( 5 );
    i--;
    Assert( i.Equals( Integer.From( 4 ) ) );

    Print( "+Integer" );
    i = Integer.From( 5 );
    Assert( (+i).Equals( Integer.From( 5 ) ) );

    Print( "-Integer" );
    i = Integer.From( 5 );
    Assert( (-i).Equals( Integer.From( -5 ) ) );

    Print( "Explicit Real -> Integer" );
    Assert( ( (Integer)(Real.From( 10 )) ).Equals( Integer.From( 10 ) ) );

    Print( "Explicit fractional Real -> Integer throws ValueException" );
    threw = false;
    try {
        i = (Integer)(Real.From( 1.14m ));
    } catch( ValueException ) {
        threw = true;
    }
    AssertEqual( threw, true );

    Print( "Implicit Integer -> Real" );
    Real r = Integer.From( 10 );
    Assert( r.Equals( Real.From( 10 ) ) );
}



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




} // type
} // namespace

