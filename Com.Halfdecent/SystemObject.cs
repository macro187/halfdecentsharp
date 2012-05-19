// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010, 2011, 2012
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
using System.Linq;
using System.Collections.Generic;


namespace
Com.Halfdecent
{


// =============================================================================
/// `System.Object` Library
// =============================================================================

public static class
SystemObject
{



// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// Generate a string representation of the object
///
/// Also handles `null`
///
public static
    string
ToString(
    object obj
)
{
    if( obj == null ) return "null";
    return obj.ToString();
}



// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

// TODO Document Match() - Returns() - When() - Else() pattern
//
public static
    MatchResult< T >
Match<
    T
>(
    this T dis
)
{
    return new MatchResult< T >( dis );
}


public static
    bool
Is<
    T
>(
    this object dis
)
{
    return dis.As< T >().HasValue;
}


public static
    bool
Is<
    T
>(
    this object     dis,
    Predicate< T >  predicate
)
{
    return dis.As< T >( predicate ).HasValue;
}


public static
    IMaybe< T >
As<
    T
>(
    this object dis
)
{
    return dis.As< T >( t => true );
}


public static
    IMaybe< T >
As<
    T
>(
    this object     dis,
    Predicate< T >  predicate
)
{
    if( predicate == null )
        throw new ArgumentNullException( "predicate" );
    if( dis == null )
        return Maybe.Create< T >();
    foreach( object obj in dis.ProxyChain() ) {
        if( !( obj is T ) ) continue;
        T t = (T)obj;
        if( !predicate( t ) ) continue;
        return Maybe.Create( t );
    }
    return Maybe.Create< T >();
}


/// Look through any number of proxies to the underlying object
///
public static
    object
GetUnderlying(
    this object dis
)
{
    if( dis == null )
        throw new ArgumentNullException( "dis" );
    return dis.ProxyChain().Last();
}


/// Iterate through this object and any proxies, recursively
///
public static
    IEnumerable< object >
ProxyChain(
    this object dis
)
{
    if( dis == null )
        throw new ArgumentNullException( "dis" );
    return SystemEnumerable.Recurse(
        dis,
        obj => obj is IProxy ? ((IProxy)obj).Underlying : null );
}




} // type
} // namespace

