// -----------------------------------------------------------------------------
// Copyright (c) 2011, 2012
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
Com.Halfdecent.Streams
{


// =============================================================================
/// Filter state enumeration
// =============================================================================

public class
FilterState
{


// -----------------------------------------------------------------------------
// Static
// -----------------------------------------------------------------------------

/// The filter has not started
///
public static readonly
FilterState
NotStarted = new FilterState( "NotStarted" );


/// The filter requires an item
///
public static readonly
FilterState
Want = new FilterState( "Want" );


/// The filter has produced an item
///
public static readonly
FilterState
Have = new FilterState( "Have" );


/// The filter can no longer accept nor produce any more items
///
public static readonly
FilterState
Closed = new FilterState( "Closed" );



// -----------------------------------------------------------------------------
// Object
// -----------------------------------------------------------------------------

public override
    string
ToString()
{
    return string.Concat( "FilterState:", this.Tag );
}



// -----------------------------------------------------------------------------
// Private
// -----------------------------------------------------------------------------

private
FilterState(
    string tag
)
{
    this.Tag = tag;
}

private
string
Tag;




} // type
} // namespace

