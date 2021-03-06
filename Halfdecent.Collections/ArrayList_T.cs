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


using SCG = System.Collections.Generic;
using Halfdecent.Globalisation;
using Halfdecent.Meta;
using Halfdecent.RTypes;
using Halfdecent.Streams;


namespace
Halfdecent.Collections
{


// =============================================================================
/// A dynamic array
///
/// See <tt>http://en.wikipedia.org/wiki/Dynamic_array</tt>.
///
/// Uses <tt>System.Collections.Generic.List<T></tt> internally.
// =============================================================================

public class
ArrayList<
    T
>
    : CollectionFromSystemListAdapter< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
ArrayList(
    SCG.List< T > list
)
    : base( list )
{
    NonNull.CheckParameter( list, "list" );
    this.List = list;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

protected
    SCG.List< T >
List
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Suggest that the internal capacity be optimised for the number of items
/// currently in the collection
///
public
    void
TrimInternalCapacity()
{
    this.List.TrimExcess();
}


/// Suggest that the internal capacity be adjusted to optimally handle the
/// addition of a certain number of items
///
public
    void
PrepareInternalCapacityForAdditional(
    int i
    ///< The number of additional items to optimise for
    ///  - GTE( 0 )
)
{
    if( i <= 0 ) throw new LocalisedArgumentOutOfRangeException( "i" );
    if( i == 0 ) return;
    int c = this.List.Count + i;
    if( this.List.Capacity < c ) this.List.Capacity = c;
}




} // type
} // namespace

