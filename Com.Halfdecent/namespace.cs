// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010
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
/// Enhancements to the BCL's <tt>System</tt> namespace
///
///
/// @section tuples Tuples
///
///     @subsection problems Problems
///
///         -   No tuples in BCL prior to .NET 4.0
///         -   BCL tuples aren't abstract
///         -   BCL tuples are classes, which incur runtime allocation and GC
///             overhead and may not be suitable in performance-sensitive
///             situations
///
///     @subsection solution Solution
///
///         -   Abstract type: <tt>ITuple<T1,T2></tt>
///         -   Abstract operations: <tt>Tuple</tt>
///         -   Struct-based implementation: <tt>Tuple<T1,T2></tt>
///         -   Interoperability with BCL tuples:
///             <tt>SystemTuple.AsHalfdecentTuple<T1,T2>()</tt> and
///             <tt>Tuple.AsSystemTuple<T1,T2>()</tt>
///
///
/// @section intervals Intervals
///
///     @subsection problems Problems
///
///         -   No intervals in BCL
///
///     @subsection solution Solution
///
///         -   Abstract type: <tt>IInterval<T></tt>
///         -   Abstract operations: <tt>Interval</tt>
///         -   Implementation: <tt>Interval<T></tt>
///
///
/// @section comparison Comparison
///
///     @subsection problems Problems
///
///         Existing comparison patterns do not adequately support abstract
///         types and suffer from other design shortcomings.
///
///         -   C# comparison operators (<tt>==, !=, <, ></tt> and friends)
///             aren't suitable for abstract types because they don't work on
///             interfaces.
///
///         -   <tt>System.Object.Equals()</tt> and
///             <tt>System.Object.GetHashCode()</tt> aren't suitable for
///             abstract types because they allow only one kind of comparison
///             per concrete class when classes may implement any number of
///             abstract types, each, possibly, with its own kind of comparison.
///
///         -   <tt>System.IEquatable<T></tt> and <tt>System.IComparable<T></tt>
///             aren't suitable for abstract types because, while they permit
///             more than one kind of comparison per class, they don't similarly
///             allow for the multiple matching hash code implementations that
///             are required. <sup>1</sup>
///
///         -   In all of the existing mechanisms, only one of the two items'
///             comparison implementations is consulted.  This is a problem
///             because the other item's implementation may be more precise,
///             resulting in a situation where getting the correct result
///             depends on which of the two items' comparion methods is called.
///             Knowing which item has the more specific comparison is
///             impossible, except in the unlikely case that both items' exact
///             runtime types are known.
///
///         -   <tt>System.Collections.Generic.IComparer<T></tt> does not imply
///             <tt>System.Collections.Generic.IEqulityComparer<T></tt> even
///             though its functionality is a superset.
///
///         -   The BCL comparers are not themselves equatable, so you cannot
///             determine whether two comparers represent the same kind of
///             comparison.
///
///         -   <tt>System.Collections.Generic.Comparer<T></tt> provides no
///             support for creating ad hoc comparers out of <tt>.Equals()</tt>
///             and <tt>.GetHashCode()</tt> delegates.
///
///         <small>
///         <sup>1</sup> For a detailed explanation of the connection between
///         <tt>GetHashCode()</tt> and <tt>Equals()</tt>, consult the
///         <tt>System.Object.GetHashCode()</tt> section of your Base Class
///         Library documentation
///         </small>
///
///
///     @subsection solution Solution
///
///         Replacement comparison patterns and types that allow correct
///         comparison implementations for abstract types.
///
///         -   Replacement <tt>IEquatable<T></tt> interface defines an
///             <tt>IEquatable<T>.GetHashCode()</tt> to go with
///             <tt>IEquatable<T>.Equals()</tt>.
///
///         -   Replacement <tt>IEquatable<T></tt> and <tt>IComparable<T></tt>
///             interfaces define directional comparison methods which are
///             called on both items during comparison in such a way that the
///             most precise (and therefore correct) result is always obtained.
///
///         -   <tt>ComparisonDisagreementException</tt>, an exception
///             indicating that the two directional comparisons involved in a
///             comparison were in complete disagreement, indicating a bug in
///             one or both.
///
///         -   <tt>Comparable</tt>, an extension methods library for
///             <tt>IComparable<T></tt> providing convenience methods such as
///             <tt>Comparable.GT()</tt>, <tt>Comparable.LT()</tt>, etc.
///
///         -   Replacement <tt>IEqualityComparer<T></tt> and
///             <tt>IComparer<T></tt>, with the latter implying the former.
///
///         -   Replacement <tt>IEqualityComparer<T></tt> and
///             <tt>IComparer<T></tt> are themselves equatable.
///
///         -   Replacement <tt>Comparer<T></tt> which supports ad hoc comparers
///             made from <tt>.Equals()</tt> and <tt>.GetHashCode()</tt>
///             delegates.
///
///         -   <tt>ObjectComparer</tt>, an interop equality comparer that just
///             uses <tt>object.Equals()</tt> and,<tt>object.GetHashCode()</tt>.
///
///         -   TODO: <tt>System.Object.Equals()</tt> and
///             <tt>System.Object.GetHashCode()</tt> are effectively obsolete.
///             What should the pattern be for them?  Leave as default?  Throw
///             an exception?
///
///
/// @section abstracttypes Abstract Types
///
///     TODO:
///
///     This library establishes a pattern for defining abstract types in
///     C#.
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
///     @subsection abstract_operations Abstract Operations
///
///         TODO:
///         Explain why abstract operations should use constrained
///         generic types instead of interface types directly.
///         Constrained generic types use constrained virtcall which
///         avoids boxing overhead if T is a value type.
///
///
// =============================================================================

namespace
Com.Halfdecent
{
}

