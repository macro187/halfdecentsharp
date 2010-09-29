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
/// Human cultures and languages
///
///
/// @section culturenotes Notes on Cultures in .NET
///
///     A <em>specific culture</em> is a particular language in a particular
///     geographic region, for example <tt>en-US</tt>.  A <em>neutral
///     culture</em> is just a particular language, for example <tt>fr</tt>.
///     The <em>invariant culture</em> (usually represented as a blank string)
///     is the least-specific and means no particular language or region.
///
///     A less-specific version of a culture is said to be its <em>parent</em>.
///     A specific culture's parent is the corresponding neutral culture, and a
///     neutral culture's parent is the invariant culture.  For example,
///     <tt>"en-AU" &lt; "en" &lt; ""</tt>.
///
///
/// @section problem Problem
///
///     Like flossing, making code localisable is often something that is done
///     as an afterthought, when it's already too late to be effective.  There
///     is a proliferation of existing localisable string programming patterns
///     and, even thought they sort of work, they tend to share some negative
///     characteristics.
///
///     -   Making a string localisable demands immediate,
///         concentration-breaking work for the programmer (eg. Add the string
///         to a table, (re)generate accessor classes and embedded resources,
///         change literals to some kind of localised string references, etc.)
///
///     -   Clear, human-readable literals become opaque references (often
///         single-word lookup keys)
///
///     -   Localisable and non-localisable items are the same type, so it can
///         be unclear at first glance which of the two a given piece of code is
///         intended to work with, and it prevents the compiler from helping to
///         reinforce the difference
///
///     -   Furthermore, because localisable items are no different from
///         regular ones, they can't carry additional localisable behaviour with
///         them, for example the ability to translate themselves to other
///         languages in real-time as UICulture changes
///
///     -   The whole thing feels "flimsy", seems "bolted-on", or leaves a bad
///         "code smell" <sup>[1]</sup>
///
///     (TODO: Try to do a good survey of existing localisation patterns rather
///     than just trashing them all at once, even though they might deserve it)
///
///     The underlying problem starts with the lack of a "logical" localisable
///     item type providing a way to refer to all variations of a localised
///     asset collectively as one.  We'd like these items to transparently adapt
///     themselves to different cultural contexts with little or no extra work
///     on our part.
///
///     Overall, we want a way to write code that is localisable from the
///     outset, with minimal programming overhead, so that we actually do it.
///
///     <small>
///     <sup>[1]</sup> <tt>http://en.wikipedia.org/wiki/Code_smell</tt>
///     </small>
///
///
/// @section solution Solution
///
///     (TODO: Localised<T> might be a monad, so revisit this once I have a
///     solid understanding of them)
///
///     <tt>Localised<T></tt> is a logical item having one or more cultural
///     variations and which transparently changes according to the current (or
///     a specified) culture.
///
///     <tt>LocalisedBase<T></tt> provides a starting point for implementing
///     <tt>Localised<T></tt>. It helps implement the semantics correctly and
///     supports different culture fallback algorithms.
///
///     <tt>LocalisedString</tt> composes localised strings using the familiar
///     <tt>System.String.Format()</tt> pattern.  The resulting composite
///     strings lazily compose themselves, and can transparently re-compose
///     themselves in other languages.
///
///
// =============================================================================

namespace
Com.Halfdecent.Globalisation
{
}


