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


using SCG = System.Collections.Generic;
using System.Linq;
using Com.Halfdecent;
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


[Test( "EQ<T>" )]
public static
void
Test_EQ_T()
{
    Print( "Equality" );
    Assert(
        new EQ<object>( 1, new ObjectComparer() ).Equals(
        new EQ<object>( 1, new ObjectComparer() ) ) );
    Assert(
        new EQ<object>( 1, new ObjectComparer() ).GetHashCode() ==
        new EQ<object>( 1, new ObjectComparer() ).GetHashCode() );
    Assert( !
        new EQ<object>( 1, new ObjectComparer() ).Equals(
        new EQ<object>( 2, new ObjectComparer() ) ) );
    Assert(
        new EQ<object>( null, new ObjectComparer() ).Equals(
        new EQ<object>( null, new ObjectComparer() ) ) );
    Assert(
        new EQ<object>( null, new ObjectComparer() ).GetHashCode() ==
        new EQ<object>( null, new ObjectComparer() ).GetHashCode() );
    Assert( !
        new EQ<object>( 1, new ObjectComparer() ).Equals(
        new EQ<object>( null, new ObjectComparer() ) ) );

    IRType<object> t;

    t = new EQ<object>( 1, new ObjectComparer() );

    Print( "Null passes" );
    t.Require( null, new Literal() );

    Print( "Equal passes" );
    t.Require( 1, new Literal() );

    Print( "Inequal fails" );
    Expect< RTypeException >(
        () => t.Require( 2, new Literal() ) );

    t = new EQ<object>( null, new ObjectComparer() );

    Print( "With null CompareTo, null passes" );
    t.Require( null, new Literal() );

    Print( "With null CompareTo, non-null fails" );
    Expect< RTypeException >(
        () => t.Require( new object(), new Literal() ) );
}


[Test( "NEQ<T>" )]
public static
void
Test_NEQ_T()
{
    Print( "Equality" );
    Assert(
        new NEQ<object>( 1, new ObjectComparer() ).Equals(
        new NEQ<object>( 1, new ObjectComparer() ) ) );
    Assert(
        new NEQ<object>( 1, new ObjectComparer() ).GetHashCode() ==
        new NEQ<object>( 1, new ObjectComparer() ).GetHashCode() );
    Assert( !(
        new NEQ<object>( 1, new ObjectComparer() ).GetHashCode() ==
        new NEQ<object>( 2, new ObjectComparer() ).GetHashCode() ) );
    Assert(
        new NEQ<object>( null, new ObjectComparer() ).GetHashCode() ==
        new NEQ<object>( null, new ObjectComparer() ).GetHashCode() );
    Assert(
        new NEQ<object>( null, new ObjectComparer() ).GetHashCode() ==
        new NEQ<object>( null, new ObjectComparer() ).GetHashCode() );
    Assert( !(
        new NEQ<object>( 1, new ObjectComparer() ).GetHashCode() ==
        new NEQ<object>( null, new ObjectComparer() ).GetHashCode() ) );

    IRType<object> t;

    t = new NEQ<object>( 1, new ObjectComparer() );

    Print( "Null passes" );
    t.Require( null, new Literal() );

    Print( "Inequal passes" );
    t.Require( 2, new Literal() );

    Print( "Equal fails" );
    Expect< RTypeException >(
        () => t.Require( 1, new Literal() ) );

    t = new NEQ<object>( null, new ObjectComparer() );

    Print( "With null CompareTo, non-null passes" );
    t.Require( new object(), new Literal() );

    Print( "With null CompareTo, null fails" );
    Expect< RTypeException >(
        () => t.Require( null, new Literal() ) );
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
        .Equals( new EQ<object>( 1, new ObjectComparer() ) ) ) );

    Print( "Non-null passes" );
    new NonNull().Require( new object(), new Literal() );

    Print( "Null fails" );
    Expect< RTypeException >(
        () => new NonNull().Require( null, new Literal() ) );
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
        .Equals( new EQ<object>( 1, new ObjectComparer() ) ) ) );

    Print( "Null passes" );
    new NonBlankString().Require( null, new Literal() );

    Print( "Non-blank string passes" );
    new NonBlankString().Require( "Not blank", new Literal() );

    Print( "Blank string fails" );
    Expect< RTypeException >(
        () => new NonBlankString().Require( "", new Literal() ) );
}


[Test( "Contravariance" )]
public static
void
Test_Contravariance()
{
    IRType< object > t = new EQ<object>( "apple", new ObjectComparer() );
    IRType< object > u = new EQ<object>( "apple", new ObjectComparer() );
    IRType< object > v = new EQ<object>( "orange", new ObjectComparer() );
    IRType< string > w = t.Contravary< object, string >();
    IRType< string > x = u.Contravary< object, string >();
    IRType< string > y = v.Contravary< object, string >();

    Print( "Contravariant provides same Assert() results as original" );
    w.Require( "apple", new Literal() );
    Expect< RTypeException >(
        () => w.Require( "orange", new Literal() ) );

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
    public override SCG.IEnumerable< IRType< int > > GetComponents()
    {
        return
            base.GetComponents()
            .Append( new NEQ<object>( "T1", new ObjectComparer() )
                .Contravary< object, int >() )
            .Append( new NEQ<object>( "T2", new ObjectComparer() )
                .Contravary< object, int >() );
    }
}

private class
U
    : SimpleTextRTypeBase< int >
{
    public U() : base( "", "", "" ) {}
    public override SCG.IEnumerable< IRType< int > > GetComponents()
    {
        return
            base.GetComponents()
            .Append( new T() )
            .Append( new NEQ<object>( "U2", new ObjectComparer() )
                .Contravary< object, int >() );
    }
}


[Test( "AllComponentsDepthFirst()" )]
public static
void
Test_AllComponentsDepthFirst()
{
    Print( "No components" );
    Assert(
        new NEQ<object>( 4, new ObjectComparer() ).AllComponentsDepthFirst()
        .SequenceEqual(
            Enumerable.Empty< IRType< object > >() ) );

    Print( "Flat components" );
    Assert(
        new T().AllComponentsDepthFirst()
        .SequenceEqual(
            Enumerable.Empty< IRType< int > >()
            .Append( new NEQ<object>( "T1", new ObjectComparer() )
                .Contravary< object, int >() )
            .Append( new NEQ<object>( "T2", new ObjectComparer() )
                .Contravary< object, int >() ) ) );

    Print( "Nested components" );
    Assert(
        new U().AllComponentsDepthFirst()
        .SequenceEqual(
            Enumerable.Empty< IRType< int > >()
            .Append( new T() )
            .Append( new NEQ<object>( "T1", new ObjectComparer() )
                .Contravary< object, int >() )
            .Append( new NEQ<object>( "T2", new ObjectComparer() )
                .Contravary< object, int >() )
            .Append( new NEQ<object>( "U2", new ObjectComparer() )
                .Contravary< object, int >() ) ) );
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

    Print( "NonNull <= NEQ<object>( null, new ObjectComparer() )" );
    Assert(
        new NonNull().IsEqualToOrMoreSpecificThan(
            new NEQ<object>( null, new ObjectComparer() ) ) );

    Print( "NonBlankString !<= EQ<object>( \"foo\", new ObjectComparer() )" );
    Assert( !(
        new NonBlankString().IsEqualToOrMoreSpecificThan(
            new EQ<object>( "foo", new ObjectComparer() ) ) ) );
}




} // type
} // namespace

