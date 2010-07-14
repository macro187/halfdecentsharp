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


using System;
using System.Text;


namespace
Com.Halfdecent.Text
{


// =============================================================================
/// Predefined text encodings
// =============================================================================

public static class
Encodings
{



// -----------------------------------------------------------------------------
// Properties
// -----------------------------------------------------------------------------

/// UTF-8, no byte-order-mark
///
public static
    Encoding
UTF8
{
    get { return new UTF8Encoding( false, true ); }
}


/// UTF-8, byte-order-mark
///
public static
    Encoding
UTF8BOM
{
    get { return new UTF8Encoding( true, true ); }
}


public static
    Encoding
UTF16
{
    get { return BitConverter.IsLittleEndian ? UTF16LE : UTF16BE; }
}


public static
    Encoding
UTF16BOM
{
    get { return BitConverter.IsLittleEndian ? UTF16LEBOM : UTF16BEBOM; }
}


public static
    Encoding
UTF16LE
{
    get { return new UnicodeEncoding( false, false, true ); }
}


public static
    Encoding
UTF16LEBOM
{
    get { return new UnicodeEncoding( false, true, true ); }
}


public static
    Encoding
UTF16BE
{
    get { return new UnicodeEncoding( true, false, true ); }
}


public static
    Encoding
UTF16BEBOM
{
    get { return new UnicodeEncoding( true, true, true ); }
}


public static
    Encoding
UTF32
{
    get { return BitConverter.IsLittleEndian ? UTF32LE : UTF32BE; }
}


public static
    Encoding
UTF32BOM
{
    get { return BitConverter.IsLittleEndian ? UTF32LEBOM : UTF32BEBOM; }
}


public static
    Encoding
UTF32LE
{
    get { return new UnicodeEncoding( false, false, true ); }
}


public static
    Encoding
UTF32LEBOM
{
    get { return new UnicodeEncoding( false, true, true ); }
}


public static
    Encoding
UTF32BE
{
    get { return new UnicodeEncoding( true, false, true ); }
}


public static
    Encoding
UTF32BEBOM
{
    get { return new UnicodeEncoding( true, true, true ); }
}




} // type
} // namespace

