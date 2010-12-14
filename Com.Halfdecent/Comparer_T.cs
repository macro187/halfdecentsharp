// -----------------------------------------------------------------------------
// Copyright (c) 2009
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


using SCG = System.Collections.Generic;


namespace
Com.Halfdecent
{


// =============================================================================
/// An <tt>IComparer<T></tt> that uses specified <tt>Compare()</tt>,
/// <tt>Equals()</tt>, and <tt>GetHashCode()</tt> functions
// =============================================================================

public sealed class
Comparer<
    T
>
    : IComparer< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialise a new <tt>Comparer<T></tt>
///
/// @exception System.ArgumentNullException
/// <tt>compareFunction</tt> is <tt>null</tt>
/// - OR -
/// <tt>getHashCodeFunction</tt> is <tt>null</tt>
///
public
Comparer(
    System.Comparison< T >      compareFunction,
    ///< <tt>IComparer<T>.Compare()</tt> function
    ///
    System.Func< T, int >       getHashCodeFunction
    ///< <tt>IEqualityComparer<T>.GetHashCode()</tt> function
    ///
)
    : this( compareFunction, null, getHashCodeFunction )
{
}


/// Initialise a new <tt>Comparer<T></tt>
///
/// @exception System.ArgumentNullException
/// <tt>compareFunction</tt> is <tt>null</tt>
/// - OR -
/// <tt>getHashCodeFunction</tt> is <tt>null</tt>
///
public
Comparer(
    System.Comparison< T >      compareFunction,
    ///< <tt>IComparer<T>.Compare()</tt> function
    ///
    System.Func< T, T, bool >   equalsFunction,
    ///< <tt>IEqualityComparer<T>.Equals()</tt> function
    ///
    ///  If <tt>null</tt>, <tt>compareFunction</tt> will be used to derive
    ///  equality
    ///
    System.Func< T, int >       getHashCodeFunction
    ///< <tt>IEqualityComparer<T>.GetHashCode()</tt> function
    ///
)
{
    if( compareFunction == null )
        throw new System.ArgumentNullException( "compareFunction" );
    if( getHashCodeFunction == null )
        throw new System.ArgumentNullException( "getHashCodeFunction" );
    this.CompareFunction = compareFunction;
    this.EqualsFunction =
        equalsFunction ??
        ( ( dis, dat ) => compareFunction( dis, dat ) == 0 );
    this.GetHashCodeFunction = getHashCodeFunction;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
System.Comparison< T >
CompareFunction
{
    get;
    private set;
}


public
System.Func< T, T, bool >
EqualsFunction
{
    get;
    private set;
}


public
System.Func< T, int >
GetHashCodeFunction
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// System.Collections.Generic.IComparer< T >
// -----------------------------------------------------------------------------

public
    int
Compare(
    T dis,
    T that
)
{
    return this.CompareFunction( dis, that );
}



// -----------------------------------------------------------------------------
// System.Collections.Generic.IEqualityComparer< T >
// -----------------------------------------------------------------------------

public
    bool
Equals(
    T dis,
    T that
)
{
    return this.EqualsFunction( dis, that );
}


public
    int
GetHashCode(
    T item
)
{
    if( object.ReferenceEquals( item, null ) )
        throw new System.ArgumentNullException( "item" );
    return this.GetHashCodeFunction( item );
}



// -----------------------------------------------------------------------------
// IEquatable< IEqualityComparer >
// -----------------------------------------------------------------------------

public
    bool
Equals(
    IEqualityComparer that
)
{
    return Equatable.Equals( this, that );
}


public
    bool
DirectionalEquals(
    IEqualityComparer that
)
{
    if( that == null ) return false;
    if( that.GetUnderlying().GetType() != this.GetType() ) return false;
    Comparer<T> c = (Comparer<T>)that;
    return
        c.CompareFunction == this.CompareFunction &&
        c.EqualsFunction == this.EqualsFunction &&
        c.GetHashCodeFunction == this.GetHashCodeFunction;
}


public override
    int
GetHashCode()
{
    return
        this.GetType().GetHashCode() ^
        this.CompareFunction.GetHashCode() ^
        this.EqualsFunction.GetHashCode() ^
        this.GetHashCodeFunction.GetHashCode();
}



// -----------------------------------------------------------------------------
// System.Object
// -----------------------------------------------------------------------------

public override
    bool
Equals(
    object that
)
{
    return
        that != null &&
        that is IEqualityComparer &&
        this.Equals( (IEqualityComparer)that );
}




} // type
} // namespace

