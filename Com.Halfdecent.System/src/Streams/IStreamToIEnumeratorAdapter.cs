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
/// Presents an <see cref="IStream"/> as an <see cref="IEnumerator"/>
/// </summary>
public class
IStreamToIEnumeratorAdapter<T>
    : IEnumerator<T>
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// <summary>
/// Initialize a new <c>IStreamToIEnumeratorAdapter</c> adapting a given
/// <see cref="IStream"/>
/// </summary>
public
IStreamToIEnumeratorAdapter(
    IStream<T> stream
)
{
    if( stream == null ) throw new ArgumentNullException( "stream" );
    this.stream = stream;
    this.started = false;
    //this.finished = false;
}




// -----------------------------------------------------------------------------
// Fields
// -----------------------------------------------------------------------------

private IStream<T>
stream;

private bool
started;

/*
private bool
finished;
*/

private T
current;




// -----------------------------------------------------------------------------
// Interface: IEnumerator
// -----------------------------------------------------------------------------

/// <summary>(see <see cref="IEnumerator.Current"/>)</summary>
/// <exception cref="InvalidOperationException">
/// If the enumerator is still positioned before the first item
/// </exception>
object
IEnumerator.Current
{
    get
    {
        return ((IEnumerator<T>)this).Current;
    }
}



/// <summary>(see <see cref="IEnumerator.MoveNext"/>)</summary>
/// <exception cref="InvalidOperationException">
/// If the underlying stream definitely cannot produce any more items
/// (exception will originate in the underlying <c>IStream.Yield()</c>)
/// </exception>
/// <seealso cref="IStream.Yield"/>
bool
IEnumerator.MoveNext()
{
    this.current = this.stream.Yield(); // throws InvalidOperationException if
                                        // the IStream is finished
    if( !this.started ) this.started = true;
    return true;
}



/// <summary>(see <see cref="IEnumerator.Reset"/>)</summary>
/// <exception cref="InvalidOperationException"/>
void
IEnumerator.Reset()
{
    throw new InvalidOperationException(
        "This enumerator cannot be reset because it is enumerating an" +
        " IStream, and IStreams cannot be reset" );
}




// -----------------------------------------------------------------------------
// Interface: IEnumerator<T>
// -----------------------------------------------------------------------------

/// <summary>(see <see cref="IEnumerator<T>.Current"/>)</summary>
/// <exception cref="InvalidOperationException">
/// If the enumerator is still positioned before the first item
/// </exception>
T
IEnumerator<T>.Current
{
    get
    {
        if( !started ) throw new InvalidOperationException(
            "The current item cannot be retreived because the enumerator is" +
            " still positioned before the first item" );
        /*
        if( finished ) throw new InvalidOperationException(
            "The current item cannot be retreived because the enumerator is" +
            " already positioned past the last item" );
        */
        return this.current;
    }
}




// -----------------------------------------------------------------------------
// Interface: IDisposable
// -----------------------------------------------------------------------------

/// <summary>(see <see cref="IDisposable.Dispose"/>)</summary>
/// <remarks>
/// The <c>foreach</c> statement unconditionally <c>Dispose()</c>s enumerators
/// after using them.  This conflicts with <c>IStream</c>'s semantics which
/// allow it to be <c>foreach</c>ed more than once, so this <c>Dispose()</c>
/// does nothing.  If the underlying <see cref="IStream"/> is
/// <see cref="IDisposable"/>, it should be explicitly <c>Dispose()</c>d
/// directly when no longer needed.
/// </remarks>
void
IDisposable.Dispose()
{
}




} // type
} // namespace

