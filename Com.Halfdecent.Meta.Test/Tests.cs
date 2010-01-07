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
using Com.Halfdecent.Exceptions;
using Com.Halfdecent.Meta;
using Com.Halfdecent.Testing;


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

    ValueException e;
    Print( "ValueException( valueReference )" );
    e = new ValueException( valueReference );
    Print( "Check .ValueReference" );
    AssertEqual( e.ValueReference, valueReference );
    Print( "SayMessage: {0}", e.SayMessage( reference ) );
    Print( "Message: {0}", e.Message );
    Print( "Check .InnerException" );
    AssertEqual( e.InnerException, null );

    Print( "ValueException( valueReference, messageFormat )" );
    e = new ValueException( valueReference, messageFormat );
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
    e = new ValueException( valueReference, messageFormat, innerException );
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


[Test( "ValueArgumentException" )]
public static
void
Test_ValueArgumentException()
{
    ValueArgumentException  vae;
    IValueException         ve;
    ILocalisedException     le;
    ArgumentException       ae;

    Parameter param = new Parameter( "param" );
    string format = "Test Format {0}";
    Exception inner = new Exception();

    Print( "ValueArgumentException( Parameter )" );
    vae = new ValueArgumentException( param );
    ve = vae; le = vae; ae = vae;
    Print( "IValueException.ValueReference" );
    AssertEqual( ve.ValueReference, param );
    Print( "ArgumentException.ParamName" );
    AssertEqual( ae.ParamName, param.Name );

    Print( "ValueArgumentException( Parameter, Localised<string> )" );
    vae = new ValueArgumentException( param, format );
    ve = vae; le = vae; ae = vae;
    Print( "IValueException.ValueReference" );
    AssertEqual( ve.ValueReference, param );
    Print( "IValueException.SayMessage" );
    AssertEqual< string >(
        ve.SayMessage( "ref" ),
        string.Format( format, "ref" ) );
    Print( "ILocalisedException.Message" );
    AssertEqual< string >(
        le.Message,
        string.Format( format, param.ToString() ) );
    Print( "ArgumentException.ParamName" );
    AssertEqual( ae.ParamName, param.Name );
    Print( "ArgumentException.Message" );
    AssertEqual(
        ae.Message,
        string.Format( format, param.ToString() ) );

    Print( "ValueArgumentException( Parameter, Localised<string>, Exception )" );
    vae = new ValueArgumentException( param, format, inner );
    ve = vae; le = vae; ae = vae;
    Print( "IValueException.ValueReference" );
    AssertEqual( ve.ValueReference, param );
    Print( "IValueException.SayMessage" );
    AssertEqual< string >(
        ve.SayMessage( "ref" ),
        string.Format( format, "ref" ) );
    Print( "ILocalisedException.Message" );
    AssertEqual< string >(
        le.Message,
        string.Format( format, param.ToString() ) );
    Print( "ArgumentException.ParamName" );
    AssertEqual( ae.ParamName, param.Name );
    Print( "ArgumentException.Message" );
    AssertEqual(
        ae.Message,
        string.Format( format, param.ToString() ) );
    Print( "ArgumentException.InnerException" );
    AssertEqual(
        ae.InnerException,
        inner );
}


[Test( "ValueArgumentNullException" )]
public static
void
Test_ValueArgumentNullException()
{
    ValueArgumentNullException  vane;
    IValueException             ve;
    ILocalisedException         le;
    ArgumentNullException       ane;

    Parameter param = new Parameter( "param" );
    string format = "Test Format {0}";
    Exception inner = new Exception();

    Print( "ValueArgumentNullException( Parameter )" );
    vane = new ValueArgumentNullException( param );
    ve = vane; le = vane; ane = vane;
    Print( "IValueException.ValueReference" );
    AssertEqual( ve.ValueReference, param );
    Print( "ArgumentNullException.ParamName" );
    AssertEqual( ane.ParamName, param.Name );

    Print( "ValueArgumentNullException( Parameter, Localised<string> )" );
    vane = new ValueArgumentNullException( param, format );
    ve = vane; le = vane; ane = vane;
    Print( "IValueException.ValueReference" );
    AssertEqual( ve.ValueReference, param );
    Print( "IValueException.SayMessage" );
    AssertEqual< string >(
        ve.SayMessage( "ref" ),
        string.Format( format, "ref" ) );
    Print( "ILocalisedException.Message" );
    AssertEqual< string >(
        le.Message,
        string.Format( format, param.ToString() ) );
    Print( "ArgumentNullException.ParamName" );
    AssertEqual( ane.ParamName, param.Name );
    Print( "ArgumentNullException.Message" );
    AssertEqual(
        ane.Message,
        string.Format( format, param.ToString() ) );

    Print( "ValueArgumentNullException( Parameter, Localised<string>, Exception )" );
    vane = new ValueArgumentNullException( param, format, inner );
    ve = vane; le = vane; ane = vane;
    Print( "IValueException.ValueReference" );
    AssertEqual( ve.ValueReference, param );
    Print( "IValueException.SayMessage" );
    AssertEqual< string >(
        ve.SayMessage( "ref" ),
        string.Format( format, "ref" ) );
    Print( "ILocalisedException.Message" );
    AssertEqual< string >(
        le.Message,
        string.Format( format, param.ToString() ) );
    Print( "ArgumentNullException.ParamName" );
    AssertEqual( ane.ParamName, param.Name );
    Print( "ArgumentNullException.Message" );
    AssertEqual(
        ane.Message,
        string.Format( format, param.ToString() ) );
    Print( "ArgumentNullException.InnerException" );
    AssertEqual(
        ane.InnerException,
        inner );
}


