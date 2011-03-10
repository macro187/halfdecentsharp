// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010, 2011
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


using SCG = System.Collections.Generic;
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

public static
    IStream< T >
Create<
    T
>(
    params T[] items
)
{
    return items.AsStream();
}


public static
    IStream< T >
Create<
    T
>(
    System.Func< bool > canPullFunc,
    System.Func< T >    pullFunc
)
{
    NonNull.CheckParameter( canPullFunc, "canPullFunc" );
    NonNull.CheckParameter( pullFunc, "pullFunc" );
    return new Stream< T >( canPullFunc, pullFunc );
}


public static
    IStream< T >
Create<
    T
>(
    MaybeFunc< T > maybeFunc
)
{
    NonNull.CheckParameter( maybeFunc, "maybeFunc" );
    return new Stream< T >( maybeFunc );
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
    ITuple< bool, T > t = dis.TryPull();
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
    return dis.SequenceEqual(
        that,
        new ObjectComparer().Contravary< object, T >() );
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
    where TEquatable : IEquatable< TEquatable >
{
    return dis.SequenceEqual< T >(
        that,
        new EquatableComparer< TEquatable >().Contravary< TEquatable, T >() );
}


public static
    bool
SequenceEqual<
    T
>(
    this IStream< T >           dis,
    IStream< T >                that,
    SCG.IEqualityComparer< T >  comparer
    ///< Equality comparer to use
)
{
    NonNull.CheckParameter( dis, "dis" );
    NonNull.CheckParameter( that, "that" );
    NonNull.CheckParameter( comparer, "comparer" );
    return dis.AsEnumerable().SequenceEqual( that.AsEnumerable(), comparer );
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
    T item;
    while( stream.TryPull( out item ) )
        sink.Push( item );
}


/// Present the stream as an enumerator
///
public static
    SCG.IEnumerator< T >
AsEnumerator<
    T
>(
    this IStream< T > dis
)
{
    NonNull.CheckParameter( dis, "dis" );
    return new SystemEnumerator< T >( dis.TryPull );
}


/// Present the stream as an enumerable
///
public static
    SCG.IEnumerable< T >
AsEnumerable<
    T
>(
    this IStream< T > dis
)
{
    NonNull.CheckParameter( dis, "dis" );
    return
        new SystemEnumerableFromSystemEnumeratorAdapter< T >(
            dis.AsEnumerator() );
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


/// Connect a stream to a filter
///
public static
    IStream< TTo >
PipeTo<
    TFrom,
    TTo
>(
    this IStream< TFrom > dis,
    IFilter< TFrom, TTo > to
)
{
    return dis.PipeTo< TFrom, TTo >( to, true, true );
}


/// Connect a stream to a filter, specifying whether each should be disposed
/// after use
///
public static
    IStream< TTo >
PipeTo<
    TFrom,
    TTo
>(
    this IStream< TFrom >   dis,
    IFilter< TFrom, TTo >   to,
    bool                    disposeThis,
    bool                    disposeTo
)
{
    return new StreamToFilter< TFrom, TTo >( dis, disposeThis, to, disposeTo );
}




} // type
} // namespace

