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
/// An <tt>IValueNullException</tt> that is also a
/// <tt>System.ArgumentNullException</tt>
// =============================================================================

public class
ValueArgumentNullException
    : LocalisedArgumentNullException
    , IValueException
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
ValueArgumentNullException(
    Parameter           parameter
    ///< Reference to the parameter whose value caused the exception
)
    : this( parameter, null, null )
{
}


public
ValueArgumentNullException(
    Parameter           parameter,
    ///< Reference to the parameter whose value caused the exception
    Localised< string > messageFormat
    ///< Format string used to <tt>SayMessage()</tt>
    ///
    ///  {0} - Natural language referring to the problematic parameter
)
    : this( parameter, messageFormat, null )
{
}


public
ValueArgumentNullException(
    Parameter           parameter,
    ///< Reference to the parameter whose value caused the exception
    Localised< string > messageFormat,
    ///< Format string used to <tt>SayMessage()</tt>
    ///
    ///  {0} - Natural language referring to the problematic parameter
    Exception           innerException
)
    : base(
        parameter != null ? parameter.Name : "",
        null,
        innerException )
{
    if( parameter == null )
        throw new LocalisedArgumentNullException( "parameter" );
    this.Parameter = parameter;
    this.MessageFormat = messageFormat ?? _S("{0} is null");
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// Reference to the parameter whose value caused the exception
///
public
Parameter
Parameter
{
    get;
    private set;
}


/// Format string used to <tt>SayMessage()</tt>
///
/// {0} - Natural language referring to the problematic parameter
///
public
Localised< string >
MessageFormat
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// IValueException
// -----------------------------------------------------------------------------

public virtual
Localised< string >
SayMessage(
    Localised< string > reference
)
{
    if( reference == null )
        throw new LocalisedArgumentNullException( "reference" );
    return LocalisedString.Format( this.MessageFormat, reference );
}


Value
IValueException.ValueReference
{
    get { return this.Parameter; }
}



// -----------------------------------------------------------------------------
// ILocalisedException
// -----------------------------------------------------------------------------

public override
Localised< string >
Message
{
    get { return this.SayMessage( this.Parameter.ToString() ); }
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

