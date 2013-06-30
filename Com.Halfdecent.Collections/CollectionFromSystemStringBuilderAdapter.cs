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
using System.Text;
using Com.Halfdecent;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Numerics;


namespace
Com.Halfdecent.Collections
{


// =============================================================================
/// Present a <tt>System.Text.StringBuilder</tt> as a mutable collection of
/// characters
// =============================================================================

public partial class
CollectionFromSystemStringBuilderAdapter
    : IOrderedCollectionRCSG< char >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
CollectionFromSystemStringBuilderAdapter(
    StringBuilder from
)
{
    NonNull.CheckParameter( from, "from" );
    this.From = from;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

protected
StringBuilder
From
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// IOrderedCollectionRCSG< char >
// -----------------------------------------------------------------------------

public IOrderedCollectionRCSG< char > Slice( long index, long count ) {
    return new IndexSliceRCSG< char >( this, index, count ); }



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionC< char >
// -----------------------------------------------------------------------------

public
    void
Replace(
    long    key,
    char    replacement
)
{
    ExistingKeyIn.CheckParameter( this, key, "key" );
    int i = (int)key;
    this.From[ i ] = replacement;
}



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionR< long, char >
// -----------------------------------------------------------------------------

public
    char
Get(
    long key
)
{
    ExistingKeyIn.CheckParameter( this, key, "key" );
    int i = (int)key;
    return this.From[ i ];
}



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionS< char >
// -----------------------------------------------------------------------------

public
    void
Remove(
    long key
)
{
    ExistingKeyIn.CheckParameter( this, key, "key" );
    int i = (int)key;
    this.From.Remove( i, 1 );
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
// IKeyedCollectionG< long, char >
// -----------------------------------------------------------------------------

public
    void
Add(
    long    key,
    char    item
)
{
    ExistingOrNextPositionIn.CheckParameter( this, key, "key" );
    InInt32Range.CheckParameter( Real.Create( key ), "key" );
    // TODO FullException (or whatever) if .Length == .MaxCapacity
    int i = (int)key;
    this.From.Insert( i, item );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionRC< long, char >
// -----------------------------------------------------------------------------

public
    IFilter< char, char >
GetAndReplaceAll(
    long key
)
{
    return KeyedCollection
        .GetAndReplaceAllViaUniqueKeyedCollection( this, key );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionRS< long, char >
// -----------------------------------------------------------------------------

public
    IStream< char >
GetAndRemoveAll(
    long key
)
{
    return KeyedCollection
        .GetAndRemoveAllViaUniqueKeyedCollection( this, key );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionR< long, char >
// -----------------------------------------------------------------------------

public
    IStream< ITupleHD< long, char > >
StreamPairs()
{
    return this.StreamPairsIterator().AsStream();
}

private
    SCG.IEnumerator< ITupleHD< long, char > >
StreamPairsIterator()
{
    for( int i = 0; i < this.From.Length; i++ ) {
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
    if( key >= this.From.Length ) return false;
    return true;
}


public
    IStream< char >
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
    get { return this.From.Length; }
}



// -----------------------------------------------------------------------------
// ICollectionG< char >
// -----------------------------------------------------------------------------

public
    void
Add(
    char item
)
{
    this.From.Append( item );
}



// -----------------------------------------------------------------------------
// ICollectionRC< char >
// -----------------------------------------------------------------------------

public
    IFilter< char, char >
GetAndReplaceWhere(
    Predicate< char > where
)
{
    return Collection.GetAndReplaceWhereViaUniqueKeyedCollection( this, where );
}



// -----------------------------------------------------------------------------
// ICollectionRS< char >
// -----------------------------------------------------------------------------

public
    IStream< char >
GetAndRemoveWhere(
    Predicate< char > where
)
{
    return Collection.GetAndRemoveWhereViaUniqueKeyedCollection( this, where );
}



// -----------------------------------------------------------------------------
// ICollectionR< char >
// -----------------------------------------------------------------------------

public
    IStream< char >
Stream()
{
    return Collection.StreamViaKeyedCollection( this );
}




} // type
} // namespace

