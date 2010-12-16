#region PERMUDA
// permute _RCSG
// filename Cursor/*PERMUDA*/Proxy/*PERMUDA FILESUFFIX*/.cs
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
using Com.Halfdecent.Numerics;


namespace
Com.Halfdecent.Cursors
{


public partial class
Cursor/*PERMUDA*/Proxy/*PERMUDA PROXYSUFFIX*/
    : ICursor/*PERMUDA*//*PERMUDA TYPESUFFIX*/
    , IProxy

    /*PERMUDA WHERE*/
{



public
Cursor/*PERMUDA*/Proxy(
    ICursor/*PERMUDA*//*PERMUDA FROMSUFFIX*/ from
)
{
    NonNull.CheckParameter( from, "from" );
    this.From = from;
}


protected
    ICursor/*PERMUDA*//*PERMUDA FROMSUFFIX*/
From
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// IProxy
// -----------------------------------------------------------------------------

    object
IProxy.Underlying
{
    get { return this.From; }
}



#region TRAITOR
// ICursor.Proxy
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
// ICursorR.Proxy
#endregion
#region PERMUDA TRAITS C
// ICursorC.Proxy
#endregion
#region PERMUDA TRAITS S
// ICursorS.Proxy
#endregion
#region PERMUDA TRAITS G
// ICursorG.Proxy
#endregion
#region PERMUDA TRAITS RC
// ICursorR.Proxy
// ICursorC.Proxy
// ICursorRC.Proxy
#endregion
#region PERMUDA TRAITS RS
// ICursorR.Proxy
// ICursorS.Proxy
// ICursorRS.Proxy
#endregion
#region PERMUDA TRAITS RG
// ICursorR.Proxy
// ICursorG.Proxy
// ICursorRG.Proxy
#endregion
#region PERMUDA TRAITS CS
// ICursorC.Proxy
// ICursorS.Proxy
// ICursorCS.Proxy
#endregion
#region PERMUDA TRAITS CG
// ICursorC.Proxy
// ICursorG.Proxy
// ICursorCG.Proxy
#endregion
#region PERMUDA TRAITS SG
// ICursorS.Proxy
// ICursorG.Proxy
// ICursorSG.Proxy
#endregion
#region PERMUDA TRAITS RCS
// ICursorR.Proxy
// ICursorC.Proxy
// ICursorS.Proxy
// ICursorRC.Proxy
// ICursorRS.Proxy
// ICursorCS.Proxy
// ICursorRCS.Proxy
#endregion
#region PERMUDA TRAITS RCG
// ICursorR.Proxy
// ICursorC.Proxy
// ICursorG.Proxy
// ICursorRC.Proxy
// ICursorRG.Proxy
// ICursorCG.Proxy
// ICursorRCG.Proxy
#endregion
#region PERMUDA TRAITS RSG
// ICursorR.Proxy
// ICursorS.Proxy
// ICursorG.Proxy
// ICursorRS.Proxy
// ICursorRG.Proxy
// ICursorSG.Proxy
// ICursorRSG.Proxy
#endregion
#region PERMUDA TRAITS CSG
// ICursorC.Proxy
// ICursorS.Proxy
// ICursorG.Proxy
// ICursorCS.Proxy
// ICursorCG.Proxy
// ICursorSG.Proxy
// ICursorCSG.Proxy
#endregion
#region PERMUDA TRAITS RCSG
// ICursorR.Proxy
// ICursorC.Proxy
// ICursorS.Proxy
// ICursorG.Proxy
// ICursorRC.Proxy
// ICursorRS.Proxy
// ICursorRG.Proxy
// ICursorCS.Proxy
// ICursorCG.Proxy
// ICursorSG.Proxy
// ICursorRCS.Proxy
// ICursorRCG.Proxy
// ICursorRSG.Proxy
// ICursorCSG.Proxy
// ICursorRCSG.Proxy
#endregion




} // type
} // namespace

