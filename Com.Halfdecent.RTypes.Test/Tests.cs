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
using Com.Halfdecent.Globalisation;
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


private class
FakeRType
    : RType< object >
{
    public
    FakeRType()
        : base (
            obj => true,
            r => "fake",
            r => "fake",
            r => "fake" )
    {}
}


private class
FakeRType2
    : RType< object >
{
    public
    FakeRType2()
        : base (
            obj => true,
            r => "fake2",
            r => "fake2",
            r => "fake2" )
    {}
}


[Test( "RTypeException" )]
public static
void
Test_RTypeException()
{
    bool ok;

    Print( "void Match(), match" );
    ok = false;
    try {
        throw new ValueReferenceException(
            new Frame().Local( "local" ),
            new RTypeException( new FakeRType() ) );
    } catch( System.Exception e ) {
        RTypeException.Match(
            e,
            (vr,f) => vr.Equals( f.Local( "local" ) ),
            rt => rt is FakeRType,
            (vr,f,rte) => ok = true );
    }
    Assert( ok );

    Print( "void Match(), value reference mismatch" );
    ok = false;
    try {
        throw new ValueReferenceException(
            new Frame().Local( "local" ),
            new RTypeException( new FakeRType() ) );
    } catch( System.Exception e ) {
        ok = true;
        RTypeException.Match(
            e,
            (vr,f) => !( vr.Equals( f.Local( "local" ) ) ),
            rt => rt is FakeRType,
            (vr,f,rte) => ok = false );
    }
    Assert( ok );

    Print( "void Match(), rtype mismatch" );
    ok = false;
    try {
        throw new ValueReferenceException(
            new Frame().Local( "local" ),
            new RTypeException( new FakeRType() ) );
    } catch( System.Exception e ) {
        ok = true;
        RTypeException.Match(
            e,
            (vr,f) => vr.Equals( f.Local( "local" ) ),
            rt => !( rt is FakeRType ),
            (vr,f,rte) => ok = false );
    }
    Assert( ok );

    Print( "bool Match(), match" );
    ok = false;
    try {
        throw new ValueReferenceException(
            new Frame().Local( "local" ),
            new RTypeException( new FakeRType() ) );
    } catch( System.Exception e ) {
        ok = RTypeException.Match(
            e,
            (vr,f) => vr.Equals( f.Local( "local" ) ),
            rt => rt is FakeRType );
    }
    Assert( ok );

    Print( "bool Match(), value reference mismatch" );
    ok = false;
    try {
        throw new ValueReferenceException(
            new Frame().Local( "local" ),
            new RTypeException( new FakeRType() ) );
    } catch( System.Exception e ) {
        ok = true;
        ok = !( RTypeException.Match(
            e,
            (vr,f) => !( vr.Equals( f.Local( "local" ) ) ),
            rt => rt is FakeRType ) );
    }
    Assert( ok );

    Print( "bool Match(), rtype mismatch" );
    ok = false;
    try {
        throw new ValueReferenceException(
            new Frame().Local( "local" ),
            new RTypeException( new FakeRType() ) );
    } catch( System.Exception e ) {
        ok = true;
        ok = !( RTypeException.Match(
            e,
            (vr,f) => vr.Equals( f.Local( "local" ) ),
            rt => !( rt is FakeRType ) ) );
    }
    Assert( ok );

    Print( "void Match<T>(), match" );
    ok = false;
    try {
        throw new ValueReferenceException(
            new Frame().Local( "local" ),
            new RTypeException( new FakeRType() ) );
    } catch( System.Exception e ) {
        RTypeException.Match<
            FakeRType >(
            e,
            (vr,f) => vr.Equals( f.Local( "local" ) ),
            (vr,f,rt,rte) => ok = true );
    }
    Assert( ok );

    Print( "void Match<T>(), value reference mismatch" );
    ok = false;
    try {
        throw new ValueReferenceException(
            new Frame().Local( "local" ),
            new RTypeException( new FakeRType() ) );
    } catch( System.Exception e ) {
        ok = true;
        RTypeException.Match<
            FakeRType >(
            e,
            (vr,f) => !( vr.Equals( f.Local( "local" ) ) ),
            (vr,f,rt,rte) => ok = false );
    }
    Assert( ok );

    Print( "void Match<T>(), rtype mismatch" );
    ok = false;
    try {
        throw new ValueReferenceException(
            new Frame().Local( "local" ),
            new RTypeException( new FakeRType() ) );
    } catch( System.Exception e ) {
        ok = true;
        RTypeException.Match<
            FakeRType2 >(
            e,
            (vr,f) => vr.Equals( f.Local( "local" ) ),
            (vr,f,rt,rte) => ok = false );
    }
    Assert( ok );

    Print( "bool Match<T>(), match" );
    ok = false;
    try {
        throw new ValueReferenceException(
            new Frame().Local( "local" ),
            new RTypeException( new FakeRType() ) );
    } catch( System.Exception e ) {
        ok = RTypeException.Match<
            FakeRType >(
            e,
            (vr,f) => vr.Equals( f.Local( "local" ) ) );
    }
    Assert( ok );

    Print( "bool Match(), value reference mismatch" );
    ok = false;
    try {
        throw new ValueReferenceException(
            new Frame().Local( "local" ),
            new RTypeException( new FakeRType() ) );
    } catch( System.Exception e ) {
        ok = true;
        ok = !( RTypeException.Match< FakeRType >(
            e,
            (vr,f) => !( vr.Equals( f.Local( "local" ) ) ) ) );
    }
    Assert( ok );

    Print( "bool Match(), rtype mismatch" );
    ok = false;
    try {
        throw new ValueReferenceException(
            new Frame().Local( "local" ),
            new RTypeException( new FakeRType() ) );
    } catch( System.Exception e ) {
        ok = true;
        ok = !( RTypeException.Match<
            FakeRType2 >(
            e,
            (vr,f) => vr.Equals( f.Local( "local" ) ) ) );
    }
    Assert( ok );
}


[Test( "EQ<T>" )]
public static
void
Test_EQ_T()
{
    bool ok;

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
    EQ.Check( (object)1, new ObjectComparer(), (object)null );

    Print( "Equal passes" );
    EQ.Check( 1, 1 );

    Print( "Inequal fails" );
    ok = false;
    try {
        EQ.Check( 1, 2 );
    } catch( System.Exception e ) {
        ok = RTypeException.Match<
            EQ< int > >(
            e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ) );
    }
    Assert( ok );

    Print( "With null CompareTo, null passes" );
    EQ.Check( null, new ObjectComparer(), null );

    Print( "With null CompareTo, non-null fails" );
    ok = false;
    try {
        EQ.Check( null, new ObjectComparer(), new object() );
    } catch( System.Exception e ) {
        ok = RTypeException.Match<
            EQ< object > >(
            e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ) );
    }
    Assert( ok );
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
    NEQ.Check( (object)1, new ObjectComparer(), null );

    Print( "Inequal passes" );
    NEQ.Check( 1, 2 );

    Print( "Equal fails" );
    Expect(
        e => RTypeException.Match<
            NEQ< int > >(
            e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ) ),
        () => NEQ.Check( 1, 1 ) );

    Print( "With null CompareTo, non-null passes" );
    NEQ.Check( null, new ObjectComparer(), new object() );

    Print( "With null CompareTo, null fails" );
    Expect(
        e => RTypeException.Match<
            NEQ< object > >(
            e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ) ),
        () => NEQ.Check( null, new ObjectComparer(), null ) );
}


class
NotBadOrWrong
    : CompositeRType< string >
{
    public
    NotBadOrWrong()
        : base(
            SystemEnumerable.Create(
                NEQ.Create( "bad" ),
                NEQ.Create( "wrong" ) ),
            ls => LocalisedString.Format( "{0} is NotBadOrWrong", ls ),
            ls => LocalisedString.Format( "{0} is not NotBadOrWrong", ls ),
            ls => LocalisedString.Format( "{0} must be NotBadOrWrong", ls ) )
    {}
}


