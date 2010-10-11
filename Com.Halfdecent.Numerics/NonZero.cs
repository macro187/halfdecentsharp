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


using SCG = System.Collections.Generic;
using Com.Halfdecent;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Numerics
{


// =============================================================================
/// RType: Not zero
// =============================================================================

public sealed class
NonZero
    : SimpleTextRTypeBase< IReal >
{



// -----------------------------------------------------------------------------
// Static
// -----------------------------------------------------------------------------

public static
    void
Require(
    IReal item,
    Value itemReference
)
{
    ((IRType< IReal >)Create()).Require( item, itemReference );
}


public static
    NonZero
Create()
{
    return instance;
}


private static
    NonZero
instance = new NonZero();


private static
    IRType< IReal >[]
components = new IRType< IReal >[] {
    NEQ.Create( Real.From( 0 ) )
};



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
NonZero()
    : base(
        _S("{0} is not zero"),
        _S("{0} is zero"),
        _S("{0} must not be zero") )
{
}



// -----------------------------------------------------------------------------
// RTypeBase< IReal >
// -----------------------------------------------------------------------------

public override
    SCG.IEnumerable< IRType< IReal > >
GetComponents()
{
    return components;
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( typeof( NonZero ), s, args ); }

} // type
} // namespace

