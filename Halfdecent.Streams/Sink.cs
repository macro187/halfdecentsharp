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
using Halfdecent.Meta;
using Halfdecent.RTypes;


namespace
Halfdecent.Streams
{


// =============================================================================
/// <tt>ISink< T ></tt> Library
// =============================================================================

public static class
Sink
{



// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// Create a sink from an infinitely-callable function that performs the push
/// action
///
public static
    ISink< T >
Create<
    T
>(
    Action< T > pushFunc
)
{
    return Create< T >( pushFunc, () => {;} );
}


public static
    ISink< T >
Create<
    T
>(
    Action< T > pushFunc,
    Action      disposeFunc
)
{
    NonNull.CheckParameter( pushFunc, "pushFunc" );
    return Create< T >(
        item => {
            pushFunc( item );
            return true; },
        disposeFunc );
}


/// Create a sink from a pair of functions, one that determines whether a push
/// can occur, and one that does it
///
public static
    ISink< T >
Create<
    T
>(
    Func< bool >    canPushFunc,
    Action< T >     pushFunc
)
{
    return Create< T >( canPushFunc, pushFunc, () => {;} );
}


public static
    ISink< T >
Create<
    T
>(
    Func< bool >    canPushFunc,
    Action< T >     pushFunc,
    Action          disposeFunc
)
{
    NonNull.CheckParameter( canPushFunc, "canPushFunc" );
    NonNull.CheckParameter( pushFunc, "pushFunc" );
    return Create< T >(
        item => {
            if( canPushFunc() ) {
                pushFunc( item );
                return true;
            } else {
                return false;
            } },
        disposeFunc );
}


/// Create a sink from a function that performs and signals the success of the
/// push
///
public static
    ISink< T >
Create<
    T
>(
    Func< T, bool > tryPushFunc
)
{
    return Create< T >( tryPushFunc, () => {;} );
}


public static
    ISink< T >
Create<
    T
>(
    Func< T, bool > tryPushFunc,
    Action          disposeFunc
)
{
    NonNull.CheckParameter( tryPushFunc, "tryPushFunc" );
    return Create< T >(
        get => TryPushFuncToPushIterator( get, tryPushFunc ),
        disposeFunc );
}


private static
    IEnumerator< object >
TryPushFuncToPushIterator<
    T
>(
    Func< T >       get,
    Func< T, bool > tryPushFunc
)
{
    for( ;; ) {
        if( !tryPushFunc( get() ) ) break;
        yield return null;
    }
}


/// Create a sink from a iterator that performs push actions
///
public static
    ISink< T >
Create<
    T
>(
    SinkPushIterator< T > pushIterator
)
{
    return Create< T >( pushIterator, () => {;} );
}


public static
    ISink< T >
Create<
    T
>(
    SinkPushIterator< T >   pushIterator,
    Action                  disposeFunc
)
{
    NonNull.CheckParameter( pushIterator, "pushIterator" );
    return new Sink< T >( pushIterator, disposeFunc );
}




// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

/// Push an item into the sink, expecting there to be capacity for it
///
/// @exception FullException
/// The sink did not have capacity to accept the item
///
public static
    void
Push<
    T
>(
    this ISink< T > sink,
    T               item
)
{
    NonNull.CheckParameter( sink, "sink" );
    if( !sink.TryPush( item ) )
        throw new ValueReferenceException(
            new Frame().Parameter( "sink" ),
            new FullException() );
}


public static
    ISink< TTo >
Contravary<
    TFrom,
    TTo
>(
    this ISink< TFrom > dis
)
    where TTo : TFrom
{
    NonNull.CheckParameter( dis, "dis" );
    return new SinkProxy< TFrom, TTo >( dis );
}




} // type
} // namespace

