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

#if DOTNET40


namespace
Com.Halfdecent
{


// =============================================================================
/// TODO
// =============================================================================

public class
TupleFromSystemTupleAdapter<
    T1,
    T2
>
    : ITuple< T1, T2 >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
TupleFromSystemTupleAdapter(
    System.Tuple< T1, T2 > from
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
System.Tuple< T1, T2 >
From
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// ITuple< T1, T2 >
// -----------------------------------------------------------------------------

public
T1
A
{
    get { return this.From.Item1; }
}


public
T2
B
{
    get { return this.From.Item2; }
}




} // type
} // namespace

#endif

