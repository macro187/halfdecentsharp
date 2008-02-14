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

    Localized< string > msg = new InMemoryLocalized< string >( "message" );
    msg[fr] = "la message";

    Exception e;
    HDException hde;

    Print( "HDException( string )" );
    hde = new HDException( "message" );
    Print( "Check Message" );
    AssertEqual< string >( hde.Message, "message" );
    Print( "Check Exception::Message" );
    e = hde;
    AssertEqual( e.Message, "message" );

    Print( "HDException( Localized< string > )" );
    hde = new HDException( msg );
    Print( "Check localized messages" );
    AssertEqual< string >( hde.Message[en], "message" );
    AssertEqual< string >( hde.Message[fr], "la message" );
    Print( "Check localized messages (via Exception::Message)" );
    e = hde;
    current = Thread.CurrentThread.CurrentCulture;
    try {
        Thread.CurrentThread.CurrentCulture = en;
        AssertEqual( e.Message, "message" );
        Thread.CurrentThread.CurrentCulture = fr;
        AssertEqual( e.Message, "la message" );
    } finally {
        Thread.CurrentThread.CurrentCulture = current;
    }

    Print( "HDException( Localized< string >, Exception )" );
    e = new ArgumentException();
    hde = new HDException( msg, e );
    Print( "Check InnerException" );
    AssertEqual( hde.InnerException, e );

    //if( e == null ) {}
}



static private
void
PrintPredicateStrings( IPredicate p )
{
    Print( "SayConforms(X): '{0}'",
        p.SayConforms( "X" ) );
    Print( "SayDoesNotConform(X): '{0}'",
        p.SayDoesNotConform( "X" ) );
    Print( "SayRequirement(X): '{0}'",
        p.SayRequirement( "X" ) );
}



static public
bool
Passes< T >( IPredicate< T > predicate, T value  )
{
    bool result = true;
    try {
        predicate.Require( value );
    } catch( ValueException ) {
        result = false;
    }
    return result;
}



[Test( "IsPresent" )]
public static void
Test_IsPresent()
{
    IsPresent ispresent = new IsPresent();
    object obj;

    PrintPredicateStrings( ispresent );

    Print( "passes if not null" );
    obj = new object();
    AssertEqual( Passes( ispresent, obj ) , true );

    Print( "fails if null" );
    obj = null;
    AssertEqual( Passes( ispresent, obj ) , false );
}



[Test( "IsA" )]
public static void
Test_IsA()
{
    IsA< int > isaint = new IsA< int >();
    object o = new object();
    int i = 5;

    PrintPredicateStrings( isaint );

    Print( "passes if of the specified type" );
    AssertEqual( Passes< object >( isaint, i ) , true );

    Print( "fails if not" );
    AssertEqual( Passes( isaint, o ) , false );

    Print( "BugException if term is null" );
    bool threw = false;
    try {
        isaint.Require( null );
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

    Print( "passes if not blank" );
    AssertEqual( Passes( isnotblank, "i'm not blank" ) , true );

    Print( "fails if blank" );
    AssertEqual( Passes( isnotblank, "" ) , false );

    Print( "BugException if term is null" );
    bool threw = false;
    try {
        isnotblank.Require( null );
    } catch( BugException ) {
        threw = true;
    }
    AssertEqual( threw, true );
}




} // type
} // namespace

