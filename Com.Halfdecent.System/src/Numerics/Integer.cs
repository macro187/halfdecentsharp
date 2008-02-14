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




/// An integer
///
/// TODO Wikipedia link to integer
///
public struct
Integer
    : IInteger
    , IComparable< Integer >
    , IEquatable< Integer >
{




// -----------------------------------------------------------------------------
#region Constructors and Converters
// -----------------------------------------------------------------------------

/// Copy from <tt>IInteger</tt>
///
static public
Integer
From(
    IInteger value  ///< The <tt>IInteger</tt> to copy
)
{
    return new Integer( Real.From( value ) );
}



/// "Narrowing" conversion from <tt>Real</tt>
///
/// @exception ValueException
/// If the given <tt>System.Decimal</tt> is a fractional value
///
static public
Integer
From(
    IReal value ///< The <tt>Real</tt> to convert to an Integer
)
{
    return new Integer( Real.From( value ) );
}



/// "Widening" conversion to <tt>Real</tt>
///
public
Real    /// @returns A <tt>Real</tt> with the same value as this integer
ToReal()
{
    return this.value;
}



/// Conversion from <tt>System.Decimal</tt>
///
/// @exception ValueException
/// If the given <tt>System.Decimal</tt> is a fractional value
///
static public
Integer
From(
    decimal value
)
{
    return Integer.From( Real.From( value ) );
}



/// Conversion to <tt>System.Decimal</tt>
///
/// (Would throw a ValueException if this Integer were out of Decimal's range,
/// but since Integer is currently implemented on Real, which is implemented
/// on Decimal, that can't happen)
///
public
decimal /// @returns A <tt>System.Decimal</tt> with the same value as this
        /// integer
ToDecimal()
{
    return this.value.ToDecimal();
}



/// Initialize a new <tt>Integer</tt> from a <tt>Real</tt> value
///
/// @exception ValueException
/// If the given <tt>System.Decimal</tt> is a fractional value
///
private
Integer(
    Real value  ///< The value of the new Integer
                ///
                ///  Requirements:
                ///  - <tt>IsNotFractional< T ></tt>
)
{
    new IsNotFractional< Real >().Require( value );
    this.value = value;
}

#endregion




// -----------------------------------------------------------------------------
#region Methods
// -----------------------------------------------------------------------------

/// Compute whether this integer is greater than another
///
public
bool            /// @returns Whether this integer is greater than the other
GT(
    Integer x   ///< The other integer
)
{
    return this.value.GT( x );
}



/// Compute whether this integer is greater than or equal to another
///
public
bool            /// @returns Whether this integer is greater than or equal to the
                /// other
GTE(
    Integer x   ///< The other integer
)
{
    return this.value.GTE( x );
}



/// Compute whether this integer is less than another
///
public
bool            /// @returns Whether this integer is less than or equal to the
                /// other
LT(
    Integer x   ///< The other integer
)
{
    return this.value.LT( x );
}



/// Compute whether this integer is less than or equal to another
///
public
bool            /// @returns Whether this integer is less than or equal to the
                /// other
LTE(
    Integer x   ///< The other integer
)
{
    return this.value.LTE( x );
}



/// Compute this integer plus another
///
public
Integer         /// @returns This integer plus the other
Plus(
    Integer x   ///< The other integer
)
{
    return Integer.From( this.value.Plus( x ) );    // Assume Integer + Integer
                                                    // always = Integer
}



/// Compute this integer minus another
///
public
Integer         /// @returns This integer minus the other
Minus(
    Integer x   ///< The other integer
)
{
    return Integer.From( this.value.Minus( x ) );   // Assume Integer - Integer
                                                    // always = Integer
}



/// Compute this integer times another
///
public
Integer         /// @returns This integer times the other
Times(
    Integer x   ///< The other integer
)
{
    return Integer.From( this.value.Times( x ) );   // Assume Integer * Integer
                                                    // always = Integer
}



/// Compute this integer divided by another
///
public
Real            /// @returns This integer divided by the other
DividedBy(
    Integer x   ///< The other integer
)
{
    return this.value.DividedBy( x );   // Assume Integer * Integer
                                        // always = Integer
}



/// Compute the remainder when this integer is divided by another
///
public
Integer         /// @returns The remainder when this integer is divided by the
                /// other
RemainderWhenDividedBy(
    Integer x   ///< The other integer
)
{
    // Assume remainder of Integer / Integer is always Integer
    return Integer.From( this.value.RemainderWhenDividedBy( x ) );
}



/// (see <tt>Real.Truncate()</tt>)
///
public
Integer
Truncate()
{
    return this;
}



// TODO Integer Div (?)

#endregion




// -----------------------------------------------------------------------------
#region System.IEquatable< Integer >
// -----------------------------------------------------------------------------

/// (see <tt>IEquatable< T >.Equals()</tt>)
public
bool
Equals(
    Integer x
)
{
    return this.value.Equals( x );
}

#endregion




// -----------------------------------------------------------------------------
#region System.IComparable< Integer >
// -----------------------------------------------------------------------------

/// (see <tt>IComparable< T >.CompareTo()</tt>)
public
int
CompareTo(
    Integer x
)
{
    return this.value.CompareTo( x );
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
    if( obj is Integer ) {
        result = this.Equals( (Integer)obj );
    } else if( obj is Real ) {
        result = this.ToReal().Equals( (Real)obj );
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
int
GetHashCode()
{
    return this.value.GetHashCode();
}

#endregion




// -----------------------------------------------------------------------------
#region Equality and Comparison Operators
// -----------------------------------------------------------------------------

/// <tt>Integer == Integer</tt>
///
public static
bool
operator ==(
    Integer i1,
    Integer i2
)
{
    return i1.Equals( i2 );
}



/// <tt>Integer != Integer</tt>
///
public static
bool
operator !=(
    Integer i1,
    Integer i2
)
{
    return !(i1 == i2);
}



/// <tt>Integer > Integer</tt>
///
public static
bool
operator >(
    Integer i1,
    Integer i2
)
{
    return i1.GT( i2 );
}



/// <tt>Integer >= Integer</tt>
///
public static
bool
operator >=(
    Integer i1,
    Integer i2
)
{
    return i1.GTE( i2 );
}



/// <tt>Integer < Integer</tt>
///
public static
bool
operator <(
    Integer i1,
    Integer i2
)
{
    return i1.LT( i2 );
}



/// <tt>Integer <= Integer</tt>
///
public static
bool
operator <=(
    Integer i1,
    Integer i2
)
{
    return i1.LTE( i2 );
}

#endregion




// -----------------------------------------------------------------------------
#region Arithmetic Operators
// -----------------------------------------------------------------------------

/// <tt>Integer + Integer</tt>
///
public static
Integer
operator +(
    Integer i1,
    Integer i2
)
{
    return i1.Plus( i2 );
}



/// <tt>Integer - Integer</tt>
///
public static
Integer
operator -(
    Integer i1,
    Integer i2
)
{
    return i1.Minus( i2 );
}



/// <tt>Integer * Integer</tt>
///
public static
Integer
operator *(
    Integer i1,
    Integer i2
)
{
    return i1.Times( i2 );
}



/// <tt>Integer / Integer</tt>
///
public static
Real
operator /(
    Integer i1,
    Integer i2
)
{
    return i1.DividedBy( i2 );
}



/// <tt>Integer % Integer</tt>
///
public static
Integer
operator %(
    Integer i1,
    Integer i2
)
{
    return i1.RemainderWhenDividedBy( i2 );
}



/// <tt>Integer++</tt>
///
public static
Integer
operator ++(
    Integer i
)
{
    return i.Plus( Integer.From( 1 ) );
}



/// <tt>Integer--</tt>
///
public static
Integer
operator --(
    Integer i
)
{
    return i.Minus( Integer.From( 1 ) );
}



/// <tt>+Integer</tt>
///
public static
Integer
operator +(
    Integer i
)
{
    return i;
}



/// <tt>-Integer</tt>
///
public static
Integer
operator -(
    Integer i
)
{
    return Integer.From( 0 ).Minus( i );
}

#endregion




// -----------------------------------------------------------------------------
#region Conversion Operators
// -----------------------------------------------------------------------------

/// Explicit narrowing from Real
///
/// @exception ValueException
/// If the given <tt>Real</tt> is a fractional value
///
public static
explicit operator Integer(
    Real r
)
{
    return Integer.From( r );
}



/// Implicit widening to Real
///
public static
implicit operator Real(
    Integer i
)
{
    return i.ToReal();
}



/*
/// Explicit from System.Decimal
///
/// @exception ValueException
/// If the given <tt>System.Decimal</tt> is a fractional value
///
public static
explicit operator Integer(
    decimal d
)
{
    return Integer.From( d );
}



/// Explicit to System.Decimal
///
public static
explicit operator decimal(
    Integer i
)
{
    return i.ToDecimal();
}
*/

#endregion




// -----------------------------------------------------------------------------
#region Private
// -----------------------------------------------------------------------------

private
Real
value;

#endregion




// -----------------------------------------------------------------------------
#region IInteger
// -----------------------------------------------------------------------------



#endregion




// -----------------------------------------------------------------------------
#region IReal
// -----------------------------------------------------------------------------

bool    IReal.GT( IReal x ) { return this.value.GT( x ); }
bool    IReal.GTE( IReal x ) { return this.value.GTE( x ); }
bool    IReal.LT( IReal x ) { return this.value.LT( x ); }
bool    IReal.LTE( IReal x ) { return this.value.LTE( x ); }
IReal   IReal.Plus( IReal x  ) { return this.value.Plus( x ); }
IReal   IReal.Minus( IReal x ) { return this.value.Minus( x ); }
IReal   IReal.Times( IReal x ) { return this.value.Times( x ); }
IReal   IReal.DividedBy( IReal x ) { return this.value.DividedBy( x ); }
IReal   IReal.Truncate() { return this.value.Truncate(); }

#endregion




// -----------------------------------------------------------------------------
#region System.IComparable< IReal >
// -----------------------------------------------------------------------------

/// (see <tt>IComparable< T >.CompareTo()</tt>)
public
int
CompareTo(
    IReal x
)
{
    return this.value.CompareTo( x );
}

#endregion




// -----------------------------------------------------------------------------
#region System.IEquatable< IReal >
// -----------------------------------------------------------------------------

/// (see <tt>IEquatable< T >.Equals()</tt>)
public
bool
Equals(
    IReal x
)
{
    return this.value.Equals( x );
}

#endregion




// -----------------------------------------------------------------------------
#region IInteger
// -----------------------------------------------------------------------------

public bool     GT( IInteger x ) { return this.GT( Integer.From( x ) ); }
public bool     GTE( IInteger x ) { return this.GTE( Integer.From( x ) ); }
public bool     LT( IInteger x ) { return this.LT( Integer.From( x ) ); }
public bool     LTE( IInteger x ) { return this.LTE( Integer.From( x ) ); }
public IInteger Plus( IInteger x  ) { return this.Plus( Integer.From( x ) ); }
public IInteger Minus( IInteger x ) { return this.Minus( Integer.From( x ) ); }
public IInteger Times( IInteger x ) { return this.Times( Integer.From( x ) ); }
public IReal    DividedBy( IInteger x ) {
                    return this.DividedBy( Integer.From( x ) ); }
public IInteger RemainderWhenDividedBy( IInteger x ) {
                    return this.RemainderWhenDividedBy( Integer.From( x ) ); }

#endregion




// -----------------------------------------------------------------------------
#region System.IComparable< IInteger >
// -----------------------------------------------------------------------------

/// (see <tt>IComparable< T >.CompareTo()</tt>)
public
int
CompareTo(
    IInteger x
)
{
    return this.CompareTo( Integer.From( x ) );
}

#endregion




// -----------------------------------------------------------------------------
#region System.IEquatable< IInteger >
// -----------------------------------------------------------------------------

/// (see <tt>IEquatable< T >.Equals()</tt>)
public
bool
Equals(
    IInteger x
)
{
    return this.Equals( Integer.From( x ) );
}

#endregion







} // type
} // namespace

