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
Com.Halfdecent
{


// =============================================================================
/// A type whose values can be compared for equality
///
/// This improved version of `System.IEquatable<T>` carries its own
/// `IEquatable<T>.GetHashCode()`, allowing types to implement equality +
/// hashcode pairs for more than one interface.
///
/// To conclusively determine equality, _both_ items' `IEquatable<T>.Equals()`
/// must be consulted, because one or the other item may be a subtype with a
/// more specific definition of equality.  A convenient way to do this is
/// `EquatableHD.EqualsBidirectional()`.
///
/// Equatability is contravariant in nature but, for unknown reasons, the BCL
/// designers chose not to make `System.IEquatable<T>` contravariant in `T` - a
/// decision that could be considered a mistake.  Whatever the case,
/// <em>this</em> interface is contravariant in `T` and so, unfortunately,
/// cannot imply `System.IEquatable<T>`.
// =============================================================================

public interface
IEquatableHD<
    #if DOTNET40
    in T
    #else
    T
    #endif
>
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

    bool
Equals(
    T that
);


/// Generate a hash code for this item according to this definition of equality
///
/// Subject to the same requirements as `System.Object.GetHashCode()` with
/// respect to this definition of equality, specifically:
///
/// - If `a.Equals( b )` then `a.GetHashCode()` must equal `b.GetHashCode()`.
///
    int
GetHashCode();




} // type
} // namespace

