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
using R = Com.Halfdecent.Resources.Resource;
using Com.Halfdecent.Exceptions;

using System_Exception = System.Exception;
using HD_Exception = Com.Halfdecent.Exceptions.Exception;


namespace
Com.Halfdecent.System
{




/// Exception indicating that a condition was encountered at runtime that
/// indicates a programming error
///
public class
BugException
    : HD_Exception
{




/// Initialise a new <tt>BugException</tt> with a given message
///
public
BugException(
    Localized< string > message
)
    : this( message, null )
{
}



/// Initialise a new <tt>BugException</tt> with a given inner exception
/// indicating the underlying reason for this exception
///
public
BugException(
    System_Exception innerException
)
    : this( null, innerException )
{
}



/// Initialise a new <tt>BugException</tt> with a given message and inner
/// exception indicating the underlying reason for this exception
///
public
BugException(
    Localized< string > message,
    System_Exception    innerException
)
    : base(
        (message != null
            ? message
            : (innerException != null
                ? (innerException is IException
                    ? ((IException)innerException).Message
                    : (Localized< string >)innerException.Message
                )
                : R._S("A condition indicating a programming error was encountered")
            )
        ),
        innerException )
{
}




} // type
} // namespace

