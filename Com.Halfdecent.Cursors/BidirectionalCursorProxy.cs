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


public class
BidirectionalCursorProxy
    : CursorProxy
    , IBidirectionalCursor
    , IProxy
{



public
BidirectionalCursorProxy(
    IBidirectionalCursor from
)
    : base( from )
{
    this.From = from;
}


new protected
    IBidirectionalCursor
From
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// IBidirectionalCursor
// -----------------------------------------------------------------------------

public IInteger TryMoveBack( IInteger count) { return this.From.TryMoveBack( count ); }



// -----------------------------------------------------------------------------
// IProxy
// -----------------------------------------------------------------------------

    object
IProxy.Underlying
{
    get { return this.From; }
}




} // type
} // namespace

