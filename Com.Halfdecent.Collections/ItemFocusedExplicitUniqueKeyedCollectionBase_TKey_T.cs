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
ItemFocusedExplicitUniqueKeyedCollectionBase<
    TKey,
    T
>
    : ItemFocusedExplicitKeyedCollectionBase< TKey, T >
    , IUniqueKeyedCollectionCSG< TKey, T >
    , ICollectionC< T >
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
// IUniqueKeyedCollectionC< IInteger, T >
// -----------------------------------------------------------------------------

public abstract
    T
GetAndReplace(
    TKey    key,
    T       replacement
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
// IUniqueKeyedCollectionG< IInteger, T >
// -----------------------------------------------------------------------------



// -----------------------------------------------------------------------------
// IKeyedCollection< TKey, T >
// -----------------------------------------------------------------------------

public override
    IStream< T >
GetAll(
    TKey key
)
{
    new NonNull().Require( key, new Parameter( "key" ) );
    return
        this.Contains( key )
            ? new Stream< T >( this.Get( key ) )
            : new Stream< T >();
}



// -----------------------------------------------------------------------------
// IKeyedCollectionC< TKey, T >
// -----------------------------------------------------------------------------

public override
    IFilter< T, T >
GetAndReplaceAll(
    TKey key
)
{
    return new Filter< T, T >(
        ( get, put, drop ) =>
            this.GetAndReplaceAllFilter( key, get, put, drop ) );
}

protected
    SCG.IEnumerator< bool >
GetAndReplaceAllFilter(
    TKey            key,
    Func< T >       get,
    Action< T >     put,
    Action< T >     drop
)
{
    if( !this.Contains( key ) ) yield break;
    yield return false;
    put( this.GetAndReplace( key, get() ) );
    yield return true;
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
        this.GetAndRemoveAllIterator( key )
        .AsStream();
}

protected
    SCG.IEnumerator< T >
GetAndRemoveAllIterator(
    TKey key
)
{
    if( !this.Contains( key ) ) yield break;
    yield return this.GetAndRemove( key );
}



// -----------------------------------------------------------------------------
// ICollectionC< ITuple< TKey, T > >
// -----------------------------------------------------------------------------

public override
    IFilter< ITuple< TKey, T >, ITuple< TKey, T > >
GetAndReplaceAll(
    Func< ITuple< TKey, T >, bool > where
)
{
    new NonNull().Require( where, new Parameter( "where" ) );
    return
        new Filter< ITuple< TKey, T >, ITuple< TKey, T > >(
            ( get, put, drop ) =>
                this.GetAndReplaceAllFilter( where, get, put, drop ) );
}

protected
    SCG.IEnumerator< bool >
GetAndReplaceAllFilter(
    Func< ITuple< TKey, T >, bool > where,
    Func< ITuple< TKey, T > >       get,
    Action< ITuple< TKey, T > >     put,
    Action< ITuple< TKey, T > >     drop
)
{
    // XXX This algorithm assumes that .GetAndReplace() does not interfere
    //     with .StreamKeys()
    foreach( TKey key in this.StreamKeys().AsEnumerable() ) {
        ITuple< TKey, T > old = new Tuple< TKey, T >( key, this.Get( key ) );
        if( !where( old ) ) continue;
        yield return false;
        // TODO Change to .Replace() when it appears
        this.GetAndReplace( key, get().B );
        put( old );
        yield return true;
    }
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
    new NonNull().Require( where, new Parameter( "where" ) );
    return this.GetAndRemoveAllIterator( where ).AsStream();
}

protected
    SCG.IEnumerator< ITuple< TKey, T > >
GetAndRemoveAllIterator(
    Func< ITuple< TKey, T >, bool > where
)
{
    startover:
    foreach( TKey key in this.StreamKeys().AsEnumerable() ) {
        ITuple< TKey, T > old = new Tuple< TKey, T >( key, this.Get( key ) );
        if( !where( old ) ) continue;
        // TODO Use .Remove() when it appears
        this.GetAndRemove( key );
        yield return old;
        goto startover;
    }
}



// -----------------------------------------------------------------------------
// ICollectionC< T >
// -----------------------------------------------------------------------------

public
    IFilter< T, T >
GetAndReplaceAll(
    Func< T, bool > where
)
{
    new NonNull().Require( where, new Parameter( "where" ) );
    return
        new Filter< T, T >(
            ( get, put, drop ) =>
                this.GetAndReplaceAllFilter( where, get, put, drop ) );
}

protected
    SCG.IEnumerator< bool >
GetAndReplaceAllFilter(
    Func< T, bool > where,
    Func< T >       get,
    Action< T >     put,
    Action< T >     drop
)
{
    // XXX This algorithm assumes that .GetAndReplace() does not interfere
    //     with .StreamKeys()
    foreach( TKey key in this.StreamKeys().AsEnumerable() ) {
        T old = this.Get( key );
        if( !where( old ) ) continue;
        yield return false;
        // TODO Change to .Replace() when it appears
        this.GetAndReplace( key, get() );
        put( old );
        yield return true;
    }
}




//private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

