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



namespace
Com.Halfdecent.System.Globalization
{



/// <summary>
/// Convenience base class for localized <c>Exception</c> subclasses
/// </summary>
public class
LocalizedException
    : LocalizedExceptionShim
    , ILocalizedException
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// <summary>
/// Create a new <c>LocalizedException</c> with a given message
/// <summary>
public
LocalizedException(
    Localized<string> message
)
    : this( message, null )
{
    this.message = message;
}


/// <summary>
/// Create a new <c>LocalizedException</c> with a given message and inner
/// exception
/// <summary>
public
LocalizedException(
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



/// <summary>
/// INTERNAL: Return a <c>string</c> if being used as a plain <c>Exception</c>,
/// see <c>LocalizedExceptionShim</c>
/// </summary>
protected override string
BaseMessage
{
    get { return this.Message; }
}




// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private Localized<string>
message;




} // type




/// <summary>
/// INTERNAL:
/// Shim to rename/redirect <c>Message</c> so we can effectively both
/// override and shadow it in <c>LocalizedException</c>
/// </summary>
public abstract class
LocalizedExceptionShim
    : Exception
{

internal
LocalizedExceptionShim(
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

}




} // namespace

