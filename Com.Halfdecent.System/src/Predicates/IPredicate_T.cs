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


namespace
Com.Halfdecent.Predicates
{




/// A predicate applying to terms of a particular type
///
public interface
IPredicate<
    T   ///< The type of term the predicate applies to
>
    : IPredicate
{



/// Evaluate the predicate against a term
///
bool        /// @returns Whether the predicate is true of the given term
Evaluate
(
    T term  ///< The term
);



/// Demand that a term conform to the predicate
///
/// @exception PredicateValueException
/// If the term does not conform to the predicate
///
void
Demand
(
    T term  ///< The term
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
    T term  ///< The term
);




} // type
} // namespace

