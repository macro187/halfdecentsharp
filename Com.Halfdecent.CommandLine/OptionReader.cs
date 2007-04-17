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
/// Reads <c>Option</c>s of a particular format from a command-line args list
/// </summary>
public abstract class
OptionReader
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// <summary>
/// Initialize an <c>OptionReader</c> to read from a given argument list
/// according to given option specs
/// <summary>
/// <param name="args">
/// The command-line args as a _modifiable_ <c>IList</c>
/// </param>
public
OptionReader(
    IList<string>       args,
    IList<OptionSpec>   specs
)
{
    if( args == null ) throw new ArgumentNullException( "args" );
    if( specs == null ) throw new ArgumentNullException( "specs" );
    // TODO Is there a way to check that args is modifiable?
    this.args = args;
    this.specs = specs;
}




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// <summary>
/// Read all consecutive <c>Option</c>s from the front of the list
/// <summary>
/// <remarks>
/// Reads and returns all options up until the first non-option argument or
/// the end of the list, whichever comes first
/// </remarks>
abstract public IList<Option>
ReadConsecutive();



// TODO ReadAll()




// -----------------------------------------------------------------------------
// Protected
// -----------------------------------------------------------------------------

protected IList<string>
args;


protected IList<OptionSpec>
specs;




} // type
} // namespace

