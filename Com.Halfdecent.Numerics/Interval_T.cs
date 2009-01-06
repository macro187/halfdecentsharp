// -----------------------------------------------------------------------------
// Copyright (c) 2008 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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
//
public class
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
    T from,
    T to
)
    : this( from, true, to, true )
{
}



public
Interval(
    T       from,
    bool    fromInclusive,
    T       to,
    bool    toInclusive
)
{
    NonNull.SCheck( from, new Parameter( "from" ) );
    NonNull.SCheck( to, new Parameter( "to" ) );
    this.from = from;
    this.frominclusive = fromInclusive;
    this.to = to;
    this.toinclusive = toInclusive;
}




// -----------------------------------------------------------------------------
// IInterval< T >
// -----------------------------------------------------------------------------

public
T
From
{
    get { return this.from; }
}

private
T
from;



public
bool
FromInclusive
{
    get { return this.frominclusive; }
}

private
bool
frominclusive;



public
T
To
{
    get { return this.to; }
}

private
T
to;



public
bool
ToInclusive
{
    get { return this.toinclusive; }
}

private
bool
toinclusive;



// XXX This logic is duplicated in InInterval< T >, not sure if there's any
//     way around that
public
bool
Contains(
    IComparable< T > value
)
{
    new NonNull< IComparable< T > >().Check( value, new Parameter( "value" ) );
    return
        ( this.FromInclusive
            ? value.CompareTo( this.From ) >= 0
            : value.CompareTo( this.From ) > 0
        )
        && ( this.ToInclusive
            ? value.CompareTo( this.To ) <= 0
            : value.CompareTo( this.To ) < 0
        );
}




// -----------------------------------------------------------------------------
// System.Object
// -----------------------------------------------------------------------------

public override
string
ToString()
{
    return string.Format(
        "{0} {1} x {2} {3}",
        this.From,
        this.FromInclusive ? "<=" : "<",
        this.ToInclusive ? "<=" : "<",
        this.To );
}




} // type
} // namespace

