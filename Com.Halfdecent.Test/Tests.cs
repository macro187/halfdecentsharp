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


public interface A : Halfdecent.IEquatable< A > {}
public interface B : Halfdecent.IEquatable< B > {}
public interface AA : A {}
public class C : A, B {
    public bool Equals( A that ) {
        return Equatable.Equals( this, that );
    }
    public bool DirectionalEquals(
        A that
    ) {
        return true;
    }
    int Halfdecent.IEquatable<A>.GetHashCode() {
        return 0xCA;
    }
    public bool Equals( B that ) {
        return Equatable.Equals( this, that );
    }
    public bool DirectionalEquals(
        B that
    ) {
        return true;
    }
    int Halfdecent.IEquatable<B>.GetHashCode() {
        return 0xCB;
    }
    public override bool Equals( object that ) { throw new System.Exception(); }
    public override int GetHashCode() { throw new System.Exception(); }
}
public class D : A, B {
    public bool Equals( A that ) {
        return Equatable.Equals( this, that );
    }
    public bool DirectionalEquals(
        A that
    ) {
        return false;
    }
    int Halfdecent.IEquatable<A>.GetHashCode() {
        return 0xDA;
    }
    public bool Equals( B that ) {
        return Equatable.Equals( this, that );
    }
    public bool DirectionalEquals(
        B that
    ) {
        return true;
    }
    int Halfdecent.IEquatable<B>.GetHashCode() {
        return 0xDB;
    }
    public override bool Equals( object that ) { throw new System.Exception(); }
    public override int GetHashCode() { throw new System.Exception(); }
}


[Test( "IEquatable< T >" )]
public static
void
Test_IEquatable_T()
{
    C c = new C();
    D d = new D();
    A ca = c;
    B cb = c;
    A da = d;
    B db = d;

    Print( "Per-interface .GetHashCode()" );
    Assert( ca.GetHashCode() == 0xCA  );
    Assert( cb.GetHashCode() == 0xCB  );

    Print( "Per-interface .Equals()" );
    Assert( ca.Equals( ca ) );
    Assert( !( da.Equals( da ) ) );

    Print( ".Equals() requires both items to agree" );
    Assert( !( ca.Equals( da ) ) );
    Assert( cb.Equals( db ) );
}


[Test( "EqualityComparer< T >" )]
public static
void
Test_EqualityComparer_T()
{
    System.Func< string, string, bool> equalsfunc =
        (s1,s2) => s1 == s2;
    System.Func< string, int > gethashcodefunc =
        s => s.GetHashCode();
    IEqualityComparer< string > c1 =
        new EqualityComparer< string >(
            equalsfunc,
            gethashcodefunc );
    IEqualityComparer< string > c2 =
        new EqualityComparer< string >(
            equalsfunc,
            gethashcodefunc );
    IEqualityComparer< string > c3 =
        new EqualityComparer< string >(
            (s1,s2) => s1.ToLowerInvariant() == s2.ToLowerInvariant(),
            s => s.ToLowerInvariant().GetHashCode() );

    Print( "Equality of EqualityComparers" );
    Assert( c1.Equals( c2 ) );
    Assert( c2.Equals( c1 ) );
    Assert( !c1.Equals( c3 ) );
    Assert( !c3.Equals( c1 ) );

    Print( "EqualityComparer Functionality" );
    Assert( c1.Equals( "abc", "abc" ) );
    Assert( !c1.Equals( "abc", "def" ) );
    Assert( c1.GetHashCode( "abc" ) == c1.GetHashCode( "abc" ) );
    Assert( c3.Equals( "abc", "ABC" ) );
    Assert( !c3.Equals( "abc", "def" ) );
}


[Test( "EquatableComparer< T >" )]
public static
void
Test_EquatableComparer_T()
{
    C c = new C();
    D d = new D();

    IEqualityComparer< A > acomparer = new EquatableComparer< A >();
    IEqualityComparer< B > bcomparer = new EquatableComparer< B >();

    Print( "Calls underlying IEquatable<T>s correctly" );
    Assert( acomparer.GetHashCode( c ) == 0xCA  );
    Assert( bcomparer.GetHashCode( c ) == 0xCB  );
    Assert( acomparer.Equals( c, c ) );
    Assert( !acomparer.Equals( d, d ) );
    Assert( !( acomparer.Equals( c, d ) ) );
    Assert( bcomparer.Equals( c, d ) );

    Print( "Implements IEquatable< IEqualityComparer > correctly" );
    Assert( acomparer.Equals( acomparer ) );
    Assert(
        new EquatableComparer< A >().Equals(
        new EquatableComparer< A >() ) );
    Assert( !acomparer.Equals( bcomparer ) );
}


