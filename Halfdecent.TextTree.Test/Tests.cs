// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2011
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
using Halfdecent.Testing;
using Halfdecent;
using Halfdecent.Streams;
using Halfdecent.TextTree;


namespace
Halfdecent.TextTree.Test
{


// =============================================================================
/// Test program for <tt>Halfdecent.TextTree</tt>
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



[Test( "Output Token Streams" )]
public static
void
Test_OutputTokenStreams()
{
    IStream< Token > tokens =
        tree1
        .AsStream()
        .To( new TextLineSplitter() )
        .To( new Lexer() );

    Token t;

    t = tokens.Pull();
    Assert( t.LineNumber == 1 );
    Assert( t.Is< DataToken >( dt => dt.Data == "a" ) );

    t = tokens.Pull();
    Assert( t.LineNumber == 2 );
    Assert( t.Is< IndentToken >() );

    t = tokens.Pull();
    Assert( t.LineNumber == 2 );
    Assert( t.Is< DataToken >( dt => dt.Data == "aa" ) );

    t = tokens.Pull();
    Assert( t.LineNumber == 3 );
    Assert( t.Is< DataToken >( dt => dt.Data == "ab" ) );

    t = tokens.Pull();
    Assert( t.LineNumber == 4 );
    Assert( t.Is< DeindentToken >() );

    t = tokens.Pull();
    Assert( t.LineNumber == 5 );
    Assert( t.Is< IndentToken >() );

    t = tokens.Pull();
    Assert( t.LineNumber == 6 );
    Assert( t.Is< DeindentToken >() );

    t = tokens.Pull();
    Assert( t.LineNumber == 7 );
    Assert( t.Is< DataToken >( dt => dt.Data == "b" ) );

    t = tokens.Pull();
    Assert( t.LineNumber == 8 );
    Assert( t.Is< IndentToken >() );

    t = tokens.Pull();
    Assert( t.LineNumber == 8 );
    Assert( t.Is< DataToken >( dt => dt.Data == "ba" ) );

    t = tokens.Pull();
    Assert( t.LineNumber == 9 );
    Assert( t.Is< DataToken >( dt => dt.Data == "bb" ) );

    t = tokens.Pull();
    Assert( t.LineNumber == 9 );
    Assert( t.Is< DeindentToken >() );

    Assert( !tokens.TryPull( out t ) );
}


private static string
tree1 =
@"a
    aa
    ab

    

b
    ba
    bb";




} // type
} // namespace

