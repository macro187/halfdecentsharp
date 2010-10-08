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

    Print( "Null passes" );
    EQ.Require( (object)1, new ObjectComparer(), (object)null, new Literal() );

    Print( "Equal passes" );
    EQ.Require( 1, 1, new Literal() );

    Print( "Inequal fails" );
    Expect< RTypeException >(
        () => EQ.Require( 1, 2, new Literal() ) );

    Print( "With null CompareTo, null passes" );
    EQ.Require( null, new ObjectComparer(), null, new Literal() );

    Print( "With null CompareTo, non-null fails" );
    Expect< RTypeException >(
        () => EQ.Require(
            null, new ObjectComparer(), new object(), new Literal() ) );
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

    Print( "Null passes" );
    NEQ.Require( (object)1, new ObjectComparer(), null, new Literal() );

    Print( "Inequal passes" );
    NEQ.Require( 1, 2, new Literal() );

    Print( "Equal fails" );
    Expect< RTypeException >(
        () => NEQ.Require( 1, 1, new Literal() ) );

    Print( "With null CompareTo, non-null passes" );
    NEQ.Require( null, new ObjectComparer(), new object(), new Literal() );

    Print( "With null CompareTo, null fails" );
    Expect< RTypeException >(
        () => NEQ.Require( null, new ObjectComparer(), null, new Literal() ) );
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
    NonNull.Require( new object(), new Literal() );

    Print( "Null fails" );
    Expect< RTypeException >(
        () => NonNull.Require( null, new Literal() ) );
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
    NonBlankString.Require( null, new Literal() );

    Print( "Non-blank string passes" );
    NonBlankString.Require( "Not blank", new Literal() );

    Print( "Blank string fails" );
    Expect< RTypeException >(
        () => NonBlankString.Require( "", new Literal() ) );
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
        GT.Create( null, new ComparableComparer<I>() ) );
    Expect< System.ArgumentNullException >( () =>
        GT.Create( bigger, null ) );

    Print( "null passes" );
    GT.Require( equal, null, new Literal() );

    Print( "Bigger passes" );
    GT.Require<I>( equal, bigger, new Local( "bigger" ) );

    Print( "Equal fails" );
    Expect< RTypeException >( () =>
        GT.Require( equal, equal, new Local( "equal" ) ) );

    Print( "Smaller fails" );
    Expect< RTypeException >( () =>
        GT.Require( equal, smaller, new Local( "smaller" ) ) );
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
        GTE.Create( equal, new ComparableComparer<I>() ).Equals(
        GTE.Create( equal, new ComparableComparer<I>() ) ) );
    Assert(
        GTE.Create( equal, new ComparableComparer<I>() ).GetHashCode() ==
        GTE.Create( equal, new ComparableComparer<I>() ).GetHashCode() );
    Assert( !
        GTE.Create( bigger, new ComparableComparer<I>() ).Equals(
        GTE.Create( smaller, new ComparableComparer<I>() ) ) );

    Print( "Null arguments to constructor throw ArgumentNullException" );
    Expect< System.ArgumentNullException >( () =>
        GTE.Create( null, new ComparableComparer<I>() ) );
    Expect< System.ArgumentNullException >( () =>
        GTE.Create( bigger, null ) );

    Print( "null passes" );
    GTE.Require( equal, null, new Literal() );

    Print( "Bigger passes" );
    GTE.Require( equal, bigger, new Local( "bigger" ) );

    Print( "Equal passes" );
    GTE.Require( equal, equal, new Local( "equal" ) );

    Print( "Smaller fails" );
    Expect< RTypeException >( () =>
        GTE.Require( equal, smaller, new Local( "smaller" ) ) );
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
        LT.Create( null, new ComparableComparer<I>() ) );
    Expect< System.ArgumentNullException >( () =>
        LT.Create( bigger, null ) );

    Print( "null passes" );
    LT.Require( equal, null, new Literal() );

    Print( "Bigger fails" );
    Expect< RTypeException >( () =>
        LT.Require( equal, bigger, new Local( "bigger" ) ) );

    Print( "Equal fails" );
    Expect< RTypeException >( () =>
        LT.Require( equal, equal, new Local( "equal" ) ) );

    Print( "Smaller passes" );
    LT.Require( equal, smaller, new Local( "smaller" ) );
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
        LTE.Create( null, new ComparableComparer<I>() ) );
    Expect< System.ArgumentNullException >( () =>
        LTE.Create( bigger, null ) );

    Print( "null passes" );
    LTE.Require( equal, null, new Literal() );

    Print( "Bigger fails" );
    Expect< RTypeException >( () =>
        LTE.Require( equal, bigger, new Local( "bigger" ) ) );

    Print( "Equal passes" );
    LTE.Require( equal, equal, new Local( "equal" ) );

    Print( "Smaller passes" );
    LTE.Require( equal, smaller, new Local( "smaller" ) );
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

    Print( "NonNull <= NEQ<object>( null, new ReferenceComparer() )" );
    Assert(
        new NonNull().IsEqualToOrMoreSpecificThan(
            new NEQ<object>( null, new ReferenceComparer() ) ) );

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

    IRType< int > rtinc =
        InInterval.Create( Interval.Create( from, true, to, true ) );
    IRType< int > rtexc =
        InInterval.Create( Interval.Create( from, false, to, false ) );
    IRType< int > rtfrominc =
        InInterval.Create( Interval.Create( from, true, to, false ) );
    IRType< int > rttoinc =
        InInterval.Create( Interval.Create( from, false, to, true ) );

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
    IRType< int > t1 = InInterval.Create( Interval.Create( 1, 10 ) );
    IRType< int > t2 = InInterval.Create( Interval.Create( 1, 10 ) );
    IRType< int > t3 = InInterval.Create( Interval.Create( 1, 20 ) );
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

