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
using Com.Halfdecent.Streams.BCLInterop;
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
PassOne
    : FilterBase< int, int >
{
    protected override
    IEnumerator< bool >
    Process()
    {
        yield return false;
        this.PutItem( this.GetItem() );
        yield return true;
    }
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
    List< int >         too = new List< int >();

    Print( "1-to-1 filter" );
    to.Clear();
    f = new PassThrough { To = to.AsBag() };
    foreach( int i in from ) f.Push( i );
    Assert( to.SequenceEqual( from ) );

    Print( "1-to-many filter" );
    to.Clear();
    f = new DoubleUp { To = to.AsBag() };
    foreach( int i in from ) f.Push( i );
    Assert( to.SequenceEqual( new int[] { 1,1, 2,2, 3,3, 4,4 } ) );

    Print( "Many-to-1 filter" );
    to.Clear();
    f = new AddPairs { To = to.AsBag() };
    foreach( int i in from ) f.Push( i );
    Assert( to.SequenceEqual( new int[] { 3, 7 } ) );

    Print( "Closing filter" );
    to.Clear();
    f = new PassOne { To = to.AsBag() };
    f.Push( 1 );
    AssertEqual( f.TryPush( 2 ), false );
    Assert( to.SequenceEqual( new int[] { 1 } ) );

    Print( "1-to-many filter, switch .To mid-block" );
    to.Clear();
    too.Clear();
    f = new DoubleUp { To =
        new PassOne { To =
        to.AsBag() } };
    f.Push( 1 );
    Assert( to.SequenceEqual( new int[] { 1 } ) );
    f.To = too.AsBag();
    // (filter immediately flushes pending item to new sink)
    Assert( too.SequenceEqual( new int[] { 1 } ) );
}



[Test( "FilterBase.Pull()" )]
public static
void
Test_FilterBase_Pull()
{
    IBag< int >                     from = new int[] { 1, 2, 3, 4 }
                                        .AsReadOnlyBag();
    IBag< int >                     from1 = new int[] { 1 }.AsReadOnlyBag();
    IBag< int >                     from2 = new int[] { 2 }.AsReadOnlyBag();
    IFilter< int, int >             f;
    BagFromSCGCollectionAdapter< int > to = new List< int >().AsBag();

    Print( "1-to-1 filter" );
    f = new PassThrough { From = from.Stream() };
    to.Clear();
    f.EmptyTo( to );
    Assert( to.Stream().AsEnumerable().SequenceEqual(
        from.Stream().AsEnumerable() ) );

    Print( "1-to-many filter" );
    f = new DoubleUp { From = from.Stream() };
    to.Clear();
    f.EmptyTo( to );
    Assert( to.Stream().AsEnumerable().SequenceEqual(
        new int[] { 1,1, 2,2, 3,3, 4,4 } ) );

    Print( "Many-to-1 filter" );
    f = new AddPairs { From = from.Stream() };
    to.Clear();
    f.EmptyTo( to );
    Assert( to.Stream().AsEnumerable().SequenceEqual(
        new int[] { 3, 7 } ) );

    Print( "Closing filter" );
    f = new PassOne { From = from.Stream() };
    to.Clear();
    f.EmptyTo( to );
    Assert( to.Stream().AsEnumerable().SequenceEqual(
        new int[] { 1 } ) );

    Print( "Many-to-1 filter, switch .From mid-block" );
    f = new AddPairs { From = from1.Stream() };
    to.Clear();
    f.EmptyTo( to );
    AssertEqual( to.Count.ToDecimal(), 0m );
    f.From = from2.Stream();
    f.EmptyTo( to );
    Assert( to.Stream().AsEnumerable().SequenceEqual( new int[] { 3 } ) );
}




} // type
} // namespace

