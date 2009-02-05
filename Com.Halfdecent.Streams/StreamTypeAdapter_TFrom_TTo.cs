// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009
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


using System.Collections;
using System.Collections.Generic;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// Covariant <tt>IStream< T ></tt> type adapter
// =============================================================================
//
public class
StreamTypeAdapter<
    TFrom,
    TTo
>
    : StreamBase< TTo >
    where TFrom : TTo
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
StreamTypeAdapter(
    IStream< TFrom > from
)
{
    NonNull.Check( from, new Parameter( "from" ) );
    this.from = from;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
IStream< TFrom >
From
{
    get { return this.from; }
}

private
IStream< TFrom >
from;



// -----------------------------------------------------------------------------
// StreamBase< T >
// -----------------------------------------------------------------------------

public override
bool
TryGet(
    out TTo item
)
{
    bool result;
    TFrom fromitem;
    result = this.from.TryGet( out fromitem );
    item = fromitem;
    return result;
}




//private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

