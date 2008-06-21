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




/// Predicate: "... is greater than ..."
///
public class
IsGT<
    T
>
    : PredicateBase< T >
    where T
        : IComparable< T >
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialise a new <tt>IsGT</tt> that compares against the given
/// value
///
public
IsGT(
    T comparisonValue   ///< The value to compare against
                        ///
                        ///  Requirements:
                        ///  - Really <tt>IsPresent< T ></tt>
)
{
    new IsPresent< T >().ReallyRequire( comparisonValue );
    this.comparisonvalue = comparisonValue;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// The value that this predicate compares against
///
public
T
ComparisonValue
{
    get { return this.comparisonvalue; }
}

private
T
comparisonvalue;




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
    return ( term.CompareTo( this.ComparisonValue ) > 0 );
}




// -----------------------------------------------------------------------------
// IPredicate
// -----------------------------------------------------------------------------

override public
Localized< string >
SayConforms(
    Localized< string > termIdentifier
)
{
    new IsPresent< Localized< string > >().ReallyRequire( termIdentifier );
    return _S( "{0} is greater than {1}",
        termIdentifier,
        this.ComparisonValue );
}



override public
Localized< string >
SayDoesNotConform(
    Localized< string > termIdentifier
)
{
    new IsPresent< Localized< string > >().ReallyRequire( termIdentifier );
    return _S( "{0} is not greater than {1}",
        termIdentifier,
        this.ComparisonValue );
}



override public
Localized< string >
SayRequirement(
    Localized< string > termIdentifier
)
{
    new IsPresent< Localized< string > >().ReallyRequire( termIdentifier );
    return _S( "{0} must be greater than {1}",
        termIdentifier,
        this.ComparisonValue );
}




private static Com.Halfdecent.Globalization.Localized< string > _S( string s, params object[] args ) { return Com.Halfdecent.Resources.Resource._S( global::System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

