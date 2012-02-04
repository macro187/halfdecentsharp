// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010, 2011, 2012
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
using System.Collections.Generic;


namespace
Com.Halfdecent
{


// =============================================================================
/// <tt>IInterval</tt> implementation
// =============================================================================

public sealed class
Interval<
    T
>
    : IInterval< T >
{


// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
Interval(
    T                   from,
    bool                fromInclusive,
    T                   to,
    bool                toInclusive,
    IComparerHD< T >    comparer
)
{
    if( from == null )
        throw new ArgumentNullException( "from" );
    if( to == null )
        throw new ArgumentNullException( "to" );
    if( comparer == null )
        throw new ArgumentNullException( "comparer" );
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
IComparerHD< T >
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
// IEquatableHD< IInterval< T > >
// -----------------------------------------------------------------------------

public
    bool
Equals(
    IInterval< T > that
)
{
    return Interval.Equals( this, that );
}


public override
    int
GetHashCode()
{
    return Interval.GetHashCode( this );
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
        that.Is< IInterval< T > >()
        && this.Equals( (IInterval< T >)that );
}


public override
    string
ToString()
{
    return Interval.ToString( this );
}




} // type
} // namespace

