// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2011
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


using Halfdecent.Meta;
using Halfdecent.RTypes;


namespace
Halfdecent.Streams
{


// =============================================================================
/// TODO
// =============================================================================

public class
StreamProxy<
    TFrom,
    TTo
>
    : IStream< TTo >
    , IProxy

    where TFrom : TTo
{


public
StreamProxy(
    IStream< TFrom > from
)
{
    NonNull.CheckParameter( from, "from" );
    this.From = from;
}


protected
IStream< TFrom >
From
{
    get;
    private set;
}


public
    IMaybe< TTo >
TryPull()
{
    return this.From.TryPull().Covary< TFrom, TTo >();
}



// -----------------------------------------------------------------------------
// IDisposable
// -----------------------------------------------------------------------------

public
void
Dispose()
{
    this.From.Dispose();
}



// -----------------------------------------------------------------------------
// IProxy
// -----------------------------------------------------------------------------

    object
IProxy.Underlying
{
    get { return this.From; }
}




} // type
} // namespace

