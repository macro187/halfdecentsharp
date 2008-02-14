// -----------------------------------------------------------------------------
// Copyright (c) 2007 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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
using SCG = System.Collections.Generic;
using Com.Halfdecent.Testing;
using Com.Halfdecent.System;
using Com.Halfdecent.Numerics;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Collections;
using Com.Halfdecent.Collections.SCGInterop;


namespace
Com.Halfdecent.System.Test
{




/// Tests for <tt>Com.Halfdecent.Collections.SCGInterop</tt>
public class
CollectionsSCGInteropTests
    : TestBase
{



public static SCG.IList< int >
MakeTestList()
{
    SCG.IList< int > list = new SCG.List< int >();
    list.Add( 1 );
    list.Add( 2 );
    list.Add( 3 );
    list.Add( 4 );
    list.Add( 5 );
    return list;
}



[Test( "SCGInteropAlgorithms" )]
public static
void
Test_SCGInteropAlgorithms()
{
    SCG.IList< int > list;

    Print( "IBagStreamViaIEnumerable()" );
    list = MakeTestList();
    int i = 1;
    foreach( int item in list ) {
        AssertEqual( item, i );
        Assert( i <= 5 );
        i++;
    }
    AssertEqual( i, 6 );

    Print( "IBagCountViaICollection()" );
    list = MakeTestList();
    AssertEqual(
        SCGInteropAlgorithms.IBagCountViaICollection( list ),
        Integer.From( 5 ) );

    Print( "IBagRemoveAllViaICollection()" );
    list = MakeTestList();
    SCGInteropAlgorithms.IBagRemoveAllViaICollection( list );
    AssertEqual( list.Count, 0 );
}



[Test( "IBagFromReadOnlyICollectionAdapter" )]
public static
void
Test_IBagFromReadOnlyICollectionAdapter()
{
    SCG.IList< int >                            list;
    IBagFromReadOnlyICollectionAdapter< int >   adapter;
    IFiniteStream< int >                        stream;
    bool                                        threw;
    int                                         i;

    Print( "new( null ) throws BugException" );
    threw = false;
    adapter = null;
    try {
        adapter = new IBagFromReadOnlyICollectionAdapter< int >( null );
    } catch( BugException ) {
        threw = true;
    }
    AssertEqual( threw, true );

    Print( "new()" );
    list = MakeTestList();
    adapter = new IBagFromReadOnlyICollectionAdapter< int >( list );

    Print( "Count" );
    list = MakeTestList();
    adapter = new IBagFromReadOnlyICollectionAdapter< int >( list );
    AssertEqual( adapter.Count, Integer.From( 5 ) );

    Print( "Stream()" );
    list = MakeTestList();
    adapter = new IBagFromReadOnlyICollectionAdapter< int >( list );
    stream = adapter.Stream();
    Assert( stream != null );
    i = 1;
    foreach( int item in stream ) {
        AssertEqual( item, i );
        Assert( i <= 5 );
        i++;
    }
    AssertEqual( i, 6 );

    if( adapter == null ) {} // avoid warning
}



[Test( "IBagFromGrowableICollectionAdapter" )]
public static
void
Test_IBagFromGrowableICollectionAdapter()
{
    SCG.IList< int >                            list;
    IBagFromGrowableICollectionAdapter< int >   adapter;
    bool                                        threw;
    int                                         i;

    Print( "Add()" );
    list = MakeTestList();
    adapter = new IBagFromGrowableICollectionAdapter< int >( list );
    adapter.Add( 6 );
    AssertEqual( adapter.Count, Integer.From( 6 ) );
    i = 1;
    foreach( int item in adapter.Stream() ) {
        AssertEqual( item, i );
        Assert( i <= 6 );
        i++;
    }
    AssertEqual( i, 7 );

    Print( "Add() to non-growable collection throws BugException" );
    adapter = new IBagFromGrowableICollectionAdapter< int >(
        new int[] { 1, 2, 3, 4, 5 } );
    threw = false;
    try {
        adapter.Add( 6 );
    } catch( BugException ) {
        threw = true;
    }
    AssertEqual( threw, true );

    if( adapter == null ) {} // avoid warning
}



[Test( "IBagFromShrinkableICollectionAdapter" )]
public static
void
Test_IBagFromShrinkableICollectionAdapter()
{
    SCG.IList< int >                            list;
    IBagFromShrinkableICollectionAdapter< int > adapter;
    bool                                        threw;

    Print( "RemoveAll()" );
    list = MakeTestList();
    adapter = new IBagFromShrinkableICollectionAdapter< int >( list );
    adapter.RemoveAll();
    AssertEqual( adapter.Count, Integer.From( 0 ) );

    Print( "RemoveAll() on non-shrinkable collection throws BugException" );
    adapter = new IBagFromShrinkableICollectionAdapter< int >(
        new int[] { 1, 2, 3, 4, 5 } );
    threw = false;
    try {
        adapter.RemoveAll();
    } catch( BugException ) {
        threw = true;
    }
    AssertEqual( threw, true );

    if( adapter == null ) {} // avoid warning
}



[Test( "IBagFromResizableICollectionAdapter" )]
public static
void
Test_IBagFromResizableICollectionAdapter()
{
    SCG.IList< int >                            list;
    IBagFromResizableICollectionAdapter< int >  adapter;
    bool                                        threw;
    int                                         i;

    Print( "Add()" );
    list = MakeTestList();
    adapter = new IBagFromResizableICollectionAdapter< int >( list );
    adapter.Add( 6 );
    AssertEqual( adapter.Count, Integer.From( 6 ) );
    i = 1;
    foreach( int item in adapter.Stream() ) {
        AssertEqual( item, i );
        Assert( i <= 6 );
        i++;
    }
    AssertEqual( i, 7 );

    Print( "Add() to non-growable collection throws BugException" );
    adapter = new IBagFromResizableICollectionAdapter< int >(
        new int[] { 1, 2, 3, 4, 5 } );
    threw = false;
    try {
        adapter.Add( 6 );
    } catch( BugException ) {
        threw = true;
    }
    AssertEqual( threw, true );


    Print( "RemoveAll()" );
    list = MakeTestList();
    adapter = new IBagFromResizableICollectionAdapter< int >( list );
    adapter.RemoveAll();
    AssertEqual( adapter.Count, Integer.From( 0 ) );

    Print( "RemoveAll() on non-shrinkable collection throws BugException" );
    adapter = new IBagFromResizableICollectionAdapter< int >(
        new int[] { 1, 2, 3, 4, 5 } );
    threw = false;
    try {
        adapter.RemoveAll();
    } catch( BugException ) {
        threw = true;
    }
    AssertEqual( threw, true );

    if( adapter == null ) {} // avoid warning
}



[Test( "IListFromReadOnlyIListAdapter" )]
public static
void
Test_IListFromReadOnlyIListAdapter()
{
    IListFromReadOnlyIListAdapter< int >    list
        = new IListFromReadOnlyIListAdapter< int >(
            new int[] { 0, 1, 2 } );
    IFiniteStream< int >                    stream;
    int                                     i;
    int                                     j;
    bool                                    threw;

    Print( "GetAt()" );
    AssertEqual( list.GetAt( Integer.From( 0 ) ), 0 );
    AssertEqual( list.GetAt( Integer.From( 1 ) ), 1 );
    AssertEqual( list.GetAt( Integer.From( 2 ) ), 2 );

    Print( "GetAt( -1 ) throws ValueException" );
    threw = false;
    try {
        list.GetAt( Integer.From( -1 ) );
    } catch( ValueException ) {
        threw = true;
    }
    AssertEqual( threw, true );

    Print( "GetAt( Count ) throws ValueException" );
    threw = false;
    try {
        list.GetAt( list.Count );
    } catch( ValueException ) {
        threw = true;
    }
    AssertEqual( threw, true );

    Print( "StreamForward()" );
    stream = list.StreamForward();
    i = 0;
    while( stream.Yield( out j ) ) {
        AssertEqual( j, i );
        i++;
    }
    AssertEqual( i, 3 );

    Print( "StreamBackward()" );
    stream = list.StreamBackward();
    i = 2;
    while( stream.Yield( out j ) ) {
        AssertEqual( j, i );
        i--;
    }
    AssertEqual( i, -1 );
}




} // type
} // namespace

