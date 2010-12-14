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


using Com.Halfdecent.Globalisation;


namespace
Com.Halfdecent.Meta
{


// =============================================================================
/// Reference to a machine
// =============================================================================

public class
Machine
    : IValueReferenceComponent
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialise a new machine representing the caller
///
public
Machine()
{
    this.Name = System.Net.Dns.GetHostName();
}


// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
string
Name
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// IValueReferenceComponent
// -----------------------------------------------------------------------------

public override
    string
ToString()
{
    return string.Concat( "(", this.Name, ") " );
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
    return that.IsAnd<
        Machine >(
        m => m.Name == this.Name );
}


public override
    int
GetHashCode()
{
    return
        typeof( Machine ).GetHashCode()
        ^ this.Name.GetHashCode();
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




} // type
} // namespace

