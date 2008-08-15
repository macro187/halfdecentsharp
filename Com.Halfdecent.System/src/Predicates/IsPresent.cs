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

using Com.Halfdecent.Globalisation;

namespace
Com.Halfdecent.Predicates
{



/// Predicate:  Is present (not <tt>null</tt>)
///
public class
IsPresent<
    T
>
    : IPredicate< T >
{




public
void
Require(
    T term
)
{
    if( term == null ) throw new PredicateValueException( this );
}



public
Localised< string >
SayIsTrueOf(
    Localised< string > termIdentifier
)
{
    return LocalisedString.Format(
        _S( "{0} is present" ),
        termIdentifier );
}



public
Localised< string >
SayIsFalseOf(
    Localised< string > termIdentifier
)
{
    return LocalisedString.Format(
        _S( "{0} is not present "),
        termIdentifier );
}



public
Localised< string >
SayIsRequiredOf(
    Localised< string > termIdentifier
)
{
    return LocalisedString.Format(
        _S( "{0} is required" ),
        termIdentifier );
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

