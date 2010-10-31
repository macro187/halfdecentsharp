// -----------------------------------------------------------------------------
// Copyright (c) 2010
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


using System.Linq;
using Com.Halfdecent.Testing;
using Com.Halfdecent.Streams;
using Com.Halfdecent.TextTree;


namespace
Com.Halfdecent.Streams.Test
{


// =============================================================================
/// Test program for <tt>Com.Halfdecent.TextTree</tt>
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



[Test( "Token Equality" )]
public static
void
Test_TokenEquality()
{
    Print( "IndentToken" );
    Assert( new IndentToken().Equals( new IndentToken() ) );
    Assert( !new IndentToken().Equals( new DeindentToken() ) );

    Print( "DeindentToken" );
    Assert( new DeindentToken().Equals( new DeindentToken() ) );
    Assert( !new DeindentToken().Equals( new IndentToken() ) );

    Print( "DataToken" );
    Assert( new DataToken( "abc" ).Equals( new DataToken( "abc" ) ) );
    Assert( !new DataToken( "abc" ).Equals( new DataToken( "def" ) ) );
    Assert( !new DataToken( "abc" ).Equals( new IndentToken() ) );
}



[Test( "Output Token Streams" )]
public static
void
Test_OutputTokenStreams()
{
    IStream< Token > tokens =
        tree1
        .AsStream()
        .PipeTo( new TextLineSplitter() )
        .PipeTo( new Lexer() );

    Token t;

    t = tokens.Pull();
    Assert( new DataToken( "a" ).Equals( t ) );
    Assert( t.LineNumber == 1 );

    t = tokens.Pull();
    Assert( new IndentToken().Equals( t ) );
    Assert( t.LineNumber == 2 );

    t = tokens.Pull();
    Assert( new DataToken( "aa" ).Equals( t ) );
    Assert( t.LineNumber == 2 );

    t = tokens.Pull();
    Assert( new DataToken( "ab" ).Equals( t ) );
    Assert( t.LineNumber == 3 );

    t = tokens.Pull();
    Assert( new DeindentToken().Equals( t ) );
    Assert( t.LineNumber == 4 );

    t = tokens.Pull();
    Assert( new IndentToken().Equals( t ) );
    Assert( t.LineNumber == 5 );

    t = tokens.Pull();
    Assert( new DeindentToken().Equals( t ) );
    Assert( t.LineNumber == 6 );

    t = tokens.Pull();
    Assert( new DataToken( "b" ).Equals( t ) );
    Assert( t.LineNumber == 7 );

    t = tokens.Pull();
    Assert( new IndentToken().Equals( t ) );
    Assert( t.LineNumber == 8 );

    t = tokens.Pull();
    Assert( new DataToken( "ba" ).Equals( t ) );
    Assert( t.LineNumber == 8 );

    t = tokens.Pull();
    Assert( new DataToken( "bb" ).Equals( t ) );
    Assert( t.LineNumber == 9 );

    Assert( !tokens.TryPull( out t ) );
}


private static string
tree1 =
@"a
    aa
    ab

    

b
    ba
    bb
";




} // type
} // namespace

