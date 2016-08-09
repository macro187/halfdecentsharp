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


using Halfdecent.RTypes;


namespace
Halfdecent.Collections
{



/// A tree traversal event
///
public abstract class
TreeEvent<T>
{

internal
TreeEvent()
{
}

}



/// A node was visited while traversing a tree
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



/// A descent to a child node occurred while traversing a tree
///
public class
DescendTreeEvent<T>
    : TreeEvent<T>
{

internal
DescendTreeEvent()
{
}

}



/// An ascent to a parent node occurred while traversing a tree
///
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

