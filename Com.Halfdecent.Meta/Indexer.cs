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


using Com.Halfdecent;
using Com.Halfdecent.Exceptions;


namespace
Com.Halfdecent.Meta
{


// =============================================================================
/// An item accessed through an indexer
// =============================================================================

public class
Indexer
    : MemberBase
{



internal
Indexer(
    IValue parent,
    object index
)
    : base( parent )
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
// MemberBase
// -----------------------------------------------------------------------------


protected override
string
ComponentToString()
{
    return string.Concat( "[", Value.FormatLiteral( this.Index ), "]" );
}


protected override
bool
ComponentEquals(
    IMember item
)
{
    return object.Equals( ((Indexer)item).Index, this.Index );
}


protected override
int
ComponentGetHashCode()
{
    if( this.Index == null ) return 0;
    return this.Index.GetHashCode();
}




} // type
} // namespace

