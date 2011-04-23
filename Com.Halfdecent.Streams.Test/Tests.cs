// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010, 2011
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


using SC = System.Collections;
using SCG = System.Collections.Generic;
using System.Linq;
using Com.Halfdecent;
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



private static
void
Assert123(
    IStream< int > s
)
{
    ITuple< bool, int > t;

    t = s.TryPull();
    Assert( t.A );
    Assert( t.B == 1 );

    t = s.TryPull();
    Assert( t.A );
    Assert( t.B == 2 );

    t = s.TryPull();
    Assert( t.A );
    Assert( t.B == 3 );

    t = s.TryPull();
    Assert( !t.A );
}


[Test( "Stream< T >" )]
public static
void
Test_Stream_T()
{
    int i = 1;
    IStream< int > s = new Stream< int >(
        () =>
            i <= 3
                ? Tuple.Create( true, i++ )
                : Tuple.Create( false, -1 ),
        () => {;} );
    Assert123( s );
}


[Test( "Stream.Create( Maybe<T> )" )]
public static
void
Test_Stream_Create_Maybe()
{
    testmaybestate = 1;
    IStream< int > s = Stream.Create< int >( TestMaybe );
    Assert123( s );
}

private static int testmaybestate = 1;

private static
    bool
TestMaybe( out int result )
{
    if( testmaybestate <= 3 ) {
        result = testmaybestate++;
        return true;
    } else {
        result = default( int );
        return false;
    }
}


[Test( "Stream.Create( Func<bool>, Func<T> )" )]
public static
void
Test_Stream_Create_canPullFunc_pullFunc()
{
    int i = 1;
    IStream< int > s = Stream.Create(
        () => i <= 3,
        () => i++ );
    Assert123( s );
}


[Test( "Stream.Create( params T[] )" )]
public static
void
Test_Stream_Create_params()
{
    IStream< int > s = Stream.Create( 1, 2, 3 );
    ITuple< bool, int > t;
    t = s.TryPull();
    Assert( t.A );
    Assert( t.B == 1 );
    t = s.TryPull();
    Assert( t.A );
    Assert( t.B == 2 );
    t = s.TryPull();
    Assert( t.A );
    Assert( t.B == 3 );
    t = s.TryPull();
    Assert( !t.A );
}


[Test( "IStream.Covary()" )]
public static
void
Test_IStream_Covary()
{
    IStream< object > s =
        new int[] { 1, 2, 3 }
        .AsStream()
        .Covary< int, object >();
    Assert(
        s.AsEnumerable()
        .SequenceEqual( new object[] { 1, 2, 3 } ) );
}


#if DOTNET40
[Test( "IStream Covariance" )]
public static
void
Test_IStream_Covariance()
{
    IStream< object > s =
        new string[] { "1", "2", "3" }
        .AsStream();
    Assert(
        s.AsEnumerable()
        .SequenceEqual( new object[] { "1", "2", "3" } ) );
}
#endif


[Test( "IStream.TryPull( out T )" )]
public static
void
Test_IStream_TryPull_out_T()
{
    IStream< int > s = Stream.Create( 1, 2, 3 );
    int i;
    Assert( s.TryPull( out i ) );
    Assert( i == 1 );
    Assert( s.TryPull( out i ) );
    Assert( i == 2 );
    Assert( s.TryPull( out i ) );
    Assert( i == 3 );
    Assert( !s.TryPull( out i ) );
}


[Test( "IStream.Pull()" )]
public static
void
Test_IStream_Pull()
{
    IStream< int > s = Stream.Create( 1, 2, 3 );
    Assert( s.Pull() == 1 );
    Assert( s.Pull() == 2 );
    Assert( s.Pull() == 3 );
    Print( "EmptyException" );
    Expect(
        e => ValueReferenceException.Match<
            EmptyException >(
            e,
            (vr,f) => vr.Equals( f.Down().Parameter( "dis" ) ) ),
        () => s.Pull() );
}


