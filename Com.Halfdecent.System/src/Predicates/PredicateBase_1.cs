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
using Com.Halfdecent.Globalization;

namespace
Com.Halfdecent.Predicates
{



/// Base class for implementing <tt>IPredicate< T ></tt>
///
public abstract class
PredicateBase<
    T
>
    : IPredicate< T >
{




// -----------------------------------------------------------------------------
// Protected (Overridable)
// -----------------------------------------------------------------------------

/// Prerequisite predicates
///
protected virtual
IEnumerable< IPredicate< T > >
GetPrerequisites()
{
    yield break;
}



/// Hard-coded prerequisite checks
///
/// Run after prerequisite predicates from <tt>GetPrerequisites</tt>.  Throw
/// an appropriate <tt>ValueException</tt> if the term fails.
///
/// @Exception ValueException
/// The term did not pass a hard-coded prerequisite check
///
protected virtual
void
MyRequirePrerequisites(
    T term
)
{
}



/// Component predicates
///
protected virtual
IEnumerable< IPredicate< T > >
GetComponents()
{
    yield break;
}



/// Hard-coded evaluation
///
/// Evaluated only after all components have evaluated <tt>true</tt>
///
protected virtual
bool
MyEvaluate(
    T term
)
{
    return true;
}




// -----------------------------------------------------------------------------
// Protected
// -----------------------------------------------------------------------------

protected
void
RequirePrerequisites(
    T term
)
{
    foreach( Predicate< T > pr in GetPrerequisites() )
        pr.Require( term );
    foreach( Predicate< T > c in GetComponents() )
        c.RequirePrerequisites( term );
    this.MyRequirePrerequisites( term );
}




// -----------------------------------------------------------------------------
// IPredicate< T >
// -----------------------------------------------------------------------------

public
bool
Evaluate(
    T term
)
{
    this.RequirePrerequisites( term );
    foreach( Predicate< T > c in this.GetComponents() )
        if( !c.Evaluate( term ) ) return false;
    return this.MyEvaluate( term );
}



public
void
Require(
    T term
)
{
    this.RequirePrerequisites( term );
    try {
        foreach( Predicate< T > c in GetComponents() )
            c.Require( term );
    } catch( ValueException ve ) {
        throw new PredicateValueException( this, ve );
    }
    if( !this.MyEvaluate( term ) )
        throw new PredicateValueException( this );
}



abstract public
Localized< string >
SayIsTrueOf(
    Localized< string > termIdentifier
);



abstract public
Localized< string >
SayIsFalseOf(
    Localized< string > termIdentifier
);



abstract public
Localized< string >
SayIsRequiredOf(
    Localized< string > termIdentifier
);




} // type
} // namespace

