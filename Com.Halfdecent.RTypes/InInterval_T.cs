// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009
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
using Com.Halfdecent;
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.RTypes
{


public class
InInterval<
    T
>
    : RTypeBase< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
InInterval(
    IInterval< T > interval
)
{
    if( object.ReferenceEquals( interval, null ) )
        throw new ValueArgumentNullException( new Parameter( "interval" ) );
    this.Interval = interval;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
IInterval< T >
Interval
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// RTypeBase< T >
// -----------------------------------------------------------------------------

public override
    SCG.IEnumerable< IRType< T > >
GetComponents()
{
    return
        base.GetComponents()
        .Append(
            this.Interval.FromInclusive ?
                new GTE< T >( this.Interval.From, this.Interval.Comparer )
                    as IRType< T > :
                new GT< T >( this.Interval.From, this.Interval.Comparer )
                    as IRType< T > )
        .Append(
            this.Interval.ToInclusive ?
                new LTE< T >( this.Interval.To, this.Interval.Comparer )
                    as IRType< T > :
                new LT< T >( this.Interval.To, this.Interval.Comparer )
                    as IRType< T > );
}


public override
    Localised< string >
SayIs(
    Localised< string > reference
)
{
    if( object.ReferenceEquals( reference, null ) )
        throw new ValueArgumentNullException( new Parameter( "reference" ) );
    if( this.Interval.FromInclusive && this.Interval.ToInclusive )
        return _S( "{0} is between {1} and {2}, inclusive",
            reference,
            this.Interval.From.ToString(),
            this.Interval.To.ToString() );
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
    if( object.ReferenceEquals( reference, null ) )
        throw new ValueArgumentNullException( new Parameter( "reference" ) );
    if( this.Interval.FromInclusive && this.Interval.ToInclusive )
        return _S( "{0} is not between {1} and {2}, inclusive",
            reference,
            this.Interval.From.ToString(),
            this.Interval.To.ToString() );
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
    if( object.ReferenceEquals( reference, null ) )
        throw new ValueArgumentNullException( new Parameter( "reference" ) );
    if( this.Interval.FromInclusive && this.Interval.ToInclusive )
        return _S( "{0} must be between {1} and {2}, inclusive",
            reference,
            this.Interval.From.ToString(),
            this.Interval.To.ToString() );
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


public override
    bool
DirectionalEquals(
    IRType that
)
{
    return
        base.DirectionalEquals( that ) &&
        ((InInterval<T>)that.GetUnderlying()).Interval.Equals( this.Interval );
}


public override
    int
GetHashCode()
{
    return
        base.GetHashCode() ^
        this.Interval.GetHashCode();
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace
