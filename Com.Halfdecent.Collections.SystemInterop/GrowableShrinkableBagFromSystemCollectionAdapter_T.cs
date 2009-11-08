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
/// Present a non-read-only <tt>System.Collections.Generic</tt> collection
/// as a growable, shrinkable bag
///
/// @par .IsReadOnly
/// Refer to the namespace-wide <tt>Com.Halfdecent.Collections</tt>
/// documentation for a discussion of important issues surrounding the
/// readability / writability of collections in the base class library.
///
/// @par Undefined <tt>TryAdd()</tt> failure
/// Because <tt>ICollection< T >.Add()</tt> doesn't define how to fail when the
/// collection is full, neither can this class.  So, <tt>TryAdd()</tt> will
/// either succeed, returning <tt>true</tt>, or fail in whatever undefined way
/// the underlying collection's <tt>Add()</tt> fails.
// =============================================================================

public class
GrowableShrinkableBagFromSystemCollectionAdapter<
    T
>
    : BagFromSystemCollectionAdapter< T >
    , IGrowableBag< T >
    , IShrinkableBag< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
GrowableShrinkableBagFromSystemCollectionAdapter(
    SCG.ICollection< T > collection
)
    : base( collection )
{
    if( collection.IsReadOnly )
        throw new ValueException(
            new Parameter( "collection" ),
            _S("{0} is read-only, use ReadOnlyBagFromSystemCollectionAdapter") );
}



// -----------------------------------------------------------------------------
// IShrinkableBag< T >
// -----------------------------------------------------------------------------

public
bool
TryRemove(
    T sought
)
{
    return this.Collection.Remove( sought );
}


public
void
RemoveAll()
{
    this.Collection.Clear();
}



// -----------------------------------------------------------------------------
// IGrowableBag< T >
// -----------------------------------------------------------------------------

public
bool
TryAdd(
    T item
)
{
    this.Collection.Add( item );
    return true;
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

