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


using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Collections
{



/// <summary>
/// An event in the course of traversing a tree
/// </summary>
///
public abstract class
TreeEvent<T>
{

internal
TreeEvent()
{
}

}



/// <summary>
/// Visit a node in the course of traversing a tree
/// </summary>
///
public class
NodeTreeEvent<T>
    : TreeEvent<T>
{

internal
NodeTreeEvent(
    T node
)
{
    NonNull.CheckParameter( node, "node" );
    this.Node = node;
}

public T
Node
{
    get;
    private set;
}

}



/// <summary>
/// Descend to a node's child in the course of traversing a tree
/// </summary>
public class
DescendTreeEvent<T>
    : TreeEvent<T>
{

internal
DescendTreeEvent()
{
}

}



/// <summary>
/// Ascend to a node's parent in the course of traversing a tree
/// </summary>
public class
AscendTreeEvent<T>
    : TreeEvent<T>
{

internal
AscendTreeEvent()
{
}

}



}

