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


using System;
using Com.Halfdecent.Numerics;
using Com.Halfdecent.Streams;


namespace
Com.Halfdecent.Collections
{


public class
OrderedCollectionRSGProxy<
    T
>
    : OrderedCollectionProxy
    , IOrderedCollectionRSG< T >
{



public
OrderedCollectionRSGProxy(
    IOrderedCollectionRSG< T > from
)
    : base( from )
{
    this.From = from;
}


new protected
    IOrderedCollectionRSG< T >
From
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// ICollectionR< T >
// -----------------------------------------------------------------------------

public IStream< T > Stream() { return this.From.Stream(); }



// -----------------------------------------------------------------------------
// ICollectionG< T >
// -----------------------------------------------------------------------------

public void Add( T item ) { this.From.Add( item ); }



// -----------------------------------------------------------------------------
// ICollectionRS< T >
// -----------------------------------------------------------------------------

public IStream< T > GetAndRemoveWhere( Predicate< T > where ) { return this.From.GetAndRemoveWhere( where ); }



// -----------------------------------------------------------------------------
// IKeyedCollectionR< IInteger, T >
// -----------------------------------------------------------------------------

public IStream< ITuple< IInteger, T > > StreamPairs() { return this.From.StreamPairs(); }

public bool Contains( IInteger key ) { return this.From.Contains( key ); }

public IStream< T > Stream( IInteger key ) { return this.From.Stream( key ); }



// -----------------------------------------------------------------------------
// IKeyedCollectionS< IInteger >
// -----------------------------------------------------------------------------

public void RemoveAll( IInteger key ) { this.From.RemoveAll( key ); }



// -----------------------------------------------------------------------------
// IKeyedCollectionG< IInteger, T >
// -----------------------------------------------------------------------------

public void Add( IInteger key, T item ) { this.From.Add( key, item ); }



// -----------------------------------------------------------------------------
// IKeyedCollectionRS< IInteger, T >
// -----------------------------------------------------------------------------

public IStream< T > GetAndRemoveAll( IInteger key ) { return this.From.GetAndRemoveAll( key ); }



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionR< IInteger, T >
// -----------------------------------------------------------------------------

public T Get( IInteger key ) { return this.From.Get( key ); }



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionS< IInteger >
// -----------------------------------------------------------------------------

public void Remove( IInteger key ) { this.From.Remove( key ); }




} // type
} // namespace
