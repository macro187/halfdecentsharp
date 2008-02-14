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




/// Presents an enumerator as a stream
public class
IStreamFromIEnumeratorAdapter<
    T   ///< Type of items in the enumerator and resultant stream
>
    : IStream<T>
    , IDisposable
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialize a new <tt>IEnumeratorToIStreamAdapter< T ></tt> adapting a given
/// enumerator
///
public
IStreamFromIEnumeratorAdapter(
    IEnumerator<T> enumerator   ///< The <tt>IEnumerator< T ></tt> to adapt
                                ///  - <tt>IsPresent</tt> else bug
)
{
    new IsPresent().ReallyRequire( enumerator );
    this.enumerator = enumerator;
    this.enumeratoradapter = new IStreamToIEnumeratorAdapter<T>( this );
}




// -----------------------------------------------------------------------------
// Fields
// -----------------------------------------------------------------------------

private IEnumerator<T>
enumerator;

private IEnumerator<T>
enumeratoradapter;




// -----------------------------------------------------------------------------
// Interface: IStream
// -----------------------------------------------------------------------------

/// (see <tt>IStream::Yield()</tt>)
public T
Yield()
{
    if( !this.enumerator.MoveNext() )
        // TODO: Create (and throw) more specific type of exception (?)
        throw new InvalidOperationException( "No more items in stream" );
    return this.enumerator.Current;
}




// -----------------------------------------------------------------------------
// Interface: IEnumerable<T>
// -----------------------------------------------------------------------------

/// (see <tt>IEnumerable< T >::GetEnumerator()</tt>)
IEnumerator<T>
IEnumerable<T>.GetEnumerator()
{
    return this.enumeratoradapter;
}




// -----------------------------------------------------------------------------
// Interface: IEnumerable
// -----------------------------------------------------------------------------

/// (see <tt>IEnumerable::GetEnumerator()</tt>)
IEnumerator
IEnumerable.GetEnumerator()
{
    return ((IEnumerable<T>)this).GetEnumerator();
}




// -----------------------------------------------------------------------------
// Interface: IDisposable
// -----------------------------------------------------------------------------

/// Disposes the underlying enumerator
///
/// @sa
/// <tt>IDisposable::Dispose()</tt>
public void
Dispose()
{
    this.enumerator.Dispose();
    // TODO: Do we have to track whether this has been called and throw
    // exceptions in other operations it has?
}




} // type
} // namespace

