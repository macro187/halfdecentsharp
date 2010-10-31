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
// Constructors
// -----------------------------------------------------------------------------

public
ValueException(
    Value valueReference
    ///< Reference to the value that caused the exception
)
    : this( valueReference, null, null )
{
}


public
ValueException(
    Value               valueReference,
    ///< Reference to the value that caused the exception
    Localised< string > messageFormat
    ///< Format string used to <tt>SayMessage()</tt>
    ///
    ///  {0} - Natural language referring to the problematic value
)
    : this( valueReference, messageFormat, null )
{
}


public
ValueException(
    Value               valueReference,
    ///< Reference to the value that caused the exception
    Localised< string > messageFormat,
    ///< Format string used to <tt>SayMessage()</tt>
    ///
    ///  {0} - Natural language referring to the problematic value
    Exception           innerException
    ///< Another exception that is the underlying cause of this one, or
    ///  <tt>null</tt> if there is no such underlying cause
)
    : base( null, innerException )
{
    if( valueReference == null )
        throw new LocalisedArgumentNullException( "valueReference" );
    this.ValueReference = valueReference;
    this.MessageFormat = messageFormat ?? _S("Unable to proceed due to {0}");
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

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


public
Value
ValueReference
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// ILocalisedException
// -----------------------------------------------------------------------------

public override
Localised< string >
Message
{
    get { return this.SayMessage( this.ValueReference.ToString() ); }
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( typeof( ValueException ), s, args ); }

} // type
} // namespace

