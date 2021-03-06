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


using Halfdecent.Streams;


namespace
Halfdecent.Collections
{


// =============================================================================
/// TODO
// =============================================================================

public interface
IKeyedCollectionRC<
    TKey,
    T
>
    : IKeyedCollectionR< TKey, T >
    , IKeyedCollectionC< TKey, T >
    , ICollectionRC< T >
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Generate a filter that replaces any items with the specified key while
/// passing along the replaced items
///
    IFilter< T, T >
GetAndReplaceAll(
    TKey key
);



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IKeyedCollectionRC.Statics
// -----------------------------------------------------------------------------
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IKeyedCollectionRC.Proxy
// -----------------------------------------------------------------------------

public IFilter< T, T >
    GetAndReplaceAll( TKey key ) {
        return this.From.GetAndReplaceAll( key ); }
#endif




} // type
} // namespace

