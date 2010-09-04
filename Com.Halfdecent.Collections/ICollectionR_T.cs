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


using Com.Halfdecent.Streams;


namespace
Com.Halfdecent.Collections
{


// =============================================================================
/// TODO
// =============================================================================

public interface
ICollectionR<
#if DOTNET40
    out T
#else
    T
#endif
>
    : ICollection
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Produce a stream of all items in no particular order
///
    IStream< T >
Stream();



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait ICollectionR< T >.Proxy
// -----------------------------------------------------------------------------

public IStream< T > Stream() {
    return this.From.Stream(); }
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait ICollectionR< out T >.Proxy
// -----------------------------------------------------------------------------

public IStream< T > Stream() {
    return this.From.Stream().Covary< TFrom, T >(); }
#endif



} // type
} // namespace

