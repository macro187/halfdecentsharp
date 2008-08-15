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




/// An <tt>IFiniteStreamFilter< TIn, TOut ></tt> that only passes items of a
/// certain runtime type
///
public class
TypeFiniteStreamFilter<
    TIn,    ///< (See <tt>IFiniteStreamFilter< TIn, TOut ></tt>)
    TSought ///< The type of items to pass through
>
    : FiniteStreamFilterBase< TIn, TSought >
    where TSought : TIn
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
TypeFiniteStreamFilter(
    IFiniteStream< TIn > input  ///< The input stream
                                ///  Requirements:
                                ///  - Really <tt>IsPresent</tt>
)
    : base( input )
{
}




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// (See <tt>FiniteStreamFilterBase< TIn, TOut >.Filter()</tt>)
///
protected override
bool
Filter(
    TIn         iin,
    out TSought iout
)
{
    bool result = false;
    iout = default( TSought );

    if( iin is TSought ) {
        result = true;
        iout = (TSought)iin;
    }

    return result;
}




} // type
} // namespace

