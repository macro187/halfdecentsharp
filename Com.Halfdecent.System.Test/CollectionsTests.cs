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


namespace
Com.Halfdecent.System.Test
{


public class
TestBag
    : IBag< int >
    , IBagCanStream< int >
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
    TestBag tb = new TestBag();
    AssertEqual(
        CollectionsAlgorithms.CountViaStream< TestBag, int >( tb ),
        Integer.From( 5 ) );
}




} // type
} // namespace

