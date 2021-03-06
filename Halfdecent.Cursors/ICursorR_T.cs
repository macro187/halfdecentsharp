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
ICursorR<
#if DOTNET40
    out T
#else
    T
#endif
>
    : ICursor
{


/// Retrieve the item the cursor points to
///
/// @exception System.InvalidOperationException
/// The cursor is <tt>AtBeginning</tt> or <tt>AtEnd</tt>
///
    T
Get();



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait ICursorR.Statics
// -----------------------------------------------------------------------------
public static
    ICursorR< T >
Covary<
    TFrom,
    T
>(
    this ICursorR< TFrom > from
)
    where TFrom : T
{
    return new CursorRProxy< TFrom, T >( from );
}
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait ICursorR.Proxy
// -----------------------------------------------------------------------------
public T Get() { return this.From.Get(); }
#endif




} // type
} // namespace

