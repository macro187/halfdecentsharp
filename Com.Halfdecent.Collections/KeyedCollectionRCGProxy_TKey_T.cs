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
KeyedCollectionRCGProxy<
    TKey,
    T
>
    : IKeyedCollectionRCG< TKey, T >
{



public
KeyedCollectionRCGProxy(
    IKeyedCollectionRCG< TKey, T > from
)
{
    new NonNull().Require( from, new Parameter( "from" ) );
    this.From = from;
}


protected
    IKeyedCollectionRCG< TKey, T >
From
{
    get;
    private set;
}



#region TRAITOR
// ICollection.Proxy
// ICollectionR< T >.Proxy
// ICollectionC< T >.Proxy
// ICollectionRC< T >.Proxy
// IKeyedCollection.Proxy
// IKeyedCollectionR< TKey, T >.Proxy
// IKeyedCollectionC< TKey, T >.Proxy
// IKeyedCollectionG< TKey, T >.Proxy
// IKeyedCollectionRC< TKey, T >.Proxy
// IKeyedCollectionRG< TKey, T >.Proxy
// IKeyedCollectionCG< TKey, T >.Proxy
// IKeyedCollectionRCG< TKey, T >.Proxy
#endregion




} // type
} // namespace

