// -----------------------------------------------------------------------------
// Copyright (c) 2007, 2008, 2009, 2010, 2011
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
Com.Halfdecent.Globalisation.Test
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


[Test( "Localised<T>" )]
public static
void
Test_Localised()
{
    CultureInfo en = CultureInfo.GetCultureInfo( "en-US" );
    CultureInfo fr = CultureInfo.GetCultureInfo( "fr-FR" );
    Localised< string > ls;

    Print( "Create single value" );
    ls = new Localised< string >( "all" );

    Print( "Check In()" );
    Assert( ls.In( en ) == "all" );
    Assert( ls.In( fr ) == "all" );

    Print( "Check InCurrent()" );
    Assert( ls.InCurrent() == "all" );

    Print( "Check explicit conversion to T" );
    Assert( ((string)ls) == "all" );

    Print( "Create multi value" );
    ls = new Localised< string >( lang =>
        lang.Equals( en ) ? "english" :
        lang.Equals( fr ) ? "french" :
        "default" );

    Print( "Check In()" );
    Assert( ls.In( en ) == "english" );
    Assert( ls.In( fr ) == "french" );

    Print( "Check via Covary()" );
    Localised< object> lo = ls.Covary< string, object >();
    Assert( lo.In( en ).ToString() == "english" );
    Assert( lo.In( fr ).ToString() == "french" );
}


[Test( "LocalisedString.Format()" )]
public static
void
Test_LocalisedString_Format()
{
    CultureInfo en = CultureInfo.GetCultureInfo( "en-US" );
    CultureInfo fr = CultureInfo.GetCultureInfo( "fr-FR" );

    Localised<string> format = new Localised<string>( lang =>
        lang.Equals( fr )
            ? "Bonjour, {0}"
            : "Hello, {0}" );

    Localised<string> name = new Localised<string>( lang =>
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


[Test( "LocalisedString.Concat()" )]
public static
void
Test_LocalisedString_Concat()
{
    CultureInfo en = CultureInfo.GetCultureInfo( "en-US" );
    CultureInfo fr = CultureInfo.GetCultureInfo( "fr-FR" );

    Localised<string> a = new Localised<string>( lang =>
        lang.Equals( fr )
            ? "Un"
            : "One" );

    Localised<string> b = new Localised<string>( lang =>
        lang.Equals( fr )
            ? "Deux"
            : "Two" );

    Print( "Concat() a couple of Localised<string>s" );
    Localised<string> ab = LocalisedString.Concat( a, b );

    Print( "Make sure it's right in english" );
    Assert( ab.In( en ) == "OneTwo" );

    Print( "Make sure it's right in french" );
    Assert( ab.In( fr ) == "UnDeux" );
}


// TODO Use examples where the lowercasing is performed differently
//
[Test( "LocalisedString.ToLower()" )]
public static
void
Test_LocalisedString_ToLower()
{
    CultureInfo en = CultureInfo.GetCultureInfo( "en-US" );
    CultureInfo fr = CultureInfo.GetCultureInfo( "fr-FR" );

    Localised<string> s = new Localised<string>( lang =>
        lang.Equals( fr )
            ? "Bonjour"
            : "Hello" )
        .ToLower();

    Print( "Make sure it's right in english" );
    Assert( s.In( en ) == "hello" );

    Print( "Make sure it's right in french" );
    Assert( s.In( fr ) == "bonjour" );
}


// TODO Use examples where the uppercasing is performed differently
//
[Test( "LocalisedString.ToUpper()" )]
public static
void
Test_LocalisedString_ToUpper()
{
    CultureInfo en = CultureInfo.GetCultureInfo( "en-US" );
    CultureInfo fr = CultureInfo.GetCultureInfo( "fr-FR" );

    Localised<string> s = new Localised<string>( lang =>
        lang.Equals( fr )
            ? "Bonjour"
            : "Hello" )
        .ToUpper();

    Print( "Make sure it's right in english" );
    Assert( s.In( en ) == "HELLO" );

    Print( "Make sure it's right in french" );
    Assert( s.In( fr ) == "BONJOUR" );
}


[Test( "Localised Exceptions" )]
public static
void
Test_LocalisedExceptions()
{
    Exception           ie = new Exception();
    Localised< string > m = new Localised< string >( "message" );
    string              pn = "paramname";
    object              av = new object();

    Print( "LocalisedException" );
    try {
        throw new LocalisedException( m, ie );
    } catch( LocalisedException e ) {
        Assert( e.Message == m );
        Assert( e.InnerException == ie );
    }

    Print( "LocalisedArgumentException" );
    try {
        throw new LocalisedArgumentException( m, pn, ie );
    } catch( LocalisedArgumentException e ) {
        Assert( e.Message == m );
        Assert( e.ParamName == pn );
        Assert( e.InnerException == ie );
    }

    Print( "LocalisedArgumentNullException" );
    try {
        throw new LocalisedArgumentNullException( pn, m, ie );
    } catch( LocalisedArgumentNullException e ) {
        Assert( e.ParamName == pn );
        Assert( e.Message == m );
        Assert( e.InnerException == ie );
    }

    Print( "LocalisedArgumentOutOfRangeException" );
    try {
        throw new LocalisedArgumentOutOfRangeException( pn, av, m, ie );
    } catch( LocalisedArgumentOutOfRangeException e ) {
        Assert( e.ParamName == pn );
        Assert( e.ActualValue == av );
        Assert( e.Message == m );
        Assert( e.InnerException == ie );
    }

    Print( "LocalisedFormatException" );
    try {
        throw new LocalisedFormatException( m, ie );
    } catch( LocalisedFormatException e ) {
        Assert( e.Message == m );
        Assert( e.InnerException == ie );
    }

    Print( "LocalisedInvalidOperationException" );
    try {
        throw new LocalisedInvalidOperationException( m, ie );
    } catch( LocalisedInvalidOperationException e ) {
        Assert( e.Message == m );
        Assert( e.InnerException == ie );
    }
}




} // type
} // namespace

