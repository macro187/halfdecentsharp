// -----------------------------------------------------------------------------
// Copyright (c) 2007 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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




/// A real number
///
/// TODO Wikipedia link to real
///
public interface
IReal
    : IComparable< IReal >
    , IEquatable< IReal >
{




// -----------------------------------------------------------------------------
#region Methods
// -----------------------------------------------------------------------------

/// "Narrowing" conversion to <tt>System.Decimal</tt>
///
/// TODO: Is this right?
/// @exception HDInvalidOperationException
/// If this Real's value is out of Decimal range
///
decimal /// @returns A <tt>System.Decimal</tt> with the same value as this real
ToDecimal();



/// Compute whether this real is greater than another
///
bool        /// @returns Whether this real is greater than the other
GT(
    IReal x ///< The other real
);



/// Compute whether this real is greater than or equal to another
///
bool        /// @returns Whether this real is greater than or equal to the other
GTE(
    IReal x ///< The other real
);



/// Compute whether this real is less than another
///
bool        /// @returns Whether this real is less than or equal to the other
LT(
    IReal x ///< The other real
);



/// Compute whether this real is less than or equal to another
///
bool        /// @returns Whether this real is less than or equal to the other
LTE(
    IReal x ///< The other real
);



/// Compute this real plus another
///
IReal       /// @returns This real plus the other
Plus(
    IReal x ///< The other real
);



/// Compute this real minus another
///
IReal       /// @returns This real minus the other
Minus(
    IReal x ///< The other real
);



/// Compute this real times another
///
IReal       /// @returns This real times the other
Times(
    IReal x ///< The other real
);



/// Compute this real divided by another
///
IReal       /// @returns This real divided by the other
DividedBy(
    IReal x ///< The other real
            ///  - Must not be zero
);



/*
/// Compute the remainder when this real is divided by another
///
IReal       /// @returns The remainder when this real is divided by the other
RemainderWhenDividedBy(
    IReal x ///< The other real
            ///  - Must not be zero
);
*/



/// Generate the value of this real with the fractional part of it's value
/// discarded
///
IReal
Truncate();

#endregion




} // type
} // namespace

