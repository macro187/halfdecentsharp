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
using SCG = System.Collections.Generic;
using System.Linq;
using Com.Halfdecent.Testing;
using Com.Halfdecent.Filters;
using Com.Halfdecent.Streams;


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
    SCG.IEnumerator< bool >
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
    SCG.IEnumerator< bool >
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
    SCG.IEnumerator< bool >
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
    SCG.IEnumerator< bool >
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
    SCG.List< int >     to = new SCG.List< int >();
    SCG.List< int >     too = new SCG.List< int >();

    Print( "1-to-1 filter" );
    to.Clear();
    f = new PassThrough { To = to.AsSink() };
    foreach( int i in from ) f.Push( i );
    Assert( to.SequenceEqual( from ) );

    Print( "1-to-many filter" );
    to.Clear();
    f = new DoubleUp { To = to.AsSink() };
    foreach( int i in from ) f.Push( i );
    Assert( to.SequenceEqual( new int[] { 1,1, 2,2, 3,3, 4,4 } ) );

    Print( "Many-to-1 filter" );
    to.Clear();
    f = new AddPairs { To = to.AsSink() };
    foreach( int i in from ) f.Push( i );
    Assert( to.SequenceEqual( new int[] { 3, 7 } ) );

    Print( "Closing filter" );
    to.Clear();
    f = new PassOne { To = to.AsSink() };
    f.Push( 1 );
    Assert( !f.TryPush( 2 ) );
    Assert( to.SequenceEqual( new int[] { 1 } ) );

    Print( "1-to-many filter, switch .To mid-block" );
    to.Clear();
    too.Clear();
    f = new DoubleUp { To =
        new PassOne { To =
        to.AsSink() } };
    f.Push( 1 );
    Assert( to.SequenceEqual( new int[] { 1 } ) );
    f.To = too.AsSink();
    // (filter immediately flushes pending item to new sink)
    Assert( too.SequenceEqual( new int[] { 1 } ) );
}



[Test( "FilterBase.Pull()" )]
public static
void
Test_FilterBase_Pull()
{
    IFilter< int, int > f;
    SCG.List< int > to = new SCG.List< int >();

    Print( "1-to-1 filter" );
    f = new PassThrough { From = new Stream< int >( 1, 2, 3, 4 ) };
    to.Clear();
    f.EmptyTo( to.AsSink() );
    Assert( to.SequenceEqual( new int[] { 1, 2, 3, 4 } ) );

    Print( "1-to-many filter" );
    f = new DoubleUp { From = new Stream< int >( 1, 2, 3, 4 ) };
    to.Clear();
    f.EmptyTo( to.AsSink() );
    Assert( to.SequenceEqual( new int[] { 1,1, 2,2, 3,3, 4,4 } ) );

    Print( "Many-to-1 filter" );
    f = new AddPairs { From = new Stream< int >( 1, 2, 3, 4 ) };
    to.Clear();
    f.EmptyTo( to.AsSink() );
    Assert( to.SequenceEqual( new int[] { 3, 7 } ) );

    Print( "Closing filter" );
    f = new PassOne { From = new Stream< int >( 1, 2, 3, 4 ) };
    to.Clear();
    f.EmptyTo( to.AsSink() );
    Assert( to.SequenceEqual( new int[] { 1 } ) );

    Print( "Many-to-1 filter, switch .From mid-block" );
    f = new AddPairs { From = new Stream< int >( 1 ) };
    to.Clear();
    f.EmptyTo( to.AsSink() );
    Assert( to.Count == 0 );
    f.From = new Stream< int >( 2 );
    f.EmptyTo( to.AsSink() );
    Assert( to.SequenceEqual( new int[] { 3 } ) );
}


public static
    SCG.IEnumerator< bool >
OnlyEvens(
    Func< int >         get,
    Func< int, Void >   put,
    Func< int, Void >   drop
)
{
    for( ;; ) {
        yield return false;
        int i = get();
        if( i % 2 != 0 ) continue;
        put( i );
        yield return true;
    }
}


[Test( "Filter< TIn, TOut >" )]
public static
void
Test_Filter_TIn_TOut()
{
    IFilter< int, int > f = new Filter< int, int >( OnlyEvens );
    SCG.IList< int > results = new SCG.List< int >();
    f.From = new int[] { 1, 2, 3, 4, 5, 6 }.AsStream();
    f.EmptyTo( results.AsSink() );
    Assert( results.SequenceEqual( new int[] { 2, 4, 6 } ) );
}




} // type
} // namespace