[Test( "IStream.AsEnumerator()" )]
public static
void
Test_IStream_AsEnumerator()
{
    IStream< int > s;
    SC.IEnumerator e;
    SCG.IEnumerator< int > ge;

    s = Stream.Create( 1, 2, 3 );

    Print( "Correct sequence" );
    ge = s.AsEnumerator();
    Assert( ge.MoveNext() );
    Assert( ge.Current == 1 );
    Assert( ge.MoveNext() );
    Assert( ge.Current == 2 );

    Print( "Subsequent .AsEnumerator() continues from the same point" );
    ge = s.AsEnumerator();
    Assert( ge.MoveNext() );
    Assert( ge.Current == 3 );

    Print( "Ends when the underlying stream ends" );
    Assert( !ge.MoveNext() );

    Print( "Non-generic IEnumerator interface" );
    s = Stream.Create( 1, 2, 3 );
    e = s.AsEnumerator();
    Assert( e.MoveNext() );
    Assert( e.Current.Equals( 1 ) );
    Assert( e.MoveNext() );
    Assert( e.Current.Equals( 2 ) );
    Assert( e.MoveNext() );
    Assert( e.Current.Equals( 3 ) );
    Assert( !e.MoveNext() );
}


[Test( "IStream.AsEnumerable()" )]
public static
void
Test_IStream_AsEnumerable()
{
    IStream< int > s;
    SC.IEnumerable e;
    SCG.IEnumerable< int > ge;

    Print( "Single .AsEnumerable()" );
    s = Stream.Create( 1, 2, 3 );
    Assert(
        s
        .AsEnumerable()
        .SequenceEqual(
            new int[] { 1, 2, 3 } ) );

    Print( "Single .AsEnumerable(), multiple .GetEnumerator()" );
    s = Stream.Create( 1, 2, 3 );
    ge = s.AsEnumerable();
    Assert(
        ge
        .Take( 2 )
        .SequenceEqual(
            new int[] { 1, 2 } ) );
    Assert(
        ge
        .SequenceEqual(
            new int[] { 3 } ) );

    Print( "Multiple .AsEnumerable()" );
    s = Stream.Create( 1, 2, 3 );
    Assert(
        s.AsEnumerable()
        .Take( 2 )
        .SequenceEqual(
            new int[] { 1, 2 } ) );
    Assert(
        s.AsEnumerable()
        .SequenceEqual(
            new int[] { 3 } ) );

    Print( "Non-generic IEnumerable interface" );
    s = Stream.Create( 1, 2, 3 );
    e = s.AsEnumerable();
    Assert(
        e
        .OfType< int >()
        .SequenceEqual(
            new int[] { 1, 2, 3 } ) );
}


[Test( "IEnumerator<T>.AsStream()" )]
public static
void
Test_IEnumerator_AsStream()
{
    Assert(
        new int[] { 1, 2, 3 }
        //
        // XXX Not sure why this is required, but it is, otherwise the result of
        // the subsequent .GetEnumerator() seems to be an enumerable (!)
        .AsEnumerable()
        //
        .GetEnumerator()
        .AsStream()
        .AsEnumerable()
        .SequenceEqual(
            new int[] { 1, 2, 3 } ) );
}


[Test( "IEnumerable<T>.AsStream()" )]
public static
void
Test_IEnumerable_AsStream()
{
    Assert(
        new int[] { 1, 2, 3 }
        .AsStream()
        .AsEnumerable()
        .SequenceEqual(
            new int[] { 1, 2, 3 } ) );
}


[Test( "Sink<T>" )]
public static
void
Test_Sink()
{
    int i = 0;
    ISink< object > s = new Sink< object >(
        item => i++ < 3
            ? true
            : false,
        () => {;} );
    Assert( s.TryPush( 1 ) );
    Assert( s.TryPush( 2 ) );
    Assert( s.TryPush( 3 ) );
    Assert( !s.TryPush( 4 ) );
}


