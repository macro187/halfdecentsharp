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



namespace
Com.Halfdecent.Globalization
{



/// <summary>
/// A read/write in-memory localized item
/// </summary>
public class
InMemoryLocalized<T>
    : Localized<T>
    where T : class
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// <summary>
/// Create a new <c>InMemoryLocalized&lt;T&gt;</c> with a given
/// invariant/untranslated version
/// </summary>
public
InMemoryLocalized( T invariantversion )
{
    if( invariantversion == null )
        throw new ArgumentNullException( "invariantversion" );
    this[ CultureInfo.InvariantCulture ] = invariantversion;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// <summary>
/// (see <c>Localized&lt;T&gt;)
/// </summary>
public override T
this[ CultureInfo culture ]
{
    get
    {
        if( culture == null ) throw new ArgumentNullException( "culture" );
        T r;
        for( CultureInfo c = culture; ; c = c.Parent ) {
            if( this.data.ContainsKey( c ) ) {
                r = this.data[ c ];
                break;
            }
            if( c == CultureInfo.InvariantCulture )
                throw new Exception( "BUG: No invariant version" );
        }
        return r;
    }
    set
    {
        if( culture == null ) throw new ArgumentNullException( "culture" );
        if( value == null ) throw new ArgumentNullException();
        this.data[ culture ] = value;
    }
}




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// <summary>
/// Indicates whether a version of the item exists for a specific culture
/// </summary>
public bool
Exists( CultureInfo culture )
{
    if( culture == null ) throw new ArgumentNullException( "culture" );
    return this.data.ContainsKey( culture );
}




// -----------------------------------------------------------------------------
// Operators
// -----------------------------------------------------------------------------




// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private Dictionary<CultureInfo,T>
data = new Dictionary<CultureInfo,T>();




} // type
} // namespace

