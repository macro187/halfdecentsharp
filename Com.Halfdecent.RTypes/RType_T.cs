// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2012
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
using System.Linq;
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// A condition of values of a particular type, expressed as a predicate
// =============================================================================


public abstract class
RType<
    T
>
    : RType
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

protected
RType(
    Predicate< T >                                      isFunc,
    Func< Localised< string >, Localised< string > >    sayIsFunc,
    Func< Localised< string >, Localised< string > >    sayIsNotFunc,
    Func< Localised< string >, Localised< string > >    sayMustBeFunc
)
    : base( sayIsFunc, sayIsNotFunc, sayMustBeFunc )
{
    this.IsFunc = isFunc;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

private
Predicate< T >
IsFunc;



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Determine whether an item meets this RType
///
public virtual
    bool
Is(
    T item
)
{
    if( this.IsFunc != null ) return this.IsFunc( item );
    return true;
}


/// Require that an item meet this RType
///
/// @exception RTypeException
/// <tt>item</tt> does not meet to this RType
///
public virtual
    void
Check(
    T item
)
{
    if( !this.Is( item ) )
        throw new ValueReferenceException(
            new Frame().Parameter( "item" ),
            new RTypeException( this ) );
}


public
    RType< TTo >
Contravary<
    TTo
>()
    where TTo : T
{
    return new RTypeProxy< T, TTo >( this );
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Globalisation.LocalisedResource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

