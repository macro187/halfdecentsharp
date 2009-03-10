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
using System.Collections.Generic;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Exceptions;


namespace
Com.Halfdecent.Filters
{


// =============================================================================
/// Base class for implementing filters
///
/// TODO Document ownership, ie. who Disposes() elements?  When? (actually a
///      Sink issue)
/// TODO Issues to do with multithreaded pipelines
// =============================================================================

public abstract class
FilterBase<
    TIn,
    TOut
>
    : IFilter< TIn, TOut >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
FilterBase()
{
    this.process = Process();
    this.Tick();
    if( this.process.Current == true ) throw new BugException(
        "Process() says it has produced an before having consumed any" );
}



// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private
IEnumerator< bool >
process = null;


private
TIn
initem;


private
bool
haveinitem = false;


private
TOut
outitem;


private
bool
haveoutitem = false;



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Processing kernel
///
/// The simplest filters are 1-to-1 filters where one input item always yields
/// one output item.
///
/// In addition, some scenarios call for one-to-many and many-to-one filters,
/// where a single input item yields multiple output items or vice-versa.*
/// These kinds of filters are more difficult to implement because the
/// processing routine must be interruptible mid-execution to process
/// additional input (or output) items.
///
/// * Note that in many cases, one-to-many or many-to-one filters can be
///   reduced to simpler 1-to-1 filters by designing them to process blocks of
///   items as individual collections and relying on external
///   blocking/deblocking filters.  This can be applicable especially if the
///   blocks are fixed-size or separated by easy-to-recognise delimiters.
///
/// TODO Detailed Process() API documentation
/// - Consume an item...
///   <tt>yield return false<tt> then <tt>this.GetItem()</tt>
/// - Dispose an item...
///   <tt>this.DisposeItem()</tt>
/// - Produce an item...
///   <tt>this.PutItem()</tt> then <tt>yield return true</tt>
/// - Finish processing and close the filter, allowing no more items through
///   ever again...
///   Exit the iterator
///
protected abstract
IEnumerator< bool >
Process();


/// <tt>Process()</tt> API: Consume an item
///
/// Must immediately follow <tt>yield return false</tt>
///
protected
TIn
GetItem()
{
    if( !this.haveinitem ) throw new BugException(
        _S( "GetItem() called when !haveinitem, Process() implementation probably forgot to 'yield return false' before calling" ) );
    TIn r = this.initem;
    this.initem = default( TIn );
    this.haveinitem = false;
    return r;
}


/// <tt>Process()</tt> API: Produce an item
///
/// Must be immediately followed by <tt>yield return true</tt>
///
protected
void
PutItem(
    TOut item
)
{
    if( this.haveoutitem ) throw new BugException(
        _S( "PutItem() called when haveoutitem, Process() implementation probably forgot to 'yield return true' following last PutItem() call" ) );
    this.outitem = item;
    this.haveoutitem = true;
}


/// <tt>Process()</tt> API: Dispose of an item as necessary
///
/// This method MUST be called for all items not passing through the filter as
/// output after use.
///
protected
void
DisposeItem(
    TIn item
)
{
    IDisposable d = item as IDisposable;
    if( d != null ) d.Dispose();
}


private
void
Tick()
{
    if( this.process == null ) throw new InvalidOperationException(
        "Process() has already exited, can't Tick()" );

    if( !this.process.MoveNext() ) {
        this.process = null;
        // TODO Check end-of-processing invariants?
        return;
    }

    if( !this.process.Current && this.haveinitem ) throw new BugException(
        _S("Process() asked for another item before GetItem()ing the last one") );
    if( this.process.Current && !this.haveoutitem ) throw new BugException(
        _S("Process() says it produced an item but didn't PutItem() it") );
}


private
void
GiveToProcess(
    TIn item
)
{
    this.initem = item;
    this.haveinitem = true;
}


private
TOut
PeekFromProcess()
{
    return this.outitem;
}


private
void
AcceptFromProcess()
{
    this.outitem = default( TOut );
    this.haveoutitem = false;
}



// -----------------------------------------------------------------------------
// IFilter< TIn, TOut >
// -----------------------------------------------------------------------------

/// Upstream stream
///
public
IStream< TIn >
From
{
    get { return this.from; }
    set { this.from = value; }
}
private
IStream< TIn >
from = null;


/// Downstream sink
///
/// When set, an immediate attempt is made to flush any pending items to the
/// new sink
///
public
ISink< TOut >
To
{
    get { return this.to; }
    set
    {
        this.to = value;
        if( value == null ) return;
        for( ;; ) {
            if( this.process == null ) return;
            if( !this.process.Current ) return;
            if( !this.To.TryPush( this.PeekFromProcess() ) ) return;
            this.AcceptFromProcess();
            this.Tick();
        }
    }
}
private
ISink< TOut >
to = null;



// -----------------------------------------------------------------------------
// ISink< TIn >
// IStream< TOut >
// -----------------------------------------------------------------------------

public
bool
TryPush(
    TIn item
)
{
    if( this.To == null ) throw new InvalidOperationException(
        "this.To must be set before items can be pushed" );

    bool itemgiven = false;
    for( ;; ) {

        // Process() is done
        if( this.process == null ) return itemgiven;

        // Process() wants an item
        if( !this.process.Current ) {
            if( itemgiven ) return true;
            this.GiveToProcess( item );
            itemgiven = true;

        // Process() has produced an item
        } else {
            if( !this.To.TryPush( this.PeekFromProcess() ) ) return itemgiven;
            this.AcceptFromProcess();

        }

        this.Tick();
    }
}


public
bool
TryPull(
    out TOut item
)
{
    if( this.From == null ) throw new InvalidOperationException(
        "this.From must be set before items can be pulled" );

    item = default( TOut );
    for( ;; ) {

        // Process() is done
        if( this.process == null ) return false;

        // Process() has produced an item
        if( this.process.Current ) {
            item = this.PeekFromProcess();
            this.AcceptFromProcess();
            this.Tick();
            return true;

        // Process() wants an item
        } else {
            TIn i;
            if( !this.From.TryPull( out i ) ) return false;
            this.GiveToProcess( i );

        }

        this.Tick();
    }
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

