// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010, 2011
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
///         -   No abstract tuples in BCL
///         -   BCL tuple implementations are classes, which incur runtime
///             allocation and GC overhead and therefore may not be suitable in
///             performance-sensitive situations
///
///     @subsection solution Solution
///
///         -   Abstract type: <tt>ITupleHD<T1,T2></tt>
///         -   Abstract operations: <tt>TupleHD</tt>
///         -   Struct-based implementation: <tt>TupleHD<T1,T2></tt>
///         -   Interoperability with BCL tuples:
///             <tt>SystemTuple.AsTupleHD<T1,T2>()</tt> and
///             <tt>TupleHD.AsTuple<T1,T2>()</tt>
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
///         Existing comparison mechanisms have a number of shortcomings,
///         especially when abstract types and/or subtypes are involved.
///
///         -   C# comparison operators (<tt>==, !=, <, ></tt> and friends)
///             don't work on abstract types.
///
///         -   <tt>System.Object.Equals()</tt> and
///             <tt>System.Object.GetHashCode()</tt> allow only one kind of
///             comparison per concrete class, but classes may implement any
///             number of abstract types, each, possibly, with their own kind of
///             comparison.
///
///         -   <tt>System.IEquatable<T></tt> doesn't include a
///             <tt>.GetHashCode()</tt> to match its <tt>.Equals()</tt>.
///             <sup>1</sup>
///
///         -   <tt>System.IComparable<T></tt> doesn't imply
///             <tt>System.IEquatable<T></tt>.
///
///         -   Normally, <tt>System.IEquatable<T></tt> and
///             <tt>System.IComparable<T></tt> are used in a unidirectional
///             fashion where, of the two items being compared, only one's
///             <tt>.Equals()</tt> or <tt>.CompareTo()</tt> is called.
///             This is a problem because one or the other may be more
///             precise, and there's no way to know which (without resorting to
///             examination and analysis of the two objects at runtime).
///
///         -   <tt>System.Collections.Generic.IComparer<T></tt> doesn't imply
///             <tt>System.Collections.Generic.IEqualityComparer<T></tt>.
///
///         -   <tt>System.Collections.Generic.EqualityComparer<T></tt> and
///             <tt>System.Collections.Generic.Comparer<T></tt> provide no
///             support for creating ad hoc comparers out of <tt>.Equals()</tt>,
///             <tt>CompareTo()</tt>, and <tt>.GetHashCode()</tt> delegates.
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
///         Replacement comparison patterns and types that fix design flaws and
///         work correctly with abstract types and subtypes.
///
///         -   <tt>EqualsFunc<T></tt>, <tt>CompareFunc<T></tt>, and
///             <tt>GetHashCodeFunc<T></tt> delegate types.
///
///         -   <tt>IEquatableHD<T></tt> interface which defines an
///             <tt>IEquatableHD<T>.GetHashCode()</tt> to go with the
///             <tt>IEquatable<T>.Equals()</tt>.
///
///         -   <tt>SystemEquatable.EqualsBidirectional()<T></tt> and
///             <tt>SystemComparable.CompareToBidirectional()<T></tt>
///             extension methods that perform bidirectional -- and therefore
///             correct -- comparisons.
///
///         -   <tt>ComparisonDisagreementException</tt>, an exception
///             indicating that the two comparisons involved in a bidirectional
///             comparison were in complete disagreement, indicating a bug in
///             one or both.
///
///         -   <tt>SystemComparable</tt>, an extension methods library for
///             <tt>IComparable<T></tt> providing convenience comparison methods
///             such as <tt>Comparable.GT()</tt>, <tt>Comparable.LT()</tt>, etc.
///
///         -   <tt>EqualityComparerHD<T></tt> made out of <tt>.Equals()</tt>
///             and <tt>.GetHashCode()</tt> functions.
///
///         -   <tt>ComparerHD<T></tt> made out of <tt>.CompareTo()</tt> and
///             <tt>.GetHashCode()</tt> functions.  Also serves as an equality
///             comparer, unlike
///             <tt>System.Collections.Generic.Comparer<T></tt>.
///
///
/// @section maybes Maybes
///
///     @subsection problems Problems
///
///         TODO
///
///     @subsection solution Solution
///
///         TODO
///
///
/// @section proxies Proxies
///
///     @subsection problems Problems
///
///         TODO
///
///     @subsection solution Solution
///
///         TODO
///
///
/// @section matching Matching
///
///     @subsection problems Problems
///
///         TODO
///
///     @subsection solution Solution
///
///         TODO
///
///
/// @section constrainedgenerictypes Use of Constrained Generic Types
///
///     TODO:
///     Explain why abstract operations should use constrained generic types
///     instead of interface types directly.  Constrained generic types use
///     constrained virtcall which avoids boxing overhead if T is a value type.
///
///
// =============================================================================

namespace
Com.Halfdecent
{
}

