// -----------------------------------------------------------------------------
// Copyright (c) 2011
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


using SCG = System.Collections.Generic;


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// An iterator function that performs filter processing
///
/// Each iteration (<tt>yield</tt> if implemented as a C# iterator) behaves like
/// an invocation of a <tt>FilterStepFunc<TIn,TOut></tt> except that:
/// - Yielding <tt>false</tt> means <tt>Want</tt>
/// - Yielding <tt>true</tt> means <tt>Have</tt>
/// - End of iteration means <tt>Closed</tt>
///
/// See:
/// <tt>http://msdn.microsoft.com/en-us/library/dscyy5s0.aspx</tt>
/// <tt>http://en.wikipedia.org/wiki/Coroutine</tt>
// =============================================================================

public delegate
    SCG.IEnumerator< FilterState >
    /// @returns An enumerator that performs a filter processing step on each
    /// <tt>.MoveNext()</tt>
FilterStepIterator<
    #if DOTNET40
    in TIn,
    out TOut
    #else
    TIn,
    TOut
    #endif
>(
    System.Func< FilterState >  GetState,
    ///< Function indicating the current filter state
    System.Func< TIn >          Get,
    ///< Function that retrieves the next input item
    System.Action< TOut >       Put
    ///< Function that outputs an item
);




} // namespace

