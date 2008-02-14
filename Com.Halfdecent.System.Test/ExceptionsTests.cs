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
using Com.Halfdecent.Globalization;
using Com.Halfdecent.Exceptions;


namespace
Com.Halfdecent.System.Test
{




/// Tests for <tt>Com.Halfdecent.Exceptions</tt>
///
public class
ExceptionsTests
    : TestBase
{




[Test( "Exception" )]
public static void
Test_Exception()
{
    CultureInfo en = CultureInfo.GetCultureInfo( "en-US" );
    CultureInfo fr = CultureInfo.GetCultureInfo( "fr-FR" );
    CultureInfo current;

    Localized< string > msg = new InMemoryLocalized< string >( "message" );
    msg[fr] = "la message";

    Exception e;
    HDException de;

    Print( "Exception( string )" );
    de = new HDException( "message" );
    Print( "Check Message" );
    AssertEqual< string >( de.Message, "message" );
    Print( "Check Exception::Message" );
    e = de;
    AssertEqual( e.Message, "message" );

    Print( "Exception( Localized< string > )" );
    de = new HDException( msg );
    Print( "Check localized messages" );
    AssertEqual< string >( de.Message[en], "message" );
    AssertEqual< string >( de.Message[fr], "la message" );
    Print( "Check localized messages (via System.Exception::Message)" );
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

    Print( "Exception( Localized< string >, Exception )" );
    Exception ie = new ArgumentException();
    de = new HDException( msg, ie );
    Print( "Check InnerException" );
    AssertEqual( de.InnerException, ie );

    if( e == null ) {}
}




} // type
} // namespace

