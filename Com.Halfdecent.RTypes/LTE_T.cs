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


using Com.Halfdecent;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// Static methods for <tt>LTE<T></tt>
// =============================================================================

public static class
LTE
{


/// According to a specified ordering
///
public static
    void
Require<
    T
>(
    T       compareTo,
    T       item,
    Value   itemReference
)
    where T : System.IComparable< T >
{
    Create( compareTo ).Require( item, itemReference );
}


/// According to a specified comparer
///
public static
    void
Require<
    T
>(
    T               compareTo,
    IComparer< T >  comparer,
    T               item,
    Value           itemReference
)
{
    Create( compareTo, comparer ).Require( item, itemReference );
}


public static
    LTE< T >
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
    LTE< T >
Create<
    T
>(
    T               compareTo,
    IComparer< T >  comparer
)
{
    return new LTE< T >( compareTo, comparer );
}



} // type



// =============================================================================
/// RType: Less than or equal to a particular value, according to a
/// particular ordering
// =============================================================================

public sealed class
LTE<
    T
>
    : SimpleTextRTypeBase< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
LTE(
    T               compareTo,
    ///< The value to compare to
    IComparer< T >  comparer
    ///< The ordering to use
)
    : base(
        _S( "{{0}} is less than or equal to {0}",
            SystemObject.ToString( compareTo ) ),
        _S( "{{0}} is greater than {0}",
            SystemObject.ToString( compareTo ) ),
        _S( "{{0}} must be less than or equal to {0}",
            SystemObject.ToString( compareTo ) ) )
{
    if( compareTo == null )
        throw new ValueArgumentNullException( new Parameter( "compareTo" ) );
    if( comparer == null )
        throw new ValueArgumentNullException( new Parameter( "comparer" ) );
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
IComparer< T >
Comparer
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// RTypeBase< T >
// -----------------------------------------------------------------------------

public override
    bool
Predicate(
    T item
)
{
    if( object.ReferenceEquals( item, null ) ) return true;
    return this.Comparer.Compare( item, this.CompareTo ) <= 0;
}



// -----------------------------------------------------------------------------
// IEquatable< RType >
// -----------------------------------------------------------------------------

public override
    bool
DirectionalEquals(
    IRType that
)
{
    if( !base.DirectionalEquals( that ) ) return false;
    LTE<T> gt = (LTE<T>)( that.GetUnderlying() );
    return
        gt.Comparer.Equals( this.Comparer ) &&
        this.Comparer.Equals( gt.CompareTo, this.CompareTo );
}


public override
    int
GetHashCode()
{
    return
        base.GetHashCode() ^
        this.Comparer.GetHashCode() ^
        this.Comparer.GetHashCode( this.CompareTo );
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( typeof( LTE<> ), s, args ); }

} // type
} // namespace

