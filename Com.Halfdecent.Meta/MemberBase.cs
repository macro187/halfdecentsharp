// -----------------------------------------------------------------------------
// Copyright (c) 2009
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
using Com.Halfdecent.Exceptions;


namespace
Com.Halfdecent.Meta
{


// =============================================================================
/// Base class for implementing member variables
// =============================================================================

public abstract class
MemberBase
    : IMember
{



protected
MemberBase(
    IValue parent
)
{
    if( parent == null ) throw new LocalisedArgumentNullException( "parent" );
    this.Parent = parent;
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
    IMember item
);


protected abstract
int
ComponentGetHashCode();



// -----------------------------------------------------------------------------
// IMember
// -----------------------------------------------------------------------------

public
IValue
Parent
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// Object
// -----------------------------------------------------------------------------

public override sealed
string
ToString()
{
    return
        string.Concat(
            this.Parent.ToString(),
            this.ComponentToString() );
}


public override sealed
bool
Equals(
    object item
)
{
    return
        item != null &&
        this.GetType() == item.GetType() &&
        this.ComponentEquals( (IMember)item ) &&
        this.Parent.Equals( ((IMember)item).Parent );
}


public override sealed
int
GetHashCode()
{
    return
        this.GetType().GetHashCode() ^
        this.ComponentGetHashCode() ^
        this.Parent.GetHashCode();
}




} // type
} // namespace

