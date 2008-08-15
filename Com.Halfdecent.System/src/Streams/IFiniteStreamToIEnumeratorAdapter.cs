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




/// Presents an <tt>IFiniteStream< T ></tt> as an <tt>IEnumerator< T ></tt>
///
public class
IFiniteStreamToIEnumeratorAdapter<
    T   ///< Type of items on the stream and, thus, in the resultant enumerator
>
    : IEnumerator< T >
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialize a new <tt>IFiniteStreamToIEnumeratorAdapter< T ></tt> adapting
/// the given <tt>IFiniteStream< T ></tt>
///
public
IFiniteStreamToIEnumeratorAdapter(
    IFiniteStream< T > stream   ///< The <tt>IFiniteStream< T ></tt> to present
                                /// as an enumerator
                                /// - Really <tt>IsPresent</tt>
)
{
    new IsPresent< IFiniteStream< T > >().ReallyRequire( stream );
    this.stream = stream;
    this.started = false;
    this.finished = false;
}




// -----------------------------------------------------------------------------
// Fields
// -----------------------------------------------------------------------------

private
IFiniteStream< T >
stream;



private
bool
started;



private
bool
finished;



private
T
current;




// -----------------------------------------------------------------------------
// IEnumerator< T >
// -----------------------------------------------------------------------------

/// (see <tt>IEnumerator< T >.Current</tt>)
///
/// @exception HDInvalidOperationException
/// If the enumerator is positioned before the first or after the last item
///
public
T
Current
{
    get
    {
        if( !this.started ) throw new HDInvalidOperationException(
            _S("The current item cannot be retreived because the enumerator is still positioned before the first item") );
        if( this.finished ) throw new HDInvalidOperationException(
            _S("The current item cannot be retreived because the enumerator is already positioned past the last item") );
        return this.current;
    }
}




// -----------------------------------------------------------------------------
// IEnumerator
// -----------------------------------------------------------------------------

/// (see <tt>IEnumerator.Current</tt>)
///
/// @exception HDInvalidOperationException
/// If the enumerator is positioned before the first or after the last item
///
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
/// @sa
/// <tt>IFiniteStream::Yield()</tt>
///
public
bool
MoveNext()
{
    bool result = false;
    if( !this.started ) this.started = true;
    if( !this.finished ) {
        if( this.stream.Yield( out this.current ) ) {
            result = true;
        } else {
            this.finished = true;
        }
    }
    return result;
}



/// (see <tt>IEnumerator.Reset()</tt>)
///
/// @exception HDInvalidOperationException
/// Every time, because streams are not resettable
///
public
void
Reset()
{
    throw new HDInvalidOperationException(
        _S("This enumerator cannot be reset because it is enumerating an IStream, and IStreams cannot be reset") );
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




private static Com.Halfdecent.Globalization.Localized< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

