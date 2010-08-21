// -----------------------------------------------------------------------------
// Copyright (c) 2010
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
using System.Text;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Streams;
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


[Test( "OrderedCollectionFromSystemListAdapter()" )]
public static
void
Test_CollectionFromSystemListAdapter()
{
    IFilter< int, int > f;

    Print( "Create" );
    var c =
        new SCG.List< int >( new int[] { 1, 2, 3, 4, 5, 6 } )
        .AsHalfdecentCollection();

    Print( ".Stream()" );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 2, 3, 4, 5, 6 } ) );

    Print( ".GetAndReplaceWhere( Predicate< T > )" );
    f = c.GetAndReplaceWhere( i => i % 2 == 0 );
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

    Print( ".GetAndRemoveWhere( Predicate< T > )" );
    to.Clear();
    c.GetAndRemoveWhere( i => i >= 10 )
        .EmptyTo( to.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 3, 5 } ) );
    to.Sort();
    Assert(
        to.SequenceEqual(
            new int[] { 20, 40, 60 } ) );

    Print( ".Get( TKey )" );
    Assert( c.Get( Integer.From( 0 ) ) == 1 );
    Assert( c.Get( Integer.From( 1 ) ) == 3 );
    Assert( c.Get( Integer.From( 2 ) ) == 5 );

    Print( ".Replace( TKey, T )" );
    c.Replace( Integer.From( 1 ), 2 );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 2, 5 } ) );

    Print( ".Remove( TKey )" );
    c.Remove( Integer.From( 1 ) );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1, 5 } ) );

    Print( ".Contains( TKey )" );
    Assert( c.Contains( Integer.From( 0 ) ) );
    Assert( c.Contains( Integer.From( 1 ) ) );
    Assert( !c.Contains( Integer.From( 2 ) ) );

    Print( ".Stream( TKey )" );
    Assert(
        c.Stream( Integer.From( 1 ) )
        .AsEnumerable()
        .SequenceEqual(
            new int[] { 5 } ) );

    Print( ".GetAndReplaceAll( TKey )" );
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

    Print( ".GetAndRemoveAll( TKey )" );
    to.Clear();
    c.GetAndRemoveAll( Integer.From( 1 ) ).EmptyTo( to.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 1 } ) );
    Assert(
        to.SequenceEqual(
            new int[] { 6 } ) );

    Print( ".Add( TKey, T )" );
    c.Add( Integer.From( 0 ), 0 );
    c.Add( Integer.From( 2 ), 2 );
    c.Add( Integer.From( 1 ), 1 );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new int[] { 0, 1, 1, 2 } ) );

    Print( ".Count" );
    Assert( c.Count.Equals( Integer.From( 4 ) ) );

    Print( ".StreamPairs()" );
    IStream< ITuple< IInteger, int > > ts =
        c.StreamPairs();
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
}


[Test( "OrderedCollectionFromStringAdapter()" )]
public static
void
Test_OrderedCollectionFromStringAdapter()
{
    Print( "Create" );
    var c =
        "abc"
        .AsHalfdecentCollection();

    Print( ".Stream()" );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new char[] { 'a', 'b', 'c' } ) );

    Print( ".Get( TKey )" );
    Assert( c.Get( Integer.From( 0 ) ) == 'a' );
    Assert( c.Get( Integer.From( 1 ) ) == 'b' );
    Assert( c.Get( Integer.From( 2 ) ) == 'c' );

    Print( ".Contains( TKey )" );
    Assert( !c.Contains( Integer.From( -1 ) ) );
    Assert( c.Contains( Integer.From( 0 ) ) );
    Assert( c.Contains( Integer.From( 1 ) ) );
    Assert( c.Contains( Integer.From( 2 ) ) );
    Assert( !c.Contains( Integer.From( 3 ) ) );

    Print( ".Stream( TKey )" );
    Assert(
        c.Stream( Integer.From( 1 ) )
        .AsEnumerable()
        .SequenceEqual(
            new char[] { 'b' } ) );

    Print( ".Count" );
    Assert( c.Count.Equals( Integer.From( 3 ) ) );

    Print( ".StreamPairs()" );
    IStream< ITuple< IInteger, char > > ts = c.StreamPairs();
    ITuple< IInteger, char > tup;
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 0 ) ) );  Assert( tup.B == 'a' );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 1 ) ) );  Assert( tup.B == 'b' );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 2 ) ) );  Assert( tup.B == 'c' );
    Assert( !ts.TryPull( out tup ) );
}


