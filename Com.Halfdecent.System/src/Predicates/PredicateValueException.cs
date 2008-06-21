// -----------------------------------------------------------------------------
// Copyright (c) 2007 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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
using Com.Halfdecent.System;
using Com.Halfdecent.Globalization;


namespace
Com.Halfdecent.Predicates
{




/// A <tt>ValueException</tt> resulting from a value failing to conform to a
/// predicate
///
public class
PredicateValueException
    : ValueException
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// Initialise a new <tt>PredicateValueException</tt> resulting from a value
/// failing to conform to a given <tt>IPredicate</tt>
///
public
PredicateValueException(
    IPredicate  predicate   ///< Predicate that was failed
                            ///
                            ///  Requirements:
                            ///  - Really <tt>IsPresent< T ></tt>
)
    : this( predicate, null )
{
}



/// Initialise a new <tt>PredicateValueException</tt> resulting from some value
/// failing to conform to a given <tt>IPredicate</tt>, and reference to the
/// inner <tt>Exception</tt> that is the cause of this exception.
///
public
PredicateValueException(
    IPredicate  predicate,      ///< Predicate that was failed
                                ///
                                ///  Requirements:
                                ///  - Really <tt>IsPresent< T ></tt>
    Exception   innerException  ///< Exception indicating the underlying cause
                                ///  of this one
)
    : base( innerException )
{
    new IsPresent< IPredicate >().ReallyRequire( predicate );
    this.predicate = predicate;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// The <tt>IPredicate</tt> that the value failed to conform to which lead to
/// this exception
///
public
IPredicate
Predicate
{
    get { return this.predicate; }
}

private
IPredicate
predicate;




// -----------------------------------------------------------------------------
// ValueException
// -----------------------------------------------------------------------------

override public
Localized< string >
SayProblem(
    Localized< string > valueIdentifier
)
{
    new IsPresent< Localized< string > >().ReallyRequire( valueIdentifier );
    return this.Predicate.SayDoesNotConform( valueIdentifier );
}




} // type
} // namespace

