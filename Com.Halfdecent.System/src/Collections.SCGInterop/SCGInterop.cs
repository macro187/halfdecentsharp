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
/// The <tt>System.Collections.Generic.ICollection< T ></tt> type can
/// represent four possible kinds of bag:
/// - Fixed-size
/// - Growable
/// - Shrinkable
/// - Resizable (both growable and shrinkable)
/// Rather than having separate types for each kind, the issue is punted
/// to runtime in the form of the <tt>ICollection< T >.IsReadOnly</tt>
/// property, which is unclear and insufficient to indicate which of the
/// above-mentioned semantics are in force [1].
///
/// The <tt>SCGInterop</tt> namespace provides various ICollection adapters
/// capable of accurately reflecting the semantics of the various kinds of
/// bags discussed above. The developer must be careful to select an adapter
/// that accurately reflects the semantics of the <tt>ICollection< T ></tt>
/// they are adapting because, as discussed above, it's impossible for code
/// to determine those semantics without resorting to eg. attempts at the
/// various operations while checking for exceptions.
///
/// [1] The Microsoft documentation even suggests that <tt>IsReadOnly</tt>
/// indicates whether the collection elements themselves can be modified,
/// which isn't even possible to do through <tt>ICollection< T ></tt>.  See
/// "Remarks" at http://msdn2.microsoft.com/en-us/library/0cfatk9t(VS.80).aspx
///
namespace
Com.Halfdecent.Collections.SCGInterop
{
}

