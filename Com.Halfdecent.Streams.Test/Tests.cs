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



[Test( "Stream< T >" )]
public static
void
Test_Stream_T()
{
    IStream< int > s = new Stream< int >( 1, 2, 3 );

    int i;
    bool b;

    Print( "Item #1" );
    b = s.TryPull( out i );
    Assert( b );
    Assert( i == 1 );

    Print( "Item #2" );
    b = s.TryPull( out i );
    Assert( b );
    Assert( i == 2 );

    Print( "Item #3" );
    b = s.TryPull( out i );
    Assert( b );
    Assert( i == 3 );

    Print( "End of stream" );
    b = s.TryPull( out i );
    Assert( !b );
}



[Test( "Stream.Pull( this IStream )" )]
public static
void
Test_Stream_Pull()
{
    IStream< int > s = new Stream< int >( 1, 2, 3 );

    int i;

    Print( "Item #1" );
    i = s.Pull();
    Assert( i == 1 );

    Print( "Item #2" );
    i = s.Pull();
    Assert( i == 2 );

    Print( "Item #3" );
    i = s.Pull();
    Assert( i == 3 );

    Print( "EmptyException" );
    Expect< EmptyException >( () =>
        i = s.Pull() );
}



// A test ISink<T> implementation that holds 3 ints
private class
TestSink
    : ISink< int >
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



[Test( "Sink.Push( this ISink )" )]
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
    Assert( ts.Items[0] == 0 );
    Assert( ts.Items[1] == 1 );
    Assert( ts.Items[2] == 2 );
    Print( "FullException if we try to push another" );
    Expect< FullException >( () =>
        s.Push( 3 ) );
}



[Test( "Stream.EmptyTo()" )]
public static
void
Test_Stream_EmptyTo()
{
    int[] items = new int[] { 1, 2, 3 };
    Print( "EmptyTo() a sink" );
    TestSink sink = new TestSink();
    new Stream< int >( items ).EmptyTo( sink );
    Print( "Check items" );
    Assert( sink.Items.SequenceEqual( items ) );
}


[Test( "Stream<T>.Empty" )]
public static
void
Test_Stream_T_Empty()
{
    IStream< int > s = Stream< int >.Empty;
    int i;
    Assert( !s.TryPull( out i ) );
}


[Test( "Stream.AsEnumerable( this IStream )" )]
public static
void
Test_Stream_AsEnumerable()
{
    int[] items = new int[] { 1, 2, 3 };
    Print( "Items in enumerable accurately reflect stream" );
    Assert( new Stream< int >( items ).AsEnumerable().SequenceEqual( items ) );
}



[Test( "Enumerable.AsStream()" )]
public static
void
Test_Enumerable_AsStream()
{
    int[] items = new int[] { 1, 2, 3 };
    Print( "Items in stream accurately reflect enumerable" );
    Assert( items.AsStream().AsEnumerable().SequenceEqual( items ) );
}


[Test( "Stream.Append()" )]
public static
void
Test_Stream_Append()
{
    Assert(
        new Stream< int >( 1, 2, 3 )
        .Append( 4 )
        .AsEnumerable()
        .SequenceEqual( new int[] { 1, 2, 3, 4 } ) );
}


[Test( "Stream.Concat()" )]
public static
void
Test_Stream_Concat()
{
    Assert(
        new Stream< int >( 1, 2, 3 )
        .Concat( new Stream< int >( 4, 5, 6 ) )
        .AsEnumerable()
        .SequenceEqual( new int[] { 1, 2, 3, 4, 5, 6 } ) );
}


[Test( "Collection.AsSink()" )]
public static
void
Test_Collection_AsSink()
{
    ICollection< int > col = new List< int >();
    new Stream< int >( 1, 2, 3 ).EmptyTo( col.AsSink() );
    Assert( col.SequenceEqual( new int[] { 1, 2, 3 } ) );
}


[Test( "Stream.Covary()" )]
public static
void
Test_Stream_Covary()
{
    IStream< object > s =
        new int[] { 1, 2, 3 }.AsStream().Covary< int, object >();
    Assert( s.AsEnumerable().SequenceEqual( new object[] { 1, 2, 3 } ) );
}




} // type
} // namespace

