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
/// A type whose values have an inherent notion of order
///
/// This enhanced <tt>IComparable<T></tt> implies <tt>IEquatableHD<T></tt>
/// because comparability implies equatability.
///
/// Note that to compare conclusively, <em>both</em> items'
/// <tt>IComparable<T>.CompareTo()</tt> must be consulted.  The reason is that
/// the other item may be a subtype with a more specific comparison definition.
//
//  [TODO reference to convenience method for above]
//
// =============================================================================

public interface
IComparableHD<
    T
>
    : IComparable< T >
    , IEquatableHD< T >
{




} // type
} // namespace

