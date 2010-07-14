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
/// A stream connected to a filter
// =============================================================================

public class
StreamToFilter<
    TFrom,
    /// < Type of items that the stream yields and that the filter accepts
    TTo
    /// < Type of items that the filter yields
>
    : IStream< TTo >
    , IDisposable
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
StreamToFilter(
    IStream< TFrom >        from,
    bool                    disposeFrom,
    IFilter< TFrom, TTo >   to,
    bool                    disposeTo
)
{
    new NonNull().Check( from, new Parameter( "from" ) );
    new NonNull().Check( to, new Parameter( "to" ) );

    this.From = from;
    this.DisposeFrom = disposeFrom;
    this.To = to;
    this.DisposeTo = disposeTo;

    // Connect
    this.To.From = this.From;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
    IStream< TFrom >
From
{
    get;
    private set;
}


protected
    bool
DisposeFrom
{
    get;
    private set;
}


public
    IFilter< TFrom, TTo >
To
{
    get;
    private set;
}


protected
    bool
DisposeTo
{
    get;
    private set;
}




// -----------------------------------------------------------------------------
// IStream< TTo >
// -----------------------------------------------------------------------------

public
    ITuple< bool, TTo >
TryPull()
{
    return this.To.TryPull();
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


~StreamToFilter()
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
        this.To.From = null;

        // Dispose
        if( this.DisposeFrom && this.From is IDisposable )
            ((IDisposable)this.From).Dispose();
        if( this.DisposeTo && this.To is IDisposable )
            ((IDisposable)this.To).Dispose();
    }
    // (unmanaged)
    this.disposed = true;
}

private bool disposed = false;




} // type
} // namespace

