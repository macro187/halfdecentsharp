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
/// TODO
// =============================================================================

public partial interface
IOrderedCollectionCS<
#if DOTNET40
    in T
#else
    T
#endif
>
    : IOrderedCollectionC< T >
    , IOrderedCollectionS
    , IUniqueKeyedCollectionCS< long, T >
{



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionCS.Statics
// -----------------------------------------------------------------------------

public static
    IOrderedCollectionCS< T >
Contravary<
    TFrom,
    T
>(
    this IOrderedCollectionCS< TFrom > from
)
    where T : TFrom
{
    return new OrderedCollectionCSProxy< TFrom, T >( from );
}
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionCS.Proxy
// -----------------------------------------------------------------------------
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionCS< T >.IndexSlice
// -----------------------------------------------------------------------------
#endif




} // type
} // namespace

