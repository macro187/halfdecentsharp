// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010
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


using System;


namespace
Com.Halfdecent.Globalisation
{


// =============================================================================
/// INTERNAL: Shim that "renames" <tt>Message</tt> to <tt>BaseMessage</tt>,
/// enabling <tt>Message</tt> to be, effectively, both overridden and shadowed
/// in a subclass
// =============================================================================

public abstract class
ExceptionShim
    : Exception
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
ExceptionShim(
    string      message,
    Exception   innerException
)
    : base( message, innerException )
{
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

override public
string
Message
{
    get { return this.ShimMessage; }
}



// -----------------------------------------------------------------------------
// Protected
// -----------------------------------------------------------------------------

abstract protected
string
ShimMessage
{
    get;
}


protected
string
BaseMessage
{
    get { return base.Message; }
}




} // type
} // namespace

