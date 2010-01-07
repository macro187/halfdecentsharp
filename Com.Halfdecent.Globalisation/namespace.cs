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



// =============================================================================
/// Human cultures and languages
///
/// @par Kinds of Cultures
/// A <em>specific culture</em> is a language plus a geographic region, for
/// example <tt>en-US</tt>.  A <em>neutral culture</em> is less specific and
/// denotes only a language, for example <tt>fr</tt>.  The <em>invariant
/// culture</em>, represented by a blank string, is the least-specific and
/// means no culture in particular.
///
/// @par Culture Hierarchy
/// A less-specific version of a culture is said to be it's <em>parent</em>.
/// A specific culture's parent is it's corresponding neutral culture, and a
/// neutral culture's parent is the invariant culture.  For example,
/// <tt>en-AU -> en -> invariant</tt>.
// =============================================================================

namespace
Com.Halfdecent.Globalisation
{
}

