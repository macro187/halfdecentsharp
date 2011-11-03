// -----------------------------------------------------------------------------
// Copyright (c) 2011
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
using System.Globalization;
using Com.Halfdecent;
using Com.Halfdecent.Resources;


namespace
Com.Halfdecent.Globalisation
{


// =============================================================================
/// <tt>Localised<T></tt>s backed by embedded resources
///
/// Suggested private localised string convenience function:
/// <code>
/// private static global::Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return global::Com.Halfdecent.Globalisation.LocalisedResource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }
/// </code>
// =============================================================================

public static class
LocalisedResource
{



// -----------------------------------------------------------------------------
// Constants
// -----------------------------------------------------------------------------

/// Localised variations of strings are named the untranslated string itself
/// prefixed by this
///
public static readonly
string
STRING_RESOURCE_NAME_PREFIX = "__";



// -----------------------------------------------------------------------------
// Static Methods
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
        throw new ArgumentException( "s is blank", "s" );
    if( formatargs == null )
        throw new ArgumentNullException( "formatargs" );

    string name = string.Concat( STRING_RESOURCE_NAME_PREFIX, untranslated );

    // Localised< string > backed by the specified resource with fallback to
    // the untranslated string
    Localised< string > ls = Localised.Create(
        (uic,c) => {
            var maybe = Resource.Get<
                string >(
                type,
                name,
                uic );
            if( uic.Name == "" && !maybe.HasValue )
                return Maybe.Create( untranslated );
            return maybe; } );

    // LocalisedString.Format() if we were passed formatting args
    if( formatargs.Length > 0 ) {
        ls = LocalisedString.Format( ls, formatargs );
    }

    return ls;
}


/// Get a <tt>Localised< T ></tt> whose variations are embedded resources
/// belonging to a particular type under a particular name
///
/// @exception InvariantResourceMissingException
/// The specified resource doesn't exist for at least the invariant culture
///
/// @exception ArgumentNullException
/// <tt>type</tt> is <tt>null</tt>
/// <strong>OR</strong>
/// <tt>name</tt> is <tt>null</tt>
///
/// @exception ArgumentException
/// <tt>name</tt> is a blank string
///
public static
    Localised< T >
    /// @returns
    /// A <tt>Localised< T ></tt> whose localised variations are embedded
    /// resources
_R<
    T
    ///< Expected type of the resource(s)
>(
    Type type,
    ///< Type the resource(s) belong to
    string name
    ///< Name of the resource(s)
)
{
    if( type == null )
        throw new ArgumentNullException( "type" );
    if( name == null )
        throw new ArgumentNullException( "name" );
    if( name == "" )
        throw new ArgumentException( "name is blank", "name" );

    // XXX Debug-only?
    if(
        Resource.Get< T >( type, name, CultureInfo.InvariantCulture )
            .HasValue == false )
        throw new InvariantResourceMissingException( type, name );

    return Localised.Create< T >(
        (uic,c) =>
            Resource.Get< T >( type, name, uic ) );
}




} // type
} // namespace

