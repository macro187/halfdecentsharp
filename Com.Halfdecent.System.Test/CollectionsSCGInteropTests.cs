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
using Com.Halfdecent.System;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Collections;
using SCGInterop = Com.Halfdecent.Collections.SCGInterop;


namespace
Com.Halfdecent.System.Test
{




/// Tests for <tt>Com.Halfdecent.Collections.SCGInterop</tt>
public class
CollectionsSCGInteropTests
    : TestBase
{



[Test( "Operations" )]
public static void
Test_Operations()
{
    SCG.IList< int > TESTLIST = new SCG.List< int >();
    TESTLIST.Add( 1 );
    TESTLIST.Add( 2 );
    TESTLIST.Add( 3 );
    TESTLIST.Add( 4 );
    TESTLIST.Add( 5 );

    Print( "IBagStreamViaIEnumerable()" );
    int i = 1;
    foreach( int item in TESTLIST ) {
        AssertEqual( item, i );
        Assert( i <= 5 );
        i++;
    }
    AssertEqual( i, 6 );

    Print( "IBagCountViaICollection()" );
    AssertEqual(
        SCGInterop.Operations.IBagCountViaICollection( TESTLIST ),
        5 );

    Print( "IBagRemoveAllViaICollection()" );
    SCGInterop.Operations.IBagRemoveAllViaICollection( TESTLIST );
    AssertEqual( TESTLIST.Count, 0 );
}




} // type
} // namespace

