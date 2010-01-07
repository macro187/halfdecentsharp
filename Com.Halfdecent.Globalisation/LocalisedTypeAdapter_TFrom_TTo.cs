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


using System;
using System.Globalization;


namespace
Com.Halfdecent.Globalisation
{


// =============================================================================
/// Localised< T > covariant type adapter
// =============================================================================

public class
LocalisedTypeAdapter<
    TFrom,
    TTo
>
    : Localised< TTo >
    where TFrom : TTo
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
LocalisedTypeAdapter(
    Localised< TFrom > from
)
{
    if( from == null ) throw new ArgumentNullException( "from" );
    this.From = from;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
Localised< TFrom >
From
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// Localised< TTo >
// -----------------------------------------------------------------------------

protected override
    TTo
ForCulture(
    CultureInfo culture
)
{
    return this.From[ culture ];
}




} // type
} // namespace

