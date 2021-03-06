// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010, 2011, 2012
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
using System.Collections.Generic;
using Halfdecent;
using Halfdecent.Meta;
using Halfdecent.RTypes;


namespace
Halfdecent.Streams
{


// =============================================================================
/// A stream based on a <tt>TryPull()</tt> function
// =============================================================================

public class
Stream<
    T
>
    : IStream< T >
{


public
Stream(
    Func< IMaybe< T > > tryPullFunc,
    Action              disposeFunc
)
{
    NonNull.CheckParameter( tryPullFunc, "tryPullFunc" );
    NonNull.CheckParameter( disposeFunc, "disposeFunc" );
    this.TryPullFunc = tryPullFunc;
    this.DisposeFunc = disposeFunc;
    this.Disposed = false;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

private
Func< IMaybe< T > >
TryPullFunc;


private
Action
DisposeFunc;


private
bool
Disposed;



// -----------------------------------------------------------------------------
// IStream< T >
// -----------------------------------------------------------------------------

public
    IMaybe< T >
TryPull()
{
    if( this.Disposed )
        throw new BugException( new ObjectDisposedException( null ) );
    return this.TryPullFunc();
}



// -----------------------------------------------------------------------------
// IDisposable
// -----------------------------------------------------------------------------

public
    void
Dispose()
{
    if( this.Disposed ) return;
    this.DisposeFunc();
    this.Disposed = true;
}




} // type
} // namespace

