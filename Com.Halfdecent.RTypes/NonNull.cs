// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2010
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
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// RType: Not <tt>null</tt>
// =============================================================================

public sealed class
NonNull
    : SimpleTextRTypeBase< object >
{



// -----------------------------------------------------------------------------
// Static
// -----------------------------------------------------------------------------

public static
    void
Require(
    object  item,
    Value   itemReference
)
{
    ((IRType< object >)Create()).Require( item, itemReference );
}


public static
    IRType< object >
Create()
{
    return instance;
}


private static
    NonNull
instance = new NonNull();


private static
IRType< object >[]
components
= new IRType< object >[] {
    NEQ.Create( null, new ReferenceComparer() )
};



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
NonNull()
    : base(
        _S("{0} is non-null"),
        _S("{0} is null"),
        _S("{0} must not be null") )
{
}



// -----------------------------------------------------------------------------
// RType< object >
// -----------------------------------------------------------------------------

public override
    SCG.IEnumerable< IRType< object > >
GetComponents()
{
    return components;
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( typeof( NonNull ), s, args ); }

} // type
} // namespace

