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
using SC = System.Collections;
using SCG = System.Collections.Generic;
using Com.Halfdecent.Exceptions;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Streams.BCLInterop;
using Com.Halfdecent.Numerics;


namespace
Com.Halfdecent.Collections
{


// =============================================================================
/// Present a bag as a System.Generic.Collections collection
///
/// This adapter allows the largest subset of <tt>ICollection< T ></tt>
/// operations that the underlying bag is capable of.  Operations not supported
/// by the bag result in <tt>NotSupportedException</tt>s as per the
/// <tt>ICollection< T ></tt> documentation.
///
/// @par <tt>IsReadOnly</tt>
/// The collection <tt>IsReadOnly</tt> if the underlying bag is neither an
/// <tt>ISink< T ></tt> nor an <tt>IShrinkableBag< T ></tt>.
// =============================================================================

public class
BagToSCGCollectionAdapter<
    T
>
    : SCG.ICollection< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
BagToSCGCollectionAdapter(
    IBag< T > bag
)
{
    NonNull.Check( bag, new Parameter( "bag" ) );
    this.Bag = bag;
    this.Sink = bag as ISink< T >;
    this.ShrinkableBag = bag as IShrinkableBag< T >;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

protected
IBag< T >
Bag
{
    get;
    private set;
}


protected
ISink< T >
Sink
{
    get;
    private set;
}


protected
IShrinkableBag< T >
ShrinkableBag
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// ICollection< T >
// -----------------------------------------------------------------------------

public
int
Count
{
    get
    {
        if( this.Bag.Count.GT( Integer.From( Int32.MaxValue ) ) )
            throw new LocalisedInvalidOperationException(
                _S("This collection's .Count is greater than Int32.MaxValue") );
        return Decimal.ToInt32( this.Bag.Count.ToDecimal() );
    }
}


public
bool
IsReadOnly
{
    get
    {
        return this.Sink == null && this.ShrinkableBag == null;
    }
}


public
void
Add(
    T item
)
{
    if( this.Sink == null ) throw new NotSupportedException();
    this.Sink.Push( item );
}


public
void
Clear()
{
    if( this.ShrinkableBag == null ) throw new NotSupportedException();
    this.ShrinkableBag.Clear();
}


public
bool
Contains(
    T item
)
{
    return this.Bag.Contains( item );
}


public
void
CopyTo(
    T[] array,
    int arrayIndex
)
{
    if( array == null )
        throw new LocalisedArgumentNullException( "array" );
    if( arrayIndex < 0 )
        throw new LocalisedArgumentOutOfRangeException(
            "arrayIndex",
            arrayIndex,
            _S("arrayIndex is less than 0") );
    if( array.Rank > 1 )
        throw new LocalisedArgumentException(
            _S("array is multidimensional"),
            "array" );
    if( this.Bag.Count.GT( Integer.From( array.Length - arrayIndex ) ) )
        throw new LocalisedArgumentException(
            _S("The number of elements in this collection is greater than the available space from arrayIndex to the end of array") );
    // TODO
    throw new NotImplementedException();
}


public
bool
Remove(
    T item
)
{
    if( this.ShrinkableBag == null ) throw new NotSupportedException();
    bool r = this.Bag.Contains( item );
    this.ShrinkableBag.Remove( item );
    return r;
}



// -----------------------------------------------------------------------------
// IEnumerable< T >
// -----------------------------------------------------------------------------

SCG.IEnumerator< T >
SCG.IEnumerable< T >.GetEnumerator()
{
    return this.Bag.Stream().AsEnumerable().GetEnumerator();
}



// -----------------------------------------------------------------------------
// IEnumerable
// -----------------------------------------------------------------------------

SC.IEnumerator
SC.IEnumerable.GetEnumerator()
{
    return ((SCG.IEnumerable< T >)this).GetEnumerator();
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

