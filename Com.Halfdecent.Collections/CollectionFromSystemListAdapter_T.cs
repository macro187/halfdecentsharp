// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2012
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


namespace
Com.Halfdecent.Collections
{


// =============================================================================
/// Present a <tt>System.Collections.Generic.IList< T ></tt> as an
/// <tt>IOrderedCollectionRCSG< T ></tt>
// =============================================================================

public partial class
CollectionFromSystemListAdapter<
    T
>
    : IOrderedCollectionRCSG< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
CollectionFromSystemListAdapter(
    SCG.IList< T > from
)
{
    NonNull.CheckParameter( from, "from" );
    this.From = from;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

protected
SCG.IList< T >
From
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionC< T >
// -----------------------------------------------------------------------------

public
    void
Replace(
    IInteger    key,
    T           replacement
)
{
    NonNull.CheckParameter( key, "key" );
    ExistingKeyIn.CheckParameter( this, key, "key" );
    int i = (int)( key.GetValue() );
    this.From[ i ] = replacement;
}



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionR< IInteger, T >
// -----------------------------------------------------------------------------

public
    T
Get(
    IInteger key
)
{
    NonNull.CheckParameter( key, "key" );
    ExistingKeyIn.CheckParameter( this, key, "key" );
    int i = (int)( key.GetValue() );
    return this.From[ i ];
}



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionS< T >
// -----------------------------------------------------------------------------

public
    void
Remove(
    IInteger key
)
{
    NonNull.CheckParameter( key, "key" );
    ExistingKeyIn.CheckParameter( this, key, "key" );
    int i = (int)( key.GetValue() );
    this.From.RemoveAt( i );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionS< IInteger >
// -----------------------------------------------------------------------------

public
    void
RemoveAll(
    IInteger key
)
{
    this.Remove( key );
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
    NonNull.CheckParameter( key, "key" );
    ExistingOrNextPositionIn.CheckParameter( this, key, "key" );
    InInt32Range.CheckParameter( key, "key" );
    int i = (int)( key.GetValue() );
    this.From.Insert( i, item );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionRC< IInteger, T >
// -----------------------------------------------------------------------------

public
    IFilter< T, T >
GetAndReplaceAll(
    IInteger key
)
{
    return KeyedCollection
        .GetAndReplaceAllViaUniqueKeyedCollection( this, key );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionRS< IInteger, T >
// -----------------------------------------------------------------------------

public
    IStream< T >
GetAndRemoveAll(
    IInteger key
)
{
    return KeyedCollection
        .GetAndRemoveAllViaUniqueKeyedCollection( this, key );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionR< IInteger, T >
// -----------------------------------------------------------------------------

public
    IStream< ITupleHD< IInteger, T > >
StreamPairs()
{
    return this.StreamPairsIterator().AsStream();
}

private
    SCG.IEnumerator< ITupleHD< IInteger, T > >
StreamPairsIterator()
{
    for( int i = 0; i < this.From.Count; i++ ) {
        yield return TupleHD.Create( Integer.Create( i ), this.From[ i ] );
    }
}


public
    bool
Contains(
    IInteger key
)
{
    if( key == null ) return false;
    if( key.LT( Integer.Create( 0 ) ) ) return false;
    if( key.GTE( Integer.Create( this.From.Count ) ) ) return false;
    return true;
}


public
    IStream< T >
Stream(
    IInteger key
)
{
    return KeyedCollection.StreamViaUniqueKeyedCollection( this, key );
}



// -----------------------------------------------------------------------------
// ICollection
// -----------------------------------------------------------------------------

public
    IInteger
Count
{
    get { return Integer.Create( this.From.Count ); }
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
    this.From.Add( item );
}



// -----------------------------------------------------------------------------
// ICollectionRC< T >
// -----------------------------------------------------------------------------

public
    IFilter< T, T >
GetAndReplaceWhere(
    Predicate< T > where
)
{
    return Collection.GetAndReplaceWhereViaUniqueKeyedCollection( this, where );
}



// -----------------------------------------------------------------------------
// ICollectionRS< T >
// -----------------------------------------------------------------------------

public
    IStream< T >
GetAndRemoveWhere(
    Predicate< T > where
)
{
    return Collection.GetAndRemoveWhereViaUniqueKeyedCollection( this, where );
}



// -----------------------------------------------------------------------------
// ICollectionR< T >
// -----------------------------------------------------------------------------

public
    IStream< T >
Stream()
{
    return Collection.StreamViaKeyedCollection( this );
}




} // type
} // namespace

