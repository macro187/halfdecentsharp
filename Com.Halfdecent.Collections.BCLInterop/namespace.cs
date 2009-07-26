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


// =============================================================================
/// <tt>System.Collections</tt> and <tt>System.Collections.Generic</tt>
/// interoperability
///
/// @par System.Collections.ICollection<T>.IsReadOnly
/// In the base class library, the single <tt>ICollection<T></tt> type underlies
/// all collections, with writability indicated in the boolean
/// <tt>IsReadOnly</tt> property.  Besides preventing the compiler from helping
/// to enforce writability, this design is inadequate because the single boolean
/// <tt>false</tt> value is insufficent to represent the various shades of
/// writability: changeable, growable, and shrinkable.  As a result of this lack
/// of precision, ambiguities can arise when mapping between Halfdecent
/// collections and base class library collections.
// =============================================================================

namespace
Com.Halfdecent.Collections.BCLInterop
{
}

