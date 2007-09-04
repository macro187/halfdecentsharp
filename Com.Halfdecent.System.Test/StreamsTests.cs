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
using System.Collections.Generic;
using Com.Halfdecent.System;
using Com.Halfdecent.Testing;
using Com.Halfdecent.Streams;



namespace
Com.Halfdecent.System.Test
{



/// <summary>
/// Tests for <c>Com.Halfdecent.Streams</c>
/// </summary>
public class
StreamsTests
    : TestBase
{




// -----------------------------------------------------------------------------
// Tests
// -----------------------------------------------------------------------------

[Test( "IEnumeratorToIStreamAdapter" )]
public static void
Test_IEnumeratorToIStreamAdapter()
{
    IStream<int> s = new IEnumeratorToIStreamAdapter<int>( CountToFive() );
    int c = 1;

    Print( "Check that stream yields correct items..." );
    while( c <= 5 ) {
        AssertEqual( s.Yield(), c );
        c++;
    }

    Print( "Check that InvalidOperationException thrown if we keep going..." );
    bool thrown = false;
    try {
        s.Yield();
    } catch( InvalidOperationException e ) {
        thrown = true;
        if( e != null ) {}
    }
    Assert( thrown );
}



[Test( "IStreamToIEnumeratorAdapter" )]
public static void
Test_IStreamToIEnumeratorAdapter()
{
    IStream<int> stream = new IEnumeratorToIStreamAdapter<int>( CountToFive() );

    int i = 1;

    Print( "Check the first 3 items via foreach..." );
    foreach( int item in stream ) {
        AssertEqual( item, i );
        i++;
        if( i > 3 ) break;
    }

    Print( "Check the next 2 items via a second foreach..." );
    foreach( int item in stream ) {
        AssertEqual( item, i );
        i++;
        if( i > 5 ) break;
    }

    Print( "Check that InvalidOperationException thrown if we keep going..." );
    bool thrown = false;
    try {
        foreach( int item in stream ) {
            if( item == 0 ) {}
        }
    } catch( InvalidOperationException e ) {
        thrown = true;
        if( e != null ) {}
    }
    Assert( thrown );
}



private static IEnumerator<int>
CountToFive()
{
    yield return 1;
    yield return 2;
    yield return 3;
    yield return 4;
    yield return 5;
}




} // type
} // namespace

