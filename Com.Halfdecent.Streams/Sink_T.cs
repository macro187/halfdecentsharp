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


using SCG = System.Collections.Generic;
using Com.Halfdecent;
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// A sink based on a <tt>SinkPushIterator< T ></tt>
// =============================================================================

public class
Sink<
    T
>
    : ISink< T >
{


public
Sink(
    SinkPushIterator< T >   pushIterator,
    System.Action           disposeFunc
)
{
    NonNull.CheckParameter( pushIterator, "pushIterator" );
    NonNull.CheckParameter( disposeFunc, "disposeFunc" );
    this.PushEnumerator = pushIterator( this.Get );
    this.NextItem = default( T );
    this.NextItemReady = false;
    this.Open = true;
    this.DisposeFunc = disposeFunc;
    this.Disposed = false;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

private
T
NextItem;


private
bool
NextItemReady;


private
    T
Get()
{
    if( !this.NextItemReady )
        throw new BugException(
            new LocalisedInvalidOperationException(
                _S( "SinkPushIterator called get() before the next item was ready" ) ) );
    this.NextItemReady = false;
    return this.NextItem;
}


private
SCG.IEnumerator< object >
PushEnumerator;


private
bool
Open;


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
    if( !this.Open ) return false;
    this.NextItem = item;
    this.NextItemReady = true;
    this.Open = this.PushEnumerator.MoveNext();
    return this.Open;
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




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

