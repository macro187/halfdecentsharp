// -----------------------------------------------------------------------------
// Copyright (c) 2009
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
using System.Linq;
using SCG = System.Collections.Generic;
using Com.Halfdecent.Testing;
using Com.Halfdecent.Collections;
using Com.Halfdecent.Collections.BCLInterop;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Streams.BCLInterop;


namespace
Com.Halfdecent.Streams.BCLInterop.Test
{


// =============================================================================
/// Test program for <tt>Com.Halfdecent.Collections.BCLInterop</tt>
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


[Test( "ReadOnlyBagFromSCGCollectionAdapter< T >" )]
public static
void
Test_ReadOnlyBagFromSCGCollectionAdapter()
{
    ReadOnlyBagFromSCGCollectionAdapter< int >  bag;
    SCG.List< int >                             to = new SCG.List< int >();

    Print( "Empty bag" );
    bag = new int[] {}.AsReadOnlyBag();

    Print( ".Count" );
    AssertEqual( bag.Count.ToDecimal(), 0 );

    Print( ".IsEmpty" );
    Assert( bag.IsEmpty );

    Print( ".Stream()" );
    foreach( int i in bag.Stream().AsEnumerable() ) to.Add( i );
    to.Sort();  // Bags are unordered
    Assert( to.SequenceEqual( new int[] {} ) );

    Print( ".Contains()" );
    Assert( !bag.Contains( 1 ) );
    Assert( !bag.Contains( 2 ) );
    Assert( !bag.Contains( 3 ) );
    Assert( !bag.Contains( 4 ) );

    Print( "Non-empty bag" );
    bag = new int[] { 1, 2, 3 }.AsReadOnlyBag();

    Print( ".Count" );
    AssertEqual( bag.Count.ToDecimal(), 3 );

    Print( ".IsEmpty" );
    Assert( !bag.IsEmpty );

    Print( ".Stream()" );
    foreach( int i in bag.Stream().AsEnumerable() ) to.Add( i );
    to.Sort();  // Bags are unordered
    Assert( to.SequenceEqual( new int[] { 1, 2, 3 } ) );

    Print( ".Contains()" );
    Assert( bag.Contains( 1 ) );
    Assert( bag.Contains( 2 ) );
    Assert( bag.Contains( 3 ) );
    Assert( !bag.Contains( 4 ) );
}


[Test( "BagFromSCGCollectionAdapter< T >" )]
public static
void
Test_BagFromSCGCollectionAdapter()
{
    int[]                               from = new int[] { 1, 2, 3 };
    SCG.List< int >                     list = new SCG.List< int >();
    BagFromSCGCollectionAdapter< int >  bag = list.AsBag();
    SCG.List< int >                     to = new SCG.List< int >();

    Print( ".Count" );
    AssertEqual( bag.Count.ToDecimal(), 0 );

    Print( ".IsEmpty" );
    Assert( bag.IsEmpty );

    Print( ".Contains()" );
    Assert( !bag.Contains( 1 ) );
    Assert( !bag.Contains( 2 ) );
    Assert( !bag.Contains( 3 ) );
    Assert( !bag.Contains( 4 ) );

    Print( ".Stream()" );
    to.Clear();
    foreach( int i in bag.Stream().AsEnumerable() ) to.Add( i );
    to.Sort();  // Bags are unordered
    Assert( to.SequenceEqual( new int[] {} ) );

    Print( ".Push() some items" );
    foreach( int i in from ) bag.Push( i );

    Print( ".Count" );
    AssertEqual( bag.Count.ToDecimal(), 3 );

    Print( ".IsEmpty" );
    Assert( !bag.IsEmpty );

    Print( ".Contains()" );
    Assert( bag.Contains( 1 ) );
    Assert( bag.Contains( 2 ) );
    Assert( bag.Contains( 3 ) );
    Assert( !bag.Contains( 4 ) );

    Print( ".Stream()" );
    to.Clear();
    foreach( int i in bag.Stream().AsEnumerable() ) to.Add( i );
    to.Sort();  // Bags are unordered
    Assert( to.SequenceEqual( from ) );

    Print( ".Remove() an item" );
    bag.Remove( 2 );

    Print( ".Count" );
    AssertEqual( bag.Count.ToDecimal(), 2 );

    Print( ".IsEmpty" );
    Assert( !bag.IsEmpty );

    Print( ".Contains()" );
    Assert( bag.Contains( 1 ) );
    Assert( !bag.Contains( 2 ) );
    Assert( bag.Contains( 3 ) );
    Assert( !bag.Contains( 4 ) );

    Print( ".Stream()" );
    to.Clear();
    foreach( int i in bag.Stream().AsEnumerable() ) to.Add( i );
    to.Sort();  // Bags are unordered
    Assert( to.SequenceEqual( new int[] { 1, 3 } ) );

    Print( ".Clear() out all items" );
    bag.Clear();

    Print( ".Count" );
    AssertEqual( bag.Count.ToDecimal(), 0 );

    Print( ".IsEmpty" );
    Assert( bag.IsEmpty );

    Print( ".Contains()" );
    Assert( !bag.Contains( 1 ) );
    Assert( !bag.Contains( 2 ) );
    Assert( !bag.Contains( 3 ) );
    Assert( !bag.Contains( 4 ) );
}


[Test( "BagToSCGCollectionAdapter" )]
public static
void
Test_BagToSCGCollectionAdapter()
{

    // TODO Check all variations of bag (shrinkable, growable, both, etc.)

    SCG.ICollection< int >  col;
    SCG.List< int >         list = new SCG.List< int >();

    Print( "Empty read-only collection" );
    col = new int[]{}.AsReadOnlyBag().AsSCGCollection();

    Print( ".IsReadOnly" );
    Assert( col.IsReadOnly );

    Print( ".Count" );
    AssertEqual( col.Count, 0 );

    Print( ".Contains()" );
    Assert( !col.Contains( 1 ) );
    Assert( !col.Contains( 2 ) );
    Assert( !col.Contains( 3 ) );
    Assert( !col.Contains( 4 ) );

    Print( ".GetEnumerator() to check items" );
    list.Clear();
    foreach( int i in col ) list.Add( i );
    list.Sort();
    Assert( list.SequenceEqual( new int[] {} ) );

    Print( ".Add() throws NotSupportedException" );
    Expect< NotSupportedException >( () => col.Add( 1 ) );

    Print( ".Clear() throws NotSupportedException" );
    Expect< NotSupportedException >( () => col.Clear() );

    Print( ".Remove() throws NotSupportedException" );
    Expect< NotSupportedException >( () => col.Remove( 1 ) );


    Print( "Non-empty read-only collection" );
    col = new int[]{ 1, 2, 3 }.AsReadOnlyBag().AsSCGCollection();

    Print( ".IsReadOnly" );
    Assert( col.IsReadOnly );

    Print( ".Count" );
    AssertEqual( col.Count, 3 );

    Print( ".Contains()" );
    Assert( col.Contains( 1 ) );
    Assert( col.Contains( 2 ) );
    Assert( col.Contains( 3 ) );
    Assert( !col.Contains( 4 ) );

    Print( ".GetEnumerator() to check items" );
    list.Clear();
    foreach( int i in col ) list.Add( i );
    list.Sort();
    Assert( list.SequenceEqual( new int[] { 1, 2, 3 } ) );

    Print( ".Add() throws NotSupportedException" );
    Expect< NotSupportedException >( () => col.Add( 1 ) );

    Print( ".Clear() throws NotSupportedException" );
    Expect< NotSupportedException >( () => col.Clear() );

    Print( ".Remove() throws NotSupportedException" );
    Expect< NotSupportedException >( () => col.Remove( 1 ) );


    Print( "Writable collection" );
    col = new SCG.List< int >().AsBag().AsSCGCollection();

    Print( ".IsReadOnly" );
    Assert( !col.IsReadOnly );

    Print( ".Count" );
    AssertEqual( col.Count, 0 );

    Print( ".Contains()" );
    Assert( !col.Contains( 1 ) );
    Assert( !col.Contains( 2 ) );
    Assert( !col.Contains( 3 ) );
    Assert( !col.Contains( 4 ) );

    Print( ".GetEnumerator() to check items" );
    list.Clear();
    foreach( int i in col ) list.Add( i );
    list.Sort();
    Assert( list.SequenceEqual( new int[] {} ) );

    Print( ".Add()" );
    col.Add( 1 );
    col.Add( 2 );
    col.Add( 3 );

    Print( ".Count" );
    AssertEqual( col.Count, 3 );

    Print( ".Contains()" );
    Assert( col.Contains( 1 ) );
    Assert( col.Contains( 2 ) );
    Assert( col.Contains( 3 ) );
    Assert( !col.Contains( 4 ) );

    Print( ".GetEnumerator() to check items" );
    list.Clear();
    foreach( int i in col ) list.Add( i );
    list.Sort();
    Assert( list.SequenceEqual( new int[] { 1, 2, 3 } ) );

    Print( ".Remove()" );
    col.Remove( 2 );

    Print( ".Count" );
    AssertEqual( col.Count, 2 );

    Print( ".Contains()" );
    Assert( col.Contains( 1 ) );
    Assert( !col.Contains( 2 ) );
    Assert( col.Contains( 3 ) );
    Assert( !col.Contains( 4 ) );

    Print( ".GetEnumerator() to check items" );
    list.Clear();
    foreach( int i in col ) list.Add( i );
    list.Sort();
    Assert( list.SequenceEqual( new int[] { 1, 3 } ) );

    Print( ".Clear()" );
    col.Clear();

    Print( ".Count" );
    AssertEqual( col.Count, 0 );

    Print( ".Contains()" );
    Assert( !col.Contains( 1 ) );
    Assert( !col.Contains( 2 ) );
    Assert( !col.Contains( 3 ) );
    Assert( !col.Contains( 4 ) );

    Print( ".GetEnumerator() to check items" );
    list.Clear();
    foreach( int i in col ) list.Add( i );
    list.Sort();
    Assert( list.SequenceEqual( new int[] {} ) );
}




} // type
} // namespace

