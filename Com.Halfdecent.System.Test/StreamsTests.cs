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
using System.Collections.Generic;
using Com.Halfdecent.System;
using Com.Halfdecent.Testing;
using Com.Halfdecent.Streams;



namespace
Com.Halfdecent.System.Test
{



/// <summary>
/// Tests for <c>Com.Halfdecent.Streams</c>
/// </summary>
public class
StreamsTests
    : TestBase
{




// -----------------------------------------------------------------------------
// Tests
// -----------------------------------------------------------------------------

[Test( "IEnumeratorToIStreamAdapter" )]
public static void
Test_IEnumeratorToIStreamAdapter()
{
    IStream<int> stream =
        new IEnumeratorToIStreamAdapter<int>( CountToFive() );

    Print( "Stream yields correct items" );
    int c = 1;
    while( c <= 5 ) {
        AssertEqual( stream.Yield(), c );
        c++;
    }

    Print( "InvalidOperationException if we keep going" );
    bool thrown = false;
    try {
        stream.Yield();
    } catch( InvalidOperationException ioe ) {
        thrown = true;
        if( ioe != null ) {}
    }
    Assert( thrown );

    Print( "Multiple GetEnumerator() calls return the same instance" );
    IEnumerator<int> e = ((IEnumerable<int>)stream).GetEnumerator();
    AssertEqual( e, ((IEnumerable<int>)stream).GetEnumerator() );
    AssertEqual( e, ((IEnumerable<int>)stream).GetEnumerator() );
    AssertEqual( e, ((IEnumerable<int>)stream).GetEnumerator() );
    // ...
}



[Test( "IStreamToIEnumeratorAdapter" )]
public static void
Test_IStreamToIEnumeratorAdapter()
{
    IStream<int> stream = new IEnumeratorToIStreamAdapter<int>( CountToFive() );
    IEnumerator<int> e = ((IEnumerable<int>)stream).GetEnumerator();
    bool thrown;

    Print( "InvalidOperationException on Current before MoveNext()" );
    thrown = false;
    try {
        if( e.Current == 0 ) {}
    } catch( InvalidOperationException ioe ) {
        thrown = true;
        if( ioe == null ) {}
    }
    AssertEqual( thrown, true );

    Print( "Check the items via multiple foreach loops" );
    int i = 1;
    foreach( int item in stream ) {
        AssertEqual( item, i );
        i++;
        if( i > 3 ) break;
    }
    foreach( int item in stream ) {
        AssertEqual( item, i );
        i++;
        if( i > 5 ) break;
    }

    Print( "Check that InvalidOperationException thrown if we keep going" );
    thrown = false;
    try {
        foreach( int item in stream ) {
            if( item == 0 ) {}
        }
    } catch( InvalidOperationException ioe ) {
        thrown = true;
        if( ioe != null ) {}
    }
    Assert( thrown );
}



[Test( "IEnumeratorToIFiniteStreamAdapter" )]
public static void
Test_IEnumeratorToIFiniteStreamAdapter()
{
    IFiniteStream<int> stream =
        new IEnumeratorToIFiniteStreamAdapter<int>( CountToFive() );

    Print( "Check that stream yields correct items" );
    int c = 1;
    int i;
    while( stream.Yield( out i ) ) {
        AssertEqual( i, c );
        c++;
    }
    AssertEqual( c, 6 );

    Print( "Multiple GetEnumerator() calls return the same instance" );
    IEnumerator<int> e = ((IEnumerable<int>)stream).GetEnumerator();
    AssertEqual( e, ((IEnumerable<int>)stream).GetEnumerator() );
    AssertEqual( e, ((IEnumerable<int>)stream).GetEnumerator() );
    AssertEqual( e, ((IEnumerable<int>)stream).GetEnumerator() );
    // ...
}



[Test( "IFiniteStreamToIEnumeratorAdapter" )]
public static void
Test_IFiniteStreamToIEnumeratorAdapter()
{
    IFiniteStream<int> stream =
        new IEnumeratorToIFiniteStreamAdapter<int>( CountToFive() );
    IEnumerator<int> e = ((IEnumerable<int>)stream).GetEnumerator();
    bool thrown;

    Print( "InvalidOperationException on Current before first MoveNext()" );
    thrown = false;
    try {
        if( e.Current == 0 ) {}
    } catch( InvalidOperationException ioe ) {
        thrown = true;
        if( ioe == null ) {}
    }
    AssertEqual( thrown, true );

    Print( "Check the items via multiple foreach loops" );
    int i = 1;
    foreach( int item in stream ) {
        AssertEqual( item, i );
        i++;
        if( i > 3 ) break;
    }
    AssertEqual( i, 4 );
    foreach( int item in stream ) {
        AssertEqual( item, i );
        i++;
    }
    AssertEqual( i, 6 );

    Print( "InvalidOperationException on Current after MoveNext()==false" );
    thrown = false;
    try {
        if( e.Current == 0 ) {}
    } catch( InvalidOperationException ioe ) {
        thrown = true;
        if( ioe != null ) {}
    }
    Assert( thrown );
}



private static IEnumerator<int>
CountToFive()
{
    yield return 1;
    yield return 2;
    yield return 3;
    yield return 4;
    yield return 5;
}




} // type
} // namespace

