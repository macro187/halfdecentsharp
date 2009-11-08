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


using System;
using System.Collections.Generic;
using Com.Halfdecent.SystemUtils;
using Com.Halfdecent.Globalisation;
using Com.Halfdecent.Exceptions;
using Com.Halfdecent.Meta;


namespace
Com.Halfdecent.RTypes
{


// =============================================================================
/// Abstract base class for implementing RTypes
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

/// Overridable equality checker
///
/// Subtypes with value parameters should take them into account by overriding
/// this.
///
protected virtual
bool
Equals(
    IRType t
    ///< RType to compare against
    ///  - Will never be <tt>null</tt>
    ///  - Will always be the exact same run-time .NET type as <tt>this</tt>
)
{
    return true;
}



// -----------------------------------------------------------------------------
// IRType< T >
// -----------------------------------------------------------------------------

public virtual
IEnumerable< IRType< T > >
Components
{
    get { yield break; }
}


public virtual
bool
Predicate(
    T item
)
{
    return true;
}



// -----------------------------------------------------------------------------
// IRType
// -----------------------------------------------------------------------------

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



// -----------------------------------------------------------------------------
// Object
// -----------------------------------------------------------------------------

/// <tt>.Equals( object )</tt>
///
/// Subtypes with value parameters should take them into account by overriding
/// <tt>.Equals( IRType )</tt>, not this.
///
public sealed override
bool
Equals(
    object obj
)
{
    if( obj is IRTypeContravariantAdapter )
        obj = ((IRTypeContravariantAdapter)obj).From;
    if( base.Equals( obj ) ) return true;
    if( obj == null ) return false;
    if( this.GetType() != obj.GetType() ) return false;
    return this.Equals( (IRType)obj );
}


/// <tt>.GetHashCode()</tt>
///
/// Subtypes with value parameters should take them into account by overriding
/// this.
///
public override
int
GetHashCode()
{
    return this.GetType().GetHashCode();
}




//private static Com.Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

