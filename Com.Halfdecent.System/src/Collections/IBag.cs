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
Com.Halfdecent.Collections
{




/// An unordered collection of non-unique items
///
/// Bags hold finite multisets of items.  Refer to
/// <tt>http://en.wikipedia.org/wiki/Multiset</tt>.
public interface
IBag<
    T,      ///< Type common to all items in the bag
    TCount  ///< A numeric type whose maximum value is greater than or equal
            ///< to the maximum number of items the bag can contain
>
{



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// The number of items in the bag
TCount
Count
{
    get;
}




} // type
} // namespace

