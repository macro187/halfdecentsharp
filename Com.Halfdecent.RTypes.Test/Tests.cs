// -----------------------------------------------------------------------------
// Copyright (c) 2008
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
using System.Collections.Generic;
using System.Linq;
using Com.Halfdecent.SystemUtils;
using Com.Halfdecent.Testing;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.RTypes.Test
{


// =============================================================================
/// Test program for <tt>Com.Halfdecent.RTypes</tt>
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


[Test( "EQ" )]
public static
void
Test_EQ()
{
    EQ t;

    Print( ".Equals() and .GetHashCode()" );
    Assert(
        new EQ( 1 )
        .Equals( new EQ( 1 ) ) );
    Assert(
        new EQ( 1 ).GetHashCode() ==
        new EQ( 1 ).GetHashCode() );
    Assert( !(
        new EQ( 1 )
        .Equals( new EQ( 2 ) ) ) );
    Assert(
        new EQ( null )
        .Equals( new EQ( null ) ) );
    Assert(
        new EQ( null ).GetHashCode() ==
        new EQ( null ).GetHashCode() );
    Assert( !(
        new EQ( 1 )
        .Equals( new EQ( null ) ) ) );

    t = new EQ( 1 );

    Print( "Null passes" );
    t.Check< object, object >( null, new Literal() );

    Print( "Equal passes" );
    t.Check( 1, new Literal() );

    Print( "Inequal fails" );
    Expect< RTypeException >(
        () => t.Check( 2, new Literal() ) );

    t = new EQ( null );

    Print( "With null CompareTo, null passes" );
    t.Check< object, object >( null, new Literal() );

    Print( "With null CompareTo, non-null fails" );
    Expect< RTypeException >(
        () => t.Check( new object(), new Literal() ) );
}


[Test( "NEQ" )]
public static
void
Test_NEQ()
{
    NEQ t;

    Print( ".Equals() and .GetHashCode()" );
    Assert(
        new NEQ( 1 )
        .Equals( new NEQ( 1 ) ) );
    Assert(
        new NEQ( 1 ).GetHashCode() ==
        new NEQ( 1 ).GetHashCode() );
    Assert( !(
        new NEQ( 1 )
        .Equals( new NEQ( 2 ) ) ) );
    Assert(
        new NEQ( null )
        .Equals( new NEQ( null ) ) );
    Assert(
        new NEQ( null ).GetHashCode() ==
        new NEQ( null ).GetHashCode() );
    Assert( !(
        new NEQ( 1 )
        .Equals( new NEQ( null ) ) ) );

    t = new NEQ( 1 );

    Print( "Null passes" );
    t.Check< object, object >( null, new Literal() );

    Print( "Inequal passes" );
    t.Check( 2, new Literal() );

    Print( "Equal fails" );
    Expect< RTypeException >(
        () => t.Check( 1, new Literal() ) );

    t = new NEQ( null );

    Print( "With null CompareTo, non-null passes" );
    t.Check( new object(), new Literal() );

    Print( "With null CompareTo, null fails" );
    Expect< RTypeException >(
        () => t.Check< object, object >( null, new Literal() ) );
}


[Test( "NonNull" )]
public static
void
Test_NonNull()
{
    Print( ".Equals() and .GetHashCode()" );
    Assert(
        new NonNull()
        .Equals( new NonNull() ) );
    Assert(
        new NonNull().GetHashCode() ==
        new NonNull().GetHashCode() );
    Assert( !(
        new NonNull()
        .Equals( new EQ( 1 ) ) ) );

    Print( "Non-null passes" );
    new NonNull().Check( new object(), new Literal() );

    Print( "Null fails" );
    Expect< RTypeException >(
        () => new NonNull().Check< object, object >( null, new Literal() ) );
}


[Test( "NonBlankString" )]
public static
void
Test_NonBlankString()
{
    Print( ".Equals() and .GetHashCode()" );
    Assert(
        new NonBlankString()
        .Equals( new NonBlankString() ) );
    Assert(
        new NonBlankString().GetHashCode() ==
        new NonBlankString().GetHashCode() );
    Assert( !(
        new NonBlankString()
        .Equals( new EQ( 1 ) ) ) );

    Print( "Null passes" );
    new NonBlankString().Check< string, string >( null, new Literal() );

    Print( "Non-blank string passes" );
    new NonBlankString().Check( "Not blank", new Literal() );

    Print( "Blank string fails" );
    Expect< RTypeException >(
        () => new NonBlankString().Check( "", new Literal() ) );
}


[Test( "Contravariance" )]
public static
void
Test_Contravariance()
{
    IRType< object > t = new EQ( "apple" );
    IRType< object > u = new EQ( "apple" );
    IRType< object > v = new EQ( "orange" );
    IRType< string > w = t.Contravary< object, string >();
    IRType< string > x = u.Contravary< object, string >();
    IRType< string > y = v.Contravary< object, string >();

    Print( "Contravariant provides same Check() results as original" );
    w.Check( "apple", new Literal() );
    Expect< RTypeException >(
        () => w.Check( "orange", new Literal() ) );

    Print( "Contravariant .Equals() original and vice-versa" );
    Assert( t.Equals( w ) );
    Assert( w.Equals( t ) );

    Print( "Same .Equals() results among contravariants as among originals" );
    AssertEqual(
        t.Equals( u ),
        w.Equals( x ) );
    AssertEqual(
        u.Equals( v ),
        x.Equals( y ) );

    Print( "Same .Equals() results among mixed original/contravariants as among originals" );
    AssertEqual(
        t.Equals( u ),
        t.Equals( x ) );
    AssertEqual(
        u.Equals( v ),
        u.Equals( y ) );
}


private class
T
    : SimpleTextRTypeBase< int >
{
    public T() : base( "", "", "" ) {}
    public override IEnumerable< IRType< int > > Components
    {
        get {
            return base.Components
            .Append( new NEQ( "T1" ).Contravary< object, int >() )
            .Append( new NEQ( "T2" ).Contravary< object, int >() );
        }
    }
}

private class
U
    : SimpleTextRTypeBase< int >
{
    public U() : base( "", "", "" ) {}
    public override IEnumerable< IRType< int > > Components
    {
        get {
            return base.Components
            .Append( new T() )
            .Append( new NEQ( "U2" ).Contravary< object, int >() );
        }
    }
}


[Test( "AllComponentsDepthFirst()" )]
public static
void
Test_AllComponentsDepthFirst()
{
    Print( "No components" );
    Assert(
        new NEQ(4).AllComponentsDepthFirst()
        .SequenceEqual(
            Enumerable.Empty< IRType< object > >() ) );

    Print( "Flat components" );
    Assert(
        new T().AllComponentsDepthFirst()
        .SequenceEqual(
            Enumerable.Empty< IRType< int > >()
            .Append( new NEQ( "T1" ).Contravary< object, int >() )
            .Append( new NEQ( "T2" ).Contravary< object, int >() ) ) );

    Print( "Nested components" );
    Assert(
        new U().AllComponentsDepthFirst()
        .SequenceEqual(
            Enumerable.Empty< IRType< int > >()
            .Append( new T() )
            .Append( new NEQ( "T1" ).Contravary< object, int >() )
            .Append( new NEQ( "T2" ).Contravary< object, int >() )
            .Append( new NEQ( "U2" ).Contravary< object, int >() ) ) );
}


[Test( "IsEqualToOrMoreSpecificThan" )]
public static
void
Test_IsEqualToOrMoreSpecificThan()
{
    Print( "NonNull <= NonNull" );
    Assert(
        new NonNull().IsEqualToOrMoreSpecificThan(
            new NonNull() ) );

    Print( "NonNull <= NEQ( null )" );
    Assert(
        new NonNull().IsEqualToOrMoreSpecificThan(
            new NEQ( null ) ) );

    Print( "NonBlankString !<= EQ( \"foo\" )" );
    Assert( !(
        new NonBlankString().IsEqualToOrMoreSpecificThan(
            new EQ( "foo" ) ) ) );
}




} // type
} // namespace

