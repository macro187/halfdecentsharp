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


using System;
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Numerics
{


// =============================================================================
/// RType: Greater than or equal to a particular value
///
/// According to <tt>IComparable.CompareTo()</tt>
///
/// When <tt>.CompareTo</tt> is <tt>null</tt>, <tt>System.IComparable</tt>
/// semantics are used (ie. <tt>null</tt>s are equal and <tt>null</tt> is
/// greater than non-null.)  Otherwise, <tt>null</tt> values always pass.
// =============================================================================

public class
GTE
    : SimpleTextRTypeBase< object >
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
GTE(
    IComparable compareTo
    ///< The value to compare to
)
    : base(
        _S( "{{0}} is {0} or greater", compareTo ),
        _S( "{{0}} is less than {0}", compareTo ),
        _S( "{{0}} must be {0} or greater", compareTo )
    )
{
    this.CompareTo = compareTo;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// The value to compare to
///
public
IComparable
CompareTo
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// RTypeBase< object >
// -----------------------------------------------------------------------------

protected override
bool
Equals(
    IRType t
)
{
    return ((GTE)t).CompareTo.Equals( this.CompareTo );
}



// -----------------------------------------------------------------------------
// IRType< object >
// -----------------------------------------------------------------------------

public override
bool
Predicate(
    object item
)
{
    // When comparing against null, null == null
    if( this.CompareTo == null && item == null ) return true;
    // When comparing against null, null > non-null
    if( this.CompareTo == null && item != null ) return false;
    // When not comparing against null, null always passes
    if( item == null ) return true;
    return ( this.CompareTo.CompareTo( item ) <= 0 );
}



// -----------------------------------------------------------------------------
// object
// -----------------------------------------------------------------------------

public override
int
GetHashCode()
{
    if( this.CompareTo == null ) return base.GetHashCode();
    return base.GetHashCode() ^ this.CompareTo.GetHashCode();
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

