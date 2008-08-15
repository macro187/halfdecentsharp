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
using Com.Halfdecent.Globalisation;

namespace
Com.Halfdecent.Predicates
{



// =============================================================================
/// Base class for implementing <tt>IPredicate< T ></tt>
///
/// Logic implementing the predicate can be specified...
/// - Declaratively, by providing <tt>components</tt> to the constructor
/// - Programmatically, by overriding <tt>MyEvaluate()</tt>
/// ...or a combination of the two.
///
/// Term requirements are inherited from components.  Additional requirements
/// can be specified...
/// - Declaratively, by providing <tt>termRequirements</tt> to the constructor
/// - Programmatically, by overriding <tt>MyRequirements()</tt>
/// ...or a combination of the two.
///
/// Natural language sentences ("true of", "false of", and "required") must be
/// provided to the constructor.  Implementations requiring finer control can
/// provide empty strings and override the appropriate <tt>Say*</tt> methods.
// =============================================================================
///
public abstract class
PredicateBase<
    T
>
    : IPredicate< T >
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

protected
PredicateBase(
    Localised< string >             trueSentence,
    ///< Natural language sentence stating that the predicate is true of a
    ///  term, where <tt>{0}</tt> is a reference to the term.
    Localised< string >             falseSentence,
    ///< Natural language sentence stating that the predicate is false of a
    ///  term, where <tt>{0}</tt> is a reference to the term.
    Localised< string >             requiredSentence,
    ///< Natural language sentence stating that the predicate is required of a
    ///  term, where <tt>{0}</tt> is a reference to the term.
    IEnumerable< IPredicate< T > >  components,
    ///< Optional
    IEnumerable< IPredicate< T > >  termRequirements
    ///< Optional
)
{
    if( trueSentence == null )
        throw new ArgumentNullException( "trueSentence" );
    if( falseSentence == null )
        throw new ArgumentNullException( "falseSentence" );
    if( requiredSentence == null )
        throw new ArgumentNullException( "requiredSentence" );
    this.truesentence = trueSentence;
    this.falsesentence = falseSentence;
    this.requiredsentence = requiredSentence;
    this.components = components;
    this.termrequirements = termRequirements;
}




// -----------------------------------------------------------------------------
// Protected (Overridable)
// -----------------------------------------------------------------------------

/// Hard-coded term requirements
///
/// Checked after any predicates from <tt>GetTermRequirements()</tt>.
/// Throw appropriate <tt>ValueException</tt>s if terms fail.
///
/// @Exception ValueException
/// The term did not meet a requirement
///
protected virtual
void
MyTermRequirements(
    T term
)
{
}



/// Hard-coded evaluation
///
/// Evaluated after any components from <tt>GetComponents()</tt> have evaluated
/// <tt>true</tt>
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
// IPredicate< T >
// -----------------------------------------------------------------------------

public
bool
Evaluate(
    T term
)
{
    this.RequireTermRequirements( term );
    if( this.components != null )
        foreach( IPredicate< T > c in this.components )
            if( !c.Evaluate( term ) ) return false;
    return this.MyEvaluate( term );
}



public
void
Require(
    T term
)
{
    this.RequireTermRequirements( term );
    if( this.components != null )
        try {
            foreach( IPredicate< T > c in this.components )
                c.Require( term );
        } catch( ValueException ve ) {
            throw new PredicateValueException( this, ve );
        }
    if( !this.MyEvaluate( term ) )
        throw new PredicateValueException( this );
}



private
void
RequireTermRequirements(
    T term
)
{
    try {
        if( this.components != null )
            foreach( IPredicate< T > c in this.components )
                c.RequireTermRequirements( term );
        if( this.termrequirements != null )
            foreach( IPredicate< T > tr in this.termrequirements )
                tr.Require( term );
        this.MyTermRequirements( term );
    } catch( ValueException ve ) {
        throw new BugException( ve );
    }
}



public virtual
Localised< string >
SayTrueOf(
    Localised< string > termIdentifier
)
{
    if( termIdentifier == null )
        throw new ArgumentNullException( "termIdentifier" );
    return LocalisedString.Format( this.truesentence, termIdentifier );
}



public virtual
Localised< string >
SayFalseOf(
    Localised< string > termIdentifier
)
{
    if( termIdentifier == null )
        throw new ArgumentNullException( "termIdentifier" );
    return LocalisedString.Format( this.falsesentence, termIdentifier );
}



public virtual
Localised< string >
SayRequiredOf(
    Localised< string > termIdentifier
)
{
    if( termIdentifier == null )
        throw new ArgumentNullException( "termIdentifier" );
    return LocalisedString.Format( this.requiredsentence, termIdentifier );
}




// -----------------------------------------------------------------------------
// Privates
// -----------------------------------------------------------------------------

private
IEnumerable< IPredicate< T > >
termrequirements;



private
IEnumerable< IPredicate< T > >
components;



private
Localised< string >
truesentence;



private
Localised< string >
falsesentence;



private
Localised< string >
requiredsentence;




} // type
} // namespace

