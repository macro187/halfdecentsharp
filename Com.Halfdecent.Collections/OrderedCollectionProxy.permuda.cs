#region PERMUDA
// permute _RCSG
// filename OrderedCollection/*PERMUDA*/Proxy/*PERMUDA FILESUFFIX*/.cs
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


using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Collections
{


/// IOrderedCollection/*PERMUDA*/ proxy
///
public class
OrderedCollection/*PERMUDA*/Proxy/*PERMUDA PROXYSUFFIX*/
    : IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/
    , IProxy

    /*PERMUDA WHERE*/
{



public
OrderedCollection/*PERMUDA*/Proxy(
    IOrderedCollection/*PERMUDA*//*PERMUDA FROMSUFFIX*/ from
)
{
    NonNull.CheckParameter( from, "from" );
    this.From = from;
}


protected
    IOrderedCollection/*PERMUDA*//*PERMUDA FROMSUFFIX*/
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



#if TRAITOR
// Trait OrderedCollectionProxy/*PERMUDA*/.Slice< T >

    IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/
IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/.Slice(
    long index,
    long count
)
{
    return this.From.Slice( index, count );
}
#endif



#if TRAITOR
// Trait OrderedCollectionProxy/*PERMUDA*/.Slice< in T >

    IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/
IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/.Slice(
    long index,
    long count
)
{
    return this.From.Contravary< TFrom, T >().Slice( index, count );
}
#endif



#if TRAITOR
// Trait OrderedCollectionProxy/*PERMUDA*/.Slice< out T >

    IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/
IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/.Slice(
    long index,
    long count
)
{
    return this.From.Covary< TFrom, T >().Slice( index, count );
}
#endif



#region PERMUDA FILESUFFIX
// R:       _TFrom_T
// C:       _TFrom_T
// S:
// G:       _TFrom_T
// RC:      _T
// RS:      _T
// RG:      _T
// CS:      _TFrom_T
// CG:      _TFrom_T
// SG:      _TFrom_T
// RCS:     _T
// RCG:     _T
// RSG:     _T
// CSG:     _T
// RCSG:    _T
#endregion
#region PERMUDA PROXYSUFFIX
// R:       < TFrom, T >
// C:       < TFrom, T >
// S:
// G:       < TFrom, T >
// RC:      < T >
// RS:      < T >
// RG:      < T >
// CS:      < TFrom, T >
// CG:      < TFrom, T >
// SG:      < TFrom, T >
// RCS:     < T >
// RCG:     < T >
// RSG:     < T >
// CSG:     < T >
// RCSG:    < T >
#endregion
#region PERMUDA TYPESUFFIX
// R:       < T >
// C:       < T >
// S:
// G:       < T >
// RC:      < T >
// RS:      < T >
// RG:      < T >
// CS:      < T >
// CG:      < T >
// SG:      < T >
// RCS:     < T >
// RCG:     < T >
// RSG:     < T >
// CSG:     < T >
// RCSG:    < T >
#endregion
#region PERMUDA WHERE
// R:       where TFrom : T
// C:       where T : TFrom
// S:
// G:       where T : TFrom
// RC:
// RS:
// RG:
// CS:      where T : TFrom
// CG:      where T : TFrom
// SG:      where T : TFrom
// RCS:
// RCG:
// RSG:
// CSG:
// RCSG:
#endregion
#region PERMUDA FROMSUFFIX
// R:       < TFrom >
// C:       < TFrom >
// S:
// G:       < TFrom >
// RC:      < T >
// RS:      < T >
// RG:      < T >
// CS:      < TFrom >
// CG:      < TFrom >
// SG:      < TFrom >
// RCS:     < T >
// RCG:     < T >
// RSG:     < T >
// CSG:     < T >
// RCSG:    < T >
#endregion
#region PERMUDA TRAITS _
// ICollection.Proxy
// IKeyedCollection.Proxy
// IUniqueKeyedCollection.Proxy
// OrderedCollectionProxy.Slice< T >
#endregion
#region PERMUDA TRAITS R
// ICollection.Proxy
// ICollectionR.Proxy
// IKeyedCollection.Proxy
// IUniqueKeyedCollection.Proxy
// IOrderedCollection.Proxy
// IOrderedCollectionR.Proxy
// OrderedCollectionProxy.Slice< out T >
// OrderedCollectionProxyR.Slice< out T >
#endregion
#region PERMUDA TRAITS C
// ICollection.Proxy
// ICollectionC.Proxy
// IKeyedCollection.Proxy
// IUniqueKeyedCollection.Proxy
// IOrderedCollection.Proxy
// IOrderedCollectionC.Proxy
// OrderedCollectionProxy.Slice< in T >
// OrderedCollectionProxyC.Slice< in T >
#endregion
#region PERMUDA TRAITS S
// ICollection.Proxy
// ICollectionS.Proxy
// IKeyedCollection.Proxy
// IUniqueKeyedCollection.Proxy
// IOrderedCollection.Proxy
// IOrderedCollectionS.Proxy
// OrderedCollectionProxy.Slice< T >
// OrderedCollectionProxyS.Slice< T >
#endregion
#region PERMUDA TRAITS G
// ICollection.Proxy
// ICollectionG.Proxy
// IKeyedCollection.Proxy
// IUniqueKeyedCollection.Proxy
// IOrderedCollection.Proxy
// IOrderedCollectionG.Proxy
// OrderedCollectionProxy.Slice< in T >
// OrderedCollectionProxyG.Slice< in T >
#endregion
#region PERMUDA TRAITS RC
// ICollection.Proxy
// ICollectionR.Proxy.Invariant
// ICollectionC.Proxy
// ICollectionRC.Proxy
// IKeyedCollection.Proxy
// IUniqueKeyedCollection.Proxy
// IOrderedCollection.Proxy
// IOrderedCollectionR.Proxy.Invariant
// IOrderedCollectionC.Proxy
// IOrderedCollectionRC.Proxy
// OrderedCollectionProxy.Slice< T >
// OrderedCollectionProxyR.Slice< T >
// OrderedCollectionProxyC.Slice< T >
// OrderedCollectionProxyRC.Slice< T >
#endregion
#region PERMUDA TRAITS RS
// ICollection.Proxy
// ICollectionR.Proxy.Invariant
// ICollectionS.Proxy
// ICollectionRS.Proxy
// IKeyedCollection.Proxy
// IUniqueKeyedCollection.Proxy
// IOrderedCollection.Proxy
// IOrderedCollectionR.Proxy.Invariant
// IOrderedCollectionS.Proxy
// IOrderedCollectionRS.Proxy
// OrderedCollectionProxy.Slice< T >
// OrderedCollectionProxyR.Slice< T >
// OrderedCollectionProxyS.Slice< T >
// OrderedCollectionProxyRS.Slice< T >
#endregion
#region PERMUDA TRAITS RG
// ICollection.Proxy
// ICollectionR.Proxy.Invariant
// ICollectionG.Proxy
// ICollectionRG.Proxy
// IKeyedCollection.Proxy
// IUniqueKeyedCollection.Proxy
// IOrderedCollection.Proxy
// IOrderedCollectionR.Proxy.Invariant
// IOrderedCollectionG.Proxy
// IOrderedCollectionRG.Proxy
// OrderedCollectionProxy.Slice< T >
// OrderedCollectionProxyR.Slice< T >
// OrderedCollectionProxyG.Slice< T >
// OrderedCollectionProxyRG.Slice< T >
#endregion
#region PERMUDA TRAITS CS
// ICollection.Proxy
// ICollectionC.Proxy
// ICollectionS.Proxy
// ICollectionCS.Proxy
// IKeyedCollection.Proxy
// IUniqueKeyedCollection.Proxy
// IOrderedCollection.Proxy
// IOrderedCollectionC.Proxy
// IOrderedCollectionS.Proxy
// IOrderedCollectionCS.Proxy
// OrderedCollectionProxy.Slice< in T >
// OrderedCollectionProxyC.Slice< in T >
// OrderedCollectionProxyS.Slice< in T >
// OrderedCollectionProxyCS.Slice< in T >
#endregion
#region PERMUDA TRAITS CG
// ICollection.Proxy
// ICollectionC.Proxy
// ICollectionG.Proxy
// ICollectionCG.Proxy
// IKeyedCollection.Proxy
// IUniqueKeyedCollection.Proxy
// IOrderedCollection.Proxy
// IOrderedCollectionC.Proxy
// IOrderedCollectionG.Proxy
// IOrderedCollectionCG.Proxy
// OrderedCollectionProxy.Slice< in T >
// OrderedCollectionProxyC.Slice< in T >
// OrderedCollectionProxyG.Slice< in T >
// OrderedCollectionProxyCG.Slice< in T >
#endregion
#region PERMUDA TRAITS SG
// ICollection.Proxy
// ICollectionS.Proxy
// ICollectionG.Proxy
// ICollectionSG.Proxy
// IKeyedCollection.Proxy
// IUniqueKeyedCollection.Proxy
// IOrderedCollection.Proxy
// IOrderedCollectionS.Proxy
// IOrderedCollectionG.Proxy
// IOrderedCollectionSG.Proxy
// OrderedCollectionProxy.Slice< in T >
// OrderedCollectionProxyS.Slice< in T >
// OrderedCollectionProxyG.Slice< in T >
// OrderedCollectionProxySG.Slice< in T >
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
// IUniqueKeyedCollection.Proxy
// IOrderedCollection.Proxy
// IOrderedCollectionR.Proxy.Invariant
// IOrderedCollectionC.Proxy
// IOrderedCollectionS.Proxy
// IOrderedCollectionRC.Proxy
// IOrderedCollectionRS.Proxy
// IOrderedCollectionCS.Proxy
// IOrderedCollectionRCS.Proxy
// OrderedCollectionProxy.Slice< T >
// OrderedCollectionProxyR.Slice< T >
// OrderedCollectionProxyC.Slice< T >
// OrderedCollectionProxyS.Slice< T >
// OrderedCollectionProxyRC.Slice< T >
// OrderedCollectionProxyRS.Slice< T >
// OrderedCollectionProxyCS.Slice< T >
// OrderedCollectionProxyRCS.Slice< T >
#endregion
#region PERMUDA TRAITS RCG
// ICollection.Proxy
// ICollectionR.Proxy.Invariant
// ICollectionC.Proxy
// ICollectionG.Proxy
// ICollectionRC.Proxy
// ICollectionRG.Proxy
// ICollectionCG.Proxy
// ICollectionRCG.Proxy
// IKeyedCollection.Proxy
// IUniqueKeyedCollection.Proxy
// IOrderedCollection.Proxy
// IOrderedCollectionR.Proxy.Invariant
// IOrderedCollectionC.Proxy
// IOrderedCollectionG.Proxy
// IOrderedCollectionRC.Proxy
// IOrderedCollectionRG.Proxy
// IOrderedCollectionCG.Proxy
// IOrderedCollectionRCG.Proxy
// OrderedCollectionProxy.Slice< T >
// OrderedCollectionProxyR.Slice< T >
// OrderedCollectionProxyC.Slice< T >
// OrderedCollectionProxyG.Slice< T >
// OrderedCollectionProxyRC.Slice< T >
// OrderedCollectionProxyRG.Slice< T >
// OrderedCollectionProxyCG.Slice< T >
// OrderedCollectionProxyRCG.Slice< T >
#endregion
#region PERMUDA TRAITS RSG
// ICollection.Proxy
// ICollectionR.Proxy.Invariant
// ICollectionS.Proxy
// ICollectionG.Proxy
// ICollectionRS.Proxy
// ICollectionRG.Proxy
// ICollectionSG.Proxy
// ICollectionRSG.Proxy
// IKeyedCollection.Proxy
// IUniqueKeyedCollection.Proxy
// IOrderedCollection.Proxy
// IOrderedCollectionR.Proxy.Invariant
// IOrderedCollectionS.Proxy
// IOrderedCollectionG.Proxy
// IOrderedCollectionRS.Proxy
// IOrderedCollectionRG.Proxy
// IOrderedCollectionSG.Proxy
// IOrderedCollectionRSG.Proxy
// OrderedCollectionProxy.Slice< T >
// OrderedCollectionProxyR.Slice< T >
// OrderedCollectionProxyS.Slice< T >
// OrderedCollectionProxyG.Slice< T >
// OrderedCollectionProxyRS.Slice< T >
// OrderedCollectionProxyRG.Slice< T >
// OrderedCollectionProxySG.Slice< T >
// OrderedCollectionProxyRSG.Slice< T >
#endregion
#region PERMUDA TRAITS CSG
// ICollection.Proxy
// ICollectionC.Proxy
// ICollectionS.Proxy
// ICollectionG.Proxy
// ICollectionCS.Proxy
// ICollectionCG.Proxy
// ICollectionSG.Proxy
// IKeyedCollection.Proxy
// IUniqueKeyedCollection.Proxy
// IOrderedCollection.Proxy
// IOrderedCollectionC.Proxy
// IOrderedCollectionS.Proxy
// IOrderedCollectionG.Proxy
// IOrderedCollectionCS.Proxy
// IOrderedCollectionCG.Proxy
// IOrderedCollectionSG.Proxy
// IOrderedCollectionCSG.Proxy
// OrderedCollectionProxy.Slice< T >
// OrderedCollectionProxyC.Slice< T >
// OrderedCollectionProxyS.Slice< T >
// OrderedCollectionProxyG.Slice< T >
// OrderedCollectionProxyCS.Slice< T >
// OrderedCollectionProxyCG.Slice< T >
// OrderedCollectionProxySG.Slice< T >
// OrderedCollectionProxyCSG.Slice< T >
#endregion
#region PERMUDA TRAITS RCSG
// ICollection.Proxy
// ICollectionR.Proxy.Invariant
// ICollectionC.Proxy
// ICollectionS.Proxy
// ICollectionG.Proxy
// ICollectionRC.Proxy
// ICollectionRS.Proxy
// ICollectionRG.Proxy
// ICollectionCS.Proxy
// ICollectionCG.Proxy
// ICollectionSG.Proxy
// ICollectionRCS.Proxy
// ICollectionRCG.Proxy
// ICollectionRSG.Proxy
// IKeyedCollection.Proxy
// IUniqueKeyedCollection.Proxy
// IOrderedCollection.Proxy
// IOrderedCollectionR.Proxy.Invariant
// IOrderedCollectionC.Proxy
// IOrderedCollectionS.Proxy
// IOrderedCollectionG.Proxy
// IOrderedCollectionRC.Proxy
// IOrderedCollectionRS.Proxy
// IOrderedCollectionRG.Proxy
// IOrderedCollectionCS.Proxy
// IOrderedCollectionCG.Proxy
// IOrderedCollectionSG.Proxy
// IOrderedCollectionRCS.Proxy
// IOrderedCollectionRCG.Proxy
// IOrderedCollectionRSG.Proxy
// IOrderedCollectionCSG.Proxy
// IOrderedCollectionRCSG.Proxy
// OrderedCollectionProxy.Slice< T >
// OrderedCollectionProxyR.Slice< T >
// OrderedCollectionProxyC.Slice< T >
// OrderedCollectionProxyS.Slice< T >
// OrderedCollectionProxyG.Slice< T >
// OrderedCollectionProxyRC.Slice< T >
// OrderedCollectionProxyRS.Slice< T >
// OrderedCollectionProxyRG.Slice< T >
// OrderedCollectionProxyCS.Slice< T >
// OrderedCollectionProxyCG.Slice< T >
// OrderedCollectionProxySG.Slice< T >
// OrderedCollectionProxyRCS.Slice< T >
// OrderedCollectionProxyRCG.Slice< T >
// OrderedCollectionProxyRSG.Slice< T >
// OrderedCollectionProxyCSG.Slice< T >
// OrderedCollectionProxyRCSG.Slice< T >
#endregion




} // type
} // namespace

