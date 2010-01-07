// -----------------------------------------------------------------------------
// Copyright (c) 2009
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
Com.Halfdecent
{


// =============================================================================
/// A type that introduces a new definition of equality
// =============================================================================

public interface
IEquatable<
    T
    ///< The type
>
{



/// Determine whether this and another item are equal
///
/// That is, <tt>this</tt> and <tt>that</tt> <tt>DirectionalEquals()</tt> each
/// other.
///
/// This method should be implemented using <tt>Equatable.Equals<T>()</tt>.
///
bool
Equals(
    T that
);


/// Determine whether this item considers itself equal to another
///
bool
DirectionalEquals(
    T that
);


/// Generate a hash code for this item according to this definition of equality
///
/// Subject to the same requirements as <tt>System.Object.GetHashCode()</tt>,
/// specifically:
/// - If <tt>a.Equals( b )</tt> then <tt>a.GetHashCode()</tt> must equal
///   <tt>b.GetHashCode()</tt>.
///
int
GetHashCode();




} // type
} // namespace

