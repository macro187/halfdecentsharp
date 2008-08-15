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



/// Logical predicates
///
/// @par Theory
/// In predicate logic, a <em>predicate</em> is some condition of an item
/// (known as a <em>term</em>) that may be true or false (known as a
/// <em>truth value</em>).  Determining the truth value of a predicate for a
/// given term is known as <em>evaluation</em> [1].
///
/// @par Term Requirements
/// There may be additional run-time requirements of terms in addition to
/// those imposed at compile-time (via restrictions on the <tt>T</tt> type
/// parameter).  These are called <em>term requirements</em> and, if violated,
/// will result in <tt>BugException</tt>s.  It is the programmer's
/// responsibility to ensure these requirements are met prior to subjecting
/// terms to a predicate.
///
/// @par Compound Predicates
/// Predicates may be composed of one or more other predicates.  As an
/// example, a "between" could be composed of "minimum" plus a "maximum".
/// This is called a <em>compound predicate</em>, and predicates composing
/// them are called <em>component predicates</em> or just <em>components</em>.
/// When a term fails a compound predicate's <tt>Require()</tt> because it
/// failed a component predicate, the resulting <tt>ValueException</tt>'s
/// <tt>InnerException</tt> will be the exception from the component predicate
/// (and so on if the component predicate was itself a compound predicate).
/// This allows one to drill-down to the exact reason a term failed a
/// compound predicate.
///
/// [1] I don't know if this is the actual academic word for it, but it is used
/// here for lack of a better term
///
namespace
Com.Halfdecent.Predicates
{
}

