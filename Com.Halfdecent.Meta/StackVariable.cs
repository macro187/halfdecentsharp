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


using Com.Halfdecent.Globalisation;


namespace
Com.Halfdecent.Meta
{


// =============================================================================
/// A stack-allocated variable
// =============================================================================

public abstract class
StackVariable
    : IValueReferenceComponent
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
StackVariable(
    string name
    ///< The variable's name
    ///  - Non-null
    ///  - Non-blank
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
    return this.Name;
}



// -----------------------------------------------------------------------------
// IEquatable< IValueReferenceComponent >
// -----------------------------------------------------------------------------

public
    bool
Equals(
    IValueReferenceComponent that
)
{
    return Equatable.Equals< IValueReferenceComponent >( this, that );
}


public virtual
    bool
DirectionalEquals(
    IValueReferenceComponent that
)
{
    if( object.ReferenceEquals( that, null ) ) return false;
    return
        that.GetType() == this.GetType()
        && ((StackVariable)that).Name == this.Name;
}


public override
    int
GetHashCode()
{
    return
        this.GetType().GetHashCode()
        ^ this.Name.GetHashCode();
}




} // type
} // namespace
