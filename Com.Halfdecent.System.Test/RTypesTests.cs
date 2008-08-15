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

using Com.Halfdecent.Testing;
using Com.Halfdecent.RTypes;

namespace
Com.Halfdecent.System.Test
{

// =============================================================================
/// Tests for <tt>Com.Halfdecent.RTypes</tt>
// =============================================================================
//
public class
RTypesTests
    : TestBase
{




[Test( "NonNull" )]
public static
void
Test_NonNull()
{
    IRType1 rt = new NonNull();
    object obj;

    Print( "Non-null object passes" );
    obj = new object();
    rt.Check( obj );

    Print( "Null throws RTypeException" );
    obj = null;
    Expect< RTypeException >( delegate() {
        rt.Check( obj );
    } );
}



[Test( "IsA" )]
public static
void
Test_IsA()
{
    IRType1 rt = new IsA< A >();
    object obj;

    Print( "Same type passes" );
    obj = new A();
    rt.Check( obj );

    Print( "Subtype passes" );
    obj = new B();
    rt.Check( obj );

    Print( "Unrelated type throws RTypeException" );
    obj = new object();
    Expect< RTypeException >( delegate() {
        rt.Check( obj );
    } );
}

public class A { }
public class B : A { }



[Test( "NonBlankString" )]
public static
void
Test_NonBlankString()
{
    IRType1 rt = new NonBlankString();
    string s;

    Print( "Non-blank passes" );
    s = "hi";
    rt.Check( s );

    Print( "Blank throws RTypeException" );
    s = "";
    Expect< RTypeException >( delegate() {
        rt.Check( s );
    } );
}




} // type
} // namespace
