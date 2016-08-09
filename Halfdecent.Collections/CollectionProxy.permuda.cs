#region PERMUDA
// permute _RCSG
// filename Collection/*PERMUDA*/Proxy/*PERMUDA FILESUFFIX*/.cs
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


/// ICollection/*PERMUDA*/ proxy
///
public class
Collection/*PERMUDA*/Proxy/*PERMUDA PROXYSUFFIX*/
    : ICollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/
    , IProxy

    /*PERMUDA WHERE*/
{



public
Collection/*PERMUDA*/Proxy(
    ICollection/*PERMUDA*//*PERMUDA FROMSUFFIX*/ from
)
{
    NonNull.CheckParameter( from, "from" );
    this.From = from;
}


protected
    ICollection/*PERMUDA*//*PERMUDA FROMSUFFIX*/
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
// CSG:     _TFrom_T
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
// CSG:     < TFrom, T >
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
// CSG:     where T : TFrom
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
// CSG:     < TFrom >
// RCSG:    < T >
#endregion
#region PERMUDA TRAITS _
// ICollection.Proxy
#endregion
#region PERMUDA TRAITS R
// ICollection.Proxy
// ICollectionR.Proxy
#endregion
#region PERMUDA TRAITS C
// ICollection.Proxy
// ICollectionC.Proxy
#endregion
#region PERMUDA TRAITS S
// ICollection.Proxy
// ICollectionS.Proxy
#endregion
#region PERMUDA TRAITS G
// ICollection.Proxy
// ICollectionG.Proxy
#endregion
#region PERMUDA TRAITS RC
// ICollection.Proxy
// ICollectionR.Proxy.Invariant
// ICollectionC.Proxy
// ICollectionRC.Proxy
#endregion
#region PERMUDA TRAITS RS
// ICollection.Proxy
// ICollectionR.Proxy.Invariant
// ICollectionS.Proxy
// ICollectionRS.Proxy
#endregion
#region PERMUDA TRAITS RG
// ICollection.Proxy
// ICollectionR.Proxy.Invariant
// ICollectionG.Proxy
// ICollectionRG.Proxy
#endregion
#region PERMUDA TRAITS CS
// ICollection.Proxy
// ICollectionC.Proxy
// ICollectionS.Proxy
// ICollectionCS.Proxy
#endregion
#region PERMUDA TRAITS CG
// ICollection.Proxy
// ICollectionC.Proxy
// ICollectionG.Proxy
// ICollectionCG.Proxy
#endregion
#region PERMUDA TRAITS SG
// ICollection.Proxy
// ICollectionS.Proxy
// ICollectionG.Proxy
// ICollectionSG.Proxy
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
#endregion
#region PERMUDA TRAITS CSG
// ICollection.Proxy
// ICollectionC.Proxy
// ICollectionS.Proxy
// ICollectionG.Proxy
// ICollectionCS.Proxy
// ICollectionCG.Proxy
// ICollectionSG.Proxy
// ICollectionCSG.Proxy
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
// ICollectionCSG.Proxy
// ICollectionRCSG.Proxy
#endregion




} // type
} // namespace

