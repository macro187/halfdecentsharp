// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010
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
using Com.Halfdecent;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// Static methods for <tt>GT<T></tt>
// =============================================================================

public static class
GT
{


/// According to IComparable
///
public static
    void
Check<
    T
>(
    T compareTo,
    T item
)
    where T : System.IComparable< T >
{
    ValueReferenceException.Map(
        f => f.Parameter( "item" ),
        f => f.Down().Parameter( "item" ),
        () => Create( compareTo ).Check( item ) );
}


/// According to a specified comparer
///
public static
    void
Check<
    T
>(
    T               compareTo,
    IComparer< T >  comparer,
    T               item
)
{
    ValueReferenceException.Map(
        f => f.Parameter( "item" ),
        f => f.Down().Parameter( "item" ),
        () => Create( compareTo, comparer ).Check( item ) );
}


public static
    RType< T >
Create<
    T
>(
    T compareTo
)
    where T : System.IComparable< T >
{
    return Create( compareTo, new SystemComparableComparer< T >() );
}


public static
    RType< T >
Create<
    T
>(
    T               compareTo,
    IComparer< T >  comparer
)
{
    return new GT< T >( compareTo, comparer );
}



} // type



// =============================================================================
/// RType: Greater than a particular value, according to a particular ordering
// =============================================================================

public sealed class
GT<
    T
>
    : CompositeRType< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
GT(
    T               compareTo,
    IComparer< T >  comparer
)
    : base(
        SystemEnumerable.Create(
            GTE.Create( compareTo, comparer ),
            NEQ.Create( compareTo, comparer ) ),
        ls => _S( "{0} is greater than {1}",
            ls, SystemObject.ToString( compareTo ) ),
        ls => _S( "{0} is not greater than {1}",
            ls, SystemObject.ToString( compareTo ) ),
        ls => _S( "{0} must be greater than {1}",
            ls, SystemObject.ToString( compareTo ) ) )
{}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

