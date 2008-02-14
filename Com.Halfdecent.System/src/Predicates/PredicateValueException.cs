// -----------------------------------------------------------------------------
// Copyright (c) 2007 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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
using R = Com.Halfdecent.Resources.Resource;


namespace
Com.Halfdecent.Predicates
{




/// Exception indicating that some object's value is invalid due to having
/// failed to conform to a predicate
///
public class
PredicateValueException
    : ValueException
{




/// Initialise a new <tt>PredicateValueException</tt> resulting from some value
/// failing to conform to a given <tt>IPredicate</tt>
///
public
PredicateValueException(
    IPredicate  predicate
)
    : this( predicate, null )
{
}



/// Initialise a new <tt>PredicateValueException</tt> resulting from some value
/// failing to conform to a given <tt>IPredicate</tt>, and reference to the
/// inner <tt>Exception</tt> that is the cause of this exception.
///
public
PredicateValueException(
    IPredicate  predicate,
    Exception   innerException
)
    : base( innerException )
{
    new IsNotNull().BugDemand( predicate );
    this.predicate = predicate;
}



/// The <tt>IPredicate</tt> that the value failed to conform to which lead to
/// this exception
///
public
IPredicate
Predicate
{
    get { return this.predicate; }
}

private
IPredicate
predicate;



/// (see <tt>ValueException.SayProblem()</tt>)
override public
Localized< string >
SayProblem(
    Localized< string > valueIdentifier
)
{
    new IsNotNull().BugDemand( valueIdentifier );
    return this.Predicate.SayDoesNotConform( valueIdentifier );
}




} // type
} // namespace

