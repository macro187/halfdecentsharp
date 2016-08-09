// -----------------------------------------------------------------------------
// Copyright (c) 2011, 2012
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


using System;
using System.Collections.Generic;


namespace
Halfdecent.Streams
{


// =============================================================================
/// An iterator function that performs sink processing
///
/// The iterator should repeatedly...
/// -   Call the provided <tt>get()</tt> function to get the next item
/// -   Process the item
/// -   <tt>yield return null;</tt>
/// ...forever or until the sink can take no more items, at which time the
/// iterator should exit 
///
/// See:
/// <tt>http://en.wikipedia.org/wiki/Coroutine</tt>
// =============================================================================

public delegate
    IEnumerator< object >
    /// @returns An enumerator that processes another sink input item on each
    /// <tt>.MoveNext()</tt>
SinkPushIterator<
    #if DOTNET40
    in T
    #else
    T
    #endif
>(
    Func< T > Get
    ///< Function that retrieves the next input item
);




} // namespace

