// -----------------------------------------------------------------------------
// Copyright (c) 2008 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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


using Com.Halfdecent.Globalisation;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
// An RType
// =============================================================================

public interface
IRType
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Generate a natural language statement stating that an item "is" this RType
///
Localised< string >
SayIs(
    Localised< string > reference
    ///< What to refer to the item as, in natural language
);


/// Generate a natural language statement that an item "is not" this RType
///
Localised< string >
SayIsNot(
    Localised< string > reference
    ///< What to refer to the item as, in natural language
);


/// Generate a natural language statement requiring an item to be this RType
///
Localised< string >
SayMustBe(
    Localised< string > reference
    ///< What to refer to the item as, in natural language
);




} // type
} // namespace

