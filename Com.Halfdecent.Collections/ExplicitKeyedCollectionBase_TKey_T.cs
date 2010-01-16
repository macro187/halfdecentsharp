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
// Base class for implementing keyed collections where keys must be specified
// when adding items
// =============================================================================

public abstract class
ExplicitKeyedCollectionBase<
    TKey,
    T
>
    : IKeyedCollectionCSG< TKey, T >
    // TODO more?
{



// -----------------------------------------------------------------------------
// IKeyedCollection< TKey, T >
// -----------------------------------------------------------------------------

public
    IStream< TKey >
StreamKeys()
{
    return
        this.StreamKeysIterator()
        .AsStream();
}

protected abstract
    SCG.IEnumerator< TKey >
StreamKeysIterator();


public abstract
    bool
Contains(
    TKey key
);


public
    IStream< T >
GetAll(
    TKey key
)
{
    return
        this.GetAllIterator( key )
        .AsStream();
}

protected abstract
    SCG.IEnumerator< T >
GetAllIterator(
    TKey key
);



// -----------------------------------------------------------------------------
// IKeyedCollectionC< TKey, T >
// -----------------------------------------------------------------------------

public
    IFilter< T, T >
GetAndReplaceAll(
    TKey key
)
{
    return new Filter< T, T >(
        ( get, put, drop ) =>
            this.GetAndReplaceAllFilter( key, get, put, drop ) );
}

protected abstract
    SCG.IEnumerator< bool >
GetAndReplaceAllFilter(
    TKey            key,
    Func< T >       get,
    Action< T >     put,
    Action< T >     drop
);



// -----------------------------------------------------------------------------
// IKeyedCollectionS< TKey, T >
// -----------------------------------------------------------------------------

public
    IStream< T >
GetAndRemoveAll(
    TKey key
)
{
    return
        this.GetAndRemoveAllIterator( key )
        .AsStream();
}

protected abstract
    SCG.IEnumerator< T >
GetAndRemoveAllIterator(
    TKey key
);



// -----------------------------------------------------------------------------
// IKeyedCollectionG< TKey, T >
// -----------------------------------------------------------------------------

public abstract
    void
Add(
    TKey    key,
    T       item
);



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
    return
        this.StreamKeys()
        .AsEnumerable()
        .Aggregate(
            new Stream< ITuple< TKey, T > >().AsEnumerable(),
            ( s, key ) =>
                s.Concat(
                    this.GetAll( key )
                    .AsEnumerable()
                    .Select(
                        item => ((ITuple< TKey, T >)
                            new Tuple< TKey, T >( key, item ) ) ) ) )
        .AsStream();
}



// -----------------------------------------------------------------------------
// ICollectionC< ITuple< TKey, T > >
// -----------------------------------------------------------------------------

public
    IFilter< ITuple< TKey, T >, ITuple< TKey, T > >
GetAndReplaceAll(
    Func< ITuple< TKey, T >, bool > where
)
{
    new NonNull().Require( where, new Parameter( "where" ) );
    return
        new Filter< ITuple< TKey, T >, ITuple< TKey, T > >(
            ( get, put, drop ) =>
                this.TupleGetAndReplaceAllFilter( where, get, put, drop ) );
}

protected abstract
    SCG.IEnumerator< bool >
TupleGetAndReplaceAllFilter(
    Func< ITuple< TKey, T >, bool > where,
    Func< ITuple< TKey, T > >       get,
    Action< ITuple< TKey, T > >     put,
    Action< ITuple< TKey, T > >     drop
);



// -----------------------------------------------------------------------------
// ICollectionS< ITuple< TKey, T > >
// -----------------------------------------------------------------------------

public
    IStream< ITuple< TKey, T > >
GetAndRemoveAll(
    Func< ITuple< TKey, T >, bool > where
)
{
    new NonNull().Require( where, new Parameter( "where" ) );
    return
        this.GetAndRemoveAllIterator( where )
        .AsStream();
}

protected abstract
    SCG.IEnumerator< ITuple< TKey, T > >
GetAndRemoveAllIterator(
    Func< ITuple< TKey, T >, bool > where
);



// -----------------------------------------------------------------------------
// ICollectionG< ITuple< TKey, T > >
// -----------------------------------------------------------------------------

public
    void
Add(
    ITuple< TKey, T > item
)
{
    new NonNull().Require( item, new Parameter( "item" ) );
    this.Add( item.A, item.B );
}



// -----------------------------------------------------------------------------
// ICollection< T >
// -----------------------------------------------------------------------------

public
    IStream< T >
Stream()
{
    return
        ( (ICollection< ITuple< TKey, T > >) this ).Stream()
        .AsEnumerable()
        .Select( t => t.B )
        .AsStream();
}



// -----------------------------------------------------------------------------
// ICollectionS< T >
// -----------------------------------------------------------------------------

public
    IStream< T >
GetAndRemoveAll(
    Func< T, bool > where
)
{
    new NonNull().Require( where, new Parameter( "where" ) );
    return
        this.GetAndRemoveAll( t => where( t.B ) )
        .AsEnumerable()
        .Select( t => t.B )
        .AsStream();
}




//private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