class
NotFailOrNope
    : CompositeRType< string >
{
    public
    NotFailOrNope()
        : base(
            SystemEnumerable.Create(
                NEQ.Create( "fail" ),
                NEQ.Create( "nope" ) ),
            ls => LocalisedString.Format( "{0} is NotFailOrNope", ls ),
            ls => LocalisedString.Format( "{0} is not NotFailOrNope", ls ),
            ls => LocalisedString.Format( "{0} must be NotFailOrNope", ls ) )
    {}
}


class
NotBadWrongFailOrNope
    : CompositeRType< string >
{
    public
    NotBadWrongFailOrNope()
        : base(
            SystemEnumerable.Create<
                RType< string > >(
                new NotBadOrWrong(),
                new NotFailOrNope() ),
            ls => LocalisedString.Format(
                "{0} is NotBadWrongFailOrNope", ls ),
            ls => LocalisedString.Format(
                "{0} is not NotBadWrongFailOrNope", ls ),
            ls => LocalisedString.Format(
                "{0} must be NotBadWrongFailOrNope", ls ) )
    {}
}



[Test( "CompositeRType<T>" )]
public static
void
Test_CompositeRType_T()
{
    RType< string > t = new NotBadOrWrong();

    Print( "Is()" );
    Assert( t.Is( "ok" ) );
    Assert( !t.Is( "bad" ) );
    Assert( !t.Is( "wrong" ) );

    Print( "Is( null )" );
    Assert( t.Is( null ) );

    Print( "Check()" );
    t.Check( "ok" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.Equals( t ) ),
        () => t.Check( "bad" ) );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.Equals( t ) ),
        () => t.Check( "wrong" ) );

    Print( "Check( null )" );
    t.Check( null );

    Print( ".Equals()" );
    Assert( t.Equals( new NotBadOrWrong() ) );
    Assert( !t.Equals( new NotFailOrNope() ) );

    Print( "Composite of Composites" );
    RType< string > c = new NotBadWrongFailOrNope();
    Assert( c.Is( "ok" ) );
    Assert( !c.Is( "bad" ) );
    Assert( !c.Is( "wrong" ) );
    Assert( !c.Is( "fail" ) );
    Assert( !c.Is( "nope" ) );
}


class
FourLong
    : MemberRType< string, int >
{
    public
    FourLong()
        : base(
            s => s.Length,
            r => r.Property( "Length" ),
            s => LocalisedString.Format( "the length of {0}", s ),
            EQ.Create( 4 ) )
    {}
}


class
FiveLong
    : MemberRType< string, int >
{
    public
    FiveLong()
        : base(
            s => s.Length,
            r => r.Property( "Length" ),
            s => LocalisedString.Format( "the length of {0}", s ),
            EQ.Create( 5 ) )
    {}
}


[Test( "MemberRType<T,TMember>" )]
public static
void
Test_MemberRType_T_TMember()
{
    RType< string > fourlong = new FourLong();
    RType< string > fivelong = new FiveLong();

    Print( "Is()" );
    Assert( fourlong.Is( "1234" ) );
    Assert( !( fourlong.Is( "12345" ) ) );
    Assert( fivelong.Is( "12345" ) );
    Assert( !( fivelong.Is( "1234" ) ) );

    Print( "Is( null )" );
    Assert( fourlong.Is( null ) );

    Print( "Check()" );
    fourlong.Check( "1234" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.Equals( fourlong ) ),
        () => fourlong.Check( "12345" ) );
    fivelong.Check( "12345" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.Equals( fivelong ) ),
        () => fivelong.Check( "1234" ) );

    Print( "Check( null )" );
    fourlong.Check( null );

    Print( "Equals()" );
    Assert( fourlong.Equals( fourlong ) );
    Assert( !( fourlong.Equals( fivelong ) ) );
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
    NonNull.Check( new object() );

    Print( "Null fails" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.Equals( new NonNull() ) ),
        () => NonNull.Check( null ) );
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

    Print( "Non-blank string passes" );
    NonBlankString.Check( "Not blank" );

    Print( "Blank string fails" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.Equals( new NonBlankString() ) ),
        () => NonBlankString.Check( "" ) );

    Print( "Null passes" );
    NonBlankString.Check( null );
}


