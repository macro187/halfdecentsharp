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
using Com.Halfdecent.Globalization;


namespace
Com.Halfdecent.System
{




/// INTERNAL: Shim to effectively rename <tt>Message</tt> to
/// <tt>BaseMessage</tt> so we can effectively provide both a new and
/// overridden <tt>Message</tt> later
///
public abstract class
ExceptionShim
    : Exception
{



internal
ExceptionShim(
    string              message,
    Exception           innerException
)
    : base( message, innerException )
{
}



override public
string
Message
{
    get { return this.BaseMessage; }
}



abstract protected
string
BaseMessage
{
    get;
}




} // type
} // namespace

