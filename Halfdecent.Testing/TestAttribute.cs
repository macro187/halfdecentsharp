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
using System.Reflection;



namespace
Halfdecent.Testing
{



/// <summary>
/// An attribute indicating that a method is a test
/// </summary>
/// <summary>
/// This should only be applied to static methods that take no arguments
/// </summary>
[AttributeUsage( AttributeTargets.Method )]
public class
TestAttribute
    : Attribute
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// <summary>
/// Create a <c>TestAttribute</c>
/// </summary>
public
TestAttribute()
    : this("")
{
}


/// <summary>
/// Create a <c>TestAttribute</c> with a given description
/// </summary>
public
TestAttribute(
    string description
)
{
    this.description = description;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// <summary>
/// Description of the test
/// </summary>
public string
Description
{
    get { return this.description; }
}




// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private string
description;




} // type
} // namespace

