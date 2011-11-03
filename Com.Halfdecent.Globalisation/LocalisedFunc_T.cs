// -----------------------------------------------------------------------------
// Copyright (c) 2011
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


using System.Collections.Generic;
using System.Globalization;


namespace
Com.Halfdecent.Globalisation
{


// =============================================================================
/// A function that produces different variations of a value for different
/// language/cultures
///
/// The definitions of "UI culture" and "culture" are carried over from the BCL.
/// That is, "UI culture" refers to the natural language of words, phrases,
/// sentences, etc. and "culture" refers to non-linguistic aspects such as the
/// formatting and parsing of numbers, times, and dates, the type of calendar to
/// use, and so on.
///
/// The function may or may not be able to produce a variation for the specified
/// <tt>uiculture</tt>, but must <em>always</em> produce some default value for
/// <tt>CultureInfo.InvariantCulture</tt>.
///
/// @exception System.ArgumentNullException
/// <tt>uiculture</tt> is <tt>null</tt>
/// <em>OR</em>
/// <tt>culture</tt> is <tt>null</tt>
// =============================================================================

public delegate
    IMaybe< T >
LocalisedFunc<
    T
>(
    CultureInfo uiculture,
    CultureInfo culture
);




} // namespace

