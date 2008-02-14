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
    decimal d;

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

    Print( "explicit operator Real->Decimal" );
    r = Real.From( 10 );
    d = (decimal)r;
    AssertEqual( d, 10m );

    Print( "implicit operator Decimal->Real" );
    d = 10;
    r = d;
    Assert( r.Equals( Real.From( 10 ) ) );
}




} // type
} // namespace

