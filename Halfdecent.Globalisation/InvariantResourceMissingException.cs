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


using System;


namespace
Halfdecent.Globalisation
{


// =============================================================================
/// An exception indicating that there was no invariant culture variation of an
/// embedded resource
// =============================================================================

public class
InvariantResourceMissingException
    : Exception
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
InvariantResourceMissingException(
    Type    type,
    string  name
)
    : this( type, name, null )
{
}


/// Initialise an <tt>InvariantResourceMissingException</tt>
///
/// @exception ArgumentNullException
/// <tt>typename</tt> is <tt>null</tt>
/// -OR-
/// <tt>name</tt> is <tt>null</tt>
///
/// @exception ArgumentException
/// <tt>name</tt> is blank
///
public
InvariantResourceMissingException(
    Type        type,
    ///< Name of the type the missing resource was supposed to belong to
    string      name,
    ///< Name of the missing resource
    Exception   innerException
    ///< (See <tt>System.Exception</tt>)
)
    : base(
        string.Format(
            "Type '{0}' contains no embedded resources named '{1}' for the invariant culture",
            type != null ? type.FullName : "(unknown)",
            name ),
        innerException )

{
    if( type == null )
        throw new ArgumentNullException( "type" );
    if( name == null )
        throw new ArgumentNullException( "name" );
    if( name == "" )
        throw new ArgumentException( "Is blank", "name" );
    this.Type = type;
    this.Name = name;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
Type
Type
{
    get;
    private set;
}


public
string
Name
{
    get;
    private set;
}




} // type
} // namespace

