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
/// A <tt>System.ArgumentNullException</tt> that is also an
/// <tt>ILocalisedException</tt>
// =============================================================================

public class
LocalisedArgumentNullException
    : ArgumentNullExceptionShim
    , ILocalisedException
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
LocalisedArgumentNullException()
    : this( null, null, null )
{
}


public
LocalisedArgumentNullException(
    string paramName
)
    : this( paramName, null, null )
{
}


public
LocalisedArgumentNullException(
    Localised< string > message,
    Exception           innerException
)
    : this( null, message, innerException )
{
}


public
LocalisedArgumentNullException(
    string              paramName,
    Localised< string > message
)
    : this( paramName, message, null )
{
}


public
LocalisedArgumentNullException(
    string              paramName,
    Localised< string > message,
    Exception           innerException
)
    // Have to use this constructor and override ParamName because there's no
    // base constructor that takes all 3 parameters (!)
    : base( message, innerException )
{
    this.paramname = paramName;
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



// -----------------------------------------------------------------------------
// ArgumentNullExceptionShim
// -----------------------------------------------------------------------------

protected override
string
ShimMessage
{
    get { return this.Message; }
}



// -----------------------------------------------------------------------------
// ArgumentNullException
// -----------------------------------------------------------------------------

public override
string
ParamName
{
    get { return this.paramname; }
}

private
string
paramname;




} // type
} // namespace

