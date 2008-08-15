// -----------------------------------------------------------------------------
// Copyright (c) 2008 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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
using System.Diagnostics;

namespace
Com.Halfdecent.Meta
{



/// An execution context
///
public class
Context
{




public
Context()
{
}




// -----------------------------------------------------------------------------
// IDisposable
// -----------------------------------------------------------------------------

public
void
Dispose()
{
    if( disposed )
        throw new InvalidOperationException(
            "This Context has already been Dispose()d" );
    if( this != Stack.Current )
        throw new InvalidOperationException(
            "Can't Dispose() this Context because it isn't Stack.Current" );
    Stack.Pop();
    this.disposed = true;
}

private
bool
disposed = false;




} // type
} // namespace

