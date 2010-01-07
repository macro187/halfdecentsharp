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
using System.Linq;
using Com.Halfdecent;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// <tt>IRType</tt> and <tt>IRType<T></tt> Library
// =============================================================================

public static class
RType
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Determine whether an item conforms to this RType
///
public static
    bool
Is<
    T,
    U
>(
    this IRType< T >    dis,
    U                   item
)
    where U : T
{
    if( dis == null )
        throw new ValueArgumentNullException( new Parameter( "dis" ) );
    return dis.Check( item, new Parameter( "item" ) ) == null;
}


/// Determine whether an item conforms to this RType, with details if it does
/// not
///
public static
    RTypeException
    /// @returns
    /// <tt>null</tt>, if <tt>item</tt> conforms to this RType
    /// - OR -
    /// An <tt>RTypeException</tt> with details, if <tt>item</tt> does not
    /// conform to this RType
Check<
    T,
    U
>(
    this IRType< T >    dis,
    U                   item,
    ///< Item to check
    Value               itemReference
    ///< Reference to <tt>item</tt> from the caller's perspective
)
    where U : T
{
    if( dis == null )
        throw new ValueArgumentNullException( new Parameter( "dis" ) );
    if( itemReference == null )
        throw new ValueArgumentNullException(
            new Parameter( "itemReference" ) );

    RTypeException rte;

    // GetComponents()
    foreach( IRType< T > c in dis.GetComponents() ) {
        rte = c.Check( item, itemReference );
        if( rte != null )
            return new RTypeException(
                itemReference, dis.GetUnderlying(), rte );
    }

    // CheckMembers()
    rte = dis.CheckMembers( item, itemReference );
    if( rte != null )
        return new RTypeException(
            itemReference, dis.GetUnderlying(), rte );

    // Predicate()
    if( !dis.Predicate( item ) )
        return new RTypeException( itemReference, dis.GetUnderlying() );

    return null;
}


/// Require that an item conform to this RType
///
/// @exception RTypeException
/// <tt>item</tt> does not conform to this RType
///
public static
    void
Require<
    T,
    U
>(
    this IRType< T >    dis,
    U                   item,
    ///< Item to check
    Value               itemReference
    ///< Reference to <tt>item</tt> from the caller's perspective
)
    where U : T
{
    if( dis == null )
        throw new ValueArgumentNullException( new Parameter( "dis" ) );
    RTypeException rte = dis.Check( item, itemReference );
    if( rte != null ) throw rte;
}


/// Determine whether this RType is the same or more specific than another
///
public static
    bool
IsEqualToOrMoreSpecificThan<
    T
>(
    this IRType< T >    dis,
    IRType              that
)
{
    if( dis == null )
        throw new ValueArgumentNullException( new Parameter( "dis" ) );
    if( that == null )
        throw new ValueArgumentNullException( new Parameter( "that" ) );
    return
        dis.AsSingleItemEnumerable()
        .Concat( dis.AllComponentsDepthFirst() )
        .OfType< IRType >()
        .Contains( that, new EquatableComparer< IRType >() );
}


/// <tt>GetComponents()</tt>, recursive, depth first
///
public static
    SCG.IEnumerable< IRType< T > >
AllComponentsDepthFirst<
    T
>(
    this IRType< T > dis
)
{
    if( dis == null )
        throw new ValueArgumentNullException( new Parameter( "dis" ) );
    return
        dis.GetComponents()
        .SelectMany( c =>
            c.AsSingleItemEnumerable()
            .Concat( c.AllComponentsDepthFirst() ) );
}


/// Contravary to an RType of a more specific type of item
///
public static
    IRType< TTo >
Contravary<
    T,
    TTo
>(
    this IRType< T > dis
)
    where TTo : T
{
    if( dis == null )
        throw new ValueArgumentNullException( new Parameter( "dis" ) );
    return new RTypeAdapter< T, TTo >( dis );
}




} // type
} // namespace

