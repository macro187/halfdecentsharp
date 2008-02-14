// -----------------------------------------------------------------------------
// Copyright (c) 2007 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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
using Com.Halfdecent.System;


namespace
Com.Halfdecent.Context
{




/// ICallContext implementation
public class
CallContext
    : ICallContext
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialize a new CallContext with a given depth and method name
public
CallContext(
    int     depth,  ///< (See ICallContext.Depth)
    string  name    ///< (See ICallContext.Name)
)
{
    new IsPresent().Demand( name );
    new IsNotBlank().Demand( name );
    this.depth = depth;
    this.name = name;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// (See ICallContext.Depth)
public int
Depth
{
    get { return this.depth; }
}

private int
depth;



/// (See ICallContext.Name)
public string
Name
{
    get { return this.name; }
}

private string
name;




} // type
} // namespace

