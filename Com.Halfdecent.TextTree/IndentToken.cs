// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2011, 2012, 2013
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
/// A TextTree lexer token indicating an indentation increase
// =============================================================================

public class
IndentToken
    : Token
{


// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
IndentToken(
    long lineNumber
)
    : base( lineNumber )
{
}




} // type



// =============================================================================
/// Token Extension Methods
// =============================================================================

public static class
IndentTokenStatic
{


public static
    void
ExpectIndent(
    this Token dis
)
{
    if( !dis.Is< IndentToken >() )
        throw new ParseException( _S( "Expected indent" ), dis );
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Globalisation.LocalisedResource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type




} // namespace

