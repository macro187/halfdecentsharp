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



/// <summary>
/// An item that can have different versions for different cultures
/// </summary>
/// <remarks>
/// This would probably be better as an interface, but C# doesn't allow
/// conversion operators on interfaces.
/// </remarks>
public abstract class
Localized<T>
    where T : class
{




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// <summary>
/// Retrieve the version of the item most appropriate for a particular culture
/// </summary>
/// <remarks>
/// <p>
/// In the event that a version for the exact culture specified is not
/// available, some reasonable fallback may be returned instead (eg. a
/// parent or even the invariant culture).
/// </p>
/// <p>
/// C# can't enforce post-conditions, but if it could, this would
/// mandate that implementations never return null.  That doesn't mean
/// exceptions indicating larger problems eg. missing resources etc. won't
/// happen.
/// </p>
/// <p>
/// C# can't handle get/set separately for inheritance purposes ie. we can't
/// specify 'get' here and only add the 'set' in writable subclasses, without
/// triggering compiler warnings.
/// As a compromise, just throw InvalidOperationException in 'set' if your
/// subclass is read-only.
/// </p>
/// </remarks>
/// <param name="culture">
/// A <c>CultureInfo</c> (which must not be a neutral culture) indicating
/// the desired version of the item
/// </param>
abstract public T this[ CultureInfo culture ]
{
    get;
    set;
}




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// <summary>
/// Returns a string representation of the version of the item for the current
/// culture
/// <summary>
public override string
ToString()
{
    return this.ForCurrentCulture().ToString();
}




// -----------------------------------------------------------------------------
// Operators
// -----------------------------------------------------------------------------

/// <summary>
/// Implicit conversion to <c>T</c>
/// </summary>
/// <remarks>
/// Allows a <c>Localized&lt;T&gt;</c> to be used anywhere a <c>T</c> would be.
/// Converts to the version of the item for <c>CurrentCulture</c>.
/// </remarks>
public static implicit operator T( Localized<T> l )
{
    return (l != null ? l.ForCurrentCulture() : null);
}


/// <summary>
/// Implicit conversion from <c>T</c>
/// </summary>
/// <remarks>
/// Allows a non-null <c>T</c> to be used anywhere a
/// <c>Localized&lt;T&gt;</c> is expected.  The <c>T</c> value gets wrapped
/// in an <c>InMemoryLocalized&lt;T&gt; as the invariant culture version of
/// the item.
/// </remarks>
public static implicit operator Localized<T>( T t )
{
    return (t != null ? new InMemoryLocalized<T>( t ) : null);
}




// -----------------------------------------------------------------------------
// Protected
// -----------------------------------------------------------------------------

/// <summary>
/// The version of the item for the current culture
/// </summary>
protected T
ForCurrentCulture()
{
     return this[ CultureInfo.CurrentCulture ];
}




} // type
} // namespace

