// -----------------------------------------------------------------------------
// Copyright (c) 2010
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
using System.Text;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Numerics;
using Com.Halfdecent.Collections;
using Com.Halfdecent.Testing;


namespace
Com.Halfdecent.Collections.Test
{


// =============================================================================
/// Test program for <tt>Com.Halfdecent.Collections</tt>
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


[Test( "CollectionFromSystemListAdapter()" )]
public static
void
Test_CollectionFromSystemListAdapter()
{
    IFilter< int, int > f;

    Print( "Create" );
    var c =
        new SCG.List< int >( new int[] { 1, 2, 3, 4, 5, 6 } )
        .AsHalfdecentCollection();

    Print( ".Stream()" );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 2, 3, 4, 5, 6 } ) );

    Print( ".GetAndReplaceWhere( Predicate< T > )" );
    f = c.GetAndReplaceWhere( i => i % 2 == 0 );
    f.From = new int[] { 20, 40, 60, 80, 100 }.AsStream();
    SCG.List< int > to = new SCG.List< int >();
    f.EmptyTo( to.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 20, 3, 40, 5, 60 } ) );
    to.Sort();
    Assert(
        to.SequenceEqual(
            new int[] { 2, 4, 6 } ) );

    Print( ".GetAndRemoveWhere( Predicate< T > )" );
    to.Clear();
    c.GetAndRemoveWhere( i => i >= 10 )
        .EmptyTo( to.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 3, 5 } ) );
    to.Sort();
    Assert(
        to.SequenceEqual(
            new int[] { 20, 40, 60 } ) );

    Print( ".Get( TKey )" );
    Assert( c.Get( Integer.From( 0 ) ) == 1 );
    Assert( c.Get( Integer.From( 1 ) ) == 3 );
    Assert( c.Get( Integer.From( 2 ) ) == 5 );

    Print( ".Replace( TKey, T )" );
    c.Replace( Integer.From( 1 ), 2 );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 2, 5 } ) );

    Print( ".Remove( TKey )" );
    c.Remove( Integer.From( 1 ) );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 5 } ) );

    Print( ".Contains( TKey )" );
    Assert( c.Contains( Integer.From( 0 ) ) );
    Assert( c.Contains( Integer.From( 1 ) ) );
    Assert( !c.Contains( Integer.From( 2 ) ) );

    Print( ".Stream( TKey )" );
    Assert(
        c.Stream( Integer.From( 1 ) )
        .AsEnumerable()
        .SequenceEqual(
            new int[] { 5 } ) );

    Print( ".GetAndReplaceAll( TKey )" );
    f = c.GetAndReplaceAll( Integer.From( 1 ) );
    f.From = Stream.Create( 6 );
    to.Clear();
    f.EmptyTo( to.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 6 } ) );
    Assert(
        to.SequenceEqual(
            new int[] { 5 } ) );

    Print( ".GetAndRemoveAll( TKey )" );
    to.Clear();
    c.GetAndRemoveAll( Integer.From( 1 ) ).EmptyTo( to.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1 } ) );
    Assert(
        to.SequenceEqual(
            new int[] { 6 } ) );

    Print( ".Add( TKey, T )" );
    c.Add( Integer.From( 0 ), 0 );
    c.Add( Integer.From( 2 ), 2 );
    c.Add( Integer.From( 1 ), 1 );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 0, 1, 1, 2 } ) );

    Print( ".Count" );
    Assert( c.Count.Equals( Integer.From( 4 ) ) );

    Print( ".StreamPairs()" );
    IStream< ITuple< IInteger, int > > ts =
        c.StreamPairs();
    ITuple< IInteger, int > tup;
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 0 ) ) );  Assert( tup.B == 0 );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 1 ) ) );  Assert( tup.B == 1 );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 2 ) ) );  Assert( tup.B == 1 );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 3 ) ) );  Assert( tup.B == 2 );
    Assert( !ts.TryPull( out tup ) );
}


