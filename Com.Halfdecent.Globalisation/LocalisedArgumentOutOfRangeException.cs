// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010
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


namespace
Com.Halfdecent.Globalisation
{


// =============================================================================
/// A <tt>System.ArgumentOutOfRangeException</tt> that is also an
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
    // Have to use this constructor and override ParamName and ActualValue
    // because there's no base constructor that takes all 4 parameters (!)
    : base( (string)message, innerException )
{
    this.message = message;
    this.paramname = paramName;
    this.actualvalue = actualValue;
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
// ArgumentOutOfRangeExceptionShim
// -----------------------------------------------------------------------------

protected override
string
ShimMessage
{
    get { return this.Message.InCurrent(); }
}



// -----------------------------------------------------------------------------
// ArgumentOutOfRangeException
// -----------------------------------------------------------------------------

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
// ArgumentException
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

