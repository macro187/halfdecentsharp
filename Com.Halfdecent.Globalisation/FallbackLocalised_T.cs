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
using System.Collections.Generic;
using Com.Halfdecent;


namespace
Com.Halfdecent.Globalisation
{


// =============================================================================
/// <tt>Localised<T></tt> with a culture fallback mechanism
// =============================================================================

public class
FallbackLocalised<
    T
>
    : Localised< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
FallbackLocalised(
    Func< CultureInfo, IEnumerable< CultureInfo > > fallbacksForFunc,
    ///< See <tt>FallbacksFor()</tt>
    Func< CultureInfo, ITuple< bool, T > >          tryInFunc,
    ///< See <tt>TryIn()</tt>
    Func< T >                                       defaultFunc
    ///< See <tt>Default()</tt>
)
{
    if( object.ReferenceEquals( fallbacksForFunc, null ) )
        throw new ArgumentNullException( "fallbacksForFunc" );
    if( object.ReferenceEquals( tryInFunc, null ) )
        throw new ArgumentNullException( "tryInFunc" );
    if( object.ReferenceEquals( defaultFunc, null ) )
        throw new ArgumentNullException( "defaultFunc" );
}



// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private
Func< CultureInfo, IEnumerable< CultureInfo > >
FallbacksForFunc = null;


private
Func< CultureInfo, ITuple< bool, T > >
TryInFunc = null;


private
Func< T >
DefaultFunc = null;



// -----------------------------------------------------------------------------
// Protected
// -----------------------------------------------------------------------------

protected
FallbackLocalised()
{
}


protected virtual
    IEnumerable< CultureInfo >
FallbacksFor(
    CultureInfo culture
)
{
    if( this.FallbacksForFunc != null ) return this.FallbacksForFunc( culture );
    throw new NotImplementedException();
}


protected virtual
    ITuple< bool, T >
TryIn(
    CultureInfo culture
)
{
    if( this.TryInFunc != null ) return this.TryInFunc( culture );
    throw new NotImplementedException();
}


protected virtual
    T
Default()
{
    if( this.DefaultFunc != null ) return this.DefaultFunc();
    throw new NotImplementedException();
}



// -----------------------------------------------------------------------------
// Localised<T>
// -----------------------------------------------------------------------------

protected override
    T
ProtectedIn(
    CultureInfo culture
)
{
    bool success;
    T r;

    // Try specified culture
    this.TryIn( culture ).AssignTo( out success, out r );
    if( success ) return r;

    // Try fallbacks
    foreach( CultureInfo c in this.FallbacksFor( culture ) ) {
        if( c == null )
            throw new Exception( string.Format(
                "Bug: FallbacksFor( {0} ) yielded a null culture",
                culture.ToString() ) );
        this.TryIn( c ).AssignTo( out success, out r );
        if( success ) return r;
    }

    // Default
    return this.Default();
}




} // type
} // namespace

