// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2012, 2013
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
using Halfdecent;
using Halfdecent.Meta;
using Halfdecent.RTypes;
using Halfdecent.Streams;
using Halfdecent.Numerics;


namespace
Halfdecent.Collections
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
    long    key,
    T       replacement
)
{
    ExistingKeyIn.CheckParameter( this, key, "key" );
    int i = (int)key;
    this.From[ i ] = replacement;
}



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionR< long, T >
// -----------------------------------------------------------------------------

public
    T
Get(
    long key
)
{
    ExistingKeyIn.CheckParameter( this, key, "key" );
    int i = (int)key;
    return this.From[ i ];
}



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionS< T >
// -----------------------------------------------------------------------------

public
    void
Remove(
    long key
)
{
    ExistingKeyIn.CheckParameter( this, key, "key" );
    int i = (int)key;
    this.From.RemoveAt( i );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionS< long >
// -----------------------------------------------------------------------------

public
    void
RemoveAll(
    long key
)
{
    this.Remove( key );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionG< long, T >
// -----------------------------------------------------------------------------

public
    void
Add(
    long    key,
    T       item
)
{
    ExistingOrNextPositionIn.CheckParameter( this, key, "key" );
    InInt32Range.CheckParameter( Real.Create( key ), "key" );
    int i = (int)key;
    this.From.Insert( i, item );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionRC< long, T >
// -----------------------------------------------------------------------------

public
    IFilter< T, T >
GetAndReplaceAll(
    long key
)
{
    return KeyedCollection
        .GetAndReplaceAllViaUniqueKeyedCollection( this, key );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionRS< long, T >
// -----------------------------------------------------------------------------

public
    IStream< T >
GetAndRemoveAll(
    long key
)
{
    return KeyedCollection
        .GetAndRemoveAllViaUniqueKeyedCollection( this, key );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionR< long, T >
// -----------------------------------------------------------------------------

public
    IStream< ITupleHD< long, T > >
StreamPairs()
{
    return this.StreamPairsIterator().AsStream();
}

private
    SCG.IEnumerator< ITupleHD< long, T > >
StreamPairsIterator()
{
    for( int i = 0; i < this.From.Count; i++ ) {
        yield return TupleHD.Create( (long)i, this.From[ i ] );
    }
}


public
    bool
Contains(
    long key
)
{
    if( key < 0 ) return false;
    if( key >= this.From.Count ) return false;
    return true;
}


public
    IStream< T >
Stream(
    long key
)
{
    return KeyedCollection.StreamViaUniqueKeyedCollection( this, key );
}



// -----------------------------------------------------------------------------
// ICollection
// -----------------------------------------------------------------------------

public
    long
Count
{
    get { return this.From.Count; }
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

