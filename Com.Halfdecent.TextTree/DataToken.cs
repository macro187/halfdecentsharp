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


using Com.Halfdecent.Globalisation;
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
    string data,
    long   lineNumber
)
    : base( lineNumber )
{
    NonNull.CheckParameter( data, "data" );
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




} // type



// =============================================================================
/// Token Extension Methods
// =============================================================================

public static class
DataTokenStatic
{


public static
    void
ExpectFixedData(
    this Token  dis,
    string      data
)
{
    NonNull.CheckParameter( dis, "dis" );
    NonNull.CheckParameter( data, "data" );
    if( !dis.Is< DataToken >( dt => dt.Data == data ) )
        throw new ParseException(
            LocalisedString.Format( "Expected '{0}'", data ),
            dis );
}


public static
    string
ExpectData(
    this Token          dis,
    Localised< string > description
)
{
    NonNull.CheckParameter( dis, "dis" );
    NonNull.CheckParameter( description, "description" );
    return
        dis
        .As< DataToken >()
        .Else( () => {
            throw new ParseException(
                LocalisedString.Format( "Expected {0}", description ),
                dis ); } )
        .Data;
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Globalisation.LocalisedResource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type




} // namespace

