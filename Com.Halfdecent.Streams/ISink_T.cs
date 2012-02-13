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


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// A programmatic consumer of items
///
/// "End-of-stream" is signalled, if necessary, by disposal.
///
/// See <tt>http://en.wikipedia.org/wiki/Sink_(computing)</tt>
// =============================================================================

public interface
ISink<
#if DOTNET40
    in T
#else
    T
#endif
>
    : IDisposable
{



/// Try to push an item into the sink
///
    bool
    /// @returns
    /// Whether the sink had capacity for the item
TryPush(
    T item
);




} // type
} // namespace

