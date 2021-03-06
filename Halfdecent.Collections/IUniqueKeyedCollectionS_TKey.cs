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

public interface
IUniqueKeyedCollectionS<
#if DOTNET40
    in TKey
#else
    TKey
#endif
>
    : IUniqueKeyedCollection
    , IKeyedCollectionS< TKey >
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Remove the item with a specified key
///
    void
Remove(
    TKey key
    ///< Key of item to remove
    ///  - <tt>ExistingKeyIn( this )</tt>
);



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IUniqueKeyedCollectionS.Statics
// -----------------------------------------------------------------------------

public static
    IUniqueKeyedCollectionS< TKey >
Contravary<
    TKeyFrom,
    TKey
>(
    this IUniqueKeyedCollectionS< TKeyFrom > from
)
    where TKey : TKeyFrom
{
    return new UniqueKeyedCollectionSProxy< TKeyFrom, TKey >( from );
}
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IUniqueKeyedCollectionS.Proxy
// -----------------------------------------------------------------------------

public void Remove( TKey key ) { this.From.Remove( key ); }
#endif




} // type
} // namespace

