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
Com.Halfdecent.System.Test
{


// =============================================================================
/// Test program for <tt>Com.Halfdecent.Globalisation</tt>
// =============================================================================

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
    Print( "Create SingleValueLocalised<string>" );
    Localised<string> ls = new SingleValueLocalised<string>( "Hello" );

    Print( "Created object is not null" );
    Assert( ls != null );
}


[Test( "Localised<T>.InCurrent()" )]
public static
void
Test_InCurrent()
{
    Localised<string> ls = new SingleValueLocalised<string>( "Hello" );
    Assert( WantString( ls.InCurrent() ) == "Hello" );
}


[Test( "T to Localised<T> implicit conversions" )]
public static
void
Test_Conversions()
{
    Localised<string> ls = new SingleValueLocalised<string>( "Hello" );

    Print( "Localised<string> can be passed to a function expecting a string" );
    Assert( WantString( ls.InCurrent() ) == "Hello" );

    Print(
        "A string can be passed to a function expecting a Localised<string>" );
    Assert( WantLocalised( "Hello" ) == "Hello" );
}


[Test( "LocalisedProxy< TFrom, TTO>" )]
public static
void
Test_LocalisedProxy()
{
    Localised< string > s = new SingleValueLocalised< string >( "hello" );
    Localised< object > o = new LocalisedProxy< string, object >( s );

    Print( "Correct value comes through adapter" );
    Assert( o.ToString() == "hello" );
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
    return ls.InCurrent();
}


[Test( "LocalisedString.Format()" )]
public static
void
Test_LocalisedString_Format()
{
    CultureInfo en = CultureInfo.GetCultureInfo( "en-US" );
    CultureInfo fr = CultureInfo.GetCultureInfo( "fr-FR" );

    Localised<string> format = new LazyLocalised<string>( lang =>
        lang.Equals( fr )
            ? "Bonjour, {0}"
            : "Hello, {0}" );

    Localised<string> name = new LazyLocalised<string>( lang =>
        lang.Equals( fr )
            ? "Pierre"
            : "John" );

    Print( "Format() a greeting from localised parts" );
    Localised<string> greeting = LocalisedString.Format( format, name );

    Print( "Make sure it's right in english" );
    Assert( greeting.In( en ) == "Hello, John" );

    Print( "Make sure it's right in french" );
    Assert( greeting.In( fr ) == "Bonjour, Pierre" );
}




} // type
} // namespace

