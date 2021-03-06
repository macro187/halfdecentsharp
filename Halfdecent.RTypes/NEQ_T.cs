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
///<tt>NEQ<T></tt> Library
// =============================================================================

public static class
NEQ
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
    T                           compareTo,
    IEqualityComparerHD< T >    comparer,
    T                           item,
    string                      paramName
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
    T                           compareTo,
    IEqualityComparerHD< T >    comparer,
    T                           item
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
{
    return Create( compareTo, EqualityComparerHD.Create< T >() );
}


public static
    RType< T >
Create<
    T
>(
    T                           compareTo,
    IEqualityComparerHD< T >    comparer
)
{
    return new NEQ< T >( compareTo, comparer );
}



} // type




// =============================================================================
/// RType: Not equal to a particular value according to a particular equality
/// comparer
///
/// <tt>null</tt> values always pass unless <tt>CompareTo</tt> is <tt>null</tt>.
// =============================================================================

public sealed class
NEQ<
    T
>
    : RType< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
NEQ(
    T                           compareTo,
    IEqualityComparerHD< T >    comparer
)
    : base(
        item =>
            (object)compareTo == null ?
                item != null :
                item == null ?
                    true :
                    !comparer.Equals( item, compareTo ),
        r => _S( "{0} is not equal to {1}", r, compareTo ),
        r => _S( "{0} is equal to {1}", r, compareTo ),
        r => _S( "{0} must not be equal to {1}", r, compareTo ) )
{
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


/// The kind of equality to use
///
public
    IEqualityComparerHD< T >
Comparer
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// IComparable< RType >
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
            NEQ< T > >(
            neq =>
                neq.Comparer.Equals( this.Comparer ) &&
                this.Comparer.Equals( neq.CompareTo, this.CompareTo ) );
}


public override
    int
GetHashCode()
{
    return
        base.GetHashCode() ^
        this.Comparer.GetHashCode() ^
        ( this.CompareTo != null ?
            this.Comparer.GetHashCode( this.CompareTo ) :
            0 );
}




private static Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Halfdecent.Globalisation.LocalisedResource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

