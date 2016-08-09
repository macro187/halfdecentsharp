// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2012, 2013
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
using Halfdecent.Meta;
using Halfdecent.RTypes;
using Halfdecent.Streams;
using Halfdecent.Collections;
using Halfdecent.Testing;


namespace
Halfdecent.Collections.Test
{


// =============================================================================
/// Test program for <tt>Halfdecent.Collections</tt>
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
    Print( "Create" );
    var c =
        SystemEnumerable.Create( 1, 2, 3, 4, 5, 6 )
        .ToList()
        .AsHalfdecentCollection();

    Print( ".Stream()" );
    Assert(
        c.Stream()
        .SequenceEqual(
            Stream.Create( 1, 2, 3, 4, 5, 6 ) ) );

    Print( ".GetAndReplaceWhere( Predicate< T > )" );
    var to = new SCG.List< int >();
    Stream.Create( 20, 40, 60, 80, 100 )
        .To( c.GetAndReplaceWhere( i => i % 2 == 0 ) )
        .EmptyTo(
            to.AsSink() );
    Assert(
        c.Stream()
        .SequenceEqual(
            Stream.Create( 1, 20, 3, 40, 5, 60 ) ) );
    to.Sort();
    Assert(
        to.SequenceEqual(
            SystemEnumerable.Create( 2, 4, 6 ) ) );

    Print( ".GetAndRemoveWhere( Predicate< T > )" );
    to.Clear();
    c.GetAndRemoveWhere( i => i >= 10 )
        .EmptyTo( to.AsSink() );
    Assert(
        c.Stream()
        .SequenceEqual(
            Stream.Create( 1, 3, 5 ) ) );
    to.Sort();
    Assert(
        to.SequenceEqual(
            SystemEnumerable.Create( 20, 40, 60 ) ) );

    Print( ".Get( TKey )" );
    Assert( c.Get( 0 ) == 1 );
    Assert( c.Get( 1 ) == 3 );
    Assert( c.Get( 2 ) == 5 );

    Print( ".Replace( TKey, T )" );
    c.Replace( 1, 2 );
    Assert(
        c.Stream()
        .SequenceEqual(
            Stream.Create( 1, 2, 5 ) ) );

    Print( ".Remove( TKey )" );
    c.Remove( 1 );
    Assert(
        c.Stream()
        .SequenceEqual(
            Stream.Create( 1, 5 ) ) );

    Print( ".Contains( TKey )" );
    Assert( c.Contains( 0 ) );
    Assert( c.Contains( 1 ) );
    Assert( !c.Contains( 2 ) );

    Print( ".Stream( TKey )" );
    Assert(
        c.Stream( 1 )
        .SequenceEqual(
            Stream.Create( 5 ) ) );

    Print( ".GetAndReplaceAll( TKey )" );
    to.Clear();
    Stream.Create( 6 )
        .To( c.GetAndReplaceAll( 1 ) )
        .EmptyTo( to.AsSink() );
    Assert(
        c.Stream()
        .SequenceEqual(
            Stream.Create( 1, 6 ) ) );
    Assert(
        to.SequenceEqual(
            SystemEnumerable.Create( 5 ) ) );

    Print( ".GetAndRemoveAll( TKey )" );
    to.Clear();
    c.GetAndRemoveAll( 1 )
        .EmptyTo(
            to.AsSink() );
    Assert(
        c.Stream().SequenceEqual(
            Stream.Create( 1 ) ) );
    Assert(
        to.SequenceEqual(
            SystemEnumerable.Create( 6 ) ) );

    Print( ".Add( TKey, T )" );
    c.Add( 0, 0 );
    c.Add( 2, 2 );
    c.Add( 1, 1 );
    Assert(
        c.Stream()
        .SequenceEqual(
            Stream.Create( 0, 1, 1, 2 ) ) );

    Print( ".Count" );
    Assert( c.Count == 4 );

    Print( ".StreamPairs()" );
    var ts = c.StreamPairs();
    Assert( ts.Pull().BothEqual( 0L, 0 ) );
    Assert( ts.Pull().BothEqual( 1L, 1 ) );
    Assert( ts.Pull().BothEqual( 2L, 1 ) );
    Assert( ts.Pull().BothEqual( 3L, 2 ) );
    Assert( !ts.TryPull().A );
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
    Assert( c.Get( 0 ) == 'a' );
    Assert( c.Get( 1 ) == 'b' );
    Assert( c.Get( 2 ) == 'c' );

    Print( ".Contains( TKey )" );
    Assert( !c.Contains( -1 ) );
    Assert( c.Contains( 0 ) );
    Assert( c.Contains( 1 ) );
    Assert( c.Contains( 2 ) );
    Assert( !c.Contains( 3 ) );

    Print( ".Stream( TKey )" );
    Assert(
        c.Stream( 1 )
        .AsEnumerable()
        .SequenceEqual(
            new char[] { 'b' } ) );

    Print( ".Count" );
    Assert( c.Count == 3 );

    Print( ".StreamPairs()" );
    IStream< ITupleHD< long, char > > ts = c.StreamPairs();
    ITupleHD< long, char > tup;
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A == 0 );  Assert( tup.B == 'a' );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A == 1 );  Assert( tup.B == 'b' );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A == 2 );  Assert( tup.B == 'c' );
    Assert( !ts.TryPull( out tup ) );
}


