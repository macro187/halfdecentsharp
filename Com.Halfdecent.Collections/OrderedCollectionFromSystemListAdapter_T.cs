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
using System;
using Com.Halfdecent;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Numerics;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Filters;


namespace
Com.Halfdecent.Collections
{


// =============================================================================
/// Present a <tt>System.Collections.Generic.IList< T ></tt> as an
/// <tt>IOrderedCollectionCSG< T ></tt>
// =============================================================================

public class
OrderedCollectionFromSystemListAdapter<
    T
>
    : OrderedCollectionBase< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
OrderedCollectionFromSystemListAdapter(
    SCG.IList< T > list
)
{
    new NonNull().Require( list, new Parameter( "list" ) );
    this.List = list;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

protected
SCG.IList< T >
List
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// IOrderedCollection< T >
// IOrderedCollectionC< T >
// IOrderedCollectionS< T >
// IOrderedCollectionG< T >
// -----------------------------------------------------------------------------



// -----------------------------------------------------------------------------
// IUniqueKeyedCollection< IInteger, T >
// -----------------------------------------------------------------------------

public override
    T
Get(
    IInteger key
)
{
    new NonNull().Require( key, new Parameter( "key" ) );
    new ExistingPositionIn< T >( this ).Require( key, new Parameter( "key" ) );
    return this.List[ (int)( key.GetValue() ) ];
}



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionC< IInteger, T >
// -----------------------------------------------------------------------------

public override
    T
GetAndReplace(
    IInteger    key,
    T           replacement
)
{
    new NonNull().Require( key, new Parameter( "key" ) );
    new ExistingPositionIn< T >( this ).Require( key, new Parameter( "key" ) );
    int i = (int)( key.GetValue() );
    T old = this.List[ i ];
    this.List[ i ] = replacement;
    return old;
}



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionS< IInteger, T >
// -----------------------------------------------------------------------------

public override
    T
GetAndRemove(
    IInteger key
)
{
    new NonNull().Require( key, new Parameter( "key" ) );
    new ExistingPositionIn< T >( this ).Require( key, new Parameter( "key" ) );
    int i = (int)( key.GetValue() );
    T old = this.List[ i ];
    this.List.RemoveAt( i );
    return old;
}



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionG< IInteger, T >
// -----------------------------------------------------------------------------



// -----------------------------------------------------------------------------
// IKeyedCollection< IInteger, T >
// -----------------------------------------------------------------------------



// -----------------------------------------------------------------------------
// IKeyedCollectionC< IInteger, T >
// -----------------------------------------------------------------------------



// -----------------------------------------------------------------------------
// IKeyedCollectionS< IInteger, T >
// -----------------------------------------------------------------------------



// -----------------------------------------------------------------------------
// IKeyedCollectionG< IInteger, T >
// -----------------------------------------------------------------------------

public override
    void
Add(
    IInteger    key,
    T           item
)
{
    new NonNull().Require( key, new Parameter( "key" ) );
    new ExistingOrNextPositionIn< T >( this )
        .Require( key, new Parameter( "key" ) );
    new InInt32Range().Require( key, new Parameter( "key" ) );
    this.List.Insert( (int)( key.GetValue() ), item );
}



// -----------------------------------------------------------------------------
// ICollection< ITuple< IInteger, T > >
// -----------------------------------------------------------------------------

public override
IInteger
Count
{
    get { return Integer.From( this.List.Count ); }
}


protected override
    IStream< ITuple< IInteger, T > >
TupleStream()
{
    return
        this.TupleStreamIterator()
        .AsStream();
}

protected
    SCG.IEnumerator< ITuple< IInteger, T > >
TupleStreamIterator()
{
    for( int i = 0; i < this.List.Count; i++ )
        yield return new Tuple< IInteger, T >(
            Integer.From( i ),
            this.List[ i ] );
}



// -----------------------------------------------------------------------------
// ICollectionC< ITuple< IInteger, T > >
// -----------------------------------------------------------------------------



// -----------------------------------------------------------------------------
// ICollectionS< ITuple< IInteger, T > >
// -----------------------------------------------------------------------------



// -----------------------------------------------------------------------------
// ICollectionG< ITuple< IInteger, T > >
// -----------------------------------------------------------------------------



// -----------------------------------------------------------------------------
// ICollection< T >
// -----------------------------------------------------------------------------



// -----------------------------------------------------------------------------
// ICollectionC< T >
// -----------------------------------------------------------------------------



// -----------------------------------------------------------------------------
// ICollectionS< T >
// -----------------------------------------------------------------------------



// -----------------------------------------------------------------------------
// ICollectionG< T >
// -----------------------------------------------------------------------------




//private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

