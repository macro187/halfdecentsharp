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


namespace
Com.Halfdecent.Meta
{


/// A method parameter
///
public class
Parameter
    : Value
{




public
Parameter(
    IValue parent,
    string name
)
    : base( name )
{
    if( parent == null ) throw new ArgumentNullException( "parent" );
    if( name == null ) throw new ArgumentNullException( "name" );
    if( name == "" ) throw new ArgumentException( "name is blank" );
    this.parent = parent;
    this.name = name;
}




public
IValue
Parent
{
    get { return this.parent; }
}

private
IValue
parent;



public
string
Name
{
    get { return this.name; }
}

private
string
name;




// TODO Compare-by-value Object.Equals() and friends



} // type
} // namespace

