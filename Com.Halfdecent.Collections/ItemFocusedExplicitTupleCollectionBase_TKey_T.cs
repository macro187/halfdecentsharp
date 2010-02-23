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


using System;
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
/// TODO
// =============================================================================

public abstract class
ItemFocusedExplicitTupleCollectionBase<
    TKey,
    T
>
    : IKeyValueCollectionCSG< TKey, T >
{



// -----------------------------------------------------------------------------
// ICollection< ITuple< TKey, T > >
// -----------------------------------------------------------------------------

public abstract
IInteger
Count
{
    get;
}


    IStream< ITuple< TKey, T > >
ICollection< ITuple< TKey, T > >.Stream()
{
    return this.TupleStream();
}

protected abstract
    IStream< ITuple< TKey, T > >
TupleStream();



// -----------------------------------------------------------------------------
// ICollectionC< ITuple< TKey, T > >
// -----------------------------------------------------------------------------

public abstract
    IFilter< ITuple< TKey, T >, ITuple< TKey, T > >
GetAndReplaceAll(
    Predicate< ITuple< TKey, T > > where
);



// -----------------------------------------------------------------------------
// ICollectionS< ITuple< TKey, T > >
// -----------------------------------------------------------------------------

public abstract
    IStream< ITuple< TKey, T > >
GetAndRemoveAll(
    Predicate< ITuple< TKey, T > > where
);



// -----------------------------------------------------------------------------
// ICollectionG< ITuple< TKey, T > >
// -----------------------------------------------------------------------------

public abstract
    void
Add(
    ITuple< TKey, T > item
);



// -----------------------------------------------------------------------------
// ICollection< T >
// -----------------------------------------------------------------------------


public
    IStream< T >
Stream()
{
    return Collection.StreamViaTupleCollection< TKey, T >( this );
}



// -----------------------------------------------------------------------------
// ICollectionS< T >
// -----------------------------------------------------------------------------

public
    IStream< T >
GetAndRemoveAll(
    Predicate< T > where
)
{
    return
        Collection.GetAndRemoveAllViaTupleCollection< TKey, T >( this, where );
}




//private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace
