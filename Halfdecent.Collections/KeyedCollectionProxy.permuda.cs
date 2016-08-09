#region PERMUDA
// permute _RCSG
// filename KeyedCollection/*PERMUDA*/Proxy/*PERMUDA FILESUFFIX*/.cs
#endregion
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


using Halfdecent.Meta;
using Halfdecent.RTypes;


namespace
Halfdecent.Collections
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
#region PERMUDA TRAITS _
// ICollection.Proxy
// IKeyedCollection.Proxy
#endregion
#region PERMUDA TRAITS R
// ICollection.Proxy
// ICollectionR.Proxy
// IKeyedCollection.Proxy
// IKeyedCollectionR.Proxy
#endregion
#region PERMUDA TRAITS C
// ICollection.Proxy
// ICollectionC.Proxy
// IKeyedCollection.Proxy
// IKeyedCollectionC.Proxy
#endregion
#region PERMUDA TRAITS S
// ICollection.Proxy
// ICollectionS.Proxy
// IKeyedCollection.Proxy
// IKeyedCollectionS.Proxy
#endregion
#region PERMUDA TRAITS G
// ICollection.Proxy
// IKeyedCollection.Proxy
// IKeyedCollectionG.Proxy
#endregion
#region PERMUDA TRAITS RC
// ICollection.Proxy
// ICollectionR.Proxy.Invariant
// ICollectionC.Proxy
// ICollectionRC.Proxy
// IKeyedCollection.Proxy
// IKeyedCollectionR.Proxy.Invariant
// IKeyedCollectionC.Proxy
// IKeyedCollectionRC.Proxy
#endregion
#region PERMUDA TRAITS RS
// ICollection.Proxy
// ICollectionR.Proxy.Invariant
// ICollectionS.Proxy
// ICollectionRS.Proxy
// IKeyedCollection.Proxy
// IKeyedCollectionR.Proxy.Invariant
// IKeyedCollectionS.Proxy
// IKeyedCollectionRS.Proxy
#endregion
#region PERMUDA TRAITS RG
// ICollection.Proxy
// ICollectionR.Proxy.Invariant
// IKeyedCollection.Proxy
// IKeyedCollectionR.Proxy.Invariant
// IKeyedCollectionG.Proxy
// IKeyedCollectionRG.Proxy
#endregion
#region PERMUDA TRAITS CS
// ICollection.Proxy
// ICollectionC.Proxy
// ICollectionS.Proxy
// ICollectionCS.Proxy
// IKeyedCollection.Proxy
// IKeyedCollectionC.Proxy
// IKeyedCollectionS.Proxy
// IKeyedCollectionCS.Proxy
#endregion
#region PERMUDA TRAITS CG
// ICollection.Proxy
// ICollectionC.Proxy
// IKeyedCollection.Proxy
// IKeyedCollectionC.Proxy
// IKeyedCollectionG.Proxy
// IKeyedCollectionCG.Proxy
#endregion
#region PERMUDA TRAITS SG
// ICollection.Proxy
// ICollectionS.Proxy
// IKeyedCollection.Proxy
// IKeyedCollectionS.Proxy
// IKeyedCollectionG.Proxy
// IKeyedCollectionSG.Proxy
#endregion
#region PERMUDA TRAITS RCS
// ICollection.Proxy
// ICollectionR.Proxy.Invariant
// ICollectionC.Proxy
// ICollectionS.Proxy
// ICollectionRC.Proxy
// ICollectionRS.Proxy
// ICollectionCS.Proxy
// ICollectionRCS.Proxy
// IKeyedCollection.Proxy
// IKeyedCollectionR.Proxy.Invariant
// IKeyedCollectionC.Proxy
// IKeyedCollectionS.Proxy
// IKeyedCollectionRC.Proxy
// IKeyedCollectionRS.Proxy
// IKeyedCollectionCS.Proxy
// IKeyedCollectionRCS.Proxy
#endregion
#region PERMUDA TRAITS RCG
// ICollection.Proxy
// ICollectionR.Proxy.Invariant
// ICollectionC.Proxy
// ICollectionRC.Proxy
// IKeyedCollection.Proxy
// IKeyedCollectionR.Proxy.Invariant
// IKeyedCollectionC.Proxy
// IKeyedCollectionG.Proxy
// IKeyedCollectionRC.Proxy
// IKeyedCollectionRG.Proxy
// IKeyedCollectionCG.Proxy
// IKeyedCollectionRCG.Proxy
#endregion
#region PERMUDA TRAITS RSG
// ICollection.Proxy
// ICollectionR.Proxy.Invariant
// ICollectionS.Proxy
// ICollectionRS.Proxy
// IKeyedCollection.Proxy
// IKeyedCollectionR.Proxy.Invariant
// IKeyedCollectionS.Proxy
// IKeyedCollectionG.Proxy
// IKeyedCollectionRS.Proxy
// IKeyedCollectionRG.Proxy
// IKeyedCollectionSG.Proxy
// IKeyedCollectionRSG.Proxy
#endregion
#region PERMUDA TRAITS CSG
// ICollection.Proxy
// ICollectionC.Proxy
// ICollectionS.Proxy
// ICollectionCS.Proxy
// IKeyedCollection.Proxy
// IKeyedCollectionC.Proxy
// IKeyedCollectionS.Proxy
// IKeyedCollectionG.Proxy
// IKeyedCollectionCS.Proxy
// IKeyedCollectionCG.Proxy
// IKeyedCollectionSG.Proxy
// IKeyedCollectionCSG.Proxy
#endregion
#region PERMUDA TRAITS RCSG
// ICollection.Proxy
// ICollectionR.Proxy.Invariant
// ICollectionC.Proxy
// ICollectionS.Proxy
// ICollectionRC.Proxy
// ICollectionRS.Proxy
// ICollectionCS.Proxy
// ICollectionRCS.Proxy
// IKeyedCollection.Proxy
// IKeyedCollectionR.Proxy.Invariant
// IKeyedCollectionC.Proxy
// IKeyedCollectionS.Proxy
// IKeyedCollectionG.Proxy
// IKeyedCollectionRC.Proxy
// IKeyedCollectionRS.Proxy
// IKeyedCollectionRG.Proxy
// IKeyedCollectionCS.Proxy
// IKeyedCollectionCG.Proxy
// IKeyedCollectionSG.Proxy
// IKeyedCollectionRCS.Proxy
// IKeyedCollectionRCG.Proxy
// IKeyedCollectionRSG.Proxy
// IKeyedCollectionCSG.Proxy
// IKeyedCollectionRCSG.Proxy
#endregion




} // type
} // namespace

