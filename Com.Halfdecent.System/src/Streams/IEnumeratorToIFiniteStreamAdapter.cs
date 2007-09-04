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
using System.Collections;
using System.Collections.Generic;

using Com.Halfdecent.System;



namespace
Com.Halfdecent.Streams
{



/// <summary>
/// Presents an <see cref="IEnumerator"/> as an <see cref="IFiniteStream"/>
/// </summary>
public class
IEnumeratorToIFiniteStreamAdapter<T>
    : IFiniteStream<T>
    , IDisposable
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// <summary>
/// Initialize a new <c>IEnumeratorToIFiniteStreamAdapter</c> adapting a given
/// <see cref="IEnumerator"/>
/// </summary>
public
IEnumeratorToIFiniteStreamAdapter(
    IEnumerator<T> enumerator
)
{
    if( enumerator == null ) throw new ArgumentNullException( "enumerator" );
    this.enumerator = enumerator;
    this.enumeratoradapter = new IFiniteStreamToIEnumeratorAdapter<T>( this );
}




// -----------------------------------------------------------------------------
// Fields
// -----------------------------------------------------------------------------

private IEnumerator<T>
enumerator;

private IEnumerator<T>
enumeratoradapter;




// -----------------------------------------------------------------------------
// Interface: IFiniteStream
// -----------------------------------------------------------------------------

/// <summary>(see <see cref="IFiniteStream.Yield"/>)</summary>
bool
IFiniteStream<T>.Yield(
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




// -----------------------------------------------------------------------------
// Interface: IStream
// -----------------------------------------------------------------------------

/// <summary>(see <see cref="IStream.Yield"/>)</summary>
T
IStream<T>.Yield()
{
    T result;
    if( !((IFiniteStream<T>)this).Yield( out result ) )
        // TODO: Create (and throw) more specific type of exception (?)
        throw new InvalidOperationException( "No more items in stream" );
    return result;
}




// -----------------------------------------------------------------------------
// Interface: IEnumerable
// -----------------------------------------------------------------------------

/// <summary>(see <see cref="IEnumerable.GetEnumerator"/>)</summary>
IEnumerator
IEnumerable.GetEnumerator()
{
    return ((IEnumerable<T>)this).GetEnumerator();
}




// -----------------------------------------------------------------------------
// Interface: IEnumerable<T>
// -----------------------------------------------------------------------------

/// <summary>(see <see cref="IEnumerable<T>.GetEnumerator"/>)</summary>
IEnumerator<T>
IEnumerable<T>.GetEnumerator()
{
    return this.enumeratoradapter;
}




// -----------------------------------------------------------------------------
// Interface: IDisposable
// -----------------------------------------------------------------------------

/// <summary>
/// Disposes the underlying <see cref="IEnumerator"/>
/// </summary>
/// <seealso cref="IDisposable.Dispose"/>
void
IDisposable.Dispose()
{
    this.enumerator.Dispose();
    // TODO: Do we have to track whether this has been called and throw
    // exceptions in other operations it has?
}




} // type
} // namespace


