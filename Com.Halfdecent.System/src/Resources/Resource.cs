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
using System.Diagnostics;
using System.Resources;
using System.Globalization;
using System.Collections.Generic;
using System.IO;

using Com.Halfdecent.System;
using Com.Halfdecent.Globalization;



namespace
Com.Halfdecent.Resources
{


/// Utilities for working with resources
///
public class
Resource
{

/// (not creatable)
private Resource() {}




// -----------------------------------------------------------------------------
// Constants
// -----------------------------------------------------------------------------

/// Embedded string resource names are expected to be the untranslated string
/// itself prefixed by this
///
public static readonly
string
STRING_PREFIX = "__";




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Get a <tt>Localized< T ></tt> representing embedded resource(s) of a
/// given name, belonging to the type where the calling method is defined
///
/// This is the method that should generally be used to get non-string
/// resources.  It implies that the requested resource is expected to exist.
///
/// @exception ResourceMissingException
/// A version of the resource does not exist for at least the invariant culture
///
public static
Localized< T >  /// @returns A <tt>Localized< T ></tt> representing the
                /// requested resource
_R<
    T           ///< The type the resource is expected to be of
>(
    string name ///< The name of the resource
)
    where T : class
{
    Type type = new StackFrame( 1, false ).GetMethod().DeclaringType;
    return _R< T >( type, name );
}



/// Get a <tt>Localized< T ></tt> representing embedded resource(s) of a
/// given name
///
/// This is the method that should generally be used to get non-string
/// resources.  It implies that the requested resource is expected to exist.
///
/// @exception ResourceMissingException
/// A version of the resource does not exist for at least the invariant culture
///
public static
Localized< T >  /// @returns A <tt>Localized< T ></tt> representing the
                /// requested resource
_R<
    T           ///< The type the resource is expected to be of
>(
    Type type,  ///< The type the resource belongs to
    string name ///< The name of the resource
)
    where T : class
{
    new IsPresent().BugDemand( type );
    new IsPresent().BugDemand( name );
    new IsNotBlank().Demand( name );

    // Fail early if a version for the invariant culture doesn't exist
    if( Get< T >( type, name, CultureInfo.GetCultureInfo( "" ) ) == null )
        throw new ResourceMissingException( type.FullName, name );

    // TODO
    //#if DEBUG
    //Check all existing versions for correct type
    //#endif

    return new LocalizedResource< T >( type, name );
}



/// Get a <tt>Localized< string ></tt> representing a given string which
/// may have translated versions available as embedded resources belonging
/// to the type where the calling method is defined
///
public static
Localized< string >
_S(
    string  untranslated
)
{
    Type type = new StackFrame( 1, false ).GetMethod().DeclaringType;
    return _S( type, untranslated );
}



/// Get a <tt>Localized< string ></tt> representing a given string which
/// may have translated versions available as embedded resources
///
public static
Localized< string >
_S(
    Type    type,
    string  untranslated
)
{
    new IsPresent().BugDemand( type );
    new IsPresent().BugDemand( untranslated );
    new IsNotBlank().Demand( untranslated );

    return new LocalizedStringResource( type, untranslated );
}


/// Get a <tt>Localized< string ></tt> representing a given string which
/// may have translated versions available as embedded resources belonging to
/// the type where the calling method is defined and which, when used, should
/// be <tt>String.Format</tt>ted with the given arguments in a culture-specific
/// fashion
///
public static
Localized< string >
_S(
    string          untranslated,
    params object[] formatargs
)
{
    Type type = new StackFrame( 1, false ).GetMethod().DeclaringType;
    return _S( type, untranslated, formatargs );
}



/// Get a <tt>Localized< string ></tt> representing a given string which
/// may have translated versions available as embedded resources and which,
/// when used, should be <tt>String.Format</tt>ted with the given arguments in
/// a culture-specific fashion
///
public static
Localized< string >
_S(
    Type            type,
    string          untranslated,
    params object[] formatargs
)
{
    new IsPresent().BugDemand( type );
    new IsPresent().BugDemand( untranslated );
    new IsNotBlank().Demand( untranslated );

    return new LocalizedStringResource( type, untranslated, formatargs );
}



/// Retrieve an embedded resource
///
/// If the specifed resource does not exist, this method always returns
/// <tt>null</tt>.  This differs from <tt>ResourceManager.GetObject()</tt>'s,
/// confusing behaviour, which under the same circumstances sometimes
/// returns <tt>null</tt> (if there are other embedded resources) and sometimes
/// throws an exception (if there are no other embedded resources).
///
/// @exception ResourceTypeMismatchException
/// Resource is not of (or convertable) to <tt>T</tt>
///
public static
T                           /// @returns The version of the resource of the
                            /// given name most appropriate for the given
                            /// culture, or <tt>null</tt> if no versions of the
                            /// resource exist at all
Get<
    T
>(
    Type        type,
    string      name,
    CultureInfo culture
)
    where T : class
{
    new IsPresent().BugDemand( type );
    new IsPresent().BugDemand( name );
    new IsNotBlank().Demand( name );
    new IsPresent().BugDemand( culture );

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

/// Get a ResourceManager for a given type
///
/// @par
/// This implementation lazy-creates and caches ResourceManagers.  I blindly
/// assume this to be a win because
/// a) we don't create new ResourceManager objects each time
/// b) we reuse ResourceManagers, allowing their own internal caching (eg. of
///    ResourceSets) to kick in
///
/// @par Potential issues
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
///
private static
ResourceManager
GetResourceManager(
    Type type
)
{
    new IsPresent().BugDemand( type );
    ResourceManager result;
    lock( managers ) {
        if( !managers.TryGetValue( type, out result ) ) {
            result = new MyResourceManager( type );
            managers.Add( type, result );
        }
    }
    return result;
}


// ResourceManager cache
private static
Dictionary< Type, ResourceManager >
managers = new Dictionary< Type, ResourceManager >();



// Evidently, the ResourceManager implementation in (at least) MS.NET 2.0 does
// not search for resources for any cultures other than the invariant in the
// main assembly ie. it expects all other cultures' resources to be in
// satellite assemblies.  But we want the option of embedding other cultures'
// resources in the main assembly too (like we can with Mono), so this
// hack makes sure the main assembly is always checked first.
//
// TODO Look into using ResourceManager.FallbackLocation instead of
//      overriding InternalGetResourceSet()
private class
MyResourceManager
    : ResourceManager

{
    private Type
    sourcetype;

    public
    MyResourceManager(
        Type type
    )
        : base( type )
    {
        this.sourcetype = type;
    }

    protected override ResourceSet
    InternalGetResourceSet(
        CultureInfo culture,
        bool        Createifnotexists,
        bool        tryParents
    )
    {
        new IsPresent().BugDemand( culture );
        ResourceSet result = null;

        if( this.MainAssembly != null ) {
            if( !culture.Equals( CultureInfo.InvariantCulture ) ) {
                string filename = this.GetResourceFileName( culture );
                Stream stream = null;
                try {
                    stream = this.MainAssembly.GetManifestResourceStream(
                        sourcetype,
                        filename );
                } catch( FileNotFoundException fnfe ) {
                    if( fnfe == null ) {} // do nothing
                }
                if( stream != null ) {
                    result = new ResourceSet( stream );
                }
            }
        }
        if( result == null ) {
            result = base.InternalGetResourceSet( culture, Createifnotexists,
                tryParents );
        }

        return result;
    }
}



} // class
} // namespace

