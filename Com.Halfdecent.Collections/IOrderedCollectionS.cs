// -----------------------------------------------------------------------------
// Copyright (c) 2009, 2010
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


namespace
Com.Halfdecent.Collections
{


// =============================================================================
/// TODO
// =============================================================================

public partial interface
IOrderedCollectionS
    : IOrderedCollection
    , IUniqueKeyedCollectionS< IInteger >
{



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionS.Proxy
// -----------------------------------------------------------------------------

public void RemoveAll( IInteger key ) { this.From.RemoveAll( key ); }

public void Remove( IInteger key ) { this.From.Remove( key ); }
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionS.IndexSlice
// -----------------------------------------------------------------------------

public
    void
Remove(
    IInteger key
)
{
    new NonNull().Require( key, new Parameter( "key" ) );
    new GTE< IInteger >(
        Integer.From( 0 ),
#if DOTNET40
        new ComparableComparer< IReal >() )
#else
        new ComparableComparer< IReal >().Contravary< IReal, IInteger >() )
#endif
            .Require( key, new Parameter( "key" ) );
    new LTE< IInteger >(
        this.Count,
#if DOTNET40
        new ComparableComparer< IReal >() )
#else
        new ComparableComparer< IReal >().Contravary< IReal, IInteger >() )
#endif
            .Require( key, new Parameter( "key" ) );
    this.From.Remove( this.Trans( key ) );
    this.SliceCount = this.SliceCount.Minus( Integer.From( 1 ) );
}


public void RemoveAll( IInteger key ) { this.Remove( key ); }
#endif




} // type
} // namespace

