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


using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Streams;


namespace
Com.Halfdecent.Collections
{


public class
ImplicitUniqueKeyedCollectionRGProxy<
    TKey,
    T
>
    : UniqueKeyedCollectionProxy
    , IImplicitUniqueKeyedCollectionRG< TKey, T >
{



public
ImplicitUniqueKeyedCollectionRGProxy(
    IImplicitUniqueKeyedCollectionRG< TKey, T > from
)
    : base( from )
{
    this.From = from;
}


new protected
    IImplicitUniqueKeyedCollectionRG< TKey, T >
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
// IKeyedCollectionR< TKey, T >
// -----------------------------------------------------------------------------

public IStream< ITuple< TKey, T > > StreamPairs() { return this.From.StreamPairs(); }

public bool Contains( TKey key ) { return this.From.Contains( key ); }

public IStream< T > Stream( TKey key ) { return this.From.Stream( key ); }



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionR< TKey, T >
// -----------------------------------------------------------------------------

public T Get( TKey key ) { return this.From.Get( key ); }




} // type
} // namespace
