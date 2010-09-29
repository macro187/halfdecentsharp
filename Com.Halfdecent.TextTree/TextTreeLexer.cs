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


using System.Linq;
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
    : FilterBase< string, Token >
{



// -----------------------------------------------------------------------------
// FilterBase
// -----------------------------------------------------------------------------

protected override
    System.Collections.Generic.IEnumerator< bool >
Process()
{
    IOrderedCollectionRCSG< char > indent = new ArrayList< char >();
    IOrderedCollectionRCSG< IInteger > stops = new ArrayList< IInteger >();

    for( ;; ) {

        // Get the next line
        yield return false;
        string line = this.GetItem();

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
                    stops.Count.Minus( Integer.From( 1 ) ) ) );
            stops.RemoveLast();

            this.PutItem( new DeindentToken() ); 
            yield return true;
        }

        // Pop stops off the indent until it equals the same section of the
        // new indent
        while( !indent.SequenceEqual(
            newindent.Slice( Integer.From( 0 ), indent.Count ) )
        ) {
            indent.RemoveLast(
                stops.Get(
                    stops.Count.Minus( Integer.From( 1 ) ) ) );
            stops.RemoveLast();

            this.PutItem( new DeindentToken() ); 
            yield return true;
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

            this.PutItem( new IndentToken() ); 
            yield return true;
        }

        // Yield the data
        // TODO Trim?
        if( data.Count.Equals( Integer.From( 0 ) ) ) continue;

        this.PutItem(
            new DataToken(
                new string( data.Stream().AsEnumerable().ToArray() ) ) );
        yield return true;
    }
}




} // type
} // namespace
