// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009
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
using System.Threading;


namespace
Com.Halfdecent.Globalisation
{


// =============================================================================
/// Localised, lazy-evaluated result of <tt>LocalisedString.Format()</tt>
// =============================================================================

public class
FormattedLocalisedString
    : Localised< string >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
FormattedLocalisedString(
    Localised< string > format,
    params object[]     args
)
{
    if( format == null ) throw new ArgumentNullException( "format" );
    if( args == null ) throw new ArgumentNullException( "args" );
    this.Format = format;
    this.Args = args;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
Localised< string >
Format
{
    get;
    private set;
}


public
object[]
Args
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// Localised< T >
// -----------------------------------------------------------------------------

protected override
    string
ForCulture(
    CultureInfo culture
)
{
    string s;
    CultureInfo cc = Thread.CurrentThread.CurrentCulture;
    CultureInfo cuic = Thread.CurrentThread.CurrentUICulture;
    try {
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;
        s = String.Format( culture, this.Format.In( culture ), this.Args );
    } finally {
        Thread.CurrentThread.CurrentUICulture = cuic;
        Thread.CurrentThread.CurrentCulture = cc;
    }
    return s;
}




} // type
} // namespace

