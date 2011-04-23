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


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// A function that can be called repeatedly to perform filter processing
///
/// The first time the function is called, <tt>GetState()</tt> returns
/// <tt>null</tt> and the function can either:
///
///     1)  Return <tt>Want</tt>, indicating that it wants to start processing
///         and requires and item
///
///     2)  Return <tt>Closed</tt>, indicating that it will not process anything
///         at all
///
/// On each subsequent call, <tt>GetState()</tt> returns the current state, and
/// the function must:
///
///     -   If <tt>GetState()</tt> is <tt>Want</tt>, retrieve the next
///         input item using <tt>Get()</tt>
///
///     -   Process until:
///
///         a)  An output item is produced, in which case output it using
///             <tt>Put()</tt> and return <tt>Have</tt>
///
///         b)  Another input item is required, in which case return
///             <tt>Want<tt>
///
///         c)  (if applicable) No further filter processing can ever be done,
///             in which case return <tt>Closed</tt>
///
// =============================================================================

public delegate
    FilterState
    /// @returns The new filter state
FilterStepFunc<
    in TIn,
    out TOut
>(
    System.Func< FilterState >  GetState,
    ///< Function indicating the current filter state
    System.Func< TIn >          Get,
    ///< Function that retrieves the next input item
    System.Action< TOut >       Put
    ///< Function that outputs an item
);




} // namespace

