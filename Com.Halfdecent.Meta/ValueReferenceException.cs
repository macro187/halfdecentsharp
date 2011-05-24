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


using System.Linq;
using SCG = System.Collections.Generic;
using Com.Halfdecent.Globalisation;


namespace
Com.Halfdecent.Meta
{


// =============================================================================
/// A reference to the exact problematic value involved in the underlying
/// exception
// =============================================================================

public class
ValueReferenceException
    : LocalisedException
    , IValueException
{



// -----------------------------------------------------------------------------
// Static
// -----------------------------------------------------------------------------

public static
    void
Map(
    System.Func< Frame, ValueReference >    fromFunc,
    System.Func< Frame, ValueReference >    toFunc,
    System.Action                           action
)
{
    if( object.ReferenceEquals( fromFunc, null ) )
        throw new LocalisedArgumentNullException( "fromFunc" );
    if( object.ReferenceEquals( toFunc, null ) )
        throw new LocalisedArgumentNullException( "toFunc" );
    if( object.ReferenceEquals( action, null ) )
        throw new LocalisedArgumentNullException( "action" );

    Map< object >(
        // Make up for this method's frame
        f => fromFunc( f.Up() ),
        // Make up for the below anonymous method's frame
        f => toFunc( f.Down() ),
        () => { action(); return null; } );
}


public static
    T
Map<
    T
>(
    System.Func< Frame, ValueReference >    fromFunc,
    System.Func< Frame, ValueReference >    toFunc,
    System.Func< T >                        func
)
{
    if( object.ReferenceEquals( fromFunc, null ) )
        throw new LocalisedArgumentNullException( "fromFunc" );
    if( object.ReferenceEquals( toFunc, null ) )
        throw new LocalisedArgumentNullException( "toFunc" );
    if( object.ReferenceEquals( func, null ) )
        throw new LocalisedArgumentNullException( "func" );

    return Map< T >(
        SystemEnumerable.Create(
            Tuple.Create<
                System.Func< Frame, ValueReference >,
                System.Func< Frame, ValueReference > >(
                // Make up for this method's frame
                f => fromFunc( f.Up() ),
                toFunc ) ),
        func );
}


// TODO Map() overloads that take more than one mapping

// TODO MapParameter() that just takes parameter names


/// Perform an action, mapping problematic value references in exceptions
/// if they occur
///
public static
    T
Map<
    T
>(
    SCG.IEnumerable<
        ITuple<
            System.Func< Frame, ValueReference >,
            System.Func< Frame, ValueReference > > >    mappings,
    System.Func< T >                                    func
)
{
    if( object.ReferenceEquals( mappings, null ) )
        throw new LocalisedArgumentNullException( "mappings" );
    if( object.ReferenceEquals( func, null ) )
        throw new LocalisedArgumentNullException( "func" );

    try {
        return func();

    } catch( System.Exception e ) {
        ValueReferenceException vre = e.ExceptionChain()
            .OfType< ValueReferenceException >().FirstOrDefault();
        if( vre == null ) throw e;

        Frame f = new Frame();
        var i = -1;
        foreach( var mapping in mappings ) {
            i++;

            if( object.ReferenceEquals( mapping.A, null ) )
                throw new LocalisedArgumentException(
                    _S("mappings[{0}].A is null", i ),
                    "mappings" );
            if( object.ReferenceEquals( mapping.B, null ) )
                throw new LocalisedArgumentException(
                    _S("mappings[{0}].B is null", i ),
                    "mappings" );

            ValueReference to = mapping.B( f.Down() );
            if( !vre.ValueReference.StartsWith( to ) ) continue;

            ValueReference from = mapping.A( f.Up() );
            throw new ValueReferenceException(
                new ValueReference(
                    from.Concat( vre.ValueReference.Skip( to.Count ) ) ),
                vre );
        }

        throw e;
    }
}


public static
    void
Match<
    TException
>(
    System.Exception                                    e,
    System.Func< ValueReference, Frame, bool >          referencePredicate,
    System.Predicate< TException >                      exceptionPredicate,
    System.Action< ValueReference, Frame, TException >  action
)
    where TException : System.Exception
{
    if( object.ReferenceEquals( e, null ) )
        throw new LocalisedArgumentNullException( "e" );
    if( object.ReferenceEquals( referencePredicate, null ) )
        throw new LocalisedArgumentNullException( "referencePredicate" );
    if( object.ReferenceEquals( exceptionPredicate, null ) )
        throw new LocalisedArgumentNullException( "exceptionPredicate" );
    if( object.ReferenceEquals( action, null ) )
        throw new LocalisedArgumentNullException( "action" );

    ValueReferenceException vre = e as ValueReferenceException;
    if( vre == null ) return;
    Frame f = new Frame().Up();
    if( !referencePredicate( vre.ValueReference, f ) ) return;
    TException ex =
        e.ExceptionChain()
        .Where( exx => !(exx is ValueReferenceException) )
        .FirstOrDefault()
        as TException;
    if( ex == null ) return;
    if( !exceptionPredicate( ex ) ) return;
    action( vre.ValueReference, f, ex );
}


public static
    bool
Match<
    TException
>(
    System.Exception                                    e,
    System.Func< ValueReference, Frame, bool >          referencePredicate,
    System.Predicate< TException >                      exceptionPredicate
)
    where TException : System.Exception
{
    if( object.ReferenceEquals( e, null ) )
        throw new LocalisedArgumentNullException( "e" );
    if( object.ReferenceEquals( referencePredicate, null ) )
        throw new LocalisedArgumentNullException( "referencePredicate" );
    if( object.ReferenceEquals( exceptionPredicate, null ) )
        throw new LocalisedArgumentNullException( "exceptionPredicate" );

    bool result = false;
    ValueReferenceException.Match<
        TException >(
        e,
        (vre,f) => referencePredicate( vre, f.Up() ),
        exceptionPredicate,
        (vr,f,ex) => result = true );
    return result;
}


public static
    bool
Match<
    TException
>(
    System.Exception                            e,
    System.Func< ValueReference, Frame, bool >  referencePredicate
)
    where TException : System.Exception
{
    if( object.ReferenceEquals( e, null ) )
        throw new LocalisedArgumentNullException( "e" );
    if( object.ReferenceEquals( referencePredicate, null ) )
        throw new LocalisedArgumentNullException( "referencePredicate" );

    return Match<
        TException >(
        e,
        (vre,f) => referencePredicate( vre, f.Up() ),
        ex => true );
}



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
ValueReferenceException(
    ValueReference      valueReference,
    ///< Reference to the value that caused the underlying exception
    System.Exception    innerException
    ///< The underlying exception
)
    : base( null, innerException )
{
    if( object.ReferenceEquals( valueReference, null ) )
        throw new LocalisedArgumentNullException( "valueReference" );
    if( object.ReferenceEquals( innerException, null ) )
        throw new LocalisedArgumentNullException( "innerException" );
    this.ValueReference = valueReference;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
ValueReference
ValueReference
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// IValueException
// -----------------------------------------------------------------------------

public virtual
    Localised< string >
SayMessage(
    Localised< string > reference
)
{
    if( reference == null )
        throw new LocalisedArgumentNullException( "reference" );

    System.Exception e = this.InnerException;
    IValueException ve = e as IValueException;
    ILocalisedException le = e as ILocalisedException;

    if( ve != null ) return ve.SayMessage( reference );
    return LocalisedString.Format(
        "{0}: {1}",
        reference,
        le != null ? le.Message : e.Message );
}



// -----------------------------------------------------------------------------
// ILocalisedException
// -----------------------------------------------------------------------------

public override
Localised< string >
Message
{
    get { return this.SayMessage( this.ValueReference.ToString() ); }
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

