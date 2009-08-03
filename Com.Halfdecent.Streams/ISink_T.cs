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


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// A programmatic consumer of items
///
/// See <tt>http://en.wikipedia.org/wiki/Sink_(computing)</tt>
///
/// @par Item Lifetime
/// When given an item, a sink accepts responsiblity for destroying it
/// if and when appropriate.  This would generally be when the item is no
/// longer needed, is not being stored, and will not be further passed along or
/// otherwise made available.  Specifically, this means (in .NET) that the sink
/// will <tt>Dispose()</tt> the item (if applicable) and release all references
/// so as not to prevent it's being garbage-collected.
///
/// @par Capacity
/// Sinks <em>may</em> have a non-exceptional, clearly-definable definition of
/// "capacity", in which case operations that grow the bag may be capable of
/// signalling a "full" condition via a return value.
/// <tt>false</tt> will never be returned.  Regardless, all other failures will
/// be signalled with appropriate exceptions.
// =============================================================================

// TODO Common external disposal routine used by all sinks that can be used
//      eg. to capture and re-use objects etc.

public interface
ISink<
    T
>
{



/// Try to push an item into the sink
///
bool
/// @returns Whether the sink had capacity to accept the item
TryPush(
    T item
);




} // type
} // namespace

