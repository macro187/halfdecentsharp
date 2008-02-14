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
using R = Com.Halfdecent.Resources.Resource;


namespace
Com.Halfdecent.Globalization
{




/// A read/write in-memory localized item
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

/// Create a new <tt>InMemoryLocalized< T ></tt> with a given
/// invariant/untranslated version
///
public
InMemoryLocalized(
    T invariantVersion
)
{
    new IsPresent< T >().ReallyRequire( invariantVersion );
    this[ CultureInfo.InvariantCulture ] = invariantVersion;
}




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Determine whether a version of the item exists for a given culture
///
public
bool
Exists(
    CultureInfo culture
)
{
    new IsPresent< CultureInfo >().ReallyRequire( culture );
    return this.data.ContainsKey( culture );
}




// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private
Dictionary< CultureInfo, T >
data = new Dictionary< CultureInfo, T >();




// -----------------------------------------------------------------------------
// Localized< T >
// -----------------------------------------------------------------------------

public override
T
this[
    CultureInfo culture
]
{
    get
    {
        new IsPresent< CultureInfo >().ReallyRequire( culture );
        T r;
        for( CultureInfo c = culture; ; c = c.Parent ) {
            if( this.data.ContainsKey( c ) ) {
                r = this.data[ c ];
                break;
            }
            if( c == CultureInfo.InvariantCulture )
                throw new BugException( R._S("BUG: No invariant version") );
        }
        return r;
    }
    set
    {
        new IsPresent< CultureInfo >().ReallyRequire( culture );
        new IsPresent< T >().ReallyRequire( value );
        this.data[ culture ] = value;
    }
}




} // type
} // namespace

