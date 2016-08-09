// -----------------------------------------------------------------------------
// Copyright (c) 2012
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
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace
Halfdecent.Xml
{


// =============================================================================
/// `System.Xml.Linq.XDocument` Library
// =============================================================================

public static class
SystemXDocument
{


public static
    void
Apply(
    XDocument                   from,
    XDocument                   to,
    params ElementMatchRule[]   rules
)
{
    if( from == null ) throw new ArgumentNullException( "from" );
    if( to == null ) throw new ArgumentNullException( "to" );

    var e1 = from.Root;
    if( e1 == null ) return;

    var e2 = to.Root;
    if( e2 == null ) {
        e2 = new XElement( e1.Name );
        to.Add( e2 );
    }

    if( e2.Name != e1.Name )
        throw new ArgumentException(
            "to.Root.Name != from.Root.Name",
            "to" );

    Apply( e1, e2, rules );
}


public static
    void
Apply(
    XElement                    from,
    XElement                    to,
    params ElementMatchRule[]   rules
)
{
    Apply(
        from,
        to,
        rules ?? Enumerable.Empty< ElementMatchRule >() );
}


private static
    void
Apply(
    XElement                        from,
    XElement                        to,
    IEnumerable< ElementMatchRule > rules
)
{
    if( from == null ) throw new ArgumentNullException( "from" );
    if( to == null ) throw new ArgumentNullException( "to" );
    if( rules == null ) throw new ArgumentNullException( "rules" );

    XElement fromroot = from.AncestorsAndSelf().Last();

    // Attributes
    foreach( var a in from.Attributes() )
        to.SetAttributeValue( a.Name, a.Value );

    foreach( XNode n in from.Nodes() ) {

        // Text
        if( n is XText ) {
            var t = n as XText;
            to.Add( new XText( t ) );
        }

        // Elements
        if( n is XElement ) {
            var e1 = n as XElement;

            // Find matching element...
            var rule =
                rules
                .Where( r =>
                    r.AppliesTo( fromroot ).Contains( e1 ) )
                .FirstOrDefault();
            var e2 =
                rule != null
                ? to.Elements()
                    .Where( e => rule.Match( e1, e ) )
                    .SingleOrDefault()
                : null;

            // ...otherwise create it
            if( e2 == null ) {
                e2 = new XElement( e1.Name );
                to.Add( e2 );
            }

            // Recurse
            Apply( e1, e2, rules );
        }
    }
}




} // type
} // namespace

