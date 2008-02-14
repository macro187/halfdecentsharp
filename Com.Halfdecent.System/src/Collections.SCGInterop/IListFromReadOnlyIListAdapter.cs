// -----------------------------------------------------------------------------
// Copyright (c) 2008 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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
using Com.Halfdecent.System;
using Com.Halfdecent.Numerics;
using Com.Halfdecent.Streams;


namespace
Com.Halfdecent.Collections.SCGInterop
{




/// An adapter that makes an <tt>IList< T ></tt> supporting read operations
/// out of a <tt>System.Collections.Generic.IList< T ></tt>
///
public class
IListFromReadOnlyIListAdapter<
    T
>
    : IBagFromReadOnlyICollectionAdapter< T >
    , IList< T >
    , IListCanGetAt< T >
    , IListCanStreamForward< T >
    , IListCanStreamBackward< T >
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialize a new <tt>IListFromReadOnlyIListAdapter< T ></tt> adapting
/// a given <tt>System.Collections.Generic.IList< T ></tt>
///
public
IListFromReadOnlyIListAdapter(
    SCG.IList< T > list ///< The list to adapt
                        ///
                        ///  Requirements:
                        ///  - Really <tt>IsPresent</tt>
)
    : base( list )
{
    new IsPresent< SCG.IList< T > >().ReallyRequire( list );
    this.list = list;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// The <tt>System.Collections.Generic.IList< T ></tt> being adapted
///
protected SCG.IList< T >
List
{
    get { return this.list; }
}

private SCG.IList< T >
list;




// -----------------------------------------------------------------------------
// IListCanGetAt< T >
// -----------------------------------------------------------------------------

public
T
GetAt(
    Integer position
)
{
    new IsPresent< Integer >().Require( position );
    new IsExistingPositionIn< T >( this ).Require( position );
    return SCGInteropAlgorithms.IListGetAtViaIList< T >( this.List, position );
}




// -----------------------------------------------------------------------------
// IBagCanStream< T >
// -----------------------------------------------------------------------------

public override
IFiniteStream< T >
Stream()
{
    return this.StreamForward();
}




// -----------------------------------------------------------------------------
// IListCanStreamForward< T >
// -----------------------------------------------------------------------------

public
IFiniteStream< T >
StreamForward()
{
    return CollectionsAlgorithms.IListStreamForwardViaIListGetAt( this );
}




// -----------------------------------------------------------------------------
// IListCanStreamBackward< T >
// -----------------------------------------------------------------------------

public
IFiniteStream< T >
StreamBackward()
{
    return CollectionsAlgorithms.IListStreamBackwardViaIListGetAt( this );
}




} // type
} // namespace