[Test( "GTE<T>" )]
public static
void
Test_GTE_T()
{
    Print( "Equality" );
    Assert(
        GTE.Create( 1 ).Equals(
        GTE.Create( 1 ) ) );
    Assert(
        GTE.Create( 1 ).GetHashCode() ==
        GTE.Create( 1 ).GetHashCode() );
    Assert( !
        GTE.Create( 1 ).Equals(
        GTE.Create( 2 ) ) );

    Print( "Null arguments to constructor throw ArgumentNullException" );
    Expect<
        System.ArgumentNullException >(
        () => GTE.Create< string >( null ) );
    Expect<
        System.ArgumentNullException >(
        () => GTE.Create( 0, null ) );

    Print( "null passes" );
    GTE.Check( "a", null );

    Print( "Bigger passes" );
    GTE.Check( 1, 2 );

    Print( "Equal passes" );
    GTE.Check( 1, 1 );

    Print( "Smaller fails" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.IsAnd<
                GTE<int> >(
                gte => gte.CompareTo == 1 ) ),
        () => GTE.Check( 1, 0 ) );
}


[Test( "LTE<T>" )]
public static
void
Test_LTE_T()
{
    Print( "Equality" );
    Assert(
        LTE.Create( 1 ).Equals(
        LTE.Create( 1 ) ) );
    Assert(
        LTE.Create( 1 ).GetHashCode() ==
        LTE.Create( 1 ).GetHashCode() );
    Assert( !
        LTE.Create( 1 ).Equals(
        LTE.Create( 2 ) ) );

    Print( "Null arguments to constructor throw ArgumentNullException" );
    Expect<
        System.ArgumentNullException >(
        () => LTE.Create< string >( null ) );
    Expect<
        System.ArgumentNullException >(
        () => LTE.Create( 0, null ) );

    Print( "null passes" );
    LTE.Check( "a", null );

    Print( "Bigger fails" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.IsAnd<
                LTE<int> >(
                lte => lte.CompareTo == 1 ) ),
        () => LTE.Check( 1, 2 ) );

    Print( "Equal passes" );
    LTE.Check( 1, 1 );

    Print( "Smaller passes" );
    LTE.Check( 1, 0 );
}


[Test( "GT<T>" )]
public static
void
Test_GT_T()
{
    Print( "Equality" );
    Assert(
        GT.Create( 1 ).Equals(
        GT.Create( 1 ) ) );
    Assert(
        GT.Create( 1 ).GetHashCode() ==
        GT.Create( 1 ).GetHashCode() );
    Assert( !
        GT.Create( 1 ).Equals(
        GT.Create( 2 ) ) );

    Print( "null passes" );
    GT.Check( "a", null );

    Print( "Bigger passes" );
    GT.Check( 1, 2 );

    Print( "Equal fails" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.IsAnd<
                GT< int > >(
                gt => gt.Equals( GT.Create( 1 ) ) ) ),
        () => GT.Check( 1, 1 ) );

    Print( "Smaller fails" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.IsAnd<
                GT< int > >(
                gt => gt.Equals( GT.Create( 1 ) ) ) ),
        () => GT.Check( 1, 0 ) );
}