[Test( "CollectionFromStringAdapter()" )]
public static
void
Test_CollectionFromStringAdapter()
{
    Print( "Create" );
    var c =
        "abc"
        .AsHalfdecentCollection();

    Print( ".Stream()" );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new char[] { 'a', 'b', 'c' } ) );

    Print( ".Get( TKey )" );
    Assert( c.Get( Integer.From( 0 ) ) == 'a' );
    Assert( c.Get( Integer.From( 1 ) ) == 'b' );
    Assert( c.Get( Integer.From( 2 ) ) == 'c' );

    Print( ".Contains( TKey )" );
    Assert( !c.Contains( Integer.From( -1 ) ) );
    Assert( c.Contains( Integer.From( 0 ) ) );
    Assert( c.Contains( Integer.From( 1 ) ) );
    Assert( c.Contains( Integer.From( 2 ) ) );
    Assert( !c.Contains( Integer.From( 3 ) ) );

    Print( ".Stream( TKey )" );
    Assert(
        c.Stream( Integer.From( 1 ) )
        .AsEnumerable()
        .SequenceEqual(
            new char[] { 'b' } ) );

    Print( ".Count" );
    Assert( c.Count.Equals( Integer.From( 3 ) ) );

    Print( ".StreamPairs()" );
    IStream< ITuple< IInteger, char > > ts = c.StreamPairs();
    ITuple< IInteger, char > tup;
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 0 ) ) );  Assert( tup.B == 'a' );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 1 ) ) );  Assert( tup.B == 'b' );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 2 ) ) );  Assert( tup.B == 'c' );
    Assert( !ts.TryPull( out tup ) );
}


[Test( "CollectionFromSystemStringBuilderAdapter()" )]
public static
void
Test_CollectionFromSystemStringBuilderAdapter()
{
    IFilter< char, char > f;

    Print( "Create" );
    var c = new StringBuilder( "abcde" ).AsHalfdecentCollection();

    Print( ".Stream()" );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new char[] { 'a', 'b', 'c', 'd', 'e' } ) );

    Print( ".GetAndReplaceWhere( Predicate< char > )" );
    f = c.GetAndReplaceWhere( ch => ch == 'b' );
    f.From = new char[] { 'B' }.AsStream();
    SCG.List< char > to = new SCG.List< char >();
    f.EmptyTo( to.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new char[] { 'a', 'B', 'c', 'd', 'e' } ) );
    to.Sort();
    Assert(
        to.SequenceEqual(
            new char[] { 'b' } ) );

    Print( ".GetAndRemoveWhere( Predicate< char > )" );
    to.Clear();
    c.GetAndRemoveWhere( ch => ch == 'B' )
        .EmptyTo( to.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new char[] { 'a', 'c', 'd', 'e' } ) );
    to.Sort();
    Assert(
        to.SequenceEqual(
            new char[] { 'B' } ) );

    Print( ".Get( IInteger )" );
    Assert( c.Get( Integer.From( 0 ) ) == 'a' );
    Assert( c.Get( Integer.From( 1 ) ) == 'c' );
    Assert( c.Get( Integer.From( 2 ) ) == 'd' );
    Assert( c.Get( Integer.From( 3 ) ) == 'e' );

    Print( ".Replace( IInteger, char )" );
    c.Replace( Integer.From( 1 ), 'C' );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new char[] { 'a', 'C', 'd', 'e' } ) );

    Print( ".Remove( IInteger )" );
    c.Remove( Integer.From( 1 ) );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new char[] { 'a', 'd', 'e' } ) );

    Print( ".Contains( IInteger )" );
    Assert( !c.Contains( Integer.From( -1 ) ) );
    Assert( c.Contains( Integer.From( 0 ) ) );
    Assert( c.Contains( Integer.From( 1 ) ) );
    Assert( c.Contains( Integer.From( 2 ) ) );
    Assert( !c.Contains( Integer.From( 3 ) ) );

    Print( ".Stream( IInteger )" );
    Assert(
        c.Stream( Integer.From( 1 ) )
        .AsEnumerable()
        .SequenceEqual(
            new char[] { 'd' } ) );

    Print( ".GetAndReplaceAll( IInteger )" );
    f = c.GetAndReplaceAll( Integer.From( 1 ) );
    f.From = Stream.Create( 'D' );
    to.Clear();
    f.EmptyTo( to.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new char[] { 'a', 'D', 'e' } ) );
    Assert(
        to.SequenceEqual(
            new char[] { 'd' } ) );

    Print( ".GetAndRemoveAll( IInteger )" );
    to.Clear();
    c.GetAndRemoveAll( Integer.From( 1 ) ).EmptyTo( to.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new char[] { 'a', 'e' } ) );
    Assert(
        to.SequenceEqual(
            new char[] { 'D' } ) );

    Print( ".Add( IInteger, char )" );
    c.Add( Integer.From( 1 ), 'b' );
    c.Add( Integer.From( 2 ), 'c' );
    c.Add( Integer.From( 3 ), 'd' );
    c.Add( Integer.From( 5 ), 'f' );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new char[] { 'a', 'b', 'c', 'd', 'e', 'f' } ) );

    Print( ".Count" );
    Assert( c.Count.Equals( Integer.From( 6 ) ) );

    Print( ".StreamPairs()" );
    IStream< ITuple< IInteger, char > > ts =
        c.StreamPairs();
    ITuple< IInteger, char > tup;
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 0 ) ) );  Assert( tup.B == 'a' );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 1 ) ) );  Assert( tup.B == 'b' );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 2 ) ) );  Assert( tup.B == 'c' );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 3 ) ) );  Assert( tup.B == 'd' );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 4 ) ) );  Assert( tup.B == 'e' );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 5 ) ) );  Assert( tup.B == 'f' );
    Assert( !ts.TryPull( out tup ) );
}