[Test( "EqualityComparerProxy< T >" )]
public static
void
Test_EqualityComparerProxy_T()
{
    IEqualityComparer< A >  acomparer = new EquatableComparer< A >();
    IEqualityComparer< B >  bcomparer = new EquatableComparer< B >();
    IEqualityComparer< AA > aacomparer = acomparer.Contravary< A, AA >();

    Print( "Adapter Equals() underlying" );
    Assert( aacomparer.Equals( acomparer ) );

    Print( "Adapter has same hash code as underlying" );
    Assert( aacomparer.GetHashCode() == acomparer.GetHashCode() );

    Print( "Adapter !Equals() comparer for a different type" );
    Assert( !aacomparer.Equals( bcomparer ) );
}


[Test( "ObjectComparer" )]
public static
void
Test_ObjectComparer_T()
{
    Print( "Equality" );
    Assert(
        new ObjectComparer().Equals(
        new ObjectComparer() ) );
    Assert(
        new ObjectComparer().GetHashCode() ==
        new ObjectComparer().GetHashCode() );
    Assert( !(
        new ObjectComparer().Equals(
        new EquatableComparer< A >() ) ) );

    IEqualityComparer<object> oc = new ObjectComparer();

    object obja = new object();
    object objb = new object();

    Print( "Works properly on System.Object" );
    Assert( oc.Equals( obja, obja ) );
    Assert( !oc.Equals( obja, objb ) );

    // Make an effort to prevent interning so we compare different
    // string instances
    string sa = new string( 'a', 1 );
    string sb = new string( 'b', 1 );
    string sa2 = new string( 'a', 1 );

    Print( "Works properly on System.String" );
    Assert( oc.Equals( sa, sa ) );
    Assert( !oc.Equals( sa, sb ) );
    Assert( oc.Equals( sa, sa2 ) );
}


