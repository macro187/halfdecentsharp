// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010, 2012
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
using Halfdecent;
using Halfdecent.Globalisation;
using Halfdecent.Meta;


namespace
Halfdecent.RTypes
{


// =============================================================================
/// Static methods for <tt>LTE<T></tt>
// =============================================================================

public static class
LTE
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
    where T : IComparable< T >
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
    T                   compareTo,
    IComparerHD< T >    comparer,
    T                   item,
    string              paramName
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
    where T : IComparable< T >
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
    T                   compareTo,
    IComparerHD< T >    comparer,
    T                   item
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
    where T : IComparable< T >
{
    return Create( compareTo, ComparerHD.Create< T >() );
}


public static
    RType< T >
Create<
    T
>(
    T                   compareTo,
    IComparerHD< T >    comparer
)
{
    return new LTE< T >( compareTo, comparer );
}



} // type



// =============================================================================
/// RType: Less than or equal to a particular value, according to a particular
/// ordering
// =============================================================================

public sealed class
LTE<
    T
>
    : RType< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
LTE(
    T                   compareTo,
    IComparerHD< T >    comparer
)
    : base(
        item =>
            item == null ? true
            : comparer.Compare( item, compareTo ) <= 0,
        ls => _S( "{0} is less than or equal to {1}",
            ls, SystemObject.ToString( compareTo ) ),
        ls => _S( "{0} is greater than {1}",
            ls, SystemObject.ToString( compareTo ) ),
        ls => _S( "{0} must be less than or equal to {1}",
            ls, SystemObject.ToString( compareTo ) ) )
{
    if( compareTo == null )
        throw new LocalisedArgumentNullException( "compareTo" );
    if( comparer == null )
        throw new LocalisedArgumentNullException( "comparer" );
    this.CompareTo = compareTo;
    this.Comparer = comparer;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// The value to compare to
///
public
T
CompareTo
{
    get;
    private set;
}


/// The ordering to use to make the comparison
///
public
IComparerHD< T >
Comparer
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// IEquatableHD< RType >
// IEquatable< RType >
// -----------------------------------------------------------------------------

public override
    bool
Equals(
    RType that
)
{
    return
        base.Equals( that )
        && that.Is<
            LTE< T > >(
            lte =>
                lte.Comparer.Equals( (IComparerHD)this.Comparer ) &&
                this.Comparer.Equals( lte.CompareTo, this.CompareTo ) );
}


public override
    int
GetHashCode()
{
    return
        base.GetHashCode() ^
        ((IEquatableHD<IComparerHD>)this.Comparer).GetHashCode() ^
        this.Comparer.GetHashCode( this.CompareTo );
}




private static Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Halfdecent.Globalisation.LocalisedResource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