[Test( "Sink.Create( canPushFunc, pushFunc )" )]
public static
void
Test_Sink_Create_canPushFunc_pushFunc()
{
    int i = 0;
    ISink< int > s = Sink.Create< int >(
        () => i < 3,
        item => i++ );
    Assert( s.TryPush( 1 ) );
    Assert( s.TryPush( 2 ) );
    Assert( s.TryPush( 3 ) );
    Assert( !s.TryPush( 4 ) );
}


[Test( "Sink.Create( pushFunc )" )]
public static
void
Test_Sink_Create_pushFunc()
{
    ISink< int > s = Sink.Create< int >(
        item => { ; } );
    Assert( s.TryPush( 1 ) );
    Assert( s.TryPush( 2 ) );
    Assert( s.TryPush( 3 ) );
}


[Test( "ISink.Push()" )]
public static
void
Test_ISink_Push()
{
    int i = 0;
    ISink< int > s = Sink.Create< int >(
        () => i < 3,
        item => i++ );

    s.Push( 1 );
    s.Push( 2 );
    s.Push( 3 );
    Expect(
        e => ValueReferenceException.Match<
            FullException >(
            e,
            (vr,f) => vr.Equals( f.Down().Parameter( "sink" ) ) ),
        () => s.Push( 4 ) );
}


[Test( "ISink.Contravary()" )]
public static
void
Test_ISink_Contravary()
{
    ISink< string > s =
        Sink.Create< object >( item => { ; } )
        .Contravary< object, string >();
    Assert( s.TryPush( "1" ) );
}


#if DOTNET40
[Test( "ISink Contravariance" )]
public static
void
Test_ISink_Contravariance()
{
    ISink< string > s =
        Sink.Create< object >( item => { ; } );
    Assert( s.TryPush( "1" ) );
}
#endif


[Test( "IStream.EmptyTo()" )]
public static
void
Test_IStream_EmptyTo()
{
    SCG.IEnumerable< int > from = new int[] { 1, 2, 3 };
    SCG.ICollection< int > to = new SCG.List< int >();
    from.AsStream().EmptyTo(
        Sink.Create< int >(
            item => to.Add( item ) ) );
    Assert( to.SequenceEqual( from ) );
}


[Test( "Stream.Append()" )]
public static
void
Test_Stream_Append()
{
    Assert(
        Stream.Create( 1, 2, 3 )
        .Append( 4 )
        .AsEnumerable()
        .SequenceEqual(
            new int[] { 1, 2, 3, 4 } ) );
}


[Test( "Stream.Concat()" )]
public static
void
Test_Stream_Concat()
{
    Assert(
        Stream.Create( 1, 2, 3 )
        .Concat( Stream.Create( 4, 5, 6 ) )
        .AsEnumerable()
        .SequenceEqual(
            new int[] { 1, 2, 3, 4, 5, 6 } ) );
}


[Test( "System.Collection.ICollection<T>.AsSink()" )]
public static
void
Test_SystemCollection_AsSink()
{
    SCG.IEnumerable< int > from = new int[] { 1, 2, 3 };
    SCG.ICollection< int > to = new SCG.List< int >();
    from.AsStream().EmptyTo(
        to.AsSink() );
    Assert( to.SequenceEqual( from ) );
}


[Test( "IStream.SequenceEqual( IStream )" )]
public static
void
Test_IStream_SequenceEqual_IStream()
{
    Assert(
        "abc".AsStream().SequenceEqual(
            "abc".AsStream() ) );
    Assert(
        "".AsStream().SequenceEqual(
            "".AsStream() ) );
    Assert( !
        "abc".AsStream().SequenceEqual(
            "def".AsStream() ) );
    Assert( !
        "abc".AsStream().SequenceEqual(
            "abcd".AsStream() ) );
    Assert( !
        "abcd".AsStream().SequenceEqual(
            "abc".AsStream() ) );
}


// TODO Print( ".SequenceEqual<T,TEquatable>( that )" );


