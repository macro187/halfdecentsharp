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
using Halfdecent.Meta;
using Halfdecent.RTypes;
using Halfdecent.Streams;


namespace
Halfdecent.Collections
{


// =============================================================================
/// Present a unique keyed collection as an implicit unique keyed collection
// =============================================================================

public class
ImplicitUniqueKeyedCollectionFromUniqueKeyedCollectionAdapter<
    TKey,
    T
>
    : UniqueKeyedCollectionRSProxy< TKey, T >
    , IImplicitUniqueKeyedCollectionRSG< TKey, T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
ImplicitUniqueKeyedCollectionFromUniqueKeyedCollectionAdapter(
    IUniqueKeyedCollectionRSG< TKey, T >    from,
    Func< T, TKey >                         extractKeyFunc
)
    : base( from )
{
    NonNull.CheckParameter( from, "from" );
    NonNull.CheckParameter( extractKeyFunc, "extractKeyFunc" );
    this.From = from;
    this.ExtractKeyFunc = extractKeyFunc;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

new protected
IUniqueKeyedCollectionRSG< TKey, T >
From
{
    get;
    private set;
}


protected
Func< T, TKey >
ExtractKeyFunc
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// ICollectionG< T >
// -----------------------------------------------------------------------------

public
    void
Add(
    T item
)
{
    this.From.Add( this.ExtractKeyFunc( item ), item );
}




} // type
} // namespace

