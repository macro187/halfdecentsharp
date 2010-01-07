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




} // type
} // namespace

