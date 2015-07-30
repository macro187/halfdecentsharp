#region PERMUDA
// permute _RCSG
// filename BidirectionalCursor/*PERMUDA*/Proxy/*PERMUDA FILESUFFIX*/.cs
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
Com.Halfdecent.Cursors
{


public partial class
BidirectionalCursor/*PERMUDA*/Proxy/*PERMUDA PROXYSUFFIX*/
    : Cursor/*PERMUDA*/Proxy/*PERMUDA PROXYSUFFIX*/
    , IBidirectionalCursor/*PERMUDA*//*PERMUDA TYPESUFFIX*/

    /*PERMUDA WHERE*/
{



public
BidirectionalCursor/*PERMUDA*/Proxy(
    IBidirectionalCursor/*PERMUDA*//*PERMUDA FROMSUFFIX*/ from
)
    : base( from )
{
    NonNull.CheckParameter( from, "from" );
    this.From = from;
}


new protected
    IBidirectionalCursor/*PERMUDA*//*PERMUDA FROMSUFFIX*/
From
{
    get;
    private set;
}



#region TRAITOR
// IBidirectionalCursor.Proxy
/*PERMUDA TRAITS*/
#endregion



#region PERMUDA FILESUFFIX
// R:       _TFrom_T
// C:       _TFrom_T
// S:
// G:       _TFrom_T
// RC:      _T
// RS:      _TFrom_T
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
// RS:      < TFrom, T >
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
// RS:      where TFrom : T
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
// RS:      < TFrom >
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
// IBidirectionalCursorR.Proxy
#endregion
#region PERMUDA TRAITS C
// IBidirectionalCursorC.Proxy
#endregion
#region PERMUDA TRAITS S
// IBidirectionalCursorS.Proxy
#endregion
#region PERMUDA TRAITS G
// IBidirectionalCursorG.Proxy
#endregion
#region PERMUDA TRAITS RC
// IBidirectionalCursorR.Proxy
// IBidirectionalCursorC.Proxy
// IBidirectionalCursorRC.Proxy
#endregion
#region PERMUDA TRAITS RS
// IBidirectionalCursorR.Proxy
// IBidirectionalCursorS.Proxy
// IBidirectionalCursorRS.Proxy
#endregion
#region PERMUDA TRAITS RG
// IBidirectionalCursorR.Proxy
// IBidirectionalCursorG.Proxy
// IBidirectionalCursorRG.Proxy
#endregion
#region PERMUDA TRAITS CS
// IBidirectionalCursorC.Proxy
// IBidirectionalCursorS.Proxy
// IBidirectionalCursorCS.Proxy
#endregion
#region PERMUDA TRAITS CG
// IBidirectionalCursorC.Proxy
// IBidirectionalCursorG.Proxy
// IBidirectionalCursorCG.Proxy
#endregion
#region PERMUDA TRAITS SG
// IBidirectionalCursorS.Proxy
// IBidirectionalCursorG.Proxy
// IBidirectionalCursorSG.Proxy
#endregion
#region PERMUDA TRAITS RCS
// IBidirectionalCursorR.Proxy
// IBidirectionalCursorC.Proxy
// IBidirectionalCursorS.Proxy
// IBidirectionalCursorRC.Proxy
// IBidirectionalCursorRS.Proxy
// IBidirectionalCursorCS.Proxy
// IBidirectionalCursorRCS.Proxy
#endregion
#region PERMUDA TRAITS RCG
// IBidirectionalCursorR.Proxy
// IBidirectionalCursorC.Proxy
// IBidirectionalCursorG.Proxy
// IBidirectionalCursorRC.Proxy
// IBidirectionalCursorRG.Proxy
// IBidirectionalCursorCG.Proxy
// IBidirectionalCursorRCG.Proxy
#endregion
#region PERMUDA TRAITS RSG
// IBidirectionalCursorR.Proxy
// IBidirectionalCursorS.Proxy
// IBidirectionalCursorG.Proxy
// IBidirectionalCursorRS.Proxy
// IBidirectionalCursorRG.Proxy
// IBidirectionalCursorSG.Proxy
// IBidirectionalCursorRSG.Proxy
#endregion
#region PERMUDA TRAITS CSG
// IBidirectionalCursorC.Proxy
// IBidirectionalCursorS.Proxy
// IBidirectionalCursorG.Proxy
// IBidirectionalCursorCS.Proxy
// IBidirectionalCursorCG.Proxy
// IBidirectionalCursorSG.Proxy
// IBidirectionalCursorCSG.Proxy
#endregion
#region PERMUDA TRAITS RCSG
// IBidirectionalCursorR.Proxy
// IBidirectionalCursorC.Proxy
// IBidirectionalCursorS.Proxy
// IBidirectionalCursorG.Proxy
// IBidirectionalCursorRC.Proxy
// IBidirectionalCursorRS.Proxy
// IBidirectionalCursorRG.Proxy
// IBidirectionalCursorCS.Proxy
// IBidirectionalCursorCG.Proxy
// IBidirectionalCursorSG.Proxy
// IBidirectionalCursorRCS.Proxy
// IBidirectionalCursorRCG.Proxy
// IBidirectionalCursorRSG.Proxy
// IBidirectionalCursorCSG.Proxy
// IBidirectionalCursorRCSG.Proxy
#endregion




} // type
} // namespace

