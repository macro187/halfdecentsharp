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
Com.Halfdecent.Collections
{


// =============================================================================
/// TODO
// =============================================================================

public interface
IUniqueKeyedCollectionRSG<
    TKey,
    T
>
    : IUniqueKeyedCollectionRS< TKey, T >
    , IUniqueKeyedCollectionRG< TKey, T >
    , IUniqueKeyedCollectionSG< TKey, T >
    , IKeyedCollectionRSG< TKey, T >
{



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IUniqueKeyedCollectionRSG.Statics
// -----------------------------------------------------------------------------

public static
    IImplicitUniqueKeyedCollectionRSG< TKey, T >
AsImplicitUniqueKeyedCollection<
    TKey,
    T
>(
    this IUniqueKeyedCollectionRSG< TKey, T >   from,
    System.Func< T, TKey >                      extractKeyFunc
)
{
    return
        new ImplicitUniqueKeyedCollectionFromUniqueKeyedCollectionAdapter<
            TKey, T >( from, extractKeyFunc );
}
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IUniqueKeyedCollectionRSG.Proxy
// -----------------------------------------------------------------------------
#endif




} // type
} // namespace

