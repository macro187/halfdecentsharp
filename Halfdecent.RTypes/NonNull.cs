// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2010, 2012
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


using Halfdecent;
using Halfdecent.Globalisation;
using Halfdecent.Meta;


namespace
Halfdecent.RTypes
{


// =============================================================================
/// RType: Not <tt>null</tt>
// =============================================================================

public sealed class
NonNull
    : CompositeRType< object >
{



// -----------------------------------------------------------------------------
// Static
// -----------------------------------------------------------------------------

public static
    void
CheckParameter(
    object item,
    string paramName
)
{
    if( paramName == null )
        throw new LocalisedArgumentNullException( "paramName" );
    if( paramName == "" )
        throw new LocalisedArgumentException( "blank", "paramname" );
    ValueReferenceException.Map(
        f => f.Up().Parameter( paramName ),
        f => f.Parameter( "item" ),
        () => ValueReferenceException.Map(
            f => f.Parameter( "item" ),
            f => f.Down().Parameter( "item" ),
            () => Check( item ) ) );
}


public static new
    void
Check(
    object item
)
{
    ValueReferenceException.Map(
        f => f.Parameter( "item" ),
        f => f.Down().Parameter( "item" ),
        () => Create().Check( item ) );
}


public static
    RType< object >
Create()
{
    return instance;
}


private static
    NonNull
instance = new NonNull();



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
NonNull()
    : base(
        SystemEnumerable.Create(
            NEQ.Create(
                null,
                EqualityComparerHD.Create< object >(
                    (x,y) => object.ReferenceEquals( x, y ),
                    x => x.GetHashCode() ) ) ),
        ls => _S("{0} is non-null", ls),
        ls => _S("{0} is null", ls),
        ls => _S("{0} must not be null", ls) )
{
}




private static Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Halfdecent.Globalisation.LocalisedResource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

