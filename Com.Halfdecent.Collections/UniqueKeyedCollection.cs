// -----------------------------------------------------------------------------
// Copyright (c) 2009
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


using SCG = System.Collections.Generic;
using System;
using Com.Halfdecent;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Numerics;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Filters;


namespace
Com.Halfdecent.Collections
{


// =============================================================================
/// <tt>IUniqueKeyedCollection< T ></tt> library
// =============================================================================

public static class
UniqueKeyedCollection
{



// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// <tt>IUniqueKeyedCollectionC< TKey, T >.TryGetAndReplace()</tt>
/// via
/// <tt>IKeyedCollectionC< TKey, T >.GetAndReplaceAll()</tt>
///
public static
    bool
TryGetAndReplaceViaKeyedCollection<
    TCollection,
    TKey,
    T
>(
    TCollection col,
    TKey        key,
    T           replacement,
    out T       replaced
)
    where TCollection : IKeyedCollectionC< TKey, T >
{
    new NonNull().Require( col, new Parameter( "col" ) );
    IFilter< T, T > f = col.GetAndReplaceAll( key );
    f.From = new Stream< T >( replacement );
    return f.TryPull( out replaced );
}




} // type
} // namespace

