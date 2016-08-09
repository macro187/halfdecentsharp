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


using System.Collections.Generic;
using Halfdecent.RTypes;


namespace
Halfdecent.Streams
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
    this IEnumerator< T > dis
)
{
    NonNull.CheckParameter( dis, "dis" );
    return Stream.Create(
        dis.MoveNext,
        () => dis.Current );
}




} // type
} // namespace

