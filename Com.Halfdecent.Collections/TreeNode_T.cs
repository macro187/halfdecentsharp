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


using System.Collections.Generic;
using System.Linq;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Collections
{


/// <summary>
/// A tree node
/// </summary>
///
public class
TreeNode<T>
{


/// <summary>
/// Initialise a new <see cref="TreeNode<T>"/>
/// </summary>
///
public
TreeNode(
    T                       item,
    params TreeNode<T>[]    children
)
{
    NonNull.CheckParameter( item, "item" );
    children = children ?? new TreeNode<T>[]{};
    this.Item = item;
    this.Children = children;
}


/// <summary>
/// The item contained in the node
/// </summary>
///
public
    T
Item
{
    get;
    private set;
}


/// <summary>
/// The node's children
/// </summary>
///
public
    // TODO This should be ReadOnlyList<T> in .NET 4.5
    IList<TreeNode<T>>
Children
{
    get;
    private set;
}



}
}

