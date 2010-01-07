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
    t.Require< object, object >( null, new Literal() );

    Print( "Equal passes" );
    t.Require( 1, new Literal() );

    Print( "Inequal fails" );
    Expect< RTypeException >(
        () => t.Require( 2, new Literal() ) );

    t = new EQ<object>( null, new ObjectComparer() );

    Print( "With null CompareTo, null passes" );
    t.Require< object, object >( null, new Literal() );

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
    t.Require< object, object >( null, new Literal() );

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
        () => t.Require< object, object >( null, new Literal() ) );
}


public interface I : IComparable< I > {}
public interface II : I {}
public interface J : IComparable< J > {}
public class AlwaysBigger : I {
    // IComparable< I >
    public int CompareTo( I that ) {
        return Comparable.CompareTo( this, that );
    }
    public int DirectionalCompareTo( I that ) {
        return 1;
    }
    // IEquatable< I >
    public bool Equals( I that ) {
        return Equatable.Equals( this, that );
    }
    public bool DirectionalEquals(
        I that
    ) {
        return false;
    }
    int IEquatable<I>.GetHashCode() {
        return 1;
    }
    // System.Object
    public override bool Equals( object that ) { throw new System.Exception(); }
    public override int GetHashCode() { throw new System.Exception(); }
}
public class AlwaysEqual : I {
    // IComparable< I >
    public int CompareTo( I that ) {
        return Comparable.CompareTo( this, that );
    }
    public int DirectionalCompareTo( I that ) {
        return 0;
    }
    // IEquatable< I >
    public bool Equals( I that ) {
        return Equatable.Equals( this, that );
    }
    public bool DirectionalEquals(
        I that
    ) {
        return true;
    }
    int IEquatable<I>.GetHashCode() {
        return 0;
    }
    // System.Object
    public override bool Equals( object that ) { throw new System.Exception(); }
    public override int GetHashCode() { throw new System.Exception(); }
}
public class AlwaysSmaller : I {
    // IComparable< I >
    public int CompareTo( I that ) {
        return Comparable.CompareTo( this, that );
    }
    public int DirectionalCompareTo( I that ) {
        return -1;
    }
    // IEquatable< I >
    public bool Equals( I that ) {
        return Equatable.Equals( this, that );
    }
    public bool DirectionalEquals(
        I that
    ) {
        return false;
    }
    int IEquatable<I>.GetHashCode() {
        return 0;
    }
    // System.Object
    public override bool Equals( object that ) { throw new System.Exception(); }
    public override int GetHashCode() { throw new System.Exception(); }
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
        () => new NonNull().Require< object, object >( null, new Literal() ) );
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
    new NonBlankString().Require< string, string >( null, new Literal() );

    Print( "Non-blank string passes" );
    new NonBlankString().Require( "Not blank", new Literal() );

    Print( "Blank string fails" );
    Expect< RTypeException >(
        () => new NonBlankString().Require( "", new Literal() ) );
}


[Test( "GT<T>" )]
public static
void
Test_GT_T()
{
    I bigger = new AlwaysBigger();
    I equal = new AlwaysEqual();
    I smaller = new AlwaysSmaller();

    Print( "Equality" );
    Assert(
        new GT<I>( equal, new ComparableComparer<I>() ).Equals(
        new GT<I>( equal, new ComparableComparer<I>() ) ) );
    Assert(
        new GT<I>( equal, new ComparableComparer<I>() ).GetHashCode() ==
        new GT<I>( equal, new ComparableComparer<I>() ).GetHashCode() );
    Assert( !
        new GT<I>( bigger, new ComparableComparer<I>() ).Equals(
        new GT<I>( smaller, new ComparableComparer<I>() ) ) );

    Print( "Null arguments to constructor throw ArgumentNullException" );
    Expect< System.ArgumentNullException >( () =>
        new GT<I>( null, new ComparableComparer<I>() ) );
    Expect< System.ArgumentNullException >( () =>
        new GT<I>( bigger, null ) );

    IRType<I> t = new GT<I>( equal, new ComparableComparer<I>() );

    Print( "null passes" );
    t.Require< I, I >( null, new Literal() );

    Print( "Bigger passes" );
    t.Require( bigger, new Local( "bigger" ) );

    Print( "Equal fails" );
    Expect< RTypeException >( () =>
        t.Require( equal, new Local( "equal" ) ) );

    Print( "Smaller fails" );
    Expect< RTypeException >( () =>
        t.Require( smaller, new Local( "smaller" ) ) );
}


