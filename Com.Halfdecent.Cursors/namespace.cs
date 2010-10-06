// -----------------------------------------------------------------------------
// Copyright (c) 2010
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
/// Cursors
///
///
/// @section introduction Introduction
///
///     This library deals with cursors in the abstract "moveable pointer to an
///     item" sense.
///
///
/// @section problem Problem
///
///     -   The Base Class Library offers just <tt>IEnumerator<T></tt>, a
///         forward-only, read-only cursor
///
///     -   No cursors that can go backwards
///
///     -   No cursors that can replace the items they point to
///
///     -   No cursors that can insert items where they point
///
///     -   No cursors that can remove the items they point to
///
///
/// @section solution Solution
///
///     -   Forward-only cursor:  <tt>ICursor</tt>
///
///     -   Forward and backward cursor:  <tt>IBidirectionalCursor</tt>
///
///     -   Fine-grained cursor subtypes that can read, change, insert, or
///         remove items, and subtypes for all possible combinations
///
///     -   Explicit variance where appropriate via extension methods and
///         proxies
///
///     -   Implicit C# 4.0 variance where appropriate
///
///
// =============================================================================

namespace
Com.Halfdecent.Cursors
{
}

