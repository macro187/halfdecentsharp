// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2013
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


using Com.Halfdecent.Numerics;


namespace
Com.Halfdecent.Cursors
{


// =============================================================================
/// TODO
// =============================================================================

public interface
IBidirectionalCursor
    : ICursor
{


/// Try to move the cursor backward a specified number of positions
///
    long
    /// @returns
    /// Actual number of positions moved
TryMoveBack(
    long count
    ///< Number of positions to move
    ///  - <tt>GTE( 1 )</tt>
);



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IBidirectionalCursor.Statics
// -----------------------------------------------------------------------------
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IBidirectionalCursor.Proxy
// -----------------------------------------------------------------------------
public long TryMoveBack( long count) { return this.From.TryMoveBack( count ); }
#endif




} // type
} // namespace

