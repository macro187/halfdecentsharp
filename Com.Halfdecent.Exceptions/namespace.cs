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
/// Localisable exceptions
///
/// @section problem Problem
///
///     Exception messages are not localisable (ie.
///     <tt>Com.Halfdecent.Globalisation.Localised<string></tt>).  This is a
///     general shortcoming that prevents use of exception messages in
///     user-visible ways.
///
///
/// @section solution Solution
///
///     -   <tt>ILocalisedException</tt> interface with a
///         <tt>Localised<string></tt> <tt>.Message</tt>.
///
///     -   Subclasses of the main Base Class Library
///         exceptions implementing <tt>ILocalisedException</tt>.
///
///
// =============================================================================

namespace
Com.Halfdecent.Exceptions
{
}

