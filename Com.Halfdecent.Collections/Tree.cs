// -----------------------------------------------------------------------------
// Copyright (c) 2013
// Ron MacNeil <macro@hotmail.com>
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
using System.Collections.Generic;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Streams;


namespace
Com.Halfdecent.Collections
{


/// Operations on things shaped like trees
///
public static class
Tree
{


/// Traverse a tree in depth-first pre-order
///
public static
    IStream<TreeEvent<T>>
    /// @returns A lazy stream of descend, ascend, and node-visit events
TraverseDepthFirst<T>(
    T                   node,
    ///< The root node
    ///  [NonNull]
    Func<T,IStream<T>>  getChildrenFunc
    ///< A function that gets a node's child nodes
    ///  [NonNull]
)
{
    return TraverseDepthFirstImpl( node, getChildrenFunc ).AsStream();
}


private static
    IEnumerable<TreeEvent<T>>
TraverseDepthFirstImpl<T>(
    T                   node,
    Func<T,IStream<T>>  getChildrenFunc
)
{
    NonNull.CheckParameter( node, "node" );
    NonNull.CheckParameter( getChildrenFunc, "getChildrenFunc" );
    yield return new NodeTreeEvent<T>( node );
    foreach( T n in getChildrenFunc( node ).AsEnumerable() ) {
        yield return new DescendTreeEvent<T>();
        foreach(
            var e
            in TraverseDepthFirst( n, getChildrenFunc ).AsEnumerable()
        )
            yield return e;
        yield return new AscendTreeEvent<T>();
    }
}



}
}

