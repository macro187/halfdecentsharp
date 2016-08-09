// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010, 2012
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


using Halfdecent.Meta;
using Halfdecent.RTypes;


namespace
Halfdecent.Collections
{


// =============================================================================
/// TODO
// =============================================================================

public partial interface
IOrderedCollectionS
    : IOrderedCollection
    , IUniqueKeyedCollectionS< long >
{



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionS.Statics
// -----------------------------------------------------------------------------

public static
    void
RemoveFirst(
    this IOrderedCollectionS dis
)
{
    NonNull.CheckParameter( dis, "dis" );
    dis.RemoveFirst( 1 );
}


public static
    void
RemoveFirst(
    this IOrderedCollectionS    dis,
    long                        count
)
{
    NonNull.CheckParameter( dis, "dis" );
    GTE.CheckParameter( 0, count, "count" );
    LTE.CheckParameter( dis.Count, count, "count" );

    while( count > 0 ) {
        dis.Remove( 0 );
        count = count - 1;
    }
}


public static
    void
RemoveLast(
    this IOrderedCollectionS dis
)
{
    NonNull.CheckParameter( dis, "dis" );
    dis.RemoveLast( 1 );
}


public static
    void
RemoveLast(
    this IOrderedCollectionS    dis,
    long                        count
)
{
    NonNull.CheckParameter( dis, "dis" );
    GTE.CheckParameter( 0, count, "count" );
    LTE.CheckParameter( dis.Count, count, "count" );

    while( count > 0 ) {
        dis.Remove( dis.Count - 1 );
        count = count - 1;
    }
}
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionS.Proxy
// -----------------------------------------------------------------------------

public void RemoveAll( long key ) { this.From.RemoveAll( key ); }

public void Remove( long key ) { this.From.Remove( key ); }
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionS.IndexSlice
// -----------------------------------------------------------------------------

public
    void
Remove(
    long key
)
{
    GTE.CheckParameter( 0, key, "key" );
    LTE.CheckParameter( this.Count, key, "key" );
    this.From.Remove( this.Trans( key ) );
    this.SliceCount = this.SliceCount - 1;
}


public void RemoveAll( long key ) { this.Remove( key ); }
#endif




} // type
} // namespace

