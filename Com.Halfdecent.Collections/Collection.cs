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
using System.Linq;
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
/// <tt>ICollection< T ></tt> library
// =============================================================================

public static class
Collection
{



// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// <tt>ICollectionC< T >.Stream()</tt>
/// via
/// <tt>ICollection< ITuple< TKey, T > >.Stream()</tt>
///
public static
    IStream< T >
StreamViaTupleCollection<
//    TCollection,
    TKey,
    T
>(
//    TCollection col
    ICollection< ITuple< TKey, T > > col
)
//
// XXX  Constrained type parameter doesn't work, but plain parameter of exact
//      same type work?  WTF?
//
//      error CS0309: The type
//      `Com.Halfdecent.Collections.CollectionFromSystemListAdapter<T>'
//      must be convertible to
//      `Com.Halfdecent.Collections.ICollection<Com.Halfdecent.ITuple<TKey,T>>'
//      in order to use it as parameter `TCollection' in the generic type or
//      method
//      `Com.Halfdecent.Collections.Collection
//          .StreamViaTupleCollection<TCollection,TKey,T>(TCollection)'
//
//    where TCollection : ICollection< ITuple< TKey, T > >
{
    new NonNull().Require( col, new Parameter( "col" ) );
    return
        col.Stream()
        .AsEnumerable()
        .Select( t => t.B )
        .AsStream();
}




} // type
} // namespace

