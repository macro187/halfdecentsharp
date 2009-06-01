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
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Numerics;
using Com.Halfdecent.Streams;


namespace
Com.Halfdecent.Collections
{


// =============================================================================
/// Present a non-read-only <tt>System.Collections.Generic.Collection< T ></tt>
/// as an <tt>IBag< T ></tt>
// =============================================================================

public class
BagFromCollectionAdapter<
    T
>
    : IBag< T >
    , IReadableBag< T >
    , IGrowableBag< T >
    , IShrinkableBag< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
BagFromCollectionAdapter(
    SCG.ICollection< T > collection
)
{
    NonNull.Check( collection, new Parameter( "collection" ) );
    // TODO Fix when exceptions are worked out
    if( collection.IsReadOnly )
        throw new ArgumentException( "Collection is read-only", "collection" );
    // XXX  The above check doesn't cover all cases, this is a dirty
    //      situation...
    this.Collection = collection;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
SCG.ICollection< T >
Collection
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// IBag< T >
// -----------------------------------------------------------------------------

public
bool
IsEmpty
{
    get { return this.Count == Integer.From( 0 ); }
}


public
IInteger
Count
{
    get { return Integer.From( this.Collection.Count ); }
}



// -----------------------------------------------------------------------------
// IReadableBag< T >
// -----------------------------------------------------------------------------

public
IStream< T >
Stream()
{
    return this.Collection.AsStream();
}



// -----------------------------------------------------------------------------
// IGrowableBag< T >
// -----------------------------------------------------------------------------

public
void
Add(
    T item
)
{
    this.Collection.Add( item );
}



// -----------------------------------------------------------------------------
// IShrinkableBag< T >
// -----------------------------------------------------------------------------

public
void
Clear()
{
    this.Collection.Clear();
}




} // type
} // namespace

