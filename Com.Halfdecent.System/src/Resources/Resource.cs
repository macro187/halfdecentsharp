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
using System.Resources;
using System.Globalization;
using System.Collections.Generic;

using Com.Halfdecent.System;
using Com.Halfdecent.Globalization;



namespace
Com.Halfdecent.Resources
{


/// <summary>
/// Utilities for working with resources
/// </summary>
public class
Resource
{

// (class not creatable)
private Resource() {}




// -----------------------------------------------------------------------------
// Constants
// -----------------------------------------------------------------------------

/// <summary>
/// Embedded string resource names are expected to be the untranslated string
/// itself prefixed by this
/// </summary>
public static readonly string
STRING_PREFIX = "__";




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// <summary>
/// Get a <c>Localized&lt;T&gt;</c> representing embedded resource(s) of a
/// given name
/// </summary>
/// <typeparam name="T">
/// The type the resource is expected to be of
/// </typeparam>
/// <param name="name">
/// The name of the resource
/// </param>
/// <param name="type">
/// The type the resource belongs to
/// </param>
/// <returns>
/// A <c>Localized&lt;T&gt;</c> representing the requested resource
/// </returns>
/// <remarks>
/// This is the method that should generally be used to get non-string
/// resources.  It implies that the requested resource is expected to exist.
/// </remarks>
/// <exception cref="ResourceMissingException">
/// A version of the resource does not exist for at least the invariant culture
/// </exception>
public static Localized<T>
_R<T>(
    Type type,
    string name
)
    where T : class
{
    if( type == null ) throw new ArgumentNullException( "type" );
    if( name == null ) throw new ArgumentNullException( "name" );
    if( name == "" ) throw new ArgumentBlankException( "name" );

    // Fail early if a version for the invariant culture doesn't exist
    if( Get<T>( type, name, CultureInfo.GetCultureInfo( "" ) ) == null )
        throw new ResourceMissingException( type.FullName, name );

    // TODO
    //#if DEBUG
    //Check all existing versions for correct type
    //#endif

    return new LocalizedResource<T>( type, name );
}



/// <summary>
/// Get a <c>Localized&lt;string&gt;</c> representing a given string which
/// may have translated versions available as embedded resources
/// </summary>
public static Localized<string>
_S(
    Type    type,
    string  untranslated
)
{
    if( type == null ) throw new ArgumentNullException( "type" );
    if( untranslated == null ) throw new ArgumentNullException( "untranslated" );
    if( untranslated == "" ) throw new ArgumentBlankException( "untranslated" );

    return new LocalizedStringResource( type, untranslated );
}


/// <summary>
/// Get a <c>Localized&lt;string&gt;</c> representing a given string which
/// may have translated versions available as embedded resources and which,
/// when used, should be <c>String.Format</c>ted with the given arguments in
/// a culture-specific fashion
/// </summary>
public static Localized<string>
_S(
    Type    type,
    string  untranslated,
    params object[] formatargs
)
{
    if( type == null ) throw new ArgumentNullException( "type" );
    if( untranslated == null ) throw new ArgumentNullException( "untranslated" );
    if( untranslated == "" ) throw new ArgumentBlankException( "untranslated" );

    return new LocalizedStringResource( type, untranslated, formatargs );
}



/// <summary>
/// Retrieve an embedded resource
/// </summary>
/// <remarks>
/// If the specifed resource does not exist, this method always returns
/// <c>null</c>.  This differs from <c>ResourceManager.GetObject()</c>'s,
/// confusing behaviour, which under the same circumstances sometimes
/// returns <c>null</c> (if there are other embedded resources) and sometimes
/// throws an exception (if there are no other embedded resources).
/// </remarks>
/// <returns>
/// The version of the resource of the given name most appropriate for the
/// given culture, or <c>null</c> if no versions of the resource exist at all
/// </returns>
/// <exception cref="ResourceTypeMismatchException">
/// Resource is not of (or convertable) to <c>T</c>
/// </exception>
public static T
Get<T>(
    Type type,
    string name,
    CultureInfo culture
)
    where T : class
{
    if( type == null ) throw new ArgumentNullException( "type" );
    if( name == null ) throw new ArgumentNullException( "name" );
    if( name == "" ) throw new ArgumentBlankException( "name" );
    if( culture == null ) throw new ArgumentNullException( "culture" );

    T result = null;
    object o;
    ResourceManager rm = GetResourceManager( type );
    try {
        o = rm.GetObject( name, culture );
    } catch( MissingManifestResourceException ) {
        o = null;
    }

    if( o != null ) {
        result = o as T;
        if( result == null )
            throw new ResourceTypeMismatchException(
                typeof(T).FullName,
                o.GetType().FullName,
                type.FullName,
                name,
                culture.Name );
    }

    return result;
}




// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

/// <summary>
/// Get a ResourceManager for a given type
/// </summary>
/// <remarks>
/// <p>
/// This implementation lazy-creates and caches ResourceManagers.  I blindly
/// assume this to be a win because
/// a) we don't create new ResourceManager objects each time
/// b) we reuse ResourceManagers, allowing their own internal caching (eg. of
///    ResourceSets) to kick in
/// </p>
/// <p>
/// Potential issues:
/// - (definitely on Mono, don't know about MS)
///   We lazy-create and cache individual ResourceManagers, each of which
///   lazy-creates and caches individual ResourceSets, each of which _reads
///   and caches ALL values_ the first time any are accessed.  That means
///   _all values_ for every accessed culture of every accessed type end up
///   cached in memory.  This is Mono's ResourceManager's implementation's
///   fault, not ours, as our only other choice is to never reuse
///   ResourceManagers.
/// - We maintain references to each type that we come across as part of the
///   cache, which might be an issue if you're doing some kind of dynamic type
///   unloading
/// </p>
/// </remarks>
private static ResourceManager
GetResourceManager( Type type )
{
    if( type == null ) throw new ArgumentNullException( "type" );
    ResourceManager result;
    lock( managers ) {
        if( !managers.TryGetValue( type, out result ) ) {
            result = new ResourceManager( type );
            managers.Add( type, result );
        }
    }
    return result;
}


// ResourceManager cache
private static Dictionary<Type,ResourceManager>
managers = new Dictionary<Type,ResourceManager>();




} // class
} // namespace

