// -----------------------------------------------------------------------------
// Copyright (c) 2007, 2008
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
using System.Globalization;
using System.Threading;
using Com.Halfdecent.Testing;
using Com.Halfdecent.Globalisation;

namespace
Com.Halfdecent.Resources.Test
{

// =============================================================================
/// Test program for <tt>Com.Halfdecent.Globalisation</tt>
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




[Test( "Localised<T> creation" )]
public static
void
Test_Creation()
{
    Print( "Create InMemoryLocalised<string>" );
    Localised<string> ls = new InMemoryLocalised<string>( "Hello" );

    Print( "Created object is not null" );
    Assert( ls != null );
}



[Test( "Localised<T> implicit conversions" )]
public static
void
Test_Conversions()
{
    Localised<string> ls = new InMemoryLocalised<string>( "Hello" );

    Print( "Localised<string> can be passed to a function expecting a string" );
    AssertEqual( WantString( ls ), "Hello" );

    Print( "A string can be passed to a function expecting a Localised<string>" );
    AssertEqual( WantLocalised( "Hello" ), "Hello" );
}

public static
string
WantString( string s )
{
    return s;
}

public static
string
WantLocalised( Localised<string> ls )
{
    return ls;
}



[Test( "InMemoryLocalised<T> assignment and retrieval of localised values" )]
public static
void
Test_AssignmentRetrieval()
{
    CultureInfo     fr = CultureInfo.GetCultureInfo( "fr" );
    CultureInfo     fr_CA = CultureInfo.GetCultureInfo( "fr-CA" );
    CultureInfo     ja = CultureInfo.GetCultureInfo( "ja" );
    CultureInfo     ja_JP = CultureInfo.GetCultureInfo( "ja-JP" );
    CultureInfo     en_AU = CultureInfo.GetCultureInfo( "en-AU" );


    Print( "Create an InMemoryLocalised<string>" );
    Localised<string> ls = new InMemoryLocalised<string>( "(invariant)" );


    Print( "Assign various localised values" );
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



[Test( "LocalisedString.Format()" )]
public static
void
Test_LocalisedString_Format()
{
    CultureInfo en = CultureInfo.GetCultureInfo( "en-US" );
    CultureInfo fr = CultureInfo.GetCultureInfo( "fr-FR" );

    Print( "Create a localised format string" );
    Localised<string> format = new InMemoryLocalised<string>( "..." );
    format[en] = "It's {0} : {1}";
    format[fr] = "C'est {0} : {1}";

    Print( "Create a couple of Localised<string>s" );
    Localised<string> a = new InMemoryLocalised<string>( "..." );
    a[en] = "a(english)";
    a[fr] = "a(french)";

    Localised<string> b = new InMemoryLocalised<string>( "..." );
    b[en] = "b(english)";
    b[fr] = "b(french)";

    Print( "LocalisedString.Format() them according to the localised " +
        "format string, into a new Localised<string>" );
    Localised<string> both = LocalisedString.Format(
        format,
        a, b
    );

    Print( "Check that the resultant Localised<string> appears correctly in " +
        "different cultures" );
    AssertEqual( both[en], "It's a(english) : b(english)" );
    AssertEqual( both[fr], "C'est a(french) : b(french)" );
}




} // type
} // namespace

