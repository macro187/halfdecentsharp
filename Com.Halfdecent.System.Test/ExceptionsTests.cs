// -----------------------------------------------------------------------------
// Copyright (c) 2008 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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
using Com.Halfdecent.Exceptions;
using Com.Halfdecent.Globalisation;

namespace
Com.Halfdecent.System.Test
{

// =============================================================================
/// Tests for <tt>Com.Halfdecent.Exceptions</tt>
// =============================================================================
//
public class
ExceptionsTests
    : TestBase
{




[Test( "LocalisedExceptionBase" )]
public static
void
Test_LocalisedExceptionBase()
{
    TestException te = new TestException();

    CultureInfo en = CultureInfo.GetCultureInfo( "en-US" );
    CultureInfo fr = CultureInfo.GetCultureInfo( "fr-FR" );
    CultureInfo current;

    Print( "Message" );
    ILocalisedException le = te;
    AssertEqual( le.Message[ en ], "Test Exception" );
    AssertEqual( le.Message[ fr ], "Le Test Exception" );

    Print( "Message (via Exception.Message)" );
    Exception e = te;
    current = Thread.CurrentThread.CurrentCulture;
    try {
        Thread.CurrentThread.CurrentCulture = en;
        AssertEqual( e.Message, "Test Exception" );
        Thread.CurrentThread.CurrentCulture = fr;
        AssertEqual( e.Message, "Le Test Exception" );
    } finally {
        Thread.CurrentThread.CurrentCulture = current;
    }
}



[Test( "SimpleLocalisedExceptionBase" )]
public static
void
Test_SimpleLocalisedExceptionBase()
{
    SimpleTestException te = new SimpleTestException();

    CultureInfo en = CultureInfo.GetCultureInfo( "en-US" );
    CultureInfo fr = CultureInfo.GetCultureInfo( "fr-FR" );
    CultureInfo current;

    Print( "Message" );
    ILocalisedException le = te;
    AssertEqual( le.Message[ en ], "Simple Test Exception" );
    AssertEqual( le.Message[ fr ], "Le Simple Test Exception" );

    Print( "Message (via Exception.Message)" );
    Exception e = te;
    current = Thread.CurrentThread.CurrentCulture;
    try {
        Thread.CurrentThread.CurrentCulture = en;
        AssertEqual( e.Message, "Simple Test Exception" );
        Thread.CurrentThread.CurrentCulture = fr;
        AssertEqual( e.Message, "Le Simple Test Exception" );
    } finally {
        Thread.CurrentThread.CurrentCulture = current;
    }
}




} // ExceptionsTests




public class
TestException
    : LocalisedExceptionBase
{

public
TestException()
    : this( null )
{
}

public
TestException(
    Exception innerException
)
    : base( innerException )
{
}

override public
Localised< string >
Message
{
    get { return _S("Test Exception"); }
}

private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // TestException




public class
SimpleTestException
    : SimpleLocalisedExceptionBase
{

public
SimpleTestException()
    : base (
        _S("Simple Test Exception")
    )
{
}


private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // SimpleTestException




} // namespace

