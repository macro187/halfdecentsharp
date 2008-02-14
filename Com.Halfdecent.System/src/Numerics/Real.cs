// -----------------------------------------------------------------------------
// Copyright (c) 2007 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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


namespace
Com.Halfdecent.Numerics
{




/// A real number
///
/// TODO Wikipedia link to real
///
/// The current implementation uses <tt>System.Decimal</tt> for underlying
/// values and operations, so it's limitations do apply.  But you're meant to
/// carry on as though they don't.
///
public struct
Real
    : IComparable< Real >
    , IEquatable< Real >
{




// -----------------------------------------------------------------------------
#region Constructors and Converters
// -----------------------------------------------------------------------------

/// "Widening" conversion from <tt>System.Decimal</tt>
///
static public
Real
From(
    decimal value
)
{
    return new Real( value );
}



/// "Narrowing" conversion to <tt>System.Decimal</tt>
///
/// (Would throw a ValueException if the Real were out of Decimal's range, but
/// since Decimal is currently used to implement Real, that can't happen)
///
public
decimal /// @returns A <tt>System.Decimal</tt> with the same value as this real
ToDecimal()
{
    return this.value;
}



/// Initialize a new <tt>Real</tt> with a <tt>System.Decimal</tt> value
///
private
Real(
    decimal value
)
{
    this.value = value;
}

#endregion




// -----------------------------------------------------------------------------
#region System.Object
// -----------------------------------------------------------------------------

/// (see <tt>System.Object.Equals()</tt>)
///
public override
bool
Equals(
    object obj
)
{
    bool result = false;
    if( obj is Real ) {
        result = this.Equals( (Real)obj );
    }
    return result;
}



/// (see <tt>System.Object.ToString()</tt>)
///
public override
string
ToString()
{
    return this.value.ToString();
}



/// (see <tt>System.Object.GetHashCode()</tt>)
///
public override
int /// @returns A hash code for this real
GetHashCode()
{
    return this.value.GetHashCode();
}

#endregion




// -----------------------------------------------------------------------------
#region System.IEquatable< Real >
// -----------------------------------------------------------------------------

/// (see <tt>IEquatable< T >.Equals()</tt>)
public
bool
Equals(
    Real x
)
{
    return this.value.Equals( x.value );
}

#endregion




// -----------------------------------------------------------------------------
#region System.IComparable< Real >
// -----------------------------------------------------------------------------

/// (see <tt>IComparable< T >.CompareTo()</tt>)
public
int
CompareTo(
    Real x
)
{
    return this.value.CompareTo( x.value );
}

#endregion




// -----------------------------------------------------------------------------
#region Methods
// -----------------------------------------------------------------------------

/// Compute whether this real is greater than another
///
public
bool        /// @returns Whether this real is greater than the other
GT(
    Real x  ///< The other real
)
{
    return (this.CompareTo( x ) > 0);
}



/// Compute whether this real is greater than or equal to another
///
public
bool        /// @returns Whether this real is greater than or equal to the other
GTE(
    Real x  ///< The other real
)
{
    return (this.CompareTo( x ) >= 0);
}



/// Compute whether this real is less than another
///
public
bool        /// @returns Whether this real is less than or equal to the other
LT(
    Real x  ///< The other real
)
{
    return (this.CompareTo( x ) < 0);
}



/// Compute whether this real is less than or equal to another
///
public
bool        /// @returns Whether this real is less than or equal to the other
LTE(
    Real x  ///< The other real
)
{
    return (this.CompareTo( x ) <= 0);
}



/// Compute this real plus another
///
public
Real        /// @returns This real plus the other
Plus(
    Real x  ///< The other real
)
{
    return Real.From( this.value + x.value );
}



/// Compute this real minus another
///
public
Real        /// @returns This real minus the other
Minus(
    Real x  ///< The other real
)
{
    return Real.From( this.value - x.value );
}



/// Compute this real times another
///
public
Real        /// @returns This real times the other
Times(
    Real x  ///< The other real
)
{
    return Real.From( this.value * x.value );
}



/// Compute this real divided by another
///
public
Real        /// @returns This real divided by the other
DividedBy(
    Real x  ///< The other real
            ///  - Must not be zero
)
{
    new IsNotZero().Demand( x );
    return Real.From( this.value / x.value );
}



/// Compute the remainder when this real is divided by another
///
public
Real        /// @returns The remainder when this real is divided by the other
RemainderWhenDividedBy(
    Real x  ///< The other real
            ///  - Must not be zero
)
{
    new IsNotZero().Demand( x );
    return Real.From( Decimal.Remainder( this.value, x.value ) );
}



/// Generate the value of this real with the fractional part of it's value
/// discarded
///
public
Real
Truncate()
{
    return Real.From( Decimal.Truncate( this.value ) );
}

#endregion




// -----------------------------------------------------------------------------
#region Equality and Comparison Operators
// -----------------------------------------------------------------------------

/// <tt>Real == Real</tt>
///
public static
bool
operator ==(
    Real r1,
    Real r2
)
{
    return r1.Equals( r2 );
}



/// <tt>Real != Real</tt>
///
public static
bool
operator !=(
    Real r1,
    Real r2
)
{
    return !(r1 == r2);
}



/// <tt>Real > Real</tt>
///
public static
bool
operator >(
    Real r1,
    Real r2
)
{
    return r1.GT( r2 );
}



/// <tt>Real >= Real</tt>
///
public static
bool
operator >=(
    Real r1,
    Real r2
)
{
    return r1.GTE( r2 );
}



/// <tt>Real < Real</tt>
///
public static
bool
operator <(
    Real r1,
    Real r2
)
{
    return r1.LT( r2 );
}



/// <tt>Real <= Real</tt>
///
public static
bool
operator <=(
    Real r1,
    Real r2
)
{
    return r1.LTE( r2 );
}

#endregion




// -----------------------------------------------------------------------------
#region Arithmetic Operators
// -----------------------------------------------------------------------------

/// <tt>Real + Real</tt>
///
public static
Real
operator +(
    Real    r1,
    Real    r2
)
{
    return r1.Plus( r2 );
}



/// <tt>Real - Real</tt>
///
public static
Real
operator -(
    Real    r1,
    Real    r2
)
{
    return r1.Minus( r2 );
}



/// <tt>Real * Real</tt>
///
public static
Real
operator *(
    Real    r1,
    Real    r2
)
{
    return r1.Times( r2 );
}



/// <tt>Real / Real</tt>
///
public static
Real
operator /(
    Real    r1,
    Real    r2
)
{
    return r1.DividedBy( r2 );
}



/*
/// <tt>Real % Real</tt>
///
public static
Real
operator %(
    Real    r1,
    Real    r2
)
{
    return r1.RemainderWhenDividedBy( r2 );
}
*/



/// <tt>Real++</tt>
///
public static
Real
operator ++(
    Real r
)
{
    return r.Plus( Real.From( 1 ) );
}



/// <tt>Real--</tt>
///
public static
Real
operator --(
    Real r
)
{
    return r.Minus( Real.From( 1 ) );
}



/// <tt>+Real</tt>
///
public static
Real
operator +(
    Real r
)
{
    return r;
}



/// <tt>-Real</tt>
///
public static
Real
operator -(
    Real r
)
{
    return Real.From( 0 ).Minus( r );
}

#endregion




// -----------------------------------------------------------------------------
#region Private
// -----------------------------------------------------------------------------

private
decimal
value;

#endregion




} // type
} // namespace

