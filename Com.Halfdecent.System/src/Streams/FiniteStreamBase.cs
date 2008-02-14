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
using System.Collections;
using System.Collections.Generic;
using R = Com.Halfdecent.Resources.Resource;
using Com.Halfdecent.System;


namespace
Com.Halfdecent.Streams
{




/// Base class for implementing <tt>IFiniteStream< T ></tt>s
///
public abstract class
FiniteStreamBase<
    T   ///< (See <tt>IFiniteStream< T ></tt>)
>
    : IFiniteStream< T >
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialize a new <tt>FiniteStreamBase< T ></tt>
///
public
FiniteStreamBase()
{
    this.enumeratoradapter =
        new IFiniteStreamToIEnumeratorAdapter< T >( this );
}




// -----------------------------------------------------------------------------
// Fields
// -----------------------------------------------------------------------------

private
IEnumerator< T >
enumeratoradapter;




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// (see <tt>IFiniteStream< T >.Yield()</tt>)
///
public abstract
bool
Yield(
    out T item
);




// -----------------------------------------------------------------------------
// IStream< T >
// -----------------------------------------------------------------------------

/// (see <tt>IStream< T >.Yield()</tt>)
///
T
IStream< T >.Yield()
{
    T result;
    if( !((IFiniteStream< T >)this).Yield( out result ) )
        // TODO: Create (and throw) more specific type of exception (?)
        throw new HDInvalidOperationException(
            R._S("No more items in stream") );
    return result;
}




// -----------------------------------------------------------------------------
// IEnumerable< T >
// -----------------------------------------------------------------------------

/// (see <tt>IEnumerable< T >.GetEnumerator()</tt>)
///
IEnumerator< T >
IEnumerable< T >.GetEnumerator()
{
    return this.enumeratoradapter;
}




// -----------------------------------------------------------------------------
// IEnumerable
// -----------------------------------------------------------------------------

/// (see <tt>IEnumerable.GetEnumerator()</tt>)
///
IEnumerator
IEnumerable.GetEnumerator()
{
    return ((IEnumerable< T >)this).GetEnumerator();
}




} // type
} // namespace

