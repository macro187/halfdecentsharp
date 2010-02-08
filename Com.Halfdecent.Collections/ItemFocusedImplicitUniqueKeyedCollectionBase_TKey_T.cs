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
// TODO
// =============================================================================

public abstract class
ItemFocusedImplicitUniqueKeyedCollectionBase<
    TKey,
    T
>
    : ItemFocusedImplicitKeyedCollectionBase< TKey, T >
    , IUniqueKeyedCollectionS< TKey, T >
{



// -----------------------------------------------------------------------------
// IUniqueKeyedCollection< IInteger, T >
// -----------------------------------------------------------------------------

public abstract
    T
Get(
    TKey key
);



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionS< IInteger, T >
// -----------------------------------------------------------------------------

public abstract
    T
GetAndRemove(
    TKey key
);



// -----------------------------------------------------------------------------
// IKeyedCollection< TKey, T >
// -----------------------------------------------------------------------------

public override
    IStream< T >
GetAll(
    TKey key
)
{
    return KeyedCollection.GetAllViaUniqueKeyedCollection( this, key );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionS< TKey, T >
// -----------------------------------------------------------------------------

public override
    IStream< T >
GetAndRemoveAll(
    TKey key
)
{
    return
        KeyedCollection.GetAndRemoveAllViaUniqueKeyedCollection( this, key );
}



// -----------------------------------------------------------------------------
// ICollectionS< ITuple< TKey, T > >
// -----------------------------------------------------------------------------

public override
    IStream< ITuple< TKey, T > >
GetAndRemoveAll(
    Func< ITuple< TKey, T >, bool > where
)
{
    return
        TupleCollection.GetAndRemoveAllViaUniqueKeyedCollection( this, where );
}



// -----------------------------------------------------------------------------
// ICollectionC< T >
// -----------------------------------------------------------------------------

public override
    IFilter< T, T >
GetAndReplaceAll(
    Func< T, bool > where
)
{
    return Collection.GetAndReplaceAllViaUniqueKeyedCollection<
        ItemFocusedImplicitUniqueKeyedCollectionBase< TKey, T >, TKey, T >(
        this, where );
}




//private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

