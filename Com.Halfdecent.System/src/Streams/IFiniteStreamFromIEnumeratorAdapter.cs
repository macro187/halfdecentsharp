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

namespace
Com.Halfdecent.Streams
{




/// Makes a finite stream out of an enumerator
///
public class
IFiniteStreamFromIEnumeratorAdapter<
    T   ///< Type of items in the enumerator and resultant stream
>
    : FiniteStreamBase< T >
    , IDisposable
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialize a new <tt>IFiniteStreamFromIEnumeratorAdapter< T ></tt> adapting
/// a given enumerator
///
public
IFiniteStreamFromIEnumeratorAdapter(
    IEnumerator< T > enumerator ///< The <tt>IEnumerator< T ></tt> to adapt
                                ///  Requirements:
                                ///  - Really <tt>IsPresent</tt>
)
    : base()
{
    new IsPresent< IEnumerator< T > >().ReallyRequire( enumerator );
    this.enumerator = enumerator;
}




// -----------------------------------------------------------------------------
// Fields
// -----------------------------------------------------------------------------

private
IEnumerator< T >
enumerator;




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// (see <tt>IFiniteStream< T >.Yield()</tt>)
///
public override
bool
Yield(
    out T item
)
{
    bool result;
    if( this.enumerator.MoveNext() ) {
        result = true;
        item = this.enumerator.Current;
    } else {
        result = false;
        item = default( T );
    }
    return result;
}




/// Disposes the underlying enumerator
///
/// @sa
/// <tt>IDisposable.Dispose()</tt>
///
public
void
Dispose()
{
    this.enumerator.Dispose();
    // TODO: Do we have to track whether this has been called and throw
    // exceptions in other operations it has?
}




} // type
} // namespace

