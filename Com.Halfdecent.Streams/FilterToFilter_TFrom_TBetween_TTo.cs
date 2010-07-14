// -----------------------------------------------------------------------------
// Copyright (c) 2010
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
using Com.Halfdecent;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// A filter connected to a filter
// =============================================================================

public class
FilterToFilter<
    TFrom,
    /// < Type of items that the first filter accepts
    TBetween,
    /// < Type of items that flow between the two filters
    TTo
    /// < Type of items that the second filter yields
>
    : IFilter< TFrom, TTo >
    , IDisposable
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
FilterToFilter(
    IFilter< TFrom, TBetween >  f1,
    bool                        disposeF1,
    IFilter< TBetween, TTo >    f2,
    bool                        disposeF2
)
{
    new NonNull().Check( f1, new Parameter( "f1" ) );
    new NonNull().Check( f2, new Parameter( "f2" ) );

    this.F1 = f1;
    this.DisposeF1 = disposeF1;
    this.F2 = f2;
    this.DisposeF2 = disposeF2;

    // Connect
    this.F1.To = this.F2;
    this.F2.From = this.F1;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

protected
    IFilter< TFrom, TBetween >
F1
{
    get;
    private set;
}


protected
    bool
DisposeF1
{
    get;
    private set;
}


protected
    IFilter< TBetween, TTo >
F2
{
    get;
    private set;
}


protected
    bool
DisposeF2
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// IFilter< TFrom, TTo >
// -----------------------------------------------------------------------------

public
    IStream< TFrom >
From
{
    get { return this.F1.From; }
    set { this.F1.From = value; }
}


public
    ISink< TTo >
To
{
    get { return this.F2.To; }
    set { this.F2.To = value; }
}



// -----------------------------------------------------------------------------
// ISink< TFrom >
// -----------------------------------------------------------------------------

public
    bool
TryPush(
    TFrom item
)
{
    return this.F1.TryPush( item );
}



// -----------------------------------------------------------------------------
// IStream< TTo >
// -----------------------------------------------------------------------------

public
    ITuple< bool, TTo >
TryPull()
{
    return this.F2.TryPull();
}



// -----------------------------------------------------------------------------
// IDisposable
// -----------------------------------------------------------------------------

public
    void
Dispose()
{
    this.Dispose( true );
    GC.SuppressFinalize( this );
}


~FilterToFilter()
{
    this.Dispose( false );
}


protected virtual
    void
Dispose(
    bool disposing
)
{
    if( this.disposed ) return;
    if( disposing ) {
        // (managed)

        // Disconnect
        this.F1.To = null;
        this.F2.From = null;

        // Dispose
        if( this.DisposeF1 && this.F1 is IDisposable )
            ((IDisposable)this.F1).Dispose();
        if( this.DisposeF2 && this.F2 is IDisposable )
            ((IDisposable)this.F2).Dispose();
    }
    // (unmanaged)
    this.disposed = true;
}

private bool disposed = false;




} // type
} // namespace

