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
/// Present a <tt>System.Collections.Generic.IDictionary<TKey,T></tt> as an
/// <tt>IUniqueKeyedCollectionRCSG<TKey,T></tt>
// =============================================================================

public class
CollectionFromSystemDictionaryAdapter<
    TKey,
    T
>
    : IUniqueKeyedCollectionRCSG< TKey, T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
CollectionFromSystemDictionaryAdapter(
    SCG.IDictionary< TKey, T > from
)
{
    NonNull.Require( from, new Parameter( "from" ) );
    this.From = from;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

protected
SCG.IDictionary< TKey, T >
From
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionR< TKey, T >
// -----------------------------------------------------------------------------

public
    T
Get(
    TKey key
)
{
    ExistingKeyIn.Require( this, key, new Parameter( "key" ) );
    return this.From[ key ];
}



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionC< TKey, T >
// -----------------------------------------------------------------------------

public
    void
Replace(
    TKey key,
    T    replacement
)
{
    ExistingKeyIn.Require( this, key, new Parameter( "key" ) );
    this.From[ key ] = replacement;
}



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionS< TKey >
// -----------------------------------------------------------------------------

public
    void
Remove(
    TKey key
)
{
    ExistingKeyIn.Require( this, key, new Parameter( "key" ) );
    this.From.Remove( key );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionS< TKey >
// -----------------------------------------------------------------------------

public
    void
RemoveAll(
    TKey key
)
{
    this.Remove( key );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionG< TKey, T >
// -----------------------------------------------------------------------------

public
    void
Add(
    TKey key,
    T    item
)
{
    NonExistingKeyIn.Require( this, key, new Parameter( "key" ) );
    this.From.Add( key, item );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionRC< TKey, T >
// -----------------------------------------------------------------------------

public
    IFilter< T, T >
GetAndReplaceAll(
    TKey key
)
{
    return KeyedCollection
        .GetAndReplaceAllViaUniqueKeyedCollection( this, key );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionRS< TKey, T >
// -----------------------------------------------------------------------------

public
    IStream< T >
GetAndRemoveAll(
    TKey key
)
{
    return KeyedCollection
        .GetAndRemoveAllViaUniqueKeyedCollection( this, key );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionR< TKey, T >
// -----------------------------------------------------------------------------

public
    IStream< ITuple< TKey, T > >
StreamPairs()
{
    return
        this.From
        .Select( kvp => Tuple.Create( kvp.Key, kvp.Value ) )
        .AsStream();
}


public
    bool
Contains(
    TKey key
)
{
    return this.From.ContainsKey( key );
}


public
    IStream< T >
Stream(
    TKey key
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
    get { return Integer.From( this.From.Count ); }
}



// -----------------------------------------------------------------------------
// ICollectionRC< T >
// -----------------------------------------------------------------------------

public
    IFilter< T, T >
GetAndReplaceWhere(
    System.Predicate< T > where
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
    System.Predicate< T > where
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

