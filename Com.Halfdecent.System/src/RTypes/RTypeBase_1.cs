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

using System.Collections.Generic;

namespace
Com.Halfdecent.RTypes
{



// =============================================================================
/// Base class for 1-term RTypes with single IsA supertypes
// =============================================================================
//
public abstract class
RTypeBase<
    TIsA
>
    : RType1Base
{




/// Return <tt>true</tt> if <tt>null</tt> unless this RType explicitly
/// disallows <tt>null</tt>s
///
protected abstract
bool
MyCheck(
    TIsA item
);




// -----------------------------------------------------------------------------
// RType1Base
// -----------------------------------------------------------------------------

protected override
bool
MyCheck(
    object item
)
{
    // TODO Check is TIsA to verify subclass yielded base.Supers in Supers?
    return this.MyCheck( (TIsA)item );
}



public override
IEnumerable< IRType1 >
Supers
{
    get
    {
        foreach( IRType1 super in base.Supers ) yield return super;
        yield return new IsA< TIsA >();
    }
}




} // type
} // namespace

