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
Com.Halfdecent.RTypes
{


// =============================================================================
/// Equal to a particular value
///
/// According to <tt>System.Object.Equals()</tt>
// =============================================================================

public class
EQ
    : SimpleTextRTypeBase< object >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
EQ(
    object compareTo
)
    : base(
        _S( "{{0}} is equal to {0}", compareTo ?? "null" ),
        _S( "{{0}} isn't equal to {0}", compareTo ?? "null" ),
        _S( "{{0}} must be equal to {0}", compareTo ?? "null" )
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
object
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
    return object.Equals(
        this.CompareTo,
        ((EQ)t).CompareTo );
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
    if( this.CompareTo == null ) return ( item == null );
    if( item == null ) return true;
    return this.CompareTo.Equals( item );
}



// -----------------------------------------------------------------------------
// object
// -----------------------------------------------------------------------------

public override
int
GetHashCode()
{
    return
        this.CompareTo == null ?
        base.GetHashCode() :
        base.GetHashCode() ^ this.CompareTo.GetHashCode();
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

