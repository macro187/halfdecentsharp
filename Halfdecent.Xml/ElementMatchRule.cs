// -----------------------------------------------------------------------------
// Copyright (c) 2012
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
using System.Linq;
using System.Xml.Linq;


namespace
Halfdecent.Xml
{


// =============================================================================
/// A rule explaining, for certain elements in an XML tree, how to match the
/// "same" element in another
// =============================================================================

public class
ElementMatchRule
{



// -----------------------------------------------------------------------------
// Factory Methods
// -----------------------------------------------------------------------------

/// Create a new element match rule that matches by element name
///
public static
    ElementMatchRule
ByName(
    Func< XElement, IEnumerable< XElement > > appliesToFunc
)
{
    return ByFunction(
        appliesToFunc,
        (e1,e2) => e2.Name == e1.Name );
}


/// Create a new element match rule that matches by element name plus the
/// values of one or more attributes
///
public static
    ElementMatchRule
ByNameAndAttributes(
    Func< XElement, IEnumerable< XElement > >   appliesToFunc,
    params string[]                             attributeNames
)
{
    attributeNames = attributeNames ?? new string[]{};
    return ByFunction(
        appliesToFunc,
        (e1,e2) =>
            e2.Name == e1.Name &&
            attributeNames.All( n =>
                (string)( e2.Attribute( n ) ) ==
                (string)( e1.Attribute( n ) ) ) );
}


/// Create a new rule that matches using a match function
///
public static
    ElementMatchRule
ByFunction(
    Func< XElement, IEnumerable< XElement > >   appliesToFunc,
    Func< XElement, XElement, bool >            matchFunc
)
{
    return new ElementMatchRule( appliesToFunc, matchFunc );
}



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

private
ElementMatchRule(
    Func< XElement, IEnumerable< XElement > >   appliesToFunc,
    Func< XElement, XElement, bool >            matchFunc
)
{
    if( appliesToFunc == null )
        throw new ArgumentNullException( "appliesToFunc" );
    if( matchFunc == null )
        throw new ArgumentNullException( "matchFunc" );
    this.AppliesToFunc = appliesToFunc;
    this.MatchFunc = matchFunc;
}



// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private
Func< XElement, IEnumerable< XElement > >
AppliesToFunc;


private
Func< XElement, XElement, bool >
MatchFunc;



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Given the root element of an XML tree, lists the elements this rule applies
/// to
///
public
    IEnumerable< XElement >
AppliesTo(
    XElement root
)
{
    if( root == null )
        throw new ArgumentNullException( "root" );
    return this.AppliesToFunc( root );
}


/// Indicate whether two elements are the "same" according to the rule
///
public
    bool
Match(
    XElement e1,
    XElement e2
)
{
    if( e1 == null )
        throw new ArgumentNullException( "e1" );
    if( e2 == null )
        throw new ArgumentNullException( "e2" );
    return MatchFunc( e1, e2 );
}




} // type
} // namespace

