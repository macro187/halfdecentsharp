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

using System.Collections.Generic;
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Meta;

namespace
Com.Halfdecent.RTypes
{

public class
NonBlankString
    : SimpleRTypeBase< string >
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
NonBlankString()
    : base(
        _S("{0} is not blank"),
        _S("{0} is blank"),
        _S("{0} must not be blank")
    )
{
}




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

public static
void
SCheck(
    object  item,
    IValue  itemReference
)
{
    INSTANCE.Check( item, itemReference );
}

private static readonly
NonBlankString
INSTANCE = new NonBlankString();




// -----------------------------------------------------------------------------
// RTypeBase< T >
// -----------------------------------------------------------------------------

protected override
bool
MyCheck(
    string item
)
{
    return item == null ? true : ( item != string.Empty );
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

