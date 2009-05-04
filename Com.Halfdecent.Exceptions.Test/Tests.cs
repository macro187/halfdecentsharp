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
using Com.Halfdecent.Testing;
using Com.Halfdecent.Exceptions;
using Com.Halfdecent.Globalisation;


namespace
Com.Halfdecent.Exceptions.Test
{


// =============================================================================
/// Test program for <tt>Com.Halfdecent.Exceptions</tt>
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


[Test( "Localised Exceptions" )]
public static
void
Test_LocalisedExceptions()
{
    Exception           ie = new Exception();
    Localised< string > m =
        new SingleValueLocalised< string >( "message" );
    string              pn = "paramname";
    object              av = new object();

    Print( "LocalisedException" );
    try {
        throw new LocalisedException( m, ie );
    } catch( LocalisedException e ) {
        AssertEqual( e.Message, m );
        AssertEqual( e.InnerException, ie );
    }

    Print( "LocalisedArgumentException" );
    try {
        throw new LocalisedArgumentException( m, pn, ie );
    } catch( LocalisedArgumentException e ) {
        AssertEqual( e.Message, m );
        AssertEqual( e.ParamName, pn );
        AssertEqual( e.InnerException, ie );
    }

    Print( "LocalisedArgumentNullException" );
    try {
        throw new LocalisedArgumentNullException( pn, m, ie );
    } catch( LocalisedArgumentNullException e ) {
        AssertEqual( e.ParamName, pn );
        AssertEqual( e.Message, m );
        AssertEqual( e.InnerException, ie );
    }

    Print( "LocalisedArgumentOutOfRangeException" );
    try {
        throw new LocalisedArgumentOutOfRangeException( pn, av, m, ie );
    } catch( LocalisedArgumentOutOfRangeException e ) {
        AssertEqual( e.ParamName, pn );
        AssertEqual( e.ActualValue, av );
        AssertEqual( e.Message, m );
        AssertEqual( e.InnerException, ie );
    }

    Print( "LocalisedFormatException" );
    try {
        throw new LocalisedFormatException( m, ie );
    } catch( LocalisedFormatException e ) {
        AssertEqual( e.Message, m );
        AssertEqual( e.InnerException, ie );
    }

    Print( "LocalisedInvalidOperationException" );
    try {
        throw new LocalisedInvalidOperationException( m, ie );
    } catch( LocalisedInvalidOperationException e ) {
        AssertEqual( e.Message, m );
        AssertEqual( e.InnerException, ie );
    }
}




} // type
} // namespace

