// -----------------------------------------------------------------------------
// Copyright (c) 2010
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


using System.Diagnostics;
using Com.Halfdecent.Globalisation;


namespace
Com.Halfdecent.Meta
{


// =============================================================================
/// The frame at a particular depth in the current execution stack
///
/// Note that frames are only meaningful:
/// -   Within a single thread
/// -   Until such time as the stack has ascended and then re-descended to the
///     same or a deeper level, at which point the past and present frames at
///     the same level cannot be distinguished
///
/// NOTE: Inlining by the compiler or the runtime breaks the frame mechanism
/// because it relies on <tt>System.Diagnostics.StackTrace</tt>.
// =============================================================================

public class
Frame
    : IValueReferenceComponent
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialise a new Frame representing the caller
///
public
Frame()
    : this( new StackTrace( 1 ).FrameCount )
{
}


private
Frame(
    int depth
)
{
    this.Depth = depth;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
int
Depth
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Produce the next lower frame
///
public
Frame
Down()
{
    return new Frame( this.Depth + 1 );
}


/// Produce the next higher frame
///
public
Frame
Up()
{
    if( this.Depth == 0 )
        throw new LocalisedInvalidOperationException(
            _S( "No higher frames because this one is the top" ) );
    return new Frame( this.Depth - 1 );
}


/// Produce a value reference to a parameter on this frame of this thread of
/// this process on this machine
///
public
    ValueReference
Parameter(
    string name
)
{
    return new ValueReference(
        SystemEnumerable.Create<
            IValueReferenceComponent >(
            new Machine(),
            new Process(),
            new Thread(),
            this,
            new Parameter( name ) ) );
}


/// Produce a value reference to a local variable on this frame of this thread
/// of this process on this machine
///
public
    ValueReference
Local(
    string name
)
{
    return new ValueReference(
        SystemEnumerable.Create<
            IValueReferenceComponent >(
            new Machine(),
            new Process(),
            new Thread(),
            this,
            new Parameter( name ) ) );
}


/// Produce a value reference to the 'this' parameter on this frame of this
/// thread of this process on this machine
///
public
    ValueReference
This()
{
    return new ValueReference(
        SystemEnumerable.Create<
            IValueReferenceComponent >(
            new Machine(),
            new Process(),
            new Thread(),
            this,
            new This() ) );
}



// -----------------------------------------------------------------------------
// IValueReferenceComponent
// -----------------------------------------------------------------------------

public override
    string
ToString()
{
    return string.Concat( "(Frame ", this.Depth.ToString(), ") " );
}



// -----------------------------------------------------------------------------
// IEquatable< IValueReferenceComponent >
// -----------------------------------------------------------------------------

public
    bool
Equals(
    IValueReferenceComponent that
)
{
    return Equatable.Equals< IValueReferenceComponent >( this, that );
}


public virtual
    bool
DirectionalEquals(
    IValueReferenceComponent that
)
{
    if( object.ReferenceEquals( that, null ) ) return false;
    return
        that is Frame
        && ((Frame)that).Depth == this.Depth;
}


public override
    int
GetHashCode()
{
    return
        this.GetType().GetHashCode()
        ^ this.Depth;
}



// -----------------------------------------------------------------------------
// System.Object
// -----------------------------------------------------------------------------

public override
    bool
Equals(
    object that
)
{
    throw new System.NotSupportedException();
}




private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

