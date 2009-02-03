// -----------------------------------------------------------------------------
// Copyright (c) 2009
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


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// Base class for implementing
/// <tt>System.Collections.Generic.IEnumerable< T ></tt> (and, as a corollary,
/// <tt>System.Collections.IEnumerable</tt>)
// =============================================================================
//
public abstract class
EnumeratorBase<
    T
>
    : IEnumerator< T >
{



// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private
bool
started;


private
bool
finished;



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Simplified <tt>MoveNext()</tt> implementation
///
/// Override to implementations can call this default implementation when there are
/// no more items.  Once this method returns <tt>false</tt>, it will never be
/// called again.
protected virtual
bool
/// @returns Whether there was another item
MoveNext(
    out T nextItem
    ///< The next item
    /// - OR -
    ///  If there wasn't another item, an undefined value that will never be
    ///  used
)
{
    nextItem = default( T );
    return false;
}



// -----------------------------------------------------------------------------
// IEnumerator< T >
// -----------------------------------------------------------------------------

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

private
T
current;



// -----------------------------------------------------------------------------
// IEnumerator
// -----------------------------------------------------------------------------

object
IEnumerator.Current
{
    get { return ((IEnumerator< T >)this).Current; }
}


public
bool
MoveNext()
{
    if( this.finished ) return false;
    bool r = this.MoveNext( out this.current );
    if( !this.started ) this.started = true;
    if( !r ) this.finished = true;
    return r;
}


/// (see <tt>IEnumerable.Reset()</tt>
///
/// The default implementation always throws an exception, implementing a
/// non-resettable enumerator.  Override to make a resettable enumerator.
///
/// @exception InvalidOperationException
/// Always
public virtual
void
Reset()
{
    throw new InvalidOperationException(
        _S("This enumerator is not resettable") );
}



// -----------------------------------------------------------------------------
// IDisposable
// -----------------------------------------------------------------------------

/// (see <tt>IDisposable.Dispose()</tt>)
///
/// The default implementation does nothing.  Override if appropriate.  Note
/// that enumerators are unconditionally <tt>Dispose()</tt>d after being
/// iterated by the C# <tt>foreach</tt> statement.
public virtual
void
Dispose()
{
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

