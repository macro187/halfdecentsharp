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


using System;
using System.Collections.Generic;
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Exceptions;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// Base class for implementing RTypes
// =============================================================================

public abstract class
RTypeBase<
    T
>
    : IRType< T >
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Return <tt>true</tt> if <tt>null</tt> unless this RType explicitly
/// disallows <tt>null</tt>s
///
protected virtual
bool
MyCheck(
    T item
)
{
    return true;
}



// -----------------------------------------------------------------------------
// IRType< T >
// -----------------------------------------------------------------------------

public
void
Check(
    T       item,
    IValue  itemReference
)
{
    if( itemReference == null )
        throw new LocalisedArgumentNullException( "itemReference" );

    foreach( IRType< T > st in this.Supers )
        st.Check( item, itemReference );

    foreach( IRType< T > c in this.Components )
        foreach( IRType< T > cst in c.Supers )
            cst.Check( item, itemReference );

    foreach( IRType< T > c in this.Components )
        try {
            c.Check( item, itemReference );
        } catch( RTypeException rte ) {
            throw new RTypeException( itemReference, this, rte );
        }

    if( !this.MyCheck( item ) )
        throw new RTypeException( itemReference, this );
}


public virtual
IEnumerable< IRType< T > >
Supers
{
    get { return new IRType< T >[]{}; }
}


public virtual
IEnumerable< IRType< T > >
Components
{
    get { return new IRType< T >[]{}; }
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

