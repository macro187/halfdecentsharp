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
/// A bag from which items can be removed
// =============================================================================

public interface
IShrinkableBag<
    T
>
    : IBag< T >
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Remove (an occurrence of) an item from the bag that is equal to the
/// specified item (if the bag contains such an item)
///
//  TODO Clarify what "equal to" means here
//       == operator ?
//       item.Equals( sought ) ?
//       sought.Equals( item ) ?
//
bool
/// @returns
/// <tt>true</tt> if the bag contained an item equal to the specified item and
/// it was removed
/// - OR -
/// <tt>false</tt> otherwise
TryRemove(
    T sought
);


/// Remove all items from the bag
///
void
RemoveAll();




} // type
} // namespace

