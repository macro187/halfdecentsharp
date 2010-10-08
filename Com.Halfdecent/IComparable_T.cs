// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010
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


namespace
Com.Halfdecent
{


// =============================================================================
/// A type that introduces a new definition of ordering
///
/// Both items are asked how they compare to each other through their
/// respective <tt>DirectionalCompareTo()</tt> methods.  The final result is
/// determined according to the following logic:
///
/// -   If both items agree, the agreed result is used
/// -   If one item says equal and the other says greater or less than,
///     the latter is assumed to be more specific and is used
/// -   If the items return opposite results, an exception is thrown
///
/// Use <tt>Comparable.CompareTo()</tt> to implement
/// <tt>System.IComparable<T>.CompareTo()</tt>.
// =============================================================================

public interface
IComparable<
    T
>
    : IEquatable< T >
    , System.IComparable< T >
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Determine whether this item considers itself less than, equal to, or
/// greater than another
///
    int
    /// @returns
    /// A positive integer if <tt>this</tt> considers itself greater than
    /// <tt>that</tt>
    /// - OR -
    /// 0 if <tt>this</tt> considers itself equal to <tt>that</tt>
    /// - OR -
    /// A negative integer if <tt>this</tt> considers itself less than
    /// <tt>that</tt>
DirectionalCompareTo(
    T that
);




} // type
} // namespace

