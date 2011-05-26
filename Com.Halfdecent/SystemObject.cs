// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010
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


using System.Linq;
using SCG = System.Collections.Generic;


namespace
Com.Halfdecent
{


// =============================================================================
/// <tt>System.Object</tt> Library
// =============================================================================

public static class
SystemObject
{



// -----------------------------------------------------------------------------
// Static Methods
// -----------------------------------------------------------------------------

/// Generate a string representation of the object
///
/// Also handles <tt>null</tt>
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


public static
    bool
Is<
    T
>(
    this object dis
)
{
    return dis.Match< T >( t => true );
}


public static
    bool
Match<
    T
>(
    this object         dis,
    System.Action< T >  action
)
{
    return dis.Match< T >( t => true, action );
}


public static
    T
MatchElse<
    T
>(
    this object     dis,
    System.Action   else_
)
{
    return dis.MatchElse< T >( t => true, else_ );
}


public static
    bool
TryMatch<
    T
>(
    this object dis,
    out T       match
)
{
    return dis.TryMatch< T >( t => true, out match );
}


public static
    bool
Match<
    T
>(
    this object             dis,
    System.Predicate< T >   predicate
)
{
    return dis.Match< T >( predicate, t => {;} );
}


public static
    bool
Match<
    T
>(
    this object             dis,
    System.Predicate< T >   predicate,
    System.Action< T >      action
)
{
    if( action == null )
        throw new System.ArgumentNullException( "action" );
    T t;
    if( !dis.TryMatch< T >( predicate, out t ) ) return false;
    action( t );
    return true;
}


public static
    T
MatchElse<
    T
>(
    this object             dis,
    System.Predicate< T >   predicate,
    System.Action           else_
)
{
    if( else_ == null )
        throw new System.ArgumentNullException( "else_" );
    T match = default( T );
    if( !dis.TryMatch< T >( predicate, out match ) )
        else_();
    return match;
}


public static
    bool
TryMatch<
    T
>(
    this object             dis,
    System.Predicate< T >   predicate,
    out T                   match
)
{
    if( predicate == null )
        throw new System.ArgumentNullException( "predicate" );

    match = default( T );

    if( dis == null ) return false;

    foreach( object obj in dis.ProxyChain() ) {
        if( !( obj is T ) ) continue;
        T t = (T)obj;
        if( !predicate( t ) ) continue;
        match = t;
        return true;
    }

    return false;
}


/// Look through any number of proxies to the underlying object
///
public static
    object
GetUnderlying(
    this object dis
)
{
    if( dis == null ) throw new System.ArgumentNullException( "dis" );
    return dis.ProxyChain().Last();
}


/// Iterate through this object and any proxies, recursively
///
public static
    SCG.IEnumerable< object >
ProxyChain(
    this object dis
)
{
    if( dis == null ) throw new System.ArgumentNullException( "dis" );
    return SystemEnumerable.Recurse(
        dis,
        obj => obj is IProxy ? ((IProxy)obj).Underlying : null );
}




} // type
} // namespace

