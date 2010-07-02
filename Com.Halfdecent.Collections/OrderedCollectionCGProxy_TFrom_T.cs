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


using Com.Halfdecent.Numerics;


namespace
Com.Halfdecent.Collections
{


public class
OrderedCollectionCGProxy<
    TFrom,
    T
>
    : OrderedCollectionProxy
    , IOrderedCollectionCG< T >

    where T : TFrom
{



public
OrderedCollectionCGProxy(
    IOrderedCollectionCG< TFrom > from
)
    : base( from )
{
    this.From = from;
}


new protected
    IOrderedCollectionCG< TFrom >
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
// IKeyedCollectionG< IInteger, T >
// -----------------------------------------------------------------------------

public void Add( IInteger key, T item ) { this.From.Add( key, item ); }



// -----------------------------------------------------------------------------
// IUniqueKeyedCollectionC< IInteger, T >
// -----------------------------------------------------------------------------

public void Replace( IInteger key, T replacement ) { this.From.Replace( key, replacement ); }




} // type
} // namespace

