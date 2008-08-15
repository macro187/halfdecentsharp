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
using Com.Halfdecent.System;


namespace
Com.Halfdecent.Globalisation
{




/// Utilities for working with <tt>Localised< string ></tt>s
///
public static class
LocalisedString
{




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Localisation-aware equivalent of <tt>String.Format()</tt>
///
/// <tt>Format()</tt> returns a <tt>Localised< string ></tt> that performs the
/// underlying <tt>System.String.Format()</tt> operation in an on-demand
/// fashion.
///
/// This means that the returned <tt>Localised< string ></tt>'s final value
/// may appear differently at different times depending on the thread's
/// <tt>CurrentCulture</tt> (or the requested culture if the <tt>[]</tt>
/// operator is used)
///
/// As <tt>String.Format()</tt> is used internally, final values will be
/// formatted appropriately according to the current/requested culture.
///
/// Note that if any format <tt>args</tt> are themselves
/// <tt>Localised< T ></tt>s, they too may change according to culture, thus
/// influencing final values.  Indeed, strings consisting of multiple nested
/// <tt>Localised< T ></tt>'s can result, with all constituent items being
/// evaluated appropriately on-demand.
///
public static
Localised< string >
Format(
    Localised< string > format,
    params object[]     args
)
{
    new IsPresent< Localised< string > >().ReallyRequire( format );
    new IsPresent< object[] >().ReallyRequire( args );
    return new FormattedLocalisedString( format, args );
}




// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private class
FormattedLocalisedString
    : Localised<string>
{
    internal
    FormattedLocalisedString(
        Localised<string>   format,
        params object[]     args
    )
    {
        // (assume params are prevalidated)
        this.format = format;
        this.args = args;
    }

    private Localised<string>
    format;

    private object[]
    args;

    public override string
    this[ CultureInfo culture ]
    {
        get
        {
            new IsPresent< CultureInfo >().Require( culture );
            string result;
            CultureInfo cc = CultureInfo.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = culture;
            try {
                result = String.Format( this.format, this.args );
            } finally {
                Thread.CurrentThread.CurrentCulture = cc;
            }
            return result;
        }
        set
        {
            throw new InvalidOperationException();
        }
    }
}




} // type
} // namespace

