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
using Com.Halfdecent.System;
using Com.Halfdecent.Globalization;


namespace
Com.Halfdecent.Predicates
{




/// Predicate base class
///
public abstract class
PredicateBase<
    T
>
    : IPredicate< T >
{




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Term requirements
///
/// (See <tt>Predicates</tt>)
///
internal virtual
IEnumerable< IPredicate< T > >
GetTermRequirements()
{
    yield break;
}



/// Components
///
/// (See <tt>Predicates</tt>)
///
internal virtual
IEnumerable< IPredicate< T > >
GetComponents()
{
    yield break;
}



/// The predicate's underlying logical test
///
/// Only terms that have already been subjected to term requirements and
/// component predicates will get this far, so implementers can assume they've
/// all been met.
///
/// If a predicate's logic is fully implemented by component predicates,
/// implementers need not override this.
///
internal virtual
bool
Test(
    T term
)
{
    return true;
}




// -----------------------------------------------------------------------------
// IPredicate< T >
// -----------------------------------------------------------------------------

/// (see IPredicate< T >.Evaluate())
public
bool
Evaluate(
    T term
)
{
    bool result = false;
    bool done = false;

    // Enforce term requirements
    foreach( IPredicate< T > tr in this.GetTermRequirements() ) {
        tr.ReallyRequire( term );
    }

    // Run components
    foreach( IPredicate< T > c in this.GetComponents() ) {
        if( !c.Evaluate( term ) ) {
            result = false;
            done = true;
            break;
        }
    }

    // Run Test()
    if( !done ) {
        result = this.Test( term );
    }

    return result;
}



/// (see IPredicate< T >.Require())
public
void
Require(
    T term
)
{
    // Enforce term requirements
    foreach( IPredicate< T > tr in this.GetTermRequirements() ) {
        tr.ReallyRequire( term );
    }

    // Require components, wrapping ValueExceptions if encountered
    try {
        foreach( IPredicate< T > c in this.GetComponents() ) {
            c.Require( term );
        }
    } catch( ValueException e ) {
        throw new PredicateValueException( this, e );
    }

    // Check Test(), throwing ValueException if failed
    if( !this.Test( term ) ) {
        throw new PredicateValueException( this );
    }
}



/// (see IPredicate< T >.ReallyRequire())
public
void
ReallyRequire(
    T term
)
{
    try {
        this.Require( term );
    } catch( ValueException e ) {
        throw new BugException( e.Message, e );
    }
}




// -----------------------------------------------------------------------------
// IPredicate
// -----------------------------------------------------------------------------

/// (see IPredicate.SayConforms())
abstract public
Localized< string >
SayConforms(
    Localized< string > termIdentifier
);



/// (see IPredicate.SayDoesNotConform())
abstract public
Localized< string >
SayDoesNotConform(
    Localized< string > termIdentifier
);



/// (see IPredicate.SayRequirement)
abstract public
Localized< string >
SayRequirement(
    Localized< string > termIdentifier
);




} // type
} // namespace

