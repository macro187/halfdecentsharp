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
IsA<
    T,
    TIsA
>
    : SimpleRTypeBase< T >
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
IsA()
    : base(
        LocalisedString.Format(
            _S("{{0}} is a {0}"),
            typeof( TIsA ).FullName ),
        LocalisedString.Format(
            _S("{{0}} is not a {0}"),
            typeof( TIsA ).FullName ),
        LocalisedString.Format(
            _S("{{0}} must be a {0}"),
            typeof( TIsA ).FullName )
    )
{
}




// -----------------------------------------------------------------------------
// RTypeBase< T >
// -----------------------------------------------------------------------------

protected override
bool
MyCheck(
    T item
)
{
    return item == null ? true : ( item is TIsA );
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // IsA< T >




public static class
IsA
{

public static
void
SCheck<
    T,
    TIsA
>(
    T       item,
    IValue  itemReference
)
{
    new IsA< T, TIsA >().Check( item, itemReference );
}

} // IsA




} // namespace

