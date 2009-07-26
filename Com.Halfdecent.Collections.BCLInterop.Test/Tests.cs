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


[Test( "ReadOnlyBagFromSCGCollectionAdapter< T >" )]
public static
void
Test_ReadOnlyBagFromSCGCollectionAdapter()
{
    int[]                                       from = new int[] { 1, 2, 3 };
    ReadOnlyBagFromSCGCollectionAdapter< int >  bag = from.AsReadOnlyBag();
    SCG.List< int >                             to = new SCG.List< int >();

    Print( "Check .Count" );
    Assert( bag.Count.ToDecimal() == 3 );

    Print( "Check items via Stream()" );
    foreach( int i in bag.Stream().AsEnumerable() ) to.Add( i );
    to.Sort();  // Bags are unordered
    Assert( to.SequenceEqual( from ) );
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

    Print( "Check initial .Count" );
    Assert( bag.Count.ToDecimal() == 0 );

    Print( "Add items" );
    foreach( int i in from ) bag.Push( i );

    Print( "Check .Count" );
    Assert( bag.Count.ToDecimal() == 3 );

    Print( "Check items via Stream()" );
    to.Clear();
    foreach( int i in bag.Stream().AsEnumerable() ) to.Add( i );
    to.Sort();  // Bags are unordered
    Assert( to.SequenceEqual( from ) );

    Print( "Clear() out all items" );
    bag.Clear();

    Print( "Check .Count" );
    AssertEqual( bag.Count.ToDecimal(), 0 );
}


[Test( "BagToSCGCollectionAdapter" )]
public static
void
Test_BagToSCGCollectionAdapter()
{
    BagFromSCGCollectionAdapter< int > bag =
        new BagFromSCGCollectionAdapter< int >( new SCG.List< int >() );
    SCG.ICollection< int > col = bag.AsSCGCollection();

    SCG.List< int > list = new SCG.List< int >();

    Print( "Add 3 items" );
    col.Add( 1 );
    col.Add( 2 );
    col.Add( 3 );

    Print( "Check .Count" );
    AssertEqual( col.Count, 3 );

    Print( "Check items" );
    list.Clear();
    col.AsBag().Stream().EmptyTo( list.AsBag() );
    list.Sort();
    Assert( list.SequenceEqual( new int[] { 1, 2, 3 } ) );

    Print( "Check for existence of a particular item" );
    Assert( col.Contains( 2 ) );

    Print( "Remove it" );
    col.Remove( 2 );

    Print( "Check new .Count" );
    AssertEqual( col.Count, 2 );

    Print( "Check new items" );
    list.Clear();
    col.AsBag().Stream().EmptyTo( list.AsBag() );
    list.Sort();
    Assert( list.SequenceEqual( new int[] { 1, 3 } ) );

    Print( "Check that item doesn't exist anymore" );
    Assert( !col.Contains( 2 ) );
}




} // type
} // namespace

