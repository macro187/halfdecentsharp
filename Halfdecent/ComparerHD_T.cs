// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010, 2011
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


using System;
using System.Collections.Generic;


namespace
Halfdecent
{


// =============================================================================
/// (See `ComparerHD.Create<T>()`)
// =============================================================================

public class
ComparerHD<
    T
>
    : EqualityComparerHD< T >
    , IComparerHD< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
ComparerHD(
    CompareFunc< T >        compareFunc,
    GetHashCodeFunc< T >    getHashCodeFunc
)
    : base(
        (x,y) => compareFunc( x, y ) == 0,
        getHashCodeFunc )
{
    if( compareFunc == null )
        throw new ArgumentNullException( "compareFunc" );
    this.CompareFunc = compareFunc;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

private
CompareFunc< T >
CompareFunc;



// -----------------------------------------------------------------------------
// System.Collections.Generic.IComparer< T >
// -----------------------------------------------------------------------------

public
    int
Compare(
    T x,
    T y
)
{
    return this.CompareFunc( x, y );
}



// -----------------------------------------------------------------------------
// IEquatableHD< IComparerHD >
// -----------------------------------------------------------------------------

public virtual
    bool
Equals(
    IComparerHD that
)
{
    return
        that != null
        && that.Is<
            ComparerHD< T > >(
            c => c.CompareFunc == this.CompareFunc
                && c.GetHashCodeFunc == this.GetHashCodeFunc );
}


public new virtual
    int
GetHashCode()
{
    return
        typeof( ComparerHD< T > ).GetHashCode()
        ^ this.CompareFunc.GetHashCode()
        ^ this.GetHashCodeFunc.GetHashCode();
}




} // type
} // namespace

