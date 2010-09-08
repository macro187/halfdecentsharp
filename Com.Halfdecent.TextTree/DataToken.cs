// -----------------------------------------------------------------------------
// Copyright (c) 2010
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


using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.TextTree
{


// =============================================================================
/// A TextTree lexer token indicating a data node
// =============================================================================

public class
DataToken
    : Token
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
DataToken(
    string data
)
    : base()
{
    new NonNull().Require( data, new Parameter( "data" ) );
    this.Data = data;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
    string
Data
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// Token
// -----------------------------------------------------------------------------

public override
    bool
Equals(
    Token that
)
{
    if( !base.Equals( that ) ) return false;
    if( ((DataToken)( that )).Data != this.Data ) return false;
    return true;
}



// -----------------------------------------------------------------------------
// Object
// -----------------------------------------------------------------------------

public override
    int
GetHashCode()
{
    return base.GetHashCode() ^ this.Data.GetHashCode();
}




} // type
} // namespace

