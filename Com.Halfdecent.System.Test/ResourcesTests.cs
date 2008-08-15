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
using Com.Halfdecent.System;
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Resources;

namespace
Com.Halfdecent.System.Test
{

// =============================================================================
/// Tests for <tt>Com.Halfdecent.Resources</tt>
// =============================================================================
///
public class
ResourcesTests
    : TestBase
{




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
    AssertEqual(
        Resource.Get<string>(
            typeof(TestRes),
            "teststring",
            en_AU ),
        "Hello (en-AU)" );


    Print( "Correct when only neutral version exists" );
    AssertEqual(
        Resource.Get<string>(
            typeof(TestRes),
            "teststring",
            en_CA ),
        "Hello (en)" );


    Print( "Correct when only invariant version exists" );
    AssertEqual(
        Resource.Get<string>(
            typeof(TestRes),
            "teststring",
            fr_FR ),
        "Hello (invariant)" );


    Print( "Null when no version exists (but other resources exist in the assembly)" );
    AssertEqual(
        Resource.Get<string>(
            typeof(TestRes),
            "nonexistant",
            en_US ),
        null );


    Print( "Null when no version exists (no resources in the assembly at all)" );
    AssertEqual(
        Resource.Get<string>(
            typeof(NoRes),
            "nonexistant",
            en_US ),
        null );
}



[Test( "Resource._R<T>( Type, string )" )]
public static
void
Test_Resource__R_type_string()
{
    Localised<string>  ls;
    CultureInfo         en_AU = CultureInfo.GetCultureInfo( "en-AU" );
    bool                threw;


    Print( "Retrieve resource (that exists)" );
    ls = Resource._R<string>( typeof(TestRes), "teststring" );

    Print( "Isn't null" );
    Assert( ls != null );


    Print( "Works" );
    AssertEqual( ls[ en_AU ], "Hello (en-AU)" );


    Print( "Throws ResourceMissingException if missing (other resources exist)" );
    threw = false;
    try {
        ls = Resource._R<string>( typeof(TestRes), "nonexistant" );
        if( ls == null ) {}
    } catch( ResourceMissingException ) {
        threw = true;
    }
    Assert( threw );


    Print( "Throws ResourceMissingException if missing (no other resources exist)" );
    threw = false;
    try {
        ls = Resource._R<string>( typeof(NoRes), "nonexistant" );
        if( ls == null ) {}
    } catch( ResourceMissingException ) {
        threw = true;
    }
    Assert( threw );

}



[Test( "Resource._S( type, string )" )]
public static
void
Test_Resource__S_type_string()
{
    Localised<string>  ls;
    CultureInfo         en_AU = CultureInfo.GetCultureInfo( "en-AU" );
    CultureInfo         en_CA = CultureInfo.GetCultureInfo( "en-CA" );
    CultureInfo         fr_FR = CultureInfo.GetCultureInfo( "fr-FR" );


    Print( "Retrieve string resource (which has resource translations)" );
    ls = Resource._S( typeof(TestRes), "Hello (code)" );

    Print( "Isn't null" );
    Assert( ls != null );

    Print( "Exact culture translation" );
    AssertEqual<string>( ls[ en_AU ], "Hello (en-AU)" );

    Print( "Neutral culture translation" );
    AssertEqual<string>( ls[ en_CA ], "Hello (en)" );

    Print( "Invariant culture translation" );
    AssertEqual<string>( ls[ fr_FR ], "Hello (invariant)" );

    Print( "Retrieve string resource (which has no resource versions at all)" );
    ls = Resource._S( typeof(NoRes), "Hello (code)" );

    Print( "Isn't null" );
    Assert( ls != null );

    Print( "Value is original string" );
    AssertEqual<string>( ls[ en_AU ], "Hello (code)" );
}



[Test( "Resource._S( type, string, params object[] )" )]
public static
void
Test_Resource__S_type_string_paramsobject()
{
    Localised<string>  ls;

    CultureInfo         fr_FR = CultureInfo.GetCultureInfo( "fr-FR" );
    CultureInfo         ja_JP = CultureInfo.GetCultureInfo( "ja-JP" );

    Print( "NOTE: CAN'T AUTOMATICALLY VERIFY THESE, PLEASE EYEBALL" );
    Print( "(due to possible implementation differences in formatting)" );

    ls = Resource._S( typeof(TestRes), "Today is {0:f}", DateTime.Now );
    Print( "Today's Date" );
    Print( "Current culture: " + ls );
    Print( "French:          " + ls[ fr_FR ] );
    Print( "Japanese:        " + ls[ ja_JP ] );

    ls = Resource._S( typeof(TestRes), "Pi is {0:f}", 3.14 );
    Print( "A Big Number" );
    Print( "Current culture: " + ls );
    Print( "French:          " + ls[ fr_FR ] );
    Print( "Japanese:        " + ls[ ja_JP ] );
}




} // type
} // namespace

