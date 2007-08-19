// -----------------------------------------------------------------------------
// Copyright (c) 2007 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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

using Com.Halfdecent.System;
using Com.Halfdecent.Globalization;



namespace
Com.Halfdecent.Resources
{



/// <summary>
/// A read-only <c>Localized&lt;string&gt;</c> that represents a (possibly)
/// localized string
/// </summary>
public class
LocalizedStringResource
    : LocalizedResource<string>
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// <summary>
/// Create a new <c>LocalizedStringResource</c> which may have translated
/// versions available as embedded resources in a given type
/// </summary>
internal
LocalizedStringResource(
    Type type,
    string untranslated
)
    : this( type, untranslated, new object[]{} )
{
}



/// <summary>
/// Create a new <c>LocalizedStringResource</c> which may have translated
/// versions available as embedded resources in a given type and which, when
/// used, will be <c>String.Format</c>ted with the given arguments in a
/// culture-specific fashion
/// </summary>
internal
LocalizedStringResource(
    Type type,
    string untranslated,
    params object[] formatargs
)
    : base( type, Resource.STRING_PREFIX + untranslated )
{
    if( untranslated == null ) throw new ArgumentNullException( "untranslated" );
    if( untranslated == "" ) throw new ArgumentBlankException( "untranslated" );
    if( formatargs == null ) throw new ArgumentNullException( "formatargs" );
    this.untranslated = untranslated;
    this.formatargs = formatargs;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// <summary>
/// Retrieve the version of the string most suitable for the given culture
/// </summary>
/// <exception cref="ResourceTypeMismatchException">
/// Resource is not of (or convertable) to <c>string</c>
/// </exception>
public override string
this[ CultureInfo culture ]
{
    get
    {
        if( culture == null ) throw new ArgumentNullException( "culture" );
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

protected string
untranslated;


protected object[]
formatargs;




} // type
} // namespace

