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

using System_Exception = System.Exception;


namespace
Com.Halfdecent.Exceptions
{




/// Exception class to be used instead of <tt>System.Exception</tt>
///
public class
Exception
    : ExceptionShim
    , IException
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Create a new <tt>Exception</tt> with a given message
///
public
Exception(
    Localized< string > message
)
    : this( message, null )
{
}



/// Create a new <tt>Exception</tt> with a given message and inner
/// exception
///
public
Exception(
    Localized< string > message,
    System_Exception    innerException
)
    : base( message, innerException )
{
    this.message = message;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// A message explaining the reason for the exception
///
new virtual public
Localized< string >
Message
{
    get { return this.message; }
}

private
Localized< string >
message;



/// Override of <tt>Exception.Message</tt> via <tt>ExceptionShim</tt>
protected override
string
BaseMessage
{
    get { return this.Message; }
}




} // type
} // namespace
