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
using Com.Halfdecent.Globalization;
using Com.Halfdecent.Resources;


namespace
Com.Halfdecent.Predicates
{




/// Predicate: "is of the runtime type T"
///
public class
IsAPredicate<
    T ///< The runtime type the predicate checks for
>
    : Predicate
{



/// (see Predicate.Evaluate())
public
bool
Evaluate<
    TTerm
>(
    TTerm term
)
{
    return (term is T);
}



/// (see Predicate.TrueDescription)
public
Localized< string >
TrueDescription
{
    get { return Resource._S( "is a {0}", typeof(T).FullName ); }
}



/// (see Predicate.FalseDescription)
public
Localized< string >
FalseDescription
{
    get { return Resource._S( "is not a {0}", typeof(T).FullName ); }
}



/// (see Predicate.Demand)
public
Localized< string >
Demand
{
    get { return Resource._S( "must be a {0}", typeof(T).FullName ); }
}




} // type
} // namespace

