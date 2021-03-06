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


namespace
Halfdecent.Cursors
{


public interface
IBidirectionalCursorC<
#if DOTNET40
    in T
#else
    T
#endif
>
    : ICursorC< T >
    , IBidirectionalCursor
{



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IBidirectionalCursorC.Statics
// -----------------------------------------------------------------------------
public static
    IBidirectionalCursorC< T >
Contravary<
    TFrom,
    T
>(
    this IBidirectionalCursorC< TFrom > from
)
    where T : TFrom
{
    return new BidirectionalCursorCProxy< TFrom, T >( from );
}
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IBidirectionalCursorC.Proxy
// -----------------------------------------------------------------------------
#endif




} // type
} // namespace