[Test( "CollectionFromSystemDictionaryAdapter()" )]
public static
void
Test_CollectionFromSystemDictionaryAdapter()
{
    Print( "Adapt a new dictionary" );
    IUniqueKeyedCollectionRCSG< string, int > c =
        new SCG.Dictionary< string, int >()
        .AsHalfdecentCollection();

    Print( "Check that it's empty" );
    Assert( c.Count.Equals( Integer.From( 0 ) ) );

    Print( ".Add() and check" );
    c.Add( "1", 1 );
    Assert( c.Count.Equals( Integer.From( 1 ) ) );
    Assert( c.Contains( "1" ) );
    Assert( c.Get( "1" ) == 1 );

    Print( ".Add() and check" );
    c.Add( "2", 2 );
    Assert( c.Count.Equals( Integer.From( 2 ) ) );
    Assert( c.Contains( "2" ) );
    Assert( c.Get( "2" ) == 2 );

    Print( ".Add() and check" );
    c.Add( "3", 3 );
    Assert( c.Count.Equals( Integer.From( 3 ) ) );
    Assert( c.Contains( "3" ) );
    Assert( c.Get( "3" ) == 3 );

    Print( ".Replace() and check" );
    c.Replace( "2", 22 );
    Assert( c.Count.Equals( Integer.From( 3 ) ) );
    Assert( c.Contains( "2" ) );
    Assert( c.Get( "2" ) == 22 );

    Print( ".Remove() and check" );
    c.Remove( "2" );
    Assert( c.Count.Equals( Integer.From( 2 ) ) );
    Assert( !c.Contains( "2" ) );
    Expect(
        e => RTypeException.Match(
            e,
            (vr,f) => vr.Equals( f.Down().Parameter( "key" ) ),
            rt => rt.Equals( new ExistingKeyIn< string, int >( c ) ) ),
        () => c.Get( "2" ) );
}


[Test( "IUniqueKeyedCollectionRSG.AsImplicitUniqueKeyedCollection()" )]
public static
void
Test_IUniqueKeyedCollectionRSG_AsImplicitUniqueKeyedCollection()
{
    Print( "Make an implicit collection out of an explicit one" );
    IImplicitUniqueKeyedCollectionRSG< string, int > c
        = new SCG.Dictionary< string, int >()
        .AsHalfdecentCollection()
        .AsImplicitUniqueKeyedCollection( i => i.ToString() );

    Print( "Add() an item and check" );
    c.Add( 1 );
    Assert( c.Count.Equals( Integer.From( 1 ) ) );
    Assert( c.Contains( "1" ) );
    Assert( c.Get( "1" ) == 1 );

    Print( "Add() another item and check" );
    c.Add( 2 );
    Assert( c.Count.Equals( Integer.From( 2 ) ) );
    Assert( c.Contains( "2" ) );
    Assert( c.Get( "2" ) == 2 );

    Print( "Remove() an item and check" );
    c.Remove( "1" );
    Assert( c.Count.Equals( Integer.From( 1 ) ) );
    Assert( c.Contains( "2" ) );
    Assert( c.Get( "2" ) == 2 );

    Print( "Add() item with duplicate key throws RTypeException" );
    Expect(
        e => RTypeException.Match<
            NonExistingKeyIn< string, int > >(
            e ),
        () => c.Add( 2 ) );
}


[Test( "OrderedCollectionR" )]
public static
void
Test_OrderedCollectionR()
{
    Print( "IndexWhere()" );
    Assert(
        "abcdcdc"
        .AsHalfdecentCollection()
        .IndexWhere( c => c == 'c' )
        .Equals( Integer.From( 2 ) ) );
}


[Test( "ICollectionG.AsSink()" )]
public static
void
Test_ICollectionG_AsSink()
{
    ICollectionRG< int > c =
        new SCG.List< int >()
        .AsHalfdecentCollection();
    new int[] { 1, 2, 3 }
        .AsStream()
        .EmptyTo( c.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 2, 3 } ) );
}


