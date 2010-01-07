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


using SCG = System.Collections.Generic;
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

/// Initialise a new stream that yields a specified series of items, or no
/// items at all
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
{
    new NonNull().Require( enumerable, new Parameter( "enumerable" ) );
    this.Enumerator = enumerable.GetEnumerator();
}


/// Initialise a new stream that yields the items remaining in a specified
/// enumerator
///
public
Stream(
    SCG.IEnumerator< T > enumerator
)
{
    new NonNull().Require( enumerator, new Parameter( "enumerator" ) );
    this.Enumerator = enumerator;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

private
SCG.IEnumerator< T >
Enumerator
{
    get;
    set;
}



// -----------------------------------------------------------------------------
// IStream< T >
// -----------------------------------------------------------------------------

public
    bool
TryPull(
    out T item
)
{
    if( this.Enumerator.MoveNext() ) {
        item = this.Enumerator.Current;
        return true;
    } else {
        item = default( T );
        return false;
    }
}




} // type
} // namespace
