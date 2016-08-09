// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2011, 2012
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
using Halfdecent.RTypes;


namespace
Halfdecent.Streams
{


// =============================================================================
/// <tt>IFilter<TIn,TOut></tt> Library
// =============================================================================

public static class
Filter
{



// -----------------------------------------------------------------------------
// Static
// -----------------------------------------------------------------------------

/// Create a filter from a <tt>System.Converter<TInput,TOutput></tt> function
///
public static
    IFilter< TIn, TOut >
Create<
    TIn,
    TOut
>(
    Converter< TIn, TOut > convertFunc
)
{
    return Create< TIn, TOut >( convertFunc, () => {;} );
}


public static
    IFilter< TIn, TOut >
Create<
    TIn,
    TOut
>(
    Converter< TIn, TOut >  convertFunc,
    Action                  disposeFunc
)
{
    NonNull.CheckParameter( convertFunc, "convertFunc" );
    return new Filter< TIn, TOut >(
        null,
        (GetState,Get,Put) => {
            if( GetState() == FilterState.NotStarted ) {
                return FilterState.Want;
            } else if( GetState() == FilterState.Want ) {
                Put( convertFunc( Get() ) );
                return FilterState.Have;
            } else if( GetState() == FilterState.Have ) {
                return FilterState.Want;
            } else if( GetState() == FilterState.Closed ) {
                return FilterState.Closed;
            } else {
                throw new BugException();
            } },
        disposeFunc );
}


/// Create a filter from a <tt>FilterStepIterator</tt> function
///
public static
    IFilter< TIn, TOut >
Create<
    TIn,
    TOut
>(
    FilterStepIterator< TIn, TOut > stepIterator
)
{
    return Create< TIn, TOut >( stepIterator, () => {;} );
}


public static
    IFilter< TIn, TOut >
Create<
    TIn,
    TOut
>(
    FilterStepIterator< TIn, TOut > stepIterator,
    Action                          disposeFunc
)
{
    return new Filter< TIn, TOut >( stepIterator, null, disposeFunc );
}



// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

/// Hook this filter to another one to produce a composite filter
///
public static
    IFilter< TIn, TOut >
To<
    TIn,
    TBetween,
    TOut
>(
    this IFilter< TIn, TBetween >   dis,
    IFilter< TBetween, TOut >       filter
)
{
    return dis.To< TIn, TBetween, TOut >( filter, true, true );
}


public static
    IFilter< TIn, TOut >
To<
    TIn,
    TBetween,
    TOut
>(
    this IFilter< TIn, TBetween >   dis,
    IFilter< TBetween, TOut >       filter,
    bool                            disposeDis,
    bool                            disposeFilter
)
{
    NonNull.CheckParameter( dis, "dis" );
    NonNull.CheckParameter( filter, "filter" );
    return Filter.Create< TIn, TOut>(
        (getState,get,put) =>
            ComposeFilterStepIterator( dis, filter, getState, get, put ),
        () => {
            if( disposeDis ) dis.Dispose();
            if( disposeFilter ) filter.Dispose(); } );
}

private static
    IEnumerator< FilterState >
ComposeFilterStepIterator<
    TIn,
    TBetween,
    TOut
>(
    IFilter< TIn, TBetween >    f1,
    IFilter< TBetween, TOut >   f2,
    Func< FilterState >         getState,
    Func< TIn >                 get,
    Action< TOut >              put
)
{
    NonNull.CheckParameter( f1, "f1" );
    NonNull.CheckParameter( f2, "f2" );
    NonNull.CheckParameter( getState, "getState" );
    NonNull.CheckParameter( get, "get" );
    NonNull.CheckParameter( put, "put" );

    for( ;; ) {
        // (f1 Want|Have|Closed)
        // (f2 Want|Have|Closed)

        if( f2.State == FilterState.Closed )
            break;

        // (f1 Want|Have|Closed)
        // (f2 Want|Have)

        if( f2.State == FilterState.Have ) {
            put( f2.Take() );
            yield return FilterState.Have;
            continue;
        }

        // (f1 Want|Have|Closed)
        // (f2 Want)

        if( f1.State == FilterState.Closed ) {
            f2.Close();
            continue;
        }

        // (f1 Want|Have)
        // (f2 Want)

        if( f1.State == FilterState.Have ) {
            f2.Give( f1.Take() );
            continue;
        }

        // (f1 Want)
        // (f2 Want)

        yield return FilterState.Want;
        if( getState() == FilterState.Closed ) continue;
        f1.Give( get() );
    }
}


/// Hook this filter to a sink
///
/// Immediately attempts to empty any items in this filter to the sink
///
/// When disposed, attempts to empty any items remaining in the filter into the
/// sink.
///
public static
    ISink< TIn >
To<
    TIn,
    TBetween
>(
    this IFilter< TIn, TBetween >   dis,
    ISink< TBetween >               sink
)
{
    return dis.To< TIn, TBetween >( sink, true, true );
}


/// Hook this filter to a sink
///
/// Immediately attempts to empty any items in this filter to the sink
///
/// If <tt>disposeDis</tt>, when disposed, attempts to empty any items remaining
/// in the filter into the sink.
///
public static
    ISink< TIn >
To<
    TIn,
    TBetween
>(
    this IFilter< TIn, TBetween >   dis,
    ISink< TBetween >               sink,
    bool                            disposeDis,
    bool                            disposeSink
)
{
    NonNull.CheckParameter( dis, "dis" );
    NonNull.CheckParameter( sink, "sink" );

    while( dis.State == FilterState.Have )
        if( sink.TryPush( dis.Peek() ) )
            dis.Take();
        else
            break;

    return Sink.Create< TIn >(
        i => {
            // (Want|Closed|Have)
            while( dis.State != FilterState.Want ) {
                // (Closed|Have)
                if( dis.State == FilterState.Closed ) return false;
                // (Have)
                if( !sink.TryPush( dis.Peek() ) ) return false;
                dis.Take();
            }
            // (Want)
            dis.Give( i );
            // (Want|Closed|Have)
            while( dis.State == FilterState.Have ) {
                // (Have)
                if( !sink.TryPush( dis.Peek() ) ) return true;
                dis.Take();
            }
            // (Want|Closed)
            if( dis.State == FilterState.Closed ) return true;
            // (Want)
            return true;
            },

        () => {
            if( disposeDis ) {
                dis.Close();
                while( dis.State == FilterState.Have )
                    if( sink.TryPush( dis.Peek() ) )
                        dis.Take();
                    else
                        break;
                dis.Dispose();
            }
            if( disposeSink )
                sink.Dispose(); } );
}




} // type
} // namespace

