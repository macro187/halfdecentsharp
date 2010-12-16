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


/// IKeyedCollection/*PERMUDA*/ proxy
///
public class
KeyedCollection/*PERMUDA*/Proxy/*PERMUDA PROXYSUFFIX*/
    : IKeyedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/
    , IProxy

    /*PERMUDA WHERE*/
{



public
KeyedCollection/*PERMUDA*/Proxy(
    IKeyedCollection/*PERMUDA*//*PERMUDA FROMSUFFIX*/ from
)
{
    NonNull.CheckParameter( from, "from" );
    this.From = from;
}


protected
    IKeyedCollection/*PERMUDA*//*PERMUDA FROMSUFFIX*/
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



// -----------------------------------------------------------------------------
// IProxy
// -----------------------------------------------------------------------------

    object
IProxy.Underlying
{
    get { return this.From; }
}



#region PERMUDA
// permute _RCSG
// filename KeyedCollection/*PERMUDA*/Proxy/*PERMUDA FILESUFFIX*/.cs
#endregion
#region PERMUDA FILESUFFIX
// R:       _TFrom_TKey_T
// C:       _TKeyFrom_TFrom_TKey_T
// S:       _TKeyFrom_TKey
// G:       _TKeyFrom_TFrom_TKey_T
// RC:      _TKey_T
// RS:      _TKey_T
// RG:      _TKey_T
// CS:      _TKeyFrom_TFrom_TKey_T
// CG:      _TKeyFrom_TFrom_TKey_T
// SG:      _TKeyFrom_TFrom_TKey_T
// RCS:     _TKey_T
// RCG:     _TKey_T
// RSG:     _TKey_T
// CSG:     _TKey_T
// RCSG:    _TKey_T
#endregion
#region PERMUDA PROXYSUFFIX
// R:       < TFrom, TKey, T >
// C:       < TKeyFrom, TFrom, TKey, T >
// S:       < TKeyFrom, TKey >
// G:       < TKeyFrom, TFrom, TKey, T >
// RC:      < TKey, T >
// RS:      < TKey, T >
// RG:      < TKey, T >
// CS:      < TKeyFrom, TFrom, TKey, T >
// CG:      < TKeyFrom, TFrom, TKey, T >
// SG:      < TKeyFrom, TFrom, TKey, T >
// RCS:     < TKey, T >
// RCG:     < TKey, T >
// RSG:     < TKey, T >
// CSG:     < TKey, T >
// RCSG:    < TKey, T >
#endregion
#region PERMUDA TYPESUFFIX
// R:       < TKey, T >
// C:       < TKey, T >
// S:       < TKey >
// G:       < TKey, T >
// RC:      < TKey, T >
// RS:      < TKey, T >
// RG:      < TKey, T >
// CS:      < TKey, T >
// CG:      < TKey, T >
// SG:      < TKey, T >
// RCS:     < TKey, T >
// RCG:     < TKey, T >
// RSG:     < TKey, T >
// CSG:     < TKey, T >
// RCSG:    < TKey, T >
#endregion
#region PERMUDA WHERE
// R:       where TFrom : T
// C:       where TKey : TKeyFrom where T : TFrom
// S:       where TKey : TKeyFrom
// G:       where TKey : TKeyFrom where T : TFrom
// RC:
// RS:
// RG:
// CS:      where TKey : TKeyFrom where T : TFrom
// CG:      where TKey : TKeyFrom where T : TFrom
// SG:      where TKey : TKeyFrom where T : TFrom
// RCS:
// RCG:
// RSG:
// CSG:
// RCSG:
#endregion
#region PERMUDA FROMSUFFIX
// R:       < TKey, TFrom >
// C:       < TKeyFrom, TFrom >
// S:       < TKeyFrom >
// G:       < TKeyFrom, TFrom >
// RC:      < TKey, T >
// RS:      < TKey, T >
// RG:      < TKey, T >
// CS:      < TKeyFrom, TFrom >
// CG:      < TKeyFrom, TFrom >
// SG:      < TKeyFrom, TFrom >
// RCS:     < TKey, T >
// RCG:     < TKey, T >
// RSG:     < TKey, T >
// CSG:     < TKey, T >
// RCSG:    < TKey, T >
#endregion
#region PERMUDA TRAITS R
// ICollectionR< out T >.Proxy
// IKeyedCollectionR< TKey, out T >.Proxy
#endregion
#region PERMUDA TRAITS C
// ICollectionC< T >.Proxy
// IKeyedCollectionC< TKey, T >.Proxy
#endregion
#region PERMUDA TRAITS S
// ICollectionS.Proxy
// IKeyedCollectionS< TKey >.Proxy
#endregion
#region PERMUDA TRAITS G
// IKeyedCollectionG< TKey, T >.Proxy
#endregion
#region PERMUDA TRAITS RC
// ICollectionR< T >.Proxy
// ICollectionC< T >.Proxy
// ICollectionRC< T >.Proxy
// IKeyedCollectionR< TKey, T >.Proxy
// IKeyedCollectionC< TKey, T >.Proxy
// IKeyedCollectionRC< TKey, T >.Proxy
#endregion
#region PERMUDA TRAITS RS
// ICollectionR< T >.Proxy
// ICollectionS.Proxy
// ICollectionRS< T >.Proxy
// IKeyedCollectionR< TKey, T >.Proxy
// IKeyedCollectionS< TKey >.Proxy
// IKeyedCollectionRS< TKey, T >.Proxy
#endregion
#region PERMUDA TRAITS RG
// ICollectionR< T >.Proxy
// IKeyedCollectionR< TKey, T >.Proxy
// IKeyedCollectionG< TKey, T >.Proxy
// IKeyedCollectionRG< TKey, T >.Proxy
#endregion
#region PERMUDA TRAITS CS
// ICollectionC< T >.Proxy
// ICollectionS.Proxy
// ICollectionCS< T >.Proxy
// IKeyedCollectionC< TKey, T >.Proxy
// IKeyedCollectionS< TKey >.Proxy
// IKeyedCollectionCS< TKey, T >.Proxy
#endregion
#region PERMUDA TRAITS CG
// ICollectionC< T >.Proxy
// IKeyedCollectionC< TKey, T >.Proxy
// IKeyedCollectionG< TKey, T >.Proxy
// IKeyedCollectionCG< TKey, T >.Proxy
#endregion
#region PERMUDA TRAITS SG
// ICollectionS.Proxy
// IKeyedCollectionS< TKey >.Proxy
// IKeyedCollectionG< TKey, T >.Proxy
// IKeyedCollectionSG< TKey, T >.Proxy
#endregion
#region PERMUDA TRAITS RCS
// ICollectionR< T >.Proxy
// ICollectionC< T >.Proxy
// ICollectionS.Proxy
// ICollectionRC< T >.Proxy
// ICollectionRS< T >.Proxy
// ICollectionCS< T >.Proxy
// ICollectionRCS< T >.Proxy
// IKeyedCollectionR< TKey, T >.Proxy
// IKeyedCollectionC< TKey, T >.Proxy
// IKeyedCollectionS< TKey >.Proxy
// IKeyedCollectionRC< TKey, T >.Proxy
// IKeyedCollectionRS< TKey, T >.Proxy
// IKeyedCollectionCS< TKey, T >.Proxy
// IKeyedCollectionRCS< TKey, T >.Proxy
#endregion
#region PERMUDA TRAITS RCG
// ICollectionR< T >.Proxy
// ICollectionC< T >.Proxy
// ICollectionRC< T >.Proxy
// IKeyedCollectionR< TKey, T >.Proxy
// IKeyedCollectionC< TKey, T >.Proxy
// IKeyedCollectionG< TKey, T >.Proxy
// IKeyedCollectionRC< TKey, T >.Proxy
// IKeyedCollectionRG< TKey, T >.Proxy
// IKeyedCollectionCG< TKey, T >.Proxy
// IKeyedCollectionRCG< TKey, T >.Proxy
#endregion
#region PERMUDA TRAITS RSG
// ICollectionR< T >.Proxy
// ICollectionS.Proxy
// ICollectionRS< T >.Proxy
// IKeyedCollectionR< TKey, T >.Proxy
// IKeyedCollectionS< TKey >.Proxy
// IKeyedCollectionG< TKey, T >.Proxy
// IKeyedCollectionRS< TKey, T >.Proxy
// IKeyedCollectionRG< TKey, T >.Proxy
// IKeyedCollectionSG< TKey, T >.Proxy
// IKeyedCollectionRSG< TKey, T >.Proxy
#endregion
#region PERMUDA TRAITS CSG
// ICollectionC< T >.Proxy
// ICollectionS.Proxy
// ICollectionCS< T >.Proxy
// IKeyedCollectionC< TKey, T >.Proxy
// IKeyedCollectionS< TKey >.Proxy
// IKeyedCollectionG< TKey, T >.Proxy
// IKeyedCollectionCS< TKey, T >.Proxy
// IKeyedCollectionCG< TKey, T >.Proxy
// IKeyedCollectionSG< TKey, T >.Proxy
// IKeyedCollectionCSG< TKey, T >.Proxy
#endregion
#region PERMUDA TRAITS RCSG
// ICollectionR< T >.Proxy
// ICollectionC< T >.Proxy
// ICollectionS.Proxy
// ICollectionRC< T >.Proxy
// ICollectionRS< T >.Proxy
// ICollectionCS< T >.Proxy
// ICollectionRCS< T >.Proxy
// IKeyedCollectionR< TKey, T >.Proxy
// IKeyedCollectionC< TKey, T >.Proxy
// IKeyedCollectionS< TKey >.Proxy
// IKeyedCollectionG< TKey, T >.Proxy
// IKeyedCollectionRC< TKey, T >.Proxy
// IKeyedCollectionRS< TKey, T >.Proxy
// IKeyedCollectionRG< TKey, T >.Proxy
// IKeyedCollectionCS< TKey, T >.Proxy
// IKeyedCollectionCG< TKey, T >.Proxy
// IKeyedCollectionSG< TKey, T >.Proxy
// IKeyedCollectionRCS< TKey, T >.Proxy
// IKeyedCollectionRCG< TKey, T >.Proxy
// IKeyedCollectionRSG< TKey, T >.Proxy
// IKeyedCollectionCSG< TKey, T >.Proxy
// IKeyedCollectionRCSG< TKey, T >.Proxy
#endregion




} // type
} // namespace