[Test( "ArrayList< T >" )]
public static
void
Test_ArrayList()
{
    ArrayList< int > l;

    Print( "ArrayList()" );
    l = new ArrayList< int >();
    Assert( l.Count.Equals( Integer.From( 0 ) ) );

    Print( "ArrayList( ICollectionR<T> )" );
    l = new ArrayList< int >(
        new int[] { 1, 2, 3 }.AsHalfdecentCollection() );
    // Presumably the capacity has been optimised for the number of items
    // in the source collection, but that's an internal detail so can't really
    // check it.  We can check that the correct items where added, though.
    Assert(
        l.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 2, 3 } ) );
}


[Test( "IndexSliceRCSG< T >" )]
public static
void
Test_IndexSliceRCSG_T()
{
    Print( "Create ordered collection" );
    IOrderedCollectionRCSG< int > c = new ArrayList< int >();
    c.Add( 1 );
    c.Add( 2 );
    c.Add( 3 );
    c.Add( 4 );
    c.Add( 5 );

    Print( "Slice" );
    IOrderedCollectionRCSG< int > s =
        c.Slice( Integer.From( 1 ), Integer.From( 3 ) );
    Assert(
        s.Stream().AsEnumerable().SequenceEqual(
            new int[] { 2, 3, 4 } ) );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 2, 3, 4, 5 } ) );

    Print( "Insert an item at the beginning" );
    s.Add( Integer.From( 0 ), 11 );
    Assert(
        s.Stream().AsEnumerable().SequenceEqual(
            new int[] { 11, 2, 3, 4 } ) );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 11, 2, 3, 4, 5 } ) );

    Print( "Insert an item in the middle" );
    s.Add( Integer.From( 2 ), 22 );
    Assert(
        s.Stream().AsEnumerable().SequenceEqual(
            new int[] { 11, 2, 22, 3, 4 } ) );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 11, 2, 22, 3, 4, 5 } ) );

    Print( "Add an item to the end" );
    s.Add( 44 );
    Assert(
        s.Stream().AsEnumerable().SequenceEqual(
            new int[] { 11, 2, 22, 3, 4, 44 } ) );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 11, 2, 22, 3, 4, 44, 5 } ) );

    Print( "Remove an item from the beginning" );
    s.Remove( Integer.From( 0 ) );
    Assert(
        s.Stream().AsEnumerable().SequenceEqual(
            new int[] { 2, 22, 3, 4, 44 } ) );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 2, 22, 3, 4, 44, 5 } ) );

    Print( "Remove an item from the middle" );
    s.Remove( Integer.From( 1 ) );
    Assert(
        s.Stream().AsEnumerable().SequenceEqual(
            new int[] { 2, 3, 4, 44 } ) );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 2, 3, 4, 44, 5 } ) );

    Print( "Remove an item from the end" );
    s.Remove( Integer.From( 3 ) );
    Assert(
        s.Stream().AsEnumerable().SequenceEqual(
            new int[] { 2, 3, 4 } ) );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 2, 3, 4, 5 } ) );

    Print( "Remove all items" );
    s.Remove( Integer.From( 0 ) );
    s.Remove( Integer.From( 0 ) );
    s.Remove( Integer.From( 0 ) );
    Assert(
        s.Stream().AsEnumerable().SequenceEqual(
            new int[] { } ) );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 5 } ) );

    Print( "Add items back" );
    s.Add( 2 );
    s.Add( 3 );
    s.Add( 4 );
    Assert(
        s.Stream().AsEnumerable().SequenceEqual(
            new int[] { 2, 3, 4 } ) );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 2, 3, 4, 5 } ) );
}


[Test( "IOrderedCollectionS.RemoveFirst() and friends" )]
public static
void
Test_ICollectionS_RemoveFirst()
{
    IOrderedCollectionRCSG< char > chars =
        new ArrayList< char >( "abcdefg".AsHalfdecentCollection() );

    Print( ".RemoveFirst()" );
    chars.RemoveFirst();
    Assert(
        chars.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'b', 'c', 'd', 'e', 'f', 'g' } ) );
    Print( ".RemoveFirst( IInteger )" );
    chars.RemoveFirst( Integer.From( 2 ) );
    Assert(
        chars.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'd', 'e', 'f', 'g' } ) );
    Print( ".RemoveFirst()" );
    chars.RemoveLast();
    Assert(
        chars.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'd', 'e', 'f' } ) );
    Print( ".RemoveLast( IInteger )" );
    chars.RemoveLast( Integer.From( 2 ) );
    Assert(
        chars.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'd' } ) );
}


