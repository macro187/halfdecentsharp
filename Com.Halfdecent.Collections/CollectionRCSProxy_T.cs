// -----------------------------------------------------------------------------
// Copyright (c) 2010
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


using Com.Halfdecent.Meta;
using Com.Halfdecent.RTypes;
using Com.Halfdecent.Numerics;
using Com.Halfdecent.Streams;
using System;


namespace
Com.Halfdecent.Collections
{


public class
CollectionRCSProxy<
    T
>
    : ICollectionRCS< T >
{



public
CollectionRCSProxy(
    ICollectionRCS< T > from
)
{
    new NonNull().Require( from, new Parameter( "from" ) );
    this.From = from;
}


protected
    ICollectionRCS< T >
From
{
    get;
    private set;
}



// -----------------------------------------------------------------------------
// ICollection
// -----------------------------------------------------------------------------

public IInteger Count { get { return this.From.Count; } }



// -----------------------------------------------------------------------------
// ICollectionR< T >
// -----------------------------------------------------------------------------

public IStream< T > Stream() { return this.From.Stream(); }



// -----------------------------------------------------------------------------
// ICollectionRC< T >
// -----------------------------------------------------------------------------

public IFilter< T, T > GetAndReplaceWhere( Predicate< T > where ) { return this.From.GetAndReplaceWhere( where ); }



// -----------------------------------------------------------------------------
// ICollectionRS< T >
// -----------------------------------------------------------------------------

public IStream< T > GetAndRemoveWhere( Predicate< T > where ) { return this.From.GetAndRemoveWhere( where ); }




} // type
} // namespace

