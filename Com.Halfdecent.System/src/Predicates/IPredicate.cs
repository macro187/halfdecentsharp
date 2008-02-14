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


using System;
using Com.Halfdecent.Globalization;


namespace
Com.Halfdecent.Predicates
{




/// A predicate
///
public interface
IPredicate
{




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Generate a natural language statement that can be said of a term if it
/// conforms to this predicate
///
/// Examples:
/// - "... is even"
/// - "... is a valid url"
/// - "... contains at least 3 items"
///
Localized< string >
SayConforms(
    Localized< string > termIdentifier  ///< Phrase identifying the term
);



/// Generate a natural language statement that can be said of a term if it
/// <em>does not</em> conform to this predicate
///
/// Examples:
/// - "... is not even"
/// - "... is not a valid url"
/// - "... contains less than 3 items"
///
Localized< string >
SayDoesNotConform(
    Localized< string > termIdentifier  ///< Phrase identifying the term
);



/// Generate a natural language statement demanding a term conform to this
/// predicate
///
/// Examples:
/// - "... must be even"
/// - "... must be a valid url"
/// - "... must contains at least 3 items"
///
Localized< string >
SayRequirement(
    Localized< string > termIdentifier  ///< Phrase identifying the term
);




} // type
} // namespace

