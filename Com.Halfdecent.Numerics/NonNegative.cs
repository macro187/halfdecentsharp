// -----------------------------------------------------------------------------
// Copyright (c) 2009
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
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Numerics
{


public class
NonNegative
    : SimpleTextRTypeBase< IReal >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
NonNegative()
    : base(
        _S("{0} is not negative"),
        _S("{0} is negative"),
        _S("{0} must not be negative") )
{
}



// -----------------------------------------------------------------------------
// RTypeBase< IReal >
// -----------------------------------------------------------------------------

public override
    SCG.IEnumerable< IRType< IReal > >
GetComponents()
{
    return
        base.GetComponents()
        .Append(
            new GTE< IReal >(
                Real.From( 0m ),
                new ComparableComparer< IReal >() ) );
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

