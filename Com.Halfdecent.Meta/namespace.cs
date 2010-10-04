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
///     We'd like an object model for modelling programming language elements
///     from the perspective of the average application programmer.  The Base
///     Class Library includes stuff like <tt>System.Reflection</tt> and
///     <tt>System.Linq.Expressions</tt>, but we're looking for something that
///     leaves out the intricacies of the CLR and focuses on how programmers
///     think.
///
///
/// @section solution Solution
///
///     -   An object model for describing the code elements that programmers
///         think about:  <tt>Parameter</tt>, <tt>Local</tt>, <tt>This</tt>,
///         <tt>Property</tt>, <tt>Indexer</tt>, etc.
///
///     -   Exceptions that refer to offending values using these strong types
///         rather than just strings:  <tt>IValueException</tt>,
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

