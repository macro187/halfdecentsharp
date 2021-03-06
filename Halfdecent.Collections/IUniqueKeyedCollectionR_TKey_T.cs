// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010
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
Halfdecent.Collections
{


// =============================================================================
/// Access items in a collection by a key value
// =============================================================================

public interface
IUniqueKeyedCollectionR<
#if DOTNET40
    TKey,
    out T
#else
    TKey,
    T
#endif
>
    : IUniqueKeyedCollection
    , IKeyedCollectionR< TKey, T >
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Retrieve the item with the given key
///
    T
Get(
    TKey key
);



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IUniqueKeyedCollectionR.Statics
// -----------------------------------------------------------------------------

public static
    IUniqueKeyedCollectionR< TKey, T >
Covary<
    TFrom,
    TKey,
    T
>(
    this IUniqueKeyedCollectionR< TKey, TFrom > from
)
    where TFrom : T
{
    return new UniqueKeyedCollectionRProxy< TFrom, TKey, T >( from );
}
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IUniqueKeyedCollectionR.Proxy
// -----------------------------------------------------------------------------

public T Get( TKey key ) { return this.From.Get( key ); }
#endif




} // type
} // namespace

