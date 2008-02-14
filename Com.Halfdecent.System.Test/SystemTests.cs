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
using System.Globalization;
using System.Threading;
using Com.Halfdecent.Testing;
using Com.Halfdecent.System;
using Com.Halfdecent.Predicates;
using Com.Halfdecent.Globalization;


namespace
Com.Halfdecent.System.Test
{




/// Tests for <tt>Com.Halfdecent.System</tt>
public class
SystemTests
    : TestBase
{



[Test( "HDException" )]
public static void
Test_HDException()
{
    CultureInfo en = CultureInfo.GetCultureInfo( "en-US" );
    CultureInfo fr = CultureInfo.GetCultureInfo( "fr-FR" );
    CultureInfo current;

    Localized<string> msg = new InMemoryLocalized<string>( "message" );
    msg[fr] = "la message";

    Exception e;
    HDException de;

    Print( "HDException( string )" );
    de = new HDException( "message" );
    Print( "Check Message" );
    AssertEqual<string>( de.Message, "message" );
    Print( "Check Exception::Message" );
    e = de;
    AssertEqual( e.Message, "message" );

    Print( "HDException( Localized<string> )" );
    de = new HDException( msg );
    Print( "Check localized messages" );
    AssertEqual<string>( de.Message[en], "message" );
    AssertEqual<string>( de.Message[fr], "la message" );
    Print( "Check localized messages (via Exception::Message)" );
    e = de;
    current = Thread.CurrentThread.CurrentCulture;
    try {
        Thread.CurrentThread.CurrentCulture = en;
        AssertEqual( e.Message, "message" );
        Thread.CurrentThread.CurrentCulture = fr;
        AssertEqual( e.Message, "la message" );
    } finally {
        Thread.CurrentThread.CurrentCulture = current;
    }

    Print( "HDException( Localized<string>, Exception )" );
    Exception ie = new ArgumentException();
    de = new HDException( msg, ie );
    Print( "Check InnerException" );
    AssertEqual( de.InnerException, ie );

    if( e == null ) {}
}



static private
void
PrintPredicateStrings( IPredicate p )
{
    Print( "SayConforms(X): '{0}'",
        p.SayConforms( "X" ) );
    Print( "SayDoesNotConform(X): '{0}'",
        p.SayDoesNotConform( "X" ) );
    Print( "SayDemand(X): '{0}'",
        p.SayDemand( "X" ) );
}



[Test( "IsPresent" )]
public static void
Test_IsPresent()
{
    IsPresent ispresent = new IsPresent();
    object obj;

    PrintPredicateStrings( ispresent );

    Print( "true if not null" );
    obj = new object();
    AssertEqual(
        ispresent.Evaluate( obj ),
        true );

    Print( "false if null" );
    obj = null;
    AssertEqual(
        ispresent.Evaluate( obj ),
        false );
}



[Test( "IsA" )]
public static void
Test_IsA()
{
    IsA< int > isaint = new IsA< int >();
    object o = new object();
    int i = 5;

    PrintPredicateStrings( isaint );

    Print( "true if of the specified type" );
    AssertEqual(
        isaint.Evaluate( i ),
        true );

    Print( "false if not" );
    AssertEqual(
        isaint.Evaluate( o ),
        false );

    Print( "BugException if evaluate null" );
    bool threw = false;
    try {
        isaint.Evaluate( null );
    } catch( BugException ) {
        threw = true;
    }
    AssertEqual( threw, true );
}



[Test( "IsNotBlank" )]
public static void
Test_IsNotBlank()
{
    IsNotBlank isnotblank = new IsNotBlank();

    PrintPredicateStrings( isnotblank );

    Print( "true if not blank" );
    AssertEqual(
        isnotblank.Evaluate( "i'm not blank" ),
        true );

    Print( "false if blank" );
    AssertEqual(
        isnotblank.Evaluate( "" ),
        false );

    Print( "BugException if evaluate null" );
    bool threw = false;
    try {
        isnotblank.Evaluate( null );
    } catch( BugException ) {
        threw = true;
    }
    AssertEqual( threw, true );
}




} // type
} // namespace

