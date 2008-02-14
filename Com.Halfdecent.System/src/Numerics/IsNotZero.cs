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
using Com.Halfdecent.System;
using Com.Halfdecent.Predicates;
using Com.Halfdecent.Globalization;
using Com.Halfdecent.Resources;


namespace
Com.Halfdecent.Numerics
{




/// Predicate: "(Real) is not zero"
///
public class
IsNotZero
    : PredicateBase< Real >
{



/// (see IPredicate< T >.Demand())
override public
void
Demand(
    Real term   ///< - Must be present
)
{
    new IsPresent().BugDemand( term );
    if( term == Real.From( 0 ) ) throw new PredicateValueException( this );
}



/// (see Predicate.SayConforms())
override public
Localized< string >
SayConforms(
    Localized< string > termIdentifier
)
{
    new IsPresent().BugDemand( termIdentifier );
    return Resource._S( "{0} is not zero", termIdentifier );
}



/// (see Predicate.SayDoesNotConform())
override public
Localized< string >
SayDoesNotConform(
    Localized< string > termIdentifier
)
{
    new IsPresent().BugDemand( termIdentifier );
    return Resource._S( "{0} is zero", termIdentifier );
}



/// (see Predicate.Demand)
override public
Localized< string >
SayDemand(
    Localized< string > termIdentifier
)
{
    new IsPresent().BugDemand( termIdentifier );
    return Resource._S( "{0} must not be zero", termIdentifier );
}




} // type
} // namespace

