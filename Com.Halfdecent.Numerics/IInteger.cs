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
/// An integer
///
/// <tt>http://en.wikipedia.org/wiki/Integer</tt>
// =============================================================================
//
public interface
IInteger
    : IReal
{




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Determine whether this integer is greater than another
///
bool
GT(
    IInteger x
);



/// Determine whether this integer is greater than or equal to another
///
bool
GTE(
    IInteger x
);



/// Determine whether this integer is less than another
///
bool
LT(
    IInteger x
);



/// Determine whether this integer is less than or equal to another
///
bool
LTE(
    IInteger x
);



/// Compute this integer plus another
///
IInteger
Plus(
    IInteger x
);



/// Compute this integer minus another
///
IInteger
Minus(
    IInteger x
);



/// Compute this integer times another
///
IInteger
Times(
    IInteger x
);



/// Compute the remainder when this integer is divided by another
///
IInteger
RemainderWhenDividedBy(
    IInteger x
);



// TODO Integer Div (?)




} // type
} // namespace
