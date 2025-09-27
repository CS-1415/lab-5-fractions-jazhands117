using System;

namespace Lab05;

//had help on this chunk//
public class RationalNumber : IEquatable<RationalNumber>
{
    public int Numerator { get; }
    public int Denominator { get; }

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero", nameof(denominator));
        }

        if (numerator == 0)
        {
            Numerator = 0;
            Denominator = 1;
            return;
        }

        //normalize sign: denominator always positive!//
        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        int gcd = GreatestCommonDenominator(numerator, denominator);
        Numerator = numerator / gcd;
        Denominator = denominator / gcd;
    }

    private static int GreatestCommonDenominator(int a, int b)
    {
        if (b == 0)
        {
            return Math.Abs(a);
        }
        else
        {
            return GreatestCommonDenominator(b, a % b);
        }
    }

    //nullable//
    public bool Equals(RationalNumber? other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Numerator == other.Numerator && Denominator == other.Denominator;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as RationalNumber);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator);
    }

    public static bool operator ==(RationalNumber? left, RationalNumber? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;
        return left.Equals(right);
    }

    public static bool operator !=(RationalNumber? left, RationalNumber? right)
    {
        return !(left == right);
    }
}
