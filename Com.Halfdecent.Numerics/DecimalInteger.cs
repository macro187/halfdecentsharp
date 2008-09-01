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

namespace
Com.Halfdecent.Numerics
{

// =============================================================================
/// <tt>IInteger</tt> implementation using <tt>System.Decimal</tt>
// =============================================================================
//
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
    // TODO Check for no fractional value using a new RType
}




// -----------------------------------------------------------------------------
// IInteger
// -----------------------------------------------------------------------------

public bool GT( IInteger i ) { return base.GT( i ); }

public bool GTE( IInteger i ) { return base.GTE( i ); }

public bool LT( IInteger i ) { return base.LT( i ); }

public bool LTE( IInteger i ) { return base.LTE( i ); }

public IInteger Plus( IInteger i )
{
    return new DecimalInteger( base.Plus( i ) );
}

public IInteger Minus( IInteger i )
{
    return new DecimalInteger( base.Minus( i ) );
}

public IInteger Times( IInteger i )
{
    return new DecimalInteger( base.Times( i ) );
}

/*
public IReal DividedBy( IReal r )
{
    // TODO NonZero
    return new DecimalReal( this.value / r.ToDecimal() );
}
*/

public IInteger RemainderWhenDividedBy( IInteger i )
{
    return new DecimalInteger( base.RemainderWhenDividedBy( i ) );
}

/*
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
*/




} // type
} // namespace

