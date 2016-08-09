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
/// Collections
///
///
/// @section introduction Introduction
///
///
///     @subsection mutability Mutability
///
///         The readability and writability of collections breaks down into four
///         kinds:
///
///         -   <em>Readable</em>, items can be retrieved
///
///         -   <em>Changeable</em>, existing items can be replaced with new
///             ones
///
///         -   <em>Shrinkable</em>, existing items can be removed, shrinking
///             the collection
///
///         -   <em>Growable</em>, new items can be added, growing the
///             collection
///
///
/// @section problems Problems
///
///     The design of the Base Class Library collections ranges from
///     inconsistent to broken.  The list of specific problems presented here is
///     illustrative, not exhaustive.
///
///
///     @subsection upsidedown Upside-down Inheritance
///
///         In the Base Class Library, the read-only collections subclass the
///         mutable ones.  Apparently someone disagreed with Liskov.
///
///
///     @subsection inconsistencies Generic/Non-Generic Inconsistencies
///
///         There are a number of inconsistencies between
///         <tt>System.Collections</tt> and <tt>System.Collections.Generic</tt>:
///
///         -   <tt>System.Collections.Generic.ICollection<T></tt> can
///             <tt>.Add()</tt> and <tt>.Remove()</tt>, but its non-generic
///             counterpart can't
///
///         -   <tt>System.Collections.Generic.IEnumerable<T></tt> inherits from
///             its non-generic counterpart, but
///             <tt>System.Collections.Generic.ICollection<T></tt> and
///             <tt>System.Collections.Generic.IList<T></tt> don't
///
///
///     @subsection mutabilityindication Poor Indication of Mutability
///
///         The Base Class Library collections indicate their mutability through
///         various <tt>.IsReadOnly</tt> and <tt>.IsFixedSize</tt> properties,
///         which are broken:
///
///         -   They aren't shared between <tt>System.Collections</tt> and
///             <tt>System.Collections.Generic</tt>
///
///         -   They're defined on different types in the generic and
///             non-generic namespaces, specifically the non-generic list
///             (<tt>System.Collections.IList</tt>) and the generic collection
///             (<tt>System.Collections.Generic.ICollection<T></tt>)
///
///         -   <tt>.IsFixedSize</tt> doesn't distinguish between growable and
///             shrinkable
///
///         -   Generic collections just have <tt>.IsReadOnly</tt>, which is
///             completely insufficient
///
///         The net result is that mutability isn't even indicated correctly for
///         common collections such as arrays, never mind the more specialised
///         collections involved in any real object model.
///
///
///     @subsection nostaticmutability No Mutability Types
///
///         Mutability in the Base Class Library collections is not expressed as
///         types.  Even the various "read-only" classes don't qualify, as their
///         inheritance design is incorrect, making them effectively just
///         mutable collections whose modification operations throw exceptions.
///
///
/// @section solution Solution
///
///
///     @subsection hierarchy Simple Collections Hierarchy
///
///         The overall types of collections are, in general-to-specific order:
///
///         -   <tt>ICollection</tt>, a bag of items
///
///         -   <tt>IKeyedCollection</tt>, where items are referenced by
///             non-unique key
///
///         -   <tt>IUniqueKeyedCollection</tt>, where items are referenced by
///             unique key
///
///         -   <tt>IOrderedCollection</tt>, where items are in a particular
///             order and are referenced by ordinal position
///
///         Subtypes are generally substitutable for supertypes, although
///         mutability complicates the issue somewhat.
///
///
///     @subsection typedmutability Statically-typed Mutability
///
///         Each of the overall types of collection outlined above is further
///         divided into subtypes by mutability, one for each of (R)eadable,
///         (C)hangable, (S)hrinkable, (G)rowable, and all combinations.
///
///         Growable keyed collections come in two varieties:  Those where the
///         keys are specified explicitly, and those where the keys are implicit
///         in the items themselves.  Both varieties are provided, with the
///         explicitly-keyed types the default and the implicitly-keyed type
///         names carrying an "Implicit" prefix.  It's even possibly for a type
///         to support both kinds of growable, as is the case with ordered
///         collections.
///
///         The collection types inherit as appropriate.  Because of how
///         fine-grained they are, and the resulting number of them, the
///         inheritance graph appears complicated at first glance.  The aim is
///         that upon closer inspection the relationships make intuitive sense.
///
///
///     @subsection genericandvariance Generics and Variance
///
///         All collection types are generic as appropriate.  They are also
///         variant as appropriate, both implicitly through C# 4.0 variance and
///         explicitly through extension methods and proxies.
///
///
///     @subsection streamsintegration Streams Integration
///
///         This namespace builds on <tt>Halfdecent.Streams</tt>.  Rather
///         than being enumerable, the collections produce various streams of
///         their items.  Growable collections can be used as sinks.  Shrinkable
///         collections can remove items as a stream.  Changeable collections
///         can produce filters into which replacement items can be streamed,
///         and out of which the replaced items will flow.
///
///
///     @subsection cursorsintegration Cursors Integration
///
///         TODO
///
///
///     @subsection bclinterop Base Class Library Interoperability
///
///         Extension methods and adapters are provided that fit appropriate
///         collection interfaces to various Base Class Library types:
///
///         -   <tt>SystemIList.AsHalfdecentCollection<T>()</tt>
///
///         -   <tt>SystemDictionary.AsHalfdecentCollection<T>()</tt>
///
///         -   <tt>SystemString.AsHalfdecentCollection()</tt>
///
///         -   <tt>SystemStringBuilder.AsHalfdecentCollection()</tt>
///
///
///     @subsection capacities Capacities
///
///         TODO
///
///
///     @subsection collisions Base Class Library Name Collisions
///
///         This library aims to completely supersede
///         <tt>System.Collections</tt> and <tt>System.Collections.Generic</tt>,
///         taking the view that they're too useless to be worth avoiding name
///         collisions with.  If you want to use them with this namespace,
///         you'll need to do a <tt>using</tt> alias.
///
///
/// @section footnotes Footnotes
///
///     TODO
///
///
// =============================================================================

namespace
Halfdecent.Collections
{
}

