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
Com.Halfdecent.RTypes
{


// =============================================================================
/// Does not equal some constant value
///
/// According to <tt>IEquatable< T >.Equals()</tt>
// =============================================================================
//
public class
NEQ<
    T,
    U
>
    : SimpleRTypeBase< T >
    where T : IEquatable< U >
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
NEQ(
    U compareTo
)
    : base(
        _S( "{{0}} is not equal to {0}", compareTo ),
        _S( "{{0}} is equal to {0}", compareTo ),
        _S( "{{0}} must not be equal to {0}", compareTo )
    )
{
    NonNull.SCheck( compareTo, new Parameter( "compareTo" ) );
    this.compareto = compareTo;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// The value to compare to
public
U
CompareTo
{
    get { return this.compareto; }
}

private
U
compareto;




// -----------------------------------------------------------------------------
// RTypeBase< T >
// -----------------------------------------------------------------------------

protected override
bool
MyCheck(
    T item
)
{
    if( item == null ) return true;
    return !item.Equals( this.CompareTo );
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

