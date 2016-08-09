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


using Halfdecent.RTypes;


namespace
Halfdecent.Numerics
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

public static
    IReal
Create(
    decimal value
)
{
    return new DecimalReal( value );
}


public static
    int
Compare(
    IReal x,
    IReal y
)
{
    if( x == null && y == null ) return 0;
    if( x == null ) return -1;
    if( y == null ) return 1;
    if( object.ReferenceEquals( x, y ) ) return 0;
    return x.GetValue().CompareTo( y.GetValue() );
}


public static
    bool
Equals(
    IReal x,
    IReal y
)
{
    if( x == null && y == null ) return true;
    if( x == null || y == null ) return false;
    if( object.ReferenceEquals( x, y ) ) return true;
    return x.GetValue() == y.GetValue();
}


public static
    int
GetHashCode(
    IReal x
)
{
    NonNull.CheckParameter( x, "x" );
    return
        typeof( IReal ).GetHashCode()
        ^ x.GetValue().GetHashCode();
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
    NonNull.CheckParameter( dis, "dis" );
    NonNull.CheckParameter( that, "that" );
    return Create( dis.GetValue() + that.GetValue() );
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
    NonNull.CheckParameter( dis, "dis" );
    NonNull.CheckParameter( that, "that" );
    return Create( dis.GetValue() - that.GetValue() );
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
    NonNull.CheckParameter( dis, "dis" );
    NonNull.CheckParameter( that, "that" );
    return Create( dis.GetValue() * that.GetValue() );
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
    NonNull.CheckParameter( dis, "dis" );
    NonNull.CheckParameter( that, "that" );
    NonZero.CheckParameter( that, "that" );
    return Create( dis.GetValue() / that.GetValue() );
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
    NonNull.CheckParameter( dis, "dis" );
    return new DecimalInteger( decimal.Truncate( dis.GetValue() ) );
}




} // type
} // namespace

