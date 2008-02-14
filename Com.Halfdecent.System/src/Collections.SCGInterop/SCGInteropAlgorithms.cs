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
using R = Com.Halfdecent.Resources.Resource;
using Com.Halfdecent.System;
using Com.Halfdecent.Numerics;
using Com.Halfdecent.Streams;
using Com.Halfdecent.Collections;


namespace
Com.Halfdecent.Collections.SCGInterop
{




/// Collection operation implementations in terms of
/// <tt>System.Collections.Generic</tt> types
public class
SCGInteropAlgorithms
{



// not creatable
private SCGInteropAlgorithms() {}



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
public static
IFiniteStream< T >                      /// @returns
                                        /// (see <tt>IBag< T >.Stream()</tt>)
IBagStreamViaIEnumerable<
    T                                   ///< Type of items in the source
                                        ///< enumerable and the resultant
                                        ///< stream
>(
    SCG.IEnumerable< T >    enumerable  ///< An enumerable
                                        ///  - Really <tt>IsPresent</tt>
)
{
    new IsPresent< SCG.IEnumerable< T > >().ReallyRequire( enumerable );
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
public static
Integer                                 /// @returns
                                        /// (see <tt>IBag< T >.Count</tt>)
IBagCountViaICollection<
    T                                   ///< Type of items in the collection
>(
    SCG.ICollection< T >    collection  ///< A collection
)
{
    new IsPresent< SCG.ICollection< T > >().Require( collection );
    return Integer.From( collection.Count );
}



/// <tt>IBag.RemoveAll()</tt> via
/// a shrinkable <tt>System.Collections.Generic.ICollection< T ></tt>
///
/// @par Description
/// Uses the collection's <tt>Clear()</tt> method
///
/// @par Complexity
/// Depends on the collection's <tt>Clear()</tt> implementation
///
/// @exception BugException
/// The underlying collection is not shrinkable.  <tt>InnerException</tt> will
/// be the <tt>NotSupportedException</tt> thrown by the underlying collection's
/// <tt>Clear()</tt> method.
///
public static
void
IBagRemoveAllViaICollection<
    T                                   ///< Type of items in the collection
>(
    SCG.ICollection< T >    collection  ///< A resizable collection
                                        ///  - Really <tt>IsPresent</tt>
)
{
    new IsPresent< SCG.ICollection< T > >().ReallyRequire( collection );
    try {
        collection.Clear();
    } catch( NotSupportedException e ) {
        throw new BugException(
            R._S("This collection is not shrinkable"),
            e );
    }
}



/// <tt>IBag< T >.Add()</tt> via a growable
/// <tt>System.Collections.Generic.ICollection< T ></tt>
///
public static
void
IBagAddViaICollection<
    T
>(
    SCG.ICollection< T >    collection, ///< A resizable collection
                                        ///  - Really <tt>IsPresent</tt>
    T                       item        ///< The item to add
)
{
    new IsPresent< SCG.ICollection< T > >().ReallyRequire( collection );
    try {
        collection.Add( item );
    } catch( NotSupportedException e ) {
        throw new BugException(
            R._S("This collection is not growable"),
            e );
    }
}



/// <tt>IListCanGetAt< T >.GetAt()</tt> via
/// <tt>System.Collections.Generic.IList< T ></tt>
///
public static
T
IListGetAtViaIList<
    T
>(
    SCG.IList< T >  list,       ///< Requirements:
                                ///  - Really IsPresent
    Integer         position    ///< Requirements:
                                ///  - IsNotNegative
                                ///  - IsLessThan( list.Count )
)
{
    new IsPresent< SCG.IList< T > >().ReallyRequire( list );
    new IsNotNegative().Require( position );
    new IsLessThan< Integer >( Integer.From( list.Count ) ).Require( position );
    return list[ (int)( position.ToDecimal() ) ];
}




} // type
} // namespace

