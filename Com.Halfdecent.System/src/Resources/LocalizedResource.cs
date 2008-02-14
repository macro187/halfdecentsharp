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




/// A read-only <tt>Localized< T ></tt> representing localized embedded
/// resources of a particular name
///
public class
LocalizedResource<
    T
>
    : Localized< T >
    where T : class
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Create a new <tt>LocalizedResource< T ></tt> backed by embedded
/// resources from a given type of a given name
///
internal
LocalizedResource(
    Type    type,
    string  name
)
{
    new IsPresent< Type >().ReallyRequire( type );
    new IsPresent< string >().ReallyRequire( name );
    new IsNotBlank().Require( name );
    this.type = type;
    this.name = name;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// Get the version of the resource most appropriate for the given culture
///
/// @exception ResourceMissingException
/// No versions of the resource exist
///
/// @exception ResourceTypeMismatchException
/// Resource is not of (or convertable) to <tt>T</tt>
///
public override
T
this[
    CultureInfo culture
]
{
    get
    {
        new IsPresent< CultureInfo >().ReallyRequire( culture );
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

protected
Type
type;

protected
string
name;




} // type
} // namespace

