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

using Com.Halfdecent.System.Globalization;



namespace
Com.Halfdecent.System
{



/// <summary>
/// Deluxe <c>Exception</c>
/// </summary>
/// <remarks>
/// <p>
/// Features:
/// - Localized <c>Message</c> (<c>ILocalizedException</c>)
/// - Context stack (<c>IHasContext</c>) for tracking what was being worked
///   on when the exception occurred
/// </p>
/// <p>
/// Useful if your exception would normally derive from <c>Exception</c>.
/// Subclasses of other kinds of exceptions will have to be coded long-hand, or
/// wait until an automated traits mechanism is developed.
/// </p>
/// </remarks>
public class
DeluxeException
    : DeluxeExceptionShim
    , ILocalizedException
//    , IHasContext
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// <summary>
/// Create a new <c>DeluxeException</c> with a given message
/// <summary>
public
DeluxeException(
    Localized<string> message
)
    : this( message, null )
{
    this.message = message;
}


/// <summary>
/// Create a new <c>DeluxeException</c> with a given message and inner
/// exception
/// <summary>
public
DeluxeException(
    Localized<string> message,
    Exception innerexception
)
    : base( message, innerexception )
{
    this.message = message;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// <summary>
/// Message
/// </summary>
new public Localized<string>
Message
{
    get { return this.message; }
}

private Localized<string>
message;



/// <summary>
/// INTERNAL: Hook up <c>Exception.Message</c> to our localized <c>Message</c>
/// </summary>
protected override string
BaseMessage
{
    get { return this.Message; }
}




} // type




/// <summary>
/// INTERNAL:
/// Shim to rename/redirect <c>Message</c> so we can effectively both
/// override and shadow it in subclasses
/// </summary>
public abstract class
DeluxeExceptionShim
    : Exception
{

internal
DeluxeExceptionShim(
    string      message,
    Exception   innerexception
)
    : base( message, innerexception )
{
}

override public string
Message
{
    get { return this.BaseMessage; }
}

abstract protected string
BaseMessage
{
    get;
}

} // DeluxeExceptionShim




} // namespace

