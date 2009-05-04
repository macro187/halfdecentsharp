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
LocalisedArgumentOutOfRangeException
    : ArgumentOutOfRangeExceptionShim
    , ILocalisedException
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
LocalisedArgumentOutOfRangeException()
    : this( null, null, null, null )
{
}


public
LocalisedArgumentOutOfRangeException(
    string paramName
)
    : this( paramName, null, null, null )
{
}


public
LocalisedArgumentOutOfRangeException(
    Localised< string > message,
    Exception           innerException
)
    : this( null, null, message, innerException )
{
}


public
LocalisedArgumentOutOfRangeException(
    string              paramName,
    Localised< string > message
)
    : this( paramName, null, message, null )
{
}


public
LocalisedArgumentOutOfRangeException(
    string              paramName,
    object              actualValue,
    Localised< string > message
)
    : this( paramName, actualValue, message, null )
{
}


public
LocalisedArgumentOutOfRangeException(
    string              paramName,
    object              actualValue,
    Localised< string > message,
    Exception           innerException
)
    : base( message, innerException )
{
    this.message = message;
    this.paramname = paramName;
    this.actualvalue = actualValue;
}



// -----------------------------------------------------------------------------
// Properties
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


public override
object
ActualValue
{
    get { return this.actualvalue; }
}

private
object
actualvalue;



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