[Test( "ValueArgumentOutOfRangeException" )]
public static
void
Test_ValueArgumentOutOfRangeException()
{
    ValueArgumentOutOfRangeException    vaoore;
    IValueException                     ve;
    ILocalisedException                 le;
    ArgumentOutOfRangeException         aoore;

    Parameter param = new Parameter( "param" );
    string format = "Test Format {0}";
    string actual = "badvalue";
    Exception inner = new Exception();

    Print( "ValueArgumentOutOfRangeException( Parameter )" );
    vaoore = new ValueArgumentOutOfRangeException( param );
    ve = vaoore; le = vaoore; aoore = vaoore;
    Print( "IValueException.ValueReference" );
    AssertEqual( ve.ValueReference, param );
    Print( "ArgumentOutOfRangeException.ParamName" );
    AssertEqual( aoore.ParamName, param.Name );

    Print( "ValueArgumentOutOfRangeException( Parameter, Localised<string> )" );
    vaoore = new ValueArgumentOutOfRangeException( param, format );
    ve = vaoore; le = vaoore; aoore = vaoore;
    Print( "IValueException.ValueReference" );
    AssertEqual( ve.ValueReference, param );
    Print( "IValueException.SayMessage" );
    AssertEqual< string >(
        ve.SayMessage( "ref" ),
        string.Format( format, "ref" ) );
    Print( "ILocalisedException.Message" );
    AssertEqual< string >(
        le.Message,
        string.Format( format, param.ToString() ) );
    Print( "ArgumentOutOfRangeException.ParamName" );
    AssertEqual( aoore.ParamName, param.Name );
    Print( "ArgumentOutOfRangeException.Message" );
    AssertEqual(
        aoore.Message,
        string.Format( format, param.ToString() ) );

    Print( "ValueArgumentOutOfRangeException( Parameter, Localised<string>, object )" );
    vaoore = new ValueArgumentOutOfRangeException( param, format, actual );
    ve = vaoore; le = vaoore; aoore = vaoore;
    Print( "IValueException.ValueReference" );
    AssertEqual( ve.ValueReference, param );
    Print( "IValueException.SayMessage" );
    AssertEqual< string >(
        ve.SayMessage( "ref" ),
        string.Format( format, "ref" ) );
    Print( "ILocalisedException.Message" );
    AssertEqual< string >(
        le.Message,
        string.Format( format, param.ToString() ) );
    Print( "ArgumentOutOfRangeException.ParamName" );
    AssertEqual( aoore.ParamName, param.Name );
    Print( "ArgumentOutOfRangeException.Message" );
    AssertEqual(
        aoore.Message,
        string.Format( format, param.ToString() ) );
    Print( "ArgumentOutOfRangeException.ActualValue" );
    AssertEqual(
        aoore.ActualValue,
        actual );

    Print( "ValueArgumentOutOfRangeException( Parameter, Localised<string>, object, Exception )" );
    vaoore = new ValueArgumentOutOfRangeException( param, format, actual, inner );
    ve = vaoore; le = vaoore; aoore = vaoore;
    Print( "IValueException.ValueReference" );
    AssertEqual( ve.ValueReference, param );
    Print( "IValueException.SayMessage" );
    AssertEqual< string >(
        ve.SayMessage( "ref" ),
        string.Format( format, "ref" ) );
    Print( "ILocalisedException.Message" );
    AssertEqual< string >(
        le.Message,
        string.Format( format, param.ToString() ) );
    Print( "ArgumentOutOfRangeException.ParamName" );
    AssertEqual( aoore.ParamName, param.Name );
    Print( "ArgumentOutOfRangeException.Message" );
    AssertEqual(
        aoore.Message,
        string.Format( format, param.ToString() ) );
    Print( "ArgumentOutOfRangeException.ActualValue" );
    AssertEqual(
        aoore.ActualValue,
        actual );
    Print( "ArgumentOutOfRangeException.InnerException" );
    AssertEqual(
        aoore.InnerException,
        inner );
}


[Test( "Literal" )]
public static
void
Test_Literal()
{
    Print( ".ToString()" );
    Print( new Literal().ToString() );
    Print( ".Equals()" );
    Assert( !(
        new Literal().Equals(
        new Literal() ) ) );
}


[Test( "Local" )]
public static
void
Test_Local()
{
    Print( ".ToString()" );
    Print( new Local( "apple" ).ToString() );
    Print( ".Equals()" );
    Assert(
        new Local( "apple" ).Equals(
        new Local( "apple" ) ) );
    Assert( !(
        new Local( "apple" ).Equals(
        new Local( "orange" ) ) ) );
    Print( ".GetHashCode()" );
    Assert(
        new Local( "apple" ).GetHashCode().Equals(
        new Local( "apple" ).GetHashCode() ) );
}


[Test( "Parameter" )]
public static
void
Test_Parameter()
{
    Print( ".ToString()" );
    Print( new Parameter( "apple" ).ToString() );
    Print( ".Equals()" );
    Assert(
        new Parameter( "apple" ).Equals(
        new Parameter( "apple" ) ) );
    Assert( !(
        new Parameter( "apple" ).Equals(
        new Local( "apple" ) ) ) );
    Assert( !(
        new Parameter( "apple" ).Equals(
        new Parameter( "orange" ) ) ) );
    Print( ".GetHashCode()" );
    Assert(
        new Parameter( "apple" ).GetHashCode().Equals(
        new Parameter( "apple" ).GetHashCode() ) );
}


[Test( "Property" )]
public static
void
Test_Property()
{
    Print( ".ToString()" );
    Print( new Local( "foo" ).Property( "Apple" ).ToString() );
    Print( ".Equals()" );
    Assert(
        new Local( "foo" ).Property( "Apple" ).Equals(
        new Local( "foo" ).Property( "Apple" ) ) );
    Assert( !(
        new Local( "foo" ).Property( "Apple" ).Equals(
        new Local( "foo" ).Property( "Orange" ) ) ) );
    Assert( !(
        new Local( "foo" ).Property( "Apple" ).Equals(
        new Local( "bar" ).Property( "Apple" ) ) ) );
    Print( ".GetHashCode()" );
    Assert(
        new Local( "foo" ).Property( "Apple" ).GetHashCode().Equals(
        new Local( "foo" ).Property( "Apple" ).GetHashCode() ) );
}


[Test( "Indexer" )]
public static
void
Test_Indexer()
{
    Print( ".ToString()" );
    Print( new Local( "foo" ).Indexer( 0 ).ToString() );
    Print( new Local( "foo" ).Indexer( "stringindex" ).ToString() );
    Print( ".Equals()" );
    Assert(
        new Local( "foo" ).Indexer( 0 ).Equals(
        new Local( "foo" ).Indexer( 0 ) ) );
    Assert(
        new Local( "foo" ).Indexer( "apple" ).Equals(
        new Local( "foo" ).Indexer( "apple" ) ) );
    Assert( !(
        new Local( "foo" ).Indexer( 0 ).Equals(
        new Local( "foo" ).Indexer( 1 ) ) ) );
    Assert( !(
        new Local( "foo" ).Indexer( "apple" ).Equals(
        new Local( "foo" ).Indexer( "orange" ) ) ) );
    Assert( !(
        new Local( "foo" ).Indexer( 0 ).Equals(
        new Local( "bar" ).Indexer( 0 ) ) ) );
    Print( ".GetHashCode()" );
    Assert(
        new Local( "foo" ).Indexer( 0 ).GetHashCode().Equals(
        new Local( "foo" ).Indexer( 0 ).GetHashCode() ) );
}


[Test( "This" )]
public static
void
Test_This()
{
    Print( ".ToString()" );
    Print( new This().ToString() );
    Print( ".Equals()" );
    Assert(
        new This().Equals(
        new This() ) );
    Assert( !(
        new This().Equals(
        new Parameter( "this" ) ) ) );
    Print( ".GetHashCode()" );
    Assert(
        new This().GetHashCode().Equals(
        new This().GetHashCode() ) );
}




} // type
} // namespace

