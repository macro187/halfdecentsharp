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

using Com.Halfdecent.Testing;
using Com.Halfdecent.Application;
using Com.Halfdecent.Globalization;



namespace
Com.Halfdecent.Application.Test
{



/// <summary>
/// Tests for <c>Com.Halfdecent.Application</c>
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

[Test( "UserException" )]
public static void
Test_UserException()
{
    Exception e;
    Exception ue;
    Localized<string> ls =
        new InMemoryLocalized<string>( "You did something wrong" );
    Print( "UserException( Localized<string> )" );
    ue = new UserException( ls );
    Print( "UserException( Localized<string>, Exception )" );
    e = new Exception();
    ue = new UserException( ls, e );

    if( ue == null ) {}
}



} // type
} // namespace

