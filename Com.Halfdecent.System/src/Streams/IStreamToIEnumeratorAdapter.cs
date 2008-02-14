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
using R = Com.Halfdecent.Resources.Resource;


namespace
Com.Halfdecent.Streams
{




/// Presents an <tt>IStream< T ></tt> as an <tt>IEnumerator< T ></tt>
public class
IStreamToIEnumeratorAdapter<
    T   ///< Type of items on the stream and, thus, in the resultant enumerator
>
    : IEnumerator< T >
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialize a new <tt>IStreamToIEnumeratorAdapter</tt> adapting a given
/// stream
///
public
IStreamToIEnumeratorAdapter(
    IStream< T > stream ///< The <tt>IStream< T ></tt> to adapt
                        ///  - Really <tt>IsPresent</tt>
)
{
    new IsPresent().ReallyRequire( stream );
    this.stream = stream;
    this.started = false;
}




// -----------------------------------------------------------------------------
// Fields
// -----------------------------------------------------------------------------

private
IStream< T >
stream;



private
bool
started;



private
T
current;




// -----------------------------------------------------------------------------
// IEnumerator< T >
// -----------------------------------------------------------------------------

/// (see <tt>IEnumerator< T >.Current</tt>)
///
/// @exception HDInvalidOperationException
/// If the enumerator is still positioned before the first item
public
T
Current
{
    get
    {
        if( !started ) throw new HDInvalidOperationException(
            R._S("The current item cannot be retreived because the enumerator is still positioned before the first item") );
        return this.current;
    }
}




// -----------------------------------------------------------------------------
// IEnumerator
// -----------------------------------------------------------------------------

/// (see <tt>IEnumerator.Current</tt>)
///
/// @exception HDInvalidOperationException
/// If the enumerator is still positioned before the first item
object
IEnumerator.Current
{
    get
    {
        return ((IEnumerator< T >)this).Current;
    }
}



/// (see <tt>IEnumerator.MoveNext()</tt>)
///
/// @exception HDInvalidOperationException
/// If the underlying stream definitely cannot produce any more items
/// (exception will originate in the underlying <tt>IStream< T >.Yield()</tt>)
///
/// @sa
/// <tt>IStream.Yield()</tt>
public
bool
MoveNext()
{
    this.current = this.stream.Yield(); // throws HDInvalidOperationException if
                                        // the IStream is finished
    if( !this.started ) this.started = true;
    return true;
}



/// (see <tt>IEnumerator.Reset()</tt>)
///
/// @exception HDInvalidOperationException
/// Every time, because streams are not resettable
public
void
Reset()
{
    throw new InvalidOperationException(
        R._S("This enumerator cannot be reset because it is enumerating an IStream, and IStreams cannot be reset") );
}




// -----------------------------------------------------------------------------
// IDisposable
// -----------------------------------------------------------------------------

/// (see <tt>IDisposable.Dispose()</tt>)
///
/// The <tt>foreach</tt> statement unconditionally <tt>Dispose()</tt>s
/// enumerators after using them.  This conflicts with <tt>IStream< T ></tt>'s
/// semantics which allow it to be <tt>foreach</tt>ed more than once, so this
/// method does nothing.  If the underlying <tt>IFiniteStream< T ></tt> is
/// <tt>IDisposable</tt> it should be explicitly <tt>Dispose()</tt>d directly
/// when no longer needed.
public
void
Dispose()
{
}




} // type
} // namespace

