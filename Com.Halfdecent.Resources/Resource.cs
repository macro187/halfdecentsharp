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
using System.Diagnostics;
using System.Resources;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using Com.Halfdecent.Globalisation;


namespace
Com.Halfdecent.Resources
{


// =============================================================================
/// Utilities for working with resources
///
/// Suggested private localised string convenience function:
/// <code>
/// private static global::Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return global::Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }
/// </code>
// =============================================================================

public static class
Resource
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

public static
Localised< string >
_S(
    Type            type,
    string          untranslated,
    params object[] formatargs
)
{
    if( type == null )
        throw new ArgumentNullException( "type" );
    if( untranslated == null )
        throw new ArgumentNullException( "untranslated" );
    if( untranslated == "" )
        throw new ArgumentException( "Is blank", "s" );
    if( formatargs == null )
        throw new ArgumentNullException( "formatargs" );

    Localised< string > ls = new LocalisedStringResource( type, untranslated );
    if( formatargs.Length > 0 ) {
        ls = LocalisedString.Format( ls, formatargs );
    }
    return ls;
}


/// Get a <tt>Localised< T ></tt> whose localised variations are embedded under
/// a given name as resources belonging to a given type
///
/// @exception ResourceMissingException
/// The specified resource doesn't exist for the invariant culture
///
/// @exception ArgumentNullException
/// <tt>type</tt> or <tt>name</tt> are <tt>null</tt>
///
/// @exception ArgumentException
/// <tt>name</tt> is a blank string
///
public static
Localised< T >
/// @returns A <tt>Localised< T ></tt> whose localised variations are embedded
/// resources
_R<
    T
    ///< Type of the resource(s)
>(
    Type type,
    ///< Type the resource(s) belong to

    string name
    ///< Name the resources are embedded under
)
{
    if( type == null )
        throw new ArgumentNullException( "type" );
    if( name == null )
        throw new ArgumentNullException( "name" );
    if( name == "" )
        throw new ArgumentException( "Is blank", "name" );

    Localised< T > r = new LocalisedResource< T >( type, name );

    // Fail early if a version for the invariant culture doesn't exist
    try {
        if( (object)( r[ CultureInfo.InvariantCulture ] ) == null ) {}
    // TODO Create and throw a more specific exception from
    //      ExceptionBase< T >, and catch only that here
    } catch( Exception e ) {
        throw new ResourceMissingException( type, name, e );
    }

    return r;
}




} // class
} // namespace

