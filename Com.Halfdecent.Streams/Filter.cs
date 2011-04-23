// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2011
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
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Streams
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
    System.Converter< TIn, TOut > convertFunc
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
    System.Converter< TIn, TOut >   convertFunc,
    System.Action                   disposeFunc
)
{
    return new Filter< TIn, TOut >( convertFunc, disposeFunc );
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
    System.Action                   disposeFunc
)
{
    return new Filter< TIn, TOut >( stepIterator, null, disposeFunc );
}



// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

/// Hook this filter to another one to produce a composite filter
///
// TODO Overload with disposeF1 and disposeF2 parameters
//
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
    SCG.IEnumerator< bool >
ComposeFilterStepIterator<
    TIn,
    TBetween,
    TOut
>(
    IFilter< TIn, TBetween >    f1,
    IFilter< TBetween, TOut >   f2,
    System.Func< FilterState >  getState,
    System.Func< TIn >          get,
    System.Action< TOut >       put
)
{
    NonNull.CheckParameter( f1, "f1" );
    NonNull.CheckParameter( f2, "f2" );
    NonNull.CheckParameter( getState, "getState" );
    NonNull.CheckParameter( get, "get" );
    NonNull.CheckParameter( put, "put" );
    for( ;; ) {
        // (f2 Have|Want|Closed)
        while( f2.State == FilterState.Have ) {
            // (f2 Have)
            put( f2.Take() );
            yield return true;
        }
        // (f2 Want|Closed)
        if( f2.State == FilterState.Closed ) yield break;
        // (f2 Want)

        // (f1 Have|Want|Closed)
        while( f1.State != FilterState.Have ) {
            // (f1 Want|Closed)
            if( f1.State == FilterState.Closed ) yield break;
            // (f1 Want)
            yield return false;
            f1.Give( get() );
        }
        // (f1 Have)
        f2.Give( f1.Take() );
    }
}


/// Hook this filter to a sink
///
/// Immediately attempts to empty any items in this filter to the sink
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
            if( disposeDis ) dis.Dispose();
            if( disposeSink ) sink.Dispose(); } );
}




} // type
} // namespace

