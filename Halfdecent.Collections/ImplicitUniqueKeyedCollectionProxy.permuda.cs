#region PERMUDA
// combos G RG SG RSG
// filename ImplicitUniqueKeyedCollection/*PERMUDA*/Proxy/*PERMUDA FILESUFFIX*/.cs
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


/// IImplicitUniqueKeyedCollection/*PERMUDA*/ proxy
///
public class
ImplicitUniqueKeyedCollection/*PERMUDA*/Proxy/*PERMUDA PROXYSUFFIX*/
    : IImplicitUniqueKeyedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/
    , IProxy

    /*PERMUDA WHERE*/
{



public
ImplicitUniqueKeyedCollection/*PERMUDA*/Proxy(
    IImplicitUniqueKeyedCollection/*PERMUDA*//*PERMUDA FROMSUFFIX*/ from
)
{
    NonNull.CheckParameter( from, "from" );
    this.From = from;
}


protected
    IImplicitUniqueKeyedCollection/*PERMUDA*//*PERMUDA FROMSUFFIX*/
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
// ICollection.Proxy
// ICollectionG.Proxy
// IKeyedCollection.Proxy
// IUniqueKeyedCollection.Proxy
// IImplicitKeyedCollectionG.Proxy
// IImplicitUniqueKeyedCollectionG.Proxy
#endregion
#region PERMUDA TRAITS RG
// ICollection.Proxy
// ICollectionR.Proxy.Invariant
// ICollectionG.Proxy
// ICollectionRG.Proxy
// IKeyedCollection.Proxy
// IKeyedCollectionR.Proxy.Invariant
// IUniqueKeyedCollection.Proxy
// IImplicitKeyedCollectionG.Proxy
// IImplicitKeyedCollectionRG.Proxy
// IUniqueKeyedCollectionR.Proxy
// IImplicitUniqueKeyedCollectionG.Proxy
// IImplicitUniqueKeyedCollectionRG.Proxy
#endregion
#region PERMUDA TRAITS SG
// ICollection.Proxy
// ICollectionS.Proxy
// ICollectionG.Proxy
// ICollectionSG.Proxy
// IKeyedCollection.Proxy
// IKeyedCollectionS.Proxy
// IImplicitKeyedCollectionG.Proxy
// IImplicitKeyedCollectionSG.Proxy
// IUniqueKeyedCollection.Proxy
// IUniqueKeyedCollectionS.Proxy
// IImplicitUniqueKeyedCollectionG.Proxy
// IImplicitUniqueKeyedCollectionSG.Proxy
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
// IKeyedCollectionR.Proxy.Invariant
// IKeyedCollectionS.Proxy
// IKeyedCollectionRS.Proxy
// IImplicitKeyedCollectionG.Proxy
// IImplicitKeyedCollectionRG.Proxy
// IImplicitKeyedCollectionSG.Proxy
// IImplicitKeyedCollectionRSG.Proxy
// IUniqueKeyedCollection.Proxy
// IUniqueKeyedCollectionR.Proxy
// IUniqueKeyedCollectionS.Proxy
// IUniqueKeyedCollectionRS.Proxy
// IImplicitUniqueKeyedCollectionG.Proxy
// IImplicitUniqueKeyedCollectionRG.Proxy
// IImplicitUniqueKeyedCollectionSG.Proxy
// IImplicitUniqueKeyedCollectionRSG.Proxy
#endregion




} // type
} // namespace

