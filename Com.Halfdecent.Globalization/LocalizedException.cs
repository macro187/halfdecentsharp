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
Com.Halfdecent.Globalization
{



/// <summary>
/// An exception whose <c>Message</c> is a <c>Localized&lt;string&gt;
/// </summary>
public class
LocalizedException
    : Exception
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
    this.localizedmessage = message;
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
    this.localizedmessage = message;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// <summary>
/// Localized message
/// </summary>
new public Localized<string>
Message
{
    get { return this.localizedmessage; }
}




// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private Localized<string>
localizedmessage;



} // type
} // namespace

