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
using System.Collections.Generic;

namespace
Com.Halfdecent.Globalisation
{

// =============================================================================
/// Base class for implementing <tt>Localised< T ></tt>
// =============================================================================

public abstract class
LocalisedBase<
    T
>
    : Localised< T >
{




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Parent culture fallback algorithm
///
public static
IEnumerable< CultureInfo >
/// @returns
/// - Must be <tt>NonNull</tt>
/// - Yielded items must be <tt>NonNull</tt>
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



// TODO Fallback algorithm which also checks other regions with the same
//      language in some prioritised order eg:
//        en-AU => en, en-US, en-GB, en-CA, ..., (invariant)
//        fr-CA => fr, fr-FR, ..., (invariant)
//
//public static
//IEnumerable< CultureInfo >
//PrioritisedRegionFallbacksFor(
//    CultureInfo culture
//)
//{
//    yield return ...;
//}




// -----------------------------------------------------------------------------
// Protected
// -----------------------------------------------------------------------------

protected virtual
bool
TryDefault(
    out T value
)
{
    value = default( T );
    return false;
}



protected virtual
bool
TryFor(
    out T       value,
    CultureInfo culture
)
{
    value = default( T );
    return false;
}



protected virtual
IEnumerable< CultureInfo >
FallbacksFor(
    CultureInfo culture
)
{
    yield break;
}




// -----------------------------------------------------------------------------
// Localised< T >
// -----------------------------------------------------------------------------

protected override
T
ForCulture(
    CultureInfo culture
)
{
    T r;

    if( this.TryFor( out r, culture ) ) return r;

    foreach( CultureInfo fb in this.FallbacksFor( culture ) ) {
        // TODO BugException
        if( fb == null ) throw new Exception( "null fallback culture" );
        if( this.TryFor( out r, fb ) ) return r;
    }

    if( this.TryDefault( out r ) ) return r;

    // TODO BugException
    throw new Exception( String.Format(
        "Bug in LocalisedBase< T > subclass: No value produced for culture" +
        " '{0}' by exact culture, fallback cultures, or TryDefault()",
        culture.Name ) );
}




} // type
} // namespace

