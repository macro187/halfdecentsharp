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




/// An integer
///
/// TODO Wikipedia link to integer
///
public interface
IInteger
    : IReal
    , IComparable< IInteger >
    , IEquatable< IInteger >
{




// -----------------------------------------------------------------------------
#region Methods
// -----------------------------------------------------------------------------

/// Compute whether this integer is greater than another
///
bool            /// @returns Whether this integer is greater than the other
GT(
    IInteger x  ///< The other integer
);



/// Compute whether this integer is greater than or equal to another
///
bool            /// @returns Whether this integer is greater than or equal to the
                /// other
GTE(
    IInteger x  ///< The other integer
);



/// Compute whether this integer is less than another
///
bool            /// @returns Whether this integer is less than or equal to the
                /// other
LT(
    IInteger x  ///< The other integer
);



/// Compute whether this integer is less than or equal to another
///
bool            /// @returns Whether this integer is less than or equal to the
                /// other
LTE(
    IInteger x  ///< The other integer
);



/// Compute this integer plus another
///
IInteger        /// @returns This integer plus the other
Plus(
    IInteger x  ///< The other integer
);



/// Compute this integer minus another
///
IInteger        /// @returns This integer minus the other
Minus(
    IInteger x  ///< The other integer
);



/// Compute this integer times another
///
IInteger        /// @returns This integer times the other
Times(
    IInteger x  ///< The other integer
);



/// Compute this integer divided by another
///
IReal           /// @returns This integer divided by the other
DividedBy(
    IInteger x  ///< The other integer
);



/// Compute the remainder when this integer is divided by another
///
IInteger        /// @returns The remainder when this integer is divided by the
                /// other
RemainderWhenDividedBy(
    IInteger x  ///< The other integer
);



// TODO Integer Div (?)

#endregion




} // type
} // namespace

