// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010
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


// =============================================================================
/// Numbers and arithmetic
///
///
/// @section problem Problem
///
///     -   There are no abstract numeric types in the Base Class Library.
///         When modelling entities that have nothing to do with computers,
///         programmers are still forced to choose from a bunch of
///         machine-specific numeric types.
///
///     -   The Base Class Library numeric types have nothing in common from a
///         type perspective, even though they're clearly related.  Among other
///         things, this makes it impossible to create generic numeric
///         algorithms that work with more than one numeric type.
///
///
/// @section solution Solution
///
///     -   Abstract numeric types
///         (see <tt>http://en.wikipedia.org/wiki/Numerical_tower</tt>)
///         - <tt>IReal</tt>
///         - <tt>IInteger</tt>
///
///     -   Implementations using <tt>System.Decimal</tt>
///         - <tt>DecimalReal</tt>
///         - <tt>DecimalInteger</tt>
///
///     -   RTypes
///         - <tt>NonZero</tt>
///         - <tt>NonNegative</tt>
///         - <tt>NonFractional</tt>
///
///     -   Base class library numeric type range RTypes
///         - <tt>InDecimalRange</tt>
///         - <tt>InUInt64Range</tt>
///         - <tt>InInt64Range</tt>
///         - <tt>InUInt32Range</tt>
///         - <tt>InInt32Range</tt>
///         - <tt>InUInt16Range</tt>
///         - <tt>InInt16Range</tt>
///         - <tt>InByteRange</tt>
///         - <tt>InSByteRange</tt>
///
///
// =============================================================================

namespace
Halfdecent.Numerics
{
}

