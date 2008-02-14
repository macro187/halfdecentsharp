// -----------------------------------------------------------------------------
// Copyright (c) 2007 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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


/// Interoperability with <tt>System.Collections.Generic</tt>
///
/// @par <tt>System.Collections.Generic.ICollection< T ></tt>
/// ICollection loosely represents four flavours of bag:  Fixed-size, growable,
/// shrinkable, or resizable (both shrinkable and resizable).
///
/// Rather than having separate types for these semantics, the issue is punted
/// to runtime in the form of the <tt>IsReadOnly</tt> property, which is both
/// unclear and insufficient [1].
///
/// The <tt>SCGInterop</tt> namespace provides various ICollection adapters
/// that accurately reflect the different semantics.  The developer must
/// be careful to select an adapter that accurately reflects the ICollection
/// they wish to adapt because, as discussed above, it's impossible to
/// determine what an ICollection actually supports (without resorting to
/// attempting the various operations and checking for exceptions).
///
/// [1] The Microsoft documentation even suggests that <tt>IsReadOnly</tt>
/// indicates whether the collection elements can be modified, something that
/// isn't even possible via <tt>ICollection< T ></tt>.  See "Remarks" at
/// http://msdn2.microsoft.com/en-us/library/0cfatk9t(VS.80).aspx
///
namespace
Com.Halfdecent.Collections.SCGInterop
{
}

