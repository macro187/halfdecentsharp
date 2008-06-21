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


/// Fundamentals
///
/// A suite of exception types, all of which implement <tt>IHDException</tt>,
/// are available for direct use or for subclassing.  They are organised in a
/// regular fashion along two lines:
/// - Cause
/// - Programmatic entity
///
/// Causes fall into four main categories:
/// - <em>Illegal</em>, something that is never valid under any
///   circumstances.  This kind of circumstance is ideally prevented at
///   compile-time but, in situations where that isn't possible, this cause
///   represents the same level of severity at runtime.
/// - <em>Platform</em>, something that is not valid given the current
///   hardware architecture, operating system, etc.
/// - <em>Environment</em>, something that is not valid given the current
///   external runtime environment, eg. software configuration, shared library
///   availability, etc.
/// - <em>State</em>, something that is not valid given the current internal
///   execution state, program or user input, etc.
///
/// The exception classes are summarised in the following table:
/// <pre>
/// ------------+-----------------------------------------------------------------------
/// CAUSE       |   VALUE                       OPERATION
/// ------------+-----------------------------------------------------------------------
/// State       |   ValueException              OperationException
///             |     (ArgumentException, etc.)   (InvalidOperationException)
/// Environment |   EnvironmentValueException   EnvironmentOperationException
///             |     (?)                         (?)
/// Platform    |   PlatformValueException      PlatformOperationException
///             |     (?)                         (PlatformNotSupportedException)
/// Illegal     |   IllegalValueException       IllegalOperationException
///             |     (NotSupportedException)     (OperationNotSupportedException)
/// ------------+-----------------------------------------------------------------------
/// </pre>
/// <table>
/// <tr>
///     <td><em>Cause</em></td>
///     <td><em>Value</em></td>
///     <td><em>Operation</em></td>
/// </tr>
/// </table>
///
namespace
Com.Halfdecent.System
{
}

