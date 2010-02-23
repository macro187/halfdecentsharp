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
TupleFocusedImplicitKeyedCollectionBase<
    TKey,
    T
>
    : TupleFocusedImplicitTupleCollectionBase< TKey, T >
    , IKeyedCollectionS< TKey, T >
{



// -----------------------------------------------------------------------------
// IKeyedCollection< TKey, T >
// -----------------------------------------------------------------------------

public abstract
    IStream< TKey >
StreamKeys();


public abstract
    bool
Contains(
    TKey key
);


public abstract
    IStream< T >
GetAll(
    TKey key
);



// -----------------------------------------------------------------------------
// IKeyedCollectionS< TKey, T >
// -----------------------------------------------------------------------------

public abstract
    IStream< T >
GetAndRemoveAll(
    TKey key
);



// -----------------------------------------------------------------------------
// ICollection< ITuple< TKey, T > >
// -----------------------------------------------------------------------------

public override
    IStream< ITuple< TKey, T > >
Stream()
{
    return TupleCollection.StreamViaKeyedCollection( this );
}







//private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace
