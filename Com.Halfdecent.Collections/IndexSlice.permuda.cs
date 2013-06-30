#region PERMUDA
// permute _RCSG
// filename IndexSlice/*PERMUDA*//*PERMUDA FILESUFFIX*/.cs
#endregion
// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2012
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


/// An index-based, by-reference slice of an ordered collection
///
/// This kind of slice accesses and manipulates the underlying collection by
/// ordinal index, so works best on collections where such index-based random
/// access is efficient.
///
public class
IndexSlice/*PERMUDA*//*PERMUDA TYPESUFFIX*/
    : IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/
{



public
IndexSlice/*PERMUDA*/(
    IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/ from,
    ///< The underlying collection
    long                        sliceIndex,
    ///< Index at which the slice begins
    ///  - <tt>GTE( 0 )</tt>
    ///  - <tt>LTE( from.Count )</tt>
    long                        sliceCount
    ///< Length of the slice
    ///  - <tt>GTE( 0 )</tt>
    ///  - <tt>LTE( from.Count - sliceIndex )</tt>
)
{
    NonNull.CheckParameter( from, "from" );
    GTE.CheckParameter( 0, sliceIndex, "sliceIndex" );
    LTE.CheckParameter( from.Count, sliceIndex, "sliceIndex" );
    GTE.CheckParameter( 0, sliceCount, "sliceCount" );
    LTE.CheckParameter( from.Count - sliceIndex, sliceCount, "sliceCount" );
    this.From = from;
    this.SliceIndex = sliceIndex;
    this.SliceCount = sliceCount;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

protected
    IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/
From
{
    get;
    private set;
}


protected
    long
SliceIndex
{
    get;
    private set;
}


protected
    long
SliceCount
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

// Translate an index to the underlying collection
//
// No null or bounds checking
//
private
    long
Trans(
    long index
)
{
    return
        this.SliceIndex == 0
            ? index
            : this.SliceIndex + index;
}



#region TRAITOR
// IOrderedCollection.IndexSlice
// IndexSlice.Slice< T >
/*PERMUDA TRAITS*/
#endregion



#if TRAITOR
// Trait IndexSlice/*PERMUDA*/.Slice< T >

    IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/
IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/.Slice(
    long index,
    long count
)
{
    return new IndexSlice/*PERMUDA*//*PERMUDA TYPESUFFIX*/(
        this, index, count );
}
#endif



#if TRAITOR
// Trait IndexSlice/*PERMUDA*/.Slice< char >

    IOrderedCollection/*PERMUDA*//*PERMUDA CHARSUFFIX*/
IOrderedCollection/*PERMUDA*//*PERMUDA CHARSUFFIX*/.Slice(
    long index,
    long count
)
{
    return new IndexSlice/*PERMUDA*//*PERMUDA CHARSUFFIX*/(
        this, index, count );
}
#endif



#region PERMUDA FILESUFFIX
// R:       _T
// C:       _T
// S:
// G:       _T
// RC:      _T
// RS:      _T
// RG:      _T
// CS:      _T
// CG:      _T
// SG:      _T
// RCS:     _T
// RCG:     _T
// RSG:     _T
// CSG:     _T
// RCSG:    _T
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
#region PERMUDA CHARSUFFIX
// R:       < char >
// C:       < char >
// S:
// G:       < char >
// RC:      < char >
// RS:      < char >
// RG:      < char >
// CS:      < char >
// CG:      < char >
// SG:      < char >
// RCS:     < char >
// RCG:     < char >
// RSG:     < char >
// CSG:     < char >
// RCSG:    < char >
#endregion
#region PERMUDA TRAITS R
// IOrderedCollectionR< T >.IndexSlice
// IndexSliceR.Slice< T >
#endregion
#region PERMUDA TRAITS C
// IOrderedCollectionC< T >.IndexSlice
// IndexSliceC.Slice< T >
#endregion
#region PERMUDA TRAITS S
// IOrderedCollectionS.IndexSlice
// IndexSliceS.Slice< T >
#endregion
#region PERMUDA TRAITS G
// IOrderedCollectionG< T >.IndexSlice
// IndexSliceG.Slice< T >
#endregion
#region PERMUDA TRAITS RC
// IOrderedCollectionR< T >.IndexSlice
// IOrderedCollectionC< T >.IndexSlice
// IOrderedCollectionRC< T >.IndexSlice
// IndexSliceR.Slice< T >
// IndexSliceC.Slice< T >
// IndexSliceRC.Slice< T >
#endregion
#region PERMUDA TRAITS RS
// IOrderedCollectionR< T >.IndexSlice
// IOrderedCollectionS.IndexSlice
// IOrderedCollectionRS< T >.IndexSlice
// IndexSliceR.Slice< T >
// IndexSliceS.Slice< T >
// IndexSliceRS.Slice< T >
#endregion
#region PERMUDA TRAITS RG
// IOrderedCollectionR< T >.IndexSlice
// IOrderedCollectionG< T >.IndexSlice
// IOrderedCollectionRG< T >.IndexSlice
// IndexSliceR.Slice< T >
// IndexSliceG.Slice< T >
// IndexSliceRG.Slice< T >
#endregion
#region PERMUDA TRAITS CS
// IOrderedCollectionC< T >.IndexSlice
// IOrderedCollectionS.IndexSlice
// IOrderedCollectionCS< T >.IndexSlice
// IndexSliceC.Slice< T >
// IndexSliceS.Slice< T >
// IndexSliceCS.Slice< T >
#endregion
#region PERMUDA TRAITS CG
// IOrderedCollectionC< T >.IndexSlice
// IOrderedCollectionG< T >.IndexSlice
// IOrderedCollectionCG< T >.IndexSlice
// IndexSliceC.Slice< T >
// IndexSliceG.Slice< T >
// IndexSliceCG.Slice< T >
#endregion
#region PERMUDA TRAITS SG
// IOrderedCollectionS.IndexSlice
// IOrderedCollectionG< T >.IndexSlice
// IOrderedCollectionSG< T >.IndexSlice
// IndexSliceS.Slice< T >
// IndexSliceG.Slice< T >
// IndexSliceSG.Slice< T >
#endregion
#region PERMUDA TRAITS RCS
// IOrderedCollectionR< T >.IndexSlice
// IOrderedCollectionC< T >.IndexSlice
// IOrderedCollectionS.IndexSlice
// IOrderedCollectionRC< T >.IndexSlice
// IOrderedCollectionRS< T >.IndexSlice
// IOrderedCollectionCS< T >.IndexSlice
// IOrderedCollectionRCS< T >.IndexSlice
// IndexSliceR.Slice< T >
// IndexSliceC.Slice< T >
// IndexSliceS.Slice< T >
// IndexSliceRC.Slice< T >
// IndexSliceRS.Slice< T >
// IndexSliceCS.Slice< T >
// IndexSliceRCS.Slice< T >
#endregion
#region PERMUDA TRAITS RCG
// IOrderedCollectionR< T >.IndexSlice
// IOrderedCollectionC< T >.IndexSlice
// IOrderedCollectionG< T >.IndexSlice
// IOrderedCollectionRC< T >.IndexSlice
// IOrderedCollectionRG< T >.IndexSlice
// IOrderedCollectionCG< T >.IndexSlice
// IOrderedCollectionRCG< T >.IndexSlice
// IndexSliceR.Slice< T >
// IndexSliceC.Slice< T >
// IndexSliceG.Slice< T >
// IndexSliceRC.Slice< T >
// IndexSliceRG.Slice< T >
// IndexSliceCG.Slice< T >
// IndexSliceRCG.Slice< T >
#endregion
#region PERMUDA TRAITS RSG
// IOrderedCollectionR< T >.IndexSlice
// IOrderedCollectionS.IndexSlice
// IOrderedCollectionG< T >.IndexSlice
// IOrderedCollectionRS< T >.IndexSlice
// IOrderedCollectionRG< T >.IndexSlice
// IOrderedCollectionSG< T >.IndexSlice
// IOrderedCollectionRSG< T >.IndexSlice
// IndexSliceR.Slice< T >
// IndexSliceS.Slice< T >
// IndexSliceG.Slice< T >
// IndexSliceRS.Slice< T >
// IndexSliceRG.Slice< T >
// IndexSliceSG.Slice< T >
// IndexSliceRSG.Slice< T >
#endregion
#region PERMUDA TRAITS CSG
// IOrderedCollectionC< T >.IndexSlice
// IOrderedCollectionS.IndexSlice
// IOrderedCollectionG< T >.IndexSlice
// IOrderedCollectionCS< T >.IndexSlice
// IOrderedCollectionCG< T >.IndexSlice
// IOrderedCollectionSG< T >.IndexSlice
// IOrderedCollectionCSG< T >.IndexSlice
// IndexSliceC.Slice< T >
// IndexSliceS.Slice< T >
// IndexSliceG.Slice< T >
// IndexSliceCS.Slice< T >
// IndexSliceCG.Slice< T >
// IndexSliceSG.Slice< T >
// IndexSliceCSG.Slice< T >
#endregion
#region PERMUDA TRAITS RCSG
// IOrderedCollectionR< T >.IndexSlice
// IOrderedCollectionC< T >.IndexSlice
// IOrderedCollectionS.IndexSlice
// IOrderedCollectionG< T >.IndexSlice
// IOrderedCollectionRC< T >.IndexSlice
// IOrderedCollectionRS< T >.IndexSlice
// IOrderedCollectionRG< T >.IndexSlice
// IOrderedCollectionCS< T >.IndexSlice
// IOrderedCollectionCG< T >.IndexSlice
// IOrderedCollectionSG< T >.IndexSlice
// IOrderedCollectionRCS< T >.IndexSlice
// IOrderedCollectionRCG< T >.IndexSlice
// IOrderedCollectionRSG< T >.IndexSlice
// IOrderedCollectionCSG< T >.IndexSlice
// IOrderedCollectionRCSG< T >.IndexSlice
// IndexSliceR.Slice< T >
// IndexSliceC.Slice< T >
// IndexSliceS.Slice< T >
// IndexSliceG.Slice< T >
// IndexSliceRC.Slice< T >
// IndexSliceRS.Slice< T >
// IndexSliceRG.Slice< T >
// IndexSliceCS.Slice< T >
// IndexSliceCG.Slice< T >
// IndexSliceSG.Slice< T >
// IndexSliceRCS.Slice< T >
// IndexSliceRCG.Slice< T >
// IndexSliceRSG.Slice< T >
// IndexSliceCSG.Slice< T >
// IndexSliceRCSG.Slice< T >
#endregion




} // type
} // namespace

