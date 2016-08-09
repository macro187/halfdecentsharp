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
using Halfdecent.Testing;
using Halfdecent.Resources;


namespace
Halfdecent.Resources.Test
{


// =============================================================================
/// Tests for <tt>Halfdecent.Resources</tt>
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


[Test( "Resource.Get<T>()" )]
public static
void
Test_Resource_Get()
{
    CultureInfo en = CultureInfo.GetCultureInfo( "en" );
    CultureInfo en_AU = CultureInfo.GetCultureInfo( "en-AU" );
    CultureInfo en_CA = CultureInfo.GetCultureInfo( "en-CA" );
    CultureInfo es = CultureInfo.GetCultureInfo( "es" );
    CultureInfo es_MX = CultureInfo.GetCultureInfo( "es-MX" );
    CultureInfo inv = CultureInfo.InvariantCulture;

    Print( "Specific, exists" );
    Assert(
        Resource.Get< string >( typeof(TestRes), "teststring", en_AU )
            .Value == "Hello (en-AU)" );

    Print( "Specific, doesn't exist, parent neutral exists" );
    Assert(
        Resource.Get< string >( typeof(TestRes), "teststring", en_CA )
            .HasValue == false );

    Print( "Specific, doesn't exist, parent neutral doesn't exist" );
    Assert(
        Resource.Get< string >( typeof(TestRes), "teststring", es_MX )
            .HasValue == false );

    Print( "Neutral, exists" );
    Assert(
        Resource.Get< string >( typeof(TestRes), "teststring", en )
            .Value == "Hello (en)" );

    Print( "Neutral, doesn't exist" );
    Assert(
        Resource.Get< string >( typeof(TestRes), "teststring", es )
            .HasValue == false );

    Print( "Invariant, exists" );
    Assert(
        Resource.Get< string >( typeof(TestRes), "teststring", inv )
            .Value == "Hello (invariant)" );

    Print( "Invariant, doesn't exist" );
    Assert(
        Resource.Get< string >( typeof(TestRes), "nonexistent", inv )
            .HasValue == false );

    Print( "No resources in assembly" );
    Assert(
        Resource.Get< string >( typeof(NoRes), "teststring", inv )
            .HasValue == false );
}




} // type
} // namespace

