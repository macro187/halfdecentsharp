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


using System;
using Com.Halfdecent;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Numerics;


namespace
Com.Halfdecent.Collections
{


public static partial class
OrderedCollectionR
{



public static
    bool
SequenceEqual<
    T
>(
    this IOrderedCollectionR< T >   dis,
    IOrderedCollectionR< T >        that
)
{
    new NonNull().Require( dis, new Parameter( "dis" ) );
    new NonNull().Require( that, new Parameter( "that" ) );
    return dis.SequenceEqual< T >(
        that, new ObjectComparer().Contravary< object, T >() );
}


public static
    bool
SequenceEqual<
    T,
    TEquatable
>(
    this IOrderedCollectionR< T >   dis,
    IOrderedCollectionR< T >        that
)
    where T : TEquatable
    where TEquatable : IEquatable< TEquatable >
{
    new NonNull().Require( dis, new Parameter( "dis" ) );
    new NonNull().Require( that, new Parameter( "that" ) );
    return dis.SequenceEqual(
        that,
        new EquatableComparer< TEquatable >().Contravary< TEquatable, T >() );
}


public static
    bool
SequenceEqual<
    T
>(
    this IOrderedCollectionR< T >   dis,
    IOrderedCollectionR< T >        that,
    IEqualityComparer< T >          comparer
)
{
    new NonNull().Require( dis, new Parameter( "dis" ) );
    new NonNull().Require( that, new Parameter( "that" ) );
    new NonNull().Require( comparer, new Parameter( "comparer" ) );

    if( !dis.Count.Equals( that.Count ) ) return false;
    return dis.Stream().SequenceEqual( that.Stream(), comparer );
}


public static
    IOrderedCollectionR< T >
Covary<
    TFrom,
    T
>(
    this IOrderedCollectionR< TFrom > from
)
    where TFrom : T
{
    return new OrderedCollectionRProxy< TFrom, T >( from );
}


/// Determine the index of the first item in the collection that matches
/// specified criteria
///
public static
    IInteger
    /// @returns Index of the matching item
    /// - OR -
    /// -1 if no matching item
IndexWhere<
    T
>(
    this IOrderedCollectionR< T >   dis,
    Predicate< T >                  where
)
{
    new NonNull().Require( where, new Parameter( "where" ) );
    foreach( ITuple< IInteger, T > t in dis.StreamPairs().AsEnumerable() ) {
        if( where( t.B ) ) return t.A;
    }
    return Integer.From( -1 );
}




} // type
} // namespace

