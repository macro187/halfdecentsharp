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
using Com.Halfdecent.Testing;
using Com.Halfdecent.Streams;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.Streams.Test
{


// =============================================================================
/// Test program for <tt>Com.Halfdecent.Streams</tt>
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
    : StreamBase< int >
{
    public
    TestStream() {}

    private
    int
    i = 1;

    public override
    bool
    Yield(
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



[Test( "IStreamBase< T >" )]
public static
void
Test_IStreamBase_T()
{
    IStream< int > s = new TestStream();

    int i;
    bool b;

    Print( "Item #1" );
    b = s.Yield( out i );
    Assert( b );
    AssertEqual( i, i );

    Print( "Item #2" );
    b = s.Yield( out i );
    Assert( b );
    AssertEqual( i, 2 );

    Print( "Item #3" );
    b = s.Yield( out i );
    Assert( b );
    AssertEqual( i, 3 );

    Print( "End of stream" );
    b = s.Yield( out i );
    Assert( !b );
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
    b = s.Yield( out i );
    Assert( b );
    AssertEqual( i, i );

    Print( "Item #2" );
    b = s.Yield( out i );
    Assert( b );
    AssertEqual( i, 2 );

    Print( "Item #3" );
    b = s.Yield( out i );
    Assert( b );
    AssertEqual( i, 3 );

    Print( "End of stream" );
    b = s.Yield( out i );
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



[Test( "StreamTypeAdapter< T >" )]
public static
void
Test_StreamTypeAdapter_T()
{
    IStream< object > s =
        new StreamTypeAdapter< int, object >(
            new StreamFromEnumeratorAdapter< int >(
                IntEnumerable().GetEnumerator() ) );

    bool b;
    object o;
    Print( "First item" );

    b = s.Yield( out o );
    Assert( b );
    AssertEqual( (int)o, 1 );

    Print( "Second item" );
    b = s.Yield( out o );
    Assert( b );
    AssertEqual( (int)o, 2 );

    Print( "Third item" );
    b = s.Yield( out o );
    Assert( b );
    AssertEqual( (int)o, 3 );

    Print( "End of stream" );
    b = s.Yield( out o );
    Assert( !b );

}




} // type
} // namespace
