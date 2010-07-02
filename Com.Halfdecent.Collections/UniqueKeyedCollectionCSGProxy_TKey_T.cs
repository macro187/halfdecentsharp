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


namespace
Com.Halfdecent.Collections
{


public class
UniqueKeyedCollectionCSGProxy<
    TKey,
    T
>
    : UniqueKeyedCollectionProxy
    , IUniqueKeyedCollectionCSG< TKey, T >
{



public
UniqueKeyedCollectionCSGProxy(
    IUniqueKeyedCollectionCSG< TKey, T > from
)
    : base( from )
{
    this.From = from;
}


new protected
    IUniqueKeyedCollectionCSG< TKey, T >
From
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// IKeyedCollectionS< TKey >
// -----------------------------------------------------------------------------

public void RemoveAll( TKey key ) { this.From.RemoveAll( key ); }



// -----------------------------------------------------------------------------
// IKeyedCollectionG< TKey, T >
// -----------------------------------------------------------------------------

public void Add( TKey key, T item ) { this.From.Add( key, item ); }



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionC< TKey, T >
// -----------------------------------------------------------------------------

public void Replace( TKey key, T replacement ) { this.From.Replace( key, replacement ); }



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionS< TKey >
// -----------------------------------------------------------------------------

public void Remove( TKey key ) { this.From.Remove( key ); }




} // type
} // namespace

