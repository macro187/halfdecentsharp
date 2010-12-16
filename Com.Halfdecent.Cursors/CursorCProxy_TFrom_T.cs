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


using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Numerics;


namespace
Com.Halfdecent.Cursors
{


public class
CursorCProxy<
    TFrom,
    T
>
    : ICursorC< T >
    where T : TFrom
{



public
CursorCProxy(
    ICursorC< TFrom > from
)
{
    NonNull.CheckParameter( from, "from" );
    this.From = from;
}


protected
    ICursorC< TFrom >
From
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// ICursor
// -----------------------------------------------------------------------------

public bool AtBeginning { get { return this.From.AtBeginning; } }
public bool AtEnd { get { return this.From.AtEnd; } }
public IInteger TryMove( IInteger count) { return this.From.TryMove( count ); }



// -----------------------------------------------------------------------------
// ICursorC
// -----------------------------------------------------------------------------

public void Set( T replacement ) { this.From.Set( replacement ); }




} // type
} // namespace


