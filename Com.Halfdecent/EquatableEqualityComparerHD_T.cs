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
EquatableEqualityComparerHD<
    T
>
    : EqualityComparerHD< T >
{


// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
EquatableEqualityComparerHD()
    : base(

        // IEquatableHD<T>.Equals()
        typeof( IEquatableHD< T > ).IsAssignableFrom( typeof( T ) )
            ? (EqualsFunc< T >)(
                (x,y) => SystemEquatable.EqualsBidirectional< T >(
                    x, y,
                    (a,b) => ((IEquatableHD< T >)a).Equals( b ),
                    (a,b) => ((IEquatableHD< T >)b).Equals( a ) ) )

            // IEquatable<T>.Equals()
            : typeof( IEquatable< T > ).IsAssignableFrom( typeof( T ) )
                ? (EqualsFunc< T >)(
                    (x,y) => SystemEquatable.EqualsBidirectional< T >(
                        x, y,
                        (a,b) => ((IEquatable< T >)a).Equals( b ),
                        (a,b) => ((IEquatable< T >)b).Equals( a ) ) )

                // (error)
                : (x,y) => false,

        // IEquatableHD<T>.GetHashCode()
        typeof( IEquatableHD< T > ).IsAssignableFrom( typeof( T ) )
            ? (GetHashCodeFunc< T >)(
                x => ((IEquatableHD< T >)x).GetHashCode() )

            // System.Object.GetHashCode()
            : x => ((object)x).GetHashCode() )

{
    if( !typeof( IEquatableHD< T > ).IsAssignableFrom( typeof( T ) )
        && !typeof( IEquatable< T > ).IsAssignableFrom( typeof( T ) ) )
        throw new NotSupportedException();
}



// -----------------------------------------------------------------------------
// IEquatableHD< IEqualityComparerHD >
// -----------------------------------------------------------------------------

public override
    bool
Equals(
    IEqualityComparerHD that
)
{
    return
        that != null
        && that.Is< EquatableEqualityComparerHD< T > >();
}


public override
    int
GetHashCode()
{
    return
        typeof( EquatableEqualityComparerHD< T > ).GetHashCode();
}




} // type
} // namespace

