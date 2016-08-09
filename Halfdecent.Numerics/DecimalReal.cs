// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010, 2012
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
using Halfdecent;
using Halfdecent.Meta;
using Halfdecent.RTypes;


namespace
Halfdecent.Numerics
{


// =============================================================================
/// <tt>IReal</tt> implementation using <tt>System.Decimal</tt>
// =============================================================================

internal class
DecimalReal
    : IReal
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialize a new <tt>DecimalReal</tt> from a <tt>System.Decimal</tt> value
///
internal
DecimalReal(
    decimal value
)
{
    this.value = value;
}



// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private
decimal
value;



// -----------------------------------------------------------------------------
// IReal
// -----------------------------------------------------------------------------

public
    decimal
GetValue()
{
    return this.value;
}



// -----------------------------------------------------------------------------
// IComparable< IReal >
// -----------------------------------------------------------------------------

public
    int
CompareTo(
    IReal that
)
{
    return Real.Compare( this, that );
}



// -----------------------------------------------------------------------------
// IEquatable< IReal >
// IEquatableHD< IReal >
// -----------------------------------------------------------------------------

public
    bool
Equals(
    IReal that
)
{
    return Real.Equals( this, that );
}


    int
IEquatableHD<IReal>.GetHashCode()
{
    return Real.GetHashCode( this );
}



// -----------------------------------------------------------------------------
// Object
// -----------------------------------------------------------------------------

public override
    string
ToString()
{
    return this.GetValue().ToString();
}


public override
    bool
Equals(
    object that
)
{
    throw new NotSupportedException();
}


public override
    int
GetHashCode()
{
    throw new NotSupportedException();
}




} // type
} // namespace

