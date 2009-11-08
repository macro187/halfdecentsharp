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
using Com.Halfdecent.Collections.SystemInterop;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Streams.SystemInterop;


namespace
Com.Halfdecent.Streams.SystemInterop.Test
{


// =============================================================================
/// Test program for <tt>Com.Halfdecent.Collections.SystemInterop</tt>
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


[Test( "BagFromSystemCollectionAdapter< T >" )]
public static
void
Test_BagFromSystemCollectionAdapter()
{
    BagFromSystemCollectionAdapter< int > bag;
    SCG.List< int > to = new SCG.List< int >();

    Print( "Empty bag" );
    bag = new int[] {}.AsBag();

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
    bag = new int[] { 1, 2, 3 }.AsBag();

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


[Test( "GrowableShrinkableBagFromSystemCollectionAdapter< T >" )]
public static
void
Test_GrowableShrinkableBagFromSystemCollectionAdapter()
{
    int[]           from = new int[] { 1, 2, 3 };
    SCG.List< int > list = new SCG.List< int >();
    GrowableShrinkableBagFromSystemCollectionAdapter< int >
                    bag = list.AsGrowableShrinkableBag();
    SCG.List< int > to = new SCG.List< int >();

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

    Print( ".Add() some items" );
    foreach( int i in from ) bag.Add( i );

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
    bag.RemoveAll();

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


[Test( "BagToSystemCollectionAdapter" )]
public static
void
Test_BagToSystemCollectionAdapter()
{
    SCG.ICollection< int >  col;
    SCG.List< int >         list = new SCG.List< int >();
    int[]                   a;

    Print( "Empty read-only collection" );
    col = new int[]{}.AsBag().AsSystemCollection();

    Print( ".IsReadOnly" );
    Assert( col.IsReadOnly );

    Print( ".Count" );
    AssertEqual( col.Count, 0 );

    Print( ".Contains()" );
    Assert( !col.Contains( 1 ) );
    Assert( !col.Contains( 2 ) );
    Assert( !col.Contains( 3 ) );
    Assert( !col.Contains( 4 ) );

    Print( "Null array to .CopyTo() throws ArgumentNullException" );
    Expect< ArgumentNullException >( () => col.CopyTo( null, 0 ) );

    Print( "Negative index to .CopyTo() throws ArgumentOutOfRangeException" );
    Expect<
        ArgumentOutOfRangeException >(
        () => col.CopyTo( new int[]{}, -1 ) );

    Print( "Empty array to .CopyTo() allowed if collection is empty" );
    col.CopyTo( new int[]{}, 0 );

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
    col = new int[]{ 1, 2, 3 }.AsBag().AsSystemCollection();

    Print( ".IsReadOnly" );
    Assert( col.IsReadOnly );

    Print( ".Count" );
    AssertEqual( col.Count, 3 );

    Print( ".Contains()" );
    Assert( col.Contains( 1 ) );
    Assert( col.Contains( 2 ) );
    Assert( col.Contains( 3 ) );
    Assert( !col.Contains( 4 ) );

    Print( "Array without enough space to .CopyTo() throws ArgumentException" );
    Expect<
        ArgumentException >(
        () => col.CopyTo( new int[]{ 0 }, 0 ) );

    Print( ".CopyTo() to check items" );
    a = new int[]{ 0, 0, 0, 0 };
    col.CopyTo( a, 1 );
    Assert( a.SequenceEqual( new int[] { 0, 1, 2, 3 } ) );

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
    col = new SCG.List< int >().AsGrowableShrinkableBag().AsSystemCollection();

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

