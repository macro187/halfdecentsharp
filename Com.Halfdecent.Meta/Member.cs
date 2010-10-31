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
/// Reference to a member variable
// =============================================================================

public abstract class
Member
    : Value
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
Member(
    Value parent
)
{
    if( parent == null ) throw new LocalisedArgumentNullException( "parent" );
    this.Parent = parent;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// The <tt>Value</tt> that this one is a member of
///
public
Value
Parent
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

protected abstract
    string
ComponentToString();


protected abstract
    bool
ComponentEquals(
    Member that
);



// -----------------------------------------------------------------------------
// Value
// -----------------------------------------------------------------------------

public override
    string
ToString()
{
    return
        string.Concat(
            this.Parent.ToString(),
            this.ComponentToString() );
}


public override
    bool
Equals(
    Value that
)
{
    return
        base.Equals( that ) &&
        ((Member)that).Parent.Equals( this.Parent ) &&
        this.ComponentEquals( (Member)that );
}



// -----------------------------------------------------------------------------
// Object
// -----------------------------------------------------------------------------

public override
    int
GetHashCode()
{
    return
        base.GetHashCode() ^
        this.Parent.GetHashCode();
}




} // type
} // namespace

