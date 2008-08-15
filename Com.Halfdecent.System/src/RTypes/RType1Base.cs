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
using Com.Halfdecent.Globalisation;

namespace
Com.Halfdecent.RTypes
{



// =============================================================================
/// Base class for 1-term RTypes
// =============================================================================
//
public abstract class
RType1Base
    : IRType1
{




/// Return <tt>true</tt> if <tt>null</tt> unless this RType explicitly
/// disallows <tt>null</tt>s
///
protected virtual
bool
MyCheck(
    object item
)
{
    return true;
}




// -----------------------------------------------------------------------------
// IRType1
// -----------------------------------------------------------------------------

public virtual
IEnumerable< IRType1 >
Supers
{
    get { return new IRType1[]{}; }
}



public virtual
IEnumerable< IRType1 >
Components
{
    get { return new IRType1[]{}; }
}



public
void
Check(
    object item
)
{
    foreach( IRType1 st in this.Supers )
        st.Check( item );
    foreach( IRType1 c in this.Components )
        foreach( IRType1 cst in c.Supers )
            cst.Check( item );
    foreach( IRType1 c in this.Components )
        try {
            c.Check( item );
        } catch( RTypeException rte ) {
            throw new RTypeException( this, rte );
        }
    if( !this.MyCheck( item ) )
        throw new RTypeException( this );
}



public abstract
Localised< string >
SayIs(
    Localised< string > reference
);



public abstract
Localised< string >
SayIsNot(
    Localised< string > reference
);



public abstract
Localised< string >
SayMustBe(
    Localised< string > reference
);




} // type
} // namespace

