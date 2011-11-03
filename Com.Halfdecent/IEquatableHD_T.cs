// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010, 2011
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
/// A type whose values have an inherent notion of equality
///
/// This enhanced <tt>IEquatable<T></tt> carries its own <tt>GetHashCode()</tt>,
/// allowing types to implement equality/hashcode for more than one interface.
///
/// Note that to conclusively determine equality, <em>both</em> items'
/// <tt>IEquatable<T>.Equals()</tt> must be consulted.  The reason is that the
/// other item may be a subtype with a more specific definition of equality.
//
//  [TODO reference to convenience method for above]
//
// =============================================================================

public interface
IEquatableHD<
    T
>
    : IEquatable< T >
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Generate a hash code for this item according to this definition of equality
///
/// Subject to the same requirements as <tt>System.Object.GetHashCode()</tt>
/// with respect to this definition of equality, specifically:
///
/// - If <tt>a.Equals( b )</tt> then <tt>a.GetHashCode()</tt> must equal
///   <tt>b.GetHashCode()</tt>.
///
    int
GetHashCode();




} // type
} // namespace

