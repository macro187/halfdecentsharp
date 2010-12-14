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


using System.Linq;
using SCG = System.Collections.Generic;


namespace
Com.Halfdecent
{


// =============================================================================
/// A sequence comparer that determines equality and hash codes according to a
/// specified item comparer
// =============================================================================

public class
SystemEnumerableComparer<
    T
>
    : IEqualityComparer< SCG.IEnumerable< T > >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
SystemEnumerableComparer(
    IEqualityComparer< T > itemComparer
)
{
    if( object.ReferenceEquals( itemComparer, null ) )
        throw new System.ArgumentNullException( "itemComparer" );
    this.ItemComparer = itemComparer;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

private
IEqualityComparer< T >
ItemComparer;



// -----------------------------------------------------------------------------
// System.Collections.Generic.IEqualityComparer< T >
// -----------------------------------------------------------------------------

public
    bool
Equals(
    SCG.IEnumerable< T > dis,
    SCG.IEnumerable< T > that
)
{
    if( object.ReferenceEquals( dis, null )
        && object.ReferenceEquals( that, null ) )
            return true;
    if( object.ReferenceEquals( dis, null )
        || object.ReferenceEquals( that, null ) )
            return false;
    return dis.SequenceEqual( that, this.ItemComparer );
}


public
    int
GetHashCode(
    SCG.IEnumerable< T > item
)
{
    if( object.ReferenceEquals( item, null ) )
        throw new System.ArgumentNullException( "item" );
    return item.Aggregate(
        typeof( SystemEnumerableComparer< T > ).GetHashCode(),
        (a,i) => a ^ this.ItemComparer.GetHashCode( i ) );
}



// -----------------------------------------------------------------------------
// IEquatable< IEqualityComparer >
// -----------------------------------------------------------------------------

public
    bool
Equals(
    IEqualityComparer that
)
{
    return Equatable.Equals( this, that );
}


public override
    int
GetHashCode()
{
    return
        typeof( SystemEnumerableComparer< T > ).GetHashCode()
        ^ this.ItemComparer.GetHashCode();
}


    bool
IEquatable< IEqualityComparer >.DirectionalEquals(
    IEqualityComparer that
)
{
    return
        that != null
        && that.GetUnderlying().IsAnd<
            SystemEnumerableComparer< T > >(
            c => c.ItemComparer.Equals( this.ItemComparer ) );
}



// -----------------------------------------------------------------------------
// System.Object
// -----------------------------------------------------------------------------

public override
    bool
Equals(
    object that
)
{
    throw new System.NotSupportedException();
}


// NOTE Would ideally override GetHashCode() with NotSupportedException too,
//      but difficult to 'override' and 'new' the same member




} // type
} // namespace

