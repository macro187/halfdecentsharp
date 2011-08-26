// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010
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


using System.Globalization;
using System.Resources;
using System.Collections.Generic;
using System.IO;
using Com.Halfdecent;
using Com.Halfdecent.Globalisation;


namespace
Com.Halfdecent.Resources
{


// =============================================================================
/// A <tt>Localised<T></tt> representing embedded resources of a particular
/// name belonging to a particular type
///
/// This uses a parent culture fallback algorithm, so if no resource is
/// available for the exact culture specified, that culture's neutral culture
/// will be tried, followed by the invariant culture.  See
/// <tt>LocalisedBase<T>.ParentFallbacksFor()</tt>.
// =============================================================================

public class
LocalisedResource<
    T
>
    : FallbackLocalised< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
LocalisedResource(
    System.Type type,
    string      name
)
{
    if( type == null ) throw new System.ArgumentNullException( "type" );
    if( name == null ) throw new System.ArgumentNullException( "name" );
    if( name == "" ) throw new System.ArgumentException( "Is blank", "name" );
    this.type = type;
    this.name = name;
}



// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private
System.Type
type;


private
string
name;


private
ResourceManager
manager = null;


private class
InternalResourceManager
    : ResourceManager
{
    public
    InternalResourceManager(
        System.Type type
    )
        : base( type )
    {
        if( type == null ) throw new System.ArgumentNullException( "type" );
        this.sourcetype = type;
    }

    private
    System.Type
    sourcetype;

    protected override
        ResourceSet
    InternalGetResourceSet(
        CultureInfo culture,
        bool        Createifnotexists,
        bool        tryParents
    )
    {
        if( culture == null )
            throw new System.ArgumentNullException( "culture" );

        Stream s = null;
        try {
            s = this.MainAssembly.GetManifestResourceStream(
                this.sourcetype,
                this.GetResourceFileName( culture ) );
        } catch( FileNotFoundException ) {
        }
        if( s != null ) return new ResourceSet( s );

        return base.InternalGetResourceSet(
            culture, Createifnotexists, tryParents );
    }
}



// -----------------------------------------------------------------------------
// LocalisedBase< T >
// -----------------------------------------------------------------------------

protected override
    IEnumerable< CultureInfo >
FallbacksFor(
    CultureInfo culture
)
{
    return FallbackLocalised.ParentFallbacksFor( culture );
}


protected override
    IMaybe< T >
TryIn(
    CultureInfo culture
)
{
    if( this.manager == null )
        this.manager = new InternalResourceManager( this.type );

    // If a ResourceSet is unavailable for the specified culture,
    // GetResourceSet() returns null under some circumstances and throws a
    // MissingManifestResourceException under others*.  We don't care why a
    // resource set might not be present, only whether it is or not, so we
    // handle both cases the same.
    //
    // * Specifically, if there are neither resources for the requested
    //   culture nor for the invariant culture you get the exception,
    //   otherwise you get null
    //
    ResourceSet set;
    try {
        set = this.manager.GetResourceSet( culture, false, false );
    } catch( MissingManifestResourceException ) {
        set = null;
    }
    if( set == null ) return Maybe.Create< T >();

    // Once we have a ResourceSet, GetObject() will give us the embedded
    // resource as an object, or null if it doesn't have anything under the
    // given name
    //
    object obj = set.GetObject( this.name );
    if( obj == null ) return Maybe.Create< T >();

    // Blow up if it's not of the expected type
    //
    if( !(obj is T) )
        throw new ResourceTypeMismatchException(
            typeof( T ).FullName,
            obj.GetType().FullName,
            this.type.FullName,
            this.name,
            culture.Name );

    return Maybe.Create( (T)obj );
}


protected override
    T
Default()
{
    throw new ResourceMissingException( this.type, this.name );
}




} // type
} // namespace