[Test( "IStream.SequenceEqual( IStream, IEqualityComparer )" )]
public static
void
Test_IStream_SequenceEqual_IStream_IEqualityComparer()
{
    SCG.IEqualityComparer< char > comparer =
        new EqualityComparer< char >(
            (c1,c2) =>
                char.ToLowerInvariant( c1 ) == char.ToLowerInvariant( c2 ),
            c => char.ToLowerInvariant( c ).GetHashCode() );

    Assert(
        "abc".AsStream().SequenceEqual(
            "ABC".AsStream(),
            comparer ) );
    Assert(
        "".AsStream().SequenceEqual(
            "".AsStream(),
            comparer ) );
    Assert( !
        "abc".AsStream().SequenceEqual(
            "def".AsStream(),
            comparer ) );
    Assert( !
        "abc".AsStream().SequenceEqual(
            "abcd".AsStream(),
            comparer ) );
    Assert( !
        "abcd".AsStream().SequenceEqual(
            "abc".AsStream(),
            comparer) );
}


[Test( "SystemStream.AsHalfdecentStream()" )]
public static
void
Test_SystemStream_AsHalfdecentStream()
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


[Test( "SystemStream.AsHalfdecentSink()" )]
public static
void
Test_SystemStream_AsHalfdecentSink()
{
    System.IO.MemoryStream ms = new System.IO.MemoryStream();
    ISink< byte > s = ms.AsHalfdecentSink();
    s.Push( (byte)0 );
    s.Push( (byte)1 );
    s.Push( (byte)2 );
    s.Push( (byte)3 );
    Assert( ms.ToArray().SequenceEqual( new byte[] { 0, 1, 2, 3 } ) );
}


[Test( "Filter<TIn,TOut>" )]
public static
void
Test_Filter()
{
    int count = 0;
    IFilter< int, int > f
        = new Filter< int, int >(
            null,
            (GetState,Get,Put) => {
                if( GetState() == null ) {
                    return FilterState.Want;
                } else if( GetState() == FilterState.Want ) {
                    Put( Get() );
                    count++;
                    return FilterState.Have;
                } else if( GetState() == FilterState.Have ) {
                    if( count >= 3 ) return FilterState.Closed;
                    return FilterState.Want;
                } else { // FilterState.Closed
                    return FilterState.Closed;
                } },
            () => {;} );

    Assert( f.State == FilterState.Want );
    f.Give( 1 );
    Assert( f.State == FilterState.Have );
    Assert( f.Take() == 1 );

    Assert( f.State == FilterState.Want );
    f.Give( 2 );
    Assert( f.State == FilterState.Have );
    Assert( f.Take() == 2 );

    Assert( f.State == FilterState.Want );
    f.Give( 3 );
    Assert( f.State == FilterState.Have );
    Assert( f.Take() == 3 );

    Assert( f.State == FilterState.Closed );
}


[Test( "Filter<TIn,TOut> immediately Closed" )]
public static
void
Test_Filter_closed()
{
    IFilter< int, int > f
        = new Filter< int, int >(
            null,
            (GetState,Get,Put) => FilterState.Closed,
            () => {;} );

    Assert( f.State == FilterState.Closed );
}


[Test( "Filter.Create( convertFunc )" )]
public static
void
Test_Filter_convertFunc()
{
    IFilter< int, int > f
        = Filter.Create< int, int >(
            i => i * 2 );

    Assert( f.State == FilterState.Want );
    f.Give( 1 );
    Assert( f.State == FilterState.Have );
    Assert( f.Take() == 2 );

    Assert( f.State == FilterState.Want );
    f.Give( 2 );
    Assert( f.State == FilterState.Have );
    Assert( f.Take() == 4 );

    Assert( f.State == FilterState.Want );
    f.Give( 3 );
    Assert( f.State == FilterState.Have );
    Assert( f.Take() == 6 );
}


