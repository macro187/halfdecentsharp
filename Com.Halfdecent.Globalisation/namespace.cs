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
/// @section problems Problems
///
///     @subsection existingstringpatterns Existing String Patterns
///
///         There is a proliferation of existing localisable string programming
///         patterns and, even though they sort of work, they tend to share
///         some negative characteristics.  They usually require housekeeping
///         work such as adding strings to a table, (re)generating accessor
///         classes and embedded resources, changing string literals to
///         localised string references of some kind, etc.  Often, they trade
///         readable string literals for opaque, single-word references.
///
///     @subsection nolocalisedtypes No Localised Types
///
///         In existing patterns, localisable and non-localisable items are the
///         same type, so it can be unclear at first glance which of the two a
///         given piece of code is intended to work with, and it prevents the
///         compiler from helping to reinforce the difference.  They can't
///         carry additional localisable behaviour with them.
///
///     @subsection exceptions Exceptions Are Not Localisable
///
///         Exception messages are not localisable, preventing their use in
///         user-visible situations.
///
///
/// @section solutions Solutions
///
///     <tt>Localised<T></tt> is a logical item having one or more cultural
///     variations and which transparently changes according to the current (or
///     a specified) culture.
///
///     <tt>FallbackLocalised<T></tt> helps with localised items where
///     variations may not exist for all cultures.
///
///     <tt>LocalisedString</tt> provides localised string manipulation and
///     composition using familiar patterns.  The results of these operations
///     are lazily evaluated <tt>Localised<string></tt> objects that can
///     re-evaluate themselves in multiple languages 
///
///     <tt>ILocalisedException</tt> is an exception whose <tt>.Message</tt> is
///     a <tt>Localised<string></tt>.  Subclasses of common Base Class Library
///     exceptions implementing <tt>ILocalisedException</tt> are provided,
///     including <tt>LocalisedException</tt>,
///     <tt>LocalisedArgumentException</tt>,
///     <tt>LocalisedArgumentNullException</tt>,
///     <tt>LocalisedArgumentOutOfRangeException</tt>,
///     <tt>LocalisedInvalidOperationException</tt>, and
///     <tt>LocalisedFormatException</tt>.
///
///
// =============================================================================

namespace
Com.Halfdecent.Globalisation
{
}

