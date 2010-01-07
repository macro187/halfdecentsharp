// -----------------------------------------------------------------------------
// Copyright (c) 2009
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
/// System-level enhancements
///
/// @section abstract_types Abstract Types
///
///     http://en.wikipedia.org/wiki/Abstract_type
///
///
/// @section abstract_type_pattern Abstract Type Pattern
///
///     eg. <tt>TheType<T></tt>
///
///
///     @subsection the_type The Type
///
///         <tt>interface ITheType<T></tt>
///
///         <tt>ITheType_T.cs</tt>
///
///         The public members of the abstract type, declared in terms of this
///         interface (no implementation classes).
///
///         This is what client code uses to declare variables, parameters,
///         properties, return types, etc.
///
///
///     @subsection abstract_operations Abstract Operations
///
///         <tt>static class TheType</tt>
///
///         <tt>TheType.cs</tt>
///
///         Abstract operations against ITheType<T> (no implementation
///         classes).  Constants, static methods, and extension methods.
///
///         Present if there are any abstract operations.
///
///         Combined with the "Default Implementation" class below if the type
///         is not generic (because the name ends up the same).
///
///
///     @subsection comparer Comparer
///
///         <tt>class TheTypeComparer<T></tt>
///
///         <tt>TheTypeComparer_T.cs</tt>
///
///         Present if the abstract type introduces it's own kind of equality.
///
///         Implements IEqualityComparer<ITheType<T>> in terms of
///         ITheType<T>.Equals( ITheType<T> ) and ITheType<T>.GetHashCode()
///         (see "Equality" section below).
///
///         Implements IComparer<ITheType<T>> if the abstract type is
///         orderable.
///
///
///     @subsection default_implmentation Default Implementation
///
///         <tt>class TheType<T></tt>
///
///         <tt>TheType_T.cs</tt>
///
///         Default implementation of ITheType<T>.
///
///         Present if applicable.
///
///         Combined with the "Abstract Operations" class above if the type is
///         not generic (because the name ends up the same).
///
///
///     @subsection base_class Base Class
///
///         <tt>abstract class TheTypeBase<T></tt>
///
///         <tt>TheTypeBase_T.cs</tt>
///
///         Base class to assist in implementing ITheType<T>.
///
///         Present if applicable.
///
///
/// @section equality Equality
///
///     @subsection insufficient The Usual Equality Patterns Are Insufficient
///
///         The <tt>==</tt> and <tt>!=</tt> C# operators are useless for the
///         same reason all operators are:  They can't apply to interfaces.
///
///         <tt>System.Object.Equals()</tt> and
///         <tt>System.Object.GetHashCode()</tt> aren't good enough because
///         they allow for only one definition of equality per class when
///         classes can implement any number of interfaces, each, possibly,
///         with it's own definition of equality.
///
///         <tt>System.Collections.Generic.IEquatable<T></tt> is insufficient
///         because, while it allows for multiple definitions of equality per
///         class, it doesn't similarly allow for matching
///         <tt>GetHashCode()</tt> definitions that are required. <sup>1</sup>
///         In fact, implementing
///         <tt>System.Collections.Generic.IEquatable<T></tt> makes matters
///         worse by making it easier to accidentally use mismatched
///         <tt>Equals()</tt> and <tt>GetHashCode()</tt> implementations
///         together, for example via the default Base Class Library
///         collections equality comparer which uses
///         <tt>System.Collections.Generic.IEquatable<T>.Equals()</tt> (if
///         available) with <tt>System.Object.GetHashCode()</tt> <sup>2</sup>.
///
///         Common equality <em>implementations</em> are also often not
///         suitable for abstract types, as they often involve the unnecessary
///         requirement that both items be of the exact same class to be
///         considered equal (for example, <tt>a.GetType() == b.GetType()</tt>
///         or similar).  This precludes objects of unrelated classes from ever
///         being equal even if both are semantically equal under a
///         commonly-implemented interface.  Furthermore, relying on both
///         objects' being of the same class creates an artificial guarantee
///         that they share the same <tt>.Equals()</tt> implementation, which
///         shields from the reality that equality is not a one-sided
///         operation; It requires agreement by both objects that they are
///         equal to each other.
///
///         <small>
///         <sup>1</sup> For a detailed explanation of the connection between
///         <tt>GetHashCode()</tt> and <tt>Equals()</tt>, consult the
///         <tt>System.Object.GetHashCode()</tt> section of your Base Class
///         Library documentation
///         </small>
///
///         <small>
///         <sup>2</sup> <tt>System.Collections.Generic.IEquatable<T></tt>
///         doesn't provide <tt>GetHashCode()</tt> so, presumably, the
///         <tt>System.Object.GetHashCode()</tt> implementation is used.  Check
///         your Base Class Library's documentation (or, better yet, it's
///         source code) to determine the exact behaviour.
///         </small>
///
///
///     @subsection pattern Equality Pattern for Abstract Types
///
///         This library provides <tt>Com.Halfdecent.IEquatable<T></tt>, which
///         addresses the above issues.  It defines a unidirectional equality
///         checking method for implementers to override, a matching
///         <tt>GetHashCode()</tt>, and an <tt>Equals()</tt> that gives both
///         objects their say in whether they are equal or not.
///
///         TODO: Introduce <tt>IEqualityComparer<T></tt> and friends
///
///         TODO: What's the pattern for object.Equals() and
///         object.GetHashCode()?  Leave as default?  Always false?
///         InvalidOperationException (or similar)?
///
// =============================================================================

namespace
Com.Halfdecent
{
}

