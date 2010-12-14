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
using System.Collections;

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
    string
Indent(
    string s
)
{
    return Indent( s, 1 );
}

public static
    string
Indent(
    string  s,
    int     level
)
{
    if( s == null ) throw new ArgumentNullException( "s" );
    if( level < 0 ) throw new ArgumentOutOfRangeException( "level" );
    if( level == 0 ) return s;
    string indentation = "";
    for( int i=0; i<level; i++ )
        indentation += "  ";
    return indentation + s.Replace( "\n", "\n" + indentation );
}



public static
    string
CleanStackTrace(
    string s
)
{
    if( s == null ) throw new ArgumentNullException( "s" );
    string[] a = s.Split( new char[] { '\n' } );
    for( int i = 0; i<a.Length; i++ ) {
        a[i] = a[i].TrimStart( null );
        if( a[i].StartsWith( "at " ) )
            a[i] = a[i].Substring( 3 );
    }
    return String.Join( "\n", a );
}



public static
    string
DumpException(
    Exception e
)
{
    if( e == null ) return "(null)";
    string s = "";
    s += e.Message + "\n";
    s += "(" + e.GetType().FullName + ")";
    if( e.Data != null )
        foreach( DictionaryEntry de in e.Data )
            s += "\n" + de.Key + ": " + de.Value;
    if( e.Source != null && e.Source != "" )
        s += "\nSource: " + e.Source;
    if( !string.IsNullOrEmpty( e.StackTrace ) )
        s += "\nStack Trace:\n" + Indent( CleanStackTrace( e.StackTrace ) );
    else
        s += "\n(No stack trace)";
    if( e.InnerException != null )
        s += "\nInner Exception:\n" + Indent( DumpException( e.InnerException ) );
    else
        s += "\n(No inner exception)";
    return s;
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
Expect<
    TExpected
>(
    ExpectAction action
)
    where TExpected : Exception
{
    Expect(
        delegate( Exception e ) { return e is TExpected; },
        action );
}


public static
void
Expect(
    ExpectPredicate predicate,
    ExpectAction    action
)
{
    if( predicate == null ) throw new ArgumentNullException( "predicate" );
    if( action == null ) throw new ArgumentNullException( "action" );

    try {
        action();

    } catch( Exception e ) {

        if( !predicate( e ) )
            throw new Exception(
                "An exception occurred but it wasn't as expected",
                e );

        Print( "Expected exception occurred:\n{0}",
            Indent( DumpException( e ) ) );
        return;
    }

    throw new Exception( "An exception was expected to occur, but did not" );
}

public delegate
void
ExpectAction();

public delegate
    bool
ExpectPredicate(
    Exception e
);




} // type
} // namespace

