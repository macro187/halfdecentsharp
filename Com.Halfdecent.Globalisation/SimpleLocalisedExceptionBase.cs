// -----------------------------------------------------------------------------
// Copyright (c) 2008 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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
Com.Halfdecent.Globalisation
{



// =============================================================================
/// Base class for implementing <tt>ILocalisedException</tt>s with a simple
/// <tt>Message</tt>
// =============================================================================
///
public abstract class
SimpleLocalisedExceptionBase
    :LocalisedExceptionBase
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
SimpleLocalisedExceptionBase(
    Localised< string > message
)
    : this( message, null )
{
}



public
SimpleLocalisedExceptionBase(
    Localised< string > message,
    Exception           innerException
)
    : base( innerException )
{
    if( message == null )
        throw new Exception( "SimpleLocalisedExceptionBase subclasses are required to provide a message" );
    this.message = message;
}




// -----------------------------------------------------------------------------
// ILocalisedException
// -----------------------------------------------------------------------------

public override
Localised< string >
Message
{
    get { return this.message; }
}

private
Localised< string >
message;




} // type
} // namespace
