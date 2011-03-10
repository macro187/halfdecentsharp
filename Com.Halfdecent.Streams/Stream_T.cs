// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010
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
using Com.Halfdecent;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// A stream yielding a specified sequence of items
// =============================================================================

public class
Stream<
    T
>
    : IStream< T >
{



// -----------------------------------------------------------------------------
// Static Properties
// -----------------------------------------------------------------------------

/// A stream that yields no items
///
public static
IStream< T >
Empty
{
    get { return empty; }
}

private static
IStream< T >
empty = new Stream< T >();



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialise a new stream that yields a specified series of items, or none
/// at all
///
public
Stream(
    params T[] items
)
    : this( (SCG.IEnumerable<T>)items )
{
}


/// Initialise a new stream that yields the items in a specified enumerable
///
public
Stream(
    SCG.IEnumerable< T > enumerable
)
    : this( enumerable.GetEnumerator() )
{
    NonNull.CheckParameter( enumerable, "enumerable" );
}


/// Initialise a new stream that yields the items remaining in a specified
/// enumerator
///
public
Stream(
    SCG.IEnumerator< T > enumerator
)
    : this( () => {
        if( enumerator.MoveNext() )
            return Tuple.Create( true, enumerator.Current );
        else
            return Tuple.Create( false, default( T ) ); } )
{
    NonNull.CheckParameter( enumerator, "enumerator" );
}


/// Initialise a new stream from a <tt>Com.Halfdecent.MaybeFunc<T></tt>
///
public
Stream(
    MaybeFunc< T > maybeFunc
)
    : this( () => {
        T r;
        if( maybeFunc( out r ) )
            return Tuple.Create( true, r );
        else
            return Tuple.Create( false, default( T ) ); } )
{
    NonNull.CheckParameter( maybeFunc, "maybeFunc" );
}


/// Initialise a new stream from a <tt>Func< ITuple< bool, T > ></tt>
///
public
Stream(
    System.Func< ITuple< bool, T > > tryPullFunc
)
{
    NonNull.CheckParameter( tryPullFunc, "tryPullFunc" );
    this.TryPullFunc = tryPullFunc;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

private
System.Func< ITuple< bool, T > >
TryPullFunc
{
    get;
    set;
}



// -----------------------------------------------------------------------------
// IStream< T >
// -----------------------------------------------------------------------------

public
    ITuple< bool, T >
TryPull()
{
    return this.TryPullFunc();
}




} // type
} // namespace

