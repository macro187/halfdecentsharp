// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010, 2012
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
using Halfdecent.RTypes;


namespace
Halfdecent.RTypes
{


// =============================================================================
/// Static methods for <tt>InInterval<T></tt>
// =============================================================================

public static class
InInterval
{


public static
    void
CheckParameter<
    T
>(
    IInterval< T >  interval,
    T               item,
    string          paramName
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
            () => Create( interval ).Check( item ) ) );
}


public static
    void
Check<
    T
>(
    IInterval< T >  interval,
    T               item
)
{
    ValueReferenceException.Map(
        f => f.Parameter( "item" ),
        f => f.Down().Parameter( "item" ),
        () => Create( interval ).Check( item ) );
}


public static
    RType< T >
Create<
    T
>(
    IInterval< T > interval
)
{
    return new InInterval< T >( interval );
}



} // type



// =============================================================================
/// RType: Within a particular interval
// =============================================================================

public sealed class
InInterval<
    T
>
    : CompositeRType< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
InInterval(
    IInterval< T > interval
)
    : base(
        SystemEnumerable.Create(
            interval.FromInclusive
                ? GTE.Create( interval.From, interval.Comparer )
                : GT.Create( interval.From, interval.Comparer ),
            interval.ToInclusive
                ? LTE.Create( interval.To, interval.Comparer )
                : LT.Create( interval.To, interval.Comparer ) ),
        null, null, null )
{
    if( interval == null )
        throw new LocalisedArgumentNullException( "interval" );
    this.Interval = interval;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

private
IInterval< T >
Interval;



// -----------------------------------------------------------------------------
// RType
// -----------------------------------------------------------------------------

public override
    Localised< string >
SayIs(
    Localised< string > reference
)
{
    if( reference == null )
        throw new LocalisedArgumentNullException( "reference" );
    if( this.Interval.FromInclusive && this.Interval.ToInclusive )
        return _S( "{0} is between {1} and {2}, inclusive",
            reference,
            this.Interval.From,
            this.Interval.To );
    else if( !this.Interval.FromInclusive && !this.Interval.ToInclusive )
        return _S( "{0} is between {1} and {2}, exclusive",
            reference,
            this.Interval.From,
            this.Interval.To );
    else if( this.Interval.FromInclusive )
        return _S( "{0} is {1} or greater and less than {2}",
            reference,
            this.Interval.From,
            this.Interval.To );
    else // if( this.Interval.ToInclusive )
        return _S( "{0} is greater than {1} and {2} or less",
            reference,
            this.Interval.From,
            this.Interval.To );
}


public override
    Localised< string >
SayIsNot(
    Localised< string > reference
)
{
    if( reference == null )
        throw new LocalisedArgumentNullException( "reference" );
    if( this.Interval.FromInclusive && this.Interval.ToInclusive )
        return _S( "{0} is not between {1} and {2}, inclusive",
            reference,
            this.Interval.From,
            this.Interval.To );
    else if( !this.Interval.FromInclusive && !this.Interval.ToInclusive )
        return _S( "{0} is not between {1} and {2}, exclusive",
            reference,
            this.Interval.From,
            this.Interval.To );
    else if( this.Interval.FromInclusive )
        return _S( "{0} is less than {1}, or is {2} or greater",
            reference,
            this.Interval.From,
            this.Interval.To );
    else // if( this.Interval.ToInclusive )
        return _S( "{0} {1} or less, or is greater than {2}",
            reference,
            this.Interval.From,
            this.Interval.To );
}


public override
    Localised< string >
SayMustBe(
    Localised< string > reference
)
{
    if( reference == null )
        throw new LocalisedArgumentNullException( "reference" );
    if( this.Interval.FromInclusive && this.Interval.ToInclusive )
        return _S( "{0} must be between {1} and {2}, inclusive",
            reference,
            this.Interval.From,
            this.Interval.To );
    else if( !this.Interval.FromInclusive && !this.Interval.ToInclusive )
        return _S( "{0} must be between {1} and {2}, exclusive",
            reference,
            this.Interval.From,
            this.Interval.To );
    else if( this.Interval.FromInclusive )
        return _S( "{0} must be {1} or greater and less than {2}",
            reference,
            this.Interval.From,
            this.Interval.To );
    else // if( this.Interval.ToInclusive )
        return _S( "{0} must be greater than {1} and {2} or less",
            reference,
            this.Interval.From,
            this.Interval.To );
}




private static Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Halfdecent.Globalisation.LocalisedResource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

