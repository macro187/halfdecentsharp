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
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Numerics
{


// =============================================================================
/// <tt>IInteger</tt> implementation using <tt>System.Decimal</tt>
// =============================================================================

internal class
DecimalInteger
    : DecimalReal
    , IInteger
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Narrowing conversion from <tt>IReal</tt>
///
public
DecimalInteger(
    IReal value
)
    : base( value )
{
    new NonFractional().Check( value, new Parameter( "value" ) );
}




// -----------------------------------------------------------------------------
// IInteger
// -----------------------------------------------------------------------------

public
IInteger
Plus(
    IInteger i
)
{
    return new DecimalInteger( base.Plus( i ) );
}


public
IInteger
Minus(
    IInteger i
)
{
    return new DecimalInteger( base.Minus( i ) );
}


public
IInteger
Times(
    IInteger i
)
{
    return new DecimalInteger( base.Times( i ) );
}


public
IInteger
RemainderWhenDividedBy(
    IInteger i
)
{
    return new DecimalInteger( base.RemainderWhenDividedBy( i ) );
}



// -----------------------------------------------------------------------------
// System.IComparable< IInteger >
// -----------------------------------------------------------------------------

public
int
CompareTo(
    IInteger i
)
{
    return this.CompareTo( (IReal)i );
}



// -----------------------------------------------------------------------------
// System.IEquatable< IInteger >
// -----------------------------------------------------------------------------

public
bool
Equals(
    IInteger i
)
{
    return this.Equals( (IReal)i );
}




} // type
} // namespace

