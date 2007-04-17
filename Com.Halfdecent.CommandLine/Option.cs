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

using Com.Halfdecent.System;
using Com.Halfdecent.Resources;
using Com.Halfdecent.Globalization;
using Com.Halfdecent.Application;



namespace
Com.Halfdecent.CommandLine
{



/// <summary>
/// A command-line option
/// </summary>
public class
Option
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// <summary>
/// Create a new <c>Option</c> with a given name and value
/// <summary>
public
Option(
    string name,
    string value
)
{
    if( name == null ) throw new ArgumentNullException( "name" );
    if( name == "" ) throw new ArgumentBlankException( "name" );
    if( value == null ) throw new ArgumentNullException( "value" );
    this.name = name;
    this.value = value;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// <summary>
/// The switch's name as it appeared on the commandline
/// </summary>
public string
Name
{
    get { return this.name; }
}



/// <summary>
/// Value provided for the switch
/// </summary>
public string
Value
{
    get { return this.value; }
}




// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private string
name;


private string
value;




} // type
} // namespace

