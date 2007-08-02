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
using System.Collections.Generic;

using Com.Halfdecent.System.Globalization;

using Com.Halfdecent.Testing;
using Com.Halfdecent.CommandLine;



namespace
Com.Halfdecent.CommandLine.Test
{



/// <summary>
/// Tests for <c>Com.Halfdecent.CommandLine</c>
/// </summary>
public class
Tests
    : TestBase
{




// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// <summary>
/// Test program entry point
/// </summary>
public static int
Main()
{
    return TestProgram.RunTests();
}




// -----------------------------------------------------------------------------
// Tests
// -----------------------------------------------------------------------------

[Test( "CommandLineException" )]
public static void
Test_CommandLineException()
{
    Exception e;

    Print( "new CommandLineException()" );
    e = new CommandLineException();

    Print( "new CommandLineException( Localized<string> )" );
    e = new CommandLineException( new InMemoryLocalized<string>(
        "Invalid command line" ) );

    if( e == null ) {}
}



[Test( "Option" )]
public static void
Test_Option()
{
    Option s;

    Print( "Create" );
    s = new Option( "myname", "myvalue" );
    Print( "Check .Name" );
    AssertEqual( s.Name, "myname" );
    Print( "Check .Value" );
    AssertEqual( s.Value, "myvalue" );
}


[Test( "OptionSpec" )]
public static void
Test_OptionSpec()
{
    OptionSpec spec;
    IList<OptionSpec> specs;
    string optstring;
    bool threw;

    Print( "OptionSpec( name )" );
    spec = new OptionSpec( "myname" );
    Print( "Check .Name" );
    AssertEqual( spec.Name, "myname" );
    Print( "Check .TakesValue" );
    AssertEqual( spec.TakesValue, false );

    Print( "OptionSpec( name, takesvalue )" );
    spec = new OptionSpec( "myname", true );
    Print( "Check .Name" );
    AssertEqual( spec.Name, "myname" );
    Print( "Check .TakesValue" );
    AssertEqual( spec.TakesValue, true );

    optstring = "vo:q";
    Print( "SpecsFromString()" );
    specs = OptionSpec.SpecsFromString( optstring );
    Print( "Check number of specs" );
    AssertEqual( specs.Count, 3 );
    Print( "Check specs" );
    AssertEqual( specs[0].Name, "v" );
    AssertEqual( specs[0].TakesValue, false );
    AssertEqual( specs[1].Name, "o" );
    AssertEqual( specs[1].TakesValue, true );
    AssertEqual( specs[2].Name, "q" );
    AssertEqual( specs[2].TakesValue, false );
    Print( "SpecsFromString() with illegal chars" );
    optstring = ":def";
    threw = false;
    try {
        specs = OptionSpec.SpecsFromString( optstring );
    } catch( ArgumentException ae ) {
        threw = true;
        if( ae == null ) {}
    }
    Print( "Check that ArgumentException was thrown" );
    AssertEqual( threw, true );
}



[Test( "DashCharOptionReader" )]
public static void
Test_DashCharOptionReader()
{
    IList<OptionSpec> specs;
    IList<string> args;
    OptionReader reader;
    IList<Option> options;
    bool thrown;

    specs = OptionSpec.SpecsFromString( "qro:v" );
    args = new List<string>(
        new string[] { "-vqr", "-o", "outfile", "file1", "file2" } );
    Print( "Create DashCharOptionReader" );
    reader = new DashCharOptionReader( args, specs );
    Print( "ReadConsecutive()" );
    options = reader.ReadConsecutive();
    Print( "Check count" );
    AssertEqual( options.Count, 4 );
    Print( "Check options" );
    AssertEqual( options[0].Name, "v" );
    AssertEqual( options[0].Value, "" );
    AssertEqual( options[1].Name, "q" );
    AssertEqual( options[1].Value, "" );
    AssertEqual( options[2].Name, "r" );
    AssertEqual( options[2].Value, "" );
    AssertEqual( options[3].Name, "o" );
    AssertEqual( options[3].Value, "outfile" );

    Print( "Create DashCharOptionReader w/ illegal option" );
    specs = OptionSpec.SpecsFromString( "qro:v" );
    args = new List<string>(
        new string[] { "-vqxr", "-o", "outfile", "file1", "file2" } );
    reader = new DashCharOptionReader( args, specs );
    Print( "ReadConsecutive()" );
    thrown = false;
    try {
        options = reader.ReadConsecutive();
    } catch( UnrecognizedOptionException e ) {
        thrown = true;
        if( e == null ) {}
    }
    Print( "Check for UnrecognizedOptionException" );
    AssertEqual( thrown, true );

    Print( "Create DashCharOptionReader w/ missing option value" );
    specs = OptionSpec.SpecsFromString( "qro:v" );
    args = new List<string>(
        new string[] { "-vqor", "file1", "file2" } );
    reader = new DashCharOptionReader( args, specs );
    Print( "ReadConsecutive()" );
    thrown = false;
    try {
        options = reader.ReadConsecutive();
    } catch( MissingOptionValueException e ) {
        thrown = true;
        if( e == null ) {}
    }
    Print( "Check for MissingOptionValueException" );
    AssertEqual( thrown, true );
}




} // type
} // namespace

