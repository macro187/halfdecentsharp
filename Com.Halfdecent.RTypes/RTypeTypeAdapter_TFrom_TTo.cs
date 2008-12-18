// -----------------------------------------------------------------------------
// Copyright (c) 2008 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// RType< T > contravariant type adapter
// =============================================================================
//
public class
RTypeTypeAdapter<
    TFrom,
    TTo
>
    : IRType< TTo >
    where TTo : TFrom
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
RTypeTypeAdapter(
    IRType< TFrom > from
)
{
    NonNull.SCheck( from, new Parameter( "from" ) );
    this.from = from;
}

private
IRType< TFrom >
from;




// -----------------------------------------------------------------------------
// IRType< T >
// -----------------------------------------------------------------------------

public
void
Check(
    TTo     item,
    IValue  itemReference
)
{
    this.from.Check( item, itemReference );
}



public
IEnumerable< IRType< TTo > >
Supers
{
    get
    {
        foreach( IRType< TFrom > s in from.Supers )
            yield return new RTypeTypeAdapter< TFrom, TTo >( s );
    }
}



public
IEnumerable< IRType< TTo > >
Components
{
    get
    {
        foreach( IRType< TFrom > c in from.Components )
            yield return new RTypeTypeAdapter< TFrom, TTo >( c );
    }
}



public
Localised< string >
SayIs(
    Localised< string > reference
)
{
    return from.SayIs( reference );
}



public
Localised< string >
SayIsNot(
    Localised< string > reference
)
{
    return from.SayIsNot( reference );
}



public
Localised< string >
SayMustBe(
    Localised< string > reference
)
{
    return from.SayMustBe( reference );
}




} // type
} // namespace

