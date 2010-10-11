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
IOrderedCollectionC<
#if DOTNET40
    in T
#else
    T
#endif
>
    : IOrderedCollection
    , IUniqueKeyedCollectionC< IInteger, T >
{



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionC< T >.Proxy
// -----------------------------------------------------------------------------

public void Replace( IInteger key, T replacement ) {
    this.From.Replace( key, replacement ); }
#endif



#if TRAITOR
// -----------------------------------------------------------------------------
// Trait IOrderedCollectionC< T >.IndexSlice
// -----------------------------------------------------------------------------

public
    void
Replace(
    IInteger    key,
    T           replacement
)
{
    NonNull.Require( key, new Parameter( "key" ) );
    GTE.Require< IReal >( Integer.From( 0 ), key, new Parameter( "key" ) );
    LTE.Require< IReal >( this.Count, key, new Parameter( "key" ) );
    this.From.Replace( this.Trans( key ), replacement );
}
#endif




} // type
} // namespace

