// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010, 2011, 2012
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
/// Enhancements to the BCL's `System` namespace
///
///
/// Tuples
/// ======
///
/// Problems
/// --------
///
/// - No tuples in BCL prior to .NET 4.0
/// - No abstract tuples in BCL
/// - BCL tuple implementations are classes, which incur runtime allocation
///     and GC overhead and therefore may not be suitable in
///     performance-sensitive situations
///
/// Solution
/// --------
///
/// -   Abstract type: `ITupleHD<T1,T2>`
/// -   Abstract operations: `TupleHD`
/// -   Struct-based implementation: `TupleHD<T1,T2>`
/// -   Interoperability with BCL tuples:
///     `SystemTuple.AsTupleHD<T1,T2>()` and
///     `TupleHD.AsTuple<T1,T2>()`
///
///
/// Intervals
/// =========
///
/// Problems
/// --------
///
/// -   No intervals in BCL
///
/// Solution
/// --------
///
/// -   Abstract type: `IInterval<T>`
/// -   Abstract operations: `Interval`
/// -   Implementation: `Interval<T>`
///
///
/// Comparison
/// ==========
///
/// Problems
/// --------
///
/// Existing comparison mechanisms have a number of shortcomings, especially
/// when abstract types and/or subtypes are involved.
///
/// -   C# operators (`==`, `!=`, `<`, `>` and friends) don't work on abstract
///     types.
///
/// -   `System.Object.Equals()` is untyped.
///
/// -   The combination of `System.Object.Equals()` and
///     `System.Object.GetHashCode()` allows for only one kind of comparison per
///     concrete class, but classes may implement any number of abstract types,
///     each, possibly, with their own kind of comparison.
///
/// -   `System.IComparable<T>` doesn't imply `System.IEquatable<T>`.  Wrong
///     because if something can be compared, it can be tested for equality.
///
/// -   Neither `System.IEquatable<T>` nor `System.IComparable<T>` include
///     `GetHashCode()` to match their definitions of equality / comparison.
///     <sup>1</sup>
///
/// -   Normally, `System.IEquatable<T>` and `System.IComparable<T>` are used in
///     a unidirectional fashion where, of the two items being compared, only
///     one's `.Equals()` or `.CompareTo()` is called.  This is a problem
///     because one or the other may be more precise, and there's no way to know
///     which (without resorting to examination and analysis of the two objects
///     at runtime).
///
/// -   `System.Collections.Generic.IComparer<T>` doesn't imply
///     `System.Collections.Generic.IEqualityComparer<T>`.  Wrong because if
///     something can compare, it can test for equality.
///
/// -   `System.Collections.Generic.IComparer<T>` does not include a
///     `GetHashCode()` to match its comparison.
///
/// -   `System.Collections.Generic.EqualityComparer<T>` and
///     `System.Collections.Generic.Comparer<T>` provide no support for creating
///     comparers on-the-fly out of functions.
///
/// <small>
/// <sup>1</sup> For a detailed explanation of the connection between
/// `GetHashCode()` and equality / comparison, consult the
/// `System.Object.GetHashCode()` section of your Base Class
/// Library documentation.
/// </small>
///
///
/// Solution
/// --------
///
/// Replacement comparison patterns and types that fix design flaws and work
/// correctly with abstract types and subtypes.
///
/// -   Delegate types for equality and comparison-related functions:
///     `EqualsFunc<T>`, `CompareFunc<T>`, and `GetHashCodeFunc<T>`
///
/// -   Equatable interface which includes a hash code method: `IEquatableHD<T>`
///
/// -   Comparable interface which implies equatability: `IComparableHD<T>`
///
/// -   Extension methods that perform bidirectional equality and comparisons:
///     `SystemEquatable.EqualsBidirectional()<T>` and
///     `SystemComparable.CompareToBidirectional()<T>`
///
/// -   Exception indicating that the two items' comparison implementations
///     completely disagreed, indicating a bug in one or both:
///     `ComparisonDisagreementException`
///
/// -   Convenient comparison extension methods for `System.IComparable<T>`:
///     `SystemComparable.GT()`, `SystemComparable.GTE()`,
///     `SystemComparable.LT()`, `SystemComparable.LTE()`
///
/// -   Comparer interface that implies equality comparer and hash code
///     functionality: IComparerHD<T>
///
/// -   Equality comparer made out of `.Equals()` and `.GetHashCode()`
///     functions: `EqualityComparerHD<T>`
///
/// -   Comparer (plus equality comparer) made out of `.CompareTo()` and
///     `.GetHashCode()` functions: `System.Collections.Generic.Comparer<T>`
///
///
/// Maybes
/// ======
///
/// Problems
/// --------
///
/// TODO
///
/// Solution
/// --------
///
/// TODO
///
///
/// Proxies
/// ======
///
/// Problems
/// --------
///
/// TODO
///
/// Solution
/// --------
///
/// TODO
///
///
/// Matching
/// ======
///
/// Problems
/// --------
///
/// TODO
///
/// Solution
/// --------
///
/// TODO
///
///
/// Use of Constrained Generic Types
/// ================================
///
/// TODO:
/// Explain why abstract operations should use constrained generic types instead
/// of interface types directly.  Constrained generic types use constrained
/// virtcall which avoids boxing overhead if T is a value type.
///
///
// =============================================================================

namespace
Com.Halfdecent
{
}

