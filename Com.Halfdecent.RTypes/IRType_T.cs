// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009
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


using System.Collections.Generic;
using Com.Halfdecent.Globalisation;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// Composable value check
// =============================================================================

public interface
IRType<
    T
    ///< .NET type of items this RType applies to
    ///  (contravariant)
>
    : IRType
{



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// RTypes that this one is composed of
///
IEnumerable< IRType< T > >
Components
{
    get;
}



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Logic (in addition to that of any <tt>.Components</tt>) determining whether
/// an item "is of" this RType
///
/// Generally returns <tt>true</tt> for <tt>null</tt> items unless the RType
/// explicitly disallows <tt>null</tt>s
///
bool
Predicate(
    T item
);




} // type
} // namespace

