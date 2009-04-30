// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009
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
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Testing;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.Meta.Test
{


// =============================================================================
/// Test program for <tt>Com.Halfdecent.Meta</tt>
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


[Test( "ValueException" )]
public static
void
Test_ValueException()
{
    IValue              valueReference = new Local( "fakelocal" );
    Localised< string > messageFormat = "Fake problem with {0}";
    Exception           innerException = new Exception();
    Localised< string > reference = "some fake value";

    ValueException< IValue > e;
    Print( "ValueException( valueReference )" );
    e = ValueException.Create( valueReference );
    Print( "Check .ValueReference" );
    AssertEqual( e.ValueReference, valueReference );
    Print( "SayMessage: {0}", e.SayMessage( reference ) );
    Print( "Message: {0}", e.Message );
    Print( "Check .InnerException" );
    AssertEqual( e.InnerException, null );

    Print( "ValueException( valueReference, messageFormat )" );
    e = ValueException.Create( valueReference, messageFormat );
    Print( "Check .ValueReference" );
    AssertEqual( e.ValueReference, valueReference );
    Print( "Check .SayMessage()" );
    AssertEqual< string >(
        e.SayMessage( reference ),
        LocalisedString.Format( e.MessageFormat, reference) );
    Print( "Check .Message" );
    AssertEqual< string >(
        e.Message,
        LocalisedString.Format(
            e.MessageFormat,
            e.ValueReference.ToString() ) );
    Print( "Check .InnerException" );
    AssertEqual( e.InnerException, null );

    Print( "ValueException( valueReference, messageFormat, innerException )" );
    e = ValueException.Create( valueReference, messageFormat, innerException );
    Print( "Check .ValueReference" );
    AssertEqual( e.ValueReference, valueReference );
    Print( "Check .SayMessage()" );
    AssertEqual< string >(
        e.SayMessage( reference ),
        LocalisedString.Format( e.MessageFormat, reference) );
    Print( "Check .Message" );
    AssertEqual< string >(
        e.Message,
        LocalisedString.Format(
            e.MessageFormat,
            e.ValueReference.ToString() ) );
    Print( "Check .InnerException" );
    AssertEqual( e.InnerException, innerException );
}




} // type
} // namespace

