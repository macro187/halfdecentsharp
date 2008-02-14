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
using SCG = System.Collections.Generic;
using Com.Halfdecent.Testing;
using Com.Halfdecent.Collections;
using Com.Halfdecent.System;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Numerics;
using Com.Halfdecent.Predicates;


namespace
Com.Halfdecent.System.Test
{


public class
TestList
    : IBag< int >
    , IBagCanStream< int >
    , IList< int >
{
    private int[] items = { 1, 2, 3, 4, 5 };

    public Integer Count { get { return Integer.From( this.items.Length ); } }
    public IFiniteStream< int > Stream() {
        return new IFiniteStreamFromIEnumeratorAdapter< int >( this.Iterate() );
    }
    private SCG.IEnumerator< int > Iterate() {
        foreach( int i in this.items ) yield return i;
    }
}



/// Tests for <tt>Com.Halfdecent.Collections</tt>
///
public class
CollectionsTests
    : TestBase
{



[Test( "CollectionsAlgorithms" )]
public static void
Test_CollectionsAlgorithms()
{
    Print( "CollectionsAlgorithms.CountViaStream()" );
    TestList tl = new TestList();
    AssertEqual(
        CollectionsAlgorithms.CountViaStream< TestList, int >( tl ),
        Integer.From( 5 ) );
}



[Test( "IsExistingPositionIn" )]
public static void
Test_IsExistingPositionIn()
{
    IList< int > list = new TestList();
    IPredicate< Integer > p = new IsExistingPositionIn< int >( list );

    Print( "-1 fails" );
    AssertEqual( p.Evaluate( Integer.From( -1 ) ), false );

    Print( "0 passes" );
    AssertEqual( p.Evaluate( Integer.From( 0 ) ), true );

    Print( "4 passes" );
    AssertEqual( p.Evaluate( Integer.From( 1 ) ), true );

    Print( "5 fails" );
    AssertEqual( p.Evaluate( Integer.From( 5 ) ), false );
}




} // type
} // namespace

