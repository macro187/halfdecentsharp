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


/// IImplicitKeyedCollection/*PERMUDA*/ proxy
///
public class
ImplicitKeyedCollection/*PERMUDA*/Proxy/*PERMUDA PROXYSUFFIX*/
    : IImplicitKeyedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/

    /*PERMUDA WHERE*/
{



public
ImplicitKeyedCollection/*PERMUDA*/Proxy(
    IImplicitKeyedCollection/*PERMUDA*//*PERMUDA FROMSUFFIX*/ from
)
{
    new NonNull().Require( from, new Parameter( "from" ) );
    this.From = from;
}


protected
    IImplicitKeyedCollection/*PERMUDA*//*PERMUDA FROMSUFFIX*/
From
{
    get;
    private set;
}



#region TRAITOR
// ICollection.Proxy
// IKeyedCollection.Proxy
/*PERMUDA TRAITS*/
#endregion



#region PERMUDA
// combos G RG SG RSG
// filename ImplicitKeyedCollection/*PERMUDA*/Proxy/*PERMUDA FILESUFFIX*/.cs
#endregion
#region PERMUDA FILESUFFIX
// G:       _TFrom_T
// RG:      _TKey_T
// SG:      _TKeyFrom_TFrom_TKey_T
// RSG:     _TKey_T
#endregion
#region PERMUDA PROXYSUFFIX
// G:       < TFrom, T >
// RG:      < TKey, T >
// SG:      < TKeyFrom, TFrom, TKey, T >
// RSG:     < TKey, T >
#endregion
#region PERMUDA TYPESUFFIX
// G:       < T >
// RG:      < TKey, T >
// SG:      < TKey, T >
// RSG:     < TKey, T >
#endregion
#region PERMUDA WHERE
// G:       where T : TFrom
// RG:
// SG:      where TKey : TKeyFrom where T : TFrom
// RSG:
#endregion
#region PERMUDA FROMSUFFIX
// G:       < TFrom >
// RG:      < TKey, T >
// SG:      < TKeyFrom, TFrom >
// RSG:     < TKey, T >
#endregion
#region PERMUDA TRAITS G
// ICollectionG< T >.Proxy
// IImplicitKeyedCollectionG< T >.Proxy
#endregion
#region PERMUDA TRAITS RG
// ICollectionR< T >.Proxy
// ICollectionG< T >.Proxy
// ICollectionRG< T >.Proxy
// IKeyedCollectionR< TKey, T >.Proxy
// IImplicitKeyedCollectionG< T >.Proxy
// IImplicitKeyedCollectionRG< TKey, T >.Proxy
#endregion
#region PERMUDA TRAITS SG
// ICollectionS.Proxy
// ICollectionG< T >.Proxy
// ICollectionSG< T >.Proxy
// IKeyedCollectionS< TKey >.Proxy
// IImplicitKeyedCollectionG< T >.Proxy
// IImplicitKeyedCollectionSG< TKey, T >.Proxy
#endregion
#region PERMUDA TRAITS RSG
// ICollectionR< T >.Proxy
// ICollectionS.Proxy
// ICollectionG< T >.Proxy
// ICollectionRS< T >.Proxy
// ICollectionRG< T >.Proxy
// ICollectionSG< T >.Proxy
// ICollectionRSG< T >.Proxy
// IKeyedCollectionR< TKey, T >.Proxy
// IKeyedCollectionS< TKey >.Proxy
// IKeyedCollectionRS< TKey, T >.Proxy
// IImplicitKeyedCollectionG< T >.Proxy
// IImplicitKeyedCollectionRG< TKey, T >.Proxy
// IImplicitKeyedCollectionSG< TKey, T >.Proxy
// IImplicitKeyedCollectionRSG< TKey, T >.Proxy
#endregion




} // type
} // namespace

