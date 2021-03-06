// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010, 2011
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
Halfdecent
{


public struct
TupleHD<
    T1,
    T2
>
    : ITupleHD< T1, T2 >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
TupleHD(
    T1  a,
    T2  b
)
{
    this.a = a;
    this.b = b;
}



// -----------------------------------------------------------------------------
// Fields
// -----------------------------------------------------------------------------

private
T1
a;


private
T2
b;



// -----------------------------------------------------------------------------
// ITuple< T1, T2 >
// -----------------------------------------------------------------------------

public
T1
A
{
    get { return this.a; }
}


public
T2
B
{
    get { return this.b; }
}




} // type
} // namespace