[Test( "LT<T>" )]
public static
void
Test_LT_T()
{
    Print( "Equality" );
    Assert(
        LT.Create( 1 ).Equals(
        LT.Create( 1 ) ) );
    Assert(
        LT.Create( 1 ).GetHashCode() ==
        LT.Create( 1 ).GetHashCode() );
    Assert( !
        LT.Create( 1 ).Equals(
        LT.Create( 2 ) ) );

    Print( "null passes" );
    LT.Check( "a", null );

    Print( "Bigger fails" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.IsAnd<
                LT< int > >(
                lt => lt.Equals( LT.Create( 1 ) ) ) ),
        () => LT.Check( 1, 2 ) );

    Print( "Equal fails" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.IsAnd<
                LT< int > >(
                lt => lt.Equals( LT.Create( 1 ) ) ) ),
        () => LT.Check( 1, 1 ) );

    Print( "Smaller passes" );
    LT.Check( 1, 0 );
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

    RType< int > rtinc =
        InInterval.Create( Interval.Create( from, true, to, true ) );
    RType< int > rtexc =
        InInterval.Create( Interval.Create( from, false, to, false ) );
    RType< int > rtfrominc =
        InInterval.Create( Interval.Create( from, true, to, false ) );
    RType< int > rttoinc =
        InInterval.Create( Interval.Create( from, false, to, true ) );

    RType< int > rt;
    string id = "...";

    Print( "Inclusive" );
    rt = rtinc;
    Print( "is     : \"" + rt.SayIs( id ) + "\"" );
    Print( "is not : \"" + rt.SayIsNot( id ) + "\"" );
    Print( "must be: \"" + rt.SayMustBe( id ) + "\"" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            t => t.Equals( rt ) ),
        () => rt.Check( lt ) );
    rt.Check( from );
    rt.Check( between );
    rt.Check( to );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            t => t.Equals( rt ) ),
        () => rt.Check( gt ) );

    Print( "Exclusive" );
    rt = rtexc;
    Print( "is     : \"" + rt.SayIs( id ) + "\"" );
    Print( "is not : \"" + rt.SayIsNot( id ) + "\"" );
    Print( "must be: \"" + rt.SayMustBe( id ) + "\"" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            t => t.Equals( rt ) ),
        () => rt.Check( lt ) );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            t => t.Equals( rt ) ),
        () => rt.Check( from ) );
    rt.Check( between );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            t => t.Equals( rt ) ),
        () => rt.Check( to ) );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            t => t.Equals( rt ) ),
        () => rt.Check( gt ) );

    Print( "From Inclusive" );
    rt = rtfrominc;
    Print( "is     : \"" + rt.SayIs( id ) + "\"" );
    Print( "is not : \"" + rt.SayIsNot( id ) + "\"" );
    Print( "must be: \"" + rt.SayMustBe( id ) + "\"" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            t => t.Equals( rt ) ),
        () => rt.Check( lt ) );
    rt.Check( from );
    rt.Check( between );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            t => t.Equals( rt ) ),
        () => rt.Check( to ) );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            t => t.Equals( rt ) ),
        () => rt.Check( gt ) );

    Print( "To Inclusive" );
    rt = rttoinc;
    Print( "is     : \"" + rt.SayIs( id ) + "\"" );
    Print( "is not : \"" + rt.SayIsNot( id ) + "\"" );
    Print( "must be: \"" + rt.SayMustBe( id ) + "\"" );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            t => t.Equals( rt ) ),
        () => rt.Check( lt ) );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            t => t.Equals( rt ) ),
        () => rt.Check( from ) );
    rt.Check( between );
    rt.Check( to );
    Expect(
        e => RTypeException.Match( e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            t => t.Equals( rt ) ),
        () => rt.Check( gt ) );

    Print( ".Equals() and .GetHashCode()" );
    RType< int > t1 = InInterval.Create( Interval.Create( 1, 10 ) );
    RType< int > t2 = InInterval.Create( Interval.Create( 1, 10 ) );
    RType< int > t3 = InInterval.Create( Interval.Create( 1, 20 ) );
    Assert( t1.Equals( t2 ) );
    Assert( !( t1.Equals( t3 ) ) );
    Assert( t1.GetHashCode() == t2.GetHashCode() );
}


[Test( "Contravariance" )]
public static
void
Test_Contravariance()
{
    RType< object > t = new EQ<object>( "apple", new ObjectComparer() );
    RType< object > u = new EQ<object>( "apple", new ObjectComparer() );
    RType< object > v = new EQ<object>( "orange", new ObjectComparer() );
    RType< string > w = t.Contravary< string >();
    RType< string > x = u.Contravary< string >();
    RType< string > y = v.Contravary< string >();

    Print( "Contravariant produces the same Check() results as original" );
    t.Check( "apple" );
    w.Check( "apple" );
    Expect(
        e => RTypeException.Match(
            e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.Equals( t ) ),
        () => t.Check( "orange" ) );
    Expect(
        e => RTypeException.Match(
            e,
            (vr,f) => vr.Equals( f.Down().Parameter( "item" ) ),
            rt => rt.Equals( w ) ),
        () => w.Check( "orange" ) );

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




} // type
} // namespace

