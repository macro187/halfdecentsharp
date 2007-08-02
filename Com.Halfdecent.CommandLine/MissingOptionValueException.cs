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
using Com.Halfdecent.System.Resources;



namespace
Com.Halfdecent.CommandLine
{



/// <summary>
/// An value was not specified for an option that required one
/// </summary>
public class
MissingOptionValueException
    : CommandLineException
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// <summary>
/// Create a new <c>MissingOptionValueException</c>
/// <summary>
/// <param name="option">
/// The option that was missing a value
/// </param>
public
MissingOptionValueException( string option )
    : this( Resource._S(
        typeof(MissingOptionValueException),
        "The '{0}' option requires a value",
        option ) )
{
}


/// <summary>
/// Create a new <c>MissingOptionValueException</c> with a given message
/// <summary>
public
MissingOptionValueException(
    Localized<string> message
)
    : base( message )
{
}




} // type
} // namespace

