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
/// An <tt>System.ArgumentNullException</tt> that is also an
/// <tt>IValueException</tt>
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
    string paramName
)
    : this( paramName, null )
{
}


public
ValueArgumentNullException(
    string      paramName,
    ///< The name of the problematic parameter
    ///  - Must not be null
    ///  - Must not be blank
    Exception   innerException
    ///< The underlying cause of this exception, or <tt>null</tt> if there is
    ///  no underlying cause
)
    : base( paramName, null, innerException )
{
    if( object.ReferenceEquals( paramName, null ) )
        throw new LocalisedArgumentNullException( "paramName" );
    if( paramName == "" )
        throw new LocalisedArgumentException(
            "paramName is null", "paramName" );
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
    if( object.ReferenceEquals( reference, null ) )
        throw new LocalisedArgumentNullException( "reference" );
    return LocalisedString.Format(
        _S("{0} is null"),
        reference );
}



// -----------------------------------------------------------------------------
// ILocalisedException
// -----------------------------------------------------------------------------

public override
Localised< string >
Message
{
    get { return this.SayMessage(
        LocalisedString.Format(
            ValueArgumentException.ARGUMENT_FORMAT,
            this.ParamName ) ); }
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

