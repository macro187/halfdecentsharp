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



[Test( "EnumerableUtils" )]
public static
void
Test_EnumerableUtils()
{
    Print( ".Append()" );
    Assert(
        new int[]{ 1, 2, 3 }
        .Append( 4 )
        .SequenceEqual( new int[]{ 1, 2, 3, 4 } ) );

    Print( ".Covary< TTo >()" );
    Assert(
        new int[]{ 1, 2, 3 }
        .Covary< int, object >()
        .SequenceEqual(
            new object[]{ 1, 2, 3 } ) );

    Print( ".AsSingleItemEnumerable()" );
    Assert(
        1.AsSingleItemEnumerable()
        .SequenceEqual(
            new int[]{ 1 } ) );
}


[Test( "ExceptionUtils" )]
public static
void
Test_ExceptionUtils()
{
    System.Exception e = new System.Exception();
    System.Exception f = new System.Exception( "", e );
    System.Exception g = new System.Exception( "", f );
    System.Exception h = new System.Exception( "", g );
    Print( ".Chain()" );
    Assert(
        h.Chain()
        .SequenceEqual(
            Enumerable.Empty< System.Exception >()
            .Append( h )
            .Append( g )
            .Append( f )
            .Append( e ) ) );
}


[Test( "ObjectUtils" )]
public static
void
Test_ObjectUtils()
{
    Print( ".ToString()" );
    AssertEqual( ObjectUtils.ToString( null ), "null" );
    AssertEqual( ObjectUtils.ToString( "notnull" ), "notnull" );
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


[Test( "EqualityComparerAdapter< T >" )]
public static
void
Test_EqualityComparerAdapter_T()
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


public interface I : IComparable< I > {}
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
    Assert( equal.CompareTo( null ) > 0 );
    Assert( smaller.CompareTo( null ) > 0 );

    Print( "Same result yields that result" );
    Assert( equal.CompareTo( equal ) == 0 );
    Assert( bigger.CompareTo( smaller ) > 0 );
    Assert( smaller.CompareTo( bigger ) < 0 );

    Print( "One equal, other greater/less than yields greater/less than" );
    Assert( bigger.CompareTo( equal ) > 0 );
    Assert( smaller.CompareTo( equal ) < 0 );
    Assert( equal.CompareTo( smaller ) > 0 );
    Assert( equal.CompareTo( bigger ) < 0 );

    Print( "Opposite results throws ComparisonDisagreementException" );
    Expect< ComparisonDisagreementException >(
        () => bigger.CompareTo( bigger ) );
    Expect< ComparisonDisagreementException >(
        () => smaller.CompareTo( smaller ) );
}




} // type
} // namespace

