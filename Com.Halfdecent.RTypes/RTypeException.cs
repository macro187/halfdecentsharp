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
    : LocalisedException
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
RTypeException(
    object  value,
    IValue  valueReference,
    IRType  rType
)
    : this( value, valueReference, rType, null )
{
}


public
RTypeException(
    object      value,
    IValue      valueReference,
    IRType      rType,
    Exception   innerException
)
    : base( null, innerException )
{
    if( valueReference == null )
        throw new LocalisedArgumentNullException( "valueReference" );
    if( rType == null )
        throw new LocalisedArgumentNullException( "rType" );
    this.value = value;
    this.valuereference = valueReference;
    this.rtype = rType;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
object
Value
{
    get { return this.value; }
}

private
object
value;


public
IValue
ValueReference
{
    get { return this.valuereference; }
}

private
IValue
valuereference;


public
IRType
RType
{
    get { return this.rtype; }
}

private
IRType
rtype;



// -----------------------------------------------------------------------------
// LocalisedException
// -----------------------------------------------------------------------------

override public
Localised< string >
Message
{
    get
    {
        return this.RType.SayIsNot(
            string.Format( "{0}", this.ValueReference.ToString() ) );
    }
}




//private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

