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


using SCG = System.Collections.Generic;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// Reusable, composable value condition
// =============================================================================

public interface
IRType<
    T
>
    : IRType
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// RType logic as a list of other RTypes to be applied to the item
///
    SCG.IEnumerable< IRType< T > >
GetComponents();


/// RType logic by applying RType checks to parts of the item
///
/// @section implementing Implementing
///
///     The <tt>??</tt> operator is a nice way to implement this method if
///     there is more than one check:
///
///     <code>
///     public override
///     RTypeException
///     CheckMembers(
///         T       item,
///         Value   itemReference
///     )
///     {
///         return
///             new SomeRType().Check(
///                 item.Prop, itemReference.Property( "Prop" ) ) ??
///             new AnotherRType().Check(
///                 item[2], itemReference.Indexer( 2 ) ) ??
///             new YetAnotherRType().Check(
///                 item.Prop2, itemReference.Property( "Prop2" ) );
///     }
///     </code>
///
    RTypeException
    /// @returns
    /// <tt>null</tt>, if all member rtype checks passed
    /// - OR -
    /// An <tt>RTypeException</tt> with details, if a member rtype check
    /// failed
CheckMembers(
    T       item,
    Value   itemReference
);


/// RType logic as a method
///
    bool
    /// @returns
    /// Whether <tt>item</tt> conforms
Predicate(
    T item
);




} // type
} // namespace

