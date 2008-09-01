// -----------------------------------------------------------------------------
// Copyright (c) 2008 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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
/// Base class for 1-term RTypes with single IsA supertypes and simple
/// IsA, IsNotA, and MustBe text
// =============================================================================
//
public abstract class
SimpleRTypeBase<
    TIsA
>
    : RTypeBase< TIsA >
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

protected
SimpleRTypeBase(
    Localised< string > isText,
    Localised< string > isNotText,
    Localised< string > mustBeText
)
{
    if( isText == null ) throw new BugException( "'isText' is null" );
    if( isNotText == null ) throw new BugException( "'isNotText' is null" );
    if( mustBeText == null ) throw new BugException( "'mustBeText' is null" );
    this.istext = isText;
    this.isnottext = isNotText;
    this.mustbetext = mustBeText;
}




// -----------------------------------------------------------------------------
// RType1Base
// -----------------------------------------------------------------------------

public override
Localised< string >
SayIs(
    Localised< string > reference
)
{
    NonNull.SCheck( reference, SAYIS_REFERENCE );
    return LocalisedString.Format( this.istext, reference );
}

private static readonly Parameter
SAYIS_REFERENCE = new Parameter( "reference" );

private
Localised< string >
istext;



public override
Localised< string >
SayIsNot(
    Localised< string > reference
)
{
    NonNull.SCheck( reference, SAYISNOT_REFERENCE );
    return LocalisedString.Format( this.isnottext, reference );
}

private static readonly Parameter
SAYISNOT_REFERENCE = new Parameter( "reference" );

private
Localised< string >
isnottext;



public override
Localised< string >
SayMustBe(
    Localised< string > reference
)
{
    NonNull.SCheck( reference, SAYMUSTBE_REFERENCE );
    return LocalisedString.Format( this.mustbetext, reference );
}

private static readonly Parameter
SAYMUSTBE_REFERENCE = new Parameter( "reference" );

private
Localised< string >
mustbetext;




} // type
} // namespace

