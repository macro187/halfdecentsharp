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
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// <tt>EQ<T></tt> Library
// =============================================================================

public static class
EQ
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
    where T : System.IEquatable< T >
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
    T                       compareTo,
    IEqualityComparer< T >  comparer,
    T                       item,
    string                  paramName
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
    where T : System.IEquatable< T >
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
    T                       compareTo,
    IEqualityComparer< T >  comparer,
    T                       item
)
{
    ValueReferenceException.Map(
        f => f.Parameter( "item" ),
        f => f.Down().Parameter( "item" ),
        () => Create( compareTo, comparer).Check( item ) );
}


public static
    RType< T >
Create<
    T
>(
    T compareTo
)
    where T : System.IEquatable< T >
{
    return Create( compareTo, new SystemEquatableComparer< T >() );
}


public static
    RType< T >
Create<
    T
>(
    T                       compareTo,
    IEqualityComparer< T >  comparer
)
{
    return new EQ< T >( compareTo, comparer );
}



} // type



// =============================================================================
/// RType: Equal to a particular value according to a particular equality
/// comparer
///
/// <tt>null</tt> values always pass
// =============================================================================

public sealed class
EQ<
    T
>
    : RType< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
EQ(
    T                       compareTo,
    IEqualityComparer< T >  comparer
)
    : base(
        item =>
            (object)item == null ?
                true :
                comparer.Equals( compareTo, item ),
        r => _S( "{0} is equal to {1}", r, compareTo ),
        r => _S( "{0} isn't equal to {1}", r, compareTo ),
        r => _S( "{0} must be equal to {1}", r, compareTo ) )
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
    IEqualityComparer< T >
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
DirectionalEquals(
    RType that
)
{
    return
        base.DirectionalEquals( that )
        && that.Match<
            EQ< T > >(
            eq =>
                eq.Comparer.Equals( this.Comparer ) &&
                this.Comparer.Equals( eq.CompareTo, this.CompareTo ) );
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




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

