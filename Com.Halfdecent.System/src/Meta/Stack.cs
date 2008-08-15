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

namespace
Com.Halfdecent.Meta
{



// =============================================================================
/// Execution stack
// =============================================================================
//
public static class
Stack
{




// -----------------------------------------------------------------------------
// Static Constructor
// -----------------------------------------------------------------------------

static
Stack()
{
    stack.Push();
}




// -----------------------------------------------------------------------------
// Static Properties
// -----------------------------------------------------------------------------

// The current context
public static
Context
Current
{
    get
    {
        if( stack.Count <= 0 )
            throw new InvalidOperationException(
                "Can't get Current because stack is empty" );
        return stack[ stack.Count-1 ];
    }
}




// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// Push a new <tt>Context</tt> onto the stack
///
public static
Context
/// @returns The newly-pushed <tt>Context</tt>
Push()
{
    Context c = new Context();
    stack.Add( c );
    return c;
}



/// Pop the last context off the stack
///
internal static
void
Pop()
{
    if( stack.Count <= 1 )
        throw new InvalidOperationException(
            "Can't Pop() the root Context" );
    stack.RemoveAt( stack.Count-1 );
}




// -----------------------------------------------------------------------------
// Static Privates
// -----------------------------------------------------------------------------

private static
List< Context >
stack = new List< Context >();




} // type
} // namespace

