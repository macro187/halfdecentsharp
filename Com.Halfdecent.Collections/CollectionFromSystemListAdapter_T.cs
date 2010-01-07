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
/// Present a <tt>System.Collections.Generic.IList<T></tt> as a collection
// =============================================================================

public class
CollectionFromSystemListAdapter<
    T
>
    : IOrderedCollectionCSG< T >
    , ICollectionG< T >
    , ICollection< ITuple< IInteger, T > >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
CollectionFromSystemListAdapter(
    SCG.IList< T >  list
)
{
    //new NonNull().Require( list, new Parameter( "list" ) );
    this.List = list;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

protected
SCG.IList< T >
List
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// IOrderedCollection< T >
// IOrderedCollectionC< T >
// IOrderedCollectionS< T >
// IOrderedCollectionG< T >
// -----------------------------------------------------------------------------



// -----------------------------------------------------------------------------
// IUniqueKeyedCollection< IInteger, T >
// -----------------------------------------------------------------------------

public
    T
Get(
    IInteger key
)
{
    new NonNull().Require( key, new Parameter( "key" ) );
    new ExistingPositionIn< T >( this ).Require( key, new Parameter( "key" ) );
    return this.List[ (int)( key.GetValue() ) ];
}



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionC< IInteger, T >
// -----------------------------------------------------------------------------

public
    void
Replace(
    IInteger    key,
    T           replacement
)
{
    new NonNull().Require( key, new Parameter( "key" ) );
    new ExistingPositionIn< T >( this ).Require( key, new Parameter( "key" ) );
    this.List[ (int)( key.GetValue() ) ] = replacement;
}



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionS< IInteger, T >
// -----------------------------------------------------------------------------

public
    void
Remove(
    IInteger key
)
{
    new NonNull().Require( key, new Parameter( "key" ) );
    new ExistingPositionIn< T >( this ).Require( key, new Parameter( "key" ) );
    this.List.RemoveAt( (int)( key.GetValue() ) );
}



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionG< IInteger, T >
// -----------------------------------------------------------------------------



// -----------------------------------------------------------------------------
// IKeyedCollection< IInteger, T >
// -----------------------------------------------------------------------------

public
    bool
Contains(
    IInteger key
)
{
    new NonNull().Require( key, new Parameter( "key" ) );
    return !(
        key.LT( Integer.From( 0 ) ) ||
        key.GTE( this.Count ) );
}


public
    IStream< T >
GetAll(
    IInteger key
)
{
    return
        KeyedCollection.GetAllViaUniqueKeyedCollection<
            CollectionFromSystemListAdapter< T >,
            IInteger,
            T
        >( this, key );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionC< IInteger, T >
// -----------------------------------------------------------------------------

public
    IFilter< T, T >
GetAndReplaceAll(
    IInteger key
)
{
    return
        KeyedCollection.GetAndReplaceAllViaUniqueKeyedCollection<
            CollectionFromSystemListAdapter< T >,
            IInteger,
            T
        >( this, key );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionS< IInteger, T >
// -----------------------------------------------------------------------------

public
    IStream< T >
GetAndRemoveAll(
    IInteger key
)
{
    return
        KeyedCollection.GetAndRemoveAllViaUniqueKeyedCollection<
            CollectionFromSystemListAdapter< T >,
            IInteger,
            T
        >( this, key );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionG< IInteger, T >
// -----------------------------------------------------------------------------

public
    void
Add(
    IInteger    key,
    T           item
)
{
    new NonNull().Require( key, new Parameter( "key" ) );
    new ExistingOrNextPositionIn< T >( this ).Require(
        key, new Parameter( "key" ) );
    new InInt32Range().Require( key, new Parameter( "key" ) );
    this.List.Insert( (int)( key.GetValue() ), item );
}



// -----------------------------------------------------------------------------
// ICollection< ITuple< IInteger, T > >
// -----------------------------------------------------------------------------

public
IInteger
Count
{
    get { return Integer.From( this.List.Count ); }
}


    IStream< ITuple< IInteger, T > >
ICollection< ITuple< IInteger, T > >.Stream()
{
    return
        this.ICollectionITupleIIntegerTStreamIterator()
        .AsStream();
}

private
    SCG.IEnumerator< ITuple< IInteger, T > >
ICollectionITupleIIntegerTStreamIterator()
{
    for( int i = 0; i < this.List.Count; i++ )
        yield return new Tuple< IInteger, T >(
            Integer.From( i ),
            this.List[ i ] );
}



// -----------------------------------------------------------------------------
// ICollectionC< ITuple< IInteger, T > >
// -----------------------------------------------------------------------------

/// (See <tt>ICollectionC< T >.GetAndReplaceAll()</tt>)
///
/// Replacement keys are ignored; Replacements are added under the same key as
/// the items they replace.
///
public
    IFilter< ITuple< IInteger, T >, ITuple< IInteger, T > >
GetAndReplaceAll(
    Func< ITuple< IInteger, T >, bool > where
)
{
    new NonNull().Require( where, new Parameter( "where" ) );
    return
        TupleCollection.GetAndReplaceAllViaUniqueKeyedCollection<
            CollectionFromSystemListAdapter< T >,
            IInteger,
            T
        >( this, where );
}



// -----------------------------------------------------------------------------
// ICollectionS< ITuple< IInteger, T > >
// -----------------------------------------------------------------------------

public
    IStream< ITuple< IInteger, T > >
GetAndRemoveAll(
    Func< ITuple< IInteger, T >, bool > where
)
{
    new NonNull().Require( where, new Parameter( "where" ) );
    return
        TupleCollection.GetAndRemoveAllViaUniqueKeyedCollection<
            CollectionFromSystemListAdapter< T >,
            IInteger,
            T
        >( this, where );
}



// -----------------------------------------------------------------------------
// ICollectionG< ITuple< IInteger, T > >
// -----------------------------------------------------------------------------

public
    void
Add(
    ITuple< IInteger, T > item
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
        Collection.StreamViaTupleCollection<
            //CollectionFromSystemListAdapter< T >,
            IInteger,
            T
        >( this );
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
    // TODO canned
    new NonNull().Require( where, new Parameter( "where" ) );
    return new Filter< T, T >(
        ( get, set, drop ) =>
            this.GetAndReplaceAllFilter( where, get, set, drop ) );
}


private
    SCG.IEnumerator< bool >
GetAndReplaceAllFilter(
    Func< T, bool > where,
    Func< T >       get,
    Func< T, Void > put,
    Func< T, Void > drop
)
{
    for( int i = 0; i < this.List.Count; i++ ) {
        T item = this.List[ i ];
        if( !where( item ) ) continue;
        yield return false;
        this.List[ i ] = get();
        put( item );
        yield return true;
    }
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
    // TODO canned
    return
        this.GetAndRemoveAllStream( where )
        .AsStream();
}


private
    SCG.IEnumerable< T >
GetAndRemoveAllStream(
    Func< T, bool > where
)
{
    for( int i = this.List.Count-1; i >= 0; i-- ) {
        T item = this.List[ i ];
        if( !where( item ) ) continue;
        this.List.RemoveAt( i );
        yield return item;
    }
}



// -----------------------------------------------------------------------------
// ICollectionG< T >
// -----------------------------------------------------------------------------

public
    void
Add(
    T item
)
{
    this.List.Add( item );
}




//private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

