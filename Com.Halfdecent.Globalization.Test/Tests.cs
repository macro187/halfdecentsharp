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



namespace
Com.Halfdecent.Globalization.Test
{



/// <summary>
/// Tests for <c>Com.Halfdecent.Globalization</c>
/// </summary>
public class
Tests
    : TestBase
{




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// <summary>
/// Test program entry point
/// </summary>
public static int
Main()
{
    return TestProgram.RunTests();
}




// -----------------------------------------------------------------------------
// Tests
// -----------------------------------------------------------------------------

[Test( "Localized<T> creation" )]
public static void
Test_Creation()
{
    Print( "Create InMemoryLocalized<string>" );
    Localized<string> ls = new InMemoryLocalized<string>( "Hello" );

    Print( "Created object is not null" );
    Assert( ls != null );
}



[Test( "Localized<T> implicit conversions" )]
public static void
Test_Conversions()
{
    Localized<string> ls = new InMemoryLocalized<string>( "Hello" );

    Print( "Localized<string> can be passed to a function expecting a string" );
    AssertEqual( WantString( ls ), "Hello" );

    Print( "A string can be passed to a function expecting a Localized<string>" );
    AssertEqual( WantLocalized( "Hello" ), "Hello" );
}

public static string
WantString( string s )
{
    return s;
}

public static string
WantLocalized( Localized<string> ls )
{
    return ls;
}



[Test( "InMemoryLocalized<T> assignment and retrieval of localized values" )]
public static void
Test_AssignmentRetrieval()
{
    CultureInfo     fr = CultureInfo.GetCultureInfo( "fr" );
    CultureInfo     fr_CA = CultureInfo.GetCultureInfo( "fr-CA" );
    CultureInfo     ja = CultureInfo.GetCultureInfo( "ja" );
    CultureInfo     ja_JP = CultureInfo.GetCultureInfo( "ja-JP" );
    CultureInfo     en_AU = CultureInfo.GetCultureInfo( "en-AU" );


    Print( "Create an InMemoryLocalized<string>" );
    Localized<string> ls = new InMemoryLocalized<string>( "(invariant)" );


    Print( "Assign various localized values" );
    ls[ fr ] = "Bonjour";
    ls[ ja ] = "Konnichiwa";
    ls[ ja_JP ] = "Konnichiwa from Japan";


    CultureInfo ci = Thread.CurrentThread.CurrentCulture;
    try {


        Print( "Correct value when exact culture is available" );
        Thread.CurrentThread.CurrentCulture = ja_JP;
        AssertEqual<string>( ls, "Konnichiwa from Japan" );


        Print( "Correct value when only neutral is available" );
        Thread.CurrentThread.CurrentCulture = fr_CA;
        AssertEqual<string>( ls, "Bonjour" );


        Print( "Correct value when only invariant is available" );
        Thread.CurrentThread.CurrentCulture = en_AU;
        AssertEqual<string>( ls, "(invariant)" );


    } finally {
        Thread.CurrentThread.CurrentCulture = ci;
    }
}



[Test( "LocalizedException" )]
public static void
Test_LocalizedException()
{
    CultureInfo en = CultureInfo.GetCultureInfo( "en" );
    CultureInfo fr = CultureInfo.GetCultureInfo( "fr" );

    Localized<string> msg = new InMemoryLocalized<string>( "message" );
    msg[fr] = "la message";

    Exception e;
    LocalizedException le;

    Print( "LocalizedException( string )" );
    le = new LocalizedException( "message" );
    Print( "Check Message" );
    AssertEqual<string>( le.Message, "message" );
    Print( "Check Exception::Message" );
    e = le;
    AssertEqual( e.Message, "message" );

    Print( "LocalizedException( Localized<string> )" );
    le = new LocalizedException( msg );
    Print( "Check localied messages" );
    AssertEqual<string>( le.Message[en], "message" );
    AssertEqual<string>( le.Message[fr], "la message" );

    Print( "LocalizedException( Localized<string>, Exception )" );
    Exception ie = new ArgumentException();
    le = new LocalizedException( msg, ie );
    Print( "Check InnerException" );
    AssertEqual( le.InnerException, ie );

    if( e == null ) {}
}



[Test( "LocalizedString.Format()" )]
public static void
Test_LocalizedString_Format()
{
    CultureInfo en = CultureInfo.GetCultureInfo( "en-US" );
    CultureInfo fr = CultureInfo.GetCultureInfo( "fr-FR" );

    Print( "Create a localized format string" );
    Localized<string> format = new InMemoryLocalized<string>( "..." );
    format[en] = "It's {0} : {1}";
    format[fr] = "C'est {0} : {1}";

    Print( "Create a couple of Localized<string>s" );
    Localized<string> a = new InMemoryLocalized<string>( "..." );
    a[en] = "a(english)";
    a[fr] = "a(french)";

    Localized<string> b = new InMemoryLocalized<string>( "..." );
    b[en] = "b(english)";
    b[fr] = "b(french)";

    Print( "LocalizedString.Format() them according to the localized " +
        "format string, into a new Localized<string>" );
    Localized<string> both = LocalizedString.Format(
        format,
        a, b
    );

    Print( "Check that the resultant Localized<string> appears correctly in " +
        "different cultures" );
    AssertEqual( both[en], "It's a(english) : b(english)" );
    AssertEqual( both[fr], "C'est a(french) : b(french)" );
}




} // type
} // namespace

