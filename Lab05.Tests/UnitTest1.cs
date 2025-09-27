// Kept all nomenclature the same as the example provided
namespace Lab05.Tests;

using NUnit.Framework;
using System;
using Lab05;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SimplifiesFraction_OnConstruction()
    {
    var r = new RationalNumber(12, 6);
    Assert.That(r.Numerator, Is.EqualTo(2));
    Assert.That(r.Denominator, Is.EqualTo(1));
    }

    [Test]
    public void KeepsSign_OnNegativeNumerator()
    {
    var r = new RationalNumber(-3, 9);
    Assert.That(r.Numerator, Is.EqualTo(-1));
    Assert.That(r.Denominator, Is.EqualTo(3));
    }

    [Test]
    public void MovesSignToNumerator_WhenDenominatorNegative()
    {
    var r = new RationalNumber(1, -2);
    Assert.That(r.Numerator, Is.EqualTo(-1));
    Assert.That(r.Denominator, Is.EqualTo(2));
    }

    [Test]
    public void ZeroNumerator_BecomesZeroOverOne()
    {
    var r = new RationalNumber(0, 5);
    Assert.That(r.Numerator, Is.EqualTo(0));
    Assert.That(r.Denominator, Is.EqualTo(1));
    }

    // Learned "Throws"!
    [Test]
    public void Throws_OnZeroDenominator()
    {
        Assert.Throws<ArgumentException>(() => new RationalNumber(1, 0));
    }

    [Test]
    public void Equals_ReturnsTrue_ForEquivalentRationals()
    {
        var a = new RationalNumber(2, 4); // tests if simplifies to 1/2
        var b = new RationalNumber(1, 2);
        Assert.IsTrue(a.Equals(b));
        Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()));
        Assert.IsTrue(a == b);
        Assert.IsFalse(a != b);
    }

    [Test]
    public void Equals_ReturnsFalse_ForDifferentRationals()
    {
        var a = new RationalNumber(1, 3);
        var b = new RationalNumber(1, 2);
        Assert.IsFalse(a.Equals(b));
    }

    [Test]
    public void Create_Rational_PosPos()
    {
        var r = new RationalNumber(3, 4);
        Assert.That(r.Numerator, Is.EqualTo(3));
        Assert.That(r.Denominator, Is.EqualTo(4));
    }

    [Test]
    public void Create_Rational_PosNeg()
    {
        var r = new RationalNumber(3, -4);
        Assert.That(r.Numerator, Is.EqualTo(-3));
        Assert.That(r.Denominator, Is.EqualTo(4));
    }

    [Test]
    public void Create_Rational_NegPos()
    {
        var r = new RationalNumber(-3, 4);
        Assert.That(r.Numerator, Is.EqualTo(-3));
        Assert.That(r.Denominator, Is.EqualTo(4));
    }

    [Test]
    public void Create_Rational_NegNeg()
    {
        var r = new RationalNumber(-3, -4);
        Assert.That(r.Numerator, Is.EqualTo(3));
        Assert.That(r.Denominator, Is.EqualTo(4));
    }

    [Test]
    public void Simplifiable_Rational_IsReduced()
    {
        var r = new RationalNumber(10, 20);
        Assert.That(r.Numerator, Is.EqualTo(1));
        Assert.That(r.Denominator, Is.EqualTo(2));
    }

    [Test]
    public void NonSimplifiable_Rational_Unchanged()
    {
        var r = new RationalNumber(3, 7);
        Assert.That(r.Numerator, Is.EqualTo(3));
        Assert.That(r.Denominator, Is.EqualTo(7));
    }

    [Test]
    public void RationalEquality_20over10_equals_4over2()
    {
        var a = new RationalNumber(20, 10);
        var b = new RationalNumber(4, 2);
        Assert.IsTrue(a.Equals(b));
        Assert.IsTrue(a == b);
    }

    [Test]
    public void MixedNumber_Decomposes_ToWholeAndPartial()
    {
        var m = new MixedNumber(7, 3);
        Assert.That(m.WholeUnits, Is.EqualTo(2));
        Assert.That(m.PartialUnits.Numerator, Is.EqualTo(1));
        Assert.That(m.PartialUnits.Denominator, Is.EqualTo(3));
    }

    [Test]
    public void MixedNumber_NoWholeValue()
    {
        var m = new MixedNumber(1, 3);
        Assert.That(m.WholeUnits, Is.EqualTo(0));
        Assert.That(m.PartialUnits.Numerator, Is.EqualTo(1));
        Assert.That(m.PartialUnits.Denominator, Is.EqualTo(3));
    }

    [Test]
    public void MixedNumberEquality_125over50_equals_5over2()
    {
        var a = new MixedNumber(125, 50);
        var b = new MixedNumber(5, 2);
        Assert.IsTrue(a.Equals(b));
        Assert.IsTrue(a == b);
    }
}