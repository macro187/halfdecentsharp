// -----------------------------------------------------------------------------
// Copyright (c) 2008 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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
using Com.Halfdecent.Globalisation;

namespace
Com.Halfdecent.Exceptions
{



// =============================================================================
/// Base class for implementing <tt>ILocalisedException</tt>s
// =============================================================================
///
public abstract class
LocalisedExceptionBase
    : LocalisedExceptionShim
    , ILocalisedException
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
LocalisedExceptionBase()
    : this( null )
{
}



public
LocalisedExceptionBase(
    Exception innerException
)
    : base(
        _S("(description not available because not using Message property)"),
        innerException )
{
}




// -----------------------------------------------------------------------------
// ILocalisedException
// -----------------------------------------------------------------------------

new public abstract
Localised< string >
Message
{
    get;
}



protected override
string
BaseMessage
{
    get { return this.Message; }
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace
