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


using System.Collections.Generic;
using System.Linq;
using Com.Halfdecent;
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Exceptions;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// RType Library
// =============================================================================

public static class
RType
{



// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

/// Ensure that an item is of the RType
///
/// @exception RTypeException
/// <tt>item</tt> was found not to be of the RType
///
public static
void
Check<
    T,
    U
>(
    this IRType< T >    t,
    U                   item,
    ///< Item to check
    IValue              itemReference
    ///< What the caller refers to <tt>item</tt> as
)
    where U : T
{
    if( t == null )
        throw new ValueArgumentNullException(
            new Parameter( "t" ) );
    if( itemReference == null )
        throw new ValueArgumentNullException(
            new Parameter( "itemReference" ) );
    foreach( IRType< T > c in t.Components ) {
        try {
            c.Check( item, itemReference );
        } catch( RTypeException e ) {
            throw new RTypeException( itemReference, t, e );
        }
    }
    if( !t.Predicate( item ) )
        throw new RTypeException( itemReference, t );
}


/// Determine whether this RType is the same or more specific than another
///
public static
bool
IsEqualToOrMoreSpecificThan<
    T
>(
    this IRType< T >    t,
    IRType              u
)
{
    if( t == null )
        throw new ValueArgumentNullException( new Parameter( "t" ) );
    if( u == null )
        throw new ValueArgumentNullException( new Parameter( "u" ) );
    return
        t.AsSingleItemEnumerable()
        .Concat( t.AllComponentsDepthFirst() )
        .Covary< IRType< T >, IRType >()
        .Contains( u );
}


/// Recursively list all components of this RType, depth first
///
public static
IEnumerable< IRType< T > >
AllComponentsDepthFirst<
    T
>(
    this IRType< T >    t
)
{
    if( t == null )
        throw new ValueArgumentNullException( new Parameter( "t" ) );
    return
        t.Components
        .SelectMany( c =>
            c.AsSingleItemEnumerable()
            .Concat( c.AllComponentsDepthFirst() ) );
}


/// Contravary the RType into one of a more specific type of item
///
public static
IRType< TTo >
Contravary<
    TFrom,
    TTo
>(
    this IRType< TFrom > t
)
    where TTo : TFrom
{
    return new RTypeContravariantAdapter< TFrom, TTo >( t );
}




} // type
} // namespace