[Test( "GTE<T>" )]
public static
void
Test_GTE_T()
{
    I bigger = new AlwaysBigger();
    I equal = new AlwaysEqual();
    I smaller = new AlwaysSmaller();

    Print( "Equality" );
    Assert(
        new GTE<I>( equal, new ComparableComparer<I>() ).Equals(
        new GTE<I>( equal, new ComparableComparer<I>() ) ) );
    Assert(
        new GTE<I>( equal, new ComparableComparer<I>() ).GetHashCode() ==
        new GTE<I>( equal, new ComparableComparer<I>() ).GetHashCode() );
    Assert( !
        new GTE<I>( bigger, new ComparableComparer<I>() ).Equals(
        new GTE<I>( smaller, new ComparableComparer<I>() ) ) );

    Print( "Null arguments to constructor throw ArgumentNullException" );
    Expect< System.ArgumentNullException >( () =>
        new GTE<I>( null, new ComparableComparer<I>() ) );
    Expect< System.ArgumentNullException >( () =>
        new GTE<I>( bigger, null ) );

    IRType<I> t = new GTE<I>( equal, new ComparableComparer<I>() );

    Print( "null passes" );
    t.Require< I, I >( null, new Literal() );

    Print( "Bigger passes" );
    t.Require( bigger, new Local( "bigger" ) );

    Print( "Equal passes" );
    t.Require( equal, new Local( "equal" ) );

    Print( "Smaller fails" );
    Expect< RTypeException >( () =>
        t.Require( smaller, new Local( "smaller" ) ) );
}


[Test( "LT<T>" )]
public static
void
Test_LT_T()
{
    I bigger = new AlwaysBigger();
    I equal = new AlwaysEqual();
    I smaller = new AlwaysSmaller();

    Print( "Equality" );
    Assert(
        new LT<I>( equal, new ComparableComparer<I>() ).Equals(
        new LT<I>( equal, new ComparableComparer<I>() ) ) );
    Assert(
        new LT<I>( equal, new ComparableComparer<I>() ).GetHashCode() ==
        new LT<I>( equal, new ComparableComparer<I>() ).GetHashCode() );
    Assert( !
        new LT<I>( bigger, new ComparableComparer<I>() ).Equals(
        new LT<I>( smaller, new ComparableComparer<I>() ) ) );

    Print( "Null arguments to constructor throw ArgumentNullException" );
    Expect< System.ArgumentNullException >( () =>
        new LT<I>( null, new ComparableComparer<I>() ) );
    Expect< System.ArgumentNullException >( () =>
        new LT<I>( bigger, null ) );

    IRType<I> t = new LT<I>( equal, new ComparableComparer<I>() );

    Print( "null passes" );
    t.Require< I, I >( null, new Literal() );

    Print( "Bigger fails" );
    Expect< RTypeException >( () =>
        t.Require( bigger, new Local( "bigger" ) ) );

    Print( "Equal fails" );
    Expect< RTypeException >( () =>
        t.Require( equal, new Local( "equal" ) ) );

    Print( "Smaller passes" );
    t.Require( smaller, new Local( "smaller" ) );
}