[Test( "ReferenceComparer" )]
public static
void
Test_ReferenceComparer_T()
{
    Print( "Equality" );
    Assert(
        new ReferenceComparer().Equals(
        new ReferenceComparer() ) );
    Assert(
        new ReferenceComparer().GetHashCode() ==
        new ReferenceComparer().GetHashCode() );
    Assert( !(
        new ReferenceComparer().Equals(
        new EquatableComparer< A >() ) ) );

    IEqualityComparer<object> c = new ReferenceComparer();

    object o = new object();
    object p = new object();

    Print( "Works properly on System.Object" );
    Assert( c.Equals( o, o ) );
    Assert( !c.Equals( o, p ) );

    string s = new string( 'a', 1 );
    string t = new string( 'a', 1 );

    Print( "Works properly on System.String even if they're the same" );
    Assert( c.Equals( s, s ) );
    Assert( !c.Equals( s, t ) );

    // Don't bother with GetHashCode() because it doesn't work properly anyway
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


[Test( "IComparable< T >" )]
public static
void
Test_IComparable()
{
    I bigger = new AlwaysBigger();
    I equal = new AlwaysEqual();
    I smaller = new AlwaysSmaller();

    Print( "Comparison with nulls" );
    Assert( bigger.CompareTo( null ) > 0 );
    Assert( bigger.GT( null ) );
    Assert( bigger.GTE( null ) );
    Assert( equal.CompareTo( null ) > 0 );
    Assert( equal.GT( null ) );
    Assert( equal.GTE( null ) );
    Assert( smaller.CompareTo( null ) > 0 );
    Assert( smaller.GT( null ) );
    Assert( smaller.GTE( null ) );

    Print( "Same result yields that result" );
    Assert( equal.CompareTo( equal ) == 0 );
    Assert( equal.GTE( equal ) );
    Assert( equal.LTE( equal ) );
    Assert( bigger.CompareTo( smaller ) > 0 );
    Assert( bigger.GT( smaller ) );
    Assert( bigger.GTE( smaller ) );
    Assert( smaller.CompareTo( bigger ) < 0 );
    Assert( smaller.LT( bigger ) );
    Assert( smaller.LTE( bigger ) );

    Print( "One equal, other greater/less than yields greater/less than" );
    Assert( bigger.CompareTo( equal ) > 0 );
    Assert( bigger.GT( equal ) );
    Assert( bigger.GTE( equal ) );
    Assert( smaller.CompareTo( equal ) < 0 );
    Assert( smaller.LT( equal ) );
    Assert( smaller.LTE( equal ) );
    Assert( equal.CompareTo( smaller ) > 0 );
    Assert( equal.GT( smaller ) );
    Assert( equal.GTE( smaller ) );
    Assert( equal.CompareTo( bigger ) < 0 );
    Assert( equal.LT( bigger ) );
    Assert( equal.LTE( bigger ) );

    Print( "Opposite results throws ComparisonDisagreementException" );
    Expect< ComparisonDisagreementException >(
        () => bigger.CompareTo( bigger ) );
    Expect< ComparisonDisagreementException >(
        () => smaller.CompareTo( smaller ) );
}


[Test( "ComparableComparer< T >" )]
public static
void
Test_ComparableComparer_T()
{
    I bigger = new AlwaysBigger();
    I equal = new AlwaysEqual();
    I smaller = new AlwaysSmaller();

    IComparer< I > c = new ComparableComparer< I >();
    IComparer< J > d = new ComparableComparer< J >();

    Print( "Calls underlying IComparable<T>s correctly" );
    Assert( c.Compare( bigger, null ) > 0 );
    Assert( c.Compare( equal, null ) > 0 );
    Assert( c.Compare( smaller, null ) > 0 );
    Assert( c.Compare( equal, equal ) == 0 );
    Assert( c.Compare( bigger, smaller ) > 0 );
    Assert( c.Compare( smaller, bigger ) < 0 );
    Assert( c.Compare( bigger, equal ) > 0 );
    Assert( c.Compare( smaller, equal ) < 0 );
    Assert( c.Compare( equal, smaller ) > 0 );
    Assert( c.Compare( equal, bigger ) < 0 );
    Expect< ComparisonDisagreementException >(
        () => c.Compare( bigger, bigger ) );
    Expect< ComparisonDisagreementException >(
        () => c.Compare( smaller, smaller ) );

    Print( "Calls underlying IEquatable<T>s correctly" );
    Assert( c.Equals( equal, equal ) );
    Assert( !c.Equals( equal, bigger ) );
    Assert( !c.Equals( bigger, bigger ) );
    Assert( !c.Equals( bigger, smaller ) );
    Assert( !c.Equals( equal, null ) );
    Assert( !c.Equals( bigger, null ) );
    Assert( c.GetHashCode( equal ) == 0  );
    Assert( c.GetHashCode( bigger ) == 1  );

    Print( "Implements IEquatable< IEqualityComparer > correctly" );
    Assert( c.Equals( c ) );
    Assert(
        new ComparableComparer< I >().Equals(
        new ComparableComparer< I >() ) );
    Assert( !c.Equals( d ) );
}


[Test( "Comparer< T >" )]
public static
void
Test_Comparer_T()
{
    IComparer< int > c = new Comparer< int >(
        ( a, b ) => a.CompareTo( b ),
        ( a ) => a.GetHashCode() );

    Print( "Compare()" );
    Assert( c.Compare( 5, 5 ) == 0 );
    Assert( c.Compare( 0, 5 ) < 0 );
    Assert( c.Compare( 10, 5 ) > 0 );

    Print( "Equals()" );
    Assert( c.Equals( 5, 5 ) );
    Assert( !c.Equals( 5, 10 ) );

    Print( "GetHashCode()" );
    Assert( c.GetHashCode( 5 ) == c.GetHashCode( 5 ) );
}


[Test( "ComparerProxy< T >" )]
public static
void
Test_ComparerProxy_T()
{
    IComparer< I >  icomparer = new ComparableComparer< I >();
    IComparer< J >  jcomparer = new ComparableComparer< J >();
    IComparer< II > iicomparer = icomparer.Contravary< I, II >();

    Print( "Adapter Equals() underlying" );
    Assert( iicomparer.Equals( icomparer ) );

    Print( "Adapter has same hash code as underlying" );
    Assert( iicomparer.GetHashCode() == icomparer.GetHashCode() );

    Print( "Adapter !Equals() comparer for a different type" );
    Assert( !iicomparer.Equals( jcomparer ) );
}


[Test( "SystemEnumerableComparer< T >" )]
public static
void
Test_SystemEnumerableComparer_T()
{
    IEqualityComparer< SCG.IEnumerable< int > > c
        = SystemEnumerableComparer.Create< int >(
            new SystemEquatableComparer< int >() );

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

    Print( "IEquatable< IEqualityComparer >" );
    Assert(
        c.Equals(
            // (an equal item comparer)
            new SystemEnumerableComparer< int >(
                new SystemEquatableComparer< int >() ) ) );
    Assert(
        !c.Equals(
            // (a different item comparer)
            new Comparer< int >( (a,b) => 0, a => 0 ) ) );
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
}


[Test( "Tuple" )]
public static void
Test_Tuple()
{
    ITuple< object, object > objects;

    Print( "Make a tuple of strings" );
    ITuple< string, string > strings =
        new Tuple< string, string >( "A", "B" );
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
    ITuple< int, int > ints = new Tuple< int, int >( 1, 2 );
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
[Test( "TupleFromSystemTupleAdapter" )]
public static void
Test_TupleFromSystemTupleAdapter()
{
    Print( "Make a tuple of strings out of a System.Tuple" );
    ITuple< string, string > strings =
        new System.Tuple< string, string >( "A", "B" )
        .AsHalfdecentTuple();
    Print( "Check strings" );
    Assert( strings.A == "A" );
    Assert( strings.B == "B" );
}
#endif


#if DOTNET40
[Test( "ITuple.AsSystemTuple()" )]
public static void
Test_ITupleAsSystemTuple()
{
    Print( "Make a System.Tuple of strings out of an ITuple" );
    System.Tuple< string, string > strings =
        new Tuple< string, string >( "A", "B" )
        .AsSystemTuple();
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
    ITuple< bool, string > t;
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
}




} // type
} // namespace

