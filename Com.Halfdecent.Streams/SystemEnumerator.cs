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
using Com.Halfdecent;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// <tt>System.Collections.Generic.IEnumerator< T ></tt> Library
// =============================================================================

public static class
SystemEnumerator
{


// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

/// Present the enumerator as a stream
///
public static
    IStream< T >
AsStream<
    T
>(
    this SCG.IEnumerator< T > dis
)
{
    NonNull.CheckParameter( dis, "dis" );
    return new Stream< T >( () => {
        if( dis.MoveNext() )
            return Tuple.Create( true, dis.Current );
        else
            return Tuple.Create( false, default( T ) ); } );
}




} // type
} // namespace

