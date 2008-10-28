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

/// A <tt>Localised< T ></tt> base class implementing a simple parent culture
/// fallback mechanism
///
/// Provides good results when most variants will be associated with neutral
/// cultures and only country-specific overrides will be associated with
/// specific cultures.
///
public abstract class
FallbackLocalised<
    T
>
    : Localised< T >
{




// -----------------------------------------------------------------------------
// Protected
// -----------------------------------------------------------------------------

/// Retrieve a variation for the exact culture specified, if available
///
/// Implementations <em>must</em> be able to produce a variation for the
/// invariant culture.  Failing to do so will result in an exception.
///
protected abstract
bool
/// @returns Whether a variation was available for the exact culture specified
TryForExactCulture(
    out T       value,
    ///< The variation for the exact culture specified
    ///  -OR- if a variation for the exact culture specified is not available,
    ///  an undefined value which should not be used
    CultureInfo culture
);




// -----------------------------------------------------------------------------
// Localised< T >
// -----------------------------------------------------------------------------

protected override
T
ForCulture(
    CultureInfo culture
)
{
    CultureInfo c = culture;
    T t;
    for( ;; ) {
        if( this.TryForExactCulture( out t, c ) ) return t;
        if( c == CultureInfo.InvariantCulture )
            // TODO BugException
            throw new Exception(
                "Bug in FallbackLocalised< T > subclass: No variation for" +
                " invariant culture" );
        c = c.Parent;
        if( c == null )
            // TODO BugException
            throw new Exception(
                "Bug: c should never get to be null" );
    }
}




} // type
} // namespace

