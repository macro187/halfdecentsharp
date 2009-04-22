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
using Com.Halfdecent.Exceptions;


namespace
Com.Halfdecent.Meta
{


// =============================================================================
/// A <tt>System.ArgumentNullException</tt> having to do with a particular value
// =============================================================================

public class
ArgumentNullValueException
    : LocalisedArgumentNullException
    , IValueException
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
ArgumentNullValueException(
    Parameter parameterReference
)
    : this( parameterReference, null, null )
{
}


public
ArgumentNullValueException(
    Parameter           parameterReference,
    Localised< string > messageFormat
)
    : this( parameterReference, messageFormat, null )
{
}


public
ArgumentNullValueException(
    Parameter           parameterReference,
    Localised< string > messageFormat,
    Exception           innerException
)
    : base(
        parameterReference != null ? parameterReference.Name : null,
        null,
        innerException )
{
    if( parameterReference == null )
        throw new LocalisedArgumentNullException( "parameterReference" );
    this.parameterreference = parameterReference;
    this.messageformat =
        messageFormat ?? _S("Unable to proceed because {0} is null");
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
Parameter
ParameterReference
{
    get { return this.parameterreference; }
}

private
Parameter
parameterreference;


public
Localised< string >
MessageFormat
{
    get { return this.messageformat; }
}

private
Localised< string >
messageformat;



// -----------------------------------------------------------------------------
// IValueException
// -----------------------------------------------------------------------------

public
IValue
ValueReference
{
    get { return this.parameterreference; }
}


public
Localised< string >
SayMessage(
    Localised< string > reference
)
{
    if( reference == null )
        throw new LocalisedArgumentNullException( "reference" );
    return LocalisedString.Format( this.MessageFormat, reference );
}



// -----------------------------------------------------------------------------
// ILocalisedException
// -----------------------------------------------------------------------------

public override
Localised< string >
Message
{
    get { return this.SayMessage( this.ParameterReference.ToString() ); }
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

