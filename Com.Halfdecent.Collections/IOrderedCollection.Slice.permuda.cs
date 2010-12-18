#region PERMUDA
// permute _RCSG
// filename IOrderedCollection/*PERMUDA*//*PERMUDA FILESUFFIX*/.Slice.cs
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


using Com.Halfdecent.Numerics;


namespace
Com.Halfdecent.Collections
{


public partial interface
IOrderedCollection/*PERMUDA*/
#if DOTNET40
/*PERMUDA VARIANTTYPESUFFIX*/
#else
/*PERMUDA TYPESUFFIX*/
#endif
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Take a by-reference slice of a specified length starting at a specified
/// position
///
    /*PERMUDA NEW*/ IOrderedCollection/*PERMUDA*//*PERMUDA TYPESUFFIX*/
Slice(
    IInteger    index,
    IInteger    count
);



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
#region PERMUDA VARIANTTYPESUFFIX
// R:       < out T >
// C:       < in T >
// S:
// G:       < in T >
// RC:      < T >
// RS:      < T >
// RG:      < T >
// CS:      < in T >
// CG:      < in T >
// SG:      < in T >
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
#region PERMUDA NEW
// R:       new
// C:       new
// S:       new
// G:       new
// RC:      new
// RS:      new
// RG:      new
// CS:      new
// CG:      new
// SG:      new
// RCS:     new
// RCG:     new
// RSG:     new
// CSG:     new
// RCSG:    new
#endregion




} // type
} // namespace

