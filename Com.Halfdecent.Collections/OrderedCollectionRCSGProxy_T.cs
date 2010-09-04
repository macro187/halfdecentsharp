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
OrderedCollectionRCSGProxy<
    T
>
    : IOrderedCollectionRCSG< T >
{



public
OrderedCollectionRCSGProxy(
    IOrderedCollectionRCSG< T > from
)
{
    new NonNull().Require( from, new Parameter( "from" ) );
    this.From = from;
}


protected
    IOrderedCollectionRCSG< T >
From
{
    get;
    private set;
}



#region TRAITOR
// ICollection.Proxy
// ICollectionR< T >.Proxy
// ICollectionC< T >.Proxy
// ICollectionS.Proxy
// ICollectionG< T >.Proxy
// ICollectionRC< T >.Proxy
// ICollectionRS< T >.Proxy
// ICollectionRG< T >.Proxy
// ICollectionCS< T >.Proxy
// ICollectionCG< T >.Proxy
// ICollectionSG< T >.Proxy
// ICollectionRCS< T >.Proxy
// ICollectionRCG< T >.Proxy
// ICollectionRSG< T >.Proxy
// IKeyedCollection.Proxy
// IUniqueKeyedCollection.Proxy
// IOrderedCollection.Proxy
// IOrderedCollectionR< T >.Proxy
// IOrderedCollectionC< T >.Proxy
// IOrderedCollectionS.Proxy
// IOrderedCollectionG< T >.Proxy
// IOrderedCollectionRC< T >.Proxy
// IOrderedCollectionRS< T >.Proxy
// IOrderedCollectionRG< T >.Proxy
// IOrderedCollectionCS< T >.Proxy
// IOrderedCollectionCG< T >.Proxy
// IOrderedCollectionSG< T >.Proxy
// IOrderedCollectionRCS< T >.Proxy
// IOrderedCollectionRCG< T >.Proxy
// IOrderedCollectionRSG< T >.Proxy
// IOrderedCollectionCSG< T >.Proxy
// IOrderedCollectionRCSG< T >.Proxy
#endregion




} // type
} // namespace

