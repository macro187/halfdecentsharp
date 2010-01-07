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
using System.Collections.Generic;
using Com.Halfdecent.SystemUtils;
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Numerics
{


// =============================================================================
/// RType: Greater than a particular value
///
/// According to <tt>IComparable.CompareTo()</tt>
// =============================================================================

public class
GT
    : SimpleTextRTypeBase< object >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
GT(
    IComparable compareTo
    ///< The value to compare to
)
    : base(
        _S( "{{0}} is greater than {0}", compareTo ),
        _S( "{{0}} is less than or equal to {0}", compareTo ),
        _S( "{{0}} must be greater than {0}", compareTo )
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
IEnumerable< IRType< object > >
Components
{
    get
    {
        return
            base.Components
            .Append( new GTE( this.CompareTo ) )
            .Append( new NEQ( this.CompareTo ) );
    }
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
