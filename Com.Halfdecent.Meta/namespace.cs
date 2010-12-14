// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2010
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
/// Programming language elements
///
///
/// @section problem Problem
///
///     There is no good way to refer to values.  For example, how do we say
///     "The value of the 'Foo' property of the 'Bar' parameter of this frame"?
///
///     %This causes difficulties especially with exceptions because there is no
///     way for them to carry exact references to the values that they indicate
///     problems with.
///
///     The only indicator currently available is
///     <tt>System.ArgumentException.ParamName</tt> which is:
///
///     -   Optional
///     -   Weakly-typed, ie. just a string
///     -   Meaningless more than one frame up the call stack
///
///
/// @section solution Solution
///
///     -   An object model for describing parts of references to values:
///         <tt>Machine</tt>, <tt>Process</tt>, <tt>Thread</tt>, <tt>Frame</tt>,
///         <tt>Literal</tt>, <tt>Parameter</tt>, <tt>Local</tt>, <tt>This</tt>,
///         <tt>Property</tt>, <tt>Indexer</tt>
///
///     -   <tt>ValueReference</tt>, an exact globally-unique "path" to a value
///         expressed using the above parts
///
///     -   <tt>ValueReferenceException</tt>, an exception containing a
///         <tt>ValueReference</tt> to the problematic value indicated by its
///         <tt>.InnerException</tt>
///
///     -   <tt>ValueReferenceException.Map()</tt> and friends, mechanisms for
///         mapping the meaning of <tt>ValueReferenceException</tt>s as they
///         move up the stack
///
///     -   <tt>IValueException</tt>, an exception representing a problem
///         with a particular value and able to describe that problem in terms
///         of a natural-language description of that problematic value
///
///     -   Versions of some BCL exceptions that implement
///         <tt>IValueException</tt>: <tt>IValueException</tt>,
///         <tt>ValueException</tt>, <tt>ValueArgumentException</tt>,
///         <tt>ValueArgumentNullException</tt>, and
///         <tt>ValueArgumentOutOfRangeException</tt>.
///
///
// =============================================================================

namespace
Com.Halfdecent.Meta
{
}

