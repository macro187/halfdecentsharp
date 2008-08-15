// -----------------------------------------------------------------------------
// Copyright (c) 2008 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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
using System.Collections;
using System.Collections.Generic;

namespace
Com.Halfdecent.Streams
{




/// A programmatic source of a potentially infinite sequence of items, yielded
/// one after another over time
///
/// See <tt>http://en.wikipedia.org/wiki/Stream_(computer)</tt>
///
/// Intuitively, at any given time a stream is "positioned" just before the
/// next item in the sequence.
///
/// On it's own, <tt>IStream< T ></tt> does not imply how many more items (if
/// any) can be produced, nor how long (if ever) it will take to yield the next
/// one.  Implementations should document their semantics in these regards
/// and/or implement a stream subtype with more specific semantics.
///
/// @par <tt>IEnumerable< T ></tt>
/// As a convenience, streams implement <tt>IEnumerable< T ></tt>.
/// <tt>GetEnumerator()</tt> returns the same enumerator no matter how
/// many times it's called, reflecting the single underlying stream.  Not only
/// does this enable iteration with <tt>foreach</tt>, it enables doing so more
/// than once, with each subsequent <tt>foreach</tt> iteration picking up from
/// the stream's current position.
///
public interface
IStream<
    T   ///< Type common to all items in the stream
>
    : IEnumerable< T > // to enable foreach (no semantic implications)
{



/// Produce the next item in the stream
///
/// If the stream is capable of producing another item, <tt>IStream< T ></tt>
/// does not imply how long it will take (if ever).
///
/// @exception HDInvalidOperationException
/// If the stream definitely cannot produce any more items
///
T   /// @returns The next item in the stream
Yield();




} // type
} // namespace

