// -----------------------------------------------------------------------------
// Copyright (c) 2010, 2011
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


using Com.Halfdecent.RTypes;


namespace
Com.Halfdecent.Streams
{


public static class
SystemStream
{



// -----------------------------------------------------------------------------
// Extension Methods
// -----------------------------------------------------------------------------

public static
    IStream< byte >
AsHalfdecentStream(
    this System.IO.Stream dis
)
{
    NonNull.CheckParameter( dis, "dis" );
    return Stream.Create(
        () => {
            int i = dis.ReadByte();
            return i >= 0
                ? Maybe.Create( (byte)i )
                : Maybe.Create< byte >(); },
        () => {
            dis.Close(); });
}


public static
    ISink< byte >
AsHalfdecentSink(
    this System.IO.Stream dis
)
{
    NonNull.CheckParameter( dis, "dis" );
    return Sink.Create< byte >(
        b => dis.WriteByte( b ),
        () => {
            dis.Close(); } );
}




} // type
} // namespace

