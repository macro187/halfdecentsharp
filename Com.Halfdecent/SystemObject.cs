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
IsAnd<
    T
>(
    this object             dis,
    System.Func< T, bool >  predicate
)
    where T : class
{
    if( object.ReferenceEquals( dis, null ) )
        throw new System.ArgumentNullException( "dis" );
    if( object.ReferenceEquals( predicate, null ) )
        throw new System.ArgumentNullException( "predicate" );
    T t = dis as T;
    if( object.ReferenceEquals( t, null ) ) return false;
    return predicate( t );
}


public static
    bool
IfIsDo<
    T
>(
    this object         dis,
    System.Action< T >  action
)
    where T : class
{
    if( object.ReferenceEquals( dis, null ) )
        throw new System.ArgumentNullException( "dis" );
    if( object.ReferenceEquals( action, null ) )
        throw new System.ArgumentNullException( "action" );
    T t = dis as T;
    if( object.ReferenceEquals( t, null ) ) return false;
    action( t );
    return true;
}


public static
    bool
IfIsAndDo<
    T
>(
    this object             dis,
    System.Predicate< T >   predicate,
    System.Action< T >      action
)
    where T : class
{
    if( object.ReferenceEquals( dis, null ) )
        throw new System.ArgumentNullException( "dis" );
    if( object.ReferenceEquals( predicate, null ) )
        throw new System.ArgumentNullException( "predicate" );
    if( object.ReferenceEquals( action, null ) )
        throw new System.ArgumentNullException( "action" );
    T t = dis as T;
    if( object.ReferenceEquals( t, null ) ) return false;
    if( !predicate( t ) ) return false;
    action( t );
    return true;
}




} // type
} // namespace

