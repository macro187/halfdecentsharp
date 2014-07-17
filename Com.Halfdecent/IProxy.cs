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


namespace
Com.Halfdecent
{


// =============================================================================
/// An object acting as a proxy for another object
//
// TODO
// Discussion of exactly what it means to be a "proxy", i.e. adds an interface
// to an underlying object, and is "proxy" indeed the right term for this?
//
// TODO
// Further discussion of other kinds of wrappers that are meant to hide the
// underlying object, correct terminology, etc.
//
// =============================================================================

public interface
IProxy
{


// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// The underlying object for which this object is acting as a proxy
///
object
Underlying
{
    get;
}




} // type
} // namespace

