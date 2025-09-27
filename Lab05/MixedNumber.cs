using System;

namespace Lab05;

public class MixedNumber : IEquatable<MixedNumber>
{
    // Number of whole units (can be negative)
    public int WholeUnits { get; }

    // Remaining fractional part as a RationalNumber (always normalized by RationalNumber)
    public RationalNumber PartialUnits { get; }

    public MixedNumber(int numerator, int denominator)
        : this(new RationalNumber(numerator, denominator))
    {
    }

    public MixedNumber(RationalNumber r)
    {
        if (r == null) throw new ArgumentNullException(nameof(r));

        int whole = r.Numerator / r.Denominator;
        int rem = Math.Abs(r.Numerator % r.Denominator);

        WholeUnits = whole;
        PartialUnits = new RationalNumber(rem, r.Denominator);
    }

    public override string ToString()
    {
        if (PartialUnits.Numerator == 0) return WholeUnits.ToString();
        return $"{WholeUnits} {PartialUnits.Numerator}/{PartialUnits.Denominator}";
    }
    public RationalNumber ToRational()
    {
        // whole + partialUnits
        int num = WholeUnits * PartialUnits.Denominator + (WholeUnits >= 0 ? PartialUnits.Numerator : -PartialUnits.Numerator);
        return new RationalNumber(num, PartialUnits.Denominator);
    }

    public bool Equals(MixedNumber? other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(this, other)) return true;
        return ToRational().Equals(other.ToRational());
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as MixedNumber);
    }

    public override int GetHashCode()
    {
        var r = ToRational();
        return HashCode.Combine(r.Numerator, r.Denominator);
    }

    public static bool operator ==(MixedNumber? left, MixedNumber? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;
        return left.Equals(right);
    }

    public static bool operator !=(MixedNumber? left, MixedNumber? right)
    {
        return !(left == right);
    }
}
