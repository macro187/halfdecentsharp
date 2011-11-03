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


namespace
Com.Halfdecent.Meta
{


// =============================================================================
/// Reference to the part of a value at a specified index
///
/// <tt>Indexer</tt> equality involves comparison of the <tt>.Index</tt> object,
/// which is done using <tt>System.Object.Equals()</tt>.
// =============================================================================

public class
Indexer
    : Member
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
Indexer(
    object index
    ///< The index, which can be <tt>null</tt>
)
{
    this.Index = index;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
object
Index
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
    return string.Concat( "[", Literal.Format( this.Index ), "]" );
}



// -----------------------------------------------------------------------------
// IEquatable< IValueReferenceComponent >
// -----------------------------------------------------------------------------

public override
    bool
Equals(
    IValueReferenceComponent that
)
{
    return that.Is<
        Indexer >(
        i => object.Equals( i.Index, this.Index ) );
}


public override
    int
GetHashCode()
{
    return
        base.GetHashCode() ^
        ( this.Index != null ?
            this.Index.GetHashCode() :
            0 );
}




} // type
} // namespace