[Test( "CollectionFromSystemStringBuilderAdapter()" )]
public static
void
Test_CollectionFromSystemStringBuilderAdapter()
{
    Print( "Create" );
    var c =
        new StringBuilder( "abcde" )
        .AsHalfdecentCollection();

    Print( ".Stream()" );
    Assert(
        c.Stream()
        .SequenceEqual(
            Stream.Create( 'a', 'b', 'c', 'd', 'e' ) ) );

    Print( ".GetAndReplaceWhere( Predicate< char > )" );
    var to = new SCG.List< char >();
    Stream.Create( 'B' )
        .To( c.GetAndReplaceWhere( ch => ch == 'b' ) )
        .EmptyTo( to.AsSink() );
    Assert(
        c.Stream()
        .SequenceEqual(
            Stream.Create( 'a', 'B', 'c', 'd', 'e' ) ) );
    to.Sort();
    Assert(
        to.SequenceEqual(
            SystemEnumerable.Create( 'b' ) ) );

    Print( ".GetAndRemoveWhere( Predicate< char > )" );
    to.Clear();
    c.GetAndRemoveWhere( ch => ch == 'B' )
        .EmptyTo( to.AsSink() );
    Assert(
        c.Stream()
        .SequenceEqual(
            Stream.Create( 'a', 'c', 'd', 'e' ) ) );
    to.Sort();
    Assert(
        to.SequenceEqual(
            SystemEnumerable.Create( 'B' ) ) );

    Print( ".Get( IInteger )" );
    Assert( c.Get( 0 ) == 'a' );
    Assert( c.Get( 1 ) == 'c' );
    Assert( c.Get( 2 ) == 'd' );
    Assert( c.Get( 3 ) == 'e' );

    Print( ".Replace( IInteger, char )" );
    c.Replace( 1, 'C' );
    Assert(
        c.Stream()
        .SequenceEqual(
            Stream.Create( 'a', 'C', 'd', 'e' ) ) );

    Print( ".Remove( IInteger )" );
    c.Remove( 1 );
    Assert(
        c.Stream()
        .SequenceEqual(
            Stream.Create( 'a', 'd', 'e' ) ) );

    Print( ".Contains( IInteger )" );
    Assert( !c.Contains( -1 ) );
    Assert( c.Contains( 0 ) );
    Assert( c.Contains( 1 ) );
    Assert( c.Contains( 2 ) );
    Assert( !c.Contains( 3 ) );

    Print( ".Stream( IInteger )" );
    Assert(
        c.Stream( 1 )
        .SequenceEqual(
            Stream.Create( 'd' ) ) );

    Print( ".GetAndReplaceAll( IInteger )" );
    to.Clear();
    Stream.Create( 'D' )
        .To( c.GetAndReplaceAll( 1 ) )
        .EmptyTo( to.AsSink() );
    Assert(
        c.Stream()
        .SequenceEqual(
            Stream.Create( 'a', 'D', 'e' ) ) );
    Assert(
        to.SequenceEqual(
            SystemEnumerable.Create( 'd' ) ) );

    Print( ".GetAndRemoveAll( IInteger )" );
    to.Clear();
    c.GetAndRemoveAll( 1 )
        .EmptyTo( to.AsSink() );
    Assert(
        c.Stream()
        .SequenceEqual(
            Stream.Create( 'a', 'e' ) ) );
    Assert(
        to.SequenceEqual(
            SystemEnumerable.Create( 'D' ) ) );

    Print( ".Add( IInteger, char )" );
    c.Add( 1, 'b' );
    c.Add( 2, 'c' );
    c.Add( 3, 'd' );
    c.Add( 5, 'f' );
    Assert(
        c.Stream()
        .SequenceEqual(
            Stream.Create( 'a', 'b', 'c', 'd', 'e', 'f' ) ) );

    Print( ".Count" );
    Assert( c.Count == 6 );

    Print( ".StreamPairs()" );
    var ts = c.StreamPairs();
    Assert( ts.Pull().BothEqual( 0L, 'a' ) );
    Assert( ts.Pull().BothEqual( 1L, 'b' ) );
    Assert( ts.Pull().BothEqual( 2L, 'c' ) );
    Assert( ts.Pull().BothEqual( 3L, 'd' ) );
    Assert( ts.Pull().BothEqual( 4L, 'e' ) );
    Assert( ts.Pull().BothEqual( 5L, 'f' ) );
    Assert( !ts.TryPull().A );
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
    Assert( c.Count == 0 );

    Print( ".Add() and check" );
    c.Add( "1", 1 );
    Assert( c.Count == 1 );
    Assert( c.Contains( "1" ) );
    Assert( c.Get( "1" ) == 1 );

    Print( ".Add() and check" );
    c.Add( "2", 2 );
    Assert( c.Count == 2 );
    Assert( c.Contains( "2" ) );
    Assert( c.Get( "2" ) == 2 );

    Print( ".Add() and check" );
    c.Add( "3", 3 );
    Assert( c.Count == 3 );
    Assert( c.Contains( "3" ) );
    Assert( c.Get( "3" ) == 3 );

    Print( ".Replace() and check" );
    c.Replace( "2", 22 );
    Assert( c.Count == 3 );
    Assert( c.Contains( "2" ) );
    Assert( c.Get( "2" ) == 22 );

    Print( ".Remove() and check" );
    c.Remove( "2" );
    Assert( c.Count == 2 );
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
    Assert( c.Count == 1 );
    Assert( c.Contains( "1" ) );
    Assert( c.Get( "1" ) == 1 );

    Print( "Add() another item and check" );
    c.Add( 2 );
    Assert( c.Count == 2 );
    Assert( c.Contains( "2" ) );
    Assert( c.Get( "2" ) == 2 );

    Print( "Remove() an item and check" );
    c.Remove( "1" );
    Assert( c.Count == 1 );
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
        == 2 );
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
    l = ArrayList.Create< int >();
    Assert( l.Count == 0 );

    Print( "ArrayList( ICollectionR<T> )" );
    l = ArrayList.Create( 1, 2, 3 );
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
    IOrderedCollectionRCSG< int > c
        = ArrayList.Create( 1, 2, 3, 4, 5 );

    Print( "Slice" );
    IOrderedCollectionRCSG< int > s =
        c.Slice( 1, 3 );
    Assert(
        s.Stream().AsEnumerable().SequenceEqual(
            new int[] { 2, 3, 4 } ) );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 2, 3, 4, 5 } ) );

    Print( "Insert an item at the beginning" );
    s.Add( 0, 11 );
    Assert(
        s.Stream().AsEnumerable().SequenceEqual(
            new int[] { 11, 2, 3, 4 } ) );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 11, 2, 3, 4, 5 } ) );

    Print( "Insert an item in the middle" );
    s.Add( 2, 22 );
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
    s.Remove( 0 );
    Assert(
        s.Stream().AsEnumerable().SequenceEqual(
            new int[] { 2, 22, 3, 4, 44 } ) );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 2, 22, 3, 4, 44, 5 } ) );

    Print( "Remove an item from the middle" );
    s.Remove( 1 );
    Assert(
        s.Stream().AsEnumerable().SequenceEqual(
            new int[] { 2, 3, 4, 44 } ) );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 2, 3, 4, 44, 5 } ) );

    Print( "Remove an item from the end" );
    s.Remove( 3 );
    Assert(
        s.Stream().AsEnumerable().SequenceEqual(
            new int[] { 2, 3, 4 } ) );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 2, 3, 4, 5 } ) );

    Print( "Remove all items" );
    s.Remove( 0 );
    s.Remove( 0 );
    s.Remove( 0 );
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
        ArrayList.Create< char >( "abcdefg".AsHalfdecentCollection() );

    Print( ".RemoveFirst()" );
    chars.RemoveFirst();
    Assert(
        chars.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'b', 'c', 'd', 'e', 'f', 'g' } ) );
    Print( ".RemoveFirst( IInteger )" );
    chars.RemoveFirst( 2 );
    Assert(
        chars.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'd', 'e', 'f', 'g' } ) );
    Print( ".RemoveFirst()" );
    chars.RemoveLast();
    Assert(
        chars.Stream().AsEnumerable().SequenceEqual(
            new char[]{ 'd', 'e', 'f' } ) );
    Print( ".RemoveLast( IInteger )" );
    chars.RemoveLast( 2 );
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


