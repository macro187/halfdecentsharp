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
Com.Halfdecent.Application
{



/// <summary>
/// A user-level error
/// </summary>
/// <remarks>
/// <p>
/// This exception indicates that something (anticipated by the developer)
/// went wrong.  It includes (potentially localized) details to be displayed
/// to the user.
/// </p>
/// <p>
/// This exception is intended to represent errors that are not the program's
/// fault and that the user might be able to do something about (eg. arguments,
/// input, environment), versus other unhandled exceptions which tend to
/// indicate bugs or oversights on the part of the developer.
/// </p>
/// </remarks>
public class
UserException
    : LocalizedException
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// <summary>
/// Create a new <c>UserException</c> with a given message to the user
/// <summary>
public
UserException(
    Localized<string> message
)
    : base( message )
{
}



/// <summary>
/// Create a new <c>UserException</c> with a given message and inner
/// exception
/// <summary>
public
UserException(
    Localized<string> message,
    Exception innerexception
)
    : base( message, innerexception )
{
}




} // type
} // namespace

