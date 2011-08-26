// -----------------------------------------------------------------------------
// Copyright (c) 2011
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


namespace
Com.Halfdecent
{


// =============================================================================
// TODO
// =============================================================================

public struct
MatchResult<
    T,
    TResult
>
    : IMaybe< TResult >
{



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

internal
MatchResult(
    T item
)
    : this( item, false, default( TResult ) )
{
}


internal
MatchResult(
    T       item,
    TResult result
)
    : this( item, true, result )
{
}


private
MatchResult(
    T       item,
    bool    matched,
    TResult result
)
{
    this.item = item;
    this.matched = matched;
    this.result = result;
}



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

public
T
Item
{
    get { return this.item; }
}

private
T
item;


public
bool
Matched
{
    get { return this.matched; }
}

private
bool
matched;


public
TResult
Result
{
    get
    {
        if( !this.Matched )
            throw new System.InvalidOperationException(
                "Hasn't .Matched, so no .Result" );
        return this.result;
    }
}

private
TResult
result;



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

public
    MatchResult< T, TResult >
When(
    System.Predicate< T >       predicate,
    System.Func< T, TResult >   resultFunc
)
{
    return this.When< T >( predicate, resultFunc );
}


public
    MatchResult< T, TResult >
When<
    TMatch
>(
    System.Predicate< TMatch >      predicate,
    System.Func< TMatch, TResult >  resultFunc
)
    where TMatch : T
{
    if( predicate == null )
        throw new System.ArgumentNullException( "predicate" );
    if( resultFunc == null )
        throw new System.ArgumentNullException( "resultFunc" );
    if( this.Matched ) return this;
    IMaybe< TMatch > m = this.Item.As< TMatch >( predicate );
    if( m.HasValue )
        return new MatchResult< T, TResult >(
            this.Item, resultFunc( m.Value ) );
    else
        return this;
}



// -----------------------------------------------------------------------------
// IMaybe< TResult >
// -----------------------------------------------------------------------------

bool
IMaybe< TResult >.HasValue
{
    get { return this.Matched; }
}


TResult
IMaybe< TResult >.Value
{
    get { return this.Result; }
}



// -----------------------------------------------------------------------------
// ITuple< bool, TResult >
// -----------------------------------------------------------------------------

bool
ITuple< bool, TResult >.A
{
    get { return this.Matched; }
}


TResult
ITuple< bool, TResult >.B
{
    get { return this.Matched ? this.Result : default( TResult ); }
}




} // type
} // namespace

