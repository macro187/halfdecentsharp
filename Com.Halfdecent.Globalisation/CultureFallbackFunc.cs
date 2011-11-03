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
/// A function that, given a culture, produces a prioritised sequence of other
/// cultures that may be "similar" enough for use in cases where resources or
/// functionality is not available
///
/// Culture fallback order is a political problem, with no single "correct" way
/// to do it.  All culture-sensitive operations should allow callers to specify
/// it by supplying a <tt>CultureFallbackFunc</tt>.
// =============================================================================

public delegate
    IEnumerable< CultureInfo >
CultureFallbackFunc
(
    CultureInfo culture
);




} // namespace

