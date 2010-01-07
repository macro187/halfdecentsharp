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


namespace
Com.Halfdecent
{


// =============================================================================
/// <tt>IComparable<T></tt> Library
// =============================================================================

public static class
Comparable
{



// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

public static
    bool
GT<
    T
>(
    this T  dis,
    T       that
)
    where T : IComparable< T >
{
    return dis.CompareTo( that ) > 0;
}


public static
    bool
GTE<
    T
>(
    this T  dis,
    T       that
)
    where T : IComparable< T >
{
    return dis.CompareTo( that ) >= 0;
}


public static
    bool
LT<
    T
>(
    this T  dis,
    T       that
)
    where T : IComparable< T >
{
    return dis.CompareTo( that ) < 0;
}


public static
    bool
LTE<
    T
>(
    this T  dis,
    T       that
)
    where T : IComparable< T >
{
    return dis.CompareTo( that ) <= 0;
}



// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// <tt>IComparable<T>.CompareTo()</tt> implementation
///
public static
    int
    /// @returns
    /// A positive integer if <tt>this</tt> is greater than <tt>that</tt>
    /// - OR -
    /// 0 if the items are equal to one another
    /// - OR -
    /// A negative integer if <tt>this</tt> is less than <tt>that</tt>
CompareTo<
    T
>(
    T dis,
    T that
)
    where T : IComparable< T >
{
    // Handle nulls according to System.IComparable.CompareTo() rules
    if( object.ReferenceEquals( dis, null ) &&
        object.ReferenceEquals( that, null ) ) return 0;
    if( object.ReferenceEquals( dis, null ) ) return -1;
    if( object.ReferenceEquals( that, null ) ) return 1;

    // Get both items' opinion
    int dissays = dis.DirectionalCompareTo( that );
    int thatsays = that.DirectionalCompareTo( dis );

    // If both items agree, use the agreed result
    if( dissays == 0 && thatsays == 0 ) return 0;
    if( dissays > 0 && thatsays < 0 ) return 1;
    if( dissays < 0 && thatsays > 0 ) return -1;

    // If one says equal and the other says greater or less than, assume the
    // latter is more specific and go with that
    if( dissays == 0 && thatsays < 0 ) return 1;
    if( dissays == 0 && thatsays > 0 ) return -1;
    if( dissays > 0 && thatsays == 0 ) return 1;
    if( dissays < 0 && thatsays == 0 ) return -1;

    // If neither of the above is the case, then the items completely disagree
    // which means something's wrong with one or both of their comparison
    // implementations
    throw new ComparisonDisagreementException(
        typeof( T ),
        dis.GetType(),
        dis,
        dissays,
        that.GetType(),
        that,
        thatsays );
}




} // type
} // namespace

