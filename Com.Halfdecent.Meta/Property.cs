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


using Com.Halfdecent.Exceptions;


namespace
Com.Halfdecent.Meta
{


// =============================================================================
/// A property
// =============================================================================

public class
Property
    : MemberBase
{



internal
Property(
    IValue parent,
    string name
)
    : base( parent )
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
// MemberBase
// -----------------------------------------------------------------------------


protected override
string
ComponentToString()
{
    return string.Concat( ".", this.Name );
}


protected override
bool
ComponentEquals(
    IMember item
)
{
    return ((Property)item).Name == this.Name;
}


protected override
int
ComponentGetHashCode()
{
    return this.Name.GetHashCode();
}




} // type
} // namespace

