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


using Com.Halfdecent;
using Com.Halfdecent.Globalisation;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// Reusable, composable value condition
// =============================================================================

public interface
IRType
    : IEquatable< IRType >
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Get the underlying RType
///
    IRType
    /// @returns
    /// <tt>this</tt>
    /// - OR -
    /// The underlying RType, if <tt>this</tt> is an adapter
GetUnderlying();


/// Generate natural language stating that an item <em>is</em> of this RType
///
    Localised< string >
SayIs(
    Localised< string > reference
    ///< Natural language reference to the item
);


/// Generate natural language stating that an item <em>is not</em> of this RType
///
    Localised< string >
SayIsNot(
    Localised< string > reference
    ///< Natural language reference to the item
);


/// Generate natural language stating that and item <em>is required to be</em>
/// of this RType
///
    Localised< string >
SayMustBe(
    Localised< string > reference
    ///< Natural language reference to the item
);




} // type
} // namespace

