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
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// Base class for implementing RTypes
///
/// @section implementing Implementing
///
///     This base class offers three mechanisms for implementing RType logic,
///     any number of which can be used simultaneously.  In decreasing order of
///     preference, they are:
///
///     -#  <tt>GetComponents()</tt>, other RTypes to apply to the item
///
///     -#  <tt>CheckMembers()</tt>, a method in which other RTypes can be
///         applied to parts of the item
///
///     -#  <tt>Predicate()</tt>, a method which can contain arbitrary logic
///
///     The earlier-listed mechanisms are more preferable for at least two
///     reasons.  First, they are composed of existing -- and therefore
///     presumably tested and correct -- RTypes, and so bring less chance of
///     introducing bugs.  Secondly, they provide more details (in the form of
///     inner exceptions) when items fail.
///
///     In short, try to compose new RTypes from existing ones using the first
///     two mechanisms.  Only resort to a hand-written <tt>Predicate()</tt>
///     when the required logic doesn't exist anywhere else.
// =============================================================================

public abstract class
RTypeBase<
    T
>
    : IRType< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
RTypeBase()
{
}



// -----------------------------------------------------------------------------
// IRType< T >
// -----------------------------------------------------------------------------

public virtual
    SCG.IEnumerable< IRType< T > >
GetComponents()
{
    yield break;
}


public virtual
    RTypeException
CheckMembers(
    T       item,
    Value   itemReference
)
{
    return null;
}


public virtual
    bool
Predicate(
    T item
)
{
    return true;
}



// -----------------------------------------------------------------------------
// IRType
// -----------------------------------------------------------------------------

public virtual
    IRType
GetUnderlying()
{
    return this;
}


public abstract
    Localised< string >
SayIs(
    Localised< string > reference
);


public abstract
    Localised< string >
SayIsNot(
    Localised< string > reference
);


public abstract
    Localised< string >
SayMustBe(
    Localised< string > reference
);



// -----------------------------------------------------------------------------
// IEquatable< RType >
// -----------------------------------------------------------------------------

public
    bool
Equals(
    IRType that
)
{
    return Equatable.Equals( this, that );
}


public virtual
    bool
DirectionalEquals(
    IRType that
)
{
    if( that == null ) return false;
    return
        this.GetUnderlying().GetType() ==
        that.GetUnderlying().GetType();
}


public override
    int
GetHashCode()
{
    return this.GetUnderlying().GetType().GetHashCode();
}



// -----------------------------------------------------------------------------
// System.Object
// -----------------------------------------------------------------------------

public override sealed
    bool
Equals(
    object that
)
{
    return
        that != null &&
        that is IRType &&
        this.Equals( (IRType)that );
}




} // type
} // namespace

