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
using Com.Halfdecent.Application;



namespace
Com.Halfdecent.CommandLine
{



/// <summary>
/// A <c>UserException</c> indicating that invalid command-line
/// argument(s) were passed to the program
/// </summary>
public class
CommandLineException
    : UserException
{




// -----------------------------------------------------------------------------
// Constants
// -----------------------------------------------------------------------------


// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// <summary>
/// Create a new <c>CommandLineException</c>
/// <summary>
public
CommandLineException()
    : this( Resource._S(
        typeof(CommandLineException),
        "Invalid commandline argument(s)" ) )
{
}


/// <summary>
/// Create a new <c>CommandLineException</c> with a given message
/// <summary>
public
CommandLineException(
    Localized<string> message
)
    : base( message )
{
}




} // type
} // namespace

