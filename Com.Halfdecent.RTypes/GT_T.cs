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


using SCG = System.Collections.Generic;
using Com.Halfdecent;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// RType: Greater than a particular value, according to a particular ordering
// =============================================================================

public class
GT<
    T
>
    : SimpleTextRTypeBase< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
GT(
    T               compareTo,
    ///< The value to compare to
    IComparer< T >  comparer
    ///< The ordering to use
)
    : base(
        _S( "{{0}} is greater than {0}",
            ObjectUtils.ToString( compareTo ) ),
        _S( "{{0}} is less than or equal to {0}",
            ObjectUtils.ToString( compareTo ) ),
        _S( "{{0}} must be greater than {0}",
            ObjectUtils.ToString( compareTo ) ) )
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
    SCG.IEnumerable< IRType< T > >
GetComponents()
{
    return
        base.GetComponents()
        .Append( new GTE<T>( this.CompareTo, this.Comparer ) )
        .Append( new NEQ<T>( this.CompareTo, this.Comparer ) );
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
    GT<T> gt = (GT<T>)( that.GetUnderlying() );
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




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( typeof( GT<> ), s, args ); }

} // type
} // namespace

