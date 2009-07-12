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
using Com.Halfdecent.Testing;


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
    : IStream< int >
{
    private
    int[]
    items = new int[] { 1, 2, 3 };

    private
    int
    i = 0;

    public
    IEnumerable< int >
    Items
    {
        get { return this.items; }
    }

    public
    bool
    TryPull(
        out int item
    )
    {
        if( this.i >= this.items.Length ) {
            item = default( int );
            return false;
        }
        item = this.items[ i ];
        i++;
        return true;
    }
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



[Test( "Stream.Pull( this IStream )" )]
public static
void
Test_Stream_Pull()
{
    IStream< int > s = new TestStream();

    int i;

    Print( "Item #1" );
    i = s.Pull();
    AssertEqual( i, i );

    Print( "Item #2" );
    i = s.Pull();
    AssertEqual( i, 2 );

    Print( "Item #3" );
    i = s.Pull();
    AssertEqual( i, 3 );

    Print( "EmptyException" );
    Expect< EmptyException >( delegate() {
        i = s.Pull();
    } );
}



// A test ISink<T> implementation that holds 3 ints
private class
TestSink
    :ISink< int >
{
    public
    int[]
    Items = new int[3];

    public
    bool
    TryPush(
        int item
    )
    {
        if( this.current >= this.Items.Length ) return false;
        this.Items[ this.current ] = item;
        this.current++;
        return true;
    }

    private
    int
    current = 0;
}



[Test( "Sink.Push()" )]
public static
void
Test_Sink_Push()
{
    TestSink ts = new TestSink();
    ISink< int > s = ts;
    Print( "Push items" );
    s.Push( 0 );
    s.Push( 1 );
    s.Push( 2 );
    Print( "Check pushed items" );
    AssertEqual( ts.Items[0], 0 );
    AssertEqual( ts.Items[1], 1 );
    AssertEqual( ts.Items[2], 2 );
    Print( "FullException if we try to push another" );
    Expect< FullException >( delegate() {
        s.Push( 3 );
    } );
}



[Test( "Stream.EmptyTo()" )]
public static
void
Test_Stream_EmptyTo()
{
    TestStream from = new TestStream();
    TestSink to = new TestSink();
    Print( "EmptyTo() a sink" );
    from.EmptyTo( to );
    Print( "Check items" );
    Assert( to.Items.SequenceEqual( from.Items ) );
}




} // type
} // namespace