[Test( "Filter.Create( filterStepIterator ) one-to-many" )]
public static
void
Test_Filter_filterStepIterator_onetomany()
{
    IFilter< int, int > f
        = Filter.Create< int, int >(
            DoubleUp3FilterIterator );

    Assert( f.State == FilterState.Want );
    f.Give( 1 );
    Assert( f.State == FilterState.Have );
    Assert( f.Take() == 1 );
    Assert( f.State == FilterState.Have );
    Assert( f.Take() == 1 );

    Assert( f.State == FilterState.Want );
    f.Give( 2 );
    Assert( f.State == FilterState.Have );
    Assert( f.Take() == 2 );
    Assert( f.State == FilterState.Have );
    Assert( f.Take() == 2 );

    Assert( f.State == FilterState.Want );
    f.Give( 3 );
    Assert( f.State == FilterState.Have );
    Assert( f.Take() == 3 );
    Assert( f.State == FilterState.Have );
    Assert( f.Take() == 3 );

    Assert( f.State == FilterState.Closed );
}

private static
SCG.IEnumerator< bool >
DoubleUp3FilterIterator(
    System.Func< FilterState > GetState,
    System.Func< int > Get,
    System.Action< int > Put
)
{
    int count = 0;
    while( count < 3 ) {
        yield return false;
        int i = Get();
        Put( i );
        yield return true;
        Put( i );
        yield return true;
        count++;
    }
}


[Test( "Filter.Create( filterStepIterator ) many-to-one" )]
public static
void
Test_Filter_filterStepIterator_manytomany()
{
    IFilter< int, int > f
        = Filter.Create< int, int >(
            Add3PairsFilterIterator );

    Assert( f.State == FilterState.Want );
    f.Give( 1 );
    Assert( f.State == FilterState.Want );
    f.Give( 2 );
    Assert( f.State == FilterState.Have );
    Assert( f.Take() == 3 );

    Assert( f.State == FilterState.Want );
    f.Give( 4 );
    Assert( f.State == FilterState.Want );
    f.Give( 5 );
    Assert( f.State == FilterState.Have );
    Assert( f.Take() == 9 );

    Assert( f.State == FilterState.Want );
    f.Give( 10 );
    Assert( f.State == FilterState.Want );
    f.Give( 11 );
    Assert( f.State == FilterState.Have );
    Assert( f.Take() == 21 );

    Assert( f.State == FilterState.Closed );
}

private static
SCG.IEnumerator< bool >
Add3PairsFilterIterator(
    System.Func< FilterState > GetState,
    System.Func< int > Get,
    System.Action< int > Put
)
{
    int count = 0;
    while( count < 3 ) {
        yield return false;
        int i = Get();
        yield return false;
        int j = Get();
        Put( i+j );
        yield return true;
        count++;
    }
}


[Test( "IStream.To()" )]
public static
void
Test_IStream_To()
{
    Print( "Fewer items than the filter allows" );
    Assert(
        Stream.Create( 1, 2 )
        .To( Filter.Create< int, int >( DoubleUp3FilterIterator ) )
        .SequenceEqual(
            Stream.Create( 1, 1, 2, 2 ) ) );
    Print( "More items than the filter allows" );
    Assert(
        Stream.Create( 1, 2, 3, 4 )
        .To( Filter.Create< int, int >( DoubleUp3FilterIterator ) )
        .SequenceEqual(
            Stream.Create( 1, 1, 2, 2, 3, 3 ) ) );
}


[Test( "IFilter.To( filter )" )]
public static
void
Test_IFilter_To_filter()
{
    IFilter< int, int > f1
        = Filter.Create< int, int >( DoubleUp3FilterIterator );
    IFilter< int, int > f2
        = Filter.Create< int, int >( Add3PairsFilterIterator );
    IFilter< int, int > f3 = f1.To( f2 );
    Assert(
        Stream.Create( 1, 2, 3, 999, 999 )
        .To( f3 )
        .SequenceEqual(
            Stream.Create( 2, 4, 6 ) ) );
}


