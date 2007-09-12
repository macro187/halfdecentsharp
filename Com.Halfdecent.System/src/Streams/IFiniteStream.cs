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




/// A stream of a finite but unknown number of items
///
/// @par Process items via <tt>Yield()</tt>
/// @code
/// while( stream.Yield( out item ) ) {
///     ...
/// }
/// @endcode
///
/// @par Process items via <tt>foreach</tt>
/// <tt>IFiniteStream< T ></tt>s implement <tt>IEnumerable< T ></tt> and
/// therefore can be iterated using <tt>foreach</tt>.  The loop will exit
/// gracefully when the end of the stream has been reached:
/// @code
/// foreach( Item item in stream ) {
///     // ...
/// }
/// @endcode
/// As long as items remain on the stream, it can be <tt>foreach</tt>ed more
/// than once, each time picking up where the last left off:
/// @code
/// // The stream
/// IFiniteStream<type> stream = ...;
///
/// // Process some of the items
/// foreach( Item item in stream ) {
///     // ...
///     if( condition ) break;
/// }
///
/// // Do something else
/// // ...
///
/// // Pick up where we left off
/// foreach( Item item in stream ) {
///     // ...
/// }
/// @endcode
public interface
IFiniteStream<
    T   ///< Type common to all items in the stream
>
    : IStream< T >
{



/// Attempt to advance to and return the next item in the stream
bool            /// @returns Whether there was another item in the stream.
                /// Once this is <tt>false</tt>, the end of the stream has
                /// been reached and it will never yield any more items.
Yield(
    out T item  ///< The next item in the stream if there was one, otherwise
                ///< some undefined value which should not be used
);




} // type
} // namespace

