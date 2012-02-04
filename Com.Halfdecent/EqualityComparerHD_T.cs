// -----------------------------------------------------------------------------
// Copyright (c) 2011
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


namespace
Com.Halfdecent
{


// =============================================================================
/// (See <tt>EqualityComparerHD.Create<T>()</tt>)
// =============================================================================

public class
EqualityComparerHD<
    T
>
    : IEqualityComparerHD< T >
    , IEquatable< IEqualityComparerHD >
{


// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
EqualityComparerHD(
    EqualsFunc< T >         equalsFunc,
    GetHashCodeFunc< T >    getHashCodeFunc
)
{
    if( equalsFunc == null )
        throw new ArgumentNullException( "equalsFunc" );
    if( getHashCodeFunc == null )
        throw new ArgumentNullException( "getHashCodeFunc" );
    this.EqualsFunc = equalsFunc;
    this.GetHashCodeFunc = getHashCodeFunc;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

protected
EqualsFunc< T >
EqualsFunc
{
    get;
    private set;
}


protected
GetHashCodeFunc< T >
GetHashCodeFunc
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// System.Collections.Generic.IEqualityComparer< T >
// -----------------------------------------------------------------------------

public
    bool
Equals(
    T x,
    T y
)
{
    return this.EqualsFunc( x, y );
}


public
    int
GetHashCode(
    T obj
)
{
    return this.GetHashCodeFunc( obj );
}



// -----------------------------------------------------------------------------
// IEquatableHD< IEqualityComparerHD >
// -----------------------------------------------------------------------------

public virtual
    bool
Equals(
    IEqualityComparerHD that
)
{
    return
        that != null
        && that.Is<
            EqualityComparerHD< T > >( ec =>
                ec.EqualsFunc == this.EqualsFunc
                && ec.GetHashCodeFunc == this.GetHashCodeFunc );
}


public override
    int
GetHashCode()
{
    return
        typeof( EqualityComparerHD< T > ).GetHashCode()
        ^ this.EqualsFunc.GetHashCode()
        ^ this.GetHashCodeFunc.GetHashCode();
}




} // type
} // namespace