[Test( "LTE<T>" )]
public static
void
Test_LTE_T()
{
    I bigger = new AlwaysBigger();
    I equal = new AlwaysEqual();
    I smaller = new AlwaysSmaller();

    Print( "Equality" );
    Assert(
        new LTE<I>( equal, new ComparableComparer<I>() ).Equals(
        new LTE<I>( equal, new ComparableComparer<I>() ) ) );
    Assert(
        new LTE<I>( equal, new ComparableComparer<I>() ).GetHashCode() ==
        new LTE<I>( equal, new ComparableComparer<I>() ).GetHashCode() );
    Assert( !
        new LTE<I>( bigger, new ComparableComparer<I>() ).Equals(
        new LTE<I>( smaller, new ComparableComparer<I>() ) ) );

    Print( "Null arguments to constructor throw ArgumentNullException" );
    Expect< System.ArgumentNullException >( () =>
        new LTE<I>( null, new ComparableComparer<I>() ) );
    Expect< System.ArgumentNullException >( () =>
        new LTE<I>( bigger, null ) );

    IRType<I> t = new LTE<I>( equal, new ComparableComparer<I>() );

    Print( "null passes" );
    t.Require< I, I >( null, new Literal() );

    Print( "Bigger fails" );
    Expect< RTypeException >( () =>
        t.Require( bigger, new Local( "bigger" ) ) );

    Print( "Equal passes" );
    t.Require( equal, new Local( "equal" ) );

    Print( "Smaller passes" );
    t.Require( smaller, new Local( "smaller" ) );
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
    Assert(
        t.Equals( u ) ==
        w.Equals( x ) );
    Assert(
        u.Equals( v ) ==
        x.Equals( y ) );

    Print( "Same .Equals() results among mixed original/contravariants as among originals" );
    Assert(
        t.Equals( u ) ==
        t.Equals( x ) );
    Assert(
        u.Equals( v ) ==
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


[Test( "InInterval_T" )]
public static void
Test_InInterval_T()
{
    int lt          = 3;
    int from        = 5;
    int between     = 7;
    int to          = 10;
    int gt          = 12;

    Value _lt       = new Local( "lt" );
    Value _from     = new Local( "from" );
    Value _between  = new Local( "between" );
    Value _to       = new Local( "to" );
    Value _gt       = new Local( "gt" );

    IComparer< int > c = new Comparer< int >(
        ( a, b ) => a.CompareTo( b ),
        ( a ) => a.GetHashCode() );

    IRType< int > rtinc =
        new InInterval< int >(
            new Interval< int >( from, true, to, true, c ) );
    IRType< int > rtexc =
        new InInterval< int >(
            new Interval< int >( from, false, to, false, c ) );
    IRType< int > rtfrominc =
        new InInterval< int >(
            new Interval< int >( from, true, to, false, c ) );
    IRType< int > rttoinc =
        new InInterval< int >(
            new Interval< int >( from, false, to, true, c ) );

    IRType< int > rt;
    string id = "...";

    Print( "Inclusive" );
    rt = rtinc;
    Print( "is     : \"" + rt.SayIs( id ) + "\"" );
    Print( "is not : \"" + rt.SayIsNot( id ) + "\"" );
    Print( "must be: \"" + rt.SayMustBe( id ) + "\"" );
    Expect< RTypeException >( () =>
        rt.Require( lt, _lt ) );
    rt.Require( from, _from );
    rt.Require( between, _between );
    rt.Require( to, _to );
    Expect< RTypeException >( () =>
        rt.Require( gt, _gt ) );

    Print( "Exclusive" );
    rt = rtexc;
    Print( "is     : \"" + rt.SayIs( id ) + "\"" );
    Print( "is not : \"" + rt.SayIsNot( id ) + "\"" );
    Print( "must be: \"" + rt.SayMustBe( id ) + "\"" );
    Expect< RTypeException >( () =>
        rt.Require( lt, _lt ) );
    Expect< RTypeException >( () =>
        rt.Require( from, _from ) );
    rt.Require( between, _between );
    Expect< RTypeException >( () =>
        rt.Require( to, _to ) );
    Expect< RTypeException >( () =>
        rt.Require( gt, _gt ) );

    Print( "From Inclusive" );
    rt = rtfrominc;
    Print( "is     : \"" + rt.SayIs( id ) + "\"" );
    Print( "is not : \"" + rt.SayIsNot( id ) + "\"" );
    Print( "must be: \"" + rt.SayMustBe( id ) + "\"" );
    Expect< RTypeException >( () =>
        rt.Require( lt, _lt ) );
    rt.Require( from, _from );
    rt.Require( between, _between );
    Expect< RTypeException >( () =>
        rt.Require( to, _to ) );
    Expect< RTypeException >( () =>
        rt.Require( gt, _gt ) );

    Print( "To Inclusive" );
    rt = rttoinc;
    Print( "is     : \"" + rt.SayIs( id ) + "\"" );
    Print( "is not : \"" + rt.SayIsNot( id ) + "\"" );
    Print( "must be: \"" + rt.SayMustBe( id ) + "\"" );
    Expect< RTypeException >( () =>
        rt.Require( lt, _lt ) );
    Expect< RTypeException >( () =>
        rt.Require( from, _from ) );
    rt.Require( between, _between );
    rt.Require( to, _to );
    Expect< RTypeException >( () =>
        rt.Require( gt, _gt ) );

    Print( ".Equals() and .GetHashCode()" );
    IRType< int > t1 = new InInterval< int >( new Interval< int >( 1, 10, c ) );
    IRType< int > t2 = new InInterval< int >( new Interval< int >( 1, 10, c ) );
    IRType< int > t3 = new InInterval< int >( new Interval< int >( 1, 20, c ) );
    Assert( t1.Equals( t2 ) );
    Assert( !( t1.Equals( t3 ) ) );
    Assert( t1.GetHashCode() == t2.GetHashCode() );
}


[Test( "IRType<T>.Is()" )]
public static
void
Test_IRType_Is()
{
    object obj = new object();
    Assert( new NonNull().Is( obj ) );
    obj = null;
    Assert( !( new NonNull().Is( obj ) ) );
}




} // type
} // namespace

