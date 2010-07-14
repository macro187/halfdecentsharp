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
    IStream< TFrom >        s,
    bool                    disposeS,
    IFilter< TFrom, TTo >   f,
    bool                    disposeF
)
{
    new NonNull().Check( s, new Parameter( "s" ) );
    new NonNull().Check( f, new Parameter( "f" ) );

    this.S = s;
    this.DisposeS = disposeS;
    this.F = f;
    this.DisposeF = disposeF;

    // Connect
    this.F.From = this.S;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

protected
    IStream< TFrom >
S
{
    get;
    private set;
}


protected
    bool
DisposeS
{
    get;
    private set;
}


protected
    IFilter< TFrom, TTo >
F
{
    get;
    private set;
}


protected
    bool
DisposeF
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
    return this.F.TryPull();
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
        this.F.From = null;

        // Dispose
        if( this.DisposeS && this.S is IDisposable )
            ((IDisposable)this.S).Dispose();
        if( this.DisposeF && this.F is IDisposable )
            ((IDisposable)this.F).Dispose();
    }
    // (unmanaged)
    this.disposed = true;
}

private bool disposed = false;




} // type
} // namespace

