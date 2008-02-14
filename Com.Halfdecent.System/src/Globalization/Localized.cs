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



/// An item plus localized variations referred to as one
///
/// A <tt>Localized< T ></tt> can be used anywhere a <tt>T</tt> can.  When
/// this is done, it will transparently "unbox" to the variation most
/// appropriate for the current culture.
///
/// The opposite is also true.  That is, a <tt>T</tt> can be used anywhere a
/// <tt>Localized< T ></tt> is called for.  In these situation, the <tt>T</tt>
/// will "box" into a <tt>Localized< T ></tt> as the invariant or default
/// variation of the item.
///
public abstract class
Localized<
    T   ///< The type of localized item
>
    where T
        : class
{




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// Retrieve the variation of the item most appropriate for a particular culture
///
/// In the event that a variation of the item for the exact culture specified is
/// not available, a reasonable fallback may be returned instead (eg. the
/// variant for the parent or even the invariant culture).
///
/// Implementations must never return <tt>null</tt> as they are expected to be
/// able to provide at least an invariant/default variation.
///
/// @exception HDNotSupportedException
/// If the <tt>Localized< t ></tt> is read-only and an attempt is made to
/// <tt>set</tt> this property (This is a compromise due to C#'s inability to
/// have only a <tt>get</tt> in this type and add <tt>set</tt>s only in
/// writable subclasses)
///
abstract public
T
this[
    CultureInfo culture     ///< <tt>CultureInfo</tt> indicating the desired
                            ///  variation of the item
                            ///
                            ///  Requirements (<tt>get</tt>):
                            ///  - Really <tt>IsPresent< T ></tt>
                            ///
                            ///  Requirements (<tt>set</tt>):
                            ///  - Really <tt>IsPresent< T ></tt>
]
{
    get;
    set;
}




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Produce the variation of the item most appropriate for the current culture
///
protected
T
ForCurrentCulture()
{
     return this[ CultureInfo.CurrentCulture ];
}




// -----------------------------------------------------------------------------
// Operators
// -----------------------------------------------------------------------------

/// Implicit conversion to <tt>T</tt>
///
/// "Unboxes" the <tt>Localized< T ></tt> to the variation most appropriate
/// for the current culture (via <tt>ForCurrentCulture()</tt>)
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
/// "Boxes" the <tt>T</tt> into a <tt>Localized< T ></tt> (specifically, an
/// <tt>InMemoryLocalized< T ></tt>) as the invariant culture's variation.
///
public static
implicit operator Localized< T >(
    T t
)
{
    return (t != null ? new InMemoryLocalized< T >( t ) : null);
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
    // TODO
    // Localized< typeof(T).FullName >
    //   (invariant) ...
    //   en          ...
    //   ja_JP       ...
    //   fr_CA       ...
    //   ...
    return this.ForCurrentCulture().ToString();
}




} // type
} // namespace

