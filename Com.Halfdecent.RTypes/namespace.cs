// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009
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
/// Composable value checks
///
/// RTypes occupy the space between programming langage types and ad-hoc
/// value checking.
///
/// TODO
///
/// Correct equality implementation is crucial for RTypes so that matching (eg.
/// in <tt>catch</tt> blocks) works.  The default implementation provided by
/// <tt>RTypeBase< T ></tt> assumes that RTypes of the same .NET type are
/// equivalent.  This is correct unless an RType involves runtime value
/// parameters, in which case they must be taken into account by overriding
/// <tt>.Equals( RType )</tt> and <tt>.GetHashCode()</tt>.  Equality is
/// complicated by the fact that RTypes are implemented in a strongly-typed
/// fashion using generics, which requires them to be contravariant, which C#
/// doesn't understand (yet).  The <tt>RTypeContravariantAdapter< T ></tt>
/// workaround provides the required contravariance, but it means RType
/// equality must recognise and "see through" those adapters.
/// <tt>RTypeBase< T ></tt> handles this complication internally and provides a
/// simplified <tt>.Equals( RType )</tt> for subtypes to override if necessary.
// =============================================================================

namespace
Com.Halfdecent.RTypes
{
}

