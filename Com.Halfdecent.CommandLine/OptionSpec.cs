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
using System.Collections.Generic;

using Com.Halfdecent.System;



namespace
Com.Halfdecent.CommandLine
{



/// <summary>
/// Spec for a command-line option
/// </summary>
public class
OptionSpec
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// <summary>
/// Create an <c>OptionSpec</c> for an option with a given name, that takes
/// no value
/// <summary>
public
OptionSpec(
    string name
)
    : this( name, false )
{
    if( name == null ) throw new ArgumentNullException( "name" );
    if( name == "" ) throw new ArgumentBlankException( "name" );
    this.name = name;
}


/// <summary>
/// Create an <c>OptionSpec</c> for an option with a given name, and
/// specifying whether the option takes a value
/// <summary>
public
OptionSpec(
    string  name,
    bool    takesvalue
)
{
    if( name == null ) throw new ArgumentNullException( "name" );
    if( name == "" ) throw new ArgumentBlankException( "name" );
    this.name = name;
    this.takesvalue = takesvalue;
}




// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// <summary>
/// Generates single-character <c>OptionSpec</c>s from a C
/// <c>getopt()</c>-style string
/// <summary>
/// <remarks>
/// A <c>getopt()</c> string is just a string of option characters, each of
/// which can be followed by a colon if the option takes a value.
///
/// Example:
///   "vqo:l:"
///   Means options "v", "q", "o", and "l".  "o" and "l" take values.
/// </remarks>
/// <exception cref="ArgumentException">
/// If an illegal character is encountered in <paramref name="optstring"/>
/// </exception>
static public IList<OptionSpec>
SpecsFromString(
    string  optstring
)
{
    if( optstring == null ) throw new ArgumentNullException( "optstring" );
    IList<OptionSpec> results = new List<OptionSpec>();
    for( int i=0; i < optstring.Length; ) {
        char c = optstring[i];
        if( !( (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') ) ) {
            throw new ArgumentOutOfRangeException(
                "optstring",
                String.Format(
                    "Invalid option character '{0}' at position {1}",
                    c, i ) );
        }
        string name = c.ToString();
        i++;
        bool takesvalue = false;
        if( i < optstring.Length ) {
            if( optstring[i] == ':' ) {
                takesvalue = true;
                i++;
            }
        }
        results.Add( new OptionSpec( name, takesvalue ) );
    }
    return results;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// <summary>
/// The name of the option as it would appear on the commandline
/// <summary>
public string
Name
{
    get { return this.name; }
}



/// <summary>
/// Does the option take a value?
/// <summary>
public bool
TakesValue
{
    get { return this.takesvalue; }
}




// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

protected string
name;


protected bool
takesvalue;




} // type
} // namespace

