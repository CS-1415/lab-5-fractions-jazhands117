using NUnit.Framework;
using Lab05;

namespace Lab05.Tests;

public class MixedNumberTests
{
    [Test]
    public void Decomposes_PositiveImproperFraction()
    {
        var m = new MixedNumber(7, 3); // 7/3 -> 2 1/3
        Assert.That(m.WholeUnits, Is.EqualTo(2));
        Assert.That(m.PartialUnits.Numerator, Is.EqualTo(1));
        Assert.That(m.PartialUnits.Denominator, Is.EqualTo(3));
    }

    [Test]
    public void Decomposes_NegativeImproperFraction()
    {
        var m = new MixedNumber(-7, 3); // -7/3 -> -2 1/3 (WholeUnits -2, partial positive)
        Assert.That(m.WholeUnits, Is.EqualTo(-2));
        Assert.That(m.PartialUnits.Numerator, Is.EqualTo(1));
        Assert.That(m.PartialUnits.Denominator, Is.EqualTo(3));
    }

    [Test]
    public void Constructs_FromRationalNumber()
    {
        var r = new RationalNumber(7, 3);
        var m = new MixedNumber(r);
        Assert.That(m.WholeUnits, Is.EqualTo(2));
        Assert.That(m.PartialUnits.Numerator, Is.EqualTo(1));
        Assert.That(m.PartialUnits.Denominator, Is.EqualTo(3));
    }

    [Test]
    public void ZeroNumerator_ProducesZeroWhole()
    {
        var m = new MixedNumber(0, 5);
        Assert.That(m.WholeUnits, Is.EqualTo(0));
        Assert.That(m.PartialUnits.Numerator, Is.EqualTo(0));
        Assert.That(m.PartialUnits.Denominator, Is.EqualTo(1)); // RationalNumber normalizes 0 to 0/1
    }

    [Test]
    public void Equals_ReturnsTrue_ForEquivalentMixedNumbers()
    {
        var a = new MixedNumber(7, 3); // 2 1/3
        var b = new MixedNumber(new RationalNumber(7, 3));
        Assert.IsTrue(a.Equals(b));
        Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()));
        Assert.IsTrue(a == b);
    }

    [Test]
    public void Equals_ReturnsFalse_ForDifferentMixedNumbers()
    {
        var a = new MixedNumber(7, 3);
        var b = new MixedNumber(8, 3);
        Assert.IsFalse(a.Equals(b));
        Assert.IsTrue(a != b);
    }
}
