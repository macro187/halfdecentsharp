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
/// As a convenience, <c>IStream</c>s implement <c>IEnumerator&lt;T&gt;</c> and
/// <c>IEnumerable&lt;T&gt;</c> so they can be iterated using <c>foreach</c>
/// statements.  As <c>IEnumerator</c>s, they are non-<c>Reset()</c>table.  As
/// <c>IEnumerable</c>s, they always return themselves, so the same stream can
/// be <c>foreach</c>ed more than once, each time continuing from the point it
/// was last left.
/// </para>
/// <para>
/// Note that <c>IStream</c> implies no particular number of items, nor, if a
/// subsequent item is available, the timeframe in which it will be yielded,
/// if ever (ie. <see cref=">Yield"/> may block, and it may even do so
/// indefinitely).  Implementations should document their semantics in these
/// regards, implement a stream sub-type with more specific semantics, or both.
/// </para>
/// </remarks>
/// <typeparam name="T">
/// Type common to all items in the stream
/// </typeparam>
public interface
IStream<T>
    : IEnumerator<T> // to enable foreach (no semantic implications)
    , IEnumerable<T> // to enable foreach (no semantic implications)
{



/// <summary>
/// Advance to and return the next item in the stream
/// </summary>
/// <exception cref="InvalidOperationException">
/// If the stream definitely does not and will not have any more items
/// </exception>
/// <returns>
/// The next item in the stream
/// </returns>
/// <example>
/// Process items via <see cref="Yield"/>
/// <code>
/// for(;;) {
///     item = stream.Yield();
///     ...
/// }
/// </code>
/// </example>
/// <example>
/// Process items via <c>foreach</c>
/// <code>
/// foreach( Item item in stream ) {
///     ...
/// }
/// </code>
/// </example>
T
Yield();




} // type
} // namespace

