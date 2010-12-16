// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010
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


using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// A value failed an rtype check
// =============================================================================

public class
RTypeException
    : ValueException
{



// -----------------------------------------------------------------------------
// Static
// -----------------------------------------------------------------------------

public static
    void
Match(
    System.Exception
        ex,
    System.Func< ValueReference, Frame, bool >
        valueReferencePredicate,
    System.Predicate< RType >
        rTypePredicate,
    System.Action< ValueReference, Frame, RTypeException >
        action
)
{
    if( ex == null )
        throw new LocalisedArgumentNullException( "ex" );
    if( valueReferencePredicate == null )
        throw new LocalisedArgumentNullException( "valueReferencePredicate" );
    if( rTypePredicate == null )
        throw new LocalisedArgumentNullException( "rTypePredicate" );
    if( action == null )
        throw new LocalisedArgumentNullException( "action" );

    ValueReferenceException.Match<
        RTypeException >(
        ex,
        (vr,f) => valueReferencePredicate( vr, f.Up() ),
        rte => rTypePredicate( rte.RType ),
        (vr,f,rte) => action( vr, f.Up(), rte ) );
}


public static
    bool
Match(
    System.Exception
        ex,
    System.Func< ValueReference, Frame, bool >
        valueReferencePredicate,
    System.Predicate< RType >
        rTypePredicate
)
{
    if( ex == null )
        throw new LocalisedArgumentNullException( "ex" );
    if( valueReferencePredicate == null )
        throw new LocalisedArgumentNullException( "valueReferencePredicate" );
    if( rTypePredicate == null )
        throw new LocalisedArgumentNullException( "rTypePredicate" );

    bool result = false;
    RTypeException.Match(
        ex,
        (vr,f) => valueReferencePredicate( vr, f.Up() ),
        rTypePredicate,
        (vr,f,rte) => result = true );
    return result;
}


public static
    void
Match<
    TRType
>(
    System.Exception
        ex,
    System.Func< ValueReference, Frame, bool >
        valueReferencePredicate,
    System.Action< ValueReference, Frame, TRType, RTypeException >
        action
)
    where TRType : RType
{
    if( ex == null )
        throw new LocalisedArgumentNullException( "ex" );
    if( valueReferencePredicate == null )
        throw new LocalisedArgumentNullException( "valueReferencePredicate" );
    if( action == null )
        throw new LocalisedArgumentNullException( "action" );

    ValueReferenceException.Match<
        RTypeException >(
        ex,
        (vr,f) => valueReferencePredicate( vr, f.Up() ),
        rte => rte.RType is TRType,
        (vr,f,rte) => action( vr, f.Up(), (TRType)(rte.RType), rte ) );
}


public static
    bool
Match<
    TRType
>(
    System.Exception ex
)
    where TRType : RType
{
    if( ex == null )
        throw new LocalisedArgumentNullException( "ex" );

    return ValueReferenceException.Match<
        RTypeException >(
        ex,
        (vr,f) => true );
}


public static
    bool
Match<
    TRType
>(
    System.Exception
        ex,
    System.Func< ValueReference, Frame, bool >
        valueReferencePredicate
)
    where TRType : RType
{
    if( ex == null )
        throw new LocalisedArgumentNullException( "ex" );
    if( valueReferencePredicate == null )
        throw new LocalisedArgumentNullException( "valueReferencePredicate" );

    return ValueReferenceException.Match<
        RTypeException >(
        ex,
        (vr,f) => valueReferencePredicate( vr, f.Up() ),
        rte => rte.RType is TRType );
}



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialise a new rtype exception with a reference to the rtype that was not
/// met
///
public
RTypeException(
    RType rtype
)
    : this( rtype, null )
{
}


/// Initialise a new rtype exception with references to the rtype that was not
/// met and the underlying exception
///
public
RTypeException(
    RType               rtype,
    System.Exception    innerException
)
    : base( null, innerException )
{
    if( rtype == null )
        throw new LocalisedArgumentNullException( "rtype" );
    this.RType = rtype;
    this.Data.Add( "Com.Halfdecent.RTypes.RTypeException.RType", rtype );
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// The rtype that was not met
///
public
RType
RType
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// IValueException
// -----------------------------------------------------------------------------

public override
    Localised< string >
SayMessage(
    Localised< string > reference
)
{
    if( reference == null )
        throw new LocalisedArgumentNullException( "reference" );
    return this.RType.SayIsNot( reference );
}




} // type
} // namespace

