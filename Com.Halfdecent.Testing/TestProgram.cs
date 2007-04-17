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
using System.Reflection;



namespace
Com.Halfdecent.Testing
{



/// <summary>
/// Test runner
/// </summary>
public class
TestProgram
{




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// <summary>
/// Run all tests in a given assembly
/// </summary>
/// <returns>
/// An <c>int</c> suitable for use as a program exit code, ie. 0 if all tests
/// passed, non-zero otherwise
/// </returns>
public static int
RunTests()
{
    int tests_total = 0;
    int tests_failed = 0;

    object[] attrs;
    TestAttribute testattr;

    // Go through all types
    Assembly a = Assembly.GetCallingAssembly();
    foreach( Type t in a.GetTypes() ) {

        // Methods
        foreach( MethodInfo m in t.GetMethods() ) {

            // Check for the TestAttribute, indicating a test method
            attrs = m.GetCustomAttributes( typeof( TestAttribute ), true );
            if( attrs.Length <= 0 ) continue;
            testattr = (TestAttribute) attrs[0];

            // Run the test
            Console.WriteLine( "Testing {0}...", testattr.Description );
            bool passed = true;
            try {
                m.Invoke( null, null );
            } catch( TargetInvocationException e ) {
                TestMessage( e.InnerException.ToString() );
                passed = false;
            }
            TestMessage( passed ? "Test passed" : "Test FAILED" );

            if( !passed ) tests_failed ++;
            tests_total++;
        }
    }

    Console.WriteLine( "" );
    if( tests_failed > 0 ) {
        Console.WriteLine(
            "{0} test{1} failed",
            tests_failed,
            (tests_failed == 1 ? "" : "s") );
    } else {
        Console.WriteLine( "All tests passed" );
    }

    return tests_failed;
}



/// <summary>
/// Emit a test-level console message
/// </summary>
public static void
TestMessage( string message )
{
    if( message == null ) throw new ArgumentNullException( "message" );
    Console.WriteLine( "  - {0}", message.Replace( "\n", "\n    " ) );
}




} // type
} // namespace

