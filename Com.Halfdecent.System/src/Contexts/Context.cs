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
Com.Halfdecent.Contexts
{




public static class
Context
{



/// Create and enter a new execution context
public static
IDisposable
Push()
{
    Debug.Print( "Context.Push()" );
    return new Handle();
}


/// Back out of the current execution context
public static
void
Pop()
{
    Debug.Print( "Context.Pop()" );
}



private class
Handle
    : IDisposable
{
    internal
    Handle() {}

    private
    bool
    disposed = false;

    public
    void
    Dispose()
    {
        Pop();
        this.disposed = true;
        //GC.SupressFinalize( this );
    }

    ~Handle()
    {
        if( !disposed )
            Debug.WriteLine(
                "WARNING: A Com.Halfdecent.Stack.Context.Handle was not"
                + " disposed properly" );
    }
}




} // type
} // namespace