[Test( "IOrderedCollectionR< T >.SplitWhere() and friends" )]
public static
void
Test_IOrderedCollectionR_T_SplitWhere()
{
    IOrderedCollectionR< char > chars;
    IOrderedCollectionR< char > s1;
    IOrderedCollectionR< char > s2;
    IStream< IOrderedCollectionR< char > > s;

    Print( ".SplitWhere()" );
    s = " abc def  ghi "
        .AsHalfdecentCollection()
        .SplitWhere( c => c == ' ' );
    Assert( s.TryPull( out chars ) );
    Assert(
        chars.Stream().AsEnumerable().SequenceEqual(
            new char[]{} ) );
    Assert( s.TryPull( out chars ) );
    Assert(
        chars.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'a', 'b', 'c' } ) );
    Assert( s.TryPull( out chars ) );
    Assert(
        chars.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'd', 'e', 'f' } ) );
    Assert( s.TryPull( out chars ) );
    Assert(
        chars.Stream().AsEnumerable().SequenceEqual(
            new char[]{} ) );
    Assert( s.TryPull( out chars ) );
    Assert(
        chars.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'g', 'h', 'i' } ) );
    Assert( s.TryPull( out chars ) );
    Assert(
        chars.Stream().AsEnumerable().SequenceEqual(
            new char[]{} ) );
    Assert( !s.TryPull( out chars ) );

    Print( ".SplitAtFirstWhere()" );
    "abcbc"
        .AsHalfdecentCollection()
        .SplitAtFirstWhere( c => c == 'b' )
        .AssignTo( out s1, out s2 );
    Assert(
        s1.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'a' } ) );
    Assert(
        s2.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'c', 'b', 'c' } ) );
    "bbb"
        .AsHalfdecentCollection()
        .SplitAtFirstWhere( c => c == 'b' )
        .AssignTo( out s1, out s2 );
    Assert(
        s1.Stream().AsEnumerable().SequenceEqual(
            new char[]{} ) );
    Assert(
        s2.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'b', 'b' } ) );
    "aaa"
        .AsHalfdecentCollection()
        .SplitAtFirstWhere( c => c == 'b' )
        .AssignTo( out s1, out s2 );
    Assert(
        s1.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'a', 'a', 'a' } ) );
    Assert(
        s2.Stream().AsEnumerable().SequenceEqual(
            new char[]{} ) );
    "aaab"
        .AsHalfdecentCollection()
        .SplitAtFirstWhere( c => c == 'b' )
        .AssignTo( out s1, out s2 );
    Assert(
        s1.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'a', 'a', 'a' } ) );
    Assert(
        s2.Stream().AsEnumerable().SequenceEqual(
            new char[]{} ) );

    Print( ".SplitBeforeWhere()" );
    s = "OneTwo"
        .AsHalfdecentCollection()
        .SplitBeforeWhere( c => char.IsUpper( c ) );
    Assert( s.TryPull( out chars ) );
    Assert(
        chars.Stream().AsEnumerable().SequenceEqual(
            new char[]{} ) );
    Assert( s.TryPull( out chars ) );
    Assert(
        chars.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'O', 'n', 'e' } ) );
    Assert( s.TryPull( out chars ) );
    Assert(
        chars.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'T', 'w', 'o' } ) );
    Assert( !s.TryPull( out chars ) );

    Print( ".SplitBeforeFirstWhere()" );
    "abcbc"
        .AsHalfdecentCollection()
        .SplitBeforeFirstWhere( c => c == 'b' )
        .AssignTo( out s1, out s2 );
    Assert(
        s1.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'a' } ) );
    Assert(
        s2.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'b', 'c', 'b', 'c' } ) );
    "bbb"
        .AsHalfdecentCollection()
        .SplitBeforeFirstWhere( c => c == 'b' )
        .AssignTo( out s1, out s2 );
    Assert(
        s1.Stream().AsEnumerable().SequenceEqual(
            new char[]{} ) );
    Assert(
        s2.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'b', 'b', 'b' } ) );
    "aaa"
        .AsHalfdecentCollection()
        .SplitBeforeFirstWhere( c => c == 'b' )
        .AssignTo( out s1, out s2 );
    Assert(
        s1.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'a', 'a', 'a' } ) );
    Assert(
        s2.Stream().AsEnumerable().SequenceEqual(
            new char[]{} ) );
    "aaab"
        .AsHalfdecentCollection()
        .SplitBeforeFirstWhere( c => c == 'b' )
        .AssignTo( out s1, out s2 );
    Assert(
        s1.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'a', 'a', 'a' } ) );
    Assert(
        s2.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'b' } ) );
}




} // type
} // namespace

