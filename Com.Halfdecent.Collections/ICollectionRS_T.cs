// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2012
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


using System;
using Com.Halfdecent.Streams;


namespace
Com.Halfdecent.Collections
{


// =============================================================================
/// A readable, shrinkable collection
// =============================================================================

public interface
ICollectionRS<
    T
>
    : ICollectionR< T >
    , ICollectionS
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Remove all items matching a specified predicate
///
    IStream< T >
GetAndRemoveWhere(
    Predicate< T > where
);



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait ICollectionRS.Statics
// -----------------------------------------------------------------------------
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait ICollectionRS.Proxy
// -----------------------------------------------------------------------------

public IStream< T >
    GetAndRemoveWhere( Predicate< T > where ) {
        return this.From.GetAndRemoveWhere( where ); }
#endif




} // type
} // namespace

