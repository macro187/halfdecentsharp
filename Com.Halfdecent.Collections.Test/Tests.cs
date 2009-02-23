// -----------------------------------------------------------------------------
// Copyright (c) 2009
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
using SCG = System.Collections.Generic;
using Com.Halfdecent.Testing;
using Com.Halfdecent.Collections;
using Com.Halfdecent.Streams;


namespace
Com.Halfdecent.Streams.Test
{


// =============================================================================
/// Test program for <tt>Com.Halfdecent.Collections</tt>
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



[Test( "BagFromCollectionAdapter< T >" )]
public static
void
Test_BagFromCollectionAdapter()
{
    int[]                           from = new int[] { 1, 2, 3 };
    SCG.List< int >                 list = new SCG.List< int >();
    BagFromCollectionAdapter< int > bag =
        new BagFromCollectionAdapter< int >( list );
    SCG.List< int >                 to = new SCG.List< int >();

    Print( "Check initial .Count" );
    Assert( bag.Count.ToDecimal() == 0 );

    Print( "Add items via Add()" );
    foreach( int i in from ) bag.Add( i );

    Print( "Check .Count" );
    Assert( bag.Count.ToDecimal() == 3 );

    Print( "Check items via Stream()" );
    to.Clear();
    foreach( int i in bag.Stream().AsEnumerable() ) to.Add( i );
    to.Sort();  // Bags are unordered
    Assert( to.SequenceEqual( from ) );

    Print( "Clear() out all items" );
    bag.Clear();

    Print( "Check .Count" );
    Assert( bag.Count.ToDecimal() == 0 );

    Print( "Add items via ISink" );
    from.AsStream().PushTo( bag );

    Print( "Check .Count" );
    Assert( bag.Count.ToDecimal() == 3 );

    Print( "Check items via Stream()" );
    to.Clear();
    foreach( int i in bag.Stream().AsEnumerable() ) to.Add( i );
    to.Sort();  // Bags are unordered
    Assert( to.SequenceEqual( from ) );
}




} // type
} // namespace

