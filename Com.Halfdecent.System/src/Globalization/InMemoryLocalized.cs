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
using System.Collections.Generic;
using Com.Halfdecent.System;


namespace
Com.Halfdecent.Globalization
{




/// A read/write in-memory <tt>Localized< T ></tt>
///
public class
InMemoryLocalized<
    T
>
    : Localized< T >
    where T
        : class
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Create a new <tt>InMemoryLocalized< T ></tt> with a given invariant culture
/// variation
///
public
InMemoryLocalized(
    T invariantVariation    ///< Invariant culture variation of the item
                            ///
                            ///  Requirements:
                            ///  - <tt>IsPresent< T ></tt>
)
{
    new IsPresent< T >().Require( invariantVariation );
    this[ CultureInfo.InvariantCulture ] = invariantVariation;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// Culture -> Value dictionary containing variants
protected
Dictionary< CultureInfo, T >
Data
{
    get { return this.data; }
}

private
Dictionary< CultureInfo, T >
data = new Dictionary< CultureInfo, T >();




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Determine whether a variation of the item exists for an exact given
/// culture
///
/// This method checks for existence of a variation for an exact culture.  No
/// fallback mechanisms are involved.
///
public
bool
Contains(
    CultureInfo culture ///< The culture for which to determine whether a
                        ///  variation exists
                        ///
                        ///  Requirements:
                        ///  - <tt>IsPresent< T ></tt>
)
{
    new IsPresent< CultureInfo >().Require( culture );
    return this.Data.ContainsKey( culture );
}



/// Retrieve the most appropriate variation available for a given culture
///
/// "Most appropriate" is currently defined as the culture itself or the most
/// specific ancestor culture for which a variation exists.
///
/// Note that this method will never return <tt>null</tt> as the invariant
/// culture's variation will be returned if no more appropriate variation is
/// available.
///
public
T                       /// @returns The variation most appropriate for the
                        /// specified culture
GetBest(
    CultureInfo culture ///< Culture to retrieve a variation for
                        ///
                        ///  Requirements:
                        ///  - <tt>IsPresent< T ></tt>
)
{
    new IsPresent< CultureInfo >().Require( culture );
    T result;
    for( CultureInfo c = culture; ; c = c.Parent ) {
        if( this.Contains( c ) ) {
            result = this.Get( c );
            break;
        }
        if( c == CultureInfo.InvariantCulture ) throw new BugException(
            _S("INTERNAL BUG: No invariant variation") );
    }
    return result;
}



/// Retrieve the variation for an exact given culture
///
/// @exception TODO SOMEKINDOFException
/// There is no variation for the specified culture
///
public
T                       /// @returns This item's variation for the specified
                        /// culture
Get(
    CultureInfo culture ///< Culture whose variation is being retrieved
                        ///
                        ///  Requirements:
                        ///  - <tt>IsPresent< T ></tt>
                        ///  - TODO <tt>IsEXISTINGKEYIN( this )</tt>
)
{
    new IsPresent< CultureInfo >().Require( culture );
    // TODO if( !this.Contains( culture ) ) throw new SOMEKINDOFException();
    if( !this.Contains( culture ) ) throw new ValueException();
        // _S("This item has no variation for {0}")
    return this.Data[ culture ];
}



/// Add / change the variation for a given culture
///
public
void
Set(
    CultureInfo culture,    ///< Culture whose variation is being set
                            ///
                            ///  Requirements:
                            ///  - <tt>IsPresent< T ></tt>
                            ///
    T           value       ///  The new variation of the item
                            ///  - <tt>IsPresent< T ></tt>
)
{
    new IsPresent< CultureInfo >().Require( culture );
    new IsPresent< T >().Require( value );
    this.Data[ culture ] = value;
}



/// Remove the variation for a given culture
///
public
void
Remove(
    CultureInfo culture     ///< Culture whose variation is being removed
                            ///
                            ///  Requirements:
                            ///  - <tt>IsPresent< T ></tt>
                            ///  - TODO <tt>IsEXISTINGKEYIN( this )</tt>
                            ///  - TODO <tt>IsNotInvariantCulture</tt>
)
{
    new IsPresent< CultureInfo >().Require( culture );
    // TODO new IsNotInvariantCulture().Require( culture );
    if( culture == CultureInfo.InvariantCulture ) throw new ValueException();
        // _S("{0} must not be the invariant culture")
    // TODO if( !this.Contains( culture ) ) throw new SOMEKINDOFException();
    if( !this.Contains( culture ) ) throw new ValueException();
        // _S("A variation of the item must exist for {0}")
    this.Data.Remove( culture );
}




// -----------------------------------------------------------------------------
// Localized< T >
// -----------------------------------------------------------------------------

/// (See <tt>Localized< T >.this[]</tt>)
///
/// Getting this property retrieves the most appropriate variation for the
/// specified culture.
///
/// Setting this property adds or changes the variation for the specified
/// culture.  Setting a variation to <tt>null</tt> removes it.
///
/// Note that because a variation must always exist for the invariant culture,
/// it can be changed but not removed ie. it cannot be set to <tt>null</tt>.
///
/// Value Requirements:
/// - <tt>IsPresent< T ></tt>
///   (when <tt>culture</tt> == <tt>InvariantCulture</tt>)
///
public override
T
this[
    CultureInfo culture ///< The culture whose variant is being set or
                        ///  retrieved
                        ///
                        ///  Requirements:
                        ///  - <tt>IsPresent< T ></tt>
]
{
    get
    {
        return this.GetBest( culture );
    }
    set
    {
        if( value != null ) {
            this.Set( culture, value );
        } else {
            this.Remove( culture );
        }
    }
}




private static Com.Halfdecent.Globalization.Localized< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

