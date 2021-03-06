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


namespace
Halfdecent.Numerics
{


// =============================================================================
/// A real number
///
/// TODO: The term "real" is used loosely here.  The idea is to (eventually)
///       have a more rigorous numeric tower of types.
// =============================================================================

public interface
IReal
    : IComparable< IReal >
    , IComparableHD< IReal >
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Conversion to <tt>System.Decimal</tt>
///
/// @exception OverflowException
/// This real's value is greater than <tt>System.Decimal.MaxValue</tt>
/// - OR -
/// This real's value is less than <tt>System.Decimal.MinValue</tt>
///
//  XXX: Should use a proper bignum type for this
//
    decimal
    /// @returns
    /// A decimal with the same value as this real
GetValue();




} // type
} // namespace

