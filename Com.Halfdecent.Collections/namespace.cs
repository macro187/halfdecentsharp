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
/// @section kinds Kinds of Collections
///
///     - ICollection< T >
///     - IKeyedCollection< TKey, T >
///     - IUniqueKeyedCollection< TKey, T >
///     - IOrderedCollection< T >
///
/// @section mutability Kinds of Mutability
///
///     - (R)eadable: Existing items can be retrieved
///     - (C)hangeable: Existing items can be replaced with new ones
///     - (S)hrinkable: Existing items can be removed, shrinking the collection
///     - (G)rowable: New items can be added, growing the collection
///
/// @section keyedcollections Keyed Collections
///
///     - Explicit vs. implicit keys
///
///         This refers to whether keys are specified explicitly or extracted
///         from the items.  Explicitly-keyed collections implement
///         <tt>IKeyedCollectionG< T ></tt> and <tt>.Add( TKey, T )</tt>, while
///         implicitly-keyed collections implement <tt>ICollectionG< T ></tt>
///         and <tt>.Add( T )</tt>.
///
/// @section capacity Capacity
///
///     TODO
///     Collections <em>may</em> have non-exceptional, clearly-definable
///     definitions of "capacity", in which case collection-growing operations
///     may be able to signal "full" conditions via return values.
///
/// @section namespaceconflict Namespace Conflict
///
///     This namespace contains type names conflicting with
///     <tt>System.Collections</tt> and <tt>System.Collections.Generic</tt>.
///     Ideally, this namespace completely supercedes them, but in cases where
///     they must both be used, use either full type names...
///
///     <code>
///     using Com.Halfdecent.Collections;
///
///     // ...
///
///     System.Collections.Enumerator e = someenumerable.GetEnumerator();
///     </code>
///
///     ...or namespace aliases:
///
///     <code>
///     using SC = System.Collections;
///     using SCG = System.Collections.Generic;
///     using Com.Halfdecent.Collections;
///
///     //...
///
///     SC.Enumerator e = someenumerable.GetEnumerator();
///     </code>
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

