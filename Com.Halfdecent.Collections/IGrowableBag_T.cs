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
Com.Halfdecent.Collections
{


// =============================================================================
/// A bag to which items can be added
///
/// @par Capacity
/// Bags <em>may</em> have a non-exceptional, clearly-definable definition of
/// "capacity", in which case operations that grow the bag may be capable of
/// signalling a "full" condition via a return value.
/// <tt>false</tt> will never be returned.  Regardless, all other failures will
/// be signalled with appropriate exceptions.
// =============================================================================

public interface
IGrowableBag<
    T
>
    : IBag< T >
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Try adding an item to the bag
///
bool
/// @returns
/// <tt>true</tt> if there was capacity for the item and it was added
/// - OR -
/// <tt>false</tt> otherwise
TryAdd(
    T item
);




} // type
} // namespace