[Test( "TreeNode<T>" )]
public static
void
Test_TreeNode_T()
{
    TreeNode<string> root =
        new TreeNode<string>( "A1",
            new TreeNode<string>( "B1" ),
            new TreeNode<string>( "B2" ) );

    Assert( root.Item == "A1" );
    Assert( root.Children.Count == 2 );
    Assert( root.Children.Get(0).Item == "B1" );
    Assert( root.Children.Get(0).Children.Count == 0 );
    Assert( root.Children.Get(1).Item == "B2" );
    Assert( root.Children.Get(1).Children.Count == 0 );
}


[Test( "Tree.TraverseDepthFirst()" )]
public static
void
Test_Tree_TraverseDepthFirst()
{
    TreeNode<string> root =
        new TreeNode<string>( "A",
            new TreeNode<string>( "AA",
                new TreeNode<string>( "AAA" ),
                new TreeNode<string>( "AAB" ) ),
            new TreeNode<string>( "AB",
                new TreeNode<string>( "ABA" ),
                new TreeNode<string>( "ABB" ) ) );

    var events = Tree.TraverseDepthFirst( root, n => n.Children.Stream() );

    TreeEvent<TreeNode<string>> te;
    NodeTreeEvent<TreeNode<string>> tne;

    te = events.Pull();
    tne = (NodeTreeEvent<TreeNode<string>>)te;
    Assert( tne.Node.Item == "A" );

    te = events.Pull();
    Assert( te is DescendTreeEvent<TreeNode<string>> );

    te = events.Pull();
    tne = (NodeTreeEvent<TreeNode<string>>)te;
    Assert( tne.Node.Item == "AA" );

    te = events.Pull();
    Assert( te is DescendTreeEvent<TreeNode<string>> );

    te = events.Pull();
    tne = (NodeTreeEvent<TreeNode<string>>)te;
    Assert( tne.Node.Item == "AAA" );

    te = events.Pull();
    Assert( te is AscendTreeEvent<TreeNode<string>> );

    te = events.Pull();
    Assert( te is DescendTreeEvent<TreeNode<string>> );

    te = events.Pull();
    tne = (NodeTreeEvent<TreeNode<string>>)te;
    Assert( tne.Node.Item == "AAB" );

    te = events.Pull();
    Assert( te is AscendTreeEvent<TreeNode<string>> );

    te = events.Pull();
    Assert( te is AscendTreeEvent<TreeNode<string>> );

    te = events.Pull();
    Assert( te is DescendTreeEvent<TreeNode<string>> );

    te = events.Pull();
    tne = (NodeTreeEvent<TreeNode<string>>)te;
    Assert( tne.Node.Item == "AB" );

    te = events.Pull();
    Assert( te is DescendTreeEvent<TreeNode<string>> );

    te = events.Pull();
    tne = (NodeTreeEvent<TreeNode<string>>)te;
    Assert( tne.Node.Item == "ABA" );

    te = events.Pull();
    Assert( te is AscendTreeEvent<TreeNode<string>> );

    te = events.Pull();
    Assert( te is DescendTreeEvent<TreeNode<string>> );

    te = events.Pull();
    tne = (NodeTreeEvent<TreeNode<string>>)te;
    Assert( tne.Node.Item == "ABB" );

    te = events.Pull();
    Assert( te is AscendTreeEvent<TreeNode<string>> );

    te = events.Pull();
    Assert( te is AscendTreeEvent<TreeNode<string>> );

    Assert( !events.TryPull().HasValue );
}



} // type
} // namespace

