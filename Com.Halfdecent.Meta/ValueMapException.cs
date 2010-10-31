// -----------------------------------------------------------------------------
// Copyright (c) 2010
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
/// An exception that translates another exception's <tt>.ValueReference</tt> to
/// the current context
// =============================================================================

public class
ValueMapException
    : ValueException
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
ValueMapException(
    Value       valueReference,
    Exception   innerException
    ///< - Must be an <tt>IValueException</tt>
)
    : base( valueReference, innerException )
{
    if( object.ReferenceEquals( innerException, null ) )
        throw new LocalisedArgumentNullException( "innerException" );
    if( !( innerException is IValueException ) )
        throw new LocalisedArgumentException(
            _S("innerException is not an IValueException"),
            "innerException" );
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
IValueException
InnerValueException
{
    get { return (IValueException)this.InnerException; }
}



// -----------------------------------------------------------------------------
// IValueException
// -----------------------------------------------------------------------------

public override
    Localised< string >
SayMessage(
    Localised< string > reference
)
{
    return this.InnerValueException.SayMessage( reference );
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( typeof( ValueMapException ), s, args ); }

} // type
} // namespace

