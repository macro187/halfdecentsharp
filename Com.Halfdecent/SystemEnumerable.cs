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



// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

/// Create an enumerable consiting of the items in this one plus a specified
/// sequence of additional items
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


/// Determine whether an enumerable begins with a specified sequence of items
///
public static
    bool
StartsWith<
    T
>(
    this IEnumerable< T >   dis,
    IEnumerable< T >        sequence
)
{
    return dis.StartsWith<T>(
        sequence,
        new ObjectComparer().Contravary< object, T >() );
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
            ((Predicate< T >)( item => comparer.Equals( item, s ) ) ) ) );
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
            throw new ArgumentException( "null criteria encountered" );
        if( !c.Current( d.Current ) ) return false;
    }
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

