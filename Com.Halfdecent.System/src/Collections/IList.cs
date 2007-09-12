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
using Com.Halfdecent.Streams;


namespace
Com.Halfdecent.Collections
{




/// An ordered collection of non-unique items
///
/// Lists hold finite sequences of items.  Refer to
/// <tt>http://en.wikipedia.org/wiki/Sequence</tt>.
///
/// @par Positions
/// Because items in a list are in order, each is in a particular position
/// ranging from <tt>0</tt> (the first item) to <tt>Count-1</tt>
/// (the last item).
public interface
IList<
    T,      ///< (see IBag< T, TCount >)
    TCount  ///< (see IBag< T, TCount >)
>
    : IBag< T, TCount >
{




} // type
} // namespace

