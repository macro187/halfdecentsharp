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
using System.Linq;
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Exceptions;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// IRType< T > contravariant type adapter
// =============================================================================

public class
RTypeAdapter<
    TFrom,
    TTo
>
    : IRType< TTo >
    where TTo : TFrom
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
RTypeAdapter(
    IRType< TFrom > from
)
{
    if( from == null )
        throw new ValueArgumentNullException( new Parameter( "from" ) );
    this.From = from;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
    IRType< TFrom >
From
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// IRType< T >
// -----------------------------------------------------------------------------

public
    SCG.IEnumerable< IRType< TTo > >
GetComponents()
{
    return this.From.GetComponents()
        .Select( c => c.Contravary< TFrom, TTo >() );
}


public
    RTypeException
CheckMembers(
    TTo     item,
    Value   itemReference
)
{
    return this.From.CheckMembers( item, itemReference );
}


public
    bool
Predicate(
    TTo item
)
{
    return this.From.Predicate( item );
}



// -----------------------------------------------------------------------------
// IRType
// -----------------------------------------------------------------------------

public virtual
IRType
GetUnderlying()
{
    return this.From.GetUnderlying();
}


public
    Localised< string >
SayIs(
    Localised< string > reference
)
{
    return this.From.SayIs( reference );
}


public
    Localised< string >
SayIsNot(
    Localised< string > reference
)
{
    return this.From.SayIsNot( reference );
}


public
    Localised< string >
SayMustBe(
    Localised< string > reference
)
{
    return this.From.SayMustBe( reference );
}



// -----------------------------------------------------------------------------
// IEquatable< RType >
// -----------------------------------------------------------------------------

public
    bool
Equals(
    IRType that
)
{
    return this.From.Equals( that );
}


public
    bool
DirectionalEquals(
    IRType that
)
{
    return this.From.DirectionalEquals( that );
}


public override
    int
GetHashCode()
{
    return this.From.GetHashCode();
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
        that is IRType &&
        this.Equals( (IRType)that );
}




} // type
} // namespace

