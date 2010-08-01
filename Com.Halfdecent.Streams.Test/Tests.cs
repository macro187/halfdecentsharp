// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010
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
using Com.Halfdecent.Text;
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



// A test IStream<T> implementation that yields 3 ints
private class
TestStream
    : IStream< int >
    , IDisposable
{
    public
    TestStream()
    {
        this.Disposed = false;
    }

    public
        ITuple< bool, int >
    TryPull()
    {
        if( this.current > 3 ) return new Tuple< bool, int >( false, 0 );
        return new Tuple< bool, int >( true, this.current++ );
    }

    private
    int
    current = 1;

    public
        void
    Dispose()
    {
        this.Disposed = true;
        GC.SuppressFinalize( this );
    }

    ~TestStream()
    {
        this.Dispose();
    }

    public bool Disposed { get; private set; }
}



// A test ISink<T> implementation that holds 3 ints
private class
TestSink
    : ISink< int >
    , IDisposable
{
    public
    TestSink()
    {
        this.Disposed = false;
    }

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

    public
        void
    Dispose()
    {
        this.Disposed = true;
        GC.SuppressFinalize( this );
    }

    ~TestSink()
    {
        this.Dispose();
    }

    public bool Disposed { get; private set; }
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


[Test( "Sink.Contravary()" )]
public static
void
Test_Sink_Contravary()
{
    IList< object > objs = new List< object >();
    ISink< string > s = objs.AsSink().Contravary< object, string >();
    s.Push( "1" );
    s.Push( "2" );
    s.Push( "3" );
    Assert( objs.SequenceEqual( new object[] { "1", "2", "3" } ) );
}


#if DOTNET40
[Test( "Sink.Contravariance" )]
public static
void
Test_Sink_Contravariance()
{
    IList< object > objs = new List< object >();
    ISink< string > s = objs.AsSink();
    s.Push( "1" );
    s.Push( "2" );
    s.Push( "3" );
    Assert( objs.SequenceEqual( new object[] { "1", "2", "3" } ) );
}
#endif


[Test( "Stream.Covary()" )]
public static
void
Test_Stream_Covary()
{
    IStream< object > s =
        new int[] { 1, 2, 3 }.AsStream().Covary< int, object >();
    Assert( s.AsEnumerable().SequenceEqual( new object[] { 1, 2, 3 } ) );
}


// TODO Enable once Mono's runtime can handle this
#if DOTNET40 && !MONO
[Test( "Stream Covariance" )]
public static
void
Test_Stream_Covariance()
{
    IStream< object > s =
        new string[] { "1", "2", "3" }.AsStream();
    Assert( s.AsEnumerable().SequenceEqual( new string[] { "1", "2", "3" } ) );
}
#endif


[Test( "System.IO.Stream::AsHalfdecentStream()" )]
public static
void
Test_System_IO_Stream__AsHalfdecentStream()
{
    IStream< byte > s =
        new System.IO.MemoryStream(
            new byte[] { 0, 1, 2, 3 } )
        .AsHalfdecentStream();
    Assert( s.Pull() == 0 );
    Assert( s.Pull() == 1 );
    Assert( s.Pull() == 2 );
    Assert( s.Pull() == 3 );
    byte b;
    Assert( !s.TryPull( out b ) );
}


[Test( "System.IO.Stream::AsHalfdecentSink()" )]
public static
void
Test_System_IO_Stream__AsHalfdecentSink()
{
    System.IO.MemoryStream ms = new System.IO.MemoryStream();
    ISink< byte > s = ms.AsHalfdecentSink();
    s.Push( (byte)0 );
    s.Push( (byte)1 );
    s.Push( (byte)2 );
    s.Push( (byte)3 );
    Assert( ms.ToArray().SequenceEqual( new byte[] { 0, 1, 2, 3 } ) );
}



public class
PassOne
    : FilterBase< int, int >
{
    protected override
    IEnumerator< bool >
    Process()
    {
        yield return false;
        this.PutItem( this.GetItem() );
        yield return true;
    }
}



public class
PassThrough
    : FilterBase< int, int >
    , IDisposable
{
    public
    PassThrough()
    {
        this.Disposed = false;
    }

    protected override
    IEnumerator< bool >
    Process()
    {
        for( ;; ) {
            yield return false;
            this.PutItem( this.GetItem() );
            yield return true;
        }
    }

    public
        void
    Dispose()
    {
        this.Disposed = true;
        GC.SuppressFinalize( this );
    }

    ~PassThrough()
    {
        this.Dispose();
    }

    public bool Disposed { get; private set; }
}



public class
DoubleUp
    : FilterBase< int, int >
{
    protected override
    IEnumerator< bool >
    Process()
    {
        for( ;; ) {
            int i;
            yield return false; i = this.GetItem();
            this.PutItem( i ); yield return true;
            this.PutItem( i ); yield return true;
        }
    }
}



public class
AddPairs
    : FilterBase< int, int >
{
    protected override
    IEnumerator< bool >
    Process()
    {
        for( ;; ) {
            int i,j;
            yield return false; i = this.GetItem();
            yield return false; j = this.GetItem();
            this.PutItem( i + j ); yield return true;
        }
    }
}


[Test( "FilterBase::Push()" )]
public static
void
Test_FilterBase_Push()
{
    int[]               from = new int[] { 1, 2, 3, 4 };
    IFilter< int, int > f;
    List< int >     to = new List< int >();
    List< int >     too = new List< int >();

    Print( "1-to-1 filter" );
    to.Clear();
    f = new PassThrough { To = to.AsSink() };
    foreach( int i in from ) f.Push( i );
    Assert( to.SequenceEqual( from ) );

    Print( "1-to-many filter" );
    to.Clear();
    f = new DoubleUp { To = to.AsSink() };
    foreach( int i in from ) f.Push( i );
    Assert( to.SequenceEqual( new int[] { 1,1, 2,2, 3,3, 4,4 } ) );

    Print( "Many-to-1 filter" );
    to.Clear();
    f = new AddPairs { To = to.AsSink() };
    foreach( int i in from ) f.Push( i );
    Assert( to.SequenceEqual( new int[] { 3, 7 } ) );

    Print( "Closing filter" );
    to.Clear();
    f = new PassOne { To = to.AsSink() };
    f.Push( 1 );
    Assert( !f.TryPush( 2 ) );
    Assert( to.SequenceEqual( new int[] { 1 } ) );

    Print( "1-to-many filter, switch .To mid-block" );
    to.Clear();
    too.Clear();
    f = new DoubleUp { To =
        new PassOne { To =
        to.AsSink() } };
    f.Push( 1 );
    Assert( to.SequenceEqual( new int[] { 1 } ) );
    f.To = too.AsSink();
    // (filter immediately flushes pending item to new sink)
    Assert( too.SequenceEqual( new int[] { 1 } ) );
}



[Test( "FilterBase::Pull()" )]
public static
void
Test_FilterBase_Pull()
{
    IFilter< int, int > f;
    List< int > to = new List< int >();

    Print( "1-to-1 filter" );
    f = new PassThrough { From = new Stream< int >( 1, 2, 3, 4 ) };
    to.Clear();
    f.EmptyTo( to.AsSink() );
    Assert( to.SequenceEqual( new int[] { 1, 2, 3, 4 } ) );

    Print( "1-to-many filter" );
    f = new DoubleUp { From = new Stream< int >( 1, 2, 3, 4 ) };
    to.Clear();
    f.EmptyTo( to.AsSink() );
    Assert( to.SequenceEqual( new int[] { 1,1, 2,2, 3,3, 4,4 } ) );

    Print( "Many-to-1 filter" );
    f = new AddPairs { From = new Stream< int >( 1, 2, 3, 4 ) };
    to.Clear();
    f.EmptyTo( to.AsSink() );
    Assert( to.SequenceEqual( new int[] { 3, 7 } ) );

    Print( "Closing filter" );
    f = new PassOne { From = new Stream< int >( 1, 2, 3, 4 ) };
    to.Clear();
    f.EmptyTo( to.AsSink() );
    Assert( to.SequenceEqual( new int[] { 1 } ) );

    Print( "Many-to-1 filter, switch .From mid-block" );
    f = new AddPairs { From = new Stream< int >( 1 ) };
    to.Clear();
    f.EmptyTo( to.AsSink() );
    Assert( to.Count == 0 );
    f.From = new Stream< int >( 2 );
    f.EmptyTo( to.AsSink() );
    Assert( to.SequenceEqual( new int[] { 3 } ) );
}


[Test( "IStream::PipeTo( IFilter )" )]
public static
void
Test_IStream_PipeTo_IFilter()
{
    List< int > to = new List< int >();

    Print( "Works as a stream" );
    to.Clear();
    new Stream< int >( 1, 2, 3, 4 )
        .PipeTo( new PassThrough() )
        .EmptyTo( to.AsSink() );
    Assert( to.SequenceEqual( new int[] { 1, 2, 3, 4 } ) );

    TestStream      s;
    PassThrough     f;
    PassThrough     f2;

    Print( "Connection and Disconnection" );
    s = new TestStream();
    f = new PassThrough();
    f2 = new PassThrough();
    Assert( f.From == null );
    Assert( f2.From == null );
    using( (IDisposable)( s.PipeTo( f ).PipeTo( f2 ) ) ) {
        Assert( f.From != null );
        Assert( f2.From != null );
    }
    Assert( f.From == null );
    Assert( f2.From == null );

    Print( "Disposal (both)" );
    s = new TestStream();
    f = new PassThrough();
    Assert( !s.Disposed );
    Assert( !f.Disposed );
    using( (IDisposable)( s.PipeTo( f ) ) ) {
        Assert( !s.Disposed );
        Assert( !f.Disposed );
    }
    Assert( s.Disposed );
    Assert( f.Disposed );

    Print( "Disposal (stream only)" );
    s = new TestStream();
    f = new PassThrough();
    Assert( !s.Disposed );
    Assert( !f.Disposed );
    using( (IDisposable)( s.PipeTo( f, true, false ) ) ) {
        Assert( !s.Disposed );
        Assert( !f.Disposed );
    }
    Assert( s.Disposed );
    Assert( !f.Disposed );

    Print( "Disposal (filter only)" );
    s = new TestStream();
    f = new PassThrough();
    Assert( !s.Disposed );
    Assert( !f.Disposed );
    using( (IDisposable)( s.PipeTo( f, false, true ) ) ) {
        Assert( !s.Disposed );
        Assert( !f.Disposed );
    }
    Assert( !s.Disposed );
    Assert( f.Disposed );

    Print( "Disposal (neither)" );
    s = new TestStream();
    f = new PassThrough();
    Assert( !s.Disposed );
    Assert( !f.Disposed );
    using( (IDisposable)( s.PipeTo( f, false, false ) ) ) {
        Assert( !s.Disposed );
        Assert( !f.Disposed );
    }
    Assert( !s.Disposed );
    Assert( !f.Disposed );

    Print( "Disposal (chained)" );
    s = new TestStream();
    f = new PassThrough();
    f2 = new PassThrough();
    Assert( !s.Disposed );
    Assert( !f.Disposed );
    Assert( !f2.Disposed );
    using( (IDisposable)( s.PipeTo( f ).PipeTo( f2 ) ) ) {
        Assert( !s.Disposed );
        Assert( !f.Disposed );
        Assert( !f2.Disposed );
    }
        Assert( s.Disposed );
        Assert( f.Disposed );
        Assert( f2.Disposed );
}


public static
    IEnumerator< bool >
OnlyEvens(
    Func< int >     get,
    Action< int >   put,
    Action< int >   drop
)
{
    for( ;; ) {
        yield return false;
        int i = get();
        if( i % 2 != 0 ) continue;
        put( i );
        yield return true;
    }
}


[Test( "Filter< TIn, TOut >" )]
public static
void
Test_Filter_TIn_TOut()
{
    IFilter< int, int > f;
    IList< int > results = new List< int >();

    Print( "Filter( FilterKernel )" );
    f = new Filter< int, int >( OnlyEvens );
    f.From = new int[] { 1, 2, 3, 4, 5, 6 }.AsStream();
    f.EmptyTo( results.AsSink() );
    Assert( results.SequenceEqual( new int[] { 2, 4, 6 } ) );

    Print( "Filter( Func )" );
    f = new Filter< int, int >( i => i * 2 );
    results.Clear();
    f.From = new int[] { 1, 2, 3, 4 }.AsStream();
    f.EmptyTo( results.AsSink() );
    Assert( results.SequenceEqual( new int[] { 2, 4, 6, 8 } ) );
}


[Test( "IFilter::PipeTo( IFilter )" )]
public static
void
Test_IFilter_PipeTo_IFilter()
{
    IFilter< int, int > f;
    IList< int > to = new List< int >();

    Print( "Works as a filter" );
    f = new DoubleUp()
        .PipeTo( new AddPairs() )
        .PipeTo( new PassThrough() );
    f.From = new int[] { 1, 2 }.AsStream();
    f.EmptyTo( to.AsSink() );
    Assert( to.SequenceEqual( new int[] { 2, 4 } ) );
    f.From = null;

    PassThrough f1;
    PassThrough f2;
    PassThrough f3;

    Print( "Connection and Disconnection" );
    f1 = new PassThrough();
    f2 = new PassThrough();
    f3 = new PassThrough();
    Assert( f1.From == null );
    Assert( f1.To == null );
    Assert( f2.From == null );
    Assert( f2.To == null );
    Assert( f3.From == null );
    Assert( f3.To == null );
    using( (IDisposable)( f1.PipeTo( f2 ).PipeTo( f3 ) ) ) {
        Assert( f1.From == null );
        Assert( f1.To != null );
        Assert( f2.From != null );
        Assert( f2.To != null );
        Assert( f3.From != null );
        Assert( f3.To == null );
    }
    Assert( f1.From == null );
    Assert( f1.To == null );
    Assert( f2.From == null );
    Assert( f2.To == null );
    Assert( f3.From == null );
    Assert( f3.To == null );

    Print( "Disposal (both)" );
    f1 = new PassThrough();
    f2 = new PassThrough();
    Assert( !f1.Disposed );
    Assert( !f2.Disposed );
    using( (IDisposable)( f1.PipeTo( f2 ) ) ) {
        Assert( !f1.Disposed );
        Assert( !f2.Disposed );
    }
    Assert( f1.Disposed );
    Assert( f2.Disposed );

    Print( "Disposal (f1 only)" );
    f1 = new PassThrough();
    f2 = new PassThrough();
    Assert( !f1.Disposed );
    Assert( !f2.Disposed );
    using( (IDisposable)( f1.PipeTo( f2, true, false ) ) ) {
        Assert( !f1.Disposed );
        Assert( !f2.Disposed );
    }
    Assert( f1.Disposed );
    Assert( !f2.Disposed );

    Print( "Disposal (f2 only)" );
    f1 = new PassThrough();
    f2 = new PassThrough();
    Assert( !f1.Disposed );
    Assert( !f2.Disposed );
    using( (IDisposable)( f1.PipeTo( f2, false, true ) ) ) {
        Assert( !f1.Disposed );
        Assert( !f2.Disposed );
    }
    Assert( !f1.Disposed );
    Assert( f2.Disposed );

    Print( "Disposal (neither)" );
    f1 = new PassThrough();
    f2 = new PassThrough();
    Assert( !f1.Disposed );
    Assert( !f2.Disposed );
    using( (IDisposable)( f1.PipeTo( f2, false, false ) ) ) {
        Assert( !f1.Disposed );
        Assert( !f2.Disposed );
    }
    Assert( !f1.Disposed );
    Assert( !f2.Disposed );

    Print( "Disposal (chained)" );
    f1 = new PassThrough();
    f2 = new PassThrough();
    f3 = new PassThrough();
    Assert( !f1.Disposed );
    Assert( !f2.Disposed );
    Assert( !f3.Disposed );
    using( (IDisposable)( f1.PipeTo( f2 ).PipeTo( f3 ) ) ) {
        Assert( !f1.Disposed );
        Assert( !f2.Disposed );
        Assert( !f3.Disposed );
    }
    Assert( f1.Disposed );
    Assert( f2.Disposed );
    Assert( f3.Disposed );
}


[Test( "IFilter::PipeTo( ISink )" )]
public static
void
Test_IFilter_PipeTo_ISink()
{
    Print( "Works as a sink" );
    List< int > to = new List< int >();
    ISink< int > sink = new DoubleUp().PipeTo( to.AsSink() );
    new int[] { 1, 2 }.AsStream().EmptyTo( sink );
    Assert( to.SequenceEqual( new int[] { 1, 1, 2, 2 } ) );

    PassThrough f;

    Print( "Connection and Disconnection" );
    f = new PassThrough();
    Assert( f.From == null );
    Assert( f.To == null );
    using( (IDisposable)( f.PipeTo( new TestSink() ) ) ) {
        Assert( f.From == null );
        Assert( f.To != null );
    }
    Assert( f.From == null );
    Assert( f.To == null );

    TestSink s;

    Print( "Disposal (both)" );
    f = new PassThrough();
    s = new TestSink();
    Assert( !f.Disposed );
    Assert( !s.Disposed );
    using( (IDisposable)( f.PipeTo( s ) ) ) {
        Assert( !f.Disposed );
        Assert( !s.Disposed );
    }
    Assert( f.Disposed );
    Assert( s.Disposed );

    Print( "Disposal (filter only)" );
    f = new PassThrough();
    s = new TestSink();
    Assert( !f.Disposed );
    Assert( !s.Disposed );
    using( (IDisposable)( f.PipeTo( s, true, false ) ) ) {
        Assert( !f.Disposed );
        Assert( !s.Disposed );
    }
    Assert( f.Disposed );
    Assert( !s.Disposed );

    Print( "Disposal (sink only)" );
    f = new PassThrough();
    s = new TestSink();
    Assert( !f.Disposed );
    Assert( !s.Disposed );
    using( (IDisposable)( f.PipeTo( s, false, true ) ) ) {
        Assert( !f.Disposed );
        Assert( !s.Disposed );
    }
    Assert( !f.Disposed );
    Assert( s.Disposed );

    Print( "Disposal (neither)" );
    f = new PassThrough();
    s = new TestSink();
    Assert( !f.Disposed );
    Assert( !s.Disposed );
    using( (IDisposable)( f.PipeTo( s, false, false ) ) ) {
        Assert( !f.Disposed );
        Assert( !s.Disposed );
    }
    Assert( !f.Disposed );
    Assert( !s.Disposed );
}



[Test( "TextDecoder" )]
public static
void
Test_TextDecoder()
{
    char[] src = { '\u65E5', '\u672C', '\u8A9E' };
    System.Text.Encoding e;
    byte[] b;
    List< char > dest = new List< char >();

    Print( "UTF8" );
    e = Encodings.UTF8;
    b = e.GetBytes( src );
    Print( "byte count: {0}", b.Length.ToString() );
    dest.Clear();
    b.AsStream().PipeTo( new TextDecoder( e ) ).EmptyTo( dest.AsSink() );
    Print( "char count: {0}", dest.Count.ToString() );
    Assert( dest.SequenceEqual( src ) );

    Print( "UTF16LE" );
    e = Encodings.UTF16LE;
    b = e.GetBytes( src );
    Print( "byte count: {0}", b.Length.ToString() );
    dest.Clear();
    b.AsStream().PipeTo( new TextDecoder( e ) ).EmptyTo( dest.AsSink() );
    Print( "char count: {0}", dest.Count.ToString() );
    Assert( dest.SequenceEqual( src ) );

    Print( "UTF16BE" );
    e = Encodings.UTF16BE;
    b = e.GetBytes( src );
    Print( "byte count: {0}", b.Length.ToString() );
    dest.Clear();
    b.AsStream().PipeTo( new TextDecoder( e ) ).EmptyTo( dest.AsSink() );
    Print( "char count: {0}", dest.Count.ToString() );
    Assert( dest.SequenceEqual( src ) );

    #if !MONO
    // Fails on Mono with char count: 0, may be Mono UTF32Encoding bug
    // TODO Does this pass on MS?
    Print( "UTF32" );
    e = Encodings.UTF32;
    b = e.GetBytes( src );
    Print( "byte count: {0}", b.Length.ToString() );
    dest.Clear();
    foreach( byte bb in b ) Print( bb.ToString() );
    b.AsStream().PipeTo( new TextDecoder( e ) ).EmptyTo( dest.AsSink() );
    Print( "char count: {0}", dest.Count.ToString() );
    Assert( dest.SequenceEqual( src ) );
    #endif
}



[Test( "TextEncoder" )]
public static
void
Test_TextEncoder()
{
    char[] src = { '\u65E5', '\u672C', '\u8A9E' };
    System.Text.Encoding e;
    byte[] b;
    List< byte > dest = new List< byte >();

    Print( "UTF8" );
    e = Encodings.UTF8;
    b = e.GetBytes( src );
    Print( "GetBytes() byte count: {0}", b.Length.ToString() );
    dest.Clear();
    src.AsStream().PipeTo( new TextEncoder( e ) ).EmptyTo( dest.AsSink() );
    Print( "TextEncoder byte count: {0}", dest.Count.ToString() );
    Assert( dest.SequenceEqual( b ) );

    Print( "UTF16LE" );
    e = Encodings.UTF16LE;
    b = e.GetBytes( src );
    Print( "GetBytes() byte count: {0}", b.Length.ToString() );
    dest.Clear();
    src.AsStream().PipeTo( new TextEncoder( e ) ).EmptyTo( dest.AsSink() );
    Print( "TextEncoder byte count: {0}", dest.Count.ToString() );
    Assert( dest.SequenceEqual( b ) );

    Print( "UTF16BE" );
    e = Encodings.UTF16BE;
    b = e.GetBytes( src );
    Print( "GetBytes() byte count: {0}", b.Length.ToString() );
    dest.Clear();
    src.AsStream().PipeTo( new TextEncoder( e ) ).EmptyTo( dest.AsSink() );
    Print( "TextEncoder byte count: {0}", dest.Count.ToString() );
    Assert( dest.SequenceEqual( b ) );

    Print( "UTF32LE" );
    e = Encodings.UTF32LE;
    b = e.GetBytes( src );
    Print( "GetBytes() byte count: {0}", b.Length.ToString() );
    dest.Clear();
    src.AsStream().PipeTo( new TextEncoder( e ) ).EmptyTo( dest.AsSink() );
    Print( "TextEncoder byte count: {0}", dest.Count.ToString() );
    Assert( dest.SequenceEqual( b ) );

    Print( "UTF32BE" );
    e = Encodings.UTF32BE;
    b = e.GetBytes( src );
    Print( "GetBytes() byte count: {0}", b.Length.ToString() );
    dest.Clear();
    src.AsStream().PipeTo( new TextEncoder( e ) ).EmptyTo( dest.AsSink() );
    Print( "TextEncoder byte count: {0}", dest.Count.ToString() );
    Assert( dest.SequenceEqual( b ) );
}



[Test( "TextLineSplitter" )]
public static
void
Test_TextLineSplitter()
{
    "line1\nline2\rline3\r\nline4\r\rline6\n\nline8\n"
        .AsStream()
        .PipeTo( new TextLineSplitter() )
        .AsEnumerable()
        .SequenceEqual( new string[] {
            "line1", "line2", "line3", "line4", "", "line6", "", "line8" } );
}




} // type
} // namespace

