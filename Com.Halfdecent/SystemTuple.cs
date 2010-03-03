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
/// <tt>System.Tuple</tt> Library
// =============================================================================

public static class
SystemTuple
{



public static
    ITuple< T1, T2 >
AsHalfdecentTuple<
    T1,
    T2
>(
    this System.Tuple< T1, T2 > dis
)
{
    if( object.ReferenceEquals( dis, null ) )
        throw new System.ArgumentNullException( "dis" );
    return new TupleFromSystemTupleAdapter< T1, T2 >( dis );
}




} // type
} // namespace

#endif

