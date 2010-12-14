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
/// An exception having to do with a particular value
// =============================================================================

public class
ValueException
    : LocalisedException
    , IValueException
{



// -----------------------------------------------------------------------------
// Static
// -----------------------------------------------------------------------------

/// Natural language referring to an unspecified value
///
public static readonly
Localised< string >
UNSPECIFIED_VALUE
    = _S( "an unspecified value" );


/// Natural language format describing an unspecified problem
///
public static readonly
Localised< string >
UNSPECIFIED_PROBLEM_FORMAT
    = _S( "Unable to proceed due to an unspecified problem with {0}" );



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
ValueException()
    : this( null, null )
{
}


public
ValueException(
    Localised< string > messageFormat
)
    : this( messageFormat, null )
{
}


public
ValueException(
    Exception innerException
)
    : this( null, innerException )
{
}


public
ValueException(
    Localised< string > messageFormat,
    ///< Natural language format describing the problem
    ///  {0} - Natural language referring to the problematic value
    Exception           innerException
    ///< The underlying cause of this exception, or <tt>null</tt> if there is
    ///  no underlying cause
)
    : base( null, innerException )
{
    this.MessageFormat = messageFormat ?? UNSPECIFIED_PROBLEM_FORMAT;
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
    get { return this.SayMessage( UNSPECIFIED_VALUE ); }
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

