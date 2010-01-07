// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009
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


using System;
using System.Collections.Generic;
using System.Linq;
using Com.Halfdecent.Testing;
using Com.Halfdecent.SystemUtils;


namespace
Com.Halfdecent.SystemUtils.Test
{


// =============================================================================
/// Test program for <tt>Com.Halfdecent.SystemUtils</tt>
// =============================================================================
//
public class
Tests
    : TestBase
{



public static
int
Main()
{
    return TestProgram.RunTests();
}



[Test( "EnumerableUtils" )]
public static
void
Test_EnumerableUtils()
{
    Print( ".Append()" );
    Assert(
        new int[]{ 1, 2, 3 }
        .Append( 4 )
        .SequenceEqual( new int[]{ 1, 2, 3, 4 } ) );

    Print( ".Covary< TTo >()" );
    Assert(
        new int[]{ 1, 2, 3 }
        .Covary< int, object >()
        .SequenceEqual(
            new object[]{ 1, 2, 3 } ) );

    Print( ".AsSingleItemEnumerable()" );
    Assert(
        1.AsSingleItemEnumerable()
        .SequenceEqual(
            new int[]{ 1 } ) );
}


[Test( "ExceptionUtils" )]
public static
void
Test_ExceptionUtils()
{
    Exception e = new Exception();
    Exception f = new Exception( "", e );
    Exception g = new Exception( "", f );
    Exception h = new Exception( "", g );
    Print( ".Chain()" );
    Assert(
        h.Chain()
        .SequenceEqual(
            Enumerable.Empty< Exception >()
            .Append( h )
            .Append( g )
            .Append( f )
            .Append( e ) ) );
}


[Test( "ObjectUtils" )]
public static
void
Test_ObjectUtils()
{
    Print( ".ToString()" );
    AssertEqual( ObjectUtils.ToString( null ), "null" );
    AssertEqual( ObjectUtils.ToString( "notnull" ), "notnull" );
}




} // type
} // namespace
