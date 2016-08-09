// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2010, 2011
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
Halfdecent.Globalisation
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
/// According to the abstract type pattern outlined in <tt>Halfdecent</tt>,
/// this type should be an interface.  However, C# operators don't work with
/// interfaces and, since implicit operators are the basis for the transparent
/// boxing behaviour outlined above, an exception was made.
///
// =============================================================================

public class
Localised<
    T
>
    : ILocalised
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
Localised(
    LocalisedFunc< T > tryInFunc
)
{
    if( tryInFunc == null )
        throw new ArgumentNullException( "tryInFunc" );
    this.TryInFunc = tryInFunc;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

private
LocalisedFunc< T >
TryInFunc = null;



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

public
    IMaybe< T >
TryIn(
    CultureInfo uiculture,
    CultureInfo culture
)
{
    if( uiculture == null ) throw new ArgumentNullException( "uiculture" );
    if( culture == null ) throw new ArgumentNullException( "culture" );
    IMaybe< T > r = this.TryInFunc( uiculture, culture );
    if( uiculture == CultureInfo.InvariantCulture && !r.HasValue )
        throw new BugException(
            "this.TryInFunc couldn't produce a variation for the invariant"
            + " culture" );
    return r;
}



// -----------------------------------------------------------------------------
// ILocalised
// -----------------------------------------------------------------------------

    IMaybe< object >
ILocalised.TryIn(
    CultureInfo uiculture,
    CultureInfo culture
)
{
    return this.TryIn( uiculture, culture ).Covary< T, object >();
}



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
    return localised != null
        ? localised.InCurrent()
        : default( T );
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
    return value != null
        ? Localised.Create< T >( value )
        : null;
}




} // type
} // namespace

