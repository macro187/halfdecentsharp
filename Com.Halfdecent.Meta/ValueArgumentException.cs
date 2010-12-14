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
using Com.Halfdecent.Globalisation;


namespace
Com.Halfdecent.Meta
{


// =============================================================================
/// An <tt>System.ArgumentException</tt> that is also an
/// <tt>IValueException</tt>
// =============================================================================

public class
ValueArgumentException
    : LocalisedArgumentException
    , IValueException
{



// -----------------------------------------------------------------------------
// Static
// -----------------------------------------------------------------------------

/// Natural language format string referring to an argument
///
public static readonly
Localised< string >
ARGUMENT_FORMAT = _S( "the {0} argument" );



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
ValueArgumentException(
    string paramName
)
    : this( paramName, null, null )
{
}


public
ValueArgumentException(
    string              paramName,
    Localised< string > messageFormat
)
    : this( paramName, messageFormat, null )
{
}


public
ValueArgumentException(
    string      paramName,
    Exception   innerException
)
    : this( paramName, null, innerException )
{
}


public
ValueArgumentException(
    string              paramName,
    ///< The name of the problematic parameter
    ///  - Must not be null
    ///  - Must not be blank
    Localised< string > messageFormat,
    ///< Natural language format describing the problem
    ///  {0} - Natural language referring to the problematic value
    Exception           innerException
    ///< The underlying cause of this exception, or <tt>null</tt> if there is
    ///  no underlying cause
)
    : base( null, paramName, innerException )
{
    if( object.ReferenceEquals( paramName, null ) )
        throw new LocalisedArgumentNullException( "paramName" );
    if( paramName == "" )
        throw new LocalisedArgumentException(
            "paramName is null", "paramName" );
    this.MessageFormat
        = messageFormat ?? ValueException.UNSPECIFIED_PROBLEM_FORMAT;
}



// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private
Localised< string >
MessageFormat;



// -----------------------------------------------------------------------------
// IValueException
// -----------------------------------------------------------------------------

public virtual
    Localised< string >
SayMessage(
    Localised< string > reference
)
{
    if( object.ReferenceEquals( reference, null ) )
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
    get { return this.SayMessage(
        LocalisedString.Format( ARGUMENT_FORMAT, this.ParamName ) ); }
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( typeof( ValueArgumentException ), s, args ); }

} // type
} // namespace

