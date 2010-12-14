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
IsNull(
    this object dis
)
{
    return dis.IsNullDo( () => {} );
}


public static
    bool
IsNullDo(
    this object     dis,
    System.Action   action
)
{
    if( action == null ) throw new System.ArgumentNullException( "action" );

    if( dis != null ) return false;
    action();
    return true;
}


public static
    bool
Is<
    T
>(
    this object dis
)
{
    return
        dis.IsDo<
            T >(
            t => {} );
}


public static
    bool
IsDo<
    T
>(
    this object             dis,
    System.Action< T >      action
)
{
    return
        dis.IsAndDo<
            T >(
            t => true,
            action );
}


public static
    bool
IsAnd<
    T
>(
    this object             dis,
    System.Predicate< T >   predicate
)
{
    return
        dis.IsAndDo<
            T >(
            predicate,
            t => {} );
}


/// Perform an action on an object (or an underlying object for which it is an
/// <tt>IProxy</tt>) if it (or one of those underlying objects) is a specified
/// type and meets specified criteria
///
public static
    bool
    /// @returns
    /// Whether the object (or an underlying object for which it is an
    /// <tt>IProxy</tt>) was the specified type and met the specified criteria
    /// and, therefore, whether the action was performed
IsAndDo<
    T
    ///< The sought-after type
>(
    this object             dis,
    ///< The object
    System.Predicate< T >   predicate,
    ///< The criteria
    System.Action< T >      action
    ///< The action to perform
)
{
    if( object.ReferenceEquals( predicate, null ) )
        throw new System.ArgumentNullException( "predicate" );
    if( object.ReferenceEquals( action, null ) )
        throw new System.ArgumentNullException( "action" );

    if( dis == null ) return false;

    foreach( object obj in dis.ProxyChain() ) {
        if( !( obj is T ) ) continue;
        T t = (T)obj;
        if( !predicate( t ) ) continue;
        action( t );
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

