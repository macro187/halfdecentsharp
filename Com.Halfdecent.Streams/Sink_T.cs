// -----------------------------------------------------------------------------
// Copyright (c) 2011
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


using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Streams
{


// =============================================================================
/// Sink implementation
// =============================================================================

public class
Sink<
    T
>
    : ISink< T >
{



// -----------------------------------------------------------------------------
// Static
// -----------------------------------------------------------------------------



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Create a sink from a pair of functions, one that determines whether a push
/// can occur, and one that does it
///
public
Sink(
    System.Func< bool > canPushFunc,
    System.Action< T >  pushFunc
)
    : this( item => {
        if( canPushFunc() ) {
            pushFunc( item );
            return true;
        } else {
            return false;
        } } )
{
    NonNull.CheckParameter( canPushFunc, "canPushFunc" );
    NonNull.CheckParameter( pushFunc, "pushFunc" );
}


/// Create a sink from a function that performs and signals the success of the
/// push
///
public
Sink(
    System.Func< T, bool > tryPushFunc
)
{
    NonNull.CheckParameter( tryPushFunc, "tryPushFunc" );
    this.TryPushFunc = tryPushFunc;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

private
System.Func< T, bool >
TryPushFunc
{
    get;
    set;
}



// -----------------------------------------------------------------------------
// ISink< T >
// -----------------------------------------------------------------------------

public
    bool
TryPush(
    T item
)
{
    return this.TryPushFunc( item );
}




} // type
} // namespace

