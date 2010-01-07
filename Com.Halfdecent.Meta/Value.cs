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


namespace
Com.Halfdecent.Meta
{


// =============================================================================
/// Reference to a value
// =============================================================================

public abstract class
Value
    : Halfdecent.IEquatable< Value >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
Value()
{
}



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Produce a reference to the value of a particular property of this value
///
public
Property
Property(
    string name
)
{
    return new Property( this, name );
}


/// Produce a reference to the value returned by this value's indexer
/// given a particular index
///
public
Indexer
Indexer(
    object index
)
{
    return new Indexer( this, index );
}


/// Produce a pseudo source code representation of this value reference
///
public abstract override
string
ToString();



// -----------------------------------------------------------------------------
// IEquatable< Value >
// -----------------------------------------------------------------------------

public virtual
bool
Equals(
    Value that
)
{
    return
        that != null &&
        that.GetType() == this.GetType();
}


public
bool
DirectionalEquals(
    Value that
)
{
    return this.Equals( that );
}


public override
int
GetHashCode()
{
    return this.GetType().GetHashCode();
}



// -----------------------------------------------------------------------------
// System.Object
// -----------------------------------------------------------------------------

public override sealed
bool
Equals(
    object that
)
{
    return
        that != null &&
        that is Value &&
        this.Equals( (Value)that );
}



// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// Format an object like a source code literal
///
public static
string
FormatLiteral(
    object value
)
{
    if( value == null ) return "null";
    if( value is string )
        return string.Concat( "\"", (string)value, "\"" );
    return value.ToString();
}




} // type
} // namespace

