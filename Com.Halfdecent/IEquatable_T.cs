// -----------------------------------------------------------------------------
// Copyright (c) 2009
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
Com.Halfdecent
{


// =============================================================================
/// A type that introduces a new definition of equality
///
/// @section implementing Implementing
///
///     -#  Implement <tt>Equals()</tt> using <tt>Equatable.Equals<T>()</tt>,
///         which handles <tt>null</tt> and checks both items'
///         <tt>DirectionalEquals()</tt> for you.  Should not be
///         <tt>virtual</tt> as this should not change.
///         .
///     -#  Implement <tt>DirectionalEquals()</tt> with your new equality
///         implementation.  If you expect subclasses, this should be
///         <tt>virtual</tt> so they can refine as necessary.
///         .
///     -#  Implement <tt>GetHashCode()</tt> to provide hash codes
///         compatible<sup>1</sup> with your <tt>DirectionalEquals()</tt>
///         implementation.  This will require an explicit interface member
///         implementation to distinguish from
///         <tt>System.Object.GetHashCode()</tt>.  If you expect subclasses,
///         implement in a separate <tt>protected virtual</tt> method so they
///         can refine as necessary (as illustrated in the following example).
///
///     Example:
///     <code>
///     //
///     // Com.Halfdecent.IEquatable<T> Implementation Example
///     //
///     public interface IFoo : Halfdecent.IEquatable<IFoo>
///     {
///         int Field1;
///         int Field2;
///     }
///
///     public class C : IFoo
///     {
///         public bool Equals( IFoo that )
///         {
///             // Always use Equatable.Equals() to implement .Equals()
///             return Equatable.Equals( this, that );
///         }
///
///         public virtual bool DirectionalEquals( IFoo that )
///         {
///             // Your equality implementation in terms of IFoo
///             return
///                 // Check for null
///                 that != null &&
///                 // Check members for equality
///                 that.Field1.Equals( this.Field1 ) &&
///                 that.Field2.Equals( this.Field2 );
///         }
///
///         // Explicit interface implementation so this implementation
///         // doesn't collide with that of <tt>System.Object</tt> or other
///         // IComparable<T> interfaces.
///         int Halfdecent.IEquatable<IFoo>.GetHashCode() {
///             return this.IFooGetHashCode();
///         }
///
///         protected virtual int IFooGetHashCode() {
///             // Your hash code implementation with the same semantics as
///             // your DirectionalEquals() implementation above
///             return
///                 // Factor in the type
///                 typeof( IFoo ).GetHashCode() ^
///                 // Factor in members
///                 this.Field1.GetHashCode() ^
///                 this.Field2.GetHashCode();
///         }
///     }
///     </code>
///
///     <sup>1</sup>Refer to the <tt>GetHashCode()</tt> documentation for
///     details
///
// =============================================================================

public interface
IEquatable<
    T
    ///< The type
>
{



// -----------------------------------------------------------------------------
// Methods
// -----------------------------------------------------------------------------

/// Determine whether this and another item are equal
///
/// That is, <tt>this</tt> and <tt>that</tt> <tt>DirectionalEquals()</tt> each
/// other.
///
/// This method should be implemented using <tt>Equatable.Equals<T>()</tt>.
///
    bool
Equals(
    T that
);


/// Determine whether this item considers itself equal to another
///
    bool
DirectionalEquals(
    T that
);


/// Generate a hash code for this item according to this definition of equality
///
/// Subject to the same requirements as <tt>System.Object.GetHashCode()</tt>,
/// specifically:
/// - If <tt>a.Equals( b )</tt> then <tt>a.GetHashCode()</tt> must equal
///   <tt>b.GetHashCode()</tt>.
///
    int
GetHashCode();




} // type
} // namespace

