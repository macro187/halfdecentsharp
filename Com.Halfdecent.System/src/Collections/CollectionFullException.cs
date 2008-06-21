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
using Com.Halfdecent.System;
using Com.Halfdecent.Globalization;


namespace
Com.Halfdecent.Collections
{




/// <tt>HDInvalidOperationException</tt> indicating that an operation could not
/// be completed because a collection was already at it's capacity
///
public class
CollectionFullException
    : HDInvalidOperationException
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialise a new <tt>CollectionFullException</tt>
///
public
CollectionFullException()
    : this( null, null )
{
}



/// Initialise a new <tt>CollectionFullException</tt> with a given message
///
public
CollectionFullException(
    Localized< string > message
)
    : this( message, null )
{
}



/// Initialise a new <tt>CollectionFullException</tt> with a given inner
/// exception indicating the underlying reason for this exception
///
public
CollectionFullException(
    Exception innerException
)
    : this( null, innerException )
{
}



/// Initialise a new <tt>CollectionFullException</tt> with a given message and
/// inner exception indicating the underlying reason for this exception
///
public
CollectionFullException(
    Localized< string > message,
    Exception           innerException
)
    : base(
        (message != null
            ? message
            : _S("The operation can not complete because the collection is already full")
        ),
        innerException )
{
}




private static Com.Halfdecent.Globalization.Localized< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

