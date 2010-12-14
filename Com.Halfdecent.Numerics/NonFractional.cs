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


using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Numerics
{


// =============================================================================
/// RType: Real with no fractional amount
// =============================================================================

public sealed class
NonFractional
    : RType< IReal >
{



// -----------------------------------------------------------------------------
// Static
// -----------------------------------------------------------------------------

public static
    void
CheckParameter(
    IReal   item,
    string  paramName
)
{
    ValueReferenceException.Map(
        r => r.Up().Parameter( paramName ),
        r => r.Down().Parameter( "item" ),
        () => Check( item ) );
}


public static new
    void
Check(
    IReal item
)
{
    ValueReferenceException.Map(
        r => r.Parameter( "item" ),
        r => r.Down().Parameter( "item" ),
        () => Create().Check( item ) );
}


public static
    RType< IReal >
Create()
{
    return instance;
}


private static
    NonFractional
instance = new NonFractional();



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
NonFractional()
    : base(
        item =>
            (object)item == null ||
            item.Equals( item.Truncate() ),
        r => _S("{0} is not fractional", r),
        r => _S("{0} is fractional", r),
        r => _S("{0} must not be fractional", r) )
{
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

