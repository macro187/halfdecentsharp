// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009
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
/// RType: Not equal to a particular value, according to a particular
/// definition of equality
///
/// <tt>null</tt> values always pass unless <tt>CompareTo</tt> is null.
// =============================================================================

public class
NEQ<
    T
>
    : SimpleTextRTypeBase< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
NEQ(
    T                       compareTo,
    IEqualityComparer< T >  comparer
)
    : base(
        _S( "{{0}} is not equal to {0}",
            SystemObject.ToString( compareTo ) ),
        _S( "{{0}} is equal to {0}",
            SystemObject.ToString( compareTo ) ),
        _S( "{{0}} must not be equal to {0}",
            SystemObject.ToString( compareTo ) ) )
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
    if( this.CompareTo == null ) return ( item != null );
    if( item == null ) return true;
    return !this.Comparer.Equals( item, this.CompareTo );
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
    NEQ<T> neq = that.GetUnderlying() as NEQ<T>;
    if( neq == null ) return false;
    return
        neq.Comparer.Equals( this.Comparer ) &&
        this.Comparer.Equals( neq.CompareTo, this.CompareTo );
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




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( typeof( NEQ<> ), s, args ); }

} // type
} // namespace

