// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2011, 2012
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


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// A mechanism that transforms one sequence of items to another
///
/// @section state State
/// A filter is always in a particular <tt>FilterState</tt> as indicated by
/// <tt>.State</tt>.
///
//  TODO Find a clearer way to illustrate these state transitions
///
/// <pre>
/// State Flowcharts
/// ----------------
///
/// Filter closes immediately:
///
///     NotStarted  -->  Closed
///
///
/// Filter processes normally, possibly eventually deciding to close itself:
///
///                       ..         ..
///                      V  )       V  )
///                        /          /
///     NotStarted  -->  Want  -->  Have  -->  Closed
///                            <--
///
///
/// While processing, filter is instructed to close:
///
///            ...  -->  Want  -->  Closed  -->  Have
///                                         <--
///
/// </pre>
///
// =============================================================================

public interface
IFilter<
    #if DOTNET40
    in TIn,
    out TOut
    #else
    TIn,
    TOut
    #endif
>
    : IDisposable
{



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

FilterState
State
{
    get;
}



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Give an input item to the filter
///
/// The filter continues processing, proceeding to the next state.
///
/// Only valid when the filter is in the <tt>Want</tt> state.
///
/// @exception InvalidOperationException
/// <tt>.State != Want</tt>
///
    void
Give(
    TIn item
);


/// Peek at the available output item
///
/// The filter does <em>not</em> continue processing.
///
/// Only valid when the filter is in the <tt>Have</tt> state.
///
/// @exception InvalidOperationException
/// <tt>.State != Have</tt>
///
    TOut
Peek();


/// Retrieve the available output item
///
/// The filter continues processing, proceeding to the next state.
///
/// Only valid when the filter is in the <tt>Have</tt> state.
///
/// @exception InvalidOperationException
/// <tt>.State != Have</tt>
///
    TOut
Take();


/// Instruct the filter to begin closing
///
/// The filter begins yielding any remaining in-flight items via final
/// <tt>Have</tt> states, after which it proceeds to the <tt>Closed</tt> state.
///
/// Only valid when the filter is in the <tt>Want</tt> state.
///
/// @exception InvalidOperationException
/// <tt>.State != Want</tt>
///
    void
Close();




} // type
} // namespace