[Test( "IFilter.To( sink )" )]
public static
void
Test_IFilter_To_sink()
{
    IStream< int > stream = Stream.Create( 1, 2, 3, 999, 999 );
    IFilter< int, int > f;
    ISink< int > sink;
    SCG.ICollection< int > c = new SCG.List< int >();

    Print( "Basic behaviour" );
    c.Clear();
    f = Filter.Create< int, int >( DoubleUp3FilterIterator );
    sink = f.To( c.AsSink() );
    while( sink.TryPush( stream.Pull() ) );
    Assert(
        c.SequenceEqual(
            new int[] { 1, 1, 2, 2, 3, 3 } ) );

    Print( "Immediate empty to sink on connect" );
    c.Clear();
    f = Filter.Create< int, int >( DoubleUp3FilterIterator );
    f.Give( 1 );
    sink = f.To( c.AsSink() );
    Assert(
        c.SequenceEqual(
            new int[] { 1, 1 } ) );
}


[Test( "TextLineSplitter" )]
public static
void
Test_TextLineSplitter()
{
    Assert(
        "\nline1\nline2\rline3\r\nline4\r\rline6\n\nline8\n"
            .AsStream()
            .To( new TextLineSplitter() )
            .SequenceEqual(
                Stream.Create(
                    "", "line1", "line2", "line3", "line4", "", "line6", "",
                    "line8" ) ) );
}


[Test( "TextDecoder" )]
public static
void
Test_TextDecoder()
{
    char[] src = { '\u65E5', '\u672C', '\u8A9E' };
    System.Text.Encoding e;

    Print( "UTF8" );
    e = Encodings.UTF8;
    Assert(
        e.GetBytes( src )
            .AsStream()
            .To( new TextDecoder( e ) )
            .AsEnumerable()
            .SequenceEqual( src ) );

    Print( "UTF16LE" );
    e = Encodings.UTF16LE;
    Assert(
        e.GetBytes( src )
            .AsStream()
            .To( new TextDecoder( e ) )
            .AsEnumerable()
            .SequenceEqual( src ) );

    Print( "UTF16BE" );
    e = Encodings.UTF16BE;
    Assert(
        e.GetBytes( src )
            .AsStream()
            .To( new TextDecoder( e ) )
            .AsEnumerable()
            .SequenceEqual( src ) );

    #if !MONO
    // Fails on Mono with char count: 0, may be Mono UTF32Encoding bug
    // TODO Does this pass on MS?
    Print( "UTF32" );
    e = Encodings.UTF32;
    Assert(
        e.GetBytes( src )
            .AsStream()
            .To( new TextDecoder( e ) )
            .AsEnumerable()
            .SequenceEqual( src ) );
    #endif
}



[Test( "TextEncoder" )]
public static
void
Test_TextEncoder()
{
    char[] src = { '\u65E5', '\u672C', '\u8A9E' };
    System.Text.Encoding e;

    Print( "UTF8" );
    e = Encodings.UTF8;
    Assert(
        src.AsStream().To( new TextEncoder( e ) ).AsEnumerable()
            .SequenceEqual( e.GetBytes( src ) ) );

    Print( "UTF16LE" );
    e = Encodings.UTF16LE;
    Assert(
        src.AsStream().To( new TextEncoder( e ) ).AsEnumerable()
            .SequenceEqual( e.GetBytes( src ) ) );

    Print( "UTF16BE" );
    e = Encodings.UTF16BE;
    Assert(
        src.AsStream().To( new TextEncoder( e ) ).AsEnumerable()
            .SequenceEqual( e.GetBytes( src ) ) );

    Print( "UTF32LE" );
    e = Encodings.UTF32LE;
    Assert(
        src.AsStream().To( new TextEncoder( e ) ).AsEnumerable()
            .SequenceEqual( e.GetBytes( src ) ) );

    Print( "UTF32BE" );
    e = Encodings.UTF32BE;
    Assert(
        src.AsStream().To( new TextEncoder( e ) ).AsEnumerable()
            .SequenceEqual( e.GetBytes( src ) ) );
}




} // type
} // namespace

