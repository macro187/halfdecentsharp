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
using Meta = Com.Halfdecent.Meta;

namespace
Com.Halfdecent.Exceptions
{



// =============================================================================
/// Exception indicating a problematic value
// =============================================================================
///
public class
ValueException
    : LocalisedException
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
ValueException(
    Meta.Value          source,
    ///< Source of the problematic value
    object              value,
    ///< Problematic value
    Exception           innerException,
    ///< Underlying cause
    Localised< string > description,
    ///< Formatted description of the problem with <tt>{0}</tt> as the value
    ///  identifier
)
    : base(
        ( description
            ? LocalisedString.Format(
                description ?? GENERIC_DESCRIPTION,
                source ?? GENERIC_VALUE_IDENTIFIER )
            : null ),
        innerException )
{
    this.source = source;
    this.value = value;
    this.description = description;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
Meta.Value
Source
{
    get { return this.source; }
}

private
Meta.Value
source;



public
object
Value
{
    get { return this.value; }
}

private
object
value;




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Generate a natural language sentence describing what's wrong with the value
///
public virtual
Localised< string >
SayProblem(
    Localised< string > valueIdentifier
    ///< What to refer to the problematic
    ///  value as
)
{
    return LocalisedString.Format(
        this.description ?? GENERIC_DESCRIPTION,
        valueIdentifier );
}




// -----------------------------------------------------------------------------
// Privates
// -----------------------------------------------------------------------------

private static readonly
Localised< string >
GENERIC_DESCRIPTION = _S("There is a problem with {0}");


private static readonly
Localised< string >
GENERIC_VALUE_IDENTIFIER = _S("a value");




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

