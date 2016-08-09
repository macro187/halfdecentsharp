// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010, 2011
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


namespace
Halfdecent.Globalisation
{


// =============================================================================
/// %Localised string manipulation routines
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

    return Localised.Create(
        (uic,c) =>
            Maybe.Create(
                string.Format(
                    c,
                    format.In( uic, c ),
                    args.Select( arg =>
                        arg is ILocalised
                            ? ((ILocalised)arg)
                                .AsLocalisedObject()
                                .In( uic, c )
                            : arg )
                        .ToArray() ) ) );
}


/// Localised-aware version of <tt>System.String.Concat()</tt>
///
public static
    Localised< string >
Concat(
    Localised< string > a,
    Localised< string > b
)
{
    a = a ?? Localised.Create( "" );
    b = b ?? Localised.Create( "" );
    return Localised.Create(
        (uic,c) =>
            Maybe.Create(
                string.Concat(
                    a.In( uic, c ),
                    b.In( uic, c ) ) ) );
}


/// Localised-aware version of <tt>System.String.ToLower()</tt>
///
public static
    Localised< string >
ToLower(
    this Localised< string > s
)
{
    if( s == null ) throw new ArgumentNullException( "s" );
    return Localised.Create(
        (uic,c) =>
            s.TryIn( uic, c )
            .If( t => t.ToLower( uic ) ) );
}


/// Localised-aware version of <tt>System.String.ToUpper()</tt>
///
public static
    Localised< string >
ToUpper(
    this Localised< string > s
)
{
    if( s == null ) throw new ArgumentNullException( "s" );
    return Localised.Create(
        (uic,c) =>
            s.TryIn( uic, c )
            .If( t => t.ToUpper( uic ) ) );
}




} // type
} // namespace

