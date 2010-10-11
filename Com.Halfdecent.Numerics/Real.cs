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


using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Numerics
{


// =============================================================================
/// <tt>IReal</tt> Library
// =============================================================================

public static class
Real
{



// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// Produce an <tt>IReal</tt> from a <tt>System.Decimal</tt>
///
public static
    IReal
From(
    decimal value
)
{
    return new DecimalReal( value );
}


/// <tt>IReal.DirectionalCompareTo()</tt> implementation
///
public static
    int
DirectionalCompareTo(
    IReal dis,
    IReal that
)
{
    NonNull.Require( dis, new Parameter( "dis" ) );
    if( object.ReferenceEquals( that, null ) ) return 1;
    return dis.GetValue().CompareTo( that.GetValue() );
}


/// <tt>IReal.DirectionalEquals()</tt> implementation
///
public static
    bool
DirectionalEquals(
    IReal dis,
    IReal that
)
{
    NonNull.Require( dis, new Parameter( "dis" ) );
    if( object.ReferenceEquals( that, null ) ) return false;
    return dis.GetValue() == that.GetValue();
}


/// <tt>IReal.GetHashCode()</tt> implementation
///
public static
    int
GetHashCode(
    IReal dis
)
{
    NonNull.Require( dis, new Parameter( "dis" ) );
    return dis.GetValue().GetHashCode();
}



// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

/// Compute this real plus another
///
public static
    IReal
Plus(
    this IReal  dis,
    IReal       that
)
{
    NonNull.Require( dis, new Parameter( "dis" ) );
    NonNull.Require( that, new Parameter( "that" ) );
    return new DecimalReal( dis.GetValue() + that.GetValue() );
}


/// Compute this real minus another
///
public static
    IReal
Minus(
    this IReal  dis,
    IReal       that
)
{
    NonNull.Require( dis, new Parameter( "dis" ) );
    NonNull.Require( that, new Parameter( "that" ) );
    return new DecimalReal( dis.GetValue() - that.GetValue() );
}


/// Compute this real multiplied by another
///
public static
    IReal
Times(
    this IReal  dis,
    IReal       that
)
{
    NonNull.Require( dis, new Parameter( "dis" ) );
    NonNull.Require( that, new Parameter( "that" ) );
    return new DecimalReal( dis.GetValue() * that.GetValue() );
}


/// Compute this real divided by another
///
public static
    IReal
DividedBy(
    this IReal  dis,
    IReal       that
    ///< - <tt>NonZero</tt>
)
{
    NonNull.Require( dis, new Parameter( "dis" ) );
    NonNull.Require( that, new Parameter( "that" ) );
    return new DecimalReal( dis.GetValue() / that.GetValue() );
}


/// Generate the value of this real with the fractional part of it's value
/// discarded
///
public static
    IInteger
Truncate(
    this IReal dis
)
{
    NonNull.Require( dis, new Parameter( "dis" ) );
    return new DecimalInteger( decimal.Truncate( dis.GetValue() ) );
}




} // type
} // namespace

