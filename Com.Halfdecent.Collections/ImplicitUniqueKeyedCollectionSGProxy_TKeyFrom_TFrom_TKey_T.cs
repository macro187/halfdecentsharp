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
ImplicitUniqueKeyedCollectionSGProxy<
    TKeyFrom,
    TFrom,
    TKey,
    T
>
    : UniqueKeyedCollectionProxy
    , IImplicitUniqueKeyedCollectionSG< TKey, T >

    where TKey : TKeyFrom
    where T : TFrom
{



public
ImplicitUniqueKeyedCollectionSGProxy(
    IImplicitUniqueKeyedCollectionSG< TKeyFrom, TFrom > from
)
    : base( from )
{
    this.From = from;
}


new protected
    IImplicitUniqueKeyedCollectionSG< TKeyFrom, TFrom >
From
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// ICollectionG< T >
// -----------------------------------------------------------------------------

public void Add( T item ) { this.From.Add( item ); }



// -----------------------------------------------------------------------------
// IKeyedCollectionS< TKey >
// -----------------------------------------------------------------------------

public void RemoveAll( TKey key ) { this.From.RemoveAll( key ); }



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionS< TKey >
// -----------------------------------------------------------------------------

public void Remove( TKey key ) { this.From.Remove( key ); }




} // type
} // namespace

