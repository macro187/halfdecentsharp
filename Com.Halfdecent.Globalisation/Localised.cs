// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2011
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
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using Com.Halfdecent;


namespace
Com.Halfdecent.Globalisation
{


// =============================================================================
/// <tt>ILocalised</tt> and <tt>Localised<T></tt> library
// =============================================================================

public static class
Localised
{



// -----------------------------------------------------------------------------
// Static
// -----------------------------------------------------------------------------

public static
    Localised< T >
Create<
    T
>(
    T singleValue
)
{
    return Create< T >(
        (uc,c) => Maybe.Create( singleValue ) );
}


public static
    Localised< T >
Create<
    T
>(
    LocalisedFunc< T > inFunc
)
{
    return new Localised< T >( inFunc );
}


//
// TODO
// Allow registration of per-process and per-thread GetFallbackCultures
// functions
//


public static
    IEnumerable< CultureInfo >
GetFallbackCultures(
    CultureInfo culture
)
{
    if( culture == null ) throw new ArgumentNullException( "culture" );
    for( ;; ) {
        culture = culture.Parent;
        if( culture.Name == "" ) yield break;
        yield return culture;
    }
}



// -----------------------------------------------------------------------------
// Extension
// -----------------------------------------------------------------------------

public static
    T
InCurrent<
    T
>(
    this Localised< T > dis
)
{
    if( dis == null )
        throw new ArgumentNullException( "dis" );
    return dis.PairInCurrent().Value;
}


public static
    T
In<
    T
>(
    this Localised< T > dis,
    CultureInfo         culture
)
{
    if( dis == null )
        throw new ArgumentNullException( "dis" );
    return dis.In( culture, culture );
}


public static
    T
In<
    T
>(
    this Localised< T > dis,
    CultureInfo         uiculture,
    CultureInfo         culture
)
{
    if( dis == null )
        throw new ArgumentNullException( "dis" );
    return dis.PairIn( uiculture, culture ).Value;
}


public static
    T
In<
    T
>(
    this Localised< T > dis,
    CultureInfo         uiculture,
    CultureInfo         culture,
    CultureFallbackFunc getFallbackCultures
)
{
    if( dis == null )
        throw new ArgumentNullException( "dis" );
    return dis.PairIn( uiculture, culture, getFallbackCultures ).Value;
}


public static
    CultureValuePair< T >
PairInCurrent<
    T
>(
    this Localised< T > dis
)
{
    if( dis == null )
        throw new ArgumentNullException( "dis" );
    return dis.PairIn(
        CultureInfo.CurrentUICulture,
        CultureInfo.CurrentCulture );
}


public static
    CultureValuePair< T >
PairIn<
    T
>(
    this Localised< T > dis,
    CultureInfo         uiculture,
    CultureInfo         culture
)
{
    if( dis == null )
        throw new ArgumentNullException( "dis" );
    return dis.PairIn(
        uiculture,
        culture,
        GetFallbackCultures );
}


public static
    CultureValuePair< T >
PairIn<
    T
>(
    this Localised< T > dis,
    CultureInfo         uiculture,
    CultureInfo         culture,
    CultureFallbackFunc getFallbackCultures
)
{
    if( dis == null )
        throw new ArgumentNullException( "dis" );
    if( getFallbackCultures == null )
        throw new ArgumentNullException( "getFallbackCultures" );
    return
        SystemEnumerable.Create( uiculture )
        .Concat( getFallbackCultures( uiculture ) )
        .Append( CultureInfo.InvariantCulture )
        .Select( c => CultureValuePair.Create( c, dis.TryIn( c, culture ) ) )
        .Where( p => p.Value.HasValue )
        .Select( p => CultureValuePair.Create( p.Culture, p.Value.Value ) )
        .First();
}


public static
    Localised< object >
AsLocalisedObject(
    this ILocalised dis
)
{
    if( dis == null ) throw new ArgumentNullException( "dis" );
    return Localised.Create< object >( dis.TryIn );
}


public static
    Localised< TTo >
Covary<
    TFrom,
    TTo
>(
    this Localised< TFrom > dis
)
    where TFrom : TTo
{
    if( dis == null ) throw new ArgumentNullException( "dis" );
    return Create< TTo >( dis.TryIn );
}




} // type
} // namespace

