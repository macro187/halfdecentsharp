// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010, 2011, 2012
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
using Com.Halfdecent;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// <tt>IStream< T ></tt> Library
// =============================================================================

public static class
Stream
{



// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// Create a stream that yields a specified sequence of items
///
public static
    IStream< T >
Create<
    T
>(
    params T[] items
)
{
    NonNull.CheckParameter( items, "items" );
    return items.AsStream();
}


/// Create a stream from a pair of functions, one that indicates whether an
/// item can be pulled and another that does the pull
///
public static
    IStream< T >
Create<
    T
>(
    Func< bool >    canPullFunc,
    Func< T >       pullFunc
)
{
    return Create( canPullFunc, pullFunc, () => {;} );
}


public static
    IStream< T >
Create<
    T
>(
    Func< bool >    canPullFunc,
    Func< T >       pullFunc,
    Action          disposeFunc
)
{
    NonNull.CheckParameter( canPullFunc, "canPullFunc" );
    NonNull.CheckParameter( pullFunc, "pullFunc" );
    return Create< T >(
        () =>
            canPullFunc()
                ? Maybe.Create( pullFunc() )
                : Maybe.Create< T >(),
        disposeFunc );
}


/// Create a stream from a <tt>Com.Halfdecent.Maybe<T></tt>
///
public static
    IStream< T >
Create<
    T
>(
    MaybeFunc< T > maybeFunc
)
{
    return Create( maybeFunc, () => {;} );
}


public static
    IStream< T >
Create<
    T
>(
    MaybeFunc< T >  maybeFunc,
    Action          disposeFunc
)
{
    NonNull.CheckParameter( maybeFunc, "maybeFunc" );
    return Create< T >(
        () => {
            T r;
            return maybeFunc( out r )
                ? Maybe.Create( r )
                : Maybe.Create< T >(); },
        disposeFunc );
}


/// Create a stream from a <tt>IStream<T>.TryPull()</tt> function
///
public static
    IStream< T >
Create<
    T
>(
    Func< IMaybe< T > > tryPullFunc
)
{
    return Create( tryPullFunc, () => {;} );
}


public static
    IStream< T >
Create<
    T
>(
    Func< IMaybe< T > > tryPullFunc,
    Action              disposeFunc
)
{
    return new Stream< T >( tryPullFunc, disposeFunc );
}



// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

/// Produce a new stream that yields the contents of the stream followed by
/// an additional specified item
///
public static
    IStream< T >
Append<
    T
>(
    this IStream< T >   dis,
    T                   item
)
{
    NonNull.CheckParameter( dis, "dis" );
    return dis.Concat( Stream.Create( item ) );
}


/// Produce a new stream that yields the contents of the stream followed by
/// the contents of another specified stream
///
public static
    IStream< T >
Concat<
    T
>(
    this IStream< T >   dis,
    IStream< T >        stream
)
{
    NonNull.CheckParameter( dis, "dis" );
    NonNull.CheckParameter( stream, "stream" );
    return
        dis.AsEnumerable()
            .Concat( stream.AsEnumerable() )
            .AsStream();
}


/// Try to pull the next item from the stream
///
public static
    bool
    /// @returns
    /// Whether there was another item in the stream
TryPull<
    T
>(
    this IStream< T >   dis,
    out T               item
    ///< The next item in the stream, if there was another item
    ///  - OR -
    ///  An undefined and unusable value, if there were no more items
)
{
    NonNull.CheckParameter( dis, "dis" );
    IMaybe< T > t = dis.TryPull();
    item = t.B;
    return t.A;
}


/// Pull the next item from the stream, expecting one to be available
///
/// @exception EmptyException
/// There were no more items available from <tt>stream</tt>
///
public static
    T
Pull<
    T
>(
    this IStream< T > dis
)
{
    NonNull.CheckParameter( dis, "dis" );
    T r;
    if( !dis.TryPull( out r ) )
        throw new ValueReferenceException(
            new Frame().Parameter( "dis" ),
            new EmptyException() );
    return r;
}


public static
    bool
SequenceEqual<
    T
>(
    this IStream< T >   dis,
    IStream< T >        that
)
{
    return dis.SequenceEqual< T, T >( that );
}


public static
    bool
SequenceEqual<
    T,
    TEquatable
    ///< Definition of equality to use
>(
    this IStream< T >   dis,
    IStream< T >        that
)
    where T : TEquatable
{
    return dis.SequenceEqual< T >(
        that,
        EqualityComparerHD.Create< TEquatable >()
            .Contravary< TEquatable, T >() );
}


public static
    bool
SequenceEqual<
    T
>(
    this IStream< T >           dis,
    IStream< T >                that,
    IEqualityComparerHD< T >    comparer
    ///< Equality comparer to use
)
{
    NonNull.CheckParameter( dis, "dis" );
    NonNull.CheckParameter( that, "that" );
    NonNull.CheckParameter( comparer, "comparer" );
    return dis.AsEnumerable().SequenceEqual( that.AsEnumerable(), comparer );
}


/// Pull items from the stream, performing an action on each, forever or until
/// the end of the stream is reached
///
public static
    void
ForEach<
    T
>(
    this IStream< T >   stream,
    Action< T >         action
)
{
    NonNull.CheckParameter( stream, "stream" );
    NonNull.CheckParameter( action, "action" );
    T item;
    while( stream.TryPull( out item ) )
        action( item );
}


/// Push all items from the stream to <tt>sink</tt>, which is expected to have
/// capacity to accept them all
///
/// @exception FullException
/// <tt>sink</tt> didn't have capacity to accept all items
/// (via <tt>Sink.Push()</tt>)
///
public static
    void
EmptyTo<
    T
>(
    this IStream< T >   stream,
    ISink< T >          sink
)
{
    NonNull.CheckParameter( stream, "stream" );
    NonNull.CheckParameter( sink, "sink" );
    stream.ForEach( sink.Push );
}


/// Present the stream as an enumerator
///
public static
    IEnumerator< T >
AsEnumerator<
    T
>(
    this IStream< T > dis
)
{
    NonNull.CheckParameter( dis, "dis" );
    T item;
    while( dis.TryPull( out item ) )
        yield return item;
}


/// Present the stream as an enumerable
///
/// This method is mainly to enable streams to work with existing
/// enumerable-based mechanisms like the LINQ <tt>IEnumerable</tt> and
/// <tt>IEnumerable<T></tt> extension methods and the C# <tt>foreach</tt>
/// statement.  Enumerables produced by this method are unusual in that calls to
/// <tt>GetEnumerator()</tt> do not "restart" iteration but instead just
/// continue from whatever point this underlying stream is at.  The result is
/// that one can use any combination of operations -- <tt>IStream<T></tt>,
/// <tt>IEnumerable</tt>, <tt>IEnumerable<T></tt>, <tt>foreach</tt>, etc. -- to
/// pull items from a single stream.
///
public static
    IEnumerable< T >
AsEnumerable<
    T
>(
    this IStream< T > dis
)
{
    NonNull.CheckParameter( dis, "dis" );
    return new SystemEnumerable< T >( () => dis.AsEnumerator() );
}


public static
    IStream< TTo >
Covary<
    TFrom,
    TTo
>(
    this IStream< TFrom > dis
)
    where TFrom : TTo
{
    return new StreamProxy< TFrom, TTo >( dis );
}


/// Connect a filter to the stream
///
public static
    IStream< TOut >
To<
    TIn,
    TOut
>(
    this IStream< TIn >     dis,
    IFilter< TIn, TOut >    filter
)
{
    return dis.To( filter, true, true );
}


public static
    IStream< TOut >
To<
    TIn,
    TOut
>(
    this IStream< TIn >     dis,
    IFilter< TIn, TOut >    filter,
    bool                    disposeThis,
    bool                    disposeFilter
)
{
    NonNull.CheckParameter( dis, "dis" );
    NonNull.CheckParameter( filter, "filter" );
    return Stream.Create(
        () => {
            TIn i;
            for( ;; ) {
                if( filter.State == FilterState.Closed )
                    return Maybe.Create< TOut >();
                if( filter.State == FilterState.Have )
                    return Maybe.Create( filter.Take() );
                if( dis.TryPull( out i ) )
                    filter.Give( i );
                else
                    filter.Close();
            } },
        () => {
            if( disposeFilter )
                filter.Dispose();
            if( disposeThis )
                dis.Dispose(); } );
}




} // type
} // namespace

