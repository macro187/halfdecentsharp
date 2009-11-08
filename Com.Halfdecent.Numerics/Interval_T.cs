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


using System;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Numerics
{


// =============================================================================
/// <tt>IInterval</tt> implementation
// =============================================================================

public class
Interval<
    T
>
    : IInterval< T >
    where T : IComparable
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Create an interval between one value to another, inclusive
///
public
Interval(
    T from,
    T to
)
    : this( from, true, to, true )
{
}


/// Create an interval between one value to another, specifying whether each
/// is inclusive
///
public
Interval(
    T       from,
    bool    fromInclusive,
    T       to,
    bool    toInclusive
)
{
    new NonNull().Check( from, new Parameter( "from" ) );
    new NonNull().Check( to, new Parameter( "to" ) );
    this.From = from;
    this.FromInclusive = fromInclusive;
    this.To = to;
    this.ToInclusive = toInclusive;
}



// -----------------------------------------------------------------------------
// IInterval< T >
// -----------------------------------------------------------------------------

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
// IInterval< T >
// -----------------------------------------------------------------------------

IComparable
IInterval.From
{
    get { return this.From; }
}

IComparable
IInterval.To
{
    get { return this.To; }
}



// -----------------------------------------------------------------------------
// System.Object
// -----------------------------------------------------------------------------

public override
string
ToString()
{
    return Interval.ToString( this );
}


public override
bool
Equals(
    object obj
)
{
    if( obj == null ) return false;
    if( !( obj is IInterval ) ) return false;
    return Interval.Equals( this, (IInterval)obj );
}


public override
int
GetHashCode()
{
    return Interval.GetHashCode( this );
}




} // type
} // namespace

