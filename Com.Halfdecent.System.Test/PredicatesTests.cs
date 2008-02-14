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
using Com.Halfdecent.Predicates;


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
PrintStrings( IPredicate p )
{
    Print( "SayConforms(X): '{0}'",
        p.SayConforms( "X" ) );
    Print( "SayDoesNotConform(X): '{0}'",
        p.SayDoesNotConform( "X" ) );
    Print( "SayDemand(X): '{0}'",
        p.SayDemand( "X" ) );
}



[Test( "IsNotNull" )]
public static void
Test_IsNotNull()
{
    IsNotNull isnotnull = new IsNotNull();
    object obj;

    PrintStrings( isnotnull );

    Print( "true if not null" );
    obj = new object();
    AssertEqual(
        isnotnull.Evaluate( obj ),
        true );

    Print( "false if null" );
    obj = null;
    AssertEqual(
        isnotnull.Evaluate( obj ),
        false );
}



[Test( "IsA" )]
public static void
Test_IsA()
{
    IsA< int > isaint = new IsA< int >();
    object o = new object();
    int i = 5;

    PrintStrings( isaint );

    Print( "true if of the specified type" );
    AssertEqual(
        isaint.Evaluate( i ),
        true );

    Print( "false if not" );
    AssertEqual(
        isaint.Evaluate( o ),
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

