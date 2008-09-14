// -----------------------------------------------------------------------------
// Copyright (c) 2008 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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
/// RType: A value that is greater than or equal to some other constant value
///
/// According to <tt>IComparable< T >.CompareTo()</tt>
// =============================================================================
//
public class
GTE<
    T
>
    : SimpleRTypeBase< IComparable< T > >
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
GTE(
    T compareAgainst
)
    : base(
        _S( "{{0}} is {0} or greater", compareAgainst ),
        _S( "{{0}} is less than {0}", compareAgainst ),
        _S( "{{0}} must be {0} or greater", compareAgainst )
    )
{
    new NonNull().Check( compareAgainst, new Parameter( "compareAgainst" ) );
    this.compareagainst = compareAgainst;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// The value to compare against
public
T
CompareAgainst
{
    get { return this.compareagainst; }
}

private
T
compareagainst;




// -----------------------------------------------------------------------------
// RTypeBase< T >
// -----------------------------------------------------------------------------

protected override
bool
MyCheck(
    IComparable< T > item
)
{
    if( item == null ) return true;
    return item.CompareTo( this.CompareAgainst ) >= 0;
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

