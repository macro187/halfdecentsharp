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
using System.Globalization;
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.RTypes;

namespace
Com.Halfdecent.Resources
{




/// A read-only <tt>Localised< T ></tt> representing localised embedded
/// resources of a particular name
///
public class
LocalisedResource<
    T
>
    : Localised< T >
    where T
        // TODO why? necessary?
        : class
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialise a new <tt>LocalisedResource< T ></tt> representing localised
/// variations of an item embedded under a given name as resources associated
/// with a given type
///
internal
LocalisedResource(
    Type    type,   ///< Type the resource(s) are associated with
                    ///
                    ///  Requirements:
                    ///  - Really <tt>IsPresent< T ></tt>
    string  name    ///< Name the resource(s) are embedded under
                    ///
                    ///  Requirements:
                    ///  - Really <tt>IsPresent< T ></tt>
                    ///  - <tt>IsNotBlank</tt>
)
{
    new NonNull().Check( type );
    new NonNull().Check( name );
    new NonBlankString().Check( name );
    this.type = type;
    this.name = name;
}




// -----------------------------------------------------------------------------
// Localised< T >
// -----------------------------------------------------------------------------

/// Get the variation of the resource most appropriate for the given culture
///
/// TODO: BugException in this situation
/// @exception ResourceMissingException
/// No versions of the resource exist
///
/// @exception ResourceTypeMismatchException
/// The underlying resource is not a <tt>T</tt>
///
public override
T
this[
    CultureInfo culture
]
{
    get
    {
        new NonNull().Check( culture );
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

// TODO to property
protected
Type
type;



protected
// TODO to property
string
name;




} // type
} // namespace

