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


using System;
using Com.Halfdecent.Exceptions;


namespace
Com.Halfdecent.Meta
{


// =============================================================================
/// Wraps an <tt>IValueException</tt> in a <tt>LocalisedArgumentException</tt>
// =============================================================================

public class
ValueArgumentException<
    TInnerException
>
    : LocalisedArgumentException
    where TInnerException :
        Exception,
        IValueException< Parameter >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
ValueArgumentException(
    TInnerException innerException
)
    : base(
        innerException.Message,
        innerException.ValueReference.Name,
        innerException )
{
    if( innerException == null )
        throw new LocalisedArgumentNullException( "innerException" );
}




} // type
} // namespace

