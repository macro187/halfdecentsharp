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
using System.Linq;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Streams;


namespace
Com.Halfdecent.Collections
{


public class
KeyedCollectionRSProxy<
    TKey,
    T
>
    : KeyedCollectionProxy
    , IKeyedCollectionRS< TKey, T >
{



public
KeyedCollectionRSProxy(
    IKeyedCollectionRS< TKey, T > from
)
    : base( from )
{
    this.From = from;
}


new protected
    IKeyedCollectionRS< TKey, T >
From
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// ICollectionR< T >
// -----------------------------------------------------------------------------

public IStream< T > Stream() { return this.From.Stream().Covary< T, T >(); }



// -----------------------------------------------------------------------------
// ICollectionRS< T >
// -----------------------------------------------------------------------------

public IStream< T > GetAndRemoveWhere( Predicate< T > where ) { return this.From.GetAndRemoveWhere( where ); }



// -----------------------------------------------------------------------------
// IKeyedCollectionR< TKey, T >
// -----------------------------------------------------------------------------

public IStream< ITuple< TKey, T > > StreamPairs() { return this.From.StreamPairs(); }

public bool Contains( TKey key ) { return this.From.Contains( key ); }

public IStream< T > Stream( TKey key ) { return this.From.Stream( key ); }



// -----------------------------------------------------------------------------
// IKeyedCollectionS< TKey >
// -----------------------------------------------------------------------------

public void RemoveAll( TKey key ) { this.From.RemoveAll( key ); }



// -----------------------------------------------------------------------------
// IKeyedCollectionRS< TKey, T >
// -----------------------------------------------------------------------------

public IStream< T > GetAndRemoveAll( TKey key ) { return this.From.GetAndRemoveAll( key ); }




} // type
} // namespace

