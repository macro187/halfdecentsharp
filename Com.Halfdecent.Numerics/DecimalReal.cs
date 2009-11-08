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
using Com.Halfdecent.Exceptions;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Numerics
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

/// Copy constructor
///
public
DecimalReal(
    IReal r
)
{
    new NonNull().Check( r, new Parameter( "r" ) );
    this.Value = r.ToDecimal();
}


/// Initialize a new <tt>DecimalReal</tt> with a <tt>System.Decimal</tt> value
///
public
DecimalReal(
    decimal value
)
{
    this.Value = value;
}



// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private
decimal
Value
{
    get;
    set;
}



// -----------------------------------------------------------------------------
// IReal
// -----------------------------------------------------------------------------

public decimal ToDecimal() { return this.Value; }

public bool GT( IReal r) { return ( this.CompareTo( r ) > 0 ); }

public bool GTE( IReal r ) { return ( this.CompareTo( r ) >= 0 ); }

public bool LT( IReal r ) { return ( this.CompareTo( r ) < 0 ); }

public bool LTE( IReal r ) { return ( this.CompareTo( r ) <= 0 ); }

public IReal Plus( IReal r )
{
    return new DecimalReal( this.Value + r.ToDecimal() );
}

public IReal Minus( IReal r )
{
    return new DecimalReal( this.Value - r.ToDecimal() );
}

public IReal Times( IReal r )
{
    return new DecimalReal( this.Value * r.ToDecimal() );
}

public IReal DividedBy( IReal r )
{
    new NonZero().Check( r, new Parameter( "r" ) );
    return new DecimalReal( this.Value / r.ToDecimal() );
}

public IReal RemainderWhenDividedBy( IReal r )
{
    new NonZero().Check( r, new Parameter( "r" ) );
    return new DecimalReal( Decimal.Remainder( this.Value, r.ToDecimal() ) );
}

public IReal Truncate()
{
    return new DecimalReal( Decimal.Truncate( this.Value ) );
}



// -----------------------------------------------------------------------------
// System.IComparable
// -----------------------------------------------------------------------------

public
int
CompareTo(
    object obj
)
{
    if( obj == null ) return 1;
    if( !( obj is IReal ) )
        throw new ValueArgumentException(
            new Parameter( "obj" ),
            _S("{0} is not an IReal") );
    return this.Value.CompareTo( ((IReal)obj).ToDecimal() );
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
    if( obj == null ) return false;
    if( !( obj is IReal ) ) return false;
    return ( this.Value == ((IReal)obj).ToDecimal() );
}


public override
string
ToString()
{
    return this.Value.ToString();
}


public override
int
GetHashCode()
{
    return this.Value.GetHashCode();
}




private static global::Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return global::Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

