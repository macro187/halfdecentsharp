// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010
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


namespace
Com.Halfdecent.Meta
{


// =============================================================================
/// A source code literal
///
/// All <tt>Literal</tt> objects are considered equal
// =============================================================================

public class
Literal
    : IValueReferenceComponent
{



// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// Format an object like a C# source code literal
///
public static
    string
Format(
    object value
)
{
    if( value == null ) return "null";
    if( value is string )
        return string.Concat( "\"", (string)value, "\"" );
    return value.ToString();
}



// -----------------------------------------------------------------------------
// IValueReferenceComponent
// -----------------------------------------------------------------------------

public override
    string
ToString()
{
    return "(literal value)";
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
    return that.Is< Literal >();
}


public override
    int
GetHashCode()
{
    return typeof( Literal ).GetHashCode();
}




} // type
} // namespace

