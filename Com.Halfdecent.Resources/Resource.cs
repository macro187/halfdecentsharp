// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010, 2011
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
using System.Resources;
using System.Globalization;
using System.IO;


namespace
Com.Halfdecent.Resources
{


// =============================================================================
/// Embedded resources
// =============================================================================

public static class
Resource
{


// -----------------------------------------------------------------------------
// Static
// -----------------------------------------------------------------------------

/// Retrieve an embedded resource
///
/// @exception ResourceTypeMismatchException
/// The resource was found but was not of the expected type
///
/// @exception ArgumentNullException
/// <tt>type</tt> is <tt>null</tt>
/// <strong>OR</strong>
/// <tt>name</tt> is <tt>null</tt>
/// <strong>OR</strong>
/// <tt>language</tt> is <tt>null</tt>
///
/// @exception ArgumentException
/// <tt>name</tt> is a blank string
///
public static
    IMaybe< T >
    ///< @returns The specified resource, if it was found
Get<
    T
    ///< Type the resource is expected to be
>(
    Type        type,
    ///< Type the resource belongs to
    string      name,
    ///< Name of the resource
    CultureInfo language
    ///< Language
)
{
    if( type == null )
        throw new ArgumentNullException( "type" );
    if( name == null )
        throw new ArgumentNullException( "name" );
    if( name == "" )
        throw new ArgumentException( "name is blank", "name" );
    if( language == null )
        throw new ArgumentNullException( "language" );

    ResourceManager mgr = new InternalResourceManager( type );

    ResourceSet set;
    try {
        set = mgr.GetResourceSet( language, true, false );
    } catch( MissingManifestResourceException ) {
        set = null;
    } catch( MissingSatelliteAssemblyException ) {
        set = null;
    }
    if( set == null ) return Maybe.Create< T >();

    object obj = set.GetObject( name );
    if( obj == null ) return Maybe.Create< T >();

    if( !(obj is T) )
        throw new ResourceTypeMismatchException(
            typeof( T ).FullName,
            obj.GetType().FullName,
            type.FullName,
            name,
            language.Name );

    return Maybe.Create( (T)obj );
}




} // class
} // namespace

