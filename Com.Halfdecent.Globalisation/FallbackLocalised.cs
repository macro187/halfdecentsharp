// -----------------------------------------------------------------------------
// Copyright (c) 2010
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
using System.Globalization;
using System.Collections.Generic;


namespace
Com.Halfdecent.Globalisation
{


// =============================================================================
/// <tt>FallbackLocalised<T></tt> library
// =============================================================================

public static class
FallbackLocalised
{


// -----------------------------------------------------------------------------
// Culture Fallback Algorithms
// -----------------------------------------------------------------------------

/// Culture fallback algorithm: Parent culture(s)
///
public static
    IEnumerable< CultureInfo >
ParentFallbacksFor(
    CultureInfo culture
)
{
    if( culture == null ) throw new ArgumentNullException( "culture" );
    CultureInfo c = culture;
    while( c.Name != "" ) {
        c = c.Parent;
        yield return c;
    }
}


// Culture fallback algorithm: Similar culture(s)
//
// TODO Fallback algorithm which also checks other regions with the same
//      language in some prioritised order eg:
//
//          en-AU => en, en-US, en-GB, en-CA, ..., (invariant)
//          fr-CA => fr, fr-FR, ..., (invariant)
//
//public static
//    IEnumerable< CultureInfo >
//SimilarFallbacksFor(
//    CultureInfo culture
//)
//{
//    yield return ...;
//}




} // type
} // namespace

