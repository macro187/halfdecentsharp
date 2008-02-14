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
using Com.Halfdecent.Predicates;
using Com.Halfdecent.Globalization;
using Com.Halfdecent.Resources;


namespace
Com.Halfdecent.System
{




/// Predicate: "(object) is of the runtime type (T)"
///
public class
IsA<
    T,      ///< (See <tt>IPredicate< T ></tt>)
    U       ///< The runtime type the predicate checks for
>
    : PredicateBase< T >
{




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
    return (term is U);
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
    return Resource._S( "{0} is a {1}", termIdentifier, typeof(U).FullName );
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
    return Resource._S( "{0} is not a {1}", termIdentifier, typeof(U).FullName );
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
    return Resource._S( "{0} must be a {1}", termIdentifier, typeof(U).FullName );
}




} // type
} // namespace

