// -----------------------------------------------------------------------------
// Copyright (c) 2011
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


public struct
Maybe<
    T
>
    : IMaybe< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
Maybe(
    bool    hasValue,
    T       value
)
{
    this.hasvalue = hasValue;
    this.value = hasValue ? value : default( T );
}



// -----------------------------------------------------------------------------
// IMaybe< T >
// -----------------------------------------------------------------------------

public
    bool
HasValue
{
    get { return this.hasvalue; }
}

private
    bool
hasvalue;


public
    T
Value
{
    get
    {
        if( !this.HasValue )
            throw new System.InvalidOperationException( "No underlying value" );
        return this.value;
    }
}

private
    T
value;



// -----------------------------------------------------------------------------
// ITuple< bool, T >
// -----------------------------------------------------------------------------

    bool
ITuple< bool, T >.A
{
    get { return this.HasValue; }
}


    T
ITuple< bool, T >.B
{
    get { return this.HasValue ? this.Value : default( T ); }
}




} // type
} // namespace

