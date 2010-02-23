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


namespace
Com.Halfdecent
{


// =============================================================================
/// TODO
// =============================================================================

public class
TupleProxy<
    TFrom1,
    TFrom2,
    TTo1,
    TTo2
>
    : ITuple< TTo1, TTo2 >
    where TFrom1 : TTo1
    where TFrom2 : TTo2
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
TupleProxy(
    ITuple< TFrom1, TFrom2 > from
)
{
    if( object.ReferenceEquals( from, null ) )
        throw new System.ArgumentNullException( "from" );
    this.From = from;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
ITuple< TFrom1, TFrom2 >
From
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// ITuple< TTo1, TTo2 >
// -----------------------------------------------------------------------------

public
TTo1
A
{
    get { return this.From.A; }
}


public
TTo2
B
{
    get { return this.From.B; }
}




} // type
} // namespace

