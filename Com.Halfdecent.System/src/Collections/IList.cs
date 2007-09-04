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




/// <summary>
/// An ordered collection of non-unique items
/// </summary>
/// <remarks>
/// <para>
/// An <c>IList</c> holds a finite sequence of items.  Refer to
/// <c>http://en.wikipedia.org/wiki/Sequence</c>.
/// </para>
/// <para>
/// Because items in an <c>IList</c> are in order, each is in a particular
/// position ranging from <c>0</c> (the first item) to <c>Count-1</c> (the
/// last item).
/// </para>
/// </remarks>
/// <typeparam name="T">
/// (see <see cref="IBag<T,TCount>"/>)
/// </typeparam>
/// <typeparam name="TCount">
/// (see <see cref="IBag<T,TCount>"/>)
/// </typeparam>
public interface
IList<T,TCount>
    : IBag<T,TCount>
    where TCount : struct
{




} // type
} // namespace

