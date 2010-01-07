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
using Com.Halfdecent.Resources;


namespace
Com.Halfdecent.Resources.Test
{


// =============================================================================
/// Tests for <tt>Com.Halfdecent.Resources</tt>
// =============================================================================

public class
ResourcesTests
    : TestBase
{



public static
int
Main()
{
    return TestProgram.RunTests();
}


/*
[Test( "Resource.Get<T>()" )]
public static
void
Test_Resource_Get()
{
    CultureInfo         en_AU = CultureInfo.GetCultureInfo( "en-AU" );
    CultureInfo         en_CA = CultureInfo.GetCultureInfo( "en-CA" );
    CultureInfo         en_US = CultureInfo.GetCultureInfo( "en-US" );
    CultureInfo         fr_FR = CultureInfo.GetCultureInfo( "fr-FR" );


    Print( "Correct when exact version exists" );
    Assert(
        Resource.Get<string>(
            typeof(TestRes),
            "teststring",
            en_AU ) ==
        "Hello (en-AU)" );


    Print( "Correct when only neutral version exists" );
    Assert(
        Resource.Get<string>(
            typeof(TestRes),
            "teststring",
            en_CA ) ==
        "Hello (en)" );


    Print( "Correct when only invariant version exists" );
    Assert(
        Resource.Get<string>(
            typeof(TestRes),
            "teststring",
            fr_FR ) ==
        "Hello (invariant)" );


    Print( "Null when no version exists (but other resources exist in the assembly)" );
    Assert(
        Resource.Get<string>(
            typeof(TestRes),
            "nonexistent",
            en_US ) ==
        null );


    Print( "Null when no version exists (no resources in the assembly at all)" );
    Assert(
        Resource.Get<string>(
            typeof(NoRes),
            "nonexistent",
            en_US ) ==
        null );
}
*/


[Test( "Resource._R()" )]
public static
void
Test_Resource__R()
{
    Localised<string>   ls;
    CultureInfo         en_AU = CultureInfo.GetCultureInfo( "en-AU" );

    Print( "Can retrieve a resource (that exists)" );
    ls = Resource._R< string >( typeof( TestRes ), "teststring" );

    Print( "...and it isn't null" );
    Assert( ls != null );

    Print( "...and it works" );
    Assert( ls[ en_AU ] == "Hello (en-AU)" );


    Print( "ResourceMissingException if missing (other resources exist)" );
    Expect< ResourceMissingException >( delegate() {
        if(
            Resource._R< string >( typeof( TestRes ), "nonexistent" )
            == null
        ){}
    } );


    Print( "ResourceMissingException if missing (no other resources exist)" );
    Expect< ResourceMissingException >( delegate() {
        if(
            Resource._R< string >( typeof( NoRes ), "nonexistent" )
            == null
        ){}
    } );
}


[Test( "Resource._S()" )]
public static
void
Test_Resource__S()
{
    Localised<string>   ls;
    CultureInfo         en_AU = CultureInfo.GetCultureInfo( "en-AU" );
    CultureInfo         en_CA = CultureInfo.GetCultureInfo( "en-CA" );
    CultureInfo         fr_FR = CultureInfo.GetCultureInfo( "fr-FR" );
    CultureInfo         ja_JP = CultureInfo.GetCultureInfo( "ja-JP" );

    Print( "Can retrieve with resource translations" );
    ls = Resource._S( typeof( TestRes ), "Hello (code)" );

    Print( "... and it isn't null" );
    Assert( ls != null );

    Print( "Exact culture variation is correct" );
    Assert( ls[ en_AU ] == "Hello (en-AU)" );

    Print( "Neutral culture variation is correct" );
    Assert( ls[ en_CA ] == "Hello (en)" );

    Print( "Invariant culture variation is correct" );
    Assert( ls[ fr_FR ] == "Hello (invariant)" );

    Print( "Can retrieve without resource translations" );
    ls = Resource._S( typeof( NoRes ), "Hello (code)" );

    Print( "...and it isn't null" );
    Assert( ls != null );

    Print( "Value is always the original untranslated string" );
    Assert( ls[ en_AU ] == "Hello (code)" );
    Assert( ls[ en_CA ] == "Hello (code)" );
    Assert( ls[ fr_FR ] == "Hello (code)" );
    Assert( ls[ ja_JP ] == "Hello (code)" );


    Print( "NOTE: CAN'T AUTOMATICALLY CHECK THE FOLLOWING, PLEASE VERIFY" );
    Print( "(due to possible implementation differences in formatting)" );

    ls = Resource._S( typeof( TestRes ), "Today is {0:f}", DateTime.Now );
    Print( "Today's Date" );
    Print( "en-AU: " + ls[ en_AU ] );
    Print( "fr-FR: " + ls[ fr_FR ] );
    Print( "ja-JP: " + ls[ ja_JP ] );

    ls = Resource._S( typeof( TestRes ), "Pi is {0:f}", 3.14 );
    Print( "A Big Number" );
    Print( "en-AU: " + ls[ en_AU ] );
    Print( "fr-FR: " + ls[ fr_FR ] );
    Print( "ja-JP: " + ls[ ja_JP ] );
}




} // type
} // namespace

