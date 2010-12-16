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


using Com.Halfdecent;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Numerics;


namespace
Com.Halfdecent.Collections
{


public static partial class
OrderedCollectionS
{



public static
    void
RemoveFirst(
    this IOrderedCollectionS dis
)
{
    NonNull.CheckParameter( dis, "dis" );
    dis.RemoveFirst( Integer.From( 1 ) );
}


public static
    void
RemoveFirst(
    this IOrderedCollectionS    dis,
    IInteger                    count
)
{
    NonNull.CheckParameter( dis, "dis" );
    GTE.CheckParameter( Integer.From( 0 ), count, "count" );
    LTE.CheckParameter( dis.Count, count, "count" );

    while( count.GT( Integer.From( 0 ) ) ) {
        dis.Remove( Integer.From( 0 ) );
        count = count.Minus( Integer.From( 1 ) );
    }
}


public static
    void
RemoveLast(
    this IOrderedCollectionS dis
)
{
    NonNull.CheckParameter( dis, "dis" );
    dis.RemoveLast( Integer.From( 1 ) );
}


public static
    void
RemoveLast(
    this IOrderedCollectionS    dis,
    IInteger                    count
)
{
    NonNull.CheckParameter( dis, "dis" );
    GTE.CheckParameter( Integer.From( 0 ), count, "count" );
    LTE.CheckParameter( dis.Count, count, "count" );

    while( count.GT( Integer.From( 0 ) ) ) {
        dis.Remove( dis.Count.Minus( Integer.From( 1 ) ) );
        count = count.Minus( Integer.From( 1 ) );
    }
}




} // type
} // namespace

