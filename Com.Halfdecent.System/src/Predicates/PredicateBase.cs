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
using Com.Halfdecent.Globalization;
using Com.Halfdecent.Resources;


namespace
Com.Halfdecent.Predicates
{




/// Predicate base class
///
public abstract class
PredicateBase<
    T
>
    : IPredicate< T >
{



/// (see IPredicate< T >.Evaluate())
public
bool
Evaluate(
    T term
)
{
    bool r = true;
    try {
        this.Demand( term );
    } catch( PredicateValueException ) {
        r = false;
    }
    return r;
}



/// (see IPredicate< T >.BugDemand())
public
void
BugDemand(
    T term
)
{
    try {
        this.Demand( term );
    } catch( PredicateValueException e ) {
        throw new BugException( e );
    }
}



/// (see IPredicate< T >.Demand())
abstract public
void
Demand(
    T term
);



/// (see IPredicate.SayConforms())
abstract public
Localized< string >
SayConforms(
    Localized< string > termIdentifier
);



/// (see IPredicate.SayDoesNotConform())
abstract public
Localized< string >
SayDoesNotConform(
    Localized< string > termIdentifier
);



/// (see IPredicate.SayDemand)
abstract public
Localized< string >
SayDemand(
    Localized< string > termIdentifier
);




} // type
} // namespace

