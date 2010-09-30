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


namespace
Com.Halfdecent.Globalisation
{


// =============================================================================
/// Represents localised variations of an item collectively as one
///
/// A <tt>Localised< T ></tt> can be used anywhere a <tt>T</tt> is called for.
/// When this is done, it transparently "flattens" or "unboxes" to an
/// unlocalised value of T appropriate for the current culture via an
/// implicit conversion operator.
///
/// The opposite is also true.  That is, a <tt>T</tt> can be used anywhere a
/// <tt>Localised< T ></tt> is called for.  When this is done, the <tt>T</tt>
/// will be transparently "boxed" into a <tt>Localised< T ></tt> as the
/// invariant (and only) variation of the item via an implicit conversion
/// operator.
///
/// According to the abstract type pattern outlined in <tt>Com.Halfdecent</tt>,
/// this type would be an interface.  But C# operators don't work with them, and
/// implicit operators are the basis for the transparent boxing behaviour
/// outlined above, so a compromise was made and, as a result, this type is an
/// abstract class.
// =============================================================================

public abstract class
Localised<
    T
    ///< The type of underlying values
>
{



// -----------------------------------------------------------------------------
// Indexer
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
/// variations for all other cultures
///
public static
explicit operator T(
    Localised< T > localised
)
{
    return localised == null
        ? default( T )
        : localised.InCurrent();
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
    return (object)value == null
        ? null
        : new SingleValueLocalised< T >( value );
}




} // type
} // namespace

