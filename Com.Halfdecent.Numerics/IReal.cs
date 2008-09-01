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

namespace
Com.Halfdecent.Numerics
{

// =============================================================================
/// A real number
///
/// TODO: The term "real" is used loosely here.  The idea is to (eventually)
///       have a more rigorous numeric tower of types.
// =============================================================================
//
public interface
IReal
    : IComparable< IReal >
    , IEquatable< IReal >
{




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// "Narrowing" conversion to <tt>System.Decimal</tt>
///
/// TODO: Is this right?
/// @exception HDInvalidOperationException
/// If this Real's value is out of Decimal range
///
decimal
/// @returns A <tt>System.Decimal</tt> with the same value as this real
ToDecimal();



/// Determine whether this real is greater than another
///
bool
GT(
    IReal x
);



/// Determine whether this real is greater than or equal to another
///
bool
GTE(
    IReal x
);



/// Determine whether this real is less than another
///
bool
LT(
    IReal x
);



/// Determine whether this real is less than or equal to another
///
bool
LTE(
    IReal x
);



/// Compute this real plus another
///
IReal
Plus(
    IReal x
);



/// Compute this real minus another
///
IReal
Minus(
    IReal x
);



/// Compute this real times another
///
IReal
Times(
    IReal x
);



/// Compute this real divided by another
///
IReal
DividedBy(
    IReal x
    ///< The other real
    ///  - NonZero
);



/// Generate the value of this real with the fractional part of it's value
/// discarded
///
IReal
Truncate();




} // type
} // namespace

