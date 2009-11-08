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


using System.Collections.Generic;
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Meta;
using Com.Halfdecent.Exceptions;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// Abstract base class for implementing RTypes with simple IsA, IsNotA, and
/// MustBe text
// =============================================================================

public abstract class
SimpleTextRTypeBase<
    T
>
    : RTypeBase< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

protected
SimpleTextRTypeBase(
    Localised< string > isFormat,
    ///< Format string to use for <tt>SayIs()</tt>
    ///  - {0} Reference to the item
    Localised< string > isNotFormat,
    ///< Format string to use for <tt>SayIsNot()</tt>
    ///  - {0} Reference to the item
    Localised< string > mustBeFormat
    ///< Format string to use for <tt>SayMustBe()</tt>
    ///  - {0} Reference to the item
)
{
    if( isFormat == null )
        throw new LocalisedArgumentNullException( "isFormat" );
    if( isNotFormat == null )
        throw new LocalisedArgumentNullException( "isNotFormat" );
    if( mustBeFormat == null )
        throw new LocalisedArgumentNullException( "mustBeFormat" );
    this.IsFormat = isFormat;
    this.IsNotFormat = isNotFormat;
    this.MustBeFormat = mustBeFormat;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

private
Localised< string >
IsFormat
{
    get;
    set;
}


private
Localised< string >
IsNotFormat
{
    get;
    set;
}


private
Localised< string >
MustBeFormat
{
    get;
    set;
}



// -----------------------------------------------------------------------------
// IRType
// -----------------------------------------------------------------------------

public override
Localised< string >
SayIs(
    Localised< string > reference
)
{
    if( reference == null )
        throw new LocalisedArgumentNullException( "reference" );
    return LocalisedString.Format( this.IsFormat, reference );
}


public override
Localised< string >
SayIsNot(
    Localised< string > reference
)
{
    if( reference == null )
        throw new LocalisedArgumentNullException( "reference" );
    return LocalisedString.Format( this.IsNotFormat, reference );
}


public override
Localised< string >
SayMustBe(
    Localised< string > reference
)
{
    if( reference == null )
        throw new LocalisedArgumentNullException( "reference" );
    return LocalisedString.Format( this.MustBeFormat, reference );
}




} // type
} // namespace

