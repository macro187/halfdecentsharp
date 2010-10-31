// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2010
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
using Com.Halfdecent.Globalisation;


namespace
Com.Halfdecent.Resources
{


// =============================================================================
/// A <tt>Localised<string></tt> that represents a (possibly) localised
/// string
// =============================================================================

public class
LocalisedStringResource
    : LocalisedResource< string >
{



// -----------------------------------------------------------------------------
// Constants
// -----------------------------------------------------------------------------

/// Localised variations of strings are named the untranslated string itself
/// prefixed by this
///
public static readonly
string
RESOURCE_NAME_PREFIX = "__";



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Create a new <tt>LocalisedStringResource</tt> which may have translated
/// versions available as embedded resources in a given type
///
internal
LocalisedStringResource(
    Type    type,
    string  untranslated
)
    : base(
        type,
        RESOURCE_NAME_PREFIX + (untranslated ?? "(null)") )
{
    if( untranslated == null )
        throw new ArgumentNullException( "untranslated" );
    if( untranslated == "" )
        throw new ArgumentException( "Is blank", "untranslated" );

    this.Untranslated = untranslated;
}



// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private string Untranslated;



// -----------------------------------------------------------------------------
// FallbackLocalised< T >
// -----------------------------------------------------------------------------

protected override
    string
Default()
{
    return this.Untranslated;
}




} // type
} // namespace

