// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2011, 2012
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
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Halfdecent;
using Halfdecent.Globalisation;


namespace
Halfdecent.Meta
{


// =============================================================================
/// A reference to a particular value
// =============================================================================

public class
ValueReference
    : IList< IValueReferenceComponent >
    , IEquatableHD< ValueReference >
    , IEquatable< ValueReference >
{


// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
ValueReference(
    IEnumerable< IValueReferenceComponent > components
)
{
    if( object.ReferenceEquals( components, null ) )
        throw new LocalisedArgumentNullException( "components" );
    this.Components = components.ToList();
}



// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private
IList< IValueReferenceComponent >
Components;



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

public
    ValueReference
Property(
    string name
)
{
    return new ValueReference( this.Append( new Property( name ) ) );
}


public
    ValueReference
Indexer(
    object index
)
{
    return new ValueReference( this.Append( new Indexer( index ) ) );
}



// -----------------------------------------------------------------------------
// IList< IValueReferenceComponent >
// -----------------------------------------------------------------------------

public
IValueReferenceComponent
this[
    int index
]
{
    get { return this.Components[ index ]; }
    set { throw new NotSupportedException(); }
}


    int
IList< IValueReferenceComponent >.IndexOf(
    IValueReferenceComponent item
)
{
    // NOTE Could be implemented using IValueReferenceComponent equality
    throw new NotSupportedException();
}


    void
IList< IValueReferenceComponent >.Insert(
    int                         index,
    IValueReferenceComponent    item
)
{
    throw new NotSupportedException();
}


    void
IList< IValueReferenceComponent >.RemoveAt(
    int index
)
{
    throw new NotSupportedException();
}



// -----------------------------------------------------------------------------
// ICollection< IValueReferenceComponent >
// -----------------------------------------------------------------------------

public
int
Count
{
    get { return this.Components.Count; }
}


bool
ICollection< IValueReferenceComponent >.IsReadOnly
{
    get { return true; }
}


void
ICollection< IValueReferenceComponent >.Add(
    IValueReferenceComponent item
)
{
    throw new NotSupportedException();
}


void
ICollection< IValueReferenceComponent >.Clear()
{
    throw new NotSupportedException();
}


bool
ICollection< IValueReferenceComponent >.Contains(
    IValueReferenceComponent item
)
{
    // NOTE Could be implemented using IValueReferenceComponent equality
    throw new NotSupportedException();
}


void
ICollection< IValueReferenceComponent >.CopyTo(
    IValueReferenceComponent[]  array,
    int                         arrayIndex
)
{
    this.Components.CopyTo( array, arrayIndex );
}


bool
ICollection< IValueReferenceComponent >.Remove(
    IValueReferenceComponent item
)
{
    throw new NotSupportedException();
}



// -----------------------------------------------------------------------------
// IEnumerable< IValueReferenceComponent >
// -----------------------------------------------------------------------------

    IEnumerator< IValueReferenceComponent >
IEnumerable< IValueReferenceComponent >.GetEnumerator()
{
    return this.Components.GetEnumerator();
}



// -----------------------------------------------------------------------------
// IEnumerable
// -----------------------------------------------------------------------------

    IEnumerator
IEnumerable.GetEnumerator()
{
    return ((IEnumerable)this.Components).GetEnumerator();
}



// -----------------------------------------------------------------------------
// IEquatableHD< ValueReference >
// IEquatable< ValueReference >
// -----------------------------------------------------------------------------

public virtual
    bool
Equals(
    ValueReference that
)
{
    if( object.ReferenceEquals( that, null ) ) return false;
    return this.SequenceEqual( that );
}


public override
    int
GetHashCode()
{
    return this.Aggregate(
        this.GetType().GetHashCode(),
        (acc, vc) => acc ^= vc.GetHashCode() );
}



// -----------------------------------------------------------------------------
// Object
// -----------------------------------------------------------------------------

public override
    bool
Equals(
    object that
)
{
    throw new NotSupportedException();
}


public override
    string
ToString()
{
    return this.Aggregate(
        "",
        (a,c) => string.Concat( a, c.ToString() ) );
}




} // type
} // namespace

