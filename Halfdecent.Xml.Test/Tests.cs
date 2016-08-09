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


using Halfdecent.Testing;
using Halfdecent.Xml;
using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Halfdecent;


namespace
Halfdecent.Xml.Test
{


// =============================================================================
/// Test program for <tt>Halfdecent.Xml</tt>
// =============================================================================
//
public class
Tests
    : TestBase
{



public static
    int
Main()
{
    return TestProgram.RunTests();
}


[Test( "Apply(XElement,XElement)" )]
public static
    void
Test_Apply()
{
    var xml =
        new XElement( "root",
            new XAttribute( "a", "a" ),
            new XElement( "a",
                new XAttribute( "a", "a" ),
                "atext" ));
    SystemXDocument.Apply(
        new XElement( "root",
            new XAttribute( "b", "b" ),
            new XElement( "b",
                new XAttribute( "b", "b" ),
                "btext" )),
        xml );
    Assert(
        XNode.DeepEquals(
            xml,
            new XElement( "root",
                new XAttribute( "a", "a" ),
                new XElement( "a",
                    new XAttribute( "a", "a" ),
                    "atext" ),
                new XAttribute( "b", "b" ),
                new XElement( "b",
                    new XAttribute( "b", "b" ),
                    "btext" ))));
}


[Test( "Apply(XElement,XElement,ElementMatchRule.ByName())" )]
public static
    void
Test_ApplyByName()
{
    var xml =
        new XElement( "root",
            new XElement( "a",
                new XAttribute( "a", "a" )));
    SystemXDocument.Apply(
        new XElement( "root",
            new XElement( "a",
                new XAttribute( "b", "b" ),
                "btext" )),
        xml,
        ElementMatchRule.ByName(
            e => e.Elements( "a" ) ) );
    Assert(
        XNode.DeepEquals(
            xml,
            new XElement( "root",
                new XElement( "a",
                    new XAttribute( "a", "a" ),
                    new XAttribute( "b", "b" ),
                    "btext" ))));
}


[Test( "Apply(XElement,XElement,ElementMatchRule.ByNameAndAttributes())" )]
public static
    void
Test_ApplyByNameAndAttributes()
{
    var xml =
        new XElement( "root",
            new XElement( "a",
                new XAttribute( "id", "1" )),
            new XElement( "a",
                new XAttribute( "id", "2" )),
            new XElement( "a",
                new XAttribute( "id", "3" )));
    SystemXDocument.Apply(
        new XElement( "root",
            new XElement( "a",
                new XAttribute( "id", "2" ),
                new XAttribute( "new", "new" ),
                "newtext" )),
        xml,
        ElementMatchRule.ByNameAndAttributes(
            e => e.Elements( "a" ),
            "id" ) );
    Assert(
        XNode.DeepEquals(
            xml,
            new XElement( "root",
                new XElement( "a",
                    new XAttribute( "id", "1" )),
                new XElement( "a",
                    new XAttribute( "id", "2" ),
                    new XAttribute( "new", "new" ),
                    "newtext" ),
                new XElement( "a",
                    new XAttribute( "id", "3" )))));
}




} // type
} // namespace

