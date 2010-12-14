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
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// RType: A non-blank string
// =============================================================================

public sealed class
NonBlankString
    : SimpleTextRTypeBase< string >
{



// -----------------------------------------------------------------------------
// Static
// -----------------------------------------------------------------------------

public static
    void
Require(
    string  item,
    Value   itemReference
)
{
    ((IRType<string>)Create()).Require( item, itemReference );
}


public static
    IRType< string > 
Create()
{
    return instance;
}


private static
    NonBlankString
instance = new NonBlankString();


private static
    IRType< string >[]
components = new IRType< string >[] {
    NEQ.Create( string.Empty )
};



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
NonBlankString()
    : base(
        _S("{0} is not blank"),
        _S("{0} is blank"),
        _S("{0} must not be blank") )
{
}



// -----------------------------------------------------------------------------
// RTypeBase< string >
// -----------------------------------------------------------------------------

public override
    SCG.IEnumerable< IRType< string > >
GetComponents()
{
    return components;
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

