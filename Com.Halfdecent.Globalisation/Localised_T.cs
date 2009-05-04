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
/// "closest" available variant will be provided.
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
/// @returns The most applicable variation for the specified culture.
/// A useful value for some culture or another will always be available;  This
/// method never returns <tt>null</tt>.
///
this[
    CultureInfo culture
]
{
    get
    {
        if( culture == null ) throw new ArgumentNullException( "culture" );
        T result = this.ForCulture( culture );
        if( (object)result == null ) throw new Exception(
            "Bug in Localised< T > subclass: ForCulture() returned null" );
        return result;
    }
}



// -----------------------------------------------------------------------------
// Protected
// -----------------------------------------------------------------------------

/// Variation retrieval implementation
///
protected abstract
T
/// @returns A variation for the specified <tt>culture</tt>
///
/// Implementations must never return <tt>null</tt>
ForCulture(
    CultureInfo culture
    ///< The culture for which a variation is desired
    ///
    ///  Implementations are guaranteed this will never be <tt>null</tt>
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
    return this[ CultureInfo.CurrentCulture ].ToString();
}



// -----------------------------------------------------------------------------
// Operators
// -----------------------------------------------------------------------------

/// Implicit conversion to <tt>T</tt>
///
/// "Unboxes" the <tt>Localised< T ></tt> to the variation most appropriate
/// for the current culture (via <tt>ForCurrentCulture()</tt>)
///
public static
implicit operator T(
    Localised< T > localised
)
{
    return localised == null
        ? default( T )
        : localised[ CultureInfo.CurrentCulture ];
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