[Test( "CollectionFromSystemStringBuilderAdapter()" )]
public static
void
Test_CollectionFromSystemStringBuilderAdapter()
{
    IFilter< char, char > f;

    Print( "Create" );
    var c = new StringBuilder( "abcde" ).AsHalfdecentCollection();

    Print( ".Stream()" );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new char[] { 'a', 'b', 'c', 'd', 'e' } ) );

    Print( ".GetAndReplaceWhere( Predicate< char > )" );
    f = c.GetAndReplaceWhere( ch => ch == 'b' );
    f.From = new char[] { 'B' }.AsStream();
    SCG.List< char > to = new SCG.List< char >();
    f.EmptyTo( to.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new char[] { 'a', 'B', 'c', 'd', 'e' } ) );
    to.Sort();
    Assert(
        to.SequenceEqual(
            new char[] { 'b' } ) );

    Print( ".GetAndRemoveWhere( Predicate< char > )" );
    to.Clear();
    c.GetAndRemoveWhere( ch => ch == 'B' )
        .EmptyTo( to.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new char[] { 'a', 'c', 'd', 'e' } ) );
    to.Sort();
    Assert(
        to.SequenceEqual(
            new char[] { 'B' } ) );

    Print( ".Get( IInteger )" );
    Assert( c.Get( Integer.From( 0 ) ) == 'a' );
    Assert( c.Get( Integer.From( 1 ) ) == 'c' );
    Assert( c.Get( Integer.From( 2 ) ) == 'd' );
    Assert( c.Get( Integer.From( 3 ) ) == 'e' );

    Print( ".Replace( IInteger, char )" );
    c.Replace( Integer.From( 1 ), 'C' );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new char[] { 'a', 'C', 'd', 'e' } ) );

    Print( ".Remove( IInteger )" );
    c.Remove( Integer.From( 1 ) );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new char[] { 'a', 'd', 'e' } ) );

    Print( ".Contains( IInteger )" );
    Assert( !c.Contains( Integer.From( -1 ) ) );
    Assert( c.Contains( Integer.From( 0 ) ) );
    Assert( c.Contains( Integer.From( 1 ) ) );
    Assert( c.Contains( Integer.From( 2 ) ) );
    Assert( !c.Contains( Integer.From( 3 ) ) );

    Print( ".Stream( IInteger )" );
    Assert(
        c.Stream( Integer.From( 1 ) )
        .AsEnumerable()
        .SequenceEqual(
            new char[] { 'd' } ) );

    Print( ".GetAndReplaceAll( IInteger )" );
    f = c.GetAndReplaceAll( Integer.From( 1 ) );
    f.From = new Stream< char >( 'D' );
    to.Clear();
    f.EmptyTo( to.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new char[] { 'a', 'D', 'e' } ) );
    Assert(
        to.SequenceEqual(
            new char[] { 'd' } ) );

    Print( ".GetAndRemoveAll( IInteger )" );
    to.Clear();
    c.GetAndRemoveAll( Integer.From( 1 ) ).EmptyTo( to.AsSink() );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new char[] { 'a', 'e' } ) );
    Assert(
        to.SequenceEqual(
            new char[] { 'D' } ) );

    Print( ".Add( IInteger, char )" );
    c.Add( Integer.From( 1 ), 'b' );
    c.Add( Integer.From( 2 ), 'c' );
    c.Add( Integer.From( 3 ), 'd' );
    c.Add( Integer.From( 5 ), 'f' );
    Assert(
        c.Stream().AsEnumerable().SequenceEqual(
            new char[] { 'a', 'b', 'c', 'd', 'e', 'f' } ) );

    Print( ".Count" );
    Assert( c.Count.Equals( Integer.From( 6 ) ) );

    Print( ".StreamPairs()" );
    IStream< ITuple< IInteger, char > > ts =
        c.StreamPairs();
    ITuple< IInteger, char > tup;
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 0 ) ) );  Assert( tup.B == 'a' );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 1 ) ) );  Assert( tup.B == 'b' );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 2 ) ) );  Assert( tup.B == 'c' );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 3 ) ) );  Assert( tup.B == 'd' );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 4 ) ) );  Assert( tup.B == 'e' );
    Assert( ts.TryPull( out tup ) );
    Assert( tup.A.Equals( Integer.From( 5 ) ) );  Assert( tup.B == 'f' );
    Assert( !ts.TryPull( out tup ) );
}




} // type
} // namespace

