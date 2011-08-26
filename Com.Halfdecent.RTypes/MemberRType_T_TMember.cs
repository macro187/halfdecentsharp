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
/// RType: A particular member of values meets a particular RType
///
/// @section equality Equality
///
///     "Anonymous" <tt>MemberRType</tt>s can be created, so object reference
///     equality is the default.
///
// =============================================================================

public abstract class
MemberRType<
    T,
    TMember
>
    : RType< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
MemberRType(
    System.Func< T, TMember >
        getMemberFunc,
    System.Func< ValueReference, ValueReference >
        getMemberReferenceFunc,
    System.Func< Localised< string >, Localised< string > >
        getNaturalReferenceFunc,
    RType< TMember >
        rType
)
    : base(
        null,
        r => rType.SayIs( getNaturalReferenceFunc( r ) ),
        r => rType.SayIsNot( getNaturalReferenceFunc( r ) ),
        r => rType.SayMustBe( getNaturalReferenceFunc( r ) ) )
{
    if( getMemberFunc == null )
        throw new LocalisedArgumentNullException( "getMemberFunc" );
    if( getMemberReferenceFunc == null )
        throw new LocalisedArgumentNullException( "getMemberReferenceFunc" );
    if( getNaturalReferenceFunc == null )
        throw new LocalisedArgumentNullException( "getNaturalReferenceFunc" );
    if( rType == null )
        throw new LocalisedArgumentNullException( "rType" );
    this.GetMemberFunc = getMemberFunc;
    this.GetMemberReferenceFunc = getMemberReferenceFunc;
    this.RType = rType;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

private
System.Func< T, TMember >
GetMemberFunc;


private
System.Func< ValueReference, ValueReference >
GetMemberReferenceFunc;


private
RType< TMember >
RType;



// -----------------------------------------------------------------------------
// RType< T >
// -----------------------------------------------------------------------------

public override
    bool
Is(
    T item
)
{
    if( item == null ) return true;
    return this.RType.Is( this.GetMemberFunc( item ) );
}


public override
    void
Check(
    T item
)
{
    if( item == null ) return;

    try {
        ValueReferenceException.Map(
            f => this.GetMemberReferenceFunc( f.Parameter( "item" ) ),
            f => f.Down().Parameter( "item" ),
            () => this.RType.Check( this.GetMemberFunc( item ) ) );

    } catch( System.Exception e ) {
        RTypeException.Match(
            e,
            (vr,f) =>
                vr.Equals(
                    this.GetMemberReferenceFunc( f.Parameter( "item" ) ) ),
            rt => rt.Equals( this.RType ),
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
            MemberRType< T, TMember > >(
            mrt =>
                mrt.GetMemberFunc == this.GetMemberFunc
                && mrt.RType.Equals( this.RType ) );
}


public override
    int
GetHashCode()
{
    return
        base.GetHashCode()
        ^ this.GetMemberFunc.GetHashCode()
        ^ this.RType.GetHashCode();
}




//private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

