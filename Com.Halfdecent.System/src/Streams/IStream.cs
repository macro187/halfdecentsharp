// -----------------------------------------------------------------------------
// Copyright (c) 2007 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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

using Com.Halfdecent.System;



namespace
Com.Halfdecent.Streams
{



/// <summary>
/// A programmatic source of a potentially infinite sequence of items, yielded
/// one after another over time
/// </summary>
/// <remarks>
/// <para>
/// <c>http://en.wikipedia.org/wiki/Stream_(computer)</c>
/// </para>
/// <para>
/// At any given time, <c>IStream</c>s are always at a single point in the
/// sequence.
/// </para>
/// <para>
/// On it's own, <c>IStream</c> does not imply how many more items (if any)
/// can be produced, nor how long (if ever) it will take to yield the next
/// one.  Implementations should document their semantics in these regards
/// and/or implement a stream sub-type with more specific semantics.
/// </para>
/// <para>
/// As a convenience, <c>IStream</c>s implement <c>IEnumerable&lt;T&gt;</c>.
/// <c>GetEnumerator()</c> returns the same <c>IEnumerator</c> no matter how
/// many times it's called, reflecting the single underlying stream.  Not only
/// does this enable iteration with <c>foreach</c>, it enables doing so more
/// than once, with each subsequent <c>foreach</c> iteration picking up from
/// the stream's current position.
/// </para>
/// </remarks>
/// <typeparam name="T">
/// Type common to all items in the stream
/// </typeparam>
public interface
IStream<T>
    : IEnumerable<T> // to enable foreach (no semantic implications)
{



/// <summary>
/// Produce the next item in the stream
/// </summary>
/// <remarks>
/// If the stream is capable of producing another item, <c>IStream</c> does
/// not imply how long it will take (if ever).
/// </remarks>
/// <exception cref="InvalidOperationException">
/// If the stream definitely cannot produce any more items
/// </exception>
/// <returns>
/// The next item in the stream
/// </returns>
T
Yield();




} // type
} // namespace

