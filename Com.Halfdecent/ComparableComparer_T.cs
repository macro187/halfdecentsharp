// -----------------------------------------------------------------------------
// Copyright (c) 2009
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


using SCG = System.Collections.Generic;


namespace
Com.Halfdecent
{


// =============================================================================
/// An <tt>IComparer<T></tt> that determines equality according to
/// <tt>IComparable<T></tt>
// =============================================================================

public struct
ComparableComparer<
    T
>
    : IComparer< T >

    where T : IComparable< T >
{



// -----------------------------------------------------------------------------
// System.Collections.Generic.IComparer< T >
// -----------------------------------------------------------------------------

public
    int
Compare(
    T dis,
    T that
)
{
    return Comparable.CompareTo( dis, that );
}



// -----------------------------------------------------------------------------
// System.Collections.Generic.IEqualityComparer< T >
// -----------------------------------------------------------------------------

public
    bool
Equals(
    T dis,
    T that
)
{
    return Equatable.Equals( dis, that );
}


public
    int
GetHashCode(
    T item
)
{
    if( item == null )
        throw new System.ArgumentNullException( "item" );
    return item.GetHashCode();
}



// -----------------------------------------------------------------------------
// IEqualityComparer
// -----------------------------------------------------------------------------

public
    IEqualityComparer
GetUnderlying()
{
    return this;
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
    return
        that != null &&
        that.GetUnderlying().GetType() == this.GetType();
}


public override
    int
GetHashCode()
{
    return this.GetType().GetHashCode();
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
    return
        that != null &&
        that is IEqualityComparer &&
        this.Equals( (IEqualityComparer)that );
}




} // type
} // namespace
