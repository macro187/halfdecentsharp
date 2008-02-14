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
using Com.Halfdecent.System;


namespace
Com.Halfdecent.Streams
{




/// Base class for implementing <tt>IFiniteStreamFilter< TIn, TOut ></tt>s
///
public abstract class
FiniteStreamFilterBase<
    TIn,    ///< (See <tt>IFiniteStreamFilter< TIn, TOut ></tt>)
    TOut    ///< (See <tt>IFiniteStreamFilter< TIn, TOut ></tt>)
>
    : FiniteStreamBase< TOut >
    , IFiniteStreamFilter< TIn, TOut >
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
FiniteStreamFilterBase(
    IFiniteStream< TIn > input  ///< The input stream
                                ///  Requirements:
                                ///  - Really <tt>IsPresent</tt>
)
    : base()
{
    new IsPresent().ReallyRequire( input );
    this.input = input;
}




// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private
IFiniteStream< TIn >
input;




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Filter an item
///
abstract protected
bool                    /// @returns Whether to let the item through the filter
Filter(
    TIn         iin,    ///< The item to check
    out TOut    iout    ///< The item as it should be output
);



/// (see <tt>IFiniteStream< T >.Yield()</tt>)
///
public override
bool
Yield(
    out TOut item
)
{
    bool result = false;
    item = default( TOut );
    TIn nextin;
    TOut nextout;
    while( this.input.Yield( out nextin ) ) {
        if( this.Filter( nextin, out nextout ) ) {
            result = true;
            item = nextout;
            break;
        }
    }
    return result;
}




} // type
} // namespace

