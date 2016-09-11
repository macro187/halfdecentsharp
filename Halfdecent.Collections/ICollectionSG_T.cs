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
/// A shrinkable, growable collection
// =============================================================================

public interface
ICollectionSG<
#if DOTNET40
    in T
#else
    T
#endif
>
    : ICollectionS
    , ICollectionG< T >
{



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait ICollectionSG.Statics
// -----------------------------------------------------------------------------

public static
    ICollectionSG< T >
Contravary<
    TFrom,
    T
>(
    this ICollectionSG< TFrom > from
)
    where T : TFrom
{
    return new CollectionSGProxy< TFrom, T >( from );
}
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait ICollectionSG.Proxy
// -----------------------------------------------------------------------------
#endif




} // type
} // namespace
