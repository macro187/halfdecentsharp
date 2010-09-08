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
    Assert(
        tree1
        .AsStream()
        .PipeTo( new TextLineSplitter() )
        .PipeTo( new Lexer() )
        .SequenceEqual(
            new Stream< Token >(
                new DataToken( "a" ),
                new IndentToken(),
                new DataToken( "aa" ),
                new DataToken( "ab" ),
                new DeindentToken(),
                new IndentToken(),
                new DeindentToken(),
                new DataToken( "b" ),
                new IndentToken(),
                new DataToken( "ba" ),
                new DataToken( "bb" ) ) ) );
}


private static string
tree1 =
@"
a
    aa
    ab

    

b
    ba
    bb
";




} // type
} // namespace

