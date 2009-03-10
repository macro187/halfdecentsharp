// -----------------------------------------------------------------------------
// Copyright (c) 2009
// Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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
using Com.Halfdecent.Globalisation;


namespace
Com.Halfdecent.Exceptions
{


// =============================================================================
/// <tt>System.ArgumentException</tt> that implements
/// <tt>ILocalisedException</tt>
// =============================================================================

public class
LocalisedArgumentException
    : ArgumentExceptionShim
    , ILocalisedException
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
LocalisedArgumentException()
    : this( null, null, null )
{
}


public
LocalisedArgumentException(
    Localised< string > message
)
    : this( message, null, null )
{
}


public
LocalisedArgumentException(
    Localised< string > message,
    Exception           innerException
)
    : base( message, null, innerException )
{
}


public
LocalisedArgumentException(
    Localised< string > message,
    string              paramName
)
    : base( message, paramName, null )
{
}


public
LocalisedArgumentException(
    Localised< string > message,
    string              paramName,
    Exception           innerException
)
    : base( message, paramName, innerException )
{
    this.message = message;
}



// -----------------------------------------------------------------------------
// ILocalisedException
// -----------------------------------------------------------------------------

new public virtual
Localised< string >
Message
{
    get { return this.message ?? this.BaseMessage; }
}

private
Localised< string >
message;


protected override
string
ShimMessage
{
    get { return this.Message; }
}




} // type
} // namespace

