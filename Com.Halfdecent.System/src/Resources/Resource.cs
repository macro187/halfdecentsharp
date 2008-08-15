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
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Resources
{




/// Utilities for working with resources
///
public static class
Resource
{




// -----------------------------------------------------------------------------
// Constants
// -----------------------------------------------------------------------------

/// Embedded string resource names are expected to be the untranslated string
/// itself prefixed by this
///
public static readonly
string
STRING_RESOURCE_NAME_PREFIX = "__";




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/*
/// Produce a <tt>Localised< string ></tt> from an untranslated <tt>string</tt>
/// whose localised variants will, if present, come from embedded string
/// resources
///
/// The name of the embedded string resources is the untranslated string itself
/// prefixed by <tt>STRING_RESOURCE_NAME_PREFIX</tt> 
///
/// The resultant <tt>Localised< string ></tt> searches for and retrieves
/// resources in an on-demand fashion using <tt>Get< T >()</tt>, so any
/// exceptions it throws may occur at those times.
///
public static
Localised< string >
_S(
    Type    type,           ///< Type that embedded resources containing
                            ///  localised variants of <tt>untranslated</tt>
                            ///  are associated with
                            ///
                            ///  Requirements:
                            ///  - Really <tt>IsPresent< T ></tt>
                            ///
    string  untranslated    ///< The untranslated string
                            ///
                            ///  Requirements:
                            ///  - Really <tt>IsPresent< T ></tt>
                            ///  - <tt>IsNotBlank</tt>
)
{
    new IsPresent< Type >().ReallyRequire( type );
    new IsPresent< string >().ReallyRequire( untranslated );
    new IsNotBlank().Require( untranslated );
    return _S( type, untranslated );
}
*/


/* _S() to put in each class:
private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }
*/

public static
Localised< string >
_S(
    Type            type,
    string          untranslated,
    params object[] formatargs
)
{
    new NonNull().Check( type );
    new NonNull().Check( untranslated );
    new NonBlankString().Check( untranslated );

    Localised<string> ls = new LocalisedStringResource(
        type, untranslated, formatargs );
    if( formatargs.Length > 0 ) {
        ls = LocalisedString.Format( ls, formatargs );
    }
    return ls;
}



/// Get a <tt>Localised< T ></tt> whose localised variations are embedded under
/// a given name as resources belonging to a given type
///
/// @exception ResourceMissingException
// TODO clarify
/// A version of the resource does not exist for at least the invariant culture
///
public static
Localised< T >  /// @returns A <tt>Localised< T ></tt> whose localised
                /// variations are embedded resources
_R<
    T           ///< Item type.  Underlying resources are implied to be the
                ///  same type.
>(
    Type type,  ///< Type the resources are associated with
                ///
                ///  Requirements:
                ///  - Really <tt>IsPresent< T ></tt>
                ///
    string name ///< Name the resources are embedded under
                ///
                ///  Requirements:
                ///  - Really <tt>IsPresent< T ></tt>
                ///  - <tt>IsNotBlank</tt>
)
    where T
        : class
{
    new NonNull().Check( type );
    new NonNull().Check( name );
    new NonBlankString().Check( name );

    // Fail early if a version for the invariant culture doesn't exist
    if( Get< T >( type, name, CultureInfo.GetCultureInfo( "" ) ) == null )
        throw new ResourceMissingException( type.FullName, name );

    // TODO
    //#if DEBUG
    //Check all existing versions for correct type
    //#endif

    return new LocalisedResource< T >( type, name );
}



/// Retrieve the most appropriate variation of a resource for a given culture,
/// of a given type, embedded under a given name, associated with a given type
///
/// If an appropriate resource does not exist, this method always returns
/// <tt>null</tt>.  This differs from <tt>System.Resources.ResourceManager</tt>
/// which, under the same circumstances, sometimes throws an exception (if
/// there are no embedded resources at all) and sometimes returns <tt>null</tt>
/// (if there are other embedded resources but not the one you're looking for)
///
/// @exception ResourceTypeMismatchException
/// An appropriate resource exists, but it is not a <tt>T</tt>
///
public static
T                       /// @returns The most appropriate variation of the
                        /// resource for the given culture, or
                        /// <tt>null</tt> if none can be found
Get<
    T                   ///< Type the resource is expected to be
>(
    Type        type,   ///< Type the resource is associated with
                        ///
                        ///  Requirements:
                        ///  - Really <tt>IsPresent< T ></tt>
                        ///
    string      name,   ///< Name the resource is embedded under
                        ///
                        ///  Requirements:
                        ///  - Really <tt>IsPresent< T ></tt>
                        ///  - <tt>IsNotBlank</tt>
                        ///
    CultureInfo culture ///< Culture to seek an appropriate variation for
                        ///
                        ///  Requirements:
                        ///  - Really <tt>IsPresent< T ></tt>
)
    where T
        : class
{
    new NonNull().Check( type );
    new NonNull().Check( name );
    new NonBlankString().Check( name );
    new NonNull().Check( culture );

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
///   lazy-creates and caches individual ResourceSets, each of which <em>reads
///   and caches ALL values</em> the first time any are accessed.  That means
///   <em>all</em> values_ for every accessed culture of every accessed type
///   end up cached in memory.  This is Mono's ResourceManager's
///   implementation's fault, not ours, as the only other (less desirable)
///   choice is to never reuse ResourceManagers at all.
/// - References to each <tt>System.Type</tt> encountered are kept as part of
///   the cache, which could possibly be an issue if you (somehow) want to
///   dynamically unload those <tt>System.Type</tt>s.
///
private static
ResourceManager
GetResourceManager(
    Type type
)
{
    new NonNull().Check( type );
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
//
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
//
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
        new NonNull().Check( culture );
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

