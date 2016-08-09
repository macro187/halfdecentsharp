// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010
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



// =============================================================================
/// Composable value conditions and checking
///
///
/// @section problem Problem
///
///     When it comes to checking conditions of values like method parameters at
///     runtime, the current situation is a disaster:
///
///     -   Condition-checking logic is re-written each time, often
///         inconsistently
///
///     -   Conditions only ever become "tangible" after they fail, in the form
///         of exceptions.  There are no entities representing the conditions
///         themselves that could be passed around ahead of time and used, for
///         example, by user-interfaces to do input field validation.
///
///     -   Failure exceptions may or may not be specific to the check, making
///         it difficult to tell programatically exactly what the problem was
///
///     -   If the exception is not specific to the check, it may or may not
///         include specific messaging
///
///     -   ...re-written at each check, leading to inconsistency
///
///     -   ...and more localisation work
///
///     -   Failure exceptions only provide a message stating that the condition
///         was not met (e.g. "The value was not valid").  Other kinds of
///         messaging would be useful.  For example, language saying that the
///         condition <em>was</em> met (e.g. "The value was valid"), or language
///         <em>requesting</em> that a condition be met (e.g.  "The value must
///         be valid").
///
///     -   At first glance, <tt>System.Exception.Source</tt> may sound like
///         a potentially-useful reference to the problematic value, but it's
///         not, it's just a reference to the assembly where the exception
///         originated
///
///
/// @section solution Solution
///
///     -   <tt>RType</tt> / <tt>RType<T></tt>, reusable units of value
///         checking logic plus associated natural language messaging
///
///     -   <tt>CompositeRType<T></tt>, a new RType composed of one or more
///         other RTypes in a logical conjunction ("and")
///
///     -   <tt>MemberRType<T,TMember></tt>, a new RType representing the
///         application of another RType to a particular member
///
///     -   <tt>RTypeException</tt>, the exception that occurs when an RType
///         check fails.  Carries a reference to the exact failed
///         <tt>RType</tt>.  Furthermore, the structure of failed composite
///         RTypes is reflected in the <tt>InnerException</tt> chain, with inner
///         RTypeExceptions -- recursive if necessary -- leading to the exact
///         component RType that failed.  A reference to the exact value that
///         failed the check is communicated through the
///         <tt>Halfdecent.Meta.ValueReferenceException</tt> mechanism.
///
///     -   A suite of drop-in rtype replacements for common value checks:
///         <tt>EQ<T></tt>, <tt>NEQ<T></tt>, <tt>NonNull</tt>,
///         <tt>NonBlankString</tt>, <tt>LT<T></tt>, <tt>LTE<T></tt>,
///         <tt>GT<T></tt>, <tt>GTE<T></tt>, and <tt>InInterval<T></tt>.
///
///
/// @section discussion Discussion
///
///     An rtype is a logical predicate <sup>[1]</sup> restricting the set of
///     values of some static type, effectively acting as a runtime-only subtype
///     <sup>[2]</sup>.  Hence the name "rtype".
///
///     From the programmer's perspective, the RType mechanism should feel
///     almost declarative, like an extension of the static type system.  It
///     should permit programmers to think of more problems as type problems
///     than .NET's static type system allows, by emulating a kind of "dependent
///     types with multiple inheritance" <sup>[3] [4]</sup>.
///
///     For example, instead of separately thinking:
///
///         -   Parameter "foo" of type integer
///         -   (...)
///         -   Check that foo is greater than 5
///         -   Check that foo is less than 10
///
///     ...the programmer can just think:
///
///         -   Parameter "foo" of type "integer between 5 and 10"
///
///
/// @section notes Notes
///
///     <sup>1</sup>
///     "Predicate (mathematical logic)",
///     <tt>http://en.wikipedia.org/wiki/Predicate_%28mathematical_logic%29</tt>
///
///     <sup>2</sup>
///     "Subtype polymorphism",
///     <tt>http://en.wikipedia.org/wiki/Subtype</tt>
///
///     <sup>3</sup>
///     "Dependent type",
///     <tt>http://en.wikipedia.org/wiki/Dependent_type</tt>
///
///     <sup>4</sup>
///     "Multiple inheritance",
///     <tt>http://en.wikipedia.org/wiki/Multiple_inheritance</tt>
///
///
// =============================================================================

namespace
Halfdecent.RTypes
{
}

