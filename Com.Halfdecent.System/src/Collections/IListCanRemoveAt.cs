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




/// A list from which items can be removed from any position
public interface
IListCanRemoveAt<
    T,      ///< (see IBag< T, TCount >)
    TCount  ///< (see IBag< T, TCount >)
>
    : IList< T, TCount >
{



/// Remove the item at a particular position
///
T                   /// @returns The removed item
RemoveAt(
    TCount position ///< Position from which to remove the item
                    ///< (see IList< T, TCount >)
                    ///  - <tt>IsBetween( 0, Count-1 )</tt>
);




} // type
} // namespace

