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


using SCG = System.Collections.Generic;
using System.Linq;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Filters;
using Com.Halfdecent.Numerics;
using Com.Halfdecent.Collections;
using Com.Halfdecent.Testing;


namespace
Com.Halfdecent.Collections.Test
{


// =============================================================================
/// Test program for <tt>Com.Halfdecent.Collections</tt>
// =============================================================================

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


[Test( "CollectionFromSystemListAdapter()" )]
public static
void
Test_CollectionFromSystemListAdapter()
{
    IFilter< int, int > f;

    Print( "Create" );
    var c =
        new SCG.List< int >( new int[] { 1, 2, 3, 4, 5, 6 } )
        .AsHalfdecentCollection();

    Print( "Stream()" );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 2, 3, 4, 5, 6 } ) );

    Print( "GetAndReplaceAll( Predicate< T > )" );
    f = c.GetAndReplaceAll( i => i % 2 == 0 );
    f.From = new int[] { 20, 40, 60, 80, 100 }.AsStream();
    SCG.List< int > to = new SCG.List< int >();
    f.EmptyTo( to.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 20, 3, 40, 5, 60 } ) );
    to.Sort();
    Assert(
        to.SequenceEqual(
            new int[] { 2, 4, 6 } ) );

    Print( "GetAndRemoveAll( Predicate< T > )" );
    to.Clear();
    c.GetAndRemoveAll( i => i >= 10 )
        .EmptyTo( to.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 3, 5 } ) );
    to.Sort();
    Assert(
        to.SequenceEqual(
            new int[] { 20, 40, 60 } ) );

    Print( "Get( TKey )" );
    Assert( c.Get( Integer.From( 0 ) ) == 1 );
    Assert( c.Get( Integer.From( 1 ) ) == 3 );
    Assert( c.Get( Integer.From( 2 ) ) == 5 );

    Print( "GetAndReplace( TKey, T )" );
    c.GetAndReplace( Integer.From( 1 ), 2 );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 2, 5 } ) );

    Print( "GetAndRemove( TKey )" );
    c.GetAndRemove( Integer.From( 1 ) );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 5 } ) );

    Print( "Contains( TKey )" );
    Assert( c.Contains( Integer.From( 0 ) ) );
    Assert( c.Contains( Integer.From( 1 ) ) );
    Assert( !c.Contains( Integer.From( 2 ) ) );

    Print( "GetAll( TKey )" );
    Assert(
        c.GetAll( Integer.From( 1 ) )
        .AsEnumerable()
        .SequenceEqual(
            new int[] { 5 } ) );

    Print( "GetAndReplaceAll( TKey )" );
    f = c.GetAndReplaceAll( Integer.From( 1 ) );
    f.From = new Stream< int >( 6 );
    to.Clear();
    f.EmptyTo( to.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 6 } ) );
    Assert(
        to.SequenceEqual(
            new int[] { 5 } ) );

    Print( "GetAndRemoveAll( TKey )" );
    to.Clear();
    c.GetAndRemoveAll( Integer.From( 1 ) ).EmptyTo( to.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1 } ) );
    Assert(
        to.SequenceEqual(
            new int[] { 6 } ) );

    Print( "Add( TKey, T )" );
    c.Add( Integer.From( 0 ), 0 );
    c.Add( Integer.From( 2 ), 2 );
    c.Add( Integer.From( 1 ), 1 );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 0, 1, 1, 2 } ) );

    Print( "Count" );
    Assert( c.Count.Equals( Integer.From( 4 ) ) );

    Print( "ICollection<ITuple<TKey,T>>.Stream()" );
    IStream< ITuple< IInteger, int > > ts =
        ((ICollection< ITuple< IInteger, int > >)( c )).Stream();
    ITuple< IInteger, int > tup;
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 0 ) ) );  Assert( tup.B == 0 );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 1 ) ) );  Assert( tup.B == 1 );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 2 ) ) );  Assert( tup.B == 1 );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 3 ) ) );  Assert( tup.B == 2 );
    Assert( !ts.TryPull( out tup ) );

    IFilter< ITuple< IInteger, int >, ITuple< IInteger, int > > tf;
    SCG.List< ITuple< IInteger, int > > tto =
        new SCG.List< ITuple< IInteger, int > >();

    Print( "GetAndReplaceAll( Predicate< ITuple< TKey, T > > )" );
    tf = c.GetAndReplaceAll( t => t.B == 1 );
    tf.From =
        new Stream< ITuple< IInteger, int > >(
            new Tuple< IInteger, int >( Integer.From( 0 ), 1 ),
            new Tuple< IInteger, int >( Integer.From( 0 ), 3 ),
            new Tuple< IInteger, int >( Integer.From( 0 ), 999 ) );
    tf.EmptyTo( tto.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 0, 1, 3, 2 } ) );

    Print( "GetAndRemoveAll( Predicate< ITuple< TKey, T > > )" );
    tto.Clear();
    c.GetAndRemoveAll( t => t.B % 2 == 0 )
        .EmptyTo( tto.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 3 } ) );
}




} // type
} // namespace

