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
using Com.Halfdecent.System;



namespace
Com.Halfdecent.Streams
{



/// <summary>
/// A stream of a finite but unknown number of items
/// </summary>
/// <remarks>
/// Once <see cref="Yield"/> returns <c>false</c>, the stream does not and
/// never will have any more items.
/// </remarks>
/// <typeparam name="T">
/// Type common to all items in the stream
/// </typeparam>
public interface
IFiniteStream<T>
    : IStream<T>
{



/// <summary>
/// Attempt to advance to and return the next item in the stream
/// </summary>
/// <param name="item">
/// The next item in the stream, or <c>default(T)</c> if the end has been
/// reached
/// </param>
/// <returns>
/// Whether there was another item in the stream
/// </returns>
/// <example>
/// Process items via <see cref="Yield"/>
/// <code>
/// while( stream.Yield( out item ) ) {
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
bool
Yield( out T item );




} // type
} // namespace

