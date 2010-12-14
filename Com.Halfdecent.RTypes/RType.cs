// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010
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


using Com.Halfdecent;
using Com.Halfdecent.Globalisation;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// A condition of values
///
/// @section equality Equality
///
///     Default RType equality is that rtypes of the same underlying runtime
///     type are equal
///
// =============================================================================

public abstract class
RType
    : IEquatable< RType >
{


// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

protected
RType(
    System.Func< Localised< string >, Localised< string > > sayIsFunc,
    System.Func< Localised< string >, Localised< string > > sayIsNotFunc,
    System.Func< Localised< string >, Localised< string > > sayMustBeFunc
)
{
    this.SayIsFunc = sayIsFunc;
    this.SayIsNotFunc = sayIsNotFunc;
    this.SayMustBeFunc = sayMustBeFunc;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

private
System.Func< Localised< string >, Localised< string > >
SayIsFunc;


private
System.Func< Localised< string >, Localised< string > >
SayIsNotFunc;


private
System.Func< Localised< string >, Localised< string > >
SayMustBeFunc;



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Generate natural language stating that an item <em>is</em> of this RType
///
public virtual
    Localised< string >
SayIs(
    Localised< string > reference
    ///< Natural language reference to the item
    ///  - Must not be <tt>null</tt>
)
{
    if( object.ReferenceEquals( this.SayIsFunc, null ) )
        throw new BugException(
            new LocalisedInvalidOperationException(
                _S("SayIs() not overridden and .SayIsFunc is null") ) );
    if( object.ReferenceEquals( reference, null ) )
        throw new LocalisedArgumentNullException( "reference" );

    return this.SayIsFunc( reference );
}


/// Generate natural language stating that an item <em>is not</em> of this RType
///
public virtual
    Localised< string >
SayIsNot(
    Localised< string > reference
    ///< Natural language reference to the item
    ///  - Must not be <tt>null</tt>
)
{
    if( object.ReferenceEquals( this.SayIsNotFunc, null ) )
        throw new BugException(
            new LocalisedInvalidOperationException(
                _S("SayIsNot() not overridden and .SayIsNotFunc is null") ) );
    if( object.ReferenceEquals( reference, null ) )
        throw new LocalisedArgumentNullException( "reference" );

    return this.SayIsNotFunc( reference );
}


/// Generate natural language stating that and item <em>is required to be</em>
/// of this RType
///
public virtual
    Localised< string >
SayMustBe(
    Localised< string > reference
    ///< Natural language reference to the item
    ///  - Must not be <tt>null</tt>
)
{
    if( object.ReferenceEquals( this.SayMustBeFunc, null ) )
        throw new BugException(
            new LocalisedInvalidOperationException(
                _S("SayMustBe() not overridden and .SayMustBeFunc is null") ) );
    if( object.ReferenceEquals( reference, null ) )
        throw new LocalisedArgumentNullException( "reference" );

    return this.SayMustBeFunc( reference );
}



// -----------------------------------------------------------------------------
// IEquatable< RType >
// -----------------------------------------------------------------------------

public
    bool
Equals(
    RType that
)
{
    return Equatable.Equals( this, that );
}


public virtual
    bool
DirectionalEquals(
    RType that
)
{
    if( (object)that == null ) return false;
    return that.GetUnderlying().GetType() == this.GetUnderlying().GetType();
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
    throw new System.NotSupportedException();
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

