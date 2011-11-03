// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010, 2011
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



// =============================================================================
/// Localisable assets embedded in assemblies
///
/// @section problem Problems
///
///     -   The static resource retrieval methods in
///         <tt>System.Resources.ResourceManager</tt> are not strongly typed.
///
///     -   Depending on the .NET implementation,
///         <tt>System.Resources.ResourceManager</tt> may or may not search the
///         main assembly for resources before searching satellite assemblies.
///
///     -   If a resource can't be found,
///         <tt>System.Resources.ResourceManager</tt> behaves differently
///         depending on whether it's because it wasn't among the resources that
///         were there or because there were no resources at all; this
///         distinction is irrelevant and only adds complication that is
///         unnecessary and easy to overlook.
///
///     -   The parent-based culture fallback mechanism built into
///         <tt>System.Resources.ResourceManager</tt> may be overly-simplistic
///         and cannot be modified.
///
///
/// @section solution Solution
///
///     @subsection api Static API
///
///         A simple, predictable API for retrieving resources.
///
///         -   <tt>Resource.Get<T>()</tt>, for retrieving resources
///
///         -   <tt>ResourceTypeMismatchException</tt>, for when a resource is
///             not of the expected type
///
///         -   Strongly-typed
///
///         -   No culture fallback occurs; either the exact resource you
///             request is there or it isn't.  Sophisticated culture fallback
///             mechanisms can be (and are) built on top of this API.
///
///         -   Always checks for resources in the containing type's main
///             assembly first
///
///
/// @section reference Embedded Resources in .NET Reference
///
///     The processes, mechanisms, and terminology surrounding embedded
///     resources are complicated and sparsely documented.  Collected here for
///     reference is a survey of how embedded resources work.
///
///     @subsection resource Resource
///
///         An external read-only object of any .NET type retrieved by name at
///         run time.
///
///     @subsection resource_set Resource set
///
///         A uniquely-keyed collection of resources.
///
///
///     @subsection resources_file_format .resources file format
///
///         A binary file format containing a resource set, usually with the
///         filename extension <tt>.resources</tt>. <sup>[1]</sup>
///
///
///     @subsection resourcereader ResourceReader and ResourceWriter classes
///
///         Base Class Library classes that can read and write the .resources
///         file format. <sup>[2] [3]</sup>  Internally,
///         System.Runtime.Serialization.Formatters.Binary.BinaryFormatter is
///         used to convert objects to and from a binary format.  [4]
///
///
///     @subsection resx_file_format <tt>.resx</tt> file format
///
///         An XML file format containing a resource set, usually with the
///         filename extension <tt>.resx</tt>. <sup>[5]</sup>  Generally, simple
///         types of resources like strings and numbers are represented as text,
///         and more complicated types are represented as base64-encoded binary.
///
///
///     @subsection resxresourcereader ResXResourceReader and ResXResourceWriter classes
///
///         Base Class Library classes that can read and write the .resx file
///         format. <sup>[6] [7]</sup>
///
///
///     @subsection resgen resgen program
///
///         A tool that can transform <tt>.resx</tt> files into
///         <tt>.resource</tt> files and vice-versa. <sup>[8] [9]</sup>
///
///
///     @subsection resourceset ResourceSet and ResXResourceSet classes
///
///         Base Class Library classes that provide access to resource sets
///         through an interface resembling a read-only string-to-object
///         dictionary. <sup>[10] [11]</sup>
///
///         ResourceSet uses ResourceReader to access resources in .resources
///         file format.
///
///         ResXResourceSet uses ResXResourceReader to access resources in .resx
///         file format.
///
///
///     @subsection embedded_file Embedded file
///
///         A named, read-only byte blob embedded in an assembly via the
///         linker's <tt>/embed</tt> switch or the compiler's
///         (confusingly-named) <tt>/resource</tt> switch.  Embedded files are
///         sometimes referred to as "embedded resources" leading to confusion
///         with individual resource objects encoded in <tt>.resources</tt> or
///         <tt>.resx</tt> files.  Embedded files are accessed at run time as
///         read-only System.IO.Stream objects retrieved using
///         System.Reflection.Assembly.GetManifestResourceStream().
///         <sup>[12]</sup> Note that the Microsoft documentation sometimes
///         treats this topic in a way that suggests that embedded files must be
///         resource-related, which is not the case.  Embedded files are just
///         named bags of bytes.
///
///
///     @subsection embedding_scheme Resource Embedding Scheme
///
///         Each resource "belongs" to the type where it is used.
///         <tt>.resources</tt> files are embedded in assemblies, each
///         containing resources in one language for one type in that assembly.
///
///         The embedded <tt>.resources</tt> files adhere to a naming convention
///         indicating the language and owning type of the resources contained
///         therein:
///
///             <tt><Namespace>.<Type>[.<culture>].resources</tt>
/// 
///         The omission of the culture from the filename indicates the default
///         set of resources for the type, or its "neutral resources".  (Note
///         this has no connection to "neutral cultures" i.e.
///         non-country-specific cultures e.g. <tt>en</tt> instead of
///         <tt>en_US</tt>)
///
///         The general idea is to have a full set of default resources, plus
///         overrides for some or all of them in various languages.
///
///         An example assembly containing three types spanning two namespaces,
///         each with default resources plus some japanese, french, and Canadian
///         french overrides might look like:
///
///         -   MyAssembly.dll
///             -   Types
///                 -   NamespaceA.TypeA
///                 -   NamespaceA.TypeB
///                 -   NamespaceB.TypeA
///             -   Embedded Files
///                 -   NamespaceA.TypeA.resources
///                 -   NamespaceA.TypeA.ja.resources
///                 -   NamespaceA.TypeA.fr_FR.resources
///                 -   NamespaceA.TypeA.fr_CA.resources
///                 -   NamespaceA.TypeB.resources
///                 -   NamespaceA.TypeB.ja.resources
///                 -   NamespaceA.TypeB.fr_FR.resources
///                 -   NamespaceA.TypeB.fr_CA.resources
///                 -   NamespaceB.TypeA.resources
///                 -   NamespaceB.TypeA.ja.resources
///                 -   NamespaceB.TypeA.fr_FR.resources
///                 -   NamespaceB.TypeA.fr_CA.resources
///
///
///     @subsection resourcemanager ResourceManager
///
///         An object used at runtime to retrieve embedded resources belonging
///         to a particular type. <sup>[13]</sup>  %Resources are requested by
///         name, and ResourceManager attempts to locate the most appropriate
///         variation of the named resource for the current (or a specified)
///         language.  The "current" language is indicated by
///         <tt>System.Threading.Thread.CurrentThread.CurrentUICulture</tt>.
///
///         ResourceManager implementes a simple fallback mechanism whereby
///         "parent" cultures are checked if a requested resource is not found
///         for the exact culture specified.
///
///         (TODO: Reverse-engineer and document the exact fallback process,
///         including how it is affected by the presence of
///         System.Resources.NeutralResourcesLanguageAttribute on the assembly)
///
///
/// @section references References
///
///     <sup>[1]</sup> "Resources in .Resources File Format",
///     <tt>http://msdn.microsoft.com/en-us/library/zew6azb7.aspx</tt>
///
///     <sup>[2]</sup> "ResourceReader Class",
///     <tt>http://msdn.microsoft.com/en-us/library/system.resources.resourcereader.aspx</tt>
///
///     <sup>[3]</sup> "ResourceWriter Class",
///     <tt>http://msdn.microsoft.com/en-us/library/system.resources.resourcewriter.aspx</tt>
///
///     <sup>[4]</sup> Mono ResourceWriter source code,
///     <tt>http://github.com/mono/mono/blob/master/mcs/class/corlib/System.Resources/ResourceWriter.cs#L218</tt>
///
///     <sup>[5]</sup> "Resources in .resx File Format",
///     <tt>http://msdn.microsoft.com/en-us/library/ekyft91f.aspx</tt>
///
///     <sup>[6]</sup> "ResXResourceReader Class",
///     <tt>http://msdn.microsoft.com/en-us/library/system.resources.resxresourcereader.aspx</tt>
///
///     <sup>[7]</sup> "ResXResourceWriter Class",
///     <tt>http://msdn.microsoft.com/en-us/library/system.resources.resxresourcewriter.aspx</tt>
///
///     <sup>[8]</sup> "Resgen.exe (Resource File Generator)",
///     <tt>http://msdn.microsoft.com/en-us/library/ccec7sz1.aspx</tt>
///
///     <sup>[9]</sup> Mono resgen(1) man page,
///     <tt>http://www.go-mono.com/docs/index.aspx?tlink=32@man%3aresgen%281%29</tt>
///
///     <sup>[10]</sup> "ResourceSet Class",
///     <tt>http://msdn.microsoft.com/en-us/library/system.resources.resourceset.aspx</tt>
///
///     <sup>[11]</sup> "ResXResourceSet Class",
///     <tt>http://msdn.microsoft.com/en-us/library/system.resources.resxresourceset.aspx</tt>
///
///     <sup>[12]</sup> "Assembly.GetManifestResourceStream Method (String)",
///     <tt>http://msdn.microsoft.com/en-us/library/xc4235zt.aspx</tt>
///
///     <sup>[13]</sup> "ResourceManager Class",
///     <tt>http://msdn.microsoft.com/en-us/library/system.resources.resourcemanager.aspx</tt>
///
///
// =============================================================================

namespace
Com.Halfdecent.Resources
{
}

