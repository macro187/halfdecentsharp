// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010, 2011
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
/// A stream based on a <tt>TryPull()</tt> function
// =============================================================================

public class
Stream<
    T
>
    : IStream< T >
{


// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
Stream(
    System.Func< bool > canPullFunc,
    System.Func< T >    pullFunc,
    System.Action       disposeFunc
)
    : this(
        () =>
            canPullFunc()
                ? Tuple.Create( true, pullFunc() )
                : Tuple.Create( false, default( T ) ),
        disposeFunc )
{
    NonNull.CheckParameter( canPullFunc, "canPullFunc" );
    NonNull.CheckParameter( pullFunc, "pullFunc" );
}


public
Stream(
    Maybe< T >      maybeFunc,
    System.Action   disposeFunc
)
    : this(
        () => {
            T r;
            return maybeFunc( out r )
                ? Tuple.Create( true, r )
                : Tuple.Create( false, default( T ) ); },
        disposeFunc )
{
    NonNull.CheckParameter( maybeFunc, "maybeFunc" );
}


public
Stream(
    System.Func< ITuple< bool, T > >    tryPullFunc,
    System.Action                       disposeFunc
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
System.Func< ITuple< bool, T > >
TryPullFunc;


private
System.Action
DisposeFunc;


private
bool
Disposed;



// -----------------------------------------------------------------------------
// IStream< T >
// -----------------------------------------------------------------------------

public
    ITuple< bool, T >
TryPull()
{
    if( this.Disposed )
        throw new BugException(
            new System.ObjectDisposedException( null ) );
    return this.TryPullFunc();
}



// -----------------------------------------------------------------------------
// System.IDisposable
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

