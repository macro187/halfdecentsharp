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



namespace
Com.Halfdecent.Globalization
{



/// <summary>
/// Utilities for working with <c>Localized&lt;string&gt;</c>s
/// </summary>
public class
LocalizedString
{

// (not creatable)
private LocalizedString() {}




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// <summary>
/// Localized equivalent of <c>String.Format()</c>
/// </summary>
/// <remarks>
/// <c>Format()</c> returns a <c>Localized&lt;string&gt;</c> that performs the
/// actual formatting of the <c>format</c> string and <c>args</c> in an
/// on-demand fashion.
///
/// This means that the returned <c>Localized&lt;string&gt;</c>'s final value
/// may appear differently at different times depending on the thread's
/// <c>CurrentCulture</c> (or the requested culture if the <c>[]</c> operator
/// is used)
///
/// As <c>String.Format()</c> is used internally, final values will be
/// formatted appropriately according to the current/requested culture.
///
/// Note that if any format <c>args</c> are themselves
/// <c>Localized&lt;T&gt;</c>s, they too may change according to culture, thus
/// influencing final values.  Indeed, multiple nested
/// <c>Localized&lt;T&gt;</c>'s can be used, and they will all be evaluated
/// appropriately on-demand.
/// </remarks>
public static Localized<string>
Format(
    string          format,
    params object[] args
)
{
    if( format == null ) throw new ArgumentNullException( "format" );
    if( args == null ) throw new ArgumentNullException( "args" );
    return new FormattedLocalizedString( format, args );
}




// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private class
FormattedLocalizedString
    : Localized<string>
{
    internal
    FormattedLocalizedString(
        string          format,
        params object[] args
    )
    {
        // (assume params are prevalidated)
        this.format = format;
        this.args = args;
    }

    private string
    format;

    private object[]
    args;

    /// <summary>(see base)</summary>
    public override string
    this[ CultureInfo culture ]
    {
        get
        {
            if( culture == null ) throw new ArgumentNullException( "culture" );
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

