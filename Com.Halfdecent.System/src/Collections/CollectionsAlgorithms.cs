// -----------------------------------------------------------------------------
// Copyright (c) 2007 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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
using Com.Halfdecent.System;
using Com.Halfdecent.Numerics;


namespace
Com.Halfdecent.Collections
{




/// %Collections algorithms
public class
CollectionsAlgorithms
{



// not creatable
private CollectionsAlgorithms() {}



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Compute <tt>IBag.Count</tt> via <tt>IBagCanStream.Stream()</tt>
///
/// @par Description
/// Computes <tt>Count</tt> by going through all items in the bag using
/// <tt>Stream()</tt> and keeping count.
///
/// @par Complexity
/// Linear
///
public static
Integer              /// @returns The number of items in the bag
CountViaStream<
    TBag,           ///< Bag type
    T               ///< (see <tt>IBag< T ></tt>)
>(
    TBag bag        ///< The bag
                    ///  - Really <tt>IsPresent</tt>
)
    where TBag : IBagCanStream< T >
{
    new IsPresent< TBag >().ReallyRequire( bag );

    Integer result = Integer.From( 0 );
    foreach( T item in bag.Stream() ) {
        result = result.Plus( Integer.From( 1 ) );
        if( item.Equals( null ) ) {}    // avoid compiler warning
    }
    return result;
}




} // type
} // namespace

