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


using System.Linq;
using Com.Halfdecent.Streams;
using Com.Halfdecent.IO;
using Com.Halfdecent.Testing;


namespace
Com.Halfdecent.IO.Test
{


// =============================================================================
/// Test program for <tt>Com.Halfdecent.IO</tt>
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



[Test( "System.IO.Stream::AsHalfdecentStream()" )]
public static
void
Test_System_IO_Stream__AsHalfdecentStream()
{
    IStream< byte > s =
        new System.IO.MemoryStream(
            new byte[] { 0, 1, 2, 3 } )
        .AsHalfdecentStream();
    Assert( s.Pull() == 0 );
    Assert( s.Pull() == 1 );
    Assert( s.Pull() == 2 );
    Assert( s.Pull() == 3 );
    byte b;
    Assert( !s.TryPull( out b ) );
}


[Test( "System.IO.Stream::AsHalfdecentSink()" )]
public static
void
Test_System_IO_Stream__AsHalfdecentSink()
{
    System.IO.MemoryStream ms = new System.IO.MemoryStream();
    ISink< byte > s = ms.AsHalfdecentSink();
    s.Push( (byte)0 );
    s.Push( (byte)1 );
    s.Push( (byte)2 );
    s.Push( (byte)3 );
    Assert( ms.ToArray().SequenceEqual( new byte[] { 0, 1, 2, 3 } ) );
}




} // type
} // namespace

