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




/// A list to which items can be added at any position
public interface
IListCanAddAt<
    T,      ///< (see IBag< T, TCount >)
    TCount  ///< (see IBag< T, TCount >)
>
    : IList< T, TCount >
{



/// Add the given item at the given position
///
/// @exception ArgumentOutOfRangeException
/// The specified <tt>position</tt> is negative or greater than the last
/// item's position
/// </exception>
void
AddAt(
    TCount  position,   ///< Position at which to add the item
                        ///< (see IList< T, TCount >)
    T       item        ///< Item to add
);




} // type
} // namespace

