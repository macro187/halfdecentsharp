// -----------------------------------------------------------------------------
// Copyright (c) 2009
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
    new NonNull().Require( dis, new Parameter( "dis" ) );
    return dis.Concat( new Stream< T >( item ) );
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
    new NonNull().Require( dis, new Parameter( "dis" ) );
    return
        dis.AsEnumerable().Concat(
            stream.AsEnumerable() )
        .AsStream();
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
    this IStream< T > stream
)
{
    new NonNull().Require( stream, new Parameter( "stream" ) );
    T r;
    if( !stream.TryPull( out r ) )
        throw new EmptyException( new This() );
    return r;
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
    new NonNull().Require( stream, new Parameter( "stream" ) );
    new NonNull().Require( sink, new Parameter( "sink" ) );
    T item;
    while( stream.TryPull( out item ) )
        sink.Push( item );
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
    new NonNull().Require( dis, new Parameter( "dis" ) );
    return
        new EnumerableFromEnumeratorAdapter< T >(
            new StreamToEnumeratorAdapter< T >( dis ) );
}




} // type
} // namespace

