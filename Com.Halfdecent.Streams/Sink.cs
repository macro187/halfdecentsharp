// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010
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


using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// <tt>ISink< T ></tt> Library
// =============================================================================

public static class
Sink
{



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
    NonNull.Require( sink, new Parameter( "sink" ) );
    if( !sink.TryPush( item ) )
        throw new FullException( new This() );
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
    NonNull.Require( dis, new Parameter( "dis" ) );
    return new SinkProxy< TFrom, TTo >( dis );
}




} // type
} // namespace

