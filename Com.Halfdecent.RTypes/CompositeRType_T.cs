// -----------------------------------------------------------------------------
// Copyright (c) 2010
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


using System.Linq;
using SCG = System.Collections.Generic;
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// RType that is a composition of other RTypes
// =============================================================================

public abstract class
CompositeRType<
    T
>
    : RType< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
CompositeRType(
    SCG.IEnumerable< RType< T > >                           components,
    System.Func< Localised< string >, Localised< string > > sayIsFunc,
    System.Func< Localised< string >, Localised< string > > sayIsNotFunc,
    System.Func< Localised< string >, Localised< string > > sayMustBeFunc
)
    : base( null, sayIsFunc, sayIsNotFunc, sayMustBeFunc )
{
    this.Components = components;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

private
SCG.IEnumerable< RType< T > >
Components;



// -----------------------------------------------------------------------------
// RType< T >
// -----------------------------------------------------------------------------

public override
    bool
Is(
    T item
)
{
    return this.Components.All( c => c.Is( item ) );
}


public override
    void
Check(
    T item
)
{
    try {
        foreach( RType< T > c in this.Components )
            ValueReferenceException.Map(
                f => f.Parameter( "item" ),
                f => f.Down().Parameter( "item" ),
                () => c.Check( item ) );

    } catch( System.Exception e ) {
        RTypeException.Match(
            e,
            (vr,f) => vr.Equals( f.Parameter( "item" ) ),
            rt => this.Components.Where( c => c.Equals( rt ) ).Any(),
            (vr,f,rte) => {
                throw new ValueReferenceException(
                    f.Parameter( "item" ),
                    new RTypeException( this, e ) ); } );
        throw e;
    }
}



// -----------------------------------------------------------------------------
// IEquatable< RType >
// -----------------------------------------------------------------------------

public override
    bool
DirectionalEquals(
    RType that
)
{
    return
        base.DirectionalEquals( that )
        && that.Is<
            CompositeRType< T > >(
            crt =>
                crt.Components
#if !DOTNET40
                .Cast< RType >()
#endif
                .SequenceEqual<
                    RType >(
                    this.Components
#if !DOTNET40
                    .Cast< RType >()
#endif
                    ,
                    new EquatableComparer< RType >() ) );
}


public override
    int
GetHashCode()
{
    return
        this.Components.Aggregate(
            base.GetHashCode(),
            (a,c) => a ^ c.GetHashCode() );
}





//private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

