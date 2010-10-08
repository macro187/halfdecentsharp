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
/// Static methods for <tt>EQ<T></tt>
// =============================================================================

public static class
EQ
{


/// According to a particular definition of equality
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
    where T : System.IEquatable< T >
{
    Create( compareTo ).Require( item, itemReference );
}


/// According to a particular comparer
///
public static
    void
Require<
    T
>(
    T                       compareTo,
    IEqualityComparer< T >  comparer,
    T                       item,
    Value                   itemReference
)
{
    Create( compareTo, comparer ).Require( item, itemReference );
}


public static
    EQ< T >
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
    EQ< T >
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
/// RType: Equal to a particular value, according to a particular definition of
/// equality
///
/// <tt>null</tt> values always pass
// =============================================================================

public sealed class
EQ<
    T
>
    : SimpleTextRTypeBase< T >
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
        _S( "{{0}} is equal to {0}", SystemObject.ToString( compareTo ) ),
        _S( "{{0}} isn't equal to {0}", SystemObject.ToString( compareTo ) ),
        _S( "{{0}} must be equal to {0}", SystemObject.ToString( compareTo ) ) )
{
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
// RTypeBase< object >
// -----------------------------------------------------------------------------

public override
    bool
Predicate(
    T item
)
{
    if( this.CompareTo == null ) return ( item == null );
    if( item == null ) return true;
    return this.Comparer.Equals( item, this.CompareTo );
}



// -----------------------------------------------------------------------------
// IComparable< IRType >
// -----------------------------------------------------------------------------

public override
    bool
DirectionalEquals(
    IRType that
)
{
    if( !base.DirectionalEquals( that ) ) return false;
    EQ<T> eq = that.GetUnderlying() as EQ<T>;
    if( eq == null ) return false;
    return
        eq.Comparer.Equals( this.Comparer ) &&
        this.Comparer.Equals( eq.CompareTo, this.CompareTo );
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




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( typeof( EQ<> ), s, args ); }

} // type
} // namespace

