// -----------------------------------------------------------------------------
// Copyright (c) 2010
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
ICursor
{


/// Is the cursor positioned at the beginning?
///
/// The "beginning" is just before the first item (if one exists).  When in
/// this position, the cursor is not pointing to an item, so <tt>.Get()</tt>
/// and <tt>.Set()</tt> cannot be used.
///
    bool
AtBeginning
{
    get;
}


/// Is the cursor positioned at the end?
///
/// The "end" is just after the last item (if one exists).  When in
/// this position, the cursor is not pointing to an item, so <tt>.Get()</tt>
/// and <tt>.Set()</tt> cannot be used.
///
    bool
AtEnd
{
    get;
}


/// Try to move the cursor forward a specified number of positions
///
    IInteger
    /// @returns
    /// Actual number of positions moved
TryMove(
    IInteger count
    ///< Number of positions to move
    ///  - <tt>GTE( 1 )</tt>
);



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait ICursor.Statics
// -----------------------------------------------------------------------------
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait ICursor.Proxy
// -----------------------------------------------------------------------------
public bool AtBeginning { get { return this.From.AtBeginning; } }
public bool AtEnd { get { return this.From.AtEnd; } }
public IInteger TryMove( IInteger count) { return this.From.TryMove( count ); }
#endif




} // type
} // namespace

