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


using System;
using System.Globalization;


namespace
Com.Halfdecent.Globalisation
{


// =============================================================================
/// Utilities for working with <tt>Localised< string ></tt>s
// =============================================================================

public static class
LocalisedString
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Localisation-aware equivalent of <tt>String.Format()</tt>
///
/// Because any <tt>args</tt> that are themselves <tt>Localised< T ></tt>s
/// will also lazy-evalute, this method can be used to build up entire
/// trees of objects that will be flattened down via
/// <tt>System.String.Format()</tt> on-demand in a culture-sensitive fashion.
///
public static
    Localised< string >
    /// @returns
    /// A <tt>Localised< string ></tt> subclass that performs the
    /// <tt>System.String.Format()</tt> operation on-demand in a
    /// culture-sensitive fashion
Format(
    Localised< string > format,
    ///< (see <tt>System.String</tt>)
    params object[]     args
    ///< (see <tt>System.String.Format( string, object[] )</tt>)
)
{
    return new FormattedLocalisedString( format, args );
}




} // type
} // namespace

