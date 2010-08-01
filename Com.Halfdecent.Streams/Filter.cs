// -----------------------------------------------------------------------------
// Copyright (c) 2010
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


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// <tt>IFilter< TFrom, TTo ></tt> Library
// =============================================================================

public static class
Filter
{



// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

/// Connect a filter to another filter
///
public static
    IFilter< TFrom, TTo >
PipeTo<
    TFrom,
    TBetween,
    TTo
>(
    this IFilter< TFrom, TBetween > dis,
    IFilter< TBetween, TTo >        to
)
{
    return dis.PipeTo< TFrom, TBetween, TTo >( to, true, true );
}


/// Connect a filter to another filter, specifying whether each should be
/// disposed after use
///
public static
    IFilter< TFrom, TTo >
PipeTo<
    TFrom,
    TBetween,
    TTo
>(
    this IFilter< TFrom, TBetween > dis,
    IFilter< TBetween, TTo >        to,
    bool                            disposeThis,
    bool                            disposeTo
)
{
    return new FilterToFilter< TFrom, TBetween, TTo >(
        dis, disposeThis, to, disposeTo );
}


/// Connect a filter to a sink
///
public static
    ISink< TFrom >
PipeTo<
    TFrom,
    TTo
>(
    this IFilter< TFrom, TTo >  dis,
    ISink< TTo >                to
)
{
    return dis.PipeTo< TFrom, TTo >( to, true, true );
}


/// Connect a filter to a sink, specifying whether each should be disposed
/// after use
///
public static
    ISink< TFrom >
PipeTo<
    TFrom,
    TTo
>(
    this IFilter< TFrom, TTo >  dis,
    ISink< TTo >                to,
    bool                        disposeThis,
    bool                        disposeTo
)
{
    return new FilterToSink< TFrom, TTo >( dis, disposeThis, to, disposeTo );
}




} // type
} // namespace
