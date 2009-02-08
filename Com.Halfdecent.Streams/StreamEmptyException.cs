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


using System;
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Exceptions;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// A stream contains no more items
// =============================================================================
//
public class
StreamEmptyException
    : LocalisedExceptionBase
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
StreamEmptyException(
    IValue  streamReference
)
    :this( streamReference, null )
{
}



public
StreamEmptyException(
    IValue      streamReference,
    Exception   innerException
)
    :base( innerException )
{
    NonNull.Check( streamReference, new Parameter( "streamReference" ) );
    this.streamreference = streamReference;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
IValue
StreamReference
{
    get { return this.streamreference; }
}

private
IValue
streamreference;



// -----------------------------------------------------------------------------
// LocalisedException
// -----------------------------------------------------------------------------

override public
Localised< string >
Message
{
    get
    {
        return _S("An attempt was made to read past the end of stream '{0}'",
            this.StreamReference.ToString() );
    }
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

