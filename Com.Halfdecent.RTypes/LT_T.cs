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
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// Static methods for <tt>LT<T></tt>
// =============================================================================

public static class
LT
{


public static
    void
CheckParameter<
    T
>(
    T       compareTo,
    T       item,
    string  paramName
)
    where T : System.IComparable< T >
{
    if( paramName == null )
        throw new LocalisedArgumentNullException( "paramName" );
    if( paramName == "" )
        throw new LocalisedArgumentException( "blank", "paramname" );
    ValueReferenceException.Map(
        f => f.Up().Parameter( paramName ),
        f => f.Parameter( "item" ),
        () => ValueReferenceException.Map(
            f => f.Parameter( "item" ),
            f => f.Down().Parameter( "item" ),
            () => Check( compareTo, item ) ) );
}


public static
    void
CheckParameter<
    T
>(
    T               compareTo,
    IComparer< T >  comparer,
    T               item,
    string          paramName
)
{
    if( paramName == null )
        throw new LocalisedArgumentNullException( "paramName" );
    if( paramName == "" )
        throw new LocalisedArgumentException( "blank", "paramname" );
    ValueReferenceException.Map(
        f => f.Up().Parameter( paramName ),
        f => f.Parameter( "item" ),
        () => ValueReferenceException.Map(
            f => f.Parameter( "item" ),
            f => f.Down().Parameter( "item" ),
            () => Check( compareTo, comparer, item ) ) );
}


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
    return new LT< T >( compareTo, comparer );
}



} // type



// =============================================================================
/// RType: Less than a particular value, according to a particular ordering
// =============================================================================

public sealed class
LT<
    T
>
    : CompositeRType< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
LT(
    T               compareTo,
    IComparer< T >  comparer
)
    : base(
        SystemEnumerable.Create(
            LTE.Create( compareTo, comparer ),
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

