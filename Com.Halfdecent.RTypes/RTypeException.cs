// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009
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
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// A value was found not to be of a particular <tt>RType</tt> when it was
/// required to be
// =============================================================================

public class
RTypeException
    : ValueException
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
RTypeException(
    IValue  valueReference,
    IRType  rType
)
    : this( valueReference, rType, null )
{
}


public
RTypeException(
    IValue      valueReference,
    IRType      rType,
    Exception   innerException
)
    : base( valueReference, null, innerException )
{
    if( valueReference == null )
        throw new ValueArgumentNullException(
            new Parameter( "valueReference" ) );
    if( rType == null )
        throw new ValueArgumentNullException( new Parameter( "rType" ) );
    this.RType = rType;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
IRType
RType
{
    get;
    private set;
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
    if( reference == null )
        throw new ValueArgumentNullException( new Parameter( "reference" ) );
    return this.RType.SayIsNot( reference );
}




//private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

