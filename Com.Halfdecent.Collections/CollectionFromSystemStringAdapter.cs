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
/// Present a string as a read-only collection of characters
// =============================================================================

public class
CollectionFromSystemStringAdapter
    : IOrderedCollectionR< char >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
CollectionFromSystemStringAdapter(
    string from
)
{
    new NonNull().Require( from, new Parameter( "from" ) );
    this.From = from;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

protected
string
From
{
    get;
    private set;
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
// ICollectionR< char >
// -----------------------------------------------------------------------------

public
    IStream< char >
Stream()
{
    return Collection.StreamViaKeyedCollection( this );
}




//private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace


