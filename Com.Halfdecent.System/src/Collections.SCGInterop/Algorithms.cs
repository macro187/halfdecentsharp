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
using SCG = System.Collections.Generic;
//using Com.Halfdecent.GenericArithmetic;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Collections;


namespace
Com.Halfdecent.Collections.SCGInterop
{




/// Collection operation implementations in terms of
/// <tt>System.Collections.Generic</tt> types
public class
Algorithms
{



// not creatable
private Algorithms() {}



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// <tt>IBag.Stream()</tt> via
/// <tt>System.Collections.Generic.IEnumerable< T ></tt>
///
/// @par Description
/// Retrieves an enumerator using the enumerable's <tt>GetEnumerator()</tt>
/// method and wraps it in an <tt>IFiniteStreamFromIEnumeratorAdapter</tt>.
///
/// @par Complexity
/// Depends on the enumerator implementation.
///
/// @exception ArgumentNullException
/// The specified enumerable is <tt>null</tt>
///
public static
IFiniteStream< T >                      /// @returns
                                        /// (see <tt>IBag.Stream()</tt>)
IBagStreamViaIEnumerable<
    T                                   ///< Type of items in the source
                                        ///< enumerable and the resultant
                                        ///< stream
>(
    SCG.IEnumerable< T >    enumerable  ///< An enumerable
)
{
    if( enumerable == null ) throw new ArgumentNullException( "enumerable" );
    return new IFiniteStreamFromIEnumeratorAdapter< T >(
        enumerable.GetEnumerator() );
}



/// <tt>IBag.Count</tt> via
/// <tt>System.Collections.Generic.ICollection< T ></tt>
///
/// @par Description
/// Uses the collection's <tt>Count</tt> property
///
/// @par Complexity
/// Depends on the collection's <tt>Count</tt> implementation
///
/// @exception ArgumentNullException
/// The specified collection is <tt>null</tt>
///
public static
int                                     /// @returns
                                        /// (see <tt>IBag.Count</tt>)
IBagCountViaICollection<
    T                                   ///< Type of items in the collection
>(
    SCG.ICollection< T >    collection  ///< A collection
)
{
    if( collection == null ) throw new ArgumentNullException( "collection" );
    return collection.Count;
}



/// <tt>IBag.RemoveAll()</tt> via
/// a resizable <tt>System.Collections.Generic.ICollection< T ></tt>
///
/// @par Description
/// Uses the collection's <tt>Clear()</tt> method
///
/// @par Complexity
/// Depends on the collection's <tt>Clear()</tt> implementation
///
/// @exception ArgumentNullException
/// The collection is <tt>null</tt>
///
/// @exception (unknown)
/// If the underlying collection is not resizable, it's <tt>Clear()</tt>
/// implementation will (hopefully) throw some kind of exception
///
public static
void
IBagRemoveAllViaICollection<
    T                                   ///< Type of items in the collection
>(
    SCG.ICollection< T >    collection  ///< A resizable collection
)
{
    if( collection == null ) throw new ArgumentNullException( "collection" );
    collection.Clear();
}




} // type
} // namespace

