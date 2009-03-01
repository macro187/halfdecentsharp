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


using System;
using System.Collections.Generic;
using System.Linq;
using Com.Halfdecent.Testing;
using Com.Halfdecent.Filters;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Collections;


namespace
Com.Halfdecent.Filters.Test
{


// =============================================================================
/// Test program for <tt>Com.Halfdecent.Filters</tt>
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



public class
PassThrough
    : FilterBase< int, int >
{
    protected override
    IEnumerator< bool >
    Process()
    {
        for( ;; ) {
            yield return false;
            this.PutItem( this.GetItem() );
            yield return true;
        }
    }
}



public class
DoubleUp
    : FilterBase< int, int >
{
    protected override
    IEnumerator< bool >
    Process()
    {
        for( ;; ) {
            int i;
            yield return false; i = this.GetItem();
            this.PutItem( i ); yield return true;
            this.PutItem( i ); yield return true;
        }
    }
}



public class
AddPairs
    : FilterBase< int, int >
{
    protected override
    IEnumerator< bool >
    Process()
    {
        for( ;; ) {
            int i,j;
            yield return false; i = this.GetItem();
            yield return false; j = this.GetItem();
            this.PutItem( i + j ); yield return true;
        }
    }
}



[Test( "FilterBase.Push()" )]
public static
void
Test_FilterBase_Push()
{
    int[]               from = new int[] { 1, 2, 3, 4 };
    IFilter< int, int > f;
    List< int >         to = new List< int >();
    //List< int >         too = new List< int >();

    Print( "Push(), 1-to-1 filter" );
    to.Clear();
    f = new PassThrough { To = to.AsBag() };
    foreach( int i in from ) f.Push( i );
    Assert( to.SequenceEqual( from ) );

    Print( "Push(), 1-to-many filter" );
    to.Clear();
    f = new DoubleUp { To = to.AsBag() };
    foreach( int i in from ) f.Push( i );
    Assert( to.SequenceEqual( new int[] { 1,1, 2,2, 3,3, 4,4 } ) );

    Print( "Push(), many-to-1 filter" );
    to.Clear();
    f = new AddPairs { To = to.AsBag() };
    foreach( int i in from ) f.Push( i );
    Assert( to.SequenceEqual( new int[] { 3, 7 } ) );

    /*
    Print( "Push(), 1-to-many filter, switch .To mid-block" );
    to.Clear();
    too.Clear();
    f = new DoubleUp();
    f.To = to.AsBag();
    // ...
    f.To = too.AsBag();
    // ...
    Assert( to.SequenceEqual( new int[] { ... } ) );
    Assert( too.SequenceEqual( new int[] { ... } ) );
    */
}




} // type
} // namespace

