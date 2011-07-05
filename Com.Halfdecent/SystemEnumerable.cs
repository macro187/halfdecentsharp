// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010
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
using System.Linq;
using System.Collections;
using System.Collections.Generic;


namespace
Com.Halfdecent
{


// =============================================================================
/// <tt>System.Collections.Generic.IEnumerable</tt> Library
// =============================================================================

public static class
SystemEnumerable
{



// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// Create an enumerable yielding a specified sequence of items
///
public static
    IEnumerable< T >
Create<
    T
>(
    params T[] items
)
{
    if( object.ReferenceEquals( items, null ) )
        throw new ArgumentNullException( "items" );
    return items;
}


/// Create an enumerable by recursively applying a function to its own result,
/// starting with a seed item, until <tt>null</tt> is encountered
///
/// Useful for descending through recursive data structures
///
public static
    IEnumerable< T >
Recurse<
    T
>(
    T                   seed,
    System.Func< T, T > func
)
{
    for(
        T item = seed;
        item != null;
        item = func( item )
    )
        yield return item;
}



// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

/// Create an enumerable consisting of the items in this one plus additional
/// specified item(s)
///
public static
    IEnumerable< T >
Append<
    T
>(
    this IEnumerable< T >   enumerable,
    params T[]              items
)
{
    if( object.ReferenceEquals( enumerable, null ) )
        throw new ArgumentNullException( "enumerable" );
    if( object.ReferenceEquals( items, null ) )
        throw new ArgumentNullException( "items" );
    return enumerable.Concat( items );
}


/// Determine whether an enumerable begins with a specified sequence of
/// equatable items
///
public static
    bool
StartsWith<
    T
>(
    this IEnumerable< T >   dis,
    IEnumerable< T >        sequence
)
    where T : System.IEquatable< T >
{
    return dis.StartsWith< T >( sequence, new SystemEquatableComparer< T >() );
}


/// Determine whether an enumerable begins with a specified sequence of items
/// according to a specified comparer
///
public static
    bool
StartsWith<
    T
>(
    this IEnumerable< T >   dis,
    IEnumerable< T >        sequence,
    IEqualityComparer< T >  comparer
)
{
    if( object.ReferenceEquals( dis, null ) )
        throw new System.ArgumentNullException( "dis" );
    if( object.ReferenceEquals( sequence, null ) )
        throw new System.ArgumentNullException( "sequence" );
    if( object.ReferenceEquals( comparer, null ) )
        throw new System.ArgumentNullException( "comparer" );
    return dis.StartsWith< T >(
        sequence.Select( s =>
            (Predicate< T >)( item => comparer.Equals( item, s ) ) ) );
}


/// Determine whether an enumerable begins with a sequence of items
/// meeting a specified sequence of criteria
///
/// @exception ArgumentException
/// <tt>criteria</tt> included a null value
///
public static
    bool
StartsWith<
    T
>(
    this IEnumerable< T >   dis,
    params Predicate< T >[] criteria
)
{
    return dis.StartsWith< T >( criteria );
}


/// Determine whether an enumerable begins with a sequence of items
/// meeting a specified sequence of criteria
///
/// @exception ArgumentException
/// <tt>criteria</tt> included a null value
///
public static
    bool
StartsWith<
    T
>(
    this IEnumerable< T >           dis,
    IEnumerable< Predicate< T > >   criteria
)
{
    if( object.ReferenceEquals( dis, null ) )
        throw new System.ArgumentNullException( "dis" );
    if( object.ReferenceEquals( criteria, null ) )
        throw new System.ArgumentNullException( "criteria" );
    IEnumerator< T > d = dis.GetEnumerator();
    IEnumerator< Predicate< T > > c = criteria.GetEnumerator();
    for( ;; ) {
        if( !c.MoveNext() ) return true;
        if( !d.MoveNext() ) return false;
        if( object.ReferenceEquals( c.Current, null ) )
            throw new ArgumentException( "null criterion encountered" );
        if( !c.Current( d.Current ) ) return false;
    }
}


/// Locate the first instance of a specified subsequence
///
public static
    int
    /// @returns
    /// The index of the beginning of the subsequence, or <tt>-1</tt> if not
    /// found
IndexOf<
    T
>(
    this IEnumerable< T >   dis,
    IEnumerable< T >        subsequence
)
    where T : System.IEquatable< T >
{
    if( object.ReferenceEquals( dis, null ) )
        throw new System.ArgumentNullException( "dis" );
    if( object.ReferenceEquals( subsequence, null ) )
        throw new System.ArgumentNullException( "subsequence" );

    return dis.IndexOf( subsequence, new SystemEquatableComparer< T >() );
}


/// Locate the first instance of a specified subsequence, matched according to a
/// specified equality comparer
///
public static
    int
    /// @returns
    /// The index of the beginning of the subsequence, or <tt>-1</tt> if not
    /// found
IndexOf<
    T
>(
    this IEnumerable< T >   dis,
    IEnumerable< T >        subsequence,
    IEqualityComparer< T >  comparer
)
{
    if( object.ReferenceEquals( dis, null ) )
        throw new System.ArgumentNullException( "dis" );
    if( object.ReferenceEquals( subsequence, null ) )
        throw new System.ArgumentNullException( "subsequence" );
    if( object.ReferenceEquals( comparer, null ) )
        throw new System.ArgumentNullException( "comparer" );

    return dis.IndexOf(
        subsequence.Select( s =>
            (Predicate< T >)( item => comparer.Equals( item, s ) ) ) );
}


/// Locate the first subsequence matching specified criteria
///
public static
    int
    /// @returns
    /// The index of the beginning of the subsequence, or <tt>-1</tt> if not
    /// found
IndexOf<
    T
>(
    this IEnumerable< T >           dis,
    IEnumerable< Predicate< T > >   criteria
)
{
    if( object.ReferenceEquals( dis, null ) )
        throw new System.ArgumentNullException( "dis" );
    if( object.ReferenceEquals( criteria, null ) )
        throw new System.ArgumentNullException( "criteria" );

    int dcount = dis.Count();
    int ccount = criteria.Count();

    // Zero-length criteria matches straight away
    if( ccount == 0 ) return 0;

    // Longer substring can't possibly match
    if( ccount > dcount ) return -1;

    int lastpossible = dcount - ccount;

    for( int i = 0; i <= lastpossible; i++ )
        if( dis.Skip( i ).StartsWith( criteria ) ) return i;

    return -1;
}


/// Covary the enumerable to one of items of a less-specific type
///
public static
    IEnumerable< TTo >
Covary<
    TFrom,
    TTo
>(
    this IEnumerable< TFrom > e
)
    where TFrom : TTo
{
    return e.Select< TFrom, TTo >( i => i );
}




} // type
} // namespace

