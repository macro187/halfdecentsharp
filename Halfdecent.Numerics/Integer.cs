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
using Halfdecent.Meta;
using Halfdecent.RTypes;


namespace
Halfdecent.Numerics
{


// =============================================================================
/// <tt>IInteger</tt> Library
// =============================================================================

public static class
Integer
{



// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

public static
    IInteger
Create(
    IReal value
    ///< - <tt>NonNull</tt>
    ///  - <tt>NonFractional</tt>
)
{
    NonNull.CheckParameter( value, "value" );
    NonFractional.CheckParameter( value, "value" );
    return new DecimalInteger( value.GetValue() );
}


public static
    IInteger
Create(
    decimal value
    ///< - Must be an integer value
)
{
    return Create( Real.Create( value ) );
}


public static
    IInteger
Create(
    long value
)
{
    return Create( (decimal)value );
}



// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

/// Compute this integer plus another
///
public static
    IInteger
Plus(
    this IInteger   dis,
    IInteger        that
)
{
    NonNull.CheckParameter( dis, "dis" );
    NonNull.CheckParameter( that, "that" );
    return ((IReal)dis).Plus( that ).Truncate();
}


/// Compute this integer minus another
///
public static
    IInteger
Minus(
    this IInteger   dis,
    IInteger        that
)
{
    NonNull.CheckParameter( dis, "dis" );
    NonNull.CheckParameter( that, "that" );
    return ((IReal)dis).Minus( that ).Truncate();
}


/// Compute this integer multiplied by another
///
public static
    IInteger
Times(
    this IInteger   dis,
    IInteger        that
)
{
    NonNull.CheckParameter( dis, "dis" );
    NonNull.CheckParameter( that, "that" );
    return ((IReal)dis).Times( that ).Truncate();
}


/// Compute the remainder when this integer is divided by another
///
public static
    IInteger
RemainderWhenDividedBy(
    this IInteger   dis,
    IInteger        that
)
{
    // TODO
    throw new NotImplementedException();
}




} // type
} // namespace

