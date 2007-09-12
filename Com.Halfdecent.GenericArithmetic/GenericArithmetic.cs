// -----------------------------------------------------------------------------
// Copyright (c) 2007 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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



/// @mainpage Com.Halfdecent.GenericArithmetic
/// This assembly contains the Com.Halfdecent.GenericArithmetic namespace.



/// Half-decent generic arithmetic support
///
/// @par Introduction
/// The base class library's numeric types do not implement a common interface
/// supporting arithmetic operations, nor does C# provide any special
/// type parameter constraints that do the same.  The result is that it's
/// impossible to constrain generic type parameters to types supporting
/// arithmetic, and therefore impossible to write algorithms involving
/// arithmetic against objects whose type is a generic type parameter.
/// The GenericArithmetic namespace provides a workaround enabling generic
/// arithmetic.
///
/// @par Implementation
/// IArithmetic< T > defines generic arithmetic operations.  Various
/// <tt>struct</tt>s (Int32Arithmetic, Int64Arithmetic, etc.) provide
/// implementations for the various numeric types.  The static
/// <tt>Arithmetic.Get<T>()</tt> method provides appropriate IArithmetic< T >
/// implementations in a generic fashion based on a type parameter.  Finally,
/// the Arithmetic class provides convenient generic versions of all arithmetic
/// operations.
///
/// @par Generic Operations
/// The quickest and easiest way to perform generic arithmetic is to use the
/// generic static methods in the Arithmetic class:
/// @code
/// using Com.Halfdecent.GenericArithmetic;
///
/// // ...
///
/// T AddTen<T>( T to )
/// {
///     return Arithmetic.Add( to, Arithmetic.From<T>( 10 ) );
/// }
/// @endcode
///
/// @par IArithmetic
/// If you have a lot of arithmetic to do, it may be worth prefetching and
/// using a type-specific IArithmetic< T > implementation.  This will save you
/// having to pass generic parameters to operations such as @c From() and
/// <i>may</i> provide some performance improvement (although no profiling has
/// been done to verify this).
/// @code
/// using Com.Halfdecent.GenericArithmetic;
///
/// // ...
///
/// T AddTenAndMultiplyByFive<T>( T to )
/// {
///     IArithmetic<T> a = Arithmetic.Get<T>();
///     return a.Multiply( a.Add( to, Arithmetic.From( 10 ) ), a.From( 5 ) );
/// }
/// @endcode
///
/// @par Considerations
/// IArithmetic< T > implementation selection is done at runtime by
/// <tt>Arithmetic.Get<T>()</tt>, and all generic operations have no
/// restrictions on their type parameters.  As far as the compiler is
/// concerned, you can perform arithmetic with <i>any</i> type.  This is of
/// course not the case, and you will get an <c>ArgumentException</c> at
/// runtime if the type is not supported.
///
namespace
Com.Halfdecent.GenericArithmetic
{
}

