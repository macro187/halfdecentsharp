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



namespace
Com.Halfdecent.CommandLine
{



/// <summary>
/// Reads dash-prefixed, one-character commandline options
/// </summary>
/// <remarks>
/// Eg:
///   -v -q arg1 arg2
///
/// Also supports stacking:
///   -vq arg1 arg2
///
/// Options can have values:
///   -vo ovalue -q qvalue arg1 arg2
///
/// </remarks>
public class
DashCharOptionReader
    : OptionReader
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// <summary>
/// Create a new <c>DashCharOptionReader</c> reading from a given argument
/// list, according to given option specs
/// <summary>
/// <exception cref="ArgumentException">
/// If the specs call for an option whose name is not exactly 1 character long
/// </exception>
public
DashCharOptionReader(
    IList<string>       args,
    IList<OptionSpec>   specs
)
    : base( args, specs )
{
    // All option names must be single-char
    foreach( OptionSpec spec in specs ) {
        if( spec.Name.Length > 1 ) {
            throw new ArgumentException(
                String.Format(
                    "Option spec with multicharacter name '{0}' encountered",
                    spec.Name ) );
        }
    }
}




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// <summary>
/// (see base)
/// <summary>
override public IList<Option>
ReadConsecutive()
{
    IList<Option> result = new List<Option>();

    // Go through arg items
    while( true ) {
        string arg = this.args[0];

        // Option arg (started with dash)
        if( arg.StartsWith( "-" ) ) {

            // Pop arg
            this.args.RemoveAt( 0 );

            // Go through option chars
            string stack = arg.Substring( 1 );
            for( int i=0; i < stack.Length; i++ ) {
                string name = stack[i].ToString();
                string value = "";

                // Find option spec
                OptionSpec spec = null;
                foreach( OptionSpec spec2 in this.specs ) {
                    if( spec2.Name == name ) {
                        spec = spec2; break;
                    }
                }
                if( spec == null )
                    throw new UnrecognizedOptionException( name );

                // If the option takes a value...
                if( spec.TakesValue ) {

                    // Error if it's not the last option on the stack
                    if( i < stack.Length-1 )
                        throw new MissingOptionValueException( name );

                    // Error if there are no more args
                    if( args.Count == 0 )
                        throw new MissingOptionValueException( name );

                    // Error if the next arg is more options rather than an
                    // option value
                    if( args[0].StartsWith( "-" ) )
                        throw new MissingOptionValueException( name );

                    // Pop the next arg as the option value
                    value = args[0];
                    args.RemoveAt( 0 );
                }

                result.Add( new Option( name, value ) );
            }

        // Not option arg, we're done
        } else {
            break;
        }

    }

    return result;
}




} // type
} // namespace

