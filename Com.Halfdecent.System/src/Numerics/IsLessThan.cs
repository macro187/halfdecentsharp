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
using Com.Halfdecent.Predicates;
using Com.Halfdecent.Globalization;
using Com.Halfdecent.Resources;


namespace
Com.Halfdecent.Numerics
{




/// Predicate: "... is less than ..."
///
public class
IsLessThan<
    T
>
    : PredicateBase< T >
    where T : IComparable< T >
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialise a new <tt>IsLessThan</tt> that compares against the given
/// value
///
public
IsLessThan(
    T lessThanValue ///< The value to compare against
                    ///
                    ///  Requirements:
                    ///  - Really IsPresent
)
{
    new IsPresent< T >().ReallyRequire( lessThanValue );
    this.lessthanvalue = lessThanValue;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// The value that this predicate compares against
///
public
T
LessThanValue
{
    get { return this.lessthanvalue; }
}

private
T
lessthanvalue;




// -----------------------------------------------------------------------------
// PredicateBase< T >
// -----------------------------------------------------------------------------

override internal
IEnumerable< IPredicate< T > >
GetTermRequirements()
{
    yield return new IsPresent< T >();
}



override internal
bool
Test(
    T term
)
{
    return ( term.CompareTo( this.LessThanValue ) < 0 );
}




// -----------------------------------------------------------------------------
// IPredicate
// -----------------------------------------------------------------------------

/// (see <tt>IPredicate.SayConforms()</tt>)
///
override public
Localized< string >
SayConforms(
    Localized< string > termIdentifier
)
{
    new IsPresent< Localized< string > >().ReallyRequire( termIdentifier );
    return Resource._S( "{0} is less than {1}",
        termIdentifier,
        this.LessThanValue );
}



/// (see <tt>IPredicate.SayDoesNotConform()</tt>)
///
override public
Localized< string >
SayDoesNotConform(
    Localized< string > termIdentifier
)
{
    new IsPresent< Localized< string > >().ReallyRequire( termIdentifier );
    return Resource._S( "{0} is not less than {1}",
        termIdentifier,
        this.LessThanValue );
}



/// (see <tt>IPredicate.SayRequirement()</tt>)
///
override public
Localized< string >
SayRequirement(
    Localized< string > termIdentifier
)
{
    new IsPresent< Localized< string > >().ReallyRequire( termIdentifier );
    return Resource._S( "{0} must be less than {1}",
        termIdentifier,
        this.LessThanValue );
}




} // type
} // namespace

