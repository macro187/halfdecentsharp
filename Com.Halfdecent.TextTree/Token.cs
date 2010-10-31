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


namespace
Com.Halfdecent.TextTree
{


// =============================================================================
/// A TextTree lexer token
///
/// @section equality Equality
///
///     Contextual information such as line numbers is not considered in token
///     equality
// =============================================================================

public abstract class
Token
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
Token()
    : this( 0 )
{
}


internal
Token(
    int lineNumber
)
{
    this.LineNumber = lineNumber;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
int
LineNumber
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

public virtual
    bool
Equals(
    Token that
)
{
    if( that == null ) return false;
    if( that.GetType() != this.GetType() ) return false;
    return true;
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
    if( that == null ) return false;
    if( !( that is Token ) ) return false;
    if( !this.Equals( (Token)that ) ) return false;
    return true;
}


public override
    int
GetHashCode()
{
    return this.GetType().GetHashCode();
}




} // type
} // namespace

