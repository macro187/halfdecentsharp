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
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// Filter implementation based on a <tt>FilterStepIterator<TIn,TOut></tt> or a
/// <tt>FilterStepFunc<TIn,TOut></tt>
// =============================================================================

public class
Filter<
    TIn,
    TOut
>
    : IFilter< TIn, TOut >
{


public
Filter(
    FilterStepIterator< TIn, TOut > stepIterator,
    FilterStepFunc< TIn, TOut >     stepFunc,
    System.Action                   disposeFunc
)
{
    if( stepIterator == null && stepFunc == null )
        new LocalisedArgumentException(
            _S("stepIterator AND stepFunc are both null") );
    NonNull.CheckParameter( disposeFunc, "disposeFunc" );

    // If we're given an iterator, turn it into a repeatedly-callable
    // FilterStepFunc
    if( stepIterator != null ) {
        SCG.IEnumerator< FilterState > e = null;
        stepFunc =
            (GetState,Get,Put) => {
                if( GetState() == FilterState.NotStarted )
                    e = stepIterator( GetState, Get, Put );
                if( !e.MoveNext() )
                    return FilterState.Closed;
                return e.Current; };
    }

    this.State = FilterState.NotStarted;
    this.StepFunc = stepFunc;
    this.DisposeFunc = disposeFunc;
    this.Disposed = false;
    this.Closing = false;
    this.Step();
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

private
FilterStepFunc< TIn, TOut >
StepFunc;


private
System.Action
DisposeFunc;


private
bool
Disposed;


private
bool
Closing;


private
TIn
inputitem;


private
TOut
outputitem;



// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

/// StepFunc() API: Get current state
///
private
    FilterState
GetState()
{
    if( this.Disposed )
        throw new BugException(
            new System.ObjectDisposedException( null ) );
    return this.State;
}


/// StepFunc() API: Get next input item
///
/// @exception BugException
/// <tt>.State != Want</tt>
///
private
    TIn
Get()
{
    if( this.Disposed )
        throw new BugException(
            new System.ObjectDisposedException( null ) );
    if( this.State != FilterState.Want )
        throw new BugException(
            new LocalisedInvalidOperationException(
                _S("State must be Want in order to Get()") ) );
    return this.inputitem;
}


/// StepFunc() API: Yield an output item
///
private
    void
Put( TOut item )
{
    if( this.Disposed )
        throw new BugException(
            new System.ObjectDisposedException( null ) );
    this.outputitem = item;
}


private
    void
Step()
{
    FilterState newstate = this.StepFunc( this.GetState, this.Get, this.Put );

    if( newstate == null )
        throw new BugException(
            new LocalisedInvalidOperationException(
                _S("StepFunc returned null") ) );

    if( newstate == FilterState.NotStarted )
        throw new BugException(
            new LocalisedInvalidOperationException(
                _S("StepFunc tried to move to NotStarted") ) );

    if( this.State == FilterState.NotStarted )
        if( newstate != FilterState.Want && newstate != FilterState.Closed )
            throw new BugException(
                new LocalisedInvalidOperationException(
                    _S("StepFunc tried to move to {0} on first step", newstate) ) );

    if( this.State == FilterState.Closed )
        if( newstate != FilterState.Have && newstate != FilterState.Closed )
            throw new BugException(
                new LocalisedInvalidOperationException(
                    _S("StepFunc tried to move from Closed to {0}", newstate) ) );

    if( this.State == FilterState.Have && this.Closing )
        if( newstate != FilterState.Have && newstate != FilterState.Closed )
            throw new BugException(
                new LocalisedInvalidOperationException(
                    _S("StepFunc tried to move to {0} while closing", newstate) ) );

    this.State = newstate;
}



// -----------------------------------------------------------------------------
// IFilter< TIn, TOut >
// -----------------------------------------------------------------------------

public
FilterState
State
{
    get;
    private set;
}


public
    void
Give(
    TIn item
)
{
    if( this.Disposed )
        throw new BugException(
            new System.ObjectDisposedException( null ) );
    if( this.State != FilterState.Want )
        throw new LocalisedInvalidOperationException(
            _S(".State must be Want in order to Give()") );
    this.inputitem = item;
    this.Step();
}


public
    TOut
Peek()
{
    if( this.Disposed )
        throw new BugException(
            new System.ObjectDisposedException( null ) );
    if( this.State != FilterState.Have )
        throw new LocalisedInvalidOperationException(
            _S(".State must be Have in order to Peek()") );
    return this.outputitem;
}


public
    TOut
Take()
{
    if( this.Disposed )
        throw new BugException(
            new System.ObjectDisposedException( null ) );
    if( this.State != FilterState.Have )
        throw new LocalisedInvalidOperationException(
            _S(".State must be Have in order to Take()") );
    TOut item = this.outputitem;
    this.Step();
    return item;
}


public
    void
Close()
{
    if( this.Disposed )
        throw new BugException(
            new System.ObjectDisposedException( null ) );
    if( this.State != FilterState.Want )
        throw new LocalisedInvalidOperationException(
            _S(".State must be Want in order to Close()") );
    this.State = FilterState.Closed;
    this.Closing = true;
    this.Step();
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

