// -----------------------------------------------------------------------------
// Copyright (c) 2007 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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
using Com.Halfdecent.Globalization;
using R = Com.Halfdecent.Resources.Resource;


namespace
Com.Halfdecent.System
{




/// Exception indicating that some object's value is invalid
///
public abstract class
ValueException
    : HDException
{




/// Initialise a new <tt>ValueException</tt> with a given inner exception
///
public
ValueException(
    Exception innerException
)
    : base( "", innerException )
{
}



/// Generate a natural language sentence describing what's wrong with the value
///
abstract public
Localized< string >
SayProblem(
    Localized< string > valueIdentifier ///< What to refer to the problematic
                                        ///  value as
);



/// (see <tt>IException.Message</tt>)
///
override public
Localized< string >
Message
{
    get { return this.SayProblem( R._S("A value") ); }
}




} // type
} // namespace

