// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010, 2011
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


// =============================================================================
/// Sequences of items over time
///
///
/// @section introduction Introduction
///
///     This library deals with streams in the simple "sequence of items over
///     time" sense, not the more complicated "IO stream" sense as implemented
///     in the C++ standard library or in <tt>System.IO</tt>.
///
///
/// @section problem Problem
///
///     -   The Base Class Library offers (and uses) <tt>IEnumerable<T></tt> as
///         a stream, except it isn't a stream, it's a stream factory.
///         <tt>IEnumerator<T></tt> is the stream.  They mixed them up.
///
///     -   <tt>foreach</tt> iterates stream factories, not streams.  Wrong.
///
///     -   The LINQ stream processing extension methods work on stream
///         factories, not streams.  Wrong.
///
///     -   <tt>IEnumerator<T></tt> is misnamed.  The name suggests that it's
///         more than just a stream, something like a cursor or a C++ iterator.
///         But it's not, because it's forward-only, read-only, and
///         <tt>.Reset()</tt> is never implemented.  The Base Class Library
///         itself only ever uses it as a stream, and then only indirectly
///         through <tt>IEnumerable<T></tt>.
///
///     -   <tt>IEnumerator<T></tt> is way too complicated for being just a
///         stream:  <tt>.Reset()</tt> isn't used.  The most recently-yielded
///         value is kept around in <tt>.Current</tt>, which is illegal to
///         access if you haven't <tt>.MoveNext()</tt>'d yet, or if there are no
///         more items.  <tt>.MoveNext()</tt> retrieves the next value but
///         doesn't give it to you, you have to go get it from <tt>.Current</tt>
///         as a separate operation.  In fact, the functionality of the entire
///         type can be (and is, in this library) reduced to a single function.
///
///     -   Lots of entities in the BCL could be treated uniformly as streams
///         and sinks, but aren't.  For example, <tt>System.IO.Stream</tt> in
///         read mode could be a stream of bytes, and in write mode could be a
///         byte sink.
///
///     -   The BCL has no sink type.
///
///     -   BCL stream processing routines are implemented in terms of
///         <tt>IEnumerable<T></tt>, so even if sinks were introduced, none of
///         the existing operations would work with them.
///
///
/// @section solution Solution
///
///     -   Streams:  <tt>IStream<T></tt> and <tt>Stream<T></tt>
///
///     -   Sinks:  <tt>ISink<T></tt> and <tt>Sink<t></tt>
///
///     -   Filters that work on both streams and sinks:
///         <tt>IFilter<TIn,TOut></tt> and <tt>Filter<TIn,TOut></tt>
///
///     -   %Streams, filters, and sinks are composable:
///         <tt>Stream.To()</tt>,
///         <tt>Filter.To()</tt>
///
///     -   Turn all kinds of stuff into streams or sinks:
///         <tt>SystemEnumerable.AsStream<T>()</tt>,
///         <tt>SystemEnumerator.AsStream<T>()</tt>,
///         <tt>SystemCollection.AsSink<T>()</tt>,
///         <tt>SystemStream.AsHalfdecentStream()</tt>,
///         <tt>SystemStream.AsHalfdecentSink()</tt>
///
///     -   Turn streams into <tt>IEnumerable<T></tt> so they work with
///         <tt>foreach</tt>, LINQ, legacy code, etc:
///         <tt>Stream.AsEnumerable<T>()</tt>
///
///     -   Library of filters:  <tt>TextDecoder</tt>, <tt>TextEncoder</tt>,
///         <tt>TextLineSplitter</tt>
///
///
/// @section usage Usage Examples
///
///     (TODO usage examples)
///
///
// =============================================================================

namespace
Halfdecent.Streams
{
}

