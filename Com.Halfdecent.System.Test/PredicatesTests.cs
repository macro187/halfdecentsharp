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
using SCG = System.Collections.Generic;
using Com.Halfdecent.Testing;
/*
using Com.Halfdecent.System;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Collections;
*/
using P = Com.Halfdecent.Predicates;


namespace
Com.Halfdecent.System.Test
{




/// Tests for <tt>Com.Halfdecent.Collections</tt>
public class
PredicatesTests
    : TestBase
{



static private
void
PrintStrings( P.Predicate p )
{
    Print( "TrueDescription: '{0}'", p.TrueDescription );
    Print( "FalseDescription: '{0}'", p.FalseDescription );
    Print( "Demand: '{0}'", p.Demand );
}



[Test( "NotNullPredicate" )]
public static void
Test_NotNullPredicate()
{
    P.NotNullPredicate p = new P.NotNullPredicate();
    object obj;

    PrintStrings( p );

    Print( "true if not null" );
    obj = new object();
    AssertEqual(
        p.Evaluate( obj ),
        true );

    Print( "false if null" );
    obj = null;
    AssertEqual(
        p.Evaluate( obj ),
        false );
}



[Test( "IsAPredicate" )]
public static void
Test_IsAPredicate()
{
    P.IsAPredicate< int > p = new P.IsAPredicate< int >();
    object o = new object();
    int i = 5;

    PrintStrings( p );

    Print( "true if of the specified type" );
    AssertEqual(
        p.Evaluate( i ),
        true );

    Print( "false if not" );
    AssertEqual(
        p.Evaluate( o ),
        false );
}



/*
[Test( "IntGTEPredicate" )]
public static void
Test_IntGTEPredicate()
{
    P.IntGTEPredicate gte10 = new P.IntGTEPredicate( 10 );
    int gt = 100;
    int eq = 10;
    int lt = 9;

    Print( "true if greater-than" );
    AssertEqual(
        gte10.Evaluate( gt ),
        true );

    Print( "true if equal" );
    AssertEqual(
        gte10.Evaluate( eq ),
        true );

    Print( "false if less-than" );
    AssertEqual(
        gte10.Evaluate( lt ),
        false );
}
*/




} // type
} // namespace

