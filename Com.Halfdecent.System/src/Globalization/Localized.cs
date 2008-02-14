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
using System.Globalization;


namespace
Com.Halfdecent.Globalization
{



/// An item that can have different versions for different cultures
///
/// This would probably be better as an interface, but C# doesn't allow
/// conversion operators on interfaces.
///
public abstract class
Localized<
    T   ///< The underlying type of localized item
>
    where T : class
{




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// Retrieve the version of the item most appropriate for a particular culture
///
/// @par
/// In the event that a version for the exact culture specified is not
/// available, some reasonable fallback may be returned instead (eg. a
/// parent or even the invariant culture).
/// 
/// @par
/// C# can't enforce post-conditions, but if it could, this would
/// mandate that implementations never return null.  That doesn't mean
/// exceptions indicating larger problems eg. missing resources etc. won't
/// happen.
///
/// @par
/// C# can't handle get/set separately for inheritance purposes ie. we can't
/// specify 'get' here and only add the 'set' in writable subclasses, without
/// triggering compiler warnings.
/// As a compromise, just throw InvalidOperationException in 'set' if your
/// subclass is read-only.
///
abstract public
T
this[
    CultureInfo culture     ///< A <tt>CultureInfo</tt> (which must not be a
                            ///  neutral culture) indicating the desired
                            ///  version of the item
]
{
    get;
    set;
}




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Returns a string representation of the version of the item for the current
/// culture
///
public override
string
ToString()
{
    return this.ForCurrentCulture().ToString();
}




// -----------------------------------------------------------------------------
// Operators
// -----------------------------------------------------------------------------

/// Implicit conversion to <tt>T</tt>
///
/// Allows a <tt>Localized< T ></tt> to be used anywhere a <tt>T</tt> would.
/// Converts to the version of the item for <tt>CurrentCulture</tt>.
///
public static
implicit operator T(
    Localized<T> l
)
{
    return (l != null ? l.ForCurrentCulture() : null);
}



/// Implicit conversion from <tt>T</tt>
///
/// Allows a non-null <tt>T</tt> to be used anywhere a <tt>Localized< T ></tt>
/// would.  Wraps the <tt>T</tt> value in an <tt>InMemoryLocalized< T ></tt>
/// as the invariant culture version of the item.
///
public static
implicit operator Localized< T >(
    T t
)
{
    return (t != null ? new InMemoryLocalized< T >( t ) : null);
}




// -----------------------------------------------------------------------------
// Protected
// -----------------------------------------------------------------------------

/// The version of the item for the current culture
///
protected
T
ForCurrentCulture()
{
     return this[ CultureInfo.CurrentCulture ];
}




} // type
} // namespace

