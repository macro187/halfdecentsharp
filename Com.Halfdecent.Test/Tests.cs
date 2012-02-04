// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010, 2011
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
using Com.Halfdecent;
using Com.Halfdecent.Testing;


namespace
Com.Halfdecent.Test
{


// =============================================================================
/// Test program for <tt>Com.Halfdecent</tt>
// =============================================================================
//
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


class
TestProxy
    : IProxy
{
    public
    TestProxy(
        object underlying
    )
    {
        this.Underlying = underlying;
    }

    public
    object
    Underlying
    {
        get;
        private set;
    }
}


[Test( "SystemObject" )]
public static
void
Test_SystemObject()
{
    object str = "match";
    object strproxy = new TestProxy( str );
    object obj = new object();
    object objproxy = new TestProxy( obj );
    object nul = null;

    Print( ".ToString()" );
    Assert( SystemObject.ToString( null ) == "null" );
    Assert( SystemObject.ToString( "notnull" ) == "notnull" );

    Print( "Is< T >()" );
    Assert( str.Is< string >() );
    Assert( strproxy.Is< string >() );
    Assert( !( objproxy.Is< string >() ) );
    Assert( !( nul.Is< string >() ) );

    Print( ".Is< T >( Predicate< T > )" );
    Assert( str.Is< string >( s => s == "match" ) );
    Assert( strproxy.Is< string >( s => s == "match" ) );
    Assert( !( strproxy.Is< string >( s => s == "NOMATCH" ) ) );
    Assert( !( objproxy.Is< string >( s => s == "match" ) ) );
    Assert( !( nul.Is< string >( s => s == "match" ) ) );

    Print( "GetUnderlying()" );
    Assert( obj.GetUnderlying() == obj );
    Assert( objproxy.GetUnderlying() == obj );

    Print( ".Match(), first .When() matches" );
    Assert(
        "abc"
            .Match()
            .Returns< int >()
            .When(
                s => true,
                s => 1 )
            .When(
                s => false,
                s => 2 )
            .Else(
                () => 3 )
        == 1 );

    Print( ".Match(), first and second .When()s match" );
    Assert(
        "abc"
            .Match()
            .Returns< int >()
            .When(
                s => true,
                s => 1 )
            .When(
                s => true,
                s => 2 )
            .Else(
                () => 3 )
        == 1 );

    Print( ".Match(), second .When() matches" );
    Assert(
        "abc"
            .Match()
            .Returns< int >()
            .When(
                s => false,
                s => 1 )
            .When(
                s => true,
                s => 2 )
            .Else(
                () => 3 )
        == 2 );

    Print( ".Match(), neither .When() matches" );
    Assert(
        "abc"
            .Match()
            .Returns< int >()
            .When(
                s => false,
                s => 1 )
            .When(
                s => false,
                s => 2 )
            .Else(
                () => 3 )
        == 3 );

    Print( ".Match< T >(), first .When() matches" );
    Assert(
        ((object)"abc")
            .Match()
            .Returns< int >()
            .When<
                string >(
                s => true,
                s => 1 )
            .When<
                string >(
                s => false,
                s => 2 )
            .Else(
                () => 3 )
        == 1 );

    Print( ".Match< T >(), first .When() predicate fails" );
    Assert(
        ((object)"abc")
            .Match()
            .Returns< int >()
            .When<
                string >(
                s => false,
                s => 1 )
            .When<
                string >(
                s => true,
                s => 2 )
            .Else(
                () => 3 )
        == 2 );

    Print( ".Match< T >(), first .When() type fails" );
    Assert(
        ((object)"abc")
            .Match()
            .Returns< int >()
            .When<
                System.Exception >(
                e => false,
                e => 1 )
            .When<
                string >(
                s => true,
                s => 2 )
            .Else(
                () => 3 )
        == 2 );

    Print( ".Match< T >(), neither .When() matches" );
    Assert(
        ((object)"abc")
            .Match()
            .Returns< int >()
            .When<
                System.Exception >(
                e => false,
                e => 1 )
            .When<
                string >(
                s => false,
                s => 2 )
            .Else(
                () => 3 )
        == 3 );

    Print( ".Match(), constant result" );
    Assert(
        "abc"
            .Match()
            .Returns< int >()
            .When(
                s => true,
                1 )
            .Else(
                () => 3 )
        == 1 );

    Print( ".Match< TMatch >(), constant result" );
    Assert(
        ((object)"abc")
            .Match()
            .Returns< int >()
            .When<
                string >(
                s => true,
                1 )
            .Else(
                () => 3 )
        == 1 );

    Print( ".Match< TMatch >(), no predicate, constant result" );
    Assert(
        ((object)"abc")
            .Match()
            .Returns< int >()
            .When< string >( 1 )
            .Else( () => 3 )
        == 1 );
}


[Test( "SystemEnumerable" )]
public static
void
Test_SystemEnumerable()
{
    Print( "Create()" );
    Assert(
        SystemEnumerable.Create<int>()
        .SequenceEqual( new int[]{} ) );
    Assert(
        SystemEnumerable.Create( 1 )
        .SequenceEqual( new int[]{ 1 } ) );
    Assert(
        SystemEnumerable.Create( 1, 2 )
        .SequenceEqual( new int[]{ 1, 2 } ) );

    // NOTE
    // Create( seed, func ) is tested indirectly by the SystemException.Chain()
    // test

    Print( ".Append()" );
    Assert(
        SystemEnumerable.Create<int>().Append( 1, 2 ,3 )
        .SequenceEqual( SystemEnumerable.Create( 1, 2, 3 ) ) );
    Assert(
        SystemEnumerable.Create( 1 ).Append( 2 ,3 )
        .SequenceEqual( SystemEnumerable.Create( 1, 2, 3 ) ) );
    Assert(
        SystemEnumerable.Create( 1, 2, 3 ).Append()
        .SequenceEqual( SystemEnumerable.Create( 1, 2, 3 ) ) );

    Print( ".Covary< TTo >()" );
    Assert(
        SystemEnumerable.Create( 1, 2, 3 ).Covary< int, object >()
        .SequenceEqual( SystemEnumerable.Create< object >( 1, 2, 3 ) ) );

    Print( ".StartsWith()" );
    Assert(
        Enumerable.Empty< int >()
        .StartsWith( Enumerable.Empty< int >() ) );
    Assert(
        SystemEnumerable.Create( 1, 2, 3 )
        .StartsWith( Enumerable.Empty< int >() ) );
    Assert(
        SystemEnumerable.Create( 1, 2, 3 )
        .StartsWith( SystemEnumerable.Create( 1, 2 ) ) );
    Assert(
        !SystemEnumerable.Create( 1, 2, 3 )
        .StartsWith( SystemEnumerable.Create( 1, 9 ) ) );
    Assert(
        !Enumerable.Empty< int >()
        .StartsWith( SystemEnumerable.Create( 1 ) ) );
    Assert(
        !SystemEnumerable.Create( 1, 2 )
        .StartsWith( SystemEnumerable.Create( 1, 2, 3 ) ) );

    Print( ".IndexOf()" );
    Assert(
        Enumerable.Empty< int >()
        .IndexOf( Enumerable.Empty< int >() )
        == 0 );
    Assert(
        Enumerable.Empty< int >()
        .IndexOf( SystemEnumerable.Create( 1 ) )
        == -1 );
    Assert(
        SystemEnumerable.Create( 1 )
        .IndexOf( Enumerable.Empty< int >() )
        == 0 );
    Assert(
        SystemEnumerable.Create( 1, 2, 3 )
        .IndexOf( SystemEnumerable.Create( 1, 2, 3 ) )
        == 0 );
    Assert(
        SystemEnumerable.Create( 1, 2, 3, 4 )
        .IndexOf( SystemEnumerable.Create( 1, 2, 3 ) )
        == 0 );
    Assert(
        SystemEnumerable.Create( 1, 2, 3 )
        .IndexOf( SystemEnumerable.Create( 1, 2, 3, 4 ) )
        == -1 );
    Assert(
        SystemEnumerable.Create( 1, 2, 3, 4 )
        .IndexOf( SystemEnumerable.Create( 2, 3, 4 ) )
        == 1 );
    Assert(
        SystemEnumerable.Create( 1, 2, 3, 2, 3 )
        .IndexOf( SystemEnumerable.Create( 2, 3 ) )
        == 1 );
}


[Test( "SystemException" )]
public static
void
Test_SystemException()
{
    Print( ".ExceptionChain()" );
    System.Exception e = new System.Exception();
    System.Exception f = new System.Exception( "", e );
    System.Exception g = new System.Exception( "", f );
    System.Exception h = new System.Exception( "", g );
    Assert(
        h.ExceptionChain()
        .SequenceEqual( SystemEnumerable.Create( h, g, f, e ) ) );
}


public interface A : IEquatableHD< A > {}
public interface B : IEquatableHD< B > {}
public interface AA : A {}
public class C : A, B {
    public bool Equals(
        A that
    ) {
        return true;
    }
    int IEquatableHD<A>.GetHashCode() {
        return 0xCA;
    }
    public bool Equals(
        B that
    ) {
        return true;
    }
    int IEquatableHD<B>.GetHashCode() {
        return 0xCB;
    }
    public override bool Equals( object that ) { throw new System.Exception(); }
    public override int GetHashCode() { throw new System.Exception(); }
}
public class D : A, B {
    public bool Equals(
        A that
    ) {
        return false;
    }
    int IEquatableHD<A>.GetHashCode() {
        return 0xDA;
    }
    public bool Equals(
        B that
    ) {
        return true;
    }
    int IEquatableHD<B>.GetHashCode() {
        return 0xDB;
    }
    public override bool Equals( object that ) { throw new System.Exception(); }
    public override int GetHashCode() { throw new System.Exception(); }
}


[Test( "IEquatableHD< T >" )]
public static
void
Test_IEquatableHD_T()
{
    C c = new C();
    D d = new D();
    A ca = c;
    B cb = c;
    A da = d;
    B db = d;

    Print( ".GetHashCode()" );
    Assert( ca.GetHashCode() == 0xCA  );
    Assert( cb.GetHashCode() == 0xCB  );

    Print( ".EqualsBidirectional()" );
    Assert( ca.EqualsBidirectional( ca ) );
    Assert( !( da.EqualsBidirectional( da ) ) );

    Print( ".Equals() requires both items to agree" );
    Assert( !( ca.EqualsBidirectional( da ) ) );
    Assert( cb.EqualsBidirectional( db ) );
}


[Test( "EqualityComparerHD< T >" )]
public static
void
Test_EqualityComparerHD_T()
{
    EqualsFunc< string > e1 = (s,t) => s == t;
    EqualsFunc< string > e2 = (s,t) => s == t;
    EqualsFunc< string > e3 =
        (s,t) => s.ToLowerInvariant() == t.ToLowerInvariant();
    GetHashCodeFunc< string > hc1 = s => s.GetHashCode();
    GetHashCodeFunc< string > hc2 = s => s.GetHashCode();
    GetHashCodeFunc< string > hc3 = s => s.ToLowerInvariant().GetHashCode();
    var c1 = EqualityComparerHD.Create< string >( e1, hc1 );
    var c3 = EqualityComparerHD.Create< string >( e3, hc3 );

    Print( ".Equals() and .GetHashCode()" );
    Assert( c1.Equals( "abc", "abc" ) );
    Assert( !c1.Equals( "abc", "def" ) );
    Assert( c1.GetHashCode( "abc" ) == c1.GetHashCode( "abc" ) );
    Assert( c3.Equals( "abc", "ABC" ) );
    Assert( !c3.Equals( "abc", "def" ) );

    Print( "Equality of comparers" );
    Assert(
        EqualityComparerHD.Create( e1, hc1 ).Equals(
        EqualityComparerHD.Create( e1, hc1 ) ) );
    Assert( !
        EqualityComparerHD.Create( e1, hc1 ).Equals(
        EqualityComparerHD.Create( e2, hc1 ) ) );
    Assert( !
        EqualityComparerHD.Create( e1, hc1 ).Equals(
        EqualityComparerHD.Create( e1, hc2 ) ) );
}


[Test( "EquatableEqualityComparerHD< T >" )]
public static
void
Test_EquatableEqualityComparerHD_T()
{
    var ic = EqualityComparerHD.Create< int >();
    var ic2 = EqualityComparerHD.Create< int >();
    var ac = EqualityComparerHD.Create< A >();
    var bc = EqualityComparerHD.Create< B >();
    var c = new C();

    Print( "Equals(), IEquatable<T>" );
    Assert( ic.Equals( 1, 1 ) );
    Assert( !ic.Equals( 1, 2 ) );

    Print( "GetHashCode(), IEquatable<T>" );
    Assert( ic.GetHashCode( 1 ) == 1.GetHashCode() );

    Print( "GetHashCode(), IEquatableHD<T>" );
    Assert( ac.GetHashCode( c ) == 0xCA );
    Assert( bc.GetHashCode( c ) == 0xCB );

    Print( "Comparer equality" );
    Assert( ic.EqualsBidirectional( (IEqualityComparerHD)ic2 ) );
}


public interface I : IComparableHD< I > {}
public interface II : I {}
public interface J : IComparableHD< J > {}
public class AlwaysBigger : I {
    // IComparable< I >
    public int CompareTo( I that ) {
        return 1;
    }
    // IEquatableHD< I >
    public bool Equals(
        I that
    ) {
        return false;
    }
    // IEquatableHD< I >
    int IEquatableHD<I>.GetHashCode() {
        return 1;
    }
    // System.Object
    public override bool Equals( object that ) { throw new System.Exception(); }
    public override int GetHashCode() { throw new System.Exception(); }
}
public class AlwaysEqual : I {
    // IComparable< I >
    public int CompareTo( I that ) {
        return 0;
    }
    // IEquatableHD< I >
    public bool Equals(
        I that
    ) {
        return true;
    }
    // IEquatableHD< I >
    int IEquatableHD<I>.GetHashCode() {
        return 0;
    }
    // System.Object
    public override bool Equals( object that ) { throw new System.Exception(); }
    public override int GetHashCode() { throw new System.Exception(); }
}
public class AlwaysSmaller : I {
    // IComparable< I >
    public int CompareTo( I that ) {
        return -1;
    }
    // IEquatableHD< I >
    public bool Equals(
        I that
    ) {
        return false;
    }
    // IEquatableHD< I >
    int IEquatableHD<I>.GetHashCode() {
        return 0;
    }
    // System.Object
    public override bool Equals( object that ) { throw new System.Exception(); }
    public override int GetHashCode() { throw new System.Exception(); }
}


[Test( "IComparableHD< T >" )]
public static
void
Test_IComparableHD()
{
    I bigger = new AlwaysBigger();
    I equal = new AlwaysEqual();
    I smaller = new AlwaysSmaller();

    Print( "Same result yields that result" );
    Assert( equal.CompareToBidirectional( equal ) == 0 );
    Assert( equal.GTE( equal ) );
    Assert( equal.LTE( equal ) );
    Assert( bigger.CompareToBidirectional( smaller ) > 0 );
    Assert( bigger.GT( smaller ) );
    Assert( bigger.GTE( smaller ) );
    Assert( smaller.CompareToBidirectional( bigger ) < 0 );
    Assert( smaller.LT( bigger ) );
    Assert( smaller.LTE( bigger ) );

    Print( "One equal, other greater/less than yields greater/less than" );
    Assert( bigger.CompareToBidirectional( equal ) > 0 );
    Assert( bigger.GT( equal ) );
    Assert( bigger.GTE( equal ) );
    Assert( smaller.CompareToBidirectional( equal ) < 0 );
    Assert( smaller.LT( equal ) );
    Assert( smaller.LTE( equal ) );
    Assert( equal.CompareToBidirectional( smaller ) > 0 );
    Assert( equal.GT( smaller ) );
    Assert( equal.GTE( smaller ) );
    Assert( equal.CompareToBidirectional( bigger ) < 0 );
    Assert( equal.LT( bigger ) );
    Assert( equal.LTE( bigger ) );

    Print( "Opposite results throws ComparisonDisagreementException" );
    Expect< ComparisonDisagreementException >(
        () => bigger.CompareToBidirectional( bigger ) );
    Expect< ComparisonDisagreementException >(
        () => smaller.CompareToBidirectional( smaller ) );
}


[Test( "ComparerHD< T >" )]
public static
void
Test_ComparerHD_T()
{
    CompareFunc< int > cf1 = (x,y) => x.CompareTo( y );
    CompareFunc< int > cf2 = (x,y) => x.CompareTo( y );
    GetHashCodeFunc< int > hcf1 = x => x.GetHashCode();
    GetHashCodeFunc< int > hcf2 = x => x.GetHashCode();


    Print( ".Compare(), .Equals(), .GetHashCode() (implicit .Equals())" );
    var c1 = ComparerHD.Create( cf1, hcf1 );
    Assert( c1.Compare( 5, 5 ) == 0 );
    Assert( c1.Compare( 0, 5 ) < 0 );
    Assert( c1.Compare( 10, 5 ) > 0 );
    Assert( c1.Equals( 5, 5 ) );
    Assert( !c1.Equals( 5, 10 ) );
    Assert( c1.GetHashCode( 5 ) == c1.GetHashCode( 5 ) );

    Print( "Comparer equality" );
    Assert( c1.Equals(
        (IComparerHD)( ComparerHD.Create( cf1, hcf1 ) ) ) );
    Assert( !c1.Equals(
        (IComparerHD)( ComparerHD.Create( cf2, hcf1 ) ) ) );
    Assert( !c1.Equals(
        (IComparerHD)( ComparerHD.Create( cf1, hcf2 ) ) ) );
}


[Test( "ComparableComparerHD< T >" )]
public static
void
Test_ComparableComparerHD_T()
{
    var c = ComparerHD.Create< int >();
    var c2 = ComparerHD.Create< int >();
    var c3 = ComparerHD.Create< I >();

    Print( "Compare(), IComparable<T>" );
    Assert( c.Compare( 1, 1 ) == 0 );
    Assert( c.Compare( 1, 2 ) < 0 );
    Assert( c.Compare( 2, 1 ) > 0 );

    Print( "GetHashCode(), IComparable<T>" );
    Assert( c.GetHashCode( 1 ) == 1.GetHashCode() );

    Print( "GetHashCode(), IComparableHD<T>" );
    Assert( c3.GetHashCode( new AlwaysBigger() ) == 1 );

    Print( "Comparer equality" );
    Assert( c.Equals( (IComparerHD)c ) );
    Assert( c.Equals( (IComparerHD)c2 ) );
    Assert( !c.Equals( (IComparerHD)c3 ) );

    Print( "Comparer equality, as IEqualityComparerHD" );
    Assert( c.Equals( (IEqualityComparerHD)c ) );
    Assert( c.Equals( (IEqualityComparerHD)c2 ) );
    Assert( c.Equals( EqualityComparerHD.Create< int >() ) );
    Assert( !c.Equals( (IEqualityComparerHD)c3 ) );
}


[Test( "EnumerableComparer< T >" )]
public static
void
Test_EnumerableComparer_T()
{
    var c = EnumerableComparer.Create(
        EqualityComparerHD.Create< int >(
            (x,y) => x == y,
            x => x.GetHashCode() ) );

    Print( ".Equals()" );
    Assert( c.Equals(
        new int[]{ 1, 2, 3 },
        new int[]{ 1, 2, 3 } ) );
    Assert( !c.Equals(
        new int[]{ 1, 2, 3 },
        new int[]{ 4, 5, 6 } ) );

    Print( ".GetHashCode()" );
    Assert(
        c.GetHashCode( new int[]{ 1, 2, 3 } )
        == c.GetHashCode( new int[]{ 1, 2, 3 } ) );
}


public class TestComparable : IComparable< TestComparable >
{
    public int CompareTo( TestComparable that )
    {
        return 0;
    }

    public override int GetHashCode()
    {
        return 0x0B;
    }
}


public class TestComparableHD : IComparableHD< TestComparableHD >
{
    public int CompareTo( TestComparableHD that )
    {
        return 0;
    }

    public bool Equals( TestComparableHD that )
    {
        return this.CompareTo( that ) == 0;
    }

    int IEquatableHD< TestComparableHD >.GetHashCode()
    {
        return 0xC0;
    }

    public override int GetHashCode()
    {
        throw new Exception();
    }
}


[Test( "Interval" )]
public static void
Test_Interval()
{
    int smaller = 1;
    int from = 5;
    int between = 7;
    int to = 10;
    int bigger = 15;

    IInterval< int > inc = Interval.Create( from, to );
    IInterval< int > exc = Interval.Create( from, false, to, false );
    IInterval< int > frominc = Interval.Create( from, true, to, false );
    IInterval< int > toinc = Interval.Create( from, false, to, true );
    IInterval< int > anotherinc = Interval.Create( from, to );

    Print( "Both Inclusive" );
    Assert( !inc.Contains( smaller ) );
    Assert( inc.Contains( from ) );
    Assert( inc.Contains( between ) );
    Assert( inc.Contains( to ) );
    Assert( !inc.Contains( bigger ) );

    Print( "Both Exclusive" );
    Assert( !exc.Contains( smaller ) );
    Assert( !exc.Contains( from ) );
    Assert( exc.Contains( between ) );
    Assert( !exc.Contains( to ) );
    Assert( !exc.Contains( bigger ) );

    Print( "From Inclusive" );
    Assert( !frominc.Contains( smaller ) );
    Assert( frominc.Contains( from ) );
    Assert( frominc.Contains( between ) );
    Assert( !frominc.Contains( to ) );
    Assert( !frominc.Contains( bigger ) );

    Print( "To Inclusive" );
    Assert( !toinc.Contains( smaller ) );
    Assert( !toinc.Contains( from ) );
    Assert( toinc.Contains( between ) );
    Assert( toinc.Contains( to ) );
    Assert( !toinc.Contains( bigger ) );

    Print( "ToString()" );
    Print( inc.ToString() );
    Print( exc.ToString() );
    Print( frominc.ToString() );
    Print( toinc.ToString() );

    Print( ".Equals()" );
    Assert( inc.Equals( anotherinc ) );
    Assert( !inc.Equals( exc ) );

    Print( ".GetHashCode()" );
    Assert( inc.GetHashCode() == anotherinc.GetHashCode() );

    Print( "Static Create() distinguishes IComparable(HD)<T>" );
    Assert(
        Interval.Create( new TestComparable(), new TestComparable() )
            .GetHashCodeFunc( new TestComparable() ) == 0x0B );
    Assert(
        Interval.Create( new TestComparableHD(), new TestComparableHD() )
            .GetHashCodeFunc( new TestComparableHD() ) == 0xC0 );
}


[Test( "TupleHD" )]
public static void
Test_TupleHD()
{
    ITupleHD< object, object > objects;

    Print( "Make a tuple of strings" );
    var strings = TupleHD.Create( "A", "B" );

    Print( "Check strings" );
    Assert( strings.A == "A" );
    Assert( strings.B == "B" );

    Print( "AssignTo() variables and check" );
    string a;
    string b;
    strings.AssignTo( out a, out b );
    Assert( a == "A" );
    Assert( b == "B" );

#if DOTNET40
    Print( "C# covary to objects" );
    objects = strings;

    Print( "Check objects" );
    Assert( objects.A.Equals( "A" ) );
    Assert( objects.B.Equals( "B" ) );
#endif

    Print( "Covary() to objects" );
    objects = strings.Covary< string, string, object, object >();

    Print( "Check objects" );
    Assert( objects.A.Equals( "A" ) );
    Assert( objects.B.Equals( "B" ) );

    Print( "Make a tuple of ints" );
    var ints = TupleHD.Create( 1, 2 );

    Print( "Check ints" );
    Assert( ints.A == 1 );
    Assert( ints.B == 2 );

    Print( "ITuple.BothEqual( a, b )" );
    Assert( strings.BothEqual( "A", "B" ) );
    Assert( !strings.BothEqual( "A", "X" ) );
    Assert( !strings.BothEqual( "X", "B" ) );
    Assert( !strings.BothEqual( "X", "X" ) );

#if DOTNET40
    Print( "(C# doesn't vary value types)" );
#endif

    Print( "Covary() to objects" );
    objects = ints.Covary< int, int, object, object >();

    Print( "Check objects" );
    Assert( objects.A.Equals( 1 ) );
    Assert( objects.B.Equals( 2 ) );
}


#if DOTNET40
[Test( "TupleAsTupleHD" )]
public static void
Test_TupleAsTupleHD()
{
    Print( "Make a tuple of strings out of a System.Tuple" );
    var strings =
        new System.Tuple< string, string >( "A", "B" )
        .AsTupleHD();

    Print( "Check strings" );
    Assert( strings.A == "A" );
    Assert( strings.B == "B" );
}
#endif


#if DOTNET40
[Test( "ITupleHD.AsTuple()" )]
public static void
Test_ITupleHDAsTuple()
{
    Print( "Make a System.Tuple of strings out of an ITuple" );
    var strings =
        TupleHD.Create( "A", "B" )
        .AsTuple();

    Print( "Check strings" );
    Assert( strings.Item1 == "A" );
    Assert( strings.Item2 == "B" );
}
#endif


[Test( "Maybe" )]
public static void
Test_Maybe()
{
    IMaybe< string > m;
    IMaybe< object > mo;
    ITupleHD< bool, string > t;
    bool success = false;

    Print( "Without value" );
    m = Maybe.Create< string >();
    Assert( !m.HasValue );
    Expect< System.InvalidOperationException>( () => {
        if( m.Value == null ) {} } );

    Print( "Without value, as tuple" );
    t = m;
    Assert( !t.A );
    Assert( t.B == default( string ) );

    Print( "With value" );
    m = Maybe.Create( "abc" );
    Assert( m.HasValue );
    Assert( m.Value == "abc" );

    Print( "With value, as tuple" );
    t = m;
    Assert( t.A );
    Assert( t.B == "abc" );

    Print( "With value, covaried explicitly" );
    mo = m.Covary< string, object >();
    Assert( mo.HasValue );
    Assert( m.Value.Equals( "abc" ) );

    #if DOTNET40
    Print( "With value, covaried implicitly" );
    mo = m;
    Assert( mo.HasValue );
    Assert( m.Value.Equals( "abc" ) );
    #endif

    Print( ".If( Func<T,U> )" );
    Assert(
        Maybe.Create( "a" )
        .If( s => 1 )
        .Value == 1 );
    Assert(
        Maybe.Create< string >()
        .If( s => 1 )
        .HasValue == false );

    Print( ".If( Action<T>, Action )" );
    success = false;
    Maybe.Create( "a" )
        .If(
            s => { success = true; },
            () => { success = false; } );
    Assert( success );
    success = false;
    Maybe.Create< string >()
        .If(
            s => { success = false; },
            () => { success = true; } );
    Assert( success );

    Print( ".Else( Func< T > )" );
    Assert(
        Maybe.Create( "good" )
        .Else( () => "bad" )
        == "good" );
    Assert(
        Maybe.Create< string >()
        .Else( () => "good" )
        == "good" );

    Print( ".Else( T )" );
    Assert(
        Maybe.Create( "good" )
        .Else( "bad" )
        == "good" );
    Assert(
        Maybe.Create< string >()
        .Else( "good" )
        == "good" );
}




} // type
} // namespace

