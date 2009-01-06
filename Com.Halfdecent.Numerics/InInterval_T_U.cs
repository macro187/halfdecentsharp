// -----------------------------------------------------------------------------
// Copyright (c) 2008 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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
using System.Collections.Generic;
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Numerics
{


public class
InInterval<
    T,
    TInterval
>
    : RTypeBase< T >
    where T : IComparable< TInterval >
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
InInterval(
    IInterval< TInterval > interval
)
{
    NonNull.SCheck( interval, new Parameter( "interval" ) );
    this.interval = interval;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
IInterval< TInterval >
Interval
{
    get { return this.interval; }
}

private
IInterval< TInterval >
interval;




// -----------------------------------------------------------------------------
// RType1Base
// -----------------------------------------------------------------------------

public override
IEnumerable< IRType< T > >
Components
{
    get
    {
        if( this.interval.FromInclusive )
            yield return new GTE< T, TInterval >( this.interval.From );
        else
            yield return new GT< T, TInterval >( this.interval.From );

        if( this.interval.ToInclusive )
            yield return new LTE< T, TInterval >( this.interval.To );
        else
            yield return new LT< T, TInterval >( this.interval.To );
    }
}




// -----------------------------------------------------------------------------
// IRType1
// -----------------------------------------------------------------------------

public override
Localised< string >
SayIs(
    Localised< string > reference
)
{
    new NonNull< string >().Check( reference, new Parameter( "reference" ) );
    if( this.interval.FromInclusive && this.interval.ToInclusive )
        return _S( "{0} is between {1} and {2}, inclusive",
            reference,
            this.interval.From.ToString(),
            this.interval.To.ToString() );
    else if( !this.interval.FromInclusive && !this.interval.ToInclusive )
        return _S( "{0} is between {1} and {2}, exclusive",
            reference,
            this.interval.From,
            this.interval.To );
    else if( this.interval.FromInclusive )
        return _S( "{0} is {1} or greater and less than {2}",
            reference,
            this.interval.From,
            this.interval.To );
    else // if( this.interval.ToInclusive )
        return _S( "{0} is greater than {1} and {2} or less",
            reference,
            this.interval.From,
            this.interval.To );
}



public override
Localised< string >
SayIsNot(
    Localised< string > reference
)
{
    new NonNull< string >().Check( reference, new Parameter( "reference" ) );
    if( this.interval.FromInclusive && this.interval.ToInclusive )
        return _S( "{0} is not between {1} and {2}, inclusive",
            reference,
            this.interval.From.ToString(),
            this.interval.To.ToString() );
    else if( !this.interval.FromInclusive && !this.interval.ToInclusive )
        return _S( "{0} is not between {1} and {2}, exclusive",
            reference,
            this.interval.From,
            this.interval.To );
    else if( this.interval.FromInclusive )
        return _S( "{0} is less than {1}, or is {2} or greater",
            reference,
            this.interval.From,
            this.interval.To );
    else // if( this.interval.ToInclusive )
        return _S( "{0} {1} or less, or is greater than {2}",
            reference,
            this.interval.From,
            this.interval.To );
}



public override
Localised< string >
SayMustBe(
    Localised< string > reference
)
{
    new NonNull< string >().Check( reference, new Parameter( "reference" ) );
    if( this.interval.FromInclusive && this.interval.ToInclusive )
        return _S( "{0} must be between {1} and {2}, inclusive",
            reference,
            this.interval.From.ToString(),
            this.interval.To.ToString() );
    else if( !this.interval.FromInclusive && !this.interval.ToInclusive )
        return _S( "{0} must be between {1} and {2}, exclusive",
            reference,
            this.interval.From,
            this.interval.To );
    else if( this.interval.FromInclusive )
        return _S( "{0} must be {1} or greater and less than {2}",
            reference,
            this.interval.From,
            this.interval.To );
    else // if( this.interval.ToInclusive )
        return _S( "{0} must be greater than {1} and {2} or less",
            reference,
            this.interval.From,
            this.interval.To );
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

