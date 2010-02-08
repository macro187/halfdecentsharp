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
/// An adapter that turns an equality comparer into one that compares a more
/// specific kind of item
// =============================================================================

public class
EqualityComparerProxy<
    TFrom,
    T
>
    : IEqualityComparer< T >
    where T : TFrom
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
EqualityComparerProxy(
    IEqualityComparer< TFrom > from
)
{
    if( object.ReferenceEquals( from, null ) )
        throw new System.ArgumentNullException( "from" );
    this.From = from;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
IEqualityComparer< TFrom >
From
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
    T a,
    T b
)
{
    return this.From.Equals( a, b );
}


public
    int
GetHashCode(
    T item
)
{
    return this.From.GetHashCode( item );
}



// -----------------------------------------------------------------------------
// IEqualityComparer
// -----------------------------------------------------------------------------

public
    IEqualityComparer
GetUnderlying()
{
    return this.From.GetUnderlying();
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
    return this.From.Equals( that );
}


public
    bool
DirectionalEquals(
    IEqualityComparer that
)
{
    return this.From.DirectionalEquals( that );
}


public override
    int
GetHashCode()
{
    return this.From.GetHashCode();
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

