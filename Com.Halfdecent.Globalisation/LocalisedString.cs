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
using System.Linq;
using System.Globalization;
using System.Threading;


namespace
Com.Halfdecent.Globalisation
{


// =============================================================================
/// %Localised string manipulation routines
///
/// These methods are modelled after the string manipulation methods in the Base
/// Class Library.  The <tt>Localised< string ></tt>s they return evaluate their
/// arguments and perform their operations lazily, and can do so repeatedly for
/// different languages/cultures.  This means that multiple operations
/// effectively queue up, with the entire series of operations evaluating (and
/// reevaluating) as necessary in different languages.
// =============================================================================

public static class
LocalisedString
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Localised-aware version of <tt>System.String.Format()</tt>
///
public static
    Localised< string >
Format(
    Localised< string > format,
    params object[]     args
)
{
    if( format == null ) throw new ArgumentNullException( "format" );
    if( args == null ) throw new ArgumentNullException( "args" );

    return new LazyLocalised< string >(
        (lang) =>
            String.Format(
                lang,
                format.In( lang ),
                args.Select( (arg) =>
                    arg is ILocalised
                        ? ((ILocalised)arg).In( lang )
                        : arg )
                    .ToArray() ) );
}




} // type
} // namespace

