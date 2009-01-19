// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009
// Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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
using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// Presents an <tt>IStream< T ></tt> as an <tt>IEnumerator< T ></tt>
// =============================================================================
//
public class
StreamToEnumeratorAdapter<
    T
>
    : IEnumerator< T >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
StreamToEnumeratorAdapter(
    IStream< T > stream
)
{
    NonNull.Check( stream, new Parameter( "stream" ) );
    this.stream = stream;
    this.started = false;
    this.finished = false;
}



// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

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
// Properties
// -----------------------------------------------------------------------------

public
IStream< T >
Stream
{
    get { return this.stream; }
}

private
IStream< T >
stream;



// -----------------------------------------------------------------------------
// IEnumerator< T >
// -----------------------------------------------------------------------------

/// @exception InvalidOperationException
/// The enumerator is still positioned before the first item
/// - OR -
/// The enumerator is already positioned after the last item
public
T
Current
{
    get
    {
        if( !this.started )
            throw new InvalidOperationException(
                _S("The current item cannot be retrieved because the enumerator is still positioned before the first item") );
        if( this.finished )
            throw new InvalidOperationException(
                _S("The current item cannot be retrieved because the enumerator is already positioned after the last item") );
        return this.current;
    }
}



// -----------------------------------------------------------------------------
// IEnumerator
// -----------------------------------------------------------------------------

/// @exception InvalidOperationException
/// The enumerator is still positioned before the first item
/// - OR -
/// The enumerator is already positioned after the last item
object
IEnumerator.Current
{
    get { return ((IEnumerator< T >)this).Current; }
}



public
bool
MoveNext()
{
    bool result = this.stream.Yield( out this.current );
    if( !this.started ) this.started = true;
    if( !result ) this.finished = true;
    return result;
}



/// @exception InvalidOperationException
/// Always, because streams are not resettable
public
void
Reset()
{
    throw new InvalidOperationException(
        _S("This enumerator cannot be reset because it is enumerating an IStream, which cannot be reset") );
}



// -----------------------------------------------------------------------------
// IDisposable
// -----------------------------------------------------------------------------

/// (see <tt>IDisposable.Dispose()</tt>)
///
/// The C# <tt>foreach</tt> statement unconditionally <tt>Dispose()</tt>s
/// enumerators after using them.  This conflicts with <tt>IStream< T ></tt>'s
/// semantics which allow it to be <tt>foreach</tt>ed more than once, so this
/// method does nothing.  If the underlying <tt>IStream< T ></tt> is
/// <tt>IDisposable</tt> it should be <tt>Dispose()</tt>d explicitly eg. via a
/// <tt>using</tt> block.
public
void
Dispose()
{
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

