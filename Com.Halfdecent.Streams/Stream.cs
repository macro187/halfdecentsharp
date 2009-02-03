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


using System.Collections.Generic;
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

/// Yield an item that is expected to exist
///
/// @exception EndOfStreamException
/// There were no more items on <tt>stream</tt>
///
public static
T
Expect<
    T
>(
    this IStream< T > stream
)
{
    NonNull.Check( stream, new Parameter( "stream" ) );
    T r;
    if( !stream.Yield( out r ) )
        throw new EndOfStreamException( new Parameter( "stream" ) );
    return r;
}




} // type
} // namespace

