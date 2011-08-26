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


namespace
Com.Halfdecent
{


// =============================================================================
// A equality comparer based on Compare and GetHashCode functions
// =============================================================================

public class
EqualityComparer<
    T
>
    : IEqualityComparer< T >
{


// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
EqualityComparer(
    System.Func< T, T, bool >   equalsFunc,
    System.Func< T, int >       getHashCodeFunc
)
{
    if( equalsFunc == null )
        throw new System.ArgumentNullException( "equalsFunc" );
    if( getHashCodeFunc == null )
        throw new System.ArgumentNullException( "getHashCodeFunc" );
    this.EqualsFunc = equalsFunc;
    this.GetHashCodeFunc = getHashCodeFunc;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

private
System.Func< T, T, bool >
EqualsFunc;


private
System.Func< T, int >
GetHashCodeFunc;



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
// IEquatable< IEqualityComparer >
// -----------------------------------------------------------------------------

public
    bool
Equals(
    IEqualityComparer that
)
{
    return Equatable.Equals( this, that );
}


public
    bool
DirectionalEquals(
    IEqualityComparer that
)
{
    return that.Is<
        EqualityComparer< T > >(
        c =>
            c.EqualsFunc == this.EqualsFunc
            && c.GetHashCodeFunc == this.GetHashCodeFunc );
}


public override
    int
GetHashCode()
{
    return
        typeof( EqualityComparer< T >).GetHashCode()
        ^ this.EqualsFunc.GetHashCode()
        ^ this.GetHashCodeFunc.GetHashCode();
}



// -----------------------------------------------------------------------------
// System.Object
// -----------------------------------------------------------------------------

public override
    bool
Equals(
    object that
)
{
    throw new System.NotSupportedException();
}




} // type
} // namespace

