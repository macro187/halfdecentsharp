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

using Com.Halfdecent.Resources;
using Com.Halfdecent.Globalization;



namespace
Com.Halfdecent.CommandLine
{



/// <summary>
/// An illegal command-line option was passed
/// </summary>
public class
UnrecognizedOptionException
    : CommandLineException
{




// -----------------------------------------------------------------------------
// Constants
// -----------------------------------------------------------------------------


// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// <summary>
/// Create a new <c>UnrecognizedOptionException</c>
/// <summary>
/// <param name="option">
/// The illegal option
/// </param>
public
UnrecognizedOptionException( string option )
    : this( Resource._S(
        typeof(UnrecognizedOptionException),
        "This program does not understand the '{0}' command-line option",
        option ) )
{
}


/// <summary>
/// Create a new <c>UnrecognizedOptionException</c> with a given message
/// <summary>
public
UnrecognizedOptionException(
    Localized<string> message
)
    : base( message )
{
}




} // type
} // namespace

