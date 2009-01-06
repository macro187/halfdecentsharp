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
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Meta;

namespace
Com.Halfdecent.Numerics
{

// =============================================================================
/// <tt>IReal</tt> implementation using <tt>System.Decimal</tt>
// =============================================================================
//
internal class
DecimalReal
    : IReal
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Copy constructor
///
public
DecimalReal(
    IReal r
)
{
    NonNull.SCheck( r, new Parameter( "r" ) );
    this.value = r.ToDecimal();
}



/// Initialize a new <tt>DecimalReal</tt> with a <tt>System.Decimal</tt> value
///
public
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

public decimal ToDecimal() { return this.value; }

public bool GT( IReal r) { return ( this.CompareTo( r ) > 0 ); }

public bool GTE( IReal r ) { return ( this.CompareTo( r ) >= 0 ); }

public bool LT( IReal r ) { return ( this.CompareTo( r ) < 0 ); }

public bool LTE( IReal r ) { return ( this.CompareTo( r ) <= 0 ); }

public IReal Plus( IReal r )
{
    return new DecimalReal( this.value + r.ToDecimal() );
}

public IReal Minus( IReal r )
{
    return new DecimalReal( this.value - r.ToDecimal() );
}

public IReal Times( IReal r )
{
    return new DecimalReal( this.value * r.ToDecimal() );
}

public IReal DividedBy( IReal r )
{
    new NonZero<IReal>().Check( r, new Parameter( "r" ) );
    return new DecimalReal( this.value / r.ToDecimal() );
}

public IReal RemainderWhenDividedBy( IReal r )
{
    new NonZero<IReal>().Check( r, new Parameter( "r" ) );
    return new DecimalReal( Decimal.Remainder( this.value, r.ToDecimal() ) );
}

public IReal Truncate()
{
    return new DecimalReal( Decimal.Truncate( this.value ) );
}




// -----------------------------------------------------------------------------
// System.IComparable< IReal >
// -----------------------------------------------------------------------------

public
int
CompareTo(
    IReal r
)
{
    return this.value.CompareTo( r.ToDecimal() );
}




// -----------------------------------------------------------------------------
// System.IEquatable< IReal >
// -----------------------------------------------------------------------------

public
bool
Equals(
    IReal r
)
{
    return ( this.value == r.ToDecimal() );
}




// -----------------------------------------------------------------------------
// System.Object
// -----------------------------------------------------------------------------

public override
bool
Equals(
    object obj
)
{
    bool result = false;
    IReal r = obj as IReal;
    if( r != null ) {
        result = this.Equals( r );
    }
    return result;
}



public override
string
ToString()
{
    return this.value.ToString();
}



public override
int
GetHashCode()
{
    return this.value.GetHashCode();
}




} // type
} // namespace

