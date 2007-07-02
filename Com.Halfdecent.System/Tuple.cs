// -----------------------------------------------------------------------------
// Copyright (c) 2007 Ron MacNeil <macro187 AT users DOT sourceforge DOT net>
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



namespace
Com.Halfdecent.System
{


/// <summary>
/// A pair of values
/// </summary>
public struct
Tuple<TA,TB>
    : IEquatable<Tuple<TA,TB>>
{




// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

/// <summary>
/// Initialize a new <c>Tuple</c> with two given values
/// </summary>
public
Tuple(
    TA a,
    TB b
)
{
    this.a = a;
    this.b = b;
}




// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// <summary>
/// The first value
/// </summary>
public TA
A
{
    get { return this.a; }
}
private TA a;



/// <summary>
/// The second value
/// </summary>
public TB
B
{
    get { return this.b; }
}
private TB b;




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// <summary>(see System.IEquatable&lt;T&gt;.Equals)</summary>
public bool
Equals(
    Tuple<TA,TB> t
)
{
    return this.a.Equals( t.a ) && this.b.Equals( t.b );
}



/// <summary>(see System.Object.Equals)</summary>
public override bool
Equals(
    object o
)
{
    bool result = false;
    if( o is Tuple<TA,TB> ) {
        result = this.Equals( (Tuple<TA,TB>)o );
    }
    return result;
}



/// <summary>(see System.Object.GetHashCode)</summary>
public override int
GetHashCode()
{
    return this.a.GetHashCode() ^ this.b.GetHashCode();
}




} // type
} // namespace

