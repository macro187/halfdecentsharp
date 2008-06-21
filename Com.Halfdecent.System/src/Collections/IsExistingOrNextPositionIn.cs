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
using SCG = System.Collections.Generic;
using Com.Halfdecent.Globalization;
using Com.Halfdecent.System;
using Com.Halfdecent.Predicates;
using Com.Halfdecent.Numerics;


namespace
Com.Halfdecent.Collections
{




/// Predicate: "... is the position of an existing item, or the position
/// following the last item"
///
public class
IsExistingOrNextPositionIn<
    TListItem   ///< Type of items in the list to check against
>
    : PredicateBase< Integer >
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialise a new <tt>IsExistingPositionIn< T ></tt> checking against
/// a given <tt>IList< T ></tt>
///
public
IsExistingOrNextPositionIn(
    IList< TListItem > list ///< The list to check against
                            ///
                            ///  Requirements:
                            ///  - Really <tt>IsPresent< T ></tt>
)
{
    new IsPresent< IList< TListItem > >().ReallyRequire( list );
    this.list = list;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// The list to check against
///
public
IList< TListItem >
List
{
    get { return this.list; }
}

private
IList< TListItem >
list;




// -----------------------------------------------------------------------------
// PredicateBase< T >
// -----------------------------------------------------------------------------

override internal
SCG.IEnumerable< IPredicate< Integer > >
GetTermRequirements()
{
    yield return new IsPresent< Integer >();
}



override internal
SCG.IEnumerable< IPredicate< Integer > >
GetComponents()
{
    yield return new IsNotNegative< Integer >();
    yield return new IsLTE< Integer >( this.List.Count );
}




// -----------------------------------------------------------------------------
// IPredicate
// -----------------------------------------------------------------------------

/// (see <tt>IPredicate.SayConforms()</tt>)
///
override public
Localized< string >
SayConforms(
    Localized< string > termIdentifier
)
{
    new IsPresent< Localized< string > >().ReallyRequire( termIdentifier );
    return _S(
        "{0} is the position of an existing item or the position following the last item",
        termIdentifier );
}



/// (see <tt>IPredicate.SayDoesNotConform()</tt>)
///
override public
Localized< string >
SayDoesNotConform(
    Localized< string > termIdentifier
)
{
    new IsPresent< Localized< string > >().ReallyRequire( termIdentifier );
    return _S(
        "{0} is not the position of an existing item or the position following the last item",
        termIdentifier );
}



/// (see <tt>IPredicate.SayRequirement()</tt>)
///
override public
Localized< string >
SayRequirement(
    Localized< string > termIdentifier
)
{
    new IsPresent< Localized< string > >().ReallyRequire( termIdentifier );
    return _S(
        "{0} must be the position of an existing item or the position following the last item",
        termIdentifier );
}




private static Com.Halfdecent.Globalization.Localized< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

