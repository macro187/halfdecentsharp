// -----------------------------------------------------------------------------
// Copyright (c) 2011
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


using Com.Halfdecent;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// A sink based on an <tt>ISink<T>.TryPush()</tt> function
// =============================================================================

public class
Sink<
    T
>
    : ISink< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
Sink(
    System.Action< T >  pushFunc,
    System.Action       disposeFunc
)
    : this(
        item => {
            pushFunc( item );
            return true; },
        disposeFunc )
{
    NonNull.CheckParameter( pushFunc, "pushFunc" );
}


public
Sink(
    System.Func< bool > canPushFunc,
    System.Action< T >  pushFunc,
    System.Action       disposeFunc
)
    : this(
        item => {
            if( canPushFunc() ) {
                pushFunc( item );
                return true;
            } else {
                return false;
            } },
        disposeFunc )
{
    NonNull.CheckParameter( canPushFunc, "canPushFunc" );
    NonNull.CheckParameter( pushFunc, "pushFunc" );
}


public
Sink(
    System.Func< T, bool >  tryPushFunc,
    System.Action           disposeFunc
)
{
    NonNull.CheckParameter( tryPushFunc, "tryPushFunc" );
    NonNull.CheckParameter( disposeFunc, "disposeFunc" );
    this.TryPushFunc = tryPushFunc;
    this.DisposeFunc = disposeFunc;
    this.Disposed = false;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

private
System.Func< T, bool >
TryPushFunc;


private
System.Action
DisposeFunc;


private
bool
Disposed;



// -----------------------------------------------------------------------------
// ISink< T >
// -----------------------------------------------------------------------------

public
    bool
TryPush(
    T item
)
{
    if( this.Disposed )
        throw new BugException(
            new System.ObjectDisposedException( null ) );
    return this.TryPushFunc( item );
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

