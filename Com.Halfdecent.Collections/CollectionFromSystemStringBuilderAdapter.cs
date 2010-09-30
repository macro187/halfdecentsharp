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
using System.Text;
using Com.Halfdecent;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Numerics;
using Com.Halfdecent.Streams;


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
    new NonNull().Require( from, new Parameter( "from" ) );
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

public IOrderedCollectionRCSG< char > Slice( IInteger index, IInteger count ) {
    return new IndexSliceRCSG< char >( this, index, count ); }



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionC< char >
// -----------------------------------------------------------------------------

public
    void
Replace(
    IInteger    key,
    char        replacement
)
{
    new NonNull().Require( key, new Parameter( "key" ) );
    new ExistingKeyIn< IInteger, char >( this )
        .Require( key, new Parameter( "key" ) );
    int i = (int)( key.GetValue() );
    this.From[ i ] = replacement;
}



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionR< IInteger, char >
// -----------------------------------------------------------------------------

public
    char
Get(
    IInteger key
)
{
    new NonNull().Require( key, new Parameter( "key" ) );
    new ExistingKeyIn< IInteger, char >( this )
        .Require( key, new Parameter( "key" ) );
    int i = (int)( key.GetValue() );
    return this.From[ i ];
}



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionS< char >
// -----------------------------------------------------------------------------

public
    void
Remove(
    IInteger key
)
{
    new NonNull().Require( key, new Parameter( "key" ) );
    new ExistingKeyIn< IInteger, char >( this )
        .Require( key, new Parameter( "key" ) );
    int i = (int)( key.GetValue() );
    this.From.Remove( i, 1 );
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
// IKeyedCollectionG< IInteger, char >
// -----------------------------------------------------------------------------

public
    void
Add(
    IInteger    key,
    char        item
)
{
    new NonNull().Require( key, new Parameter( "key" ) );
    new ExistingOrNextPositionIn( this ).Require( key, new Parameter( "key" ) );
    new InInt32Range().Require( key, new Parameter( "key" ) );
    // TODO FullException (or whatever) if .Length == .MaxCapacity
    int i = (int)( key.GetValue() );
    this.From.Insert( i, item );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionRC< IInteger, char >
// -----------------------------------------------------------------------------

public
    IFilter< char, char >
GetAndReplaceAll(
    IInteger key
)
{
    return KeyedCollection
        .GetAndReplaceAllViaUniqueKeyedCollection( this, key );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionRS< IInteger, char >
// -----------------------------------------------------------------------------

public
    IStream< char >
GetAndRemoveAll(
    IInteger key
)
{
    return KeyedCollection
        .GetAndRemoveAllViaUniqueKeyedCollection( this, key );
}



// -----------------------------------------------------------------------------
// IKeyedCollectionR< IInteger, char >
// -----------------------------------------------------------------------------

public
    IStream< ITuple< IInteger, char > >
StreamPairs()
{
    return this.StreamPairsIterator().AsStream();
}

private
    SCG.IEnumerator< ITuple< IInteger, char > >
StreamPairsIterator()
{
    for( int i = 0; i < this.From.Length; i++ ) {
        yield return new Tuple< IInteger, char >(
            Integer.From( i ), this.From[ i ] );
    }
}


public
    bool
Contains(
    IInteger key
)
{
    if( key == null ) return false;
    if( key.LT( Integer.From( 0 ) ) ) return false;
    if( key.GTE( Integer.From( this.From.Length ) ) ) return false;
    return true;
}


public
    IStream< char >
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
    get { return Integer.From( this.From.Length ); }
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
    System.Predicate< char > where
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
    System.Predicate< char > where
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

