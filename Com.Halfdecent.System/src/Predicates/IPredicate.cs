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
using Com.Halfdecent.Globalization;


namespace
Com.Halfdecent.Predicates
{




/// A logical predicate
///
/// In logic, a <em>term</em> is some particular item.  A <em>predicate</em>
/// is some condition of a term that may be true or false.
///
// XXX Right now, there is no distinction between ValueExceptions that result
//     from the Predicate itself, and those that result from other predicates
//     restricting it's input values.  Is that distinction needed?
public interface
IPredicate
{



/*
/// Evaluate the predicate against a term
///
bool    /// @returns Whether the predicate is true of the given term
Evaluate
(
    object term ///< The term
);


/// Demand that a term conform to the predicate
///
/// @exception PredicateValueException
/// If the term does not conform to the predicate
///
void
Demand
(
    object term ///< The term
);


/// Assert a term conform to the predicate, and furthermore, that if it does
/// not, it is as a result of a programming error
///
/// @exception BugException
/// If the term does not conform to the predicate
///
void
BugDemand
(
    object term ///< The term
);
*/



/// Generate a natural language statement that can be said of a term if it
/// conforms to this predicate
///
/// eg. "... is even"
/// eg. "... is a valid url"
/// eg. "... contains at least 3 items"
///
Localized< string >
SayConforms(
    Localized< string > termIdentifier  ///< Phrase identifying the term
);



/// Generate a natural language statement that can be said of a term if it
/// <em>does not</em> conform to this predicate
///
/// eg. "... is not even"
/// eg. "... is not a valid url"
/// eg. "... contains less than 3 items"
///
Localized< string >
SayDoesNotConform(
    Localized< string > termIdentifier  ///< Phrase identifying the term
);



/// Generate a natural language statement demanding a term conform to this
/// predicate
///
/// eg. "... must be even"
/// eg. "... must be a valid url"
/// eg. "... must contains at least 3 items"
///
Localized< string >
SayDemand(
    Localized< string > termIdentifier  ///< Phrase identifying the term
);




} // type
} // namespace

