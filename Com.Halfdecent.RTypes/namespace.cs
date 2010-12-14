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
///         (e.g. <tt>ArgumentNullException</tt> vs. <tt>ArgumentException</tt>)
///
///     -   Failure exceptions may or may not carry the
///         <tt>System.Exception.Source</tt> reference to the problematic value,
///         and even if they do, it's just a free-form string
///
///     -   In the non-specific failure exception case, specific messaging may
///         or may not be specified
///
///     -   ...and if it is, it's re-written each time, usually inconsistently
///
///     -   Overall, the repetition and inconsistency of the messaging makes it
///         more work to localise
///
///     -   Failure exceptions only provide a message stating that the condition
///         was not met (e.g. "The value was not valid").  Other kinds of
///         messaging would be useful.  For example, language saying that the
///         condition <em>was</em> met (e.g. "The value was valid"), or language
///         <em>requesting</em> that a condition be met (e.g.  "The value must
///         be valid").
///
///
/// @section solution Solution
///
///     -   RTypes (<tt>RType</tt> and <tt>RType<T></tt>), reusable,
///         composable units of value checking logic and associated messaging
///
///     -   Base classes for implementing rtypes:  <tt>RTypeBase<T></tt>,
///         <tt>SimpleTextRTypeBase<T></tt>
///
///     -   <tt>RTypeException</tt>, the exception that results when rtype
///         checks fail.  The exception carries an exact reference to the
///         problematic value.  It also carries a reference to the exact
///         <tt>RType</tt> representing the failed condition.  Composite rtype
///         structure is reflected in the <tt>InnerException</tt> chain,
///         allowing drill-down to the exact reason for the failure.
///
///     -   A suite of drop-in rtype replacements for common value checks:
///         <tt>NonNull</tt>, <tt>NonBlankString</tt>, <tt>NEQ<T></tt>,
///         <tt>LT<T></tt>, <tt>LTE<T></tt>, <tt>GT<T></tt>, <tt>GTE<T></tt>,
///         and <tt>InInterval<T></tt>.
///
///
/// @section discussion Discussion
///
///     An rtype is a logical predicate <sup>[1]</sup> restricting the set of
///     values of some static type, effectively acting as a runtime-only subtype
///     <sup>[2]</sup>.  Hence the name "rtype".
///
///     The motivation behind RTypes is not just to clean up how argument
///     checking is done.  It's larger than that.  It's an attempt to allow
///     programmers to think of more problems as type problems than .NET's
///     static type system allows, by emulating a kind of "dependent types with
///     multiple inheritance" <sup>[3] [4]</sup>.  We're taking those procedural
///     checks, reifying them into reusable, composable units, and using them in
///     a declarative way that feels almost like an extension of the static type
///     system.
///
///     For example, instead of separately thinking:
///
///     -   I have a parameter called "foo" of type integer
///     -   (some other stuff)
///     -   I need some code to check that foo is greater than 5
///     -   I need some code check that foo is less than 10
///
///     ...the programmer can think more like:
///
///     -   I have parameter called "foo" of type "Integer Between 5 and 10"
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
Com.Halfdecent.RTypes
{
}

