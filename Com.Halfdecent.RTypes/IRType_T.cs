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
///
/// @section logic Logic
///
///     Condition logic is expressed in any combination of 3 different ways:
///
///     -   Through the composition of existing rtypes:
///         <tt>.GetComponents()</tt>
///
///     -   Through the application of existing rtypes to parts of items:
///         <tt>.CheckMembers()</tt>
///
///     -   Through hand-written logic: <tt>.Predicate()</tt>
///
///
/// @section nulls Null Values
///
///     RTypes allow <tt>null</tt> values to pass.  The only exception is
///     <tt>NonNull</tt>, which is specifically designed to disallow them 
///
///
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

/// Logic expressed as a list of existing rtypes to compose
///
    SCG.IEnumerable< IRType< T > >
GetComponents();


/// Logic expressed as the application of existing rtypes to parts of the item
///
    RTypeException
    /// @returns
    /// <tt>null</tt> if all member checks pass
    /// - OR -
    /// An <tt>RTypeException</tt> with details of the first member check that
    /// failed
CheckMembers(
    T       item,
    Value   itemReference
);


/// Logic expressed as a function "from scratch"
///
    bool
Predicate(
    T item
);




} // type
} // namespace

