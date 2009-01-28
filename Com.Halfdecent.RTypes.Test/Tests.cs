// -----------------------------------------------------------------------------
// Copyright (c) 2008
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

using Com.Halfdecent.Testing;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Meta;

namespace
Com.Halfdecent.RTypes.Test
{

// =============================================================================
/// Test program for <tt>Com.Halfdecent.RTypes</tt>
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



[Test( "NonNull" )]
public static
void
Test_NonNull()
{
    IRType< object > rt = new NonNull< object >();
    object obj;
    IValue obj_ = new Local( "obj" );

    Print( "Non-null object passes" );
    obj = new object();
    rt.Check( obj, obj_ );

    Print( "Null throws RTypeException" );
    obj = null;
    Expect< RTypeException >( delegate() {
        rt.Check( obj, obj_ );
    } );
}



[Test( "IsA" )]
public static
void
Test_IsA()
{
    IRType< object > rt = new IsA< object, A >();
    object obj;
    IValue obj_ = new Local( "obj" );

    Print( "Same type passes" );
    obj = new A();
    rt.Check( obj, obj_ );

    Print( "Subtype passes" );
    obj = new B();
    rt.Check( obj, obj_ );

    Print( "Unrelated type throws RTypeException" );
    obj = new object();
    Expect< RTypeException >( delegate() {
        rt.Check( obj, obj_ );
    } );
}

public class A { }
public class B : A { }



[Test( "NonBlankString" )]
public static
void
Test_NonBlankString()
{
    IRType< string > rt = new NonBlankString();
    string s;
    IValue s_ = new Local( "s" );

    Print( "Non-blank passes" );
    s = "hi";
    rt.Check( s, s_ );

    Print( "Blank throws RTypeException" );
    s = "";
    Expect< RTypeException >( delegate() {
        rt.Check( s, s_ );
    } );
}



[Test( "EQ" )]
public static
void
Test_EQ()
{
    int i = 1;
    int eq = 1;
    int neq = 2;

    IRType< int > rt = new EQ< int >( i );

    // TODO null doesn't pass

    Print( "Equal passes" );
    rt.Check( eq, new Local( "eq" ) );

    Print( "Inequal fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( neq, new Local( "neq" ) );
    } );
}



[Test( "NEQ" )]
public static
void
Test_NEQ()
{
    int i = 1;
    int eq = 1;
    int neq = 2;

    IRType< int > rt = new NEQ< int >( i );

    // TODO null doesn't pass

    Print( "Inequal passes" );
    rt.Check( neq, new Local( "neq" ) );

    Print( "Equal fails" );
    Expect< RTypeException >( delegate() {
        rt.Check( eq, new Local( "eq" ) );
    } );
}



[Test( "IRType.Contravary()" )]
public static
void
Test_IRType_Contravary()
{
    IRType< string > rt =
        new NonNull< object >()
            .Contravary< object, string >();

    Print( "Use an RType< object > to check a string" );
    rt.Check( "I'm not null", new Literal() );
}




} // type
} // namespace

