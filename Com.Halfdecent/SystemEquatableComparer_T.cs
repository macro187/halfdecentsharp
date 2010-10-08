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


using SCG = System.Collections.Generic;


namespace
Com.Halfdecent
{


// =============================================================================
/// An <tt>IEqualityComparer<T></tt> that determines equality according to
/// <tt>System.IEquatable<T></tt>
///
/// Note that because <tt>System.IEquatable<T></tt> doesn't have it's own
/// <tt>.GetHashCode()</tt>, the hash codes produced by this comparer may not
/// match its <tt>.Equals()</tt>.
///
/// As a result, this comparer should only be used in situations that do not
/// rely on correct hash codes.
///
/// The fix for the above problem is to implement a custom comparer with a
/// correct <tt>.GetHashCode()</tt>, or implement <tt>IEquatable<T></tt> from
/// this namespace, which includes a matching <tt>.GetHashCode()</tt>.
// =============================================================================

public struct
SystemEquatableComparer<
    T
>
    : IEqualityComparer< T >

    where T : System.IEquatable< T >
{



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
    if( object.ReferenceEquals( dis, null ) &&
        object.ReferenceEquals( that, null ) ) return true;
    if( object.ReferenceEquals( dis, null ) ||
        object.ReferenceEquals( that, null ) ) return false;
    return dis.Equals( that );
}


public
    int
GetHashCode(
    T item
)
{
    if( object.ReferenceEquals( item, null ) )
        throw new System.ArgumentNullException( "item" );
    // Note: This is System.Object.GetHashCode()
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

