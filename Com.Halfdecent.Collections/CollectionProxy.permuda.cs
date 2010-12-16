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
// ICollection.Proxy
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
// filename Collection/*PERMUDA*/Proxy/*PERMUDA FILESUFFIX*/.cs
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
#region PERMUDA TRAITS R
// ICollectionR< out T >.Proxy
#endregion
#region PERMUDA TRAITS C
// ICollectionC< T >.Proxy
#endregion
#region PERMUDA TRAITS S
// ICollectionS.Proxy
#endregion
#region PERMUDA TRAITS G
// ICollectionG< T >.Proxy
#endregion
#region PERMUDA TRAITS RC
// ICollectionR< T >.Proxy
// ICollectionC< T >.Proxy
// ICollectionRC< T >.Proxy
#endregion
#region PERMUDA TRAITS RS
// ICollectionR< T >.Proxy
// ICollectionS.Proxy
// ICollectionRS< T >.Proxy
#endregion
#region PERMUDA TRAITS RG
// ICollectionR< T >.Proxy
// ICollectionG< T >.Proxy
// ICollectionRG< T >.Proxy
#endregion
#region PERMUDA TRAITS CS
// ICollectionC< T >.Proxy
// ICollectionS.Proxy
// ICollectionCS< T >.Proxy
#endregion
#region PERMUDA TRAITS CG
// ICollectionC< T >.Proxy
// ICollectionG< T >.Proxy
// ICollectionCG< T >.Proxy
#endregion
#region PERMUDA TRAITS SG
// ICollectionS.Proxy
// ICollectionG< T >.Proxy
// ICollectionSG< T >.Proxy
#endregion
#region PERMUDA TRAITS RCS
// ICollectionR< T >.Proxy
// ICollectionC< T >.Proxy
// ICollectionS.Proxy
// ICollectionRC< T >.Proxy
// ICollectionRS< T >.Proxy
// ICollectionCS< T >.Proxy
// ICollectionRCS< T >.Proxy
#endregion
#region PERMUDA TRAITS RCG
// ICollectionR< T >.Proxy
// ICollectionC< T >.Proxy
// ICollectionG< T >.Proxy
// ICollectionRC< T >.Proxy
// ICollectionRG< T >.Proxy
// ICollectionCG< T >.Proxy
// ICollectionRCG< T >.Proxy
#endregion
#region PERMUDA TRAITS RSG
// ICollectionR< T >.Proxy
// ICollectionS.Proxy
// ICollectionG< T >.Proxy
// ICollectionRS< T >.Proxy
// ICollectionRG< T >.Proxy
// ICollectionSG< T >.Proxy
// ICollectionRSG< T >.Proxy
#endregion
#region PERMUDA TRAITS CSG
// ICollectionC< T >.Proxy
// ICollectionS.Proxy
// ICollectionG< T >.Proxy
// ICollectionCS< T >.Proxy
// ICollectionCG< T >.Proxy
// ICollectionSG< T >.Proxy
// ICollectionCSG< T >.Proxy
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
// ICollectionCSG< T >.Proxy
// ICollectionRCSG< T >.Proxy
#endregion




} // type
} // namespace

