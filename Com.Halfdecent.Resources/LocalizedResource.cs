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
using System.Globalization;

using Com.Halfdecent.System;
using Com.Halfdecent.Globalization;



namespace
Com.Halfdecent.Resources
{



/// <summary>
/// A read-only <c>Localized&lt;T&gt;</c> that represents a localized
/// embedded resource
/// </summary>
public class
LocalizedResource<T>
    : Localized<T>
    where T : class
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// <summary>
/// Create a new <c>LocalizedResource&lt;T&gt;</c> backed by embedded
/// resources from a given type of a given name
/// </summary>
internal
LocalizedResource( Type type, string name )
{
    if( type == null ) throw new ArgumentNullException( "type" );
    if( name == null ) throw new ArgumentNullException( "name" );
    if( name == "" ) throw new ArgumentBlankException( "name" );
    this.type = type;
    this.name = name;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// <summary>
/// Get the version of the resource most appropriate for the given culture
/// </summary>
/// <exception cref="ResourceMissingException">
/// No versions of the resource exist
/// </exception>
/// <exception cref="ResourceTypeMismatchException">
/// Resource is not of (or convertable) to <c>T</c>
/// </exception>
public override T
this[ CultureInfo culture ]
{
    get
    {
        if( culture == null ) throw new ArgumentNullException( "culture" );
        T r;
        r = Resource.Get<T>( this.type, this.name, culture );
        if( r == null ) throw new ResourceMissingException(
            this.type.FullName,
            this.name );
        return r;
    }
    set
    {
        throw new InvalidOperationException();
    }
}




// -----------------------------------------------------------------------------
// Protected
// -----------------------------------------------------------------------------

protected Type
type;

protected string
name;




} // type
} // namespace

