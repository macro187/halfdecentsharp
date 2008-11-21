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
Com.Halfdecent.Resources
{

// =============================================================================
/// An exception indicating that an embedded resource that was expected to
/// exist couldn't be found
// =============================================================================
///
public class
ResourceMissingException
    : Exception
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialise a <tt>ResourceMissingException</tt>
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
ResourceMissingException(

    Type    type,
    ///
    ///< Name of the type the missing resource was supposed to belong to

    string  name,
    ///
    ///< Name of the missing resource

    Exception   innerException
    ///
    ///< (See <tt>System.Exception</tt>)
)
    : base(
        string.Format(
            "Type '{0}' contains no embedded resources named '{1}'",
            type != null ? type.FullName : "(unknown)",
            name ),
        innerException )

{
    if( type == null ) throw new ArgumentNullException( "type" );
    if( name == null ) throw new ArgumentNullException( "name" );
    if( name == "" ) throw new ArgumentException( "Is blank", "name" );
    this.type = type;
    this.name = name;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
Type
Type { get { return this.type; } }

private
Type
type;



public
string
Name { get { return this.name; } }

private
string
name;




} // type
} // namespace

