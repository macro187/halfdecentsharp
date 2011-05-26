// -----------------------------------------------------------------------------
// Copyright (c) 2011
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
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.TextTree
{


public class
ParseException
    : LocalisedException
    , IParseException
{


// -----------------------------------------------------------------------------
// Constructor
// -----------------------------------------------------------------------------

public
ParseException(
    Localised< string > message,
    Token               token
)
    : this( message, token, null )
{
}


public
ParseException(
    Localised< string > message,
    Token               token,
    System.Exception    innerException
)
    : base(
        message ?? _S( "Parse error" ),
        innerException )
{
    NonNull.CheckParameter( token, "token" );
    this.Token = token;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
Token
Token
{
    get;
    private set;
}




private static global::Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return global::Com.Halfdecent.Resources.Resource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

