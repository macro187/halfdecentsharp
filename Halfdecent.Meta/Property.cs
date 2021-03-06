// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010, 2012
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
using Halfdecent.Globalisation;


namespace
Halfdecent.Meta
{


// =============================================================================
/// Reference to a part of a value through a property
// =============================================================================

public class
Property
    : Member
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
Property(
    string  name
)
{
    if( name == null ) throw new LocalisedArgumentNullException( "name" );
    if( name == "" ) throw new LocalisedArgumentException( "Is blank", "name" );
    this.Name = name;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
string
Name
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// IValueReferenceComponent
// -----------------------------------------------------------------------------

public override
    string
ToString()
{
    return string.Concat( ".", this.Name );
}



// -----------------------------------------------------------------------------
// IEquatableHD< IValueReferenceComponent >
// IEquatable< IValueReferenceComponent >
// -----------------------------------------------------------------------------

public override
    bool
Equals(
    IValueReferenceComponent that
)
{
    return that.Is<
        Property >(
        p => p.Name == this.Name );
}


public override
    int
GetHashCode()
{
    return
        base.GetHashCode() ^
        this.Name.GetHashCode();
}



// -----------------------------------------------------------------------------
// Object
// -----------------------------------------------------------------------------

public override
    bool
Equals(
    object that
)
{
    throw new NotSupportedException();
}




} // type
} // namespace

