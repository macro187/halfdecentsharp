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


using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Numerics;


namespace
Com.Halfdecent.Collections
{


// =============================================================================
/// TODO
// =============================================================================

public partial interface
IOrderedCollectionS
    : IOrderedCollection
    , IUniqueKeyedCollectionS< IInteger >
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
    dis.RemoveFirst( Integer.Create( 1 ) );
}


public static
    void
RemoveFirst(
    this IOrderedCollectionS    dis,
    IInteger                    count
)
{
    NonNull.CheckParameter( dis, "dis" );
    GTE.CheckParameter< IReal >( Integer.Create( 0 ), count, "count" );
    LTE.CheckParameter< IReal >( dis.Count, count, "count" );

    while( count.GT( Integer.Create( 0 ) ) ) {
        dis.Remove( Integer.Create( 0 ) );
        count = count.Minus( Integer.Create( 1 ) );
    }
}


public static
    void
RemoveLast(
    this IOrderedCollectionS dis
)
{
    NonNull.CheckParameter( dis, "dis" );
    dis.RemoveLast( Integer.Create( 1 ) );
}


public static
    void
RemoveLast(
    this IOrderedCollectionS    dis,
    IInteger                    count
)
{
    NonNull.CheckParameter( dis, "dis" );
    GTE.CheckParameter< IReal >( Integer.Create( 0 ), count, "count" );
    LTE.CheckParameter< IReal >( dis.Count, count, "count" );

    while( count.GT( Integer.Create( 0 ) ) ) {
        dis.Remove( dis.Count.Minus( Integer.Create( 1 ) ) );
        count = count.Minus( Integer.Create( 1 ) );
    }
}
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionS.Proxy
// -----------------------------------------------------------------------------

public void RemoveAll( IInteger key ) { this.From.RemoveAll( key ); }

public void Remove( IInteger key ) { this.From.Remove( key ); }
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionS.IndexSlice
// -----------------------------------------------------------------------------

public
    void
Remove(
    IInteger key
)
{
    NonNull.CheckParameter( key, "key" );
    GTE.CheckParameter< IReal >( Integer.Create( 0 ), key, "key" );
    LTE.CheckParameter< IReal >( this.Count, key, "key" );
    this.From.Remove( this.Trans( key ) );
    this.SliceCount = this.SliceCount.Minus( Integer.Create( 1 ) );
}


public void RemoveAll( IInteger key ) { this.Remove( key ); }
#endif




} // type
} // namespace

