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


using SCG = System.Collections.Generic;


namespace
Com.Halfdecent
{


// =============================================================================
/// An equality comparer that compares strictly by object reference
///
/// <tt>System.Object.ReferenceEquals()</tt> is used interally to do reference
/// equality ignoring any <tt>System.Object.Equals()</tt> overrides.  There is
/// no equivalent mechanism for <tt>GetHashCode()</tt>, so hash codes produced
/// by this comparer shouldn't be trusted.
// =============================================================================

public struct
ReferenceComparer
    : IEqualityComparer< object >
{



// -----------------------------------------------------------------------------
// System.Collections.Generic.IEqualityComparer< object >
// -----------------------------------------------------------------------------

public new
    bool
Equals(
    object item,
    object anotherItem
)
{

    return object.ReferenceEquals( item, anotherItem );
}


public
    int
GetHashCode(
    object item
)
{
    if( item == null )
        throw new System.ArgumentNullException( "item" );
    return item.GetHashCode();
}



// -----------------------------------------------------------------------------
// IEquatable< IEqualityComparer >
// -----------------------------------------------------------------------------

public
    bool
Equals(
    IEqualityComparer that
)
{
    return Equatable.Equals( this, that );
}


public
    bool
DirectionalEquals(
    IEqualityComparer that
)
{
    return that.Is< ReferenceComparer >();
}


public override
    int
GetHashCode()
{
    return typeof( ReferenceComparer ).GetHashCode();
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

