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


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// A programmatic source of a potentially infinite sequence of items, yielded
/// one after another over time
///
/// See <tt>http://en.wikipedia.org/wiki/Stream_(computing)</tt>
///
/// On it's own, <tt>IStream< T ></tt> does not imply how many more items (if
/// any) are available, nor how long (if ever) it will take to yield the next
/// one.  Implementations should document their behaviour in this regard
/// and/or implement stream subtypes with more specific behaviour.
// =============================================================================

public interface
IStream<
#if DOTNET40
    out T
#else
    T
#endif
>
{



/// Try to pull the next item from the stream
///
/// <tt>IStream< T ></tt> alone does not imply how long this method will take
/// to return or whether it will return at all.
///
/// Once this method returns <tt>false</tt> indicating that the end of the
/// stream has been reached, it will never produce items again.
///
/// Design Note:
/// This method returns a tuple rather than using an <tt>out</tt> parameter
/// because <tt>out</tt> parameters are not covariant, which would mean that
/// this interface couldn't be covariant.  The good news is that an extension
/// method is available that provides a <tt>bool TryPull( out T result )</tt>
/// overload.
///
    ITuple< bool, T >
    /// @returns
    /// A tuple whose first value indicates whether there was another item in
    /// the stream and whose second value is either the value from the stream or
    /// an undefined and unusable value if there was none
TryPull();




} // type
} // namespace

