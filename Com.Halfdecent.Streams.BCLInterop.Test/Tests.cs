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


using System;
using System.Collections.Generic;
using System.Linq;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Streams.BCLInterop;
using Com.Halfdecent.Testing;


namespace
Com.Halfdecent.Streams.BCLInterop.Test
{


// =============================================================================
/// Test program for <tt>Com.Halfdecent.Streams.BCLInterop</tt>
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



// Test stream
//
private class
TestStream
    : IStream< int >
{
    private
    int
    i = 1;

    public
    bool
    TryPull(
        out int item
    )
    {
        if( i <= 3 ) {
            item = i;
            i++;
            return true;
        } else {
            item = default( int );
            return false;
        }
    }
}



// Test enumerable
//
private static
IEnumerable< int >
IntEnumerable()
{
    yield return 1;
    yield return 2;
    yield return 3;
}



[Test( "StreamFromEnumeratorAdapter< T >" )]
public static
void
Test_StreamFromEnumeratorAdapter_T()
{
    IStream< int > s =
        new StreamFromEnumeratorAdapter< int >(
            IntEnumerable().GetEnumerator() );

    int i;
    bool b;

    Print( "Item #1" );
    b = s.TryPull( out i );
    Assert( b );
    AssertEqual( i, i );

    Print( "Item #2" );
    b = s.TryPull( out i );
    Assert( b );
    AssertEqual( i, 2 );

    Print( "Item #3" );
    b = s.TryPull( out i );
    Assert( b );
    AssertEqual( i, 3 );

    Print( "End of stream" );
    b = s.TryPull( out i );
    Assert( !b );
}



[Test( "StreamToEnumeratorAdapter< T >" )]
public static
void
Test_StreamToEnumeratorAdapter_T()
{
    IEnumerator< int > e =
        new StreamToEnumeratorAdapter< int >(
            new TestStream() );

    bool b;

    Print( "Item #1" );
    b = e.MoveNext();
    Assert( b );
    AssertEqual( e.Current, 1 );

    Print( "Item #2" );
    b = e.MoveNext();
    Assert( b );
    AssertEqual( e.Current, 2 );

    Print( "Item #3" );
    b = e.MoveNext();
    Assert( b );
    AssertEqual( e.Current, 3 );

    Print( "End of enumerator" );
    b = e.MoveNext();
    Assert( !b );
}



[Test( "EnumeratorToEnumerableAdapter< T >" )]
public static
void
Test_EnumeratorToEnumerableAdapter_T()
{
    IEnumerable< int > enumerable =
        new EnumeratorToEnumerableAdapter< int >(
            new StreamToEnumeratorAdapter< int >(
                new TestStream() ) );

    IEnumerator< int > e = enumerable.GetEnumerator();

    bool b;

    Print( "Item #1" );
    b = e.MoveNext();
    Assert( b );
    AssertEqual( e.Current, 1 );

    Print( "Item #2" );
    b = e.MoveNext();
    Assert( b );
    AssertEqual( e.Current, 2 );

    Print( "Item #3" );
    b = e.MoveNext();
    Assert( b );
    AssertEqual( e.Current, 3 );

    Print( "End of enumerator" );
    b = e.MoveNext();
    Assert( !b );

    e = enumerable.GetEnumerator();

    Print( "Still end of enumerator with new GetEnumerator()" );
    b = e.MoveNext();
    Assert( !b );
}



[Test( "Stream.AsEnumerable( this IStream )" )]
public static
void
Test_Stream_AsEnumerable()
{
    IStream< int > s =
        new StreamFromEnumeratorAdapter< int >(
            IntEnumerable().GetEnumerator() );
    IEnumerable< int > e = IntEnumerable();
    Print( "Items in enumerable accurately reflect stream" );
    Assert( s.AsEnumerable().SequenceEqual( e ) );
}



[Test( "Enumerable.AsStream()" )]
public static
void
Test_Enumerable_AsStream()
{
    IStream< int > s =
        IntEnumerable().AsStream();
    IEnumerable< int > e = IntEnumerable();

    Print( "Items in stream accurately reflect enumerable" );
    Assert( s.AsEnumerable().SequenceEqual( e ) );
}




} // type
} // namespace

