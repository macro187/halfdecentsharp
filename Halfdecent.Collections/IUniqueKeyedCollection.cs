// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010, 2012
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
using SCG = System.Collections.Generic;


namespace
Halfdecent.Collections
{


// =============================================================================
/// Access items in a collection by a key value
// =============================================================================

public interface
IUniqueKeyedCollection
    : IKeyedCollection
{



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IUniqueKeyedCollection.Statics
// -----------------------------------------------------------------------------

public static
    IUniqueKeyedCollectionRCSG< TKey, T >
Create<
    TKey,
    T
>(
    IStream< ITupleHD< TKey, T > > items
)
{
    items = items ?? Stream.Create< ITupleHD< TKey, T > >();
    var dict = new SCG.Dictionary< TKey, T >();
    foreach( var tuple in items.AsEnumerable() )
        dict.Add( tuple.A, tuple.B );
    return dict.AsHalfdecentCollection();
}

#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IUniqueKeyedCollection.Proxy
// -----------------------------------------------------------------------------
#endif




} // type
} // namespace

