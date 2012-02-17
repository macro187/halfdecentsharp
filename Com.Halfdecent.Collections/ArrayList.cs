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


using SCG = System.Collections.Generic;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Numerics;
using Com.Halfdecent.Streams;


namespace
Com.Halfdecent.Collections
{


public static class
ArrayList
{



// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

public static
    ArrayList< T >
Create<
    T
>(
    params T[] items
)
{
    items = items ?? new T[]{};
    return Create< T >( items.AsHalfdecentCollection() );
}


public static
    ArrayList< T >
Create<
    T
>(
    ICollectionR< T > items
)
{
    NonNull.CheckParameter( items, "items" );
    return Create< T >( items.Stream(), items.Count );
}


public static
    ArrayList< T >
Create<
    T
>(
    IStream< T > items
)
{
    NonNull.CheckParameter( items, "items" );
    return Create< T >( items, null );
}


public static
    ArrayList< T >
Create<
    T
>(
    IStream< T >    items,
    IInteger        count
)
{
    NonNull.CheckParameter( items, "items" );
    var list =
        count == null
            ? new SCG.List< T >()
            : new SCG.List< T >(
                count.LT( Integer.Create( int.MaxValue ) )
                    ? (int)( count.GetValue() )
                    : int.MaxValue );
    if( items != null )
        items.EmptyTo( list.AsSink() );
    return new ArrayList< T >( list );
}




} // type
} // namespace

