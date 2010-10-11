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
/// <tt>IInteger</tt> Library
// =============================================================================

public static class
Integer
{



// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// Produce an <tt>IInteger</tt> from a <tt>System.Int32</tt>
///
public static
    IInteger
From(
    int from
)
{
    return new DecimalInteger( from );
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
    NonNull.Require( dis, new Parameter( "dis" ) );
    NonNull.Require( that, new Parameter( "that" ) );
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
    NonNull.Require( dis, new Parameter( "dis" ) );
    NonNull.Require( that, new Parameter( "that" ) );
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
    NonNull.Require( dis, new Parameter( "dis" ) );
    NonNull.Require( that, new Parameter( "that" ) );
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
    throw new System.NotImplementedException();
}




} // type
} // namespace

