// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2010
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


namespace
Com.Halfdecent.Globalisation
{


// =============================================================================
/// Language/cultural variations of an item boxed up as one
///
/// (TODO intro)
///
/// A <tt>T</tt> can be used anywhere a <tt>Localised< T ></tt> is called for,
/// and it will be transparently "boxed" as the only variation.
///
/// In the other direction, a <tt>Localised< T ></tt> can be "unboxed" into a
/// <tt>T</tt> for the current (or a specifed) language/culture.
/// Because this process effectively "loses" the variations for all all other
/// languages, it is not transparent and must be done explicitly using the
/// <tt>Localised<T>.In()</tt> method, <tt>Localised<T>.InCurrent()</tt> method,
/// or explicit cast to <tt>T</tt> operator.
///
/// According to the abstract type pattern outlined in <tt>Com.Halfdecent</tt>,
/// this type should be an interface.  However, C# operators don't work with
/// interfaces and, since implicit operators are the basis for the transparent
/// boxing behaviour outlined above, an exception was made.
///
// =============================================================================

public abstract class
Localised<
    T
    ///< The type of underlying values
>
    : ILocalised
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Retrieve the most applicable variation for a specified culture
///
/// If a variation is not available for the exact culture specified, the
/// "closest" available variant will be provided.  A useful value for some
/// culture or another will always be available;  This indexer never returns
/// <tt>null</tt>.
///
/// @exception ArgumentNullException
/// The specified <tt>culture</tt> is <tt>null</tt>
///
/// @exception Exception
/// The underlying implementation generated a <tt>null</tt> value, which is a
/// bug.
///
public
    T
In(
    CultureInfo culture
)
{
    if( culture == null ) throw new ArgumentNullException( "culture" );
    T result = this.ForCulture( culture );
    if( object.ReferenceEquals( result, null ) )
        throw new Exception( string.Format(
            "Bug in {0}: ForCulture() returned null",
            this.GetType().FullName ) );
    return result;
}



/// Produce the value of the localisable item in the current language/culture
///
/// As indicated by <tt>System.Globalization.CultureInfo.CurrentCulture</tt>.
///
public
    T
InCurrent()
{
    return this.In( CultureInfo.CurrentCulture );
}



// -----------------------------------------------------------------------------
// ILocalised
// -----------------------------------------------------------------------------

    object
ILocalised.In(
    CultureInfo culture
)
{
    return this.In( culture );
}


    object
ILocalised.InCurrent()
{
    return this.InCurrent();
}



// -----------------------------------------------------------------------------
// Protected
// -----------------------------------------------------------------------------

/// Variation retrieval implementation
///
protected abstract
    T
    /// @returns
    /// A variation for the specified <tt>culture</tt>
    /// - Must never be <tt>null</tt>
ForCulture(
    CultureInfo culture
    ///< The culture for which a variation is desired
    ///  - Will never be <tt>null</tt>
);



// -----------------------------------------------------------------------------
// Object
// -----------------------------------------------------------------------------

/// Generate a string representation of this object
///
public override
    string
ToString()
{
    return this.InCurrent().ToString();
}



// -----------------------------------------------------------------------------
// Operators
// -----------------------------------------------------------------------------

/// Explicit conversion to <tt>T</tt>
///
/// "Unboxes" the <tt>Localised< T ></tt> to the variation most appropriate
/// for the current culture (via <tt>ForCurrentCulture()</tt>)
///
/// This conversion is explicit because it loses information, specifically
/// the variations for all other cultures
///
public static
explicit operator T(
    Localised< T > localised
)
{
    if( object.ReferenceEquals( localised, null ) ) return default( T );
    return localised.InCurrent();
}


/// Implicit conversion from <tt>T</tt>
///
/// "Boxes" the <tt>T</tt> into a <tt>Localised< T ></tt> (specifically, an
/// <tt>InMemoryLocalised< T ></tt>) as the invariant culture's variation.
///
public static
implicit operator Localised< T >(
    T value
)
{
    if( object.ReferenceEquals( value, null ) ) return null;
    return new SingleValueLocalised< T >( value );
}




} // type
} // namespace

