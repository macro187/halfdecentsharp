// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010, 2012
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
/// RType<T> contravariant proxy
// =============================================================================

public class
RTypeProxy<
    TFrom,
    TTo
>
    : RType< TTo >
    , IProxy

    where TTo : TFrom
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
RTypeProxy(
    RType< TFrom > from
)
    : base(
        item => from.Is( item ),
        from.SayIs,
        from.SayIsNot,
        from.SayMustBe )
{
    if( object.ReferenceEquals( from, null ) )
        throw new LocalisedArgumentNullException( "from" );
    this.From = from;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

private
RType< TFrom >
From;



// -----------------------------------------------------------------------------
// IEquatableHD< RType >
// IEquatable< RType >
// -----------------------------------------------------------------------------

public override
    bool
Equals(
    RType that
)
{
    return this.From.Equals( that );
}


public override
    int
GetHashCode()
{
    return this.From.GetHashCode();
}



// -----------------------------------------------------------------------------
// IProxy
// -----------------------------------------------------------------------------

    object
IProxy.Underlying
{
    get { return this.From; }
}




} // type
} // namespace

