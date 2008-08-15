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
using System.Threading;
using System.Globalization;
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.RTypes;

namespace
Com.Halfdecent.Resources
{

// =============================================================================
/// A read-only <tt>Localised< string ></tt> that represents a (possibly)
/// localised string
// =============================================================================
///
public class
LocalisedStringResource
    : LocalisedResource< string >
{




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
    : this( type, untranslated, new object[]{} )
{
}



/// Create a new <tt>LocalisedStringResource</tt> which may have translated
/// versions available as embedded resources in a given type and which, when
/// used, will be <tt>String.Format</tt>ted with the given arguments in a
/// culture-specific fashion
///
// TODO move formatted Localised< string > functionality out into a separate
// type (eg. FormattedLocalisedString?) and remove all associated functionality
// from here and from Resource.  Programmers will have to call
// LocalisedString.Format if they want formatting.
//
internal
LocalisedStringResource(
    Type            type,
    string          untranslated,
    params object[] formatargs
)
    : base( type, Resource.STRING_RESOURCE_NAME_PREFIX + untranslated )
{
    new NonNull().Check( untranslated );
    new NonBlankString().Check( untranslated );
    new NonNull().Check( formatargs );
    this.untranslated = untranslated;
    this.formatargs = formatargs;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// The version of the string most suitable for a given culture
///
/// @exception ResourceTypeMismatchException
/// Resource is not of (or convertable) to <tt>string</tt>
///
public override
string
this[
    CultureInfo culture
]
{
    get
    {
        new NonNull().Check( culture );
        string r;
        r = Resource.Get<string>( this.type, this.name, culture );
        if( r == null )
            r = this.untranslated;
        if( this.formatargs.Length > 0 ) {
            CultureInfo cc = CultureInfo.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = culture;
            try {
                r = String.Format( r, this.formatargs );
            } finally {
                Thread.CurrentThread.CurrentCulture = cc;
            }
        }
        return r;
    }
    set
    {
        throw new InvalidOperationException();
    }
}




// -----------------------------------------------------------------------------
// Protected
// -----------------------------------------------------------------------------

// TODO to property
protected
string
untranslated;



// TODO to property
protected
object[]
formatargs;




} // type
} // namespace
