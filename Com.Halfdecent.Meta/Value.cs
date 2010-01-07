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
/// IValue library
// =============================================================================

public static class
Value
{



// -----------------------------------------------------------------------------
// Methods
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



// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

public static
Property
Property(
    this IValue value,
    string      name
)
{
    if( value == null ) throw new LocalisedArgumentNullException( "value" );
    return new Property( value, name );
}


public static
Indexer
Indexer(
    this IValue value,
    object      index
)
{
    return new Indexer( value, index );
}




} // type
} // namespace

