#region PERMUDA
// combos Byte SByte Int16 UInt16 Int32 UInt32 Int64 UInt64 Decimal
// filename In/*PERMUDA*/Range.cs
#endregion
// -----------------------------------------------------------------------------
// Copyright (c) 2008, 2009, 2010, 2012
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


using Halfdecent;
using Halfdecent.Meta;
using Halfdecent.RTypes;


namespace
Halfdecent.Numerics
{


// =============================================================================
/// RType: In range of <tt>System./*PERMUDA*/</tt>
// =============================================================================

public sealed class
In/*PERMUDA*/Range
    : CompositeRType< IReal >
{



// -----------------------------------------------------------------------------
// Static
// -----------------------------------------------------------------------------

public static
    void
CheckParameter(
    IReal   item,
    string  paramName
)
{
    ValueReferenceException.Map(
        f => f.Up().Parameter( paramName ),
        f => f.Down().Parameter( "item" ),
        () => Check( item ) );
}


public static new
    void
Check(
    IReal item
)
{
    ValueReferenceException.Map(
        f => f.Parameter( "item" ),
        f => f.Down().Parameter( "item" ),
        () => Create().Check( item ) );
}


public static
    RType< IReal >
Create()
{
    return instance;
}


private static
    In/*PERMUDA*/Range
instance = new In/*PERMUDA*/Range();



// -----------------------------------------------------------------------------
// Constructors
// -----------------------------------------------------------------------------

public
In/*PERMUDA*/Range()
    : base(
        SystemEnumerable.Create(
            InInterval.Create(
                Interval.Create(
                    Real.Create( System./*PERMUDA*/.MinValue ),
                    Real.Create( System./*PERMUDA*/.MaxValue ) ) ) ),
        r => _S("{0} is in range of System./*PERMUDA*/", r),
        r => _S("{0} is not in range of System./*PERMUDA*/", r),
        r => _S("{0} must be in range of System./*PERMUDA*/", r) )
{
}




private static Halfdecent.Globalisation.Localised< string > _S( string s, params object[] args ) { return Halfdecent.Globalisation.LocalisedResource._S( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, s, args ); }

} // type
} // namespace

