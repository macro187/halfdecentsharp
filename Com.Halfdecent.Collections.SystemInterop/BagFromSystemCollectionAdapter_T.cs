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
using Com.Halfdecent.Streams.SystemInterop;
using Com.Halfdecent.Collections;


namespace
Com.Halfdecent.Collections.SystemInterop
{


// =============================================================================
/// Present a <tt>System.Collections.Generic.Collection< T ></tt> as an
/// <tt>IBag< T ></tt>
// =============================================================================

public class
BagFromSystemCollectionAdapter<
    T
>
    : IBag< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
BagFromSystemCollectionAdapter(
    SCG.ICollection< T > collection
)
{
    NonNull.Check( collection, new Parameter( "collection" ) );
    this.Collection = collection;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

protected
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
IInteger
Count
{
    get { return Integer.From( this.Collection.Count ); }
}


public
bool
IsEmpty
{
    get { return Com.Halfdecent.Collections.Bag.IsEmptyViaCount( this ); }
}


public
IStream< T >
Stream()
{
    return this.Collection.AsStream();
}


public
bool
Contains(
    T item
)
{
    return this.Collection.Contains( item );
}




//private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

