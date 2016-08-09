// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010
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
using Halfdecent.Globalisation;
using Halfdecent.Meta;
using Halfdecent.Testing;


namespace
Halfdecent.Meta.Test
{


// =============================================================================
/// Test program for <tt>Halfdecent.Meta</tt>
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


[Test( "Literal" )]
public static
void
Test_Literal()
{
    Print( ".Equals()" );
    Assert(
        new Literal().Equals(
        new Literal() ) );
}


[Test( "Local" )]
public static
void
Test_Local()
{
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
    Print( ".Equals()" );
    Assert(
        new Property( "Apple" ).Equals(
        new Property( "Apple" ) ) );
    Assert( !(
        new Property( "Apple" ).Equals(
        new Property( "Orange" ) ) ) );
    Print( ".GetHashCode()" );
    Assert(
        new Property( "Apple" ).GetHashCode().Equals(
        new Property( "Apple" ).GetHashCode() ) );
}


[Test( "Indexer" )]
public static
void
Test_Indexer()
{
    Print( ".Equals()" );
    Assert(
        new Indexer( 0 ).Equals(
        new Indexer( 0 ) ) );
    Assert(
        new Indexer( "apple" ).Equals(
        new Indexer( "apple" ) ) );
    Assert( !(
        new Indexer( 0 ).Equals(
        new Indexer( 1 ) ) ) );
    Assert( !(
        new Indexer( "apple" ).Equals(
        new Indexer( "orange" ) ) ) );
    Print( ".GetHashCode()" );
    Assert(
        new Indexer( 0 ).GetHashCode().Equals(
        new Indexer( 0 ).GetHashCode() ) );
}


[Test( "This" )]
public static
void
Test_This()
{
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


[Test( "Frame" )]
public static
void
Test_Frame()
{
    Frame f = new Frame();

    Print( "Equality" );
    Assert( f.Equals( new Frame() ) );
    Assert( !( f.Equals( new Frame().Up() ) ) );

    Print( "Relative depths" );
    Assert( f.Down().Depth == f.Depth + 1 );
    Assert( f.Up().Depth == f.Depth - 1 );

    Print( "From down the stack" );
    Assert( OneLower().Depth == f.Down().Depth );
}

public static
    Frame
OneLower()
{
    return new Frame();
}


[Test( "ValueReference" )]
public static
void
Test_ValueReference()
{
    Print( ".Equals()" );
    Assert(
        new Frame().Local( "local" ).Property( "prop" ).Equals(
        new Frame().Local( "local" ).Property( "prop" ) ) );
    Assert( !(
        new Frame().Local( "local" ).Property( "prop" ).Equals(
        new Frame().Local( "local" ).Property( "prop2" ) ) ) );

    // TODO Remaining ValueReference members
}


[Test( "ValueException" )]
public static
void
Test_ValueException()
{
    Exception inner;

    Print( ".InnerException" );
    Assert( object.ReferenceEquals(
        new ValueException().InnerException,
        null ) );
    inner = new Exception();
    Assert( object.ReferenceEquals(
        new ValueException( inner ).InnerException,
        inner ) );

    Print( ".SayMessage(), unspecified message" );
    Print( new ValueException().SayMessage( "XXX" ).InCurrent() );

    Print( ".SayMessage(), specified message" );
    Assert(
        new ValueException( r => LocalisedString.Format( "{0} yyy", r ) )
            .SayMessage( "xxx" )
            .InCurrent()
        == "xxx yyy" );

    Print( ".Message, unspecified message" );
    Assert( new ValueException().Message.InCurrent()
        == LocalisedString.Format(
            ValueException.UNSPECIFIED_PROBLEM_FORMAT,
            ValueException.UNSPECIFIED_VALUE )
            .InCurrent() );

    Print( ".Message, specified message" );
    Assert(
        new ValueException( r => LocalisedString.Format( "{0} yyy", r ) )
            .Message.InCurrent()
        == LocalisedString.Format(
            "{0} yyy", ValueException.UNSPECIFIED_VALUE ).InCurrent() );
}


[Test( "ValueArgumentException" )]
public static
void
Test_ValueArgumentException()
{
    Exception inner;

    Print( "Constructors" );
    Expect< ArgumentNullException >( () =>
        new ValueArgumentException( null ) );
    Expect< ArgumentException >( () =>
        new ValueArgumentException( "" ) );

    Print( ".InnerException" );
    Assert( object.ReferenceEquals(
        new ValueArgumentException( "param" ).InnerException,
        null ) );
    inner = new Exception();
    Assert( object.ReferenceEquals(
        new ValueArgumentException( "param", inner ).InnerException,
        inner ) );

    Print( ".SayMessage(), unspecified message" );
    Print(
        new ValueArgumentException( "arg" ).SayMessage( "XXX" ).InCurrent() );

    Print( ".SayMessage(), specified message" );
    Assert(
        new ValueArgumentException(
            "arg",
            r => LocalisedString.Format( "{0} yyy", r ) )
                .SayMessage( "xxx" )
                .InCurrent()
            == "xxx yyy" );

    Print( ".Message, unspecified message" );
    Assert( new ValueArgumentException( "arg" ).Message.InCurrent()
        == LocalisedString.Format(
            ValueException.UNSPECIFIED_PROBLEM_FORMAT,
            LocalisedString.Format(
                ValueArgumentException.ARGUMENT_FORMAT,
                "arg" ) )
            .InCurrent() );

    Print( ".Message, specified message" );
    Assert(
        new ValueArgumentException(
            "arg",
            r => LocalisedString.Format( "{0} yyy", r ) )
            .Message.InCurrent()
        == LocalisedString.Format(
            "{0} yyy",
            LocalisedString.Format(
                ValueArgumentException.ARGUMENT_FORMAT,
                "arg" ) )
            .InCurrent() );
}


[Test( "ValueArgumentNullException" )]
public static
void
Test_ValueArgumentNullException()
{
    Exception inner;

    Print( "Constructors" );
    Expect< ArgumentNullException >( () =>
        new ValueArgumentNullException( null ) );
    Expect< ArgumentException >( () =>
        new ValueArgumentNullException( "" ) );

    Print( ".InnerException" );
    Assert( object.ReferenceEquals(
        new ValueArgumentNullException( "param" ).InnerException,
        null ) );
    inner = new Exception();
    Assert( object.ReferenceEquals(
        new ValueArgumentNullException( "param", inner ).InnerException,
        inner ) );

    Print( ".SayMessage()" );
    Print(
        new ValueArgumentException( "arg" ).SayMessage( "XXX" ).InCurrent() );

    Print( ".Message" );
    Print( new ValueArgumentException( "arg" ).Message.InCurrent() );
}


[Test( "ValueReferenceException" )]
public static
void
Test_ValueReferenceException()
{
    bool success;

    object foo = new object();
    object bar = new object();

    Print( "void Match( pred, pred, action ), match" );
    success = false;
    try {
        ThrowOne( new object() );
    } catch( Exception ex ) {
        ValueReferenceException.Match< Exception >( ex,
            (vr,f) => vr.Equals(
                f.Down().Parameter( "arg1" ).Property( "Prop1" ) ),
            e => e.Message == "fake exception",
            (vr, f, e ) => success = true );
    }
    Assert( success );

    Print( "void Match( pred, pred, action ), value reference mismatch" );
    success = false;
    try {
        ThrowOne( new object() );
    } catch( Exception ex ) {
        success = true;
        ValueReferenceException.Match< Exception >( ex,
            (vr,f) => vr.Equals(
                f.Down().Parameter( "arg1" ).Property( "WRONG" ) ),
            e => e.Message == "fake exception",
            (vr, f, e ) => success = false );
    }
    Assert( success );

    Print( "void Match( pred, pred, action ), exception mismatch" );
    success = false;
    try {
        ThrowOne( new object() );
    } catch( Exception ex ) {
        success = true;
        ValueReferenceException.Match< Exception >( ex,
            (vr,f) => vr.Equals(
                f.Down().Parameter( "arg1" ).Property( "Prop1" ) ),
            e => e.Message == "WRONG",
            (vr, f, e ) => success = false );
    }
    Assert( success );

    Print( "bool Match( pred, pred ), match" );
    success = false;
    try {
        ThrowOne( new object() );
    } catch( Exception ex ) {
        success = ValueReferenceException.Match< Exception >( ex,
            (vr,f) => vr.Equals(
                f.Down().Parameter( "arg1" ).Property( "Prop1" ) ),
            e => e.Message == "fake exception" );
    }
    Assert( success );

    Print( "bool Match( pred, pred ), value reference mismatch" );
    success = false;
    try {
        ThrowOne( new object() );
    } catch( Exception ex ) {
        success = true;
        success = !( ValueReferenceException.Match< Exception >( ex,
            (vr,f) => vr.Equals(
                f.Down().Parameter( "arg1" ).Property( "WRONG" ) ),
            e => e.Message == "fake exception" ) );
    }
    Assert( success );

    Print( "bool Match( pred ), match" );
    success = false;
    try {
        ThrowOne( new object() );
    } catch( Exception ex ) {
        success = ValueReferenceException.Match<
            Exception >(
            ex,
            (vr,f) => vr.Equals(
                f.Down().Parameter( "arg1" ).Property( "Prop1" ) ) );
    }
    Assert( success );

    Print( "bool Match( pred ), value reference mismatch" );
    success = false;
    try {
        ThrowOne( new object() );
    } catch( Exception ex ) {
        success = true;
        success = !( ValueReferenceException.Match<
            Exception >(
            ex,
            (vr,f) => vr.Equals(
                f.Down().Parameter( "arg1" ).Property( "WRONG" ) ) ) );
    }
    Assert( success );

    Print( "void Map( Action )" );
    success = false;
    try {
        ValueReferenceException.Map(
            f => f.Local( "foo" ),
            f => f.Down().Parameter( "arg1" ),
            () => ThrowOne( foo ) );
    } catch( ValueReferenceException vre ) {
        success = vre.ValueReference.Equals(
            new Frame().Local( "foo" ).Property( "Prop1" ) );
    }
    Assert( success );

    Print( "T Map<T>( Func<T> )" );
    success = false;
    try {
        bar = ValueReferenceException.Map(
            f => f.Local( "foo" ),
            f => f.Down().Parameter( "arg2" ),
            () => ThrowTwo( foo ) );
    } catch( ValueReferenceException vre ) {
        success = vre.ValueReference.Equals(
            new Frame().Local( "foo" ).Property( "Prop2" ) );
    }
    Assert( success );

    Print( "Nested mapped method calls" );
    success = false;
    try {
        bar = ValueReferenceException.Map(
            f => f.Local( "foo" ),
            f => f.Down().Parameter( "arg3" ),
            () => ThrowThree( foo ) );
    } catch( ValueReferenceException vre ) {
        success = vre.ValueReference.Equals(
            new Frame().Local( "foo" ).Property( "Prop2" ) );
    }
    Assert( success );

    Print( "Print out a test mapped exception chain" );
    Expect< ValueReferenceException >( () =>
        ValueReferenceException.Map(
            f => f.Local( "foo" ),
            f => f.Down().Parameter( "arg3" ),
            () => ThrowThree( foo ) ) );

    if( bar == null ) {}
}

public static
    void
ThrowOne( object arg1 )
{
    throw
        new ValueReferenceException(
            new Frame().Parameter( "arg1" ).Property( "Prop1" ),
            new Exception( "fake exception" ) );
}

public static
    object
ThrowTwo( object arg2 )
{
    throw
        new ValueReferenceException(
            new Frame().Parameter( "arg2" ).Property( "Prop2" ),
            new Exception( "fake exception" ) );
}

public static
    object
ThrowThree( object arg3 )
{
    return ValueReferenceException.Map(
        f => f.Parameter( "arg3" ),
        f => f.Down().Parameter( "arg2" ),
        () => ThrowTwo( arg3 ) );
}




} // type
} // namespace

