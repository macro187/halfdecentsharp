// -----------------------------------------------------------------------------
// Copyright (c) 2011, 2012
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


namespace
Com.Halfdecent
{


// =============================================================================
// A value that may or may not hold an underlying value
// =============================================================================

public interface
IMaybe<
    #if DOTNET40
    out T
    #else
    T
    #endif
>
    : ITupleHD< bool, T >
{



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// Whether there is an underlying value
///
    bool
HasValue
{
    get;
}


/// The underlying value, if there is one
///
/// @exception System.InvalidOperationException
/// There is no value, i.e. `!HasValue`
///
    T
Value
{
    get;
}




} // type
} // namespace

