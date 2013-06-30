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


/// <summary>
/// Operations on things shaped like trees
/// </summary>
///
public static class
Tree
{


/// <summary>
/// Traverse a tree in depth-first pre-order
/// </summary>
/// <param name="node">
/// The root node
/// [NonNull]
/// </param>
/// <param name="getChildrenFunc">
/// A function that gets a node's child nodes
/// [NonNull]
/// </param>
/// <returns>
/// Lazily-evaluated stream of events that occur over the course of traversing
/// the specified tree.
/// </returns>
///
public static
    IEnumerable<TreeEvent<T>>
TraverseDepthFirst<T>(
    T                       node,
    Func<T,IEnumerable<T>>  getChildrenFunc
)
{
    NonNull.CheckParameter( node, "node" );
    NonNull.CheckParameter( getChildrenFunc, "getChildrenFunc" );
    yield return new NodeTreeEvent<T>( node );
    foreach( T n in getChildrenFunc( node ) ) {
        yield return new DescendTreeEvent<T>();
        foreach(
            TreeEvent<T> e
            in TraverseDepthFirst( n, getChildrenFunc ))
            yield return e;
        yield return new AscendTreeEvent<T>();
    }
}



} // type
} // namespace

