// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2011, 2012
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
using System.Linq;
using SCG = System.Collections.Generic;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Numerics;
using Com.Halfdecent.Collections;


namespace
Com.Halfdecent.TextTree
{


// =============================================================================
/// Lexes lines of TextTree text into tokens
// =============================================================================

public class
Lexer
    : Filter< string, Token >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
Lexer()
    : base(
        (getState,get,put) => Process( getState, get, put ),
        null,
        () => {;} )
{
}



// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private static
    SCG.IEnumerator< FilterState >
Process(
    Func< FilterState > getState,
    Func< string >      get,
    Action< Token >     put
)
{
    var indent = ArrayList.Create< char >();
    var stops = ArrayList.Create< IInteger >();
    int linenum = 0;

    for( ;; ) {

        // Get the next line
        yield return FilterState.Want;
        if( getState() == FilterState.Closed ) break;
        string line = get();
        linenum++;

        // Split the indent and data apart
        IOrderedCollectionR< char > newindent;
        IOrderedCollectionR< char > data;
        line.AsHalfdecentCollection()
            .SplitBeforeFirstWhere( c => c != ' ' && c != '\t' )
            .AssignTo( out newindent, out data );

        // Pop stops off indent until it's the same length (or shorter) than
        // the new indent
        while( indent.Count.GT( newindent.Count ) ) {
            indent.RemoveLast(
                stops.Get(
                    stops.Count.Minus( Integer.Create( 1 ) ) ) );
            stops.RemoveLast();

            put( new DeindentToken( linenum ) );
            yield return FilterState.Have;
        }

        // Pop stops off the indent until it equals the same section of the
        // new indent
        while( !indent.Stream().SequenceEqual(
            newindent.Slice( Integer.Create( 0 ), indent.Count ).Stream() )
        ) {
            indent.RemoveLast(
                stops.Get(
                    stops.Count.Minus( Integer.Create( 1 ) ) ) );
            stops.RemoveLast();

            put( new DeindentToken( linenum ) );
            yield return FilterState.Have;
        }

        // If the new indent is longer than indent, push a new stop
        if( newindent.Count.GT( indent.Count ) ) {
            IInteger stoplen = newindent.Count.Minus( indent.Count );
            stops.Add( stoplen );
            newindent
                .Slice( indent.Count, stoplen )
                .Stream()
                .EmptyTo(
                    indent.AsSink() );

            put( new IndentToken( linenum ) );
            yield return FilterState.Have;
        }

        // Yield the data
        // TODO Trim?
        if( data.Count.Equals( Integer.Create( 0 ) ) ) continue;

        put(
            new DataToken(
                new string( data.Stream().AsEnumerable().ToArray() ),
                linenum ) );
        yield return FilterState.Have;
    }

    int stopcount = (int)stops.Count.GetValue();
    for( int i = 0; i < stopcount; i++ ) {
        put( new DeindentToken( linenum ) );
        yield return FilterState.Have;
    }
}




} // type
} // namespace

