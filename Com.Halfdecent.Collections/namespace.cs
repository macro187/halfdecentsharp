// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010
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
/// Collections
///
/// TODO (introduction)
///
/// @section collections Kinds of Collections
///
///     - ICollection< T >
///     - IKeyedCollection< TKey, T >
///     - IUniqueKeyedCollection< TKey, T >
///     - IOrderedCollection< T >
///
/// @section mutability Kinds of Mutability
///
///     - (C)hangeable: Existing items can be replaced with new items
///     - (S)hrinkable: Existing items can be removed, shrinking the collection
///     - (G)rowable: New items can be added, growing the collection
///
/// @section keyedcollections Keyed Collections
///
///     - Explicit vs. non-explicit key
///
///         This refers to whether keys are specified explicitly or extracted
///         from the items.  Explicit collections implement
///         <tt>IKeyedCollectionG< T ></tt> and <tt>.Add( TKey, T )</tt>, while
///         implicit collections implement <tt>ICollectionG< T ></tt> and
///         <tt>.Add( T )</tt>.
///
///     - Item-centric vs. tuple-centric
///
///         All keyed collections imply both <tt>ICollection< T ></tt> and
///         <tt>ICollection< ITuple< TKey, T > ></tt>, so at least one needs to
///         be an explicit interface implementation.  An item-centric
///         keyed collection is one where the 
///
/// @section capacity Capacity
///
///     XXX
///     Collections <em>may</em> have non-exceptional, clearly-definable
///     definitions of a "capacity", in which case operations attempting
///     to add items to the collection may be able to signal "full"
///     conditions via a return value.  <tt>false</tt> will never be
///     returned.  Regardless, all other failures will be signalled with
///     appropriate exceptions.
///
/// @section seealso See Also
///
///     - <tt>http://en.wikipedia.org/wiki/Collection_(computing)</tt>
///
// =============================================================================

namespace
Com.Halfdecent.Collections
{
}

