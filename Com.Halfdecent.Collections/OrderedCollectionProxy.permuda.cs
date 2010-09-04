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

    /*PERMUDA WHERE*/
{



public
OrderedCollection/*PERMUDA*/Proxy(
    IOrderedCollection/*PERMUDA*//*PERMUDA FROMSUFFIX*/ from
)
{
    new NonNull().Require( from, new Parameter( "from" ) );
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
// ICollection.Proxy
// IKeyedCollection.Proxy
// IUniqueKeyedCollection.Proxy
// IOrderedCollection.Proxy
/*PERMUDA TRAITS*/
#endregion



#if TRAITOR
// Trait OrderedCollectionProxy/*PERMUDA*/.Slice< T >

    IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/
IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/.Slice(
    IInteger index,
    IInteger count
)
{
    return this.From.Slice( index, count );
}
#endif



#if TRAITOR
// Trait OrderedCollectionProxy/*PERMUDA*/.Slice< in T >

    IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/
IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/.Slice(
    IInteger index,
    IInteger count
)
{
#if DOTNET40
    return this.From.Slice( index, count );
#else
    return this.From.Contravary< TFrom, T >().Slice( index, count );
#endif
}
#endif



#if TRAITOR
// Trait OrderedCollectionProxy/*PERMUDA*/.Slice< out T >

    IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/
IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/.Slice(
    IInteger index,
    IInteger count
)
{
#if DOTNET40
    return this.From.Slice( index, count );
#else
    return this.From.Covary< TFrom, T >().Slice( index, count );
#endif
}
#endif



#region PERMUDA
// permute _RCSG
// filename OrderedCollection/*PERMUDA*/Proxy/*PERMUDA FILESUFFIX*/.cs
#endregion
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
// OrderedCollectionProxy.Slice< T >
#endregion
#region PERMUDA TRAITS R
// ICollectionR< out T >.Proxy
// IOrderedCollectionR< out T >.Proxy
// OrderedCollectionProxy.Slice< out T >
// OrderedCollectionProxyR.Slice< out T >
#endregion
#region PERMUDA TRAITS C
// ICollectionC< T >.Proxy
// IOrderedCollectionC< T >.Proxy
// OrderedCollectionProxy.Slice< in T >
// OrderedCollectionProxyC.Slice< in T >
#endregion
#region PERMUDA TRAITS S
// ICollectionS.Proxy
// IOrderedCollectionS.Proxy
// OrderedCollectionProxy.Slice< T >
// OrderedCollectionProxyS.Slice< T >
#endregion
#region PERMUDA TRAITS G
// ICollectionG< T >.Proxy
// IOrderedCollectionG< T >.Proxy
// OrderedCollectionProxy.Slice< in T >
// OrderedCollectionProxyG.Slice< in T >
#endregion
#region PERMUDA TRAITS RC
// ICollectionR< T >.Proxy
// ICollectionC< T >.Proxy
// ICollectionRC< T >.Proxy
// IOrderedCollectionR< T >.Proxy
// IOrderedCollectionC< T >.Proxy
// IOrderedCollectionRC< T >.Proxy
// OrderedCollectionProxy.Slice< T >
// OrderedCollectionProxyR.Slice< T >
// OrderedCollectionProxyC.Slice< T >
// OrderedCollectionProxyRC.Slice< T >
#endregion
#region PERMUDA TRAITS RS
// ICollectionR< T >.Proxy
// ICollectionS.Proxy
// ICollectionRS< T >.Proxy
// IOrderedCollectionR< T >.Proxy
// IOrderedCollectionS.Proxy
// IOrderedCollectionRS< T >.Proxy
// OrderedCollectionProxy.Slice< T >
// OrderedCollectionProxyR.Slice< T >
// OrderedCollectionProxyS.Slice< T >
// OrderedCollectionProxyRS.Slice< T >
#endregion
#region PERMUDA TRAITS RG
// ICollectionR< T >.Proxy
// ICollectionG< T >.Proxy
// ICollectionRG< T >.Proxy
// IOrderedCollectionR< T >.Proxy
// IOrderedCollectionG< T >.Proxy
// IOrderedCollectionRG< T >.Proxy
// OrderedCollectionProxy.Slice< T >
// OrderedCollectionProxyR.Slice< T >
// OrderedCollectionProxyG.Slice< T >
// OrderedCollectionProxyRG.Slice< T >
#endregion
#region PERMUDA TRAITS CS
// ICollectionC< T >.Proxy
// ICollectionS.Proxy
// ICollectionCS< T >.Proxy
// IOrderedCollectionC< T >.Proxy
// IOrderedCollectionS.Proxy
// IOrderedCollectionCS< T >.Proxy
// OrderedCollectionProxy.Slice< in T >
// OrderedCollectionProxyC.Slice< in T >
// OrderedCollectionProxyS.Slice< in T >
// OrderedCollectionProxyCS.Slice< in T >
#endregion
#region PERMUDA TRAITS CG
// ICollectionC< T >.Proxy
// ICollectionG< T >.Proxy
// ICollectionCG< T >.Proxy
// IOrderedCollectionC< T >.Proxy
// IOrderedCollectionG< T >.Proxy
// IOrderedCollectionCG< T >.Proxy
// OrderedCollectionProxy.Slice< in T >
// OrderedCollectionProxyC.Slice< in T >
// OrderedCollectionProxyG.Slice< in T >
// OrderedCollectionProxyCG.Slice< in T >
#endregion
#region PERMUDA TRAITS SG
// ICollectionS.Proxy
// ICollectionG< T >.Proxy
// ICollectionSG< T >.Proxy
// IOrderedCollectionS.Proxy
// IOrderedCollectionG< T >.Proxy
// IOrderedCollectionSG< T >.Proxy
// OrderedCollectionProxy.Slice< in T >
// OrderedCollectionProxyS.Slice< in T >
// OrderedCollectionProxyG.Slice< in T >
// OrderedCollectionProxySG.Slice< in T >
#endregion
#region PERMUDA TRAITS RCS
// ICollectionR< T >.Proxy
// ICollectionC< T >.Proxy
// ICollectionS.Proxy
// ICollectionRC< T >.Proxy
// ICollectionRS< T >.Proxy
// ICollectionCS< T >.Proxy
// ICollectionRCS< T >.Proxy
// IOrderedCollectionR< T >.Proxy
// IOrderedCollectionC< T >.Proxy
// IOrderedCollectionS.Proxy
// IOrderedCollectionRC< T >.Proxy
// IOrderedCollectionRS< T >.Proxy
// IOrderedCollectionCS< T >.Proxy
// IOrderedCollectionRCS< T >.Proxy
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
// ICollectionR< T >.Proxy
// ICollectionC< T >.Proxy
// ICollectionG< T >.Proxy
// ICollectionRC< T >.Proxy
// ICollectionRG< T >.Proxy
// ICollectionCG< T >.Proxy
// ICollectionRCG< T >.Proxy
// IOrderedCollectionR< T >.Proxy
// IOrderedCollectionC< T >.Proxy
// IOrderedCollectionG< T >.Proxy
// IOrderedCollectionRC< T >.Proxy
// IOrderedCollectionRG< T >.Proxy
// IOrderedCollectionCG< T >.Proxy
// IOrderedCollectionRCG< T >.Proxy
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
// ICollectionR< T >.Proxy
// ICollectionS.Proxy
// ICollectionG< T >.Proxy
// ICollectionRS< T >.Proxy
// ICollectionRG< T >.Proxy
// ICollectionSG< T >.Proxy
// ICollectionRSG< T >.Proxy
// IOrderedCollectionR< T >.Proxy
// IOrderedCollectionS.Proxy
// IOrderedCollectionG< T >.Proxy
// IOrderedCollectionRS< T >.Proxy
// IOrderedCollectionRG< T >.Proxy
// IOrderedCollectionSG< T >.Proxy
// IOrderedCollectionRSG< T >.Proxy
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
// ICollectionC< T >.Proxy
// ICollectionS.Proxy
// ICollectionG< T >.Proxy
// ICollectionCS< T >.Proxy
// ICollectionCG< T >.Proxy
// ICollectionSG< T >.Proxy
// IOrderedCollectionC< T >.Proxy
// IOrderedCollectionS.Proxy
// IOrderedCollectionG< T >.Proxy
// IOrderedCollectionCS< T >.Proxy
// IOrderedCollectionCG< T >.Proxy
// IOrderedCollectionSG< T >.Proxy
// IOrderedCollectionCSG< T >.Proxy
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

