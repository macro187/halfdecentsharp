// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010
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


using System.Collections;
using System.Collections.Generic;
using Com.Halfdecent.Globalisation;


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// Base class for implementing non-resettable enumerators
// =============================================================================

internal abstract class
SystemEnumeratorBase<
    T
>
    : IEnumerator< T >
{



// -----------------------------------------------------------------------------
// Properties
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
// Methods
// -----------------------------------------------------------------------------

/// Simplified enumerator implementation
///
/// Once this method returns <tt>false</tt>, it will never be called again.
///
protected virtual
    bool
    /// @returns
    /// Whether there was another item
MoveNext(
    out T nextItem
    ///< The next item
    ///  - OR -
    ///  An undefined value that will never be used, if there wasn't another
    ///  item
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
            throw new LocalisedInvalidOperationException(
                _S("The current item cannot be retrieved because the enumerator is still positioned before the first item") );
        if( this.finished )
            throw new LocalisedInvalidOperationException(
                _S("The current item cannot be retrieved because the enumerator is already positioned after the last item") );
        return this.current;
    }
}



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


/// (see <tt>System.Collections.IEnumerable.Reset()</tt>)
///
/// @exception InvalidOperationException
/// Always
public
    void
Reset()
{
    throw new LocalisedInvalidOperationException(
        _S("This enumerator is not resettable") );
}



// -----------------------------------------------------------------------------
// IDisposable
// -----------------------------------------------------------------------------

/// (see <tt>System.IDisposable.Dispose()</tt>)
///
/// The default implementation does nothing.  Override if appropriate.  Note
/// that enumerators are unconditionally <tt>Dispose()</tt>d after being
/// iterated by the C# <tt>foreach</tt> statement.
///
public virtual
    void
Dispose()
{
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

