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
ICursorG<
#if DOTNET40
    in T
#else
    T
#endif
>
    : ICursor
{


/// Insert a new item <em>after</em> the item the cursor points to
///
/// If the cursor is <tt>AtBeginning</tt>, the new item will be inserted at the
/// beginning of the sequence.
///
/// If the cursor points to the last item or is <tt>AtEnd</tt>, the new item
/// will be appended to the end of the sequence.
///
/// Following this operation, the cursor points to the newly-inserted item.
///
    void
Insert(
    T replacement
);



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait ICursorG.Statics
// -----------------------------------------------------------------------------
public static
    ICursorG< T >
Contravary<
    TFrom,
    T
>(
    this ICursorG< TFrom > from
)
    where T : TFrom
{
    return new CursorGProxy< TFrom, T >( from );
}
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait ICursorG.Proxy
// -----------------------------------------------------------------------------
public void Insert( T replacement ) { this.From.Insert( replacement ); }
#endif




} // type
} // namespace

