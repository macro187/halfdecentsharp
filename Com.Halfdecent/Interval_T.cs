// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009
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
/// <tt>IInterval</tt> implementation
// =============================================================================

// TODO: Could this be a struct?
public sealed class
Interval<
    T
>
    : IInterval< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Create an interval between one value and another, both inclusive
///
public
Interval(
    T               from,
    T               to,
    IComparer< T >  comparer
)
    : this( from, true, to, true, comparer )
{
}


/// Create an interval between one value and another, specifying whether each
/// is inclusive
///
public
Interval(
    T               from,
    bool            fromInclusive,
    T               to,
    bool            toInclusive,
    IComparer< T >  comparer
)
{
    if( object.ReferenceEquals( from, null ) )
        throw new System.ArgumentNullException( "from" );
    if( object.ReferenceEquals( to, null ) )
        throw new System.ArgumentNullException( "to" );
    if( object.ReferenceEquals( comparer, null ) )
        throw new System.ArgumentNullException( "comparer" );
    this.From = from;
    this.FromInclusive = fromInclusive;
    this.To = to;
    this.ToInclusive = toInclusive;
    this.Comparer = comparer;
}



// -----------------------------------------------------------------------------
// IInterval< T >
// -----------------------------------------------------------------------------

public
IComparer< T >
Comparer
{
    get;
    private set;
}


public
T
From
{
    get;
    private set;
}


public
bool
FromInclusive
{
    get;
    private set;
}


public
T
To
{
    get;
    private set;
}


public
bool
ToInclusive
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// IEquatable< IInterval< T > >
// -----------------------------------------------------------------------------

public
    bool
Equals(
    IInterval< T > that
)
{
    return Equatable.Equals( this, that );
}


public
    bool
DirectionalEquals(
    IInterval< T > that
)
{
    return Interval.DirectionalEquals( this, that );
}


    int
IEquatable< IInterval< T > >.GetHashCode()
{
    return Interval.GetHashCode( this  );
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
        that is IInterval< T > &&
        this.Equals( (IInterval< T >)that );
}


public override
    int
GetHashCode()
{
    return ((IEquatable< IInterval< T > >)this).GetHashCode();
}


public override
    string
ToString()
{
    return Interval.ToString( this );
}




} // type
} // namespace

