// -----------------------------------------------------------------------------
// Copyright (c) 2007, 2008
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

namespace
Com.Halfdecent.Testing
{

// =============================================================================
/// A test
// =============================================================================
//
public abstract class
TestBase
{




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Emit a message from within a test
///
public static
void
Print(
    string message
)
{
    TestProgram.TestMessage( message );
}



/// Emit a formatted message from within a test
///
public static
void
Print(
    string          message,
    params object[] args
)
{
    TestProgram.TestMessage( String.Format( message, args ) );
}



public static
void
Assert(
    bool condition
)
{
    Assert( "", condition );
}



public static
void
Assert(
    string description,
    bool condition
)
{
    if( description != "" ) {
        Print( "Assert: " + description );
    }
    if( !condition ) {
        throw new AssertFailedException( description );
    }
}



public static
void
AssertEqual(
    object actual,
    object expected
)
{
    if( !(actual == null && expected == null) )
        if( !expected.Equals( actual ) )
            throw new AssertFailedException( String.Format(
                "Expected '{0}'\nActual '{1}'",
                expected,
                actual ) );
}



public static
void
AssertEqual<T>(
    T actual,
    T expected
)
{
    AssertEqual<T>( "", actual, expected );
}



public static
void
AssertEqual<T>(
    string description,
    T actual,
    T expected
)
{
    if( description != "" ) {
        Print( "AssertEqual: " + description );
    }
    if( !(actual == null && expected == null) ) {
        if( !(actual.Equals( expected )) )
        {
            throw new AssertFailedException( String.Format(
                "{0}\nExpected '{1}'\nActual '{2}'",
                description,
                expected,
                actual ) );
        }
    }
}



public static void
AssertElementsEqual<T>(
    T[] a1,
    int a1offset,
    T[] a2,
    int a2offset,
    int count
)
{
    for(
        int i = a1offset,j = a2offset;
        i < a1offset+count;
        i++,j++
    ) {
        if( !a1[i].Equals( a2[j] ) ) {
            throw new AssertFailedException( String.Format(
                "Array elements not equal\n" +
                "Expected '{0}' (a1[{1}])\n" +
                "Actual   '{2}' (a2[{3}])",
                a1[i],
                i,
                a2[j],
                j ) );
        }
    }
}



public static
void
Expect<
    TExpected
>(
    ExpectAction action
)
    where TExpected : Exception
{
    if( action == null ) throw new ArgumentNullException( "action" );
    bool threw = false;
    try {
        action();
    } catch( TExpected ) {
        threw = true;
    }
    if( !threw )
        throw new AssertFailedException( String.Format(
            "Expected {0} but it didn't occur",
            typeof( TExpected ).FullName ) );
}

public delegate
void
ExpectAction();



} // type
} // namespace

