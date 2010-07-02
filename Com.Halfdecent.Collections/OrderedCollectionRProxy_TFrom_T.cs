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
using Com.Halfdecent.Numerics;
using Com.Halfdecent.Streams;


namespace
Com.Halfdecent.Collections
{


public class
OrderedCollectionRProxy<
    TFrom,
    T
>
    : OrderedCollectionProxy
    , IOrderedCollectionR< T >

    where TFrom : T
{



public
OrderedCollectionRProxy(
    IOrderedCollectionR< TFrom > from
)
    : base( from )
{
    this.From = from;
}


new protected
    IOrderedCollectionR< TFrom >
From
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// ICollectionR< T >
// -----------------------------------------------------------------------------

public IStream< T > Stream() { return this.From.Stream().Covary< TFrom, T >(); }



// -----------------------------------------------------------------------------
// IKeyedCollectionR< IInteger, T >
// -----------------------------------------------------------------------------

public IStream< ITuple< IInteger, T > > StreamPairs() { return this.From.StreamPairs().AsEnumerable().Select( t => t.Covary< IInteger, TFrom, IInteger, T >() ).AsStream(); }

public bool Contains( IInteger key ) { return this.From.Contains( key ); }

public IStream< T > Stream( IInteger key ) { return this.From.Stream( key ).Covary< TFrom, T >(); }



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionR< IInteger, T >
// -----------------------------------------------------------------------------

public T Get( IInteger key ) { return this.From.Get( key ); }




} // type
} // namespace

