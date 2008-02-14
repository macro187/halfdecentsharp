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




/// An adapter that makes an <tt>IList< T ></tt> supporting read and removal
/// operations out of a <tt>System.Collections.Generic.IList< T ></tt>
public class
IListFromGrowableIListAdapter<
    T   ///< (See <tt>IBag< T ></tt>)
>
    : IListFromReadOnlyIListAdapter< T >
    , IListCanAddAt< T >
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialize a new <tt>IListFromGrowableIListAdapter< T ></tt> adapting
/// a given <tt>System.Collections.Generic.IList< T ></tt>
///
public
IListFromGrowableIListAdapter(
    SCG.IList< T > list ///< The list to adapt
                        ///
                        ///  - Really <tt>IsPresent</tt>
)
    : base( list )
{
}




// -----------------------------------------------------------------------------
// IListCanAddAt< T >
// -----------------------------------------------------------------------------

/// (See <tt>IListCanAddAt< T >.AddAt()</tt>)
///
public
void
AddAt(
    Integer position,
    T       item
)
{
    new IsPresent< Integer >().Require( position );
    new IsExistingOrNextPositionIn< T >( this ).Require( position );
    SCGInteropAlgorithms.IListAddAtViaIList< T >(
        this.List, position, item );
}




} // type
} // namespace

