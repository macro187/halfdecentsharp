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
///
/// @par .IsReadOnly
/// Refer to the namespace-wide <tt>Com.Halfdecent.Collections</tt>
/// documentation for a discussion of important issues surrounding the
/// readability / writability of collections in the base class library.
///
/// @par Undefined TryPush() failure
/// Because <tt>ICollection< T >.Add()</tt> doesn't define how to fail when the
/// collection is full, neither can this class.  So, <tt>TryPush()</tt> will
/// either succeed, returning <tt>true</tt>, or fail in whatever undefined way
/// the underlying collection's <tt>Add()</tt> fails.
// =============================================================================

public class
BagFromCollectionAdapter<
    T
>
    : ReadOnlyBagFromCollectionAdapter< T >
    , ISink< T >
    , IShrinkableBag< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
BagFromCollectionAdapter(
    SCG.ICollection< T > collection
)
    : base( collection )
{
    if( collection.IsReadOnly )
        throw new ValueException(
            new Parameter( "collection" ),
            _S("{0} is read-only, use ReadOnlyBagFromCollectionAdapter") );
}



// -----------------------------------------------------------------------------
// ISink< T >
// -----------------------------------------------------------------------------

public
bool
TryPush(
    T item
)
{
    this.Collection.Add( item );
    return true;
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




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

