// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010, 2011, 2012
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


namespace
Halfdecent
{


// =============================================================================
/// An exception indicating that two objects' `IComparable<T>.CompareTo()`
/// implementations completely disagreed with one another
// =============================================================================

public class
ComparisonDisagreementException
    : Exception
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
ComparisonDisagreementException(
    Type    comparableType,
    ///< The type of comparison involved, ie. the `IComparable<T>` type
    Type    thisType,
    ///< The type of the object on the `this` side of the comparison
    object  thisValue,
    ///< The value of the object on the `this` side of the comparison
    int     thisResult,
    ///< The comparison result from the `this` side of the comparison
    Type    thatType,
    ///< The type of the object on the `that` side of the comparison
    object  thatValue,
    ///< The value of the object on the `that` side of the comparison
    int     thatResult
    ///< The comparison result from the `that` side of the comparison
)
    : base(
        string.Format(
            "There was a disagreement in '{0}' comparison between " +
            "{1} '{2}' (which said '{3}'), and {4} '{5}' (which said '{6}'), " +
            "meaning there is a problem with one or both of their " +
            "IComparable<T>.CompareTo() implementations",
            comparableType.FullName,
            thisType.FullName,
            SystemObject.ToString( thisValue ),
            thisResult,
            thatType.FullName,
            SystemObject.ToString( thatValue ),
            thatResult ) )
{
}




} // type
} // namespace

