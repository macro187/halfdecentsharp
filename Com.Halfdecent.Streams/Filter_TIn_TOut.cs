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


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// <tt>IFilter< TIn, TOut ></tt> implementation
// =============================================================================

public class
Filter<
    TIn,
    TOut
>
    : FilterBase< TIn, TOut >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Use a specified filter function, don't drop input items
///
public
Filter(
    Func< TIn, TOut > func
)
    : this( func, false )
{
}


/// Use a specified filter function, drop input items as specified
///
public
Filter(
    Func< TIn, TOut >   func,
    bool                dropInputItems
)
{
    NonNull.Require( "func", new Parameter( "func" ) );
    this.Func = func;
    this.DropInputItems = dropInputItems;
    this.Kernel = this.DefaultKernel;
}


/// Use a specified filter iterator
///
public
Filter(
    FilterKernel< TIn, TOut > kernel
)
{
    NonNull.Require( "kernel", new Parameter( "kernel" ) );
    this.Kernel = kernel;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

private
Func< TIn, TOut >
Func
{
    get;
    set;
}


private
bool
DropInputItems
{
    get;
    set;
}


private
FilterKernel< TIn, TOut >
Kernel
{
    get;
    set;
}



// -----------------------------------------------------------------------------
// FilterBase< TIn, TOut >
// -----------------------------------------------------------------------------

protected override
SCG.IEnumerator< bool >
Process()
{
    return this.Kernel( this.GetItem, this.PutItem, this.DropItem );
}



// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private
SCG.IEnumerator< bool >
DefaultKernel(
    Func< TIn >     get,
    Action< TOut >  put,
    Action< TIn >   drop
)
{
    while( true ) {
        yield return false;
        TIn i = get();
        put( this.Func( i ) );
        if( this.DropInputItems  ) drop( i );
        yield return true;
    }
}




} // type
} // namespace

